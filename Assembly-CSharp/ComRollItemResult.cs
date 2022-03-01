using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001074 RID: 4212
public class ComRollItemResult : MonoBehaviour
{
	// Token: 0x06009F2D RID: 40749 RVA: 0x001FC9DF File Offset: 0x001FADDF
	private void Start()
	{
	}

	// Token: 0x06009F2E RID: 40750 RVA: 0x001FC9E1 File Offset: 0x001FADE1
	private void OnDestroy()
	{
		if (this.comItem != null)
		{
			ComItemManager.Destroy(this.comItem);
			this.comItem = null;
		}
	}

	// Token: 0x06009F2F RID: 40751 RVA: 0x001FCA08 File Offset: 0x001FAE08
	private void SetPlayerInfo(int index, RollDropResultItem player)
	{
		if (index < 0 || index >= 3)
		{
			return;
		}
		if (player.opType == 1)
		{
			if (this.hum[index] != null && this.hum[index].gameObject != null)
			{
				this.hum[index].gameObject.CustomActive(false);
			}
			if (this.roll[index] != null && this.roll[index].gameObject != null)
			{
				this.roll[index].gameObject.CustomActive(true);
			}
		}
		else if (player.opType == 2)
		{
			if (this.hum[index] != null && this.hum[index].gameObject != null)
			{
				this.hum[index].gameObject.CustomActive(true);
			}
			if (this.roll[index] != null && this.roll[index].gameObject != null)
			{
				this.roll[index].gameObject.CustomActive(false);
			}
		}
		else
		{
			if (this.hum[index] != null && this.hum[index].gameObject != null)
			{
				this.hum[index].gameObject.CustomActive(false);
			}
			if (this.roll[index] != null && this.roll[index].gameObject != null)
			{
				this.roll[index].gameObject.CustomActive(false);
			}
		}
		if (this.score[index] != null)
		{
			this.score[index].text = string.Format("{0}点", player.point);
		}
	}

	// Token: 0x06009F30 RID: 40752 RVA: 0x001FCBF0 File Offset: 0x001FAFF0
	public void Init(ItemData itemData, List<RollDropResultItem> playerInfos)
	{
		this.curItemData = itemData;
		if (this.comItem == null)
		{
			this.comItem = ComItemManager.Create(this.item);
		}
		if (this.curItemData != null && this.itemName != null)
		{
			ItemData.QualityInfo qualityInfo = this.curItemData.GetQualityInfo();
			if (qualityInfo != null)
			{
				this.itemName.color = qualityInfo.Col;
			}
			this.itemName.text = this.curItemData.Name;
		}
		if (this.comItem != null)
		{
			this.comItem.Setup(this.curItemData, new ComItem.OnItemClicked(this.OnItemClick));
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.playerRoot.Length; i++)
		{
			if (!(this.playerRoot[i] == null))
			{
				if (i < playerInfos.Count)
				{
					RollDropResultItem rollDropResultItem = playerInfos[i];
					if (rollDropResultItem == null)
					{
						if (this.playerRoot[i].gameObject != null)
						{
							this.playerRoot[i].gameObject.CustomActive(false);
						}
					}
					else
					{
						if (this.playerRoot[i].gameObject != null)
						{
							this.playerRoot[i].gameObject.CustomActive(true);
						}
						if (rollDropResultItem.opType <= 2 && rollDropResultItem.opType >= 0)
						{
							int opType = (int)rollDropResultItem.opType;
						}
						this.SetPlayerInfo(i, rollDropResultItem);
						if (num2 < (int)rollDropResultItem.point)
						{
							num = i;
							num2 = (int)rollDropResultItem.point;
						}
					}
				}
				else if (this.playerRoot[i].gameObject != null)
				{
					this.playerRoot[i].gameObject.CustomActive(false);
				}
			}
		}
		for (int j = 0; j < 3; j++)
		{
			RollDropResultItem rollDropResultItem2 = null;
			if (j < playerInfos.Count)
			{
				rollDropResultItem2 = playerInfos[j];
			}
			if (rollDropResultItem2 != null)
			{
				if (j == num)
				{
					if (this.playerName[j] != null)
					{
						this.playerName[j].text = string.Format("<color=#ffe23cf6>{0}</color>", rollDropResultItem2.playerName);
					}
					if (this.winBG[j] != null && this.winBG[j].gameObject != null)
					{
						this.winBG[j].gameObject.CustomActive(true);
					}
					if (this.win[j] != null && this.win[j].gameObject != null)
					{
						this.win[j].gameObject.CustomActive(true);
					}
				}
				else
				{
					if (this.playerName[j] != null)
					{
						this.playerName[j].text = string.Format("<color=#ffffffff>{0}</color>", rollDropResultItem2.playerName);
					}
					if (this.winBG[j] != null && this.winBG[j].gameObject != null)
					{
						this.winBG[j].gameObject.CustomActive(false);
					}
					if (this.win[j] != null && this.win[j].gameObject != null)
					{
						this.win[j].gameObject.CustomActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06009F31 RID: 40753 RVA: 0x001FCF7E File Offset: 0x001FB37E
	private void OnItemClick(GameObject obj, ItemData itemData)
	{
		if (itemData == null)
		{
			return;
		}
		DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
	}

	// Token: 0x040057A4 RID: 22436
	public GameObject[] playerRoot = new GameObject[3];

	// Token: 0x040057A5 RID: 22437
	public Text[] playerName = new Text[3];

	// Token: 0x040057A6 RID: 22438
	public Text[] score = new Text[3];

	// Token: 0x040057A7 RID: 22439
	public Image[] winBG = new Image[3];

	// Token: 0x040057A8 RID: 22440
	public Image[] hum = new Image[3];

	// Token: 0x040057A9 RID: 22441
	public Image[] roll = new Image[3];

	// Token: 0x040057AA RID: 22442
	public Image[] win = new Image[3];

	// Token: 0x040057AB RID: 22443
	public GameObject item;

	// Token: 0x040057AC RID: 22444
	public Text itemName;

	// Token: 0x040057AD RID: 22445
	private ItemData curItemData;

	// Token: 0x040057AE RID: 22446
	private ComItem comItem;
}

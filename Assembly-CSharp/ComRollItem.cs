using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001073 RID: 4211
public class ComRollItem : MonoBehaviour
{
	// Token: 0x06009F27 RID: 40743 RVA: 0x001FC508 File Offset: 0x001FA908
	private void Start()
	{
	}

	// Token: 0x06009F28 RID: 40744 RVA: 0x001FC50A File Offset: 0x001FA90A
	private void OnDestroy()
	{
		if (this.comItem != null)
		{
			ComItemManager.Destroy(this.comItem);
			this.comItem = null;
		}
	}

	// Token: 0x06009F29 RID: 40745 RVA: 0x001FC530 File Offset: 0x001FA930
	public void Init(ItemData itemData, float time, float totalTime, int score, DungeonRollFrame.ROLLITEM_STAT stat)
	{
		this.curItemData = itemData;
		if (this.comItem == null)
		{
			this.comItem = ComItemManager.Create(this.item);
		}
		if (this.comItem != null)
		{
			this.comItem.Setup(this.curItemData, new ComItem.OnItemClicked(this.OnItemClick));
		}
		this.curTime = time;
		this.totalTime = totalTime;
		if (this.curItemData != null && this.itemName != null)
		{
			ItemData.QualityInfo qualityInfo = this.curItemData.GetQualityInfo();
			if (qualityInfo != null)
			{
				this.itemName.color = qualityInfo.Col;
			}
			this.itemName.text = this.curItemData.Name;
		}
		if (stat == DungeonRollFrame.ROLLITEM_STAT.HUM)
		{
			if (this.humDesc != null)
			{
				this.humDesc.CustomActive(true);
			}
			if (this.scoreRoot != null)
			{
				this.scoreRoot.CustomActive(false);
			}
			if (this.scoreDesc != null)
			{
				this.scoreDesc.CustomActive(false);
			}
			if (this.btnRoll != null && this.btnRoll.gameObject != null)
			{
				this.btnRoll.gameObject.CustomActive(false);
			}
			if (this.btnHum != null && this.btnHum.gameObject != null)
			{
				this.btnHum.gameObject.CustomActive(false);
			}
		}
		else if (stat == DungeonRollFrame.ROLLITEM_STAT.SCORE)
		{
			if (this.humDesc != null)
			{
				this.humDesc.CustomActive(false);
			}
			if (this.scoreRoot != null)
			{
				this.scoreRoot.CustomActive(true);
			}
			if (this.scoreDesc != null)
			{
				this.scoreDesc.CustomActive(true);
				this.scoreDesc.text = score.ToString();
			}
			if (this.btnRoll != null && this.btnRoll.gameObject != null)
			{
				this.btnRoll.gameObject.CustomActive(false);
			}
			if (this.btnHum != null && this.btnHum.gameObject != null)
			{
				this.btnHum.gameObject.CustomActive(false);
			}
		}
		else
		{
			if (this.humDesc != null)
			{
				this.humDesc.CustomActive(false);
			}
			if (this.scoreRoot != null)
			{
				this.scoreRoot.CustomActive(false);
			}
			if (this.scoreDesc != null)
			{
				this.scoreDesc.CustomActive(false);
			}
			if (this.btnRoll != null && this.btnRoll.gameObject != null)
			{
				this.btnRoll.gameObject.CustomActive(true);
			}
			if (this.btnHum != null && this.btnHum.gameObject != null)
			{
				this.btnHum.gameObject.CustomActive(true);
			}
		}
		if (this.timeProgress != null)
		{
			if (totalTime != 0f)
			{
				this.timeProgress.value = this.curTime / totalTime;
			}
			else
			{
				this.timeProgress.value = 0f;
			}
		}
	}

	// Token: 0x06009F2A RID: 40746 RVA: 0x001FC8C4 File Offset: 0x001FACC4
	private void Update()
	{
		if (this.curTime < 0f)
		{
			return;
		}
		if (this.curTime < 0f)
		{
			this.curTime = 0f;
		}
		if (this.timeProgress != null)
		{
			if (this.totalTime != 0f)
			{
				this.timeProgress.value = this.curTime / this.totalTime;
			}
			else
			{
				this.timeProgress.value = 0f;
			}
		}
		this.curTime -= Time.deltaTime;
	}

	// Token: 0x06009F2B RID: 40747 RVA: 0x001FC95D File Offset: 0x001FAD5D
	private void OnItemClick(GameObject obj, ItemData itemData)
	{
		if (itemData == null)
		{
			return;
		}
		DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
	}

	// Token: 0x04005798 RID: 22424
	public Text itemName;

	// Token: 0x04005799 RID: 22425
	public Image humDesc;

	// Token: 0x0400579A RID: 22426
	public Text scoreDesc;

	// Token: 0x0400579B RID: 22427
	public GameObject scoreRoot;

	// Token: 0x0400579C RID: 22428
	public GameObject item;

	// Token: 0x0400579D RID: 22429
	public Slider timeProgress;

	// Token: 0x0400579E RID: 22430
	public Button btnRoll;

	// Token: 0x0400579F RID: 22431
	public Button btnHum;

	// Token: 0x040057A0 RID: 22432
	private ItemData curItemData;

	// Token: 0x040057A1 RID: 22433
	private float curTime = 10f;

	// Token: 0x040057A2 RID: 22434
	private float totalTime = 10f;

	// Token: 0x040057A3 RID: 22435
	private ComItem comItem;
}

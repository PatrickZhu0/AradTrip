using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001A24 RID: 6692
public class ItemDrugSetting : MonoBehaviour
{
	// Token: 0x060106DA RID: 67290 RVA: 0x0049EFD7 File Offset: 0x0049D3D7
	private void Start()
	{
	}

	// Token: 0x060106DB RID: 67291 RVA: 0x0049EFD9 File Offset: 0x0049D3D9
	private void Update()
	{
	}

	// Token: 0x060106DC RID: 67292 RVA: 0x0049EFDC File Offset: 0x0049D3DC
	public void SetItemInfo(int id, int percent, PlayerBaseData.PotionSlotType type)
	{
		ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
		this.item.CustomActive(id != 0);
		this.empty.CustomActive(id == 0);
		if (itemData == null)
		{
			return;
		}
		this.des.gameObject.CustomActive(itemData.SubType != 62);
		if (this.background != null)
		{
			ETCImageLoader.LoadSprite(ref this.background, itemData.GetQualityInfo().Background, true);
		}
		if (this.icon != null)
		{
			ETCImageLoader.LoadSprite(ref this.icon, itemData.Icon, true);
		}
		if (percent <= 0)
		{
			this.des.text = "自动使用关闭";
			this.des.color = new Color(0.7647059f, 0.7647059f, 0.7647059f, 1f);
		}
		else
		{
			if (type == PlayerBaseData.PotionSlotType.SlotExtend2)
			{
				this.des.text = string.Format("MP低于{0}%自动使用", percent);
			}
			else
			{
				this.des.text = string.Format("HP低于{0}%自动使用", percent);
			}
			this.des.color = Color.green;
		}
		string keyName = "PotionSlotMainSwitch";
		switch (type)
		{
		case PlayerBaseData.PotionSlotType.SlotMain:
			keyName = "PotionSlotMainSwitch";
			break;
		case PlayerBaseData.PotionSlotType.SlotExtend1:
			keyName = "PotionSlot1Switch";
			break;
		case PlayerBaseData.PotionSlotType.SlotExtend2:
			keyName = "PotionSlot2Switch";
			break;
		}
		if (!DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn(keyName))
		{
			this.des.text = "自动使用关闭";
			this.des.color = new Color(0.7647059f, 0.7647059f, 0.7647059f, 1f);
		}
	}

	// Token: 0x0400A6F8 RID: 42744
	public Image background;

	// Token: 0x0400A6F9 RID: 42745
	public Image icon;

	// Token: 0x0400A6FA RID: 42746
	public Text des;

	// Token: 0x0400A6FB RID: 42747
	public GameObject item;

	// Token: 0x0400A6FC RID: 42748
	public GameObject empty;
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200174A RID: 5962
	public class MailInfomationView : MonoBehaviour
	{
		// Token: 0x0600EA4B RID: 59979 RVA: 0x003E1D23 File Offset: 0x003E0123
		private void Awake()
		{
			this.InitPackageItem();
		}

		// Token: 0x0600EA4C RID: 59980 RVA: 0x003E1D2B File Offset: 0x003E012B
		private void OnDestroy()
		{
			this.mMailDataModel = null;
			this.mItems.Clear();
		}

		// Token: 0x0600EA4D RID: 59981 RVA: 0x003E1D40 File Offset: 0x003E0140
		private void InitPackageItem()
		{
			int num = 0;
			for (int i = 0; i < this.mPostions.Count; i++)
			{
				if (!(this.mPostions[i].name != string.Format("Pos{0}", num + 1)))
				{
					ComItem item = ComItemManager.Create(this.mPostions[i].gameObject);
					if (num < MailDataManager.MailItemNum)
					{
						this.mItems.Add(item);
					}
					num++;
				}
			}
		}

		// Token: 0x0600EA4E RID: 59982 RVA: 0x003E1DD0 File Offset: 0x003E01D0
		private void ClearItemIcon()
		{
			for (int i = 0; i < this.mItems.Count; i++)
			{
				if (this.mItems[i] != null)
				{
					this.mItems[i].Setup(null, null);
				}
			}
		}

		// Token: 0x0600EA4F RID: 59983 RVA: 0x003E1E23 File Offset: 0x003E0223
		public void UpdateMailInfoMationView(MailDataModel mailDataModel)
		{
			this.mMailDataModel = mailDataModel;
			this.UpdateMainInfo();
		}

		// Token: 0x0600EA50 RID: 59984 RVA: 0x003E1E34 File Offset: 0x003E0234
		private void UpdateMainInfo()
		{
			if (this.mMailDataModel == null)
			{
				return;
			}
			if (this.mMailDataModel.info == null)
			{
				return;
			}
			this.mMailTitle.text = this.mMailDataModel.info.title;
			this.mMailSenderName.text = this.mMailDataModel.info.sender;
			string value = this.mMailDataModel.content.Replace("\\n", "\n");
			this.mMailContent.SetText(value, true);
			this.ClearItemIcon();
			if (this.mMailDataModel.info.hasItem == 1)
			{
				int num = 0;
				int num2 = 0;
				while (num2 < this.mMailDataModel.items.Count && num2 < MailDataManager.MailItemNum)
				{
					ItemReward itemReward = this.mMailDataModel.items[num2];
					if (itemReward != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, (int)itemReward.qualityLv, (int)itemReward.strength);
						if (itemData != null)
						{
							itemData.Count = (int)itemReward.num;
							itemData.StrengthenLevel = (int)itemReward.strength;
							this.SetUpItem(itemData, num2);
							num++;
						}
					}
					num2++;
				}
				int num3 = 0;
				while (num3 < this.mMailDataModel.detailItems.Count && num + num3 < MailDataManager.MailItemNum)
				{
					ItemData itemData2 = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(this.mMailDataModel.detailItems[num3]);
					if (itemData2 != null)
					{
						itemData2.Count = (int)this.mMailDataModel.detailItems[num3].num;
						this.SetUpItem(itemData2, num + num3);
					}
					num3++;
				}
			}
			this.mItemsRoot.CustomActive(this.mMailDataModel.info.hasItem == 1);
		}

		// Token: 0x0600EA51 RID: 59985 RVA: 0x003E2014 File Offset: 0x003E0414
		private void SetUpItem(ItemData data, int index)
		{
			if (this.mItems == null || index >= this.mItems.Count)
			{
				return;
			}
			ComItem comItem = this.mItems[index];
			if (MailInfomationView.<>f__mg$cache0 == null)
			{
				MailInfomationView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(data, MailInfomationView.<>f__mg$cache0);
		}

		// Token: 0x04008E17 RID: 36375
		[SerializeField]
		private Text mMailTitle;

		// Token: 0x04008E18 RID: 36376
		[SerializeField]
		private Text mMailSenderName;

		// Token: 0x04008E19 RID: 36377
		[SerializeField]
		private LinkParse mMailContent;

		// Token: 0x04008E1A RID: 36378
		[SerializeField]
		private List<RectTransform> mPostions;

		// Token: 0x04008E1B RID: 36379
		[SerializeField]
		private GameObject mItemsRoot;

		// Token: 0x04008E1C RID: 36380
		private MailDataModel mMailDataModel;

		// Token: 0x04008E1D RID: 36381
		private List<ComItem> mItems = new List<ComItem>();

		// Token: 0x04008E1E RID: 36382
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

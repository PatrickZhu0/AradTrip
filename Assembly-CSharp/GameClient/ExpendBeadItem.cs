using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B12 RID: 6930
	public class ExpendBeadItem : MonoBehaviour
	{
		// Token: 0x17001D8A RID: 7562
		// (get) Token: 0x06011058 RID: 69720 RVA: 0x004DF87B File Offset: 0x004DDC7B
		public ExpendBeadItemData SimpleData
		{
			get
			{
				return (this.mSimpleData != null) ? this.mSimpleData : null;
			}
		}

		// Token: 0x06011059 RID: 69721 RVA: 0x004DF894 File Offset: 0x004DDC94
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.mCheckRoot.CustomActive(bSelected);
		}

		// Token: 0x0601105A RID: 69722 RVA: 0x004DF8A4 File Offset: 0x004DDCA4
		public void OnItemVisible(ExpendBeadItemData data)
		{
			this.mSimpleData = data;
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(data.ItemID);
			if (commonItemTableDataByID != null)
			{
				ComItem comItem = ComItemManager.Create(this.mItemParent);
				ComItem comItem2 = comItem;
				ItemData item = commonItemTableDataByID;
				if (ExpendBeadItem.<>f__mg$cache0 == null)
				{
					ExpendBeadItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem2.Setup(item, ExpendBeadItem.<>f__mg$cache0);
			}
			bool flag = data.TatleCount > 0;
			this.mCount.CustomActive(flag);
			this.mHintGo.CustomActive(!flag);
			this.mCount.text = string.Format("拥有{0}", data.TatleCount);
			Text text = this.mBeadName;
			string text2 = commonItemTableDataByID.GetColorName(string.Empty, false);
			this.mCheckBeadName.text = text2;
			text.text = text2;
			Text text3 = this.mBeadArrt;
			text2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(data.ItemID, false);
			this.mCheckBeadArrt.text = text2;
			text3.text = text2;
		}

		// Token: 0x0400AF35 RID: 44853
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AF36 RID: 44854
		[SerializeField]
		private Text mBeadName;

		// Token: 0x0400AF37 RID: 44855
		[SerializeField]
		private Text mCheckBeadName;

		// Token: 0x0400AF38 RID: 44856
		[SerializeField]
		private Text mBeadArrt;

		// Token: 0x0400AF39 RID: 44857
		[SerializeField]
		private Text mCheckBeadArrt;

		// Token: 0x0400AF3A RID: 44858
		[SerializeField]
		private GameObject mCheckRoot;

		// Token: 0x0400AF3B RID: 44859
		[SerializeField]
		private Text mCount;

		// Token: 0x0400AF3C RID: 44860
		[SerializeField]
		private GameObject mHintGo;

		// Token: 0x0400AF3D RID: 44861
		private ExpendBeadItemData mSimpleData;

		// Token: 0x0400AF3E RID: 44862
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

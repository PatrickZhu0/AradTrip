using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CBA RID: 7354
	public class TopUpPushItem : MonoBehaviour
	{
		// Token: 0x060120B0 RID: 73904 RVA: 0x0054726C File Offset: 0x0054566C
		public void OnItemVisiable(TopUpPushItemData topUpPushItemData, OnBuyClick callBack)
		{
			this.topUpPushItemData = topUpPushItemData;
			this.mOnBuyClick = callBack;
			ComItem comItem = ComItemManager.Create(this.mItemParent);
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.topUpPushItemData.itemId);
			commonItemTableDataByID.Count = this.topUpPushItemData.itemCount;
			ComItem comItem2 = comItem;
			ItemData item = commonItemTableDataByID;
			if (TopUpPushItem.<>f__mg$cache0 == null)
			{
				TopUpPushItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem2.Setup(item, TopUpPushItem.<>f__mg$cache0);
			this.mName.text = commonItemTableDataByID.GetColorName(string.Empty, false);
			this.mPrice.text = this.topUpPushItemData.price.ToString();
			this.mDiscountPrice.text = this.topUpPushItemData.disCountPrice.ToString();
			int num = this.topUpPushItemData.maxTimes - this.topUpPushItemData.buyTimes;
			this.mLimitBuyCount.text = string.Format("限购次数:{0}/{1}", num, this.topUpPushItemData.maxTimes);
			this.mBuyBtn.onClick.RemoveAllListeners();
			this.mBuyBtn.onClick.AddListener(new UnityAction(this.OnBuyClick));
			this.mBuyGray.enabled = (num <= 0);
		}

		// Token: 0x060120B1 RID: 73905 RVA: 0x005473B8 File Offset: 0x005457B8
		private void OnBuyClick()
		{
			if (this.mOnBuyClick != null)
			{
				this.mOnBuyClick(this.topUpPushItemData);
			}
		}

		// Token: 0x060120B2 RID: 73906 RVA: 0x005473D8 File Offset: 0x005457D8
		private void OnDestroy()
		{
			this.topUpPushItemData = null;
			if (this.mOnBuyClick != null)
			{
				this.mOnBuyClick = null;
			}
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyClick));
			}
			this.mBuyBtn = null;
		}

		// Token: 0x0400BC1C RID: 48156
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400BC1D RID: 48157
		[SerializeField]
		private Text mName;

		// Token: 0x0400BC1E RID: 48158
		[SerializeField]
		private Text mPrice;

		// Token: 0x0400BC1F RID: 48159
		[SerializeField]
		private Text mDiscountPrice;

		// Token: 0x0400BC20 RID: 48160
		[SerializeField]
		private Text mLimitBuyCount;

		// Token: 0x0400BC21 RID: 48161
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x0400BC22 RID: 48162
		[SerializeField]
		private UIGray mBuyGray;

		// Token: 0x0400BC23 RID: 48163
		private TopUpPushItemData topUpPushItemData;

		// Token: 0x0400BC24 RID: 48164
		private OnBuyClick mOnBuyClick;

		// Token: 0x0400BC25 RID: 48165
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

using System;
using System.Runtime.CompilerServices;
using LimitTimeGift;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E0 RID: 6368
	public class CommonGiftDailyPurchaseActivityItem : MonoBehaviour
	{
		// Token: 0x0600F898 RID: 63640 RVA: 0x0043A549 File Offset: 0x00438949
		private void Awake()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this.OnBuyBtnClick));
		}

		// Token: 0x0600F899 RID: 63641 RVA: 0x0043A570 File Offset: 0x00438970
		public void OnItemVisiable(LimitTimeGiftPackDetailModel model, int index, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.limitTimeGiftPackDetailModel = model;
			this.index = index;
			this.onItemClick = onItemClick;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			if (model.mRewards.Length > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)model.mRewards[0].id, 100, 0);
				if (itemData != null)
				{
					itemData.Count = (int)model.mRewards[0].num;
					ComItem comItem = this.comItem;
					ItemData item = itemData;
					if (CommonGiftDailyPurchaseActivityItem.<>f__mg$cache0 == null)
					{
						CommonGiftDailyPurchaseActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, CommonGiftDailyPurchaseActivityItem.<>f__mg$cache0);
					this.mName.SafeSetText(itemData.GetColorName(string.Empty, false));
				}
			}
			this.mPrice.SafeSetText(string.Format("{0}点券", model.GiftPrice));
			if (model.LimitType == ELimitiTimeGiftDataLimitType.Refresh)
			{
				this.mLimit.SafeSetText(TR.Value("limittime_mall_limit_role_everyday", (long)((ulong)model.LimitNum - (ulong)((long)DataManager<CountDataManager>.GetInstance().GetCount(model.Id.ToString()))), model.LimitNum));
			}
			bool isFlag = (ulong)model.LimitNum - (ulong)((long)DataManager<CountDataManager>.GetInstance().GetCount(model.Id.ToString())) > 0UL;
			this.UpdateButtonState(isFlag);
		}

		// Token: 0x0600F89A RID: 63642 RVA: 0x0043A6E6 File Offset: 0x00438AE6
		private void UpdateButtonState(bool isFlag)
		{
			if (this.mBuyGray != null)
			{
				this.mBuyGray.enabled = !isFlag;
			}
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.enabled = isFlag;
			}
		}

		// Token: 0x0600F89B RID: 63643 RVA: 0x0043A725 File Offset: 0x00438B25
		private void OnBuyBtnClick()
		{
			if (this.onItemClick != null)
			{
				this.onItemClick(this.index, 0, 0UL);
			}
		}

		// Token: 0x0600F89C RID: 63644 RVA: 0x0043A746 File Offset: 0x00438B46
		private void OnDestroy()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.index = 0;
			this.onItemClick = null;
			this.comItem = null;
		}

		// Token: 0x040099EA RID: 39402
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x040099EB RID: 39403
		[SerializeField]
		private Text mPrice;

		// Token: 0x040099EC RID: 39404
		[SerializeField]
		private Text mLimit;

		// Token: 0x040099ED RID: 39405
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x040099EE RID: 39406
		[SerializeField]
		private UIGray mBuyGray;

		// Token: 0x040099EF RID: 39407
		[SerializeField]
		private Text mName;

		// Token: 0x040099F0 RID: 39408
		private LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel;

		// Token: 0x040099F1 RID: 39409
		private int index;

		// Token: 0x040099F2 RID: 39410
		private ActivityItemBase.OnActivityItemClick<int> onItemClick;

		// Token: 0x040099F3 RID: 39411
		private ComItem comItem;

		// Token: 0x040099F4 RID: 39412
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

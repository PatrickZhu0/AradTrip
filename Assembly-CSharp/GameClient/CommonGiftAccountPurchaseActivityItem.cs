using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DF RID: 6367
	public class CommonGiftAccountPurchaseActivityItem : MonoBehaviour
	{
		// Token: 0x0600F890 RID: 63632 RVA: 0x0043A201 File Offset: 0x00438601
		private void Awake()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this.OnBuyBtnClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F891 RID: 63633 RVA: 0x0043A240 File Offset: 0x00438640
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
					if (CommonGiftAccountPurchaseActivityItem.<>f__mg$cache0 == null)
					{
						CommonGiftAccountPurchaseActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, CommonGiftAccountPurchaseActivityItem.<>f__mg$cache0);
					this.mName.SafeSetText(itemData.GetColorName(string.Empty, false));
				}
			}
			this.mPrice.SafeSetText(string.Format("{0}点券", model.GiftPrice));
			if (model.AccountLimitBuyNum > 0U)
			{
				this.UpdateLimitPurchaseInfo(-1);
			}
		}

		// Token: 0x0600F892 RID: 63634 RVA: 0x0043A33C File Offset: 0x0043873C
		private void UpdateLimitPurchaseInfo(int accountLimitNum = -1)
		{
			int accountLimitBuyNum = (int)this.limitTimeGiftPackDetailModel.AccountLimitBuyNum;
			int num;
			if (accountLimitNum == -1)
			{
				num = (int)this.limitTimeGiftPackDetailModel.AccountRestBuyNum;
			}
			else
			{
				num = accountLimitNum;
			}
			bool isFlag = num > 0;
			this.UpdateButtonState(isFlag);
			switch (this.limitTimeGiftPackDetailModel.AccountRefreshType)
			{
			case 0U:
				this.mLimit.SafeSetText(TR.Value("count_limittime_mall_limit_number_everyday", num, accountLimitBuyNum));
				break;
			case 1U:
				this.mLimit.SafeSetText(TR.Value("count_limittime_mall_limit_number_month", num, accountLimitBuyNum));
				break;
			case 2U:
				this.mLimit.SafeSetText(TR.Value("count_limittime_mall_limit_number_week", num, accountLimitBuyNum));
				break;
			case 3U:
				this.mLimit.SafeSetText(TR.Value("count_limittime_mall_limit_number_today", num, accountLimitBuyNum));
				break;
			}
		}

		// Token: 0x0600F893 RID: 63635 RVA: 0x0043A43A File Offset: 0x0043883A
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

		// Token: 0x0600F894 RID: 63636 RVA: 0x0043A479 File Offset: 0x00438879
		private void OnBuyBtnClick()
		{
			if (this.onItemClick != null)
			{
				this.onItemClick(this.index, 0, 0UL);
			}
		}

		// Token: 0x0600F895 RID: 63637 RVA: 0x0043A49C File Offset: 0x0043889C
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			int num2 = (int)uiEvent.Param2;
			int accountLimitNum = (int)uiEvent.Param3;
			if (num != this.limitTimeGiftPackDetailModel.Id)
			{
				return;
			}
			this.UpdateLimitPurchaseInfo(accountLimitNum);
		}

		// Token: 0x0600F896 RID: 63638 RVA: 0x0043A504 File Offset: 0x00438904
		private void OnDestroy()
		{
			this.mBuyBtn.SafeRemoveAllListener();
			this.index = 0;
			this.onItemClick = null;
			this.comItem = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x040099DF RID: 39391
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x040099E0 RID: 39392
		[SerializeField]
		private Text mPrice;

		// Token: 0x040099E1 RID: 39393
		[SerializeField]
		private Text mLimit;

		// Token: 0x040099E2 RID: 39394
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x040099E3 RID: 39395
		[SerializeField]
		private UIGray mBuyGray;

		// Token: 0x040099E4 RID: 39396
		[SerializeField]
		private Text mName;

		// Token: 0x040099E5 RID: 39397
		private LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel;

		// Token: 0x040099E6 RID: 39398
		private int index;

		// Token: 0x040099E7 RID: 39399
		private ActivityItemBase.OnActivityItemClick<int> onItemClick;

		// Token: 0x040099E8 RID: 39400
		private ComItem comItem;

		// Token: 0x040099E9 RID: 39401
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

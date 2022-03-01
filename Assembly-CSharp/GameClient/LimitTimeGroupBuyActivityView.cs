using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A0 RID: 6304
	public class LimitTimeGroupBuyActivityView : MonoBehaviour, IDisposable, IGiftPackActivityView
	{
		// Token: 0x0600F67D RID: 63101 RVA: 0x004287C0 File Offset: 0x00426BC0
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGASWholeBargainResSuccessed, new ClientEventSystem.UIEventHandler(this.OnGASWholeBargainResSuccessed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(688, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.iFashionGiftId = tableItem.Value;
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", Function._TransTimeStampToStr(this.mModel.StartTime), Function._TransTimeStampToStr(this.mModel.EndTime)));
			this.mCheckViewBtn.SafeRemoveAllListener();
			this.mCheckViewBtn.SafeAddOnClickListener(new UnityAction(this.OnCheckViewBtnClick));
			this.mFashionPreviewBtn.SafeRemoveAllListener();
			this.mFashionPreviewBtn.SafeAddOnClickListener(new UnityAction(this.OnFashionPreviewBtnClick));
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this.OnBuyBtnClick));
			this.InitData();
			this.mFirstNumberText.SafeSetText(string.Format(this.numberDes, this.mFirstNumber));
			this.mSecondNumberText.SafeSetText(string.Format(this.numberDes, this.mSecondNumber));
			this.mThirdNumberText.SafeSetText(string.Format(this.numberDes, this.mThirdNumber));
			this.mFourthNumberText.SafeSetText(string.Format(this.numberDes, this.mFourthNumber));
			this.mFirstDiscountText.SafeSetText(string.Format(this.discountDes, this.mFirstDiscount / 10f));
			this.mSecondDiscountText.SafeSetText(string.Format(this.discountDes, this.mSecondDiscount / 10f));
			this.mThirdDiscountText.SafeSetText(string.Format(this.discountDes, this.mThirdDiscount / 10f));
			this.InitItems();
			DataManager<ActivityDataManager>.GetInstance().OnSendGASWholeBargainReq();
		}

		// Token: 0x0600F67E RID: 63102 RVA: 0x004289E7 File Offset: 0x00426DE7
		public void UpdateData(LimitTimeGiftPackModel model)
		{
		}

		// Token: 0x0600F67F RID: 63103 RVA: 0x004289E9 File Offset: 0x00426DE9
		private void OnCheckViewBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeGroupBuyWelfareFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600F680 RID: 63104 RVA: 0x004289FD File Offset: 0x00426DFD
		private void OnBuyBtnClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(0, 0, 0UL);
			}
		}

		// Token: 0x0600F681 RID: 63105 RVA: 0x00428A1C File Offset: 0x00426E1C
		private void OnFashionPreviewBtnClick()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.iFashionGiftId, 100, 0);
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600F682 RID: 63106 RVA: 0x00428A50 File Offset: 0x00426E50
		private void InitData()
		{
			for (int i = 0; i < ActivityDataManager.mDiscountDataList.Count; i++)
			{
				ActivityDataManager.LimitTimeGroupBuyDiscountData limitTimeGroupBuyDiscountData = ActivityDataManager.mDiscountDataList[i];
				if (i == 0)
				{
					this.mFirstNumber = (float)limitTimeGroupBuyDiscountData.joinNum;
					this.mFirstDiscount = (float)limitTimeGroupBuyDiscountData.discount;
				}
				else if (i == 1)
				{
					this.mSecondNumber = (float)limitTimeGroupBuyDiscountData.joinNum;
					this.mSecondDiscount = (float)limitTimeGroupBuyDiscountData.discount;
				}
				else if (i == 2)
				{
					this.mThirdNumber = (float)limitTimeGroupBuyDiscountData.joinNum;
					this.mThirdDiscount = (float)limitTimeGroupBuyDiscountData.discount;
				}
				else if (i == 3)
				{
					this.mFourthNumber = (float)limitTimeGroupBuyDiscountData.joinNum;
				}
			}
		}

		// Token: 0x0600F683 RID: 63107 RVA: 0x00428B0C File Offset: 0x00426F0C
		private void InitItems()
		{
			if (this.mModel.DetailDatas != null && this.mModel.DetailDatas.Count > 0)
			{
				LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel = this.mModel.DetailDatas[0];
				if (limitTimeGiftPackDetailModel.mRewards != null && limitTimeGiftPackDetailModel.mRewards.Length > 0)
				{
					if (this.mItemPriceTxt != null)
					{
						this.mItemPriceTxt.text = string.Format(this.pointDes, limitTimeGiftPackDetailModel.GiftPrice);
					}
					if (this.mItemNameTxt != null)
					{
						this.mItemNameTxt.text = limitTimeGiftPackDetailModel.Name;
					}
					ItemReward itemReward = limitTimeGiftPackDetailModel.mRewards[0];
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, 100, 0);
					itemData.Count = (int)itemReward.num;
					if (this.mItemBackgroundImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemBackgroundImg, itemData.GetQualityInfo().Background, true);
					}
					if (this.mItemIconImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemIconImg, itemData.Icon, true);
					}
					if (this.mItemIconBtn != null)
					{
						this.mItemIconBtn.onClick.RemoveAllListeners();
						this.mItemIconBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
				}
			}
		}

		// Token: 0x0600F684 RID: 63108 RVA: 0x00428C8B File Offset: 0x0042708B
		private void UpdateItemCount(int count)
		{
			if (this.mBuyCountTxt != null)
			{
				this.mBuyCountTxt.text = count.ToString();
			}
		}

		// Token: 0x0600F685 RID: 63109 RVA: 0x00428CB6 File Offset: 0x004270B6
		private void RefreshFullServiceDes(float discount)
		{
			if (this.mDiscountText != null)
			{
				this.mDiscountText.text = string.Format(this.fullServiceDiscountDes, discount);
			}
		}

		// Token: 0x0600F686 RID: 63110 RVA: 0x00428CE8 File Offset: 0x004270E8
		private void UpdateProgress()
		{
			if (this.mFirstProgress != null)
			{
				float num = 0f;
				float num2 = this.currentTotalNumber;
				if (this.currentNumber > 0f)
				{
					num = this.currentNumber + this.extraValue;
					num2 = this.currentTotalNumber + this.extraValue;
				}
				this.mFirstProgress.value = num / num2;
			}
		}

		// Token: 0x0600F687 RID: 63111 RVA: 0x00428D4D File Offset: 0x0042714D
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			DataManager<ActivityDataManager>.GetInstance().OnSendGASWholeBargainReq();
		}

		// Token: 0x0600F688 RID: 63112 RVA: 0x00428D5C File Offset: 0x0042715C
		private void OnGASWholeBargainResSuccessed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeGroupBuyDataModel limitTimeGroupBuyDataModel = uiEvent.Param1 as LimitTimeGroupBuyDataModel;
			if (limitTimeGroupBuyDataModel == null)
			{
				return;
			}
			this.currentNumber = (float)limitTimeGroupBuyDataModel.joinNum;
			this.currentTotalNumber = (float)limitTimeGroupBuyDataModel.maxNum;
			this.UpdateProgress();
			this.UpdateItemCount(limitTimeGroupBuyDataModel.playerJoinNum);
			this.RefreshFullServiceDes((float)limitTimeGroupBuyDataModel.discount / 10f);
		}

		// Token: 0x0600F689 RID: 63113 RVA: 0x00428DCE File Offset: 0x004271CE
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F68A RID: 63114 RVA: 0x00428DE1 File Offset: 0x004271E1
		public void Dispose()
		{
			this.mOnItemClick = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGASWholeBargainResSuccessed, new ClientEventSystem.UIEventHandler(this.OnGASWholeBargainResSuccessed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0400974A RID: 38730
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x0400974B RID: 38731
		[SerializeField]
		private Text mBuyCountTxt;

		// Token: 0x0400974C RID: 38732
		[SerializeField]
		private Text mItemNameTxt;

		// Token: 0x0400974D RID: 38733
		[SerializeField]
		private Text mItemPriceTxt;

		// Token: 0x0400974E RID: 38734
		[SerializeField]
		private Button mCheckViewBtn;

		// Token: 0x0400974F RID: 38735
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x04009750 RID: 38736
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x04009751 RID: 38737
		[SerializeField]
		private Image mItemBackgroundImg;

		// Token: 0x04009752 RID: 38738
		[SerializeField]
		private Image mItemIconImg;

		// Token: 0x04009753 RID: 38739
		[SerializeField]
		private Slider mFirstProgress;

		// Token: 0x04009754 RID: 38740
		[SerializeField]
		private Slider mSecondProgress;

		// Token: 0x04009755 RID: 38741
		[SerializeField]
		private Slider mThirdProgress;

		// Token: 0x04009756 RID: 38742
		[SerializeField]
		private Slider mFourthProgress;

		// Token: 0x04009757 RID: 38743
		[SerializeField]
		private Text mFirstNumberText;

		// Token: 0x04009758 RID: 38744
		[SerializeField]
		private Text mSecondNumberText;

		// Token: 0x04009759 RID: 38745
		[SerializeField]
		private Text mThirdNumberText;

		// Token: 0x0400975A RID: 38746
		[SerializeField]
		private Text mFourthNumberText;

		// Token: 0x0400975B RID: 38747
		[SerializeField]
		private Text mFirstDiscountText;

		// Token: 0x0400975C RID: 38748
		[SerializeField]
		private Text mSecondDiscountText;

		// Token: 0x0400975D RID: 38749
		[SerializeField]
		private Text mThirdDiscountText;

		// Token: 0x0400975E RID: 38750
		[SerializeField]
		private Text mDiscountText;

		// Token: 0x0400975F RID: 38751
		[SerializeField]
		private Button mFashionPreviewBtn;

		// Token: 0x04009760 RID: 38752
		private float mFirstNumber = 2000f;

		// Token: 0x04009761 RID: 38753
		private float mSecondNumber = 3000f;

		// Token: 0x04009762 RID: 38754
		private float mThirdNumber = 5000f;

		// Token: 0x04009763 RID: 38755
		private float mFourthNumber = 10000f;

		// Token: 0x04009764 RID: 38756
		private float mFirstDiscount;

		// Token: 0x04009765 RID: 38757
		private float mSecondDiscount;

		// Token: 0x04009766 RID: 38758
		private float mThirdDiscount;

		// Token: 0x04009767 RID: 38759
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009768 RID: 38760
		private LimitTimeGiftPackModel mModel;

		// Token: 0x04009769 RID: 38761
		private float currentNumber;

		// Token: 0x0400976A RID: 38762
		private float currentTotalNumber;

		// Token: 0x0400976B RID: 38763
		[SerializeField]
		private string pointDes = "{0}点券";

		// Token: 0x0400976C RID: 38764
		[SerializeField]
		private string discountDes = "{0}折";

		// Token: 0x0400976D RID: 38765
		[SerializeField]
		private string numberDes = "{0}张";

		// Token: 0x0400976E RID: 38766
		[SerializeField]
		private string fullServiceDiscountDes = "当前全服折扣:{0}折";

		// Token: 0x0400976F RID: 38767
		[SerializeField]
		private float extraValue = 1000f;

		// Token: 0x04009770 RID: 38768
		private int iFashionGiftId;
	}
}

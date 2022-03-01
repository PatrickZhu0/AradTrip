using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B3 RID: 6323
	public class SpringFestivalDungeonView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F723 RID: 63267 RVA: 0x0042D85C File Offset: 0x0042BC5C
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.ParamArray2.Length > 0)
			{
				this.iExchangeShopID = model.ParamArray2[0];
			}
			this._InitNode(model);
			this._InitItems(model);
			this._InitPreviewData(model);
			this.mExchangeShopBtn.SafeAddOnClickListener(new UnityAction(this._OnExchangeBtnClick));
			this.mReviewBtn.SafeAddOnClickListener(new UnityAction(this._OnRevieBtnClick));
			this.mGoToBtn.SafeAddOnClickListener(new UnityAction(this._OnGoToBtnClick));
			this.mHelpBtn.SafeAddOnClickListener(new UnityAction(this._OnHelpBtnClick));
			this.mSpecialTipBtnClick.SafeAddOnClickListener(new UnityAction(this._OnSpecialTipBtnCloseClick));
			this.mModel = model;
		}

		// Token: 0x0600F724 RID: 63268 RVA: 0x0042D914 File Offset: 0x0042BD14
		private void _InitPreviewData(ILimitTimeActivityModel model)
		{
			this.mPreViewData = new PreViewDataModel();
			this.mPreViewData.isCreatItem = false;
			this.mPreViewData.preViewItemList = new List<PreViewItemData>();
			for (int i = 0; i < model.ParamArray.Length; i++)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)model.ParamArray[i], 100, 0);
				if (itemData.Type == ItemTable.eType.FASHION || (itemData.SubType == 29 && itemData.ThirdType == ItemTable.eThirdType.FashionGift) || itemData.SubType == 10 || itemData.SubType == 44)
				{
					PreViewItemData preViewItemData = new PreViewItemData();
					preViewItemData.activityId = (int)model.Id;
					preViewItemData.itemId = (int)model.ParamArray[i];
					this.mPreViewData.preViewItemList.Add(preViewItemData);
				}
			}
		}

		// Token: 0x0600F725 RID: 63269 RVA: 0x0042D9E8 File Offset: 0x0042BDE8
		protected override void _InitItems(ILimitTimeActivityModel model)
		{
			for (int i = 0; i < model.ParamArray.Length; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.mTmpItem);
				gameObject.transform.SetParent(this.mItemsRoot);
				gameObject.transform.localScale = Vector3.one;
				SpringFestivalDungeonItem component = gameObject.GetComponent<SpringFestivalDungeonItem>();
				if (component != null)
				{
					component.Init((int)model.ParamArray[i], this.mComItemSize, i, new ComItem.OnItemClicked(this._OnSpecialItemClick));
				}
			}
			if (this.mTmpItem)
			{
				Object.Destroy(this.mTmpItem);
			}
		}

		// Token: 0x0600F726 RID: 63270 RVA: 0x0042DA8C File Offset: 0x0042BE8C
		public override void Dispose()
		{
			this.mExchangeShopBtn.SafeRemoveOnClickListener(new UnityAction(this._OnExchangeBtnClick));
			this.mReviewBtn.SafeRemoveOnClickListener(new UnityAction(this._OnRevieBtnClick));
			this.mGoToBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGoToBtnClick));
			this.mHelpBtn.SafeRemoveOnClickListener(new UnityAction(this._OnHelpBtnClick));
			this.mSpecialTipBtnClick.SafeRemoveOnClickListener(new UnityAction(this._OnSpecialTipBtnCloseClick));
			this.mPreViewData = null;
		}

		// Token: 0x0600F727 RID: 63271 RVA: 0x0042DB13 File Offset: 0x0042BF13
		private void _OnSpecialItemClick(GameObject obj, ItemData item)
		{
			this.mSpecialTipGo.CustomActive(true);
		}

		// Token: 0x0600F728 RID: 63272 RVA: 0x0042DB21 File Offset: 0x0042BF21
		private void _OnSpecialTipBtnCloseClick()
		{
			this.mSpecialTipGo.CustomActive(false);
		}

		// Token: 0x0600F729 RID: 63273 RVA: 0x0042DB30 File Offset: 0x0042BF30
		private void _OnGoToBtnClick()
		{
			if (this.mModel != null)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
				}
				ChapterSelectFrame.SetSceneID((int)this.mModel.Param);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChapterSelectFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F72A RID: 63274 RVA: 0x0042DB86 File Offset: 0x0042BF86
		private void _OnRevieBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, this.mPreViewData, string.Empty);
		}

		// Token: 0x0600F72B RID: 63275 RVA: 0x0042DBA0 File Offset: 0x0042BFA0
		private void _OnExchangeBtnClick()
		{
			LimitTimeActivityFrame limitTimeActivityFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(LimitTimeActivityFrame)) as LimitTimeActivityFrame;
			if (limitTimeActivityFrame != null)
			{
				limitTimeActivityFrame.OpenFrameByActivityId(this.iExchangeShopID);
			}
		}

		// Token: 0x0600F72C RID: 63276 RVA: 0x0042DBD9 File Offset: 0x0042BFD9
		private void _OnHelpBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SpringFestivalDungeonTipFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600F72D RID: 63277 RVA: 0x0042DBED File Offset: 0x0042BFED
		private void _InitNode(ILimitTimeActivityModel model)
		{
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleTxt.SafeSetText(model.RuleDesc);
		}

		// Token: 0x0600F72E RID: 63278 RVA: 0x0042DC30 File Offset: 0x0042C030
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x040097FA RID: 38906
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x040097FB RID: 38907
		[SerializeField]
		private Text mRuleTxt;

		// Token: 0x040097FC RID: 38908
		[SerializeField]
		private Button mExchangeShopBtn;

		// Token: 0x040097FD RID: 38909
		[SerializeField]
		private Button mReviewBtn;

		// Token: 0x040097FE RID: 38910
		[SerializeField]
		private Button mGoToBtn;

		// Token: 0x040097FF RID: 38911
		[SerializeField]
		private Button mHelpBtn;

		// Token: 0x04009800 RID: 38912
		[SerializeField]
		private Transform mItemsRoot;

		// Token: 0x04009801 RID: 38913
		[SerializeField]
		private GameObject mTmpItem;

		// Token: 0x04009802 RID: 38914
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009803 RID: 38915
		[SerializeField]
		private GameObject mSpecialTipGo;

		// Token: 0x04009804 RID: 38916
		[SerializeField]
		private Button mSpecialTipBtnClick;

		// Token: 0x04009805 RID: 38917
		private PreViewDataModel mPreViewData;

		// Token: 0x04009806 RID: 38918
		private uint iExchangeShopID;
	}
}

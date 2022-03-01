using System;
using System.Collections.Generic;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001855 RID: 6229
	public abstract class LimitTimeMallGiftPackActivityBase : IActivity, IDisposable
	{
		// Token: 0x0600F47C RID: 62588 RVA: 0x00420090 File Offset: 0x0041E490
		public void Init(uint activityId)
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (limitTimeActivityData != null)
			{
				this.mMallType = (MallTypeTable.eMallType)limitTimeActivityData.parm;
				List<MallItemInfo> giftPackInfos = DataManager<ActivityDataManager>.GetInstance().GetGiftPackInfos(this.mMallType);
				this.mDataModel = new LimitTimeGiftPackModel(limitTimeActivityData, giftPackInfos, this.mMallType, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F47D RID: 62589 RVA: 0x004200F4 File Offset: 0x0041E4F4
		public void Show(Transform root)
		{
			if (this.mDataModel.Id == 0U)
			{
				return;
			}
			if (this.mIsInit)
			{
				this.mGameObject.CustomActive(true);
			}
			else
			{
				if (this.mGameObject == null)
				{
					this.mGameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this._GetPrefabPath(), true, 0U);
				}
				if (!(this.mGameObject != null))
				{
					Logger.LogError("加载活动预制体失败，路径:" + this._GetPrefabPath());
					return;
				}
				this.mGameObject.transform.SetParent(root, false);
				this.mGameObject.CustomActive(true);
				this.mView = this.mGameObject.GetComponent<LimitTimeMallGiftPackActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
			DataManager<ActivityManager>.GetInstance().RequestGiftDatas();
			this.mCheckComponent.Checked(this);
			if (this.mDataModel.Id == 5000U)
			{
				Utility.DoStartFrameOperation("MallGiftPackActivity", "MallGiftPackActivityBtn");
			}
		}

		// Token: 0x0600F47E RID: 62590 RVA: 0x00420222 File Offset: 0x0041E622
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F47F RID: 62591 RVA: 0x00420241 File Offset: 0x0041E641
		public void Close()
		{
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Close();
			}
			this.mView = null;
			this.mGameObject = null;
		}

		// Token: 0x0600F480 RID: 62592 RVA: 0x00420274 File Offset: 0x0041E674
		public void UpdateData()
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(this.mDataModel.Id);
			List<MallItemInfo> giftPackInfos = DataManager<ActivityDataManager>.GetInstance().GetGiftPackInfos(this.mMallType);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeGiftPackModel(limitTimeActivityData, giftPackInfos, this.mMallType, this._GetItemPrefabPath(), null, null, null);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
		}

		// Token: 0x0600F481 RID: 62593 RVA: 0x004202EC File Offset: 0x0041E6EC
		public void UpdateTask(int taskId)
		{
			this.mDataModel.UpdateItem(taskId);
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F482 RID: 62594 RVA: 0x0042031C File Offset: 0x0041E71C
		public bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F483 RID: 62595 RVA: 0x0042032C File Offset: 0x0041E72C
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F484 RID: 62596 RVA: 0x00420339 File Offset: 0x0041E739
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F485 RID: 62597 RVA: 0x00420346 File Offset: 0x0041E746
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F486 RID: 62598 RVA: 0x00420353 File Offset: 0x0041E753
		public virtual void Dispose()
		{
			this.mGameObject = null;
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
		}

		// Token: 0x0600F487 RID: 62599 RVA: 0x00420388 File Offset: 0x0041E788
		protected virtual void _OnItemClick(int id, int param, ulong param2)
		{
			if (this.mDataModel.DetailDatas != null && id >= 0 && id < this.mDataModel.DetailDatas.Count)
			{
				LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel = this.mDataModel.DetailDatas[id];
				if (limitTimeGiftPackDetailModel.PriceType == LimitTimeGiftPriceType.Point || limitTimeGiftPackDetailModel.PriceType == LimitTimeGiftPriceType.BindPint || limitTimeGiftPackDetailModel.PriceType == LimitTimeGiftPriceType.Gold || limitTimeGiftPackDetailModel.PriceType == LimitTimeGiftPriceType.BindGOLD)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(this.mMallType, limitTimeGiftPackDetailModel.Id), string.Empty);
				}
				else if (limitTimeGiftPackDetailModel.PriceType == LimitTimeGiftPriceType.RMB)
				{
					Singleton<PayManager>.GetInstance().DoPay(id, limitTimeGiftPackDetailModel.GiftPrice, ChargeMallType.Packet);
				}
			}
		}

		// Token: 0x0600F488 RID: 62600
		protected abstract string _GetItemPrefabPath();

		// Token: 0x0600F489 RID: 62601
		protected abstract string _GetPrefabPath();

		// Token: 0x0400961F RID: 38431
		protected GameObject mGameObject;

		// Token: 0x04009620 RID: 38432
		protected bool mIsInit;

		// Token: 0x04009621 RID: 38433
		protected LimitTimeMallGiftPackActivityView mView;

		// Token: 0x04009622 RID: 38434
		protected LimitTimeGiftPackModel mDataModel;

		// Token: 0x04009623 RID: 38435
		protected readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();

		// Token: 0x04009624 RID: 38436
		protected MallTypeTable.eMallType mMallType;
	}
}

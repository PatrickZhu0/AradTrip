using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001851 RID: 6225
	public class LimitTimeGroupBuyActivity : IActivity, IDisposable
	{
		// Token: 0x0600F44F RID: 62543 RVA: 0x0041F34A File Offset: 0x0041D74A
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

		// Token: 0x0600F450 RID: 62544 RVA: 0x0041F377 File Offset: 0x0041D777
		public void Dispose()
		{
			this.Close();
		}

		// Token: 0x0600F451 RID: 62545 RVA: 0x0041F37F File Offset: 0x0041D77F
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F452 RID: 62546 RVA: 0x0041F38C File Offset: 0x0041D78C
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F453 RID: 62547 RVA: 0x0041F399 File Offset: 0x0041D799
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F454 RID: 62548 RVA: 0x0041F3A6 File Offset: 0x0041D7A6
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F455 RID: 62549 RVA: 0x0041F3C8 File Offset: 0x0041D7C8
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
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(this.mMallType);
		}

		// Token: 0x0600F456 RID: 62550 RVA: 0x0041F44D File Offset: 0x0041D84D
		public bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F457 RID: 62551 RVA: 0x0041F460 File Offset: 0x0041D860
		public void Show(Transform root)
		{
			if (this.mDataModel.Id == 0U)
			{
				return;
			}
			if (this.mData == null)
			{
				return;
			}
			this.mCheckComponent.Checked(this);
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
				this.UpdateData();
				this.mView = this.mGameObject.GetComponent<IGiftPackActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
				DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(this.mMallType);
			}
		}

		// Token: 0x0600F458 RID: 62552 RVA: 0x0041F57C File Offset: 0x0041D97C
		public void UpdateData()
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(this.mDataModel.Id);
			List<MallItemInfo> giftPackInfos = DataManager<ActivityDataManager>.GetInstance().GetGiftPackInfos(this.mMallType);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeGiftPackModel(limitTimeActivityData, giftPackInfos, this.mMallType, this._GetItemPrefabPath(), null, null, null);
			}
		}

		// Token: 0x0600F459 RID: 62553 RVA: 0x0041F5D2 File Offset: 0x0041D9D2
		public void UpdateTask(int taskId)
		{
		}

		// Token: 0x0600F45A RID: 62554 RVA: 0x0041F5D4 File Offset: 0x0041D9D4
		protected virtual void _OnItemClick(int id, int param, ulong param2)
		{
			if (this.mDataModel.DetailDatas != null && id >= 0 && id < this.mDataModel.DetailDatas.Count)
			{
				LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel = this.mDataModel.DetailDatas[id];
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(this.mMallType, limitTimeGiftPackDetailModel.Id), string.Empty);
			}
		}

		// Token: 0x0600F45B RID: 62555 RVA: 0x0041F648 File Offset: 0x0041DA48
		protected virtual string _GetItemPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x0600F45C RID: 62556 RVA: 0x0041F650 File Offset: 0x0041DA50
		protected virtual string _GetPrefabPath()
		{
			string empty = string.Empty;
			if (this.mData != null && !string.IsNullOrEmpty(this.mData.prefabPath))
			{
				return this.mData.prefabPath;
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LimitTimeGroupBuyActivity";
		}

		// Token: 0x04009611 RID: 38417
		private readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();

		// Token: 0x04009612 RID: 38418
		protected GameObject mGameObject;

		// Token: 0x04009613 RID: 38419
		protected bool mIsInit;

		// Token: 0x04009614 RID: 38420
		protected LimitTimeGiftPackModel mDataModel;

		// Token: 0x04009615 RID: 38421
		protected IGiftPackActivityView mView;

		// Token: 0x04009616 RID: 38422
		protected MallTypeTable.eMallType mMallType;

		// Token: 0x04009617 RID: 38423
		protected OpActivityData mData;
	}
}

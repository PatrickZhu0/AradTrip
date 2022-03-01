using System;
using System.Collections.Generic;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001842 RID: 6210
	public class FlyingGiftPackActivity : IActivity, IDisposable
	{
		// Token: 0x0600F3F0 RID: 62448 RVA: 0x0041E310 File Offset: 0x0041C710
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

		// Token: 0x0600F3F1 RID: 62449 RVA: 0x0041E398 File Offset: 0x0041C798
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
				this.mView = this.mGameObject.GetComponent<IGiftPackActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
				DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData(this.mMallType);
			}
		}

		// Token: 0x0600F3F2 RID: 62450 RVA: 0x0041E4AE File Offset: 0x0041C8AE
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

		// Token: 0x0600F3F3 RID: 62451 RVA: 0x0041E4DB File Offset: 0x0041C8DB
		public void Dispose()
		{
			this.Close();
		}

		// Token: 0x0600F3F4 RID: 62452 RVA: 0x0041E4E3 File Offset: 0x0041C8E3
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F3F5 RID: 62453 RVA: 0x0041E4F0 File Offset: 0x0041C8F0
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F3F6 RID: 62454 RVA: 0x0041E4FD File Offset: 0x0041C8FD
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F3F7 RID: 62455 RVA: 0x0041E50A File Offset: 0x0041C90A
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F3F8 RID: 62456 RVA: 0x0041E52C File Offset: 0x0041C92C
		public bool IsHaveRedPoint()
		{
			bool flag = false;
			if (this.mData != null)
			{
				for (int i = 0; i < this.mDataModel.DetailDatas.Count; i++)
				{
					if (this.mDataModel.DetailDatas[i].Limit != 0)
					{
						if (this.mDataModel.DetailDatas[i].Limit == 2)
						{
							flag = (this.mDataModel.DetailDatas[i].LimitPurchaseNum - DataManager<CountDataManager>.GetInstance().GetCount(this.mDataModel.DetailDatas[i].Id.ToString()) > 0);
						}
						else
						{
							flag = ((ulong)this.mDataModel.DetailDatas[i].LimitNum - (ulong)((long)DataManager<CountDataManager>.GetInstance().GetCount(this.mDataModel.DetailDatas[i].Id.ToString())) > 0UL);
						}
					}
					else if (this.mDataModel.DetailDatas[i].AccountLimitBuyNum > 0U)
					{
						flag = (this.mDataModel.DetailDatas[i].AccountRestBuyNum > 0U);
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (flag)
			{
				return !this.mCheckComponent.IsChecked();
			}
			return flag;
		}

		// Token: 0x0600F3F9 RID: 62457 RVA: 0x0041E6B4 File Offset: 0x0041CAB4
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

		// Token: 0x0600F3FA RID: 62458 RVA: 0x0041E726 File Offset: 0x0041CB26
		public void UpdateTask(int taskId)
		{
		}

		// Token: 0x0600F3FB RID: 62459 RVA: 0x0041E728 File Offset: 0x0041CB28
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

		// Token: 0x0600F3FC RID: 62460 RVA: 0x0041E7F8 File Offset: 0x0041CBF8
		protected virtual string _GetItemPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x0600F3FD RID: 62461 RVA: 0x0041E800 File Offset: 0x0041CC00
		protected virtual string _GetPrefabPath()
		{
			string result = string.Empty;
			if (this.mData != null && !string.IsNullOrEmpty(this.mData.prefabPath))
			{
				return this.mData.prefabPath;
			}
			if (this.mData == null)
			{
				return result;
			}
			if (this.mData.parm2 == null || this.mData.parm2.Length < 1)
			{
				return result;
			}
			switch (this.mData.parm2[0])
			{
			case 1U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FlyingGiftPackActivity";
				break;
			case 2U:
				result = "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryThankgivingActivity";
				break;
			case 3U:
				result = "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryLuckyBagActivity";
				break;
			case 4U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FashionSyntheticActivity";
				break;
			case 5U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CommonGiftAccountPurchaseActivity";
				break;
			case 6U:
				result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CommonGiftDailyPurchaseActivity";
				break;
			}
			return result;
		}

		// Token: 0x040095F3 RID: 38387
		private readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();

		// Token: 0x040095F4 RID: 38388
		protected GameObject mGameObject;

		// Token: 0x040095F5 RID: 38389
		protected bool mIsInit;

		// Token: 0x040095F6 RID: 38390
		protected LimitTimeGiftPackModel mDataModel;

		// Token: 0x040095F7 RID: 38391
		protected IGiftPackActivityView mView;

		// Token: 0x040095F8 RID: 38392
		protected MallTypeTable.eMallType mMallType;

		// Token: 0x040095F9 RID: 38393
		protected OpActivityData mData;
	}
}

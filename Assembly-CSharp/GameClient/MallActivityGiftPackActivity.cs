using System;
using ActivityLimitTime;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001856 RID: 6230
	public class MallActivityGiftPackActivity : IActivity, IDisposable
	{
		// Token: 0x0600F48B RID: 62603 RVA: 0x00420488 File Offset: 0x0041E888
		public void Init(uint activityId)
		{
			MallItemInfo giftPackData = DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(MallTypeTable.eMallType.SN_ACTIVITY_GIFT, activityId);
			if (giftPackData != null)
			{
				this.mDataModel = new LimitTimeGiftPackDetailModel(giftPackData);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F48C RID: 62604 RVA: 0x004204C0 File Offset: 0x0041E8C0
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
				this.mView = this.mGameObject.GetComponent<MallActivityGiftPackActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new UnityAction(this._OnBuyClick));
					this.mIsInit = true;
				}
			}
			DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData();
			this.mCheckComponent.Checked(this);
			Utility.DoStartFrameOperation("MallActivityGiftPackActivity", string.Format("ActivityId/{0}", this.mDataModel.Id));
		}

		// Token: 0x0600F48D RID: 62605 RVA: 0x004205EE File Offset: 0x0041E9EE
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F48E RID: 62606 RVA: 0x0042060D File Offset: 0x0041EA0D
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

		// Token: 0x0600F48F RID: 62607 RVA: 0x00420640 File Offset: 0x0041EA40
		public void UpdateData()
		{
			MallItemInfo giftPackData = DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(MallTypeTable.eMallType.SN_ACTIVITY_GIFT, this.mDataModel.Id);
			if (giftPackData != null)
			{
				this.mDataModel = new LimitTimeGiftPackDetailModel(giftPackData);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
			else
			{
				this.mState = OpActivityState.OAS_END;
			}
		}

		// Token: 0x0600F490 RID: 62608 RVA: 0x004206A4 File Offset: 0x0041EAA4
		public void UpdateTask(int taskId)
		{
		}

		// Token: 0x0600F491 RID: 62609 RVA: 0x004206A6 File Offset: 0x0041EAA6
		public bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F492 RID: 62610 RVA: 0x004206B6 File Offset: 0x0041EAB6
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F493 RID: 62611 RVA: 0x004206C3 File Offset: 0x0041EAC3
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F494 RID: 62612 RVA: 0x004206D0 File Offset: 0x0041EAD0
		public OpActivityState GetState()
		{
			return this.mState;
		}

		// Token: 0x0600F495 RID: 62613 RVA: 0x004206D8 File Offset: 0x0041EAD8
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

		// Token: 0x0600F496 RID: 62614 RVA: 0x0042070C File Offset: 0x0041EB0C
		protected virtual void _OnBuyClick()
		{
			MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)this.mDataModel.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.BuyLink == MallLimitTimeActivity.eBuyLink.Go_To_Mall_Limit_Buy)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
				{
					MallNewType = MallNewType.LimitTimeMall
				}, string.Empty);
				Singleton<ClientSystemManager>.instance.CloseFrameByType(typeof(LimitTimeActivityFrame), false);
				Utility.DoStartFrameOperation("MallActivityGiftPackActivity", string.Format("GotoShop/{0}", this.mDataModel.Id));
			}
			else if (tableItem.BuyLink == MallLimitTimeActivity.eBuyLink.Go_To_Prop_Mall_Limit)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
				{
					MallNewType = MallNewType.PropertyMall
				}, string.Empty);
				Singleton<ClientSystemManager>.instance.CloseFrameByType(typeof(LimitTimeActivityFrame), false);
				Utility.DoStartFrameOperation("MallActivityGiftPackActivity", string.Format("GotoShop/{0}", this.mDataModel.Id));
			}
			else if (tableItem.BuyLink == MallLimitTimeActivity.eBuyLink.Go_To_Dungeon)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BossSelectBattleFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<BossSelectBattleFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			else
			{
				LimitTimeGiftPriceType priceType = this.mDataModel.PriceType;
				uint id = this.mDataModel.Id;
				int price = this.mDataModel.GiftPrice;
				string msgContent = string.Format(TR.Value("activity_activity_gift_pack_buy_tip"), price);
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					if (priceType == LimitTimeGiftPriceType.Point)
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.SendReqBuyGiftInMall(id, price, 1);
					}
				}, null, 0f, false);
			}
		}

		// Token: 0x0600F497 RID: 62615 RVA: 0x004208B2 File Offset: 0x0041ECB2
		protected virtual string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/MallActivityGiftPackActivity";
		}

		// Token: 0x04009625 RID: 38437
		protected GameObject mGameObject;

		// Token: 0x04009626 RID: 38438
		protected bool mIsInit;

		// Token: 0x04009627 RID: 38439
		protected MallActivityGiftPackActivityView mView;

		// Token: 0x04009628 RID: 38440
		private LimitTimeGiftPackDetailModel mDataModel;

		// Token: 0x04009629 RID: 38441
		private readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();

		// Token: 0x0400962A RID: 38442
		private OpActivityState mState = OpActivityState.OAS_IN;
	}
}

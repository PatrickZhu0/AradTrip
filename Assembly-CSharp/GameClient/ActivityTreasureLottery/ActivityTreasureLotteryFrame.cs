using System;
using DataModel;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E1 RID: 5089
	public sealed class ActivityTreasureLotteryFrame : ClientFrame
	{
		// Token: 0x0600C551 RID: 50513 RVA: 0x002F8B0B File Offset: 0x002F6F0B
		public static void OpenLinkFrame(string value)
		{
			if (DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetState() == ETreasureLotterState.Close)
			{
				SystemNotifyManager.SystemNotify(9062, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityTreasureLotteryFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600C552 RID: 50514 RVA: 0x002F8B42 File Offset: 0x002F6F42
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActivityTreasureLottery/ActivityTreasureLotteryFrame";
		}

		// Token: 0x0600C553 RID: 50515 RVA: 0x002F8B4C File Offset: 0x002F6F4C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._OnUpdate(0f);
			this.mIsNeedUpdate = true;
			this.BindEvents();
			if (this.userData != null && this.userData is EActivityTreasureLotteryView)
			{
				this.mView.Init(DataManager<ActivityTreasureLotteryDataManager>.GetInstance(), this.mBind.GetPrefabPath("ItemPrefabPath"), new UnityAction(this.OnChangeSubView), (EActivityTreasureLotteryView)this.userData);
			}
			else
			{
				this.mView.Init(DataManager<ActivityTreasureLotteryDataManager>.GetInstance(), this.mBind.GetPrefabPath("ItemPrefabPath"), new UnityAction(this.OnChangeSubView), EActivityTreasureLotteryView.ActivityView);
			}
		}

		// Token: 0x0600C554 RID: 50516 RVA: 0x002F8BFB File Offset: 0x002F6FFB
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mIsNeedUpdate = false;
			this.mView.Dispose();
			this.UnBindEvents();
		}

		// Token: 0x0600C555 RID: 50517 RVA: 0x002F8C1B File Offset: 0x002F701B
		public override bool IsNeedUpdate()
		{
			return this.mIsNeedUpdate;
		}

		// Token: 0x0600C556 RID: 50518 RVA: 0x002F8C23 File Offset: 0x002F7023
		protected override void _OnUpdate(float timeElapsed)
		{
			this.RefreshData(false);
		}

		// Token: 0x0600C557 RID: 50519 RVA: 0x002F8C2C File Offset: 0x002F702C
		private void OnChangeSubView()
		{
			this.RefreshData(true);
		}

		// Token: 0x0600C558 RID: 50520 RVA: 0x002F8C38 File Offset: 0x002F7038
		private void RefreshData(bool isImmediately = false)
		{
			EActivityTreasureLotteryView currentSubView = this.mView.CurrentSubView;
			if (currentSubView != EActivityTreasureLotteryView.ActivityView)
			{
				if (currentSubView != EActivityTreasureLotteryView.HistoryView)
				{
					if (currentSubView == EActivityTreasureLotteryView.MyLotteryView)
					{
						DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetMyLotteryItemList(false);
					}
				}
				else
				{
					DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetHistroyItemList(false);
				}
			}
			else
			{
				DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetLotteryItemList(false);
			}
		}

		// Token: 0x0600C559 RID: 50521 RVA: 0x002F8C9C File Offset: 0x002F709C
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotteryBuyResp, new ClientEventSystem.UIEventHandler(this.OnBuyResp));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotterySyncActivity, new ClientEventSystem.UIEventHandler(this.OnSyncActivity));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotterySyncMyLottery, new ClientEventSystem.UIEventHandler(this.OnSyncMyLottery));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotterySyncHistory, new ClientEventSystem.UIEventHandler(this.OnSyncHistory));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotteryShowHistory, new ClientEventSystem.UIEventHandler(this.OnShowHistory));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotteryShowActivity, new ClientEventSystem.UIEventHandler(this.OnShowActivity));
		}

		// Token: 0x0600C55A RID: 50522 RVA: 0x002F8D4C File Offset: 0x002F714C
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotteryBuyResp, new ClientEventSystem.UIEventHandler(this.OnBuyResp));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotterySyncActivity, new ClientEventSystem.UIEventHandler(this.OnSyncActivity));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotterySyncMyLottery, new ClientEventSystem.UIEventHandler(this.OnSyncMyLottery));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotterySyncHistory, new ClientEventSystem.UIEventHandler(this.OnSyncHistory));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotteryShowHistory, new ClientEventSystem.UIEventHandler(this.OnShowHistory));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotteryShowActivity, new ClientEventSystem.UIEventHandler(this.OnShowActivity));
		}

		// Token: 0x0600C55B RID: 50523 RVA: 0x002F8DFC File Offset: 0x002F71FC
		private void OnBuyResp(UIEvent data)
		{
			PayingGambleRes payingGambleRes = data.Param1 as PayingGambleRes;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)payingGambleRes.costCurrencyId, string.Empty, string.Empty);
			ProtoErrorCode retCode = (ProtoErrorCode)payingGambleRes.retCode;
			if (retCode != ProtoErrorCode.ITEM_SOLD_OUT)
			{
				if (retCode != ProtoErrorCode.ITEM_COPIES_NOT_ENOUGH)
				{
					if (retCode != ProtoErrorCode.SUCCESS)
					{
						if (retCode != ProtoErrorCode.ITEM_NO_REASON)
						{
							if (retCode != ProtoErrorCode.ITEM_NOT_SELL)
							{
								if (retCode != ProtoErrorCode.ITEM_NOT_ENOUGH_MONEY)
								{
									if (retCode != ProtoErrorCode.ITEM_OFF_SALE)
									{
										if (retCode == ProtoErrorCode.ITEM_GAMBLE_ALL_SOLD_OUT)
										{
											SystemNotifyManager.SystemNotify(9065, string.Empty);
										}
									}
								}
								else
								{
									CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
									{
										ContentLabel = string.Format(TR.Value("activity_treasure_lock"), (tableItem != null) ? tableItem.Name : string.Empty),
										IsShowNotify = false,
										LeftButtonText = TR.Value("activity_treasure_lock_cancel"),
										RightButtonText = TR.Value("activity_treasure_lock_Ok"),
										OnRightButtonClickCallBack = delegate()
										{
											this.BuyCurrency();
										}
									};
									SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
								}
							}
							else
							{
								SystemNotifyManager.SystemNotify(9073, string.Empty);
							}
						}
					}
					else
					{
						string msgContent = string.Format(TR.Value("activity_treasure_lottery_buy_success"), payingGambleRes.investCopies, payingGambleRes.costCurrencyNum, (tableItem != null) ? tableItem.Name : string.Empty);
						int itemIdByLotteryId = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetItemIdByLotteryId((int)payingGambleRes.gambingItemId);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, itemIdByLotteryId);
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(9074, string.Empty);
				}
			}
			else
			{
				SystemNotifyManager.SystemNotify(9061, string.Empty);
			}
		}

		// Token: 0x0600C55C RID: 50524 RVA: 0x002F8FC5 File Offset: 0x002F73C5
		private void OnSyncActivity(UIEvent data)
		{
			this.mView.UpdateData();
		}

		// Token: 0x0600C55D RID: 50525 RVA: 0x002F8FD2 File Offset: 0x002F73D2
		private void OnSyncMyLottery(UIEvent data)
		{
			this.mView.UpdateData();
		}

		// Token: 0x0600C55E RID: 50526 RVA: 0x002F8FDF File Offset: 0x002F73DF
		private void OnSyncHistory(UIEvent data)
		{
			this.mView.UpdateData();
		}

		// Token: 0x0600C55F RID: 50527 RVA: 0x002F8FEC File Offset: 0x002F73EC
		private void OnShowHistory(UIEvent data)
		{
			this.mView.ShowSubView(EActivityTreasureLotteryView.HistoryView);
		}

		// Token: 0x0600C560 RID: 50528 RVA: 0x002F8FFA File Offset: 0x002F73FA
		private void OnShowActivity(UIEvent data)
		{
			this.mView.ShowSubView(EActivityTreasureLotteryView.ActivityView);
		}

		// Token: 0x0600C561 RID: 50529 RVA: 0x002F9008 File Offset: 0x002F7408
		private void BuyCurrency()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
			}
		}

		// Token: 0x0600C562 RID: 50530 RVA: 0x002F9034 File Offset: 0x002F7434
		protected override void _bindExUI()
		{
			this.mView = this.mBind.GetCom<ActivityTreasureLotteryView>("View");
			this.mView.OnButtonCloseCallBack = new UnityAction(this.CloseFrame);
			this.mView.OnButtonBuyCallBack = new UnityAction(this.BuyLottery);
			this.mView.OnButtonBuyAllCallBack = new UnityAction(this.BuyAllLottery);
		}

		// Token: 0x0600C563 RID: 50531 RVA: 0x002F909C File Offset: 0x002F749C
		protected override void _unbindExUI()
		{
			this.mView.OnButtonCloseCallBack = null;
			this.mView.OnButtonBuyCallBack = null;
			this.mView.OnButtonBuyAllCallBack = null;
			this.mView = null;
		}

		// Token: 0x0600C564 RID: 50532 RVA: 0x002F90CC File Offset: 0x002F74CC
		private bool CheckState(IActivityTreasureLotteryModel model)
		{
			switch (model.State)
			{
			case GambingItemStatus.GIS_PREPARE:
			case GambingItemStatus.GIS_OFF_SALE:
				SystemNotifyManager.SystemNotify(9073, string.Empty);
				return false;
			case GambingItemStatus.GIS_SELLING:
				return true;
			case GambingItemStatus.GIS_SOLD_OUE:
			case GambingItemStatus.GIS_LOTTERY:
				SystemNotifyManager.SystemNotify(9061, string.Empty);
				return false;
			default:
				return false;
			}
		}

		// Token: 0x0600C565 RID: 50533 RVA: 0x002F9126 File Offset: 0x002F7526
		private void CloseFrame()
		{
			base.Close(false);
		}

		// Token: 0x0600C566 RID: 50534 RVA: 0x002F912F File Offset: 0x002F752F
		private void BuyLottery()
		{
			this.BuyLottery(false, this.mView.BuyCount);
		}

		// Token: 0x0600C567 RID: 50535 RVA: 0x002F9143 File Offset: 0x002F7543
		private void BuyAllLottery()
		{
			this.BuyLottery(true, this.mView.LeftCount);
		}

		// Token: 0x0600C568 RID: 50536 RVA: 0x002F9158 File Offset: 0x002F7558
		private void BuyLottery(bool isBuyAll, uint count)
		{
			if (this.mView.SelectId < 0)
			{
				return;
			}
			IActivityTreasureLotteryModel model = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetModel<IActivityTreasureLotteryModel>(this.mView.SelectId);
			if (count <= 0U && model.LeftNum >= 1U)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请选择购买数量", CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			if (!this.CheckState(model))
			{
				return;
			}
			if (isBuyAll)
			{
				DataManager<ActivityTreasureLotteryDataManager>.GetInstance().BuyLottery(this.mView.SelectId, count, true);
			}
			else
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = model.MoneyId;
				costInfo.nCount = (int)count;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					DataManager<ActivityTreasureLotteryDataManager>.GetInstance().BuyLottery(this.mView.SelectId, count, false);
				}, "common_money_cost", null);
			}
		}

		// Token: 0x040070B1 RID: 28849
		private bool mIsNeedUpdate;

		// Token: 0x040070B2 RID: 28850
		private ActivityTreasureLotteryView mView;
	}
}

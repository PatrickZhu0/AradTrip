using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001218 RID: 4632
	public class CoinDealDataManager : DataManager<CoinDealDataManager>
	{
		// Token: 0x0600B225 RID: 45605 RVA: 0x0027756D File Offset: 0x0027596D
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600B226 RID: 45606 RVA: 0x00277575 File Offset: 0x00275975
		public override void Clear()
		{
			this.UnBindNetEvents();
			this.ClearData();
		}

		// Token: 0x0600B227 RID: 45607 RVA: 0x00277584 File Offset: 0x00275984
		private void ClearData()
		{
			this._creditTicketItemTable = null;
			this._coinDealBaseTradeRate = 0f;
			this._coinDealBaseSinglePriceByCoinNumber = 0;
			this._coinDealSubmitOrderMaxNumber = 0;
			this._coinDealHangListLastTime = 0;
			this._coinDealMinCoinDealNumber = 0;
			this._coinDealBaseTradeCoinNumber = 0;
			this._coinDealMaxCoinDealNumber = 0;
			this._coinDealFeeRate = 0;
			this._coinDealCreditTicketExchangeRate = 0;
			this._coinDealCreditTicketExchangeDayNumber = 0;
			this._coinDealSinglePriceChangeRate = 0;
			this._coinDealCoinNumberMaxShowNumber = 0UL;
			this._coinDealOrderPageRefreshTime = 0;
			this._coinDealBaseNumberOfSinglePrice = 0;
			this.IsNotShowSubmitBuyOrderTipJustOnce = false;
			this.IsNotShowSubmitBuyOrderTipWithMore = false;
			this.IsNotShowSubmitSellOrderTip = false;
			this.ResetCoinDealSubmitOrderDataModelWithBuy();
			this.ResetCoinDealSubmitOrderDataModelWithSell();
			this.IsNotShowBuyOrderCancelTip = false;
			this.IsNotShowSellOrderCancelTip = false;
			this.IsCoinDealBuyOrderJustOnce = false;
			this.CoinDealMinCoinNumberWithBase = 0;
			this.CoinDealMaxCoinNumberWithBase = 0;
			this.CreditTicketGetNumberInTrade = 0;
			this._maxLevelInAccountByCache = -1;
			this._vipLevelByCache = -1;
			this._creditTicketMaxNumberInMonth = 0;
			this._creditTicketMaxNumberInSelfPlayer = 0;
			this.ResetCoinDealOrderPageRefreshTimeInterval();
			this.ResetCoinDealDataModel();
			this.IsCoinDealShowRedPoint = false;
		}

		// Token: 0x0600B228 RID: 45608 RVA: 0x0027767C File Offset: 0x00275A7C
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(1210102U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentOrderPageRes));
			NetProcess.AddMsgHandler(510102U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentSubmitOrderRes));
			NetProcess.AddMsgHandler(1210106U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentOwnerOrderRes));
			NetProcess.AddMsgHandler(1210108U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentCancelOrderRes));
			NetProcess.AddMsgHandler(1210104U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentDealRecordRes));
			NetProcess.AddMsgHandler(510103U, new Action<MsgDATA>(this.OnReceiveSceneGoldConsignmentDealNotify));
			NetProcess.AddMsgHandler(510105U, new Action<MsgDATA>(this.OnReceiveSceneCreditPointRecordRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_GOLD_CONSIGNMENT, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
		}

		// Token: 0x0600B229 RID: 45609 RVA: 0x00277740 File Offset: 0x00275B40
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(1210102U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentOrderPageRes));
			NetProcess.RemoveMsgHandler(510102U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentSubmitOrderRes));
			NetProcess.RemoveMsgHandler(1210106U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentOwnerOrderRes));
			NetProcess.RemoveMsgHandler(1210108U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentCancelOrderRes));
			NetProcess.RemoveMsgHandler(1210104U, new Action<MsgDATA>(this.OnReceiveUnionGoldConsignmentDealRecordRes));
			NetProcess.RemoveMsgHandler(510103U, new Action<MsgDATA>(this.OnReceiveSceneGoldConsignmentDealNotify));
			NetProcess.RemoveMsgHandler(510105U, new Action<MsgDATA>(this.OnReceiveSceneCreditPointRecordRes));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_GOLD_CONSIGNMENT, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
		}

		// Token: 0x0600B22A RID: 45610 RVA: 0x00277802 File Offset: 0x00275C02
		public void RequestCoinDealOrderItemData()
		{
			this.IsCoinDealRequestTradeItemData = false;
			this.SetCoinDealOrderPageRefreshTimeInterval();
			this.OnSendUnionGoldConsignmentOrderPageReq();
		}

		// Token: 0x0600B22B RID: 45611 RVA: 0x00277818 File Offset: 0x00275C18
		public void OnSendUnionGoldConsignmentOrderPageReq()
		{
			UnionGoldConsignmentOrderPageReq cmd = new UnionGoldConsignmentOrderPageReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<UnionGoldConsignmentOrderPageReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B22C RID: 45612 RVA: 0x00277848 File Offset: 0x00275C48
		private void OnReceiveUnionGoldConsignmentOrderPageRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionGoldConsignmentOrderPageRes unionGoldConsignmentOrderPageRes = new UnionGoldConsignmentOrderPageRes();
			unionGoldConsignmentOrderPageRes.decode(msgData.bytes);
			int startCloseTime = (int)unionGoldConsignmentOrderPageRes.startCloseTime;
			int endCloseTime = (int)unionGoldConsignmentOrderPageRes.endCloseTime;
			int startCloseStamp = (int)unionGoldConsignmentOrderPageRes.startCloseStamp;
			if (this.CloseMarketStartTime != startCloseTime || this.CloseMarketEndTime != endCloseTime || this.CloseMarketStartTimeStamp != startCloseStamp)
			{
				this.CloseMarketStartTime = startCloseTime;
				this.CloseMarketEndTime = endCloseTime;
				this.CloseMarketStartTimeStamp = startCloseStamp;
				if (this.CloseMarketEndTime >= this.CloseMarketStartTime)
				{
					int num = (this.CloseMarketEndTime - this.CloseMarketStartTime) * 3600;
					this.CloseMarketEndTimeStamp = this.CloseMarketStartTimeStamp + num;
				}
				else
				{
					int num2 = (24 - this.CloseMarketStartTime + this.CloseMarketEndTime) * 3600;
					this.CloseMarketEndTimeStamp = this.CloseMarketStartTimeStamp + num2;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealCloseMarketTimeUpdateMessage, null, null, null, null);
			}
			int lastAveragePrice = (int)unionGoldConsignmentOrderPageRes.lastAveragePrice;
			if (this.CoinDealAveragePriceValue != lastAveragePrice)
			{
				this.CoinDealAveragePriceValue = lastAveragePrice;
				this.UpdateCoinDealMinAndMaxDealPriceValue();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, null, null, null, null);
			}
			int sellAccNum = (int)unionGoldConsignmentOrderPageRes.sellAccNum;
			int buyAccNum = (int)unionGoldConsignmentOrderPageRes.buyAccNum;
			if (this.CoinDealOwnerOrderNumberWithSell != sellAccNum || this.CoinDealOwnerOrderNumberWithBuy != buyAccNum)
			{
				this.CoinDealOwnerOrderNumberWithBuy = buyAccNum;
				this.CoinDealOwnerOrderNumberWithSell = sellAccNum;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealOwnerOrderNumberUpdateMessage, null, null, null, null);
			}
			this.CreditTicketGetNumberInTrade = (int)unionGoldConsignmentOrderPageRes.estimateIncome;
			this.ResetCoinDealOrderGradeDataModelList();
			OrderGradeInfo[] sellOrderList = unionGoldConsignmentOrderPageRes.sellOrderList;
			if (sellOrderList != null && sellOrderList.Length > 0)
			{
				foreach (OrderGradeInfo orderGradeInfo in sellOrderList)
				{
					if (orderGradeInfo != null)
					{
						CoinDealTradeDataModel item = CoinDealUtility.CreateCoinDealTradeDataModel(orderGradeInfo, GoldConsignmentOrderType.GCOT_SELL);
						this.CoinDealTradeDataModelListWithSell.Add(item);
					}
				}
			}
			if (this.CoinDealTradeDataModelListWithSell != null && this.CoinDealTradeDataModelListWithSell.Count >= 2)
			{
				this.CoinDealTradeDataModelListWithSell.Sort((CoinDealTradeDataModel x, CoinDealTradeDataModel y) => x.SinglePrice.CompareTo(y.SinglePrice));
			}
			OrderGradeInfo[] buyOrderList = unionGoldConsignmentOrderPageRes.buyOrderList;
			if (buyOrderList != null && buyOrderList.Length > 0)
			{
				foreach (OrderGradeInfo orderGradeInfo2 in buyOrderList)
				{
					if (orderGradeInfo2 != null)
					{
						CoinDealTradeDataModel item2 = CoinDealUtility.CreateCoinDealTradeDataModel(orderGradeInfo2, GoldConsignmentOrderType.GCOT_BUY);
						this.CoinDealTradeDataModelListWithBuy.Add(item2);
					}
				}
			}
			if (this.CoinDealTradeDataModelListWithBuy != null && this.CoinDealTradeDataModelListWithBuy.Count >= 2)
			{
				this.CoinDealTradeDataModelListWithBuy.Sort((CoinDealTradeDataModel x, CoinDealTradeDataModel y) => -x.SinglePrice.CompareTo(y.SinglePrice));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealTradeItemMessageRes, null, null, null, null);
			int todayAveragePrice = (int)unionGoldConsignmentOrderPageRes.todayAveragePrice;
			int recentAveragePrice = (int)unionGoldConsignmentOrderPageRes.recentAveragePrice;
			if (this.CoinDealAveragePriceValueInToday != todayAveragePrice || this.CoinDealAveragePriceValueInRecently != recentAveragePrice)
			{
				this.CoinDealAveragePriceValueInToday = todayAveragePrice;
				this.CoinDealAveragePriceValueInRecently = recentAveragePrice;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, null, null, null, null);
			}
			this.DealMyOrderPriceInvalid((int)unionGoldConsignmentOrderPageRes.isHasUnitAbnormalOrder);
		}

		// Token: 0x0600B22D RID: 45613 RVA: 0x00277B74 File Offset: 0x00275F74
		private void DealMyOrderPriceInvalid(int isHasUnitAbnormalOrder)
		{
			if (this.IsAlreadyDealMyOrderPriceInValidFlag)
			{
				return;
			}
			if (!CoinDealUtility.IsCoinDealFrameOpen())
			{
				return;
			}
			this.IsAlreadyDealMyOrderPriceInValidFlag = true;
			if (isHasUnitAbnormalOrder != 1)
			{
				return;
			}
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			int typeKeyIntValue = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.CoinDealMyOrderPriceInValidTime, new object[0]);
			bool flag = TimeUtility.IsInSameDayOfTwoTimeStamp((ulong)serverTime, (ulong)((long)typeKeyIntValue));
			if (flag)
			{
				return;
			}
			CoinDealUtility.OnOpenCoinDealSwitchToMyOrderTabTipFrame();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.CoinDealMyOrderPriceInValidTime, (int)serverTime, new object[0]);
		}

		// Token: 0x0600B22E RID: 45614 RVA: 0x00277C00 File Offset: 0x00276000
		public void OnSendUnionGoldConsignmentSubmitOrderReq(GoldConsignmentOrderType orderType, int singlePrice, int dealNumber, GoldConsignmentTradeType tradeType = GoldConsignmentTradeType.GCOT_HANG_LIST)
		{
			UnionGoldConsignmentSubmitOrderReq unionGoldConsignmentSubmitOrderReq = new UnionGoldConsignmentSubmitOrderReq();
			unionGoldConsignmentSubmitOrderReq.orderType = (uint)orderType;
			unionGoldConsignmentSubmitOrderReq.unitPrice = (uint)singlePrice;
			unionGoldConsignmentSubmitOrderReq.tradeNum = (uint)dealNumber;
			unionGoldConsignmentSubmitOrderReq.tradeType = (uint)tradeType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<UnionGoldConsignmentSubmitOrderReq>(ServerType.GATE_SERVER, unionGoldConsignmentSubmitOrderReq);
			}
		}

		// Token: 0x0600B22F RID: 45615 RVA: 0x00277C4C File Offset: 0x0027604C
		public void OnReceiveUnionGoldConsignmentSubmitOrderRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionGoldConsignmentSubmitOrderRes unionGoldConsignmentSubmitOrderRes = new UnionGoldConsignmentSubmitOrderRes();
			unionGoldConsignmentSubmitOrderRes.decode(msgData.bytes);
			if (unionGoldConsignmentSubmitOrderRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)unionGoldConsignmentSubmitOrderRes.retCode, string.Empty);
				return;
			}
			GoldConsignmentOrderType orderType = (GoldConsignmentOrderType)unionGoldConsignmentSubmitOrderRes.orderType;
			if (orderType == GoldConsignmentOrderType.GCOT_SELL)
			{
				if (unionGoldConsignmentSubmitOrderRes.dealNum == 0U)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Sell_Order_On_Shelf_Succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					if (this.CoinDealSubmitOrderDataModelWithSell == null)
					{
						this.CoinDealSubmitOrderDataModelWithSell = new CoinDealSubmitOrderDataModel();
					}
					this.CoinDealSubmitOrderDataModelWithSell.OrderType = GoldConsignmentOrderType.GCOT_SELL;
					this.CoinDealSubmitOrderDataModelWithSell.DealTotalNumber = unionGoldConsignmentSubmitOrderRes.dealNum;
					this.CoinDealSubmitOrderDataModelWithSell.UnDealNumber = unionGoldConsignmentSubmitOrderRes.hangListNum;
					this.CoinDealSubmitOrderDataModelWithSell.SinglePrice = unionGoldConsignmentSubmitOrderRes.unitPrice;
					this.CoinDealSubmitOrderDataModelWithSell.ReceiveNumber = unionGoldConsignmentSubmitOrderRes.param1;
					this.CoinDealSubmitOrderDataModelWithSell.FeeValueNumber = unionGoldConsignmentSubmitOrderRes.param2;
					CoinDealUtility.OnOpenCoinDealSellRecordFrame();
				}
			}
			else if (orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				if (unionGoldConsignmentSubmitOrderRes.dealNum == 0U)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Buy_Order_On_Shelf_Succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					if (this.CoinDealSubmitOrderDataModelWithBuy == null)
					{
						this.CoinDealSubmitOrderDataModelWithBuy = new CoinDealSubmitOrderDataModel();
					}
					this.CoinDealSubmitOrderDataModelWithBuy.OrderType = GoldConsignmentOrderType.GCOT_BUY;
					this.CoinDealSubmitOrderDataModelWithBuy.DealTotalNumber = unionGoldConsignmentSubmitOrderRes.dealNum;
					this.CoinDealSubmitOrderDataModelWithBuy.UnDealNumber = unionGoldConsignmentSubmitOrderRes.hangListNum;
					this.CoinDealSubmitOrderDataModelWithBuy.SinglePrice = unionGoldConsignmentSubmitOrderRes.unitPrice;
					this.CoinDealSubmitOrderDataModelWithBuy.PayNumber = unionGoldConsignmentSubmitOrderRes.param1;
					this.CoinDealSubmitOrderDataModelWithBuy.ReturnNumber = unionGoldConsignmentSubmitOrderRes.param2;
					CoinDealUtility.OnOpenCoinDealBuyRecordFrame();
				}
			}
			this.IsCoinDealRequestTradeItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestTradeItemData, null, null, null, null);
			if (unionGoldConsignmentSubmitOrderRes.hangListNum > 0U)
			{
				this.IsCoinDealRequestMyOrderItemData = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestMyOrderItemData, null, null, null, null);
			}
			if (unionGoldConsignmentSubmitOrderRes.dealNum > 0U)
			{
				this.IsCoinDealRequestRecordItemData = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestRecordItemData, null, null, null, null);
			}
		}

		// Token: 0x0600B230 RID: 45616 RVA: 0x00277E48 File Offset: 0x00276248
		public void OnSendUnionGoldConsignmentOwnerOrderReq()
		{
			UnionGoldConsignmentOwnerOrderReq cmd = new UnionGoldConsignmentOwnerOrderReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<UnionGoldConsignmentOwnerOrderReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B231 RID: 45617 RVA: 0x00277E78 File Offset: 0x00276278
		private void OnReceiveUnionGoldConsignmentOwnerOrderRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionGoldConsignmentOwnerOrderRes unionGoldConsignmentOwnerOrderRes = new UnionGoldConsignmentOwnerOrderRes();
			unionGoldConsignmentOwnerOrderRes.decode(msgData.bytes);
			this.ResetCoinDealMyOrderDataModelList();
			this.CoinDealOwnerOrderNumberWithBuy = (int)unionGoldConsignmentOwnerOrderRes.buyAccNum;
			GoldConsignmentOrder[] buyOrderList = unionGoldConsignmentOwnerOrderRes.buyOrderList;
			if (buyOrderList != null && buyOrderList.Length > 0)
			{
				foreach (GoldConsignmentOrder goldConsignmentOrder in buyOrderList)
				{
					if (goldConsignmentOrder != null)
					{
						CoinDealMyOrderDataModel coinDealMyOrderDataModel = CoinDealUtility.CreateCoinDealMyOrderDataModel(goldConsignmentOrder, GoldConsignmentOrderType.GCOT_BUY);
						if (coinDealMyOrderDataModel != null)
						{
							this.CoinDealMyOrderDataModelListWithBuy.Add(coinDealMyOrderDataModel);
						}
					}
				}
			}
			this.CoinDealOwnerOrderNumberWithSell = (int)unionGoldConsignmentOwnerOrderRes.sellAccNum;
			GoldConsignmentOrder[] sellOrderList = unionGoldConsignmentOwnerOrderRes.sellOrderList;
			if (sellOrderList != null && sellOrderList.Length > 0)
			{
				foreach (GoldConsignmentOrder goldConsignmentOrder2 in sellOrderList)
				{
					if (goldConsignmentOrder2 != null)
					{
						CoinDealMyOrderDataModel coinDealMyOrderDataModel2 = CoinDealUtility.CreateCoinDealMyOrderDataModel(goldConsignmentOrder2, GoldConsignmentOrderType.GCOT_SELL);
						if (coinDealMyOrderDataModel2 != null)
						{
							this.CoinDealMyOrderDataModelListWithSell.Add(coinDealMyOrderDataModel2);
						}
					}
				}
			}
			if (this.CoinDealMyOrderDataModelListWithBuy != null && this.CoinDealMyOrderDataModelListWithBuy.Count >= 2)
			{
				this.CoinDealMyOrderDataModelListWithBuy.Sort(delegate(CoinDealMyOrderDataModel x, CoinDealMyOrderDataModel y)
				{
					int num = -x.SinglePrice.CompareTo(y.SinglePrice);
					if (num == 0)
					{
						num = x.SubmitTimeStamp.CompareTo(y.SubmitTimeStamp);
					}
					return num;
				});
			}
			if (this.CoinDealMyOrderDataModelListWithSell != null && this.CoinDealMyOrderDataModelListWithSell.Count >= 2)
			{
				this.CoinDealMyOrderDataModelListWithSell.Sort(delegate(CoinDealMyOrderDataModel x, CoinDealMyOrderDataModel y)
				{
					int num = x.SinglePrice.CompareTo(y.SinglePrice);
					if (num == 0)
					{
						num = x.SubmitTimeStamp.CompareTo(y.SubmitTimeStamp);
					}
					return num;
				});
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealOwnerOrderMessageRes, null, null, null, null);
		}

		// Token: 0x0600B232 RID: 45618 RVA: 0x0027801C File Offset: 0x0027641C
		public void OnSendUnionGoldConsignmentCancelOrderReq(ulong orderId, GoldConsignmentOrderType orderType = GoldConsignmentOrderType.GCOT_SELL)
		{
			UnionGoldConsignmentCancelOrderReq unionGoldConsignmentCancelOrderReq = new UnionGoldConsignmentCancelOrderReq();
			unionGoldConsignmentCancelOrderReq.orderId = orderId;
			unionGoldConsignmentCancelOrderReq.orderType = (uint)orderType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<UnionGoldConsignmentCancelOrderReq>(ServerType.GATE_SERVER, unionGoldConsignmentCancelOrderReq);
			}
		}

		// Token: 0x0600B233 RID: 45619 RVA: 0x00278058 File Offset: 0x00276458
		private void OnReceiveUnionGoldConsignmentCancelOrderRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionGoldConsignmentCancelOrderRes unionGoldConsignmentCancelOrderRes = new UnionGoldConsignmentCancelOrderRes();
			unionGoldConsignmentCancelOrderRes.decode(msgData.bytes);
			if (unionGoldConsignmentCancelOrderRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)unionGoldConsignmentCancelOrderRes.retCode, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Cancel_Succeed_Label"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			this.IsCoinDealRequestTradeItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestTradeItemData, null, null, null, null);
			this.IsCoinDealRequestMyOrderItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestMyOrderItemData, null, null, null, null);
		}

		// Token: 0x0600B234 RID: 45620 RVA: 0x002780E0 File Offset: 0x002764E0
		public void OnSendUnionGoldConsignmentDealRecordReq()
		{
			UnionGoldConsignmentDealRecordReq cmd = new UnionGoldConsignmentDealRecordReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<UnionGoldConsignmentDealRecordReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B235 RID: 45621 RVA: 0x00278110 File Offset: 0x00276510
		private void OnReceiveUnionGoldConsignmentDealRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionGoldConsignmentDealRecordRes unionGoldConsignmentDealRecordRes = new UnionGoldConsignmentDealRecordRes();
			unionGoldConsignmentDealRecordRes.decode(msgData.bytes);
			this.ResetCoinDealRecordDataModelList();
			GoldConsignmentTradeRecord[] buyRecord = unionGoldConsignmentDealRecordRes.buyRecord;
			if (buyRecord != null && buyRecord.Length > 0)
			{
				foreach (GoldConsignmentTradeRecord goldConsignmentTradeRecord in buyRecord)
				{
					if (goldConsignmentTradeRecord != null)
					{
						CoinDealRecordDataModel coinDealRecordDataModel = CoinDealUtility.CreateCoinDealRecordDataModel(goldConsignmentTradeRecord, GoldConsignmentOrderType.GCOT_BUY);
						if (coinDealRecordDataModel != null)
						{
							this.CoinDealRecordDataModelListWithBuy.Add(coinDealRecordDataModel);
						}
					}
				}
			}
			GoldConsignmentTradeRecord[] sellRecord = unionGoldConsignmentDealRecordRes.sellRecord;
			if (sellRecord != null && sellRecord.Length > 0)
			{
				foreach (GoldConsignmentTradeRecord goldConsignmentTradeRecord2 in sellRecord)
				{
					if (goldConsignmentTradeRecord2 != null)
					{
						CoinDealRecordDataModel coinDealRecordDataModel2 = CoinDealUtility.CreateCoinDealRecordDataModel(goldConsignmentTradeRecord2, GoldConsignmentOrderType.GCOT_SELL);
						if (coinDealRecordDataModel2 != null)
						{
							this.CoinDealRecordDataModelListWithSell.Add(coinDealRecordDataModel2);
						}
					}
				}
			}
			if (this.CoinDealRecordDataModelListWithBuy != null && this.CoinDealRecordDataModelListWithBuy.Count >= 2)
			{
				this.CoinDealRecordDataModelListWithBuy.Sort((CoinDealRecordDataModel x, CoinDealRecordDataModel y) => -x.TradeTimeStamp.CompareTo(y.TradeTimeStamp));
			}
			if (this.CoinDealRecordDataModelListWithSell != null && this.CoinDealRecordDataModelListWithSell.Count >= 2)
			{
				this.CoinDealRecordDataModelListWithSell.Sort((CoinDealRecordDataModel x, CoinDealRecordDataModel y) => -x.TradeTimeStamp.CompareTo(y.TradeTimeStamp));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRecordMessageRes, null, null, null, null);
		}

		// Token: 0x0600B236 RID: 45622 RVA: 0x0027829C File Offset: 0x0027669C
		private void OnReceiveSceneGoldConsignmentDealNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneGoldConsignmentDealNotify stream = new SceneGoldConsignmentDealNotify();
			stream.decode(msgData.bytes);
			this.IsCoinDealRequestTradeItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestTradeItemData, null, null, null, null);
			this.IsCoinDealRequestMyOrderItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestMyOrderItemData, null, null, null, null);
			this.IsCoinDealRequestRecordItemData = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestRecordItemData, null, null, null, null);
			if (!this.IsCoinDealShowRecordTab)
			{
				this.IsCoinDealShowRedPoint = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, null, null, null, null);
			}
		}

		// Token: 0x0600B237 RID: 45623 RVA: 0x00278338 File Offset: 0x00276738
		public void OnSendSceneCreditPointRecordReq()
		{
			SceneCreditPointRecordReq cmd = new SceneCreditPointRecordReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneCreditPointRecordReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B238 RID: 45624 RVA: 0x00278368 File Offset: 0x00276768
		private void OnReceiveSceneCreditPointRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneCreditPointRecordRes sceneCreditPointRecordRes = new SceneCreditPointRecordRes();
			sceneCreditPointRecordRes.decode(msgData.bytes);
			this.ResetCoinDealRecordDetailDataModelList();
			CreditPointRecord[] recordList = sceneCreditPointRecordRes.recordList;
			if (recordList != null && recordList.Length > 0)
			{
				foreach (CreditPointRecord creditPointRecord in recordList)
				{
					if (creditPointRecord != null)
					{
						CoinDealRecordDetailDataModel item = CoinDealUtility.CreateRecordDetailDataModelByRecord(creditPointRecord);
						this.CoinDealRecordDetailDataModelList.Add(item);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealCreditPointRecordDetailMessage, null, null, null, null);
		}

		// Token: 0x0600B239 RID: 45625 RVA: 0x002783F5 File Offset: 0x002767F5
		private void OnServerFuncSwitch(ServerSceneFuncSwitch funcSwitch)
		{
			if (funcSwitch.sType != ServiceType.SERVICE_GOLD_CONSIGNMENT)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealServerFuncSwitchChangeMessage, null, null, null, null);
		}

		// Token: 0x0600B23A RID: 45626 RVA: 0x0027841C File Offset: 0x0027681C
		public void ResetCoinDealDataModel()
		{
			this.CloseMarketStartTime = 0;
			this.CloseMarketEndTime = 0;
			this.CloseMarketStartTimeStamp = 0;
			this.CloseMarketEndTimeStamp = 0;
			this._coinDealMinDealPriceValue = 0;
			this._coinDealMaxDealPriceValue = 0;
			this.CoinDealAveragePriceValue = 0;
			this.CoinDealAveragePriceValueInToday = 0;
			this.CoinDealAveragePriceValueInRecently = 0;
			this.ResetCoinDealOrderGradeDataModelList();
			this.ResetCoinDealMyOrderDataModelList();
			this.ResetCoinDealRecordDataModelList();
			this.ResetCoinDealSubmitOrderDataModelWithBuy();
			this.ResetCoinDealSubmitOrderDataModelWithSell();
			this.IsCoinDealRequestTradeItemData = false;
			this.IsCoinDealRequestMyOrderItemData = false;
			this.IsCoinDealRequestRecordItemData = false;
			this.IsCoinDealShowRecordTab = false;
			this.ResetCoinDealRecordDetailDataModelList();
			this.IsAlreadyDealMyOrderPriceInValidFlag = false;
		}

		// Token: 0x0600B23B RID: 45627 RVA: 0x002784AF File Offset: 0x002768AF
		public void ResetCoinDealSubmitOrderDataModelWithBuy()
		{
			this.CoinDealSubmitOrderDataModelWithBuy = null;
		}

		// Token: 0x0600B23C RID: 45628 RVA: 0x002784B8 File Offset: 0x002768B8
		public void ResetCoinDealSubmitOrderDataModelWithSell()
		{
			this.CoinDealSubmitOrderDataModelWithSell = null;
		}

		// Token: 0x0600B23D RID: 45629 RVA: 0x002784C1 File Offset: 0x002768C1
		public void ResetCoinDealOrderGradeDataModelList()
		{
			this.CoinDealTradeDataModelListWithBuy.Clear();
			this.CoinDealTradeDataModelListWithSell.Clear();
		}

		// Token: 0x0600B23E RID: 45630 RVA: 0x002784D9 File Offset: 0x002768D9
		private void ResetCoinDealRecordDataModelList()
		{
			this.CoinDealRecordDataModelListWithBuy.Clear();
			this.CoinDealRecordDataModelListWithSell.Clear();
		}

		// Token: 0x0600B23F RID: 45631 RVA: 0x002784F1 File Offset: 0x002768F1
		private void ResetCoinDealMyOrderDataModelList()
		{
			this.CoinDealOwnerOrderNumberWithBuy = 0;
			this.CoinDealMyOrderDataModelListWithBuy.Clear();
			this.CoinDealOwnerOrderNumberWithSell = 0;
			this.CoinDealMyOrderDataModelListWithSell.Clear();
		}

		// Token: 0x0600B240 RID: 45632 RVA: 0x00278518 File Offset: 0x00276918
		public void ResetCoinDealRecordDetailDataModelList()
		{
			if (this.CoinDealRecordDetailDataModelList == null || this.CoinDealRecordDetailDataModelList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.CoinDealRecordDetailDataModelList.Count; i++)
			{
				CoinDealRecordDetailDataModel coinDealRecordDetailDataModel = this.CoinDealRecordDetailDataModelList[i];
				if (coinDealRecordDetailDataModel != null)
				{
					if (coinDealRecordDetailDataModel.ChildRecordDetailDataModelList != null)
					{
						coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Clear();
					}
				}
			}
			this.CoinDealRecordDetailDataModelList.Clear();
		}

		// Token: 0x0600B241 RID: 45633 RVA: 0x00278598 File Offset: 0x00276998
		public int GetCoinDealOriginalDealBuyPrice()
		{
			if (this.CoinDealTradeDataModelListWithSell != null && this.CoinDealTradeDataModelListWithSell.Count > 0)
			{
				for (int i = 0; i < this.CoinDealTradeDataModelListWithSell.Count; i++)
				{
					CoinDealTradeDataModel coinDealTradeDataModel = this.CoinDealTradeDataModelListWithSell[i];
					if (coinDealTradeDataModel != null)
					{
						bool flag = CoinDealUtility.IsPriceInSinglePriceInterval((int)coinDealTradeDataModel.SinglePrice);
						if (flag)
						{
							return (int)coinDealTradeDataModel.SinglePrice;
						}
					}
				}
			}
			return this.CoinDealAveragePriceValueInToday;
		}

		// Token: 0x0600B242 RID: 45634 RVA: 0x00278614 File Offset: 0x00276A14
		public int GetCoinDealOriginalDealSellPrice()
		{
			if (this.CoinDealTradeDataModelListWithBuy != null && this.CoinDealTradeDataModelListWithBuy.Count > 0)
			{
				for (int i = 0; i < this.CoinDealTradeDataModelListWithBuy.Count; i++)
				{
					CoinDealTradeDataModel coinDealTradeDataModel = this.CoinDealTradeDataModelListWithBuy[i];
					if (coinDealTradeDataModel != null)
					{
						bool flag = CoinDealUtility.IsPriceInSinglePriceInterval((int)coinDealTradeDataModel.SinglePrice);
						if (flag)
						{
							return (int)coinDealTradeDataModel.SinglePrice;
						}
					}
				}
			}
			return this.CoinDealAveragePriceValueInToday;
		}

		// Token: 0x0600B243 RID: 45635 RVA: 0x00278690 File Offset: 0x00276A90
		public int GetCoinDealMinDealPriceValue()
		{
			if (this._coinDealMinDealPriceValue <= 0)
			{
				return this.GetCoinDealMinProtectedPrice();
			}
			return this._coinDealMinDealPriceValue;
		}

		// Token: 0x0600B244 RID: 45636 RVA: 0x002786AB File Offset: 0x00276AAB
		public int GetCoinDealMaxDealPriceValue()
		{
			if (this._coinDealMaxDealPriceValue <= 0)
			{
				return this.GetCoinDealMaxProtectedPrice();
			}
			return this._coinDealMaxDealPriceValue;
		}

		// Token: 0x0600B245 RID: 45637 RVA: 0x002786C8 File Offset: 0x00276AC8
		private void UpdateCoinDealMinAndMaxDealPriceValue()
		{
			int coinDealSinglePriceChangeRate = this.GetCoinDealSinglePriceChangeRate();
			float num = (float)coinDealSinglePriceChangeRate / 1000f;
			float num2 = (float)this.CoinDealAveragePriceValue * (1f - num);
			int num3 = (int)num2;
			int coinDealMinProtectedPrice = this.GetCoinDealMinProtectedPrice();
			if (num3 < coinDealMinProtectedPrice)
			{
				num3 = coinDealMinProtectedPrice;
			}
			this._coinDealMinDealPriceValue = num3;
			float num4 = (float)this.CoinDealAveragePriceValue * (1f + num);
			int num5 = (int)num4;
			int coinDealMaxProtectedPrice = this.GetCoinDealMaxProtectedPrice();
			if (num5 == 0 || num5 > coinDealMaxProtectedPrice)
			{
				num5 = coinDealMaxProtectedPrice;
			}
			this._coinDealMaxDealPriceValue = num5;
		}

		// Token: 0x0600B246 RID: 45638 RVA: 0x0027874C File Offset: 0x00276B4C
		public int GetCreditTicketMaxNumberInMonth()
		{
			this.SetCreditTicketMaxNumber();
			return this._creditTicketMaxNumberInMonth;
		}

		// Token: 0x0600B247 RID: 45639 RVA: 0x0027875A File Offset: 0x00276B5A
		public int GetCreditTicketMaxNumberInSelfPlayer()
		{
			this.SetCreditTicketMaxNumber();
			return this._creditTicketMaxNumberInSelfPlayer;
		}

		// Token: 0x0600B248 RID: 45640 RVA: 0x00278768 File Offset: 0x00276B68
		private void SetCreditTicketMaxNumber()
		{
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel <= this._vipLevelByCache && (int)DataManager<PlayerBaseData>.GetInstance().Level <= this._maxLevelInAccountByCache)
			{
				return;
			}
			this._vipLevelByCache = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			this._maxLevelInAccountByCache = PlayerUtility.GetMaxLevelInAccount();
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(this._maxLevelInAccountByCache, string.Empty, string.Empty);
			int vipPrivilegeValue = PlayerUtility.GetVipPrivilegeValue(VipPrivilegeTable.eType.CREDIT_POINT_MONTH_GET_NUM);
			int num = 0;
			if (tableItem != null)
			{
				num = tableItem.CreditPointMonthGetNum;
			}
			this._creditTicketMaxNumberInMonth = ((vipPrivilegeValue <= num) ? num : vipPrivilegeValue);
			int vipPrivilegeValue2 = PlayerUtility.GetVipPrivilegeValue(VipPrivilegeTable.eType.CREDIT_POINT_OWN_NUM);
			int num2 = 0;
			if (tableItem != null)
			{
				num2 = tableItem.CreditPointOwnNum;
			}
			this._creditTicketMaxNumberInSelfPlayer = ((vipPrivilegeValue2 <= num2) ? num2 : vipPrivilegeValue2);
		}

		// Token: 0x0600B249 RID: 45641 RVA: 0x00278830 File Offset: 0x00276C30
		public int GetCreditTicketMaxNumberInMonthTransfer()
		{
			int vipPrivilegeValue = PlayerUtility.GetVipPrivilegeValue(VipPrivilegeTable.eType.CREDIT_POINT_MONTH_CONVERSION_NUM);
			int num = vipPrivilegeValue;
			int maxLevelInAccount = PlayerUtility.GetMaxLevelInAccount();
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(maxLevelInAccount, string.Empty, string.Empty);
			if (tableItem != null && tableItem.CreditPointMonthConversionNum > num)
			{
				num = tableItem.CreditPointMonthConversionNum;
			}
			return num;
		}

		// Token: 0x0600B24A RID: 45642 RVA: 0x00278880 File Offset: 0x00276C80
		public int GetCoinDealFeeRate()
		{
			if (this._coinDealFeeRate > 0)
			{
				return this._coinDealFeeRate;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(11, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealFeeRate = tableItem.Value;
			}
			if (this._coinDealFeeRate <= 0)
			{
				this._coinDealFeeRate = 50;
			}
			return this._coinDealFeeRate;
		}

		// Token: 0x0600B24B RID: 45643 RVA: 0x002788E4 File Offset: 0x00276CE4
		public int GetCoinDealCreditTicketExchangeRate()
		{
			if (this._coinDealCreditTicketExchangeRate > 0)
			{
				return this._coinDealCreditTicketExchangeRate;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(12, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealCreditTicketExchangeRate = tableItem.Value;
			}
			if (this._coinDealCreditTicketExchangeRate <= 0)
			{
				this._coinDealCreditTicketExchangeRate = 1;
			}
			return this._coinDealCreditTicketExchangeRate;
		}

		// Token: 0x0600B24C RID: 45644 RVA: 0x00278948 File Offset: 0x00276D48
		public int GetCoinDealCreditTicketExchangeDayNumber()
		{
			if (this._coinDealCreditTicketExchangeDayNumber > 0)
			{
				return this._coinDealCreditTicketExchangeDayNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(13, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealCreditTicketExchangeDayNumber = tableItem.Value;
			}
			if (this._coinDealCreditTicketExchangeDayNumber <= 0)
			{
				this._coinDealCreditTicketExchangeDayNumber = 30;
			}
			return this._coinDealCreditTicketExchangeDayNumber;
		}

		// Token: 0x0600B24D RID: 45645 RVA: 0x002789AC File Offset: 0x00276DAC
		private int GetCoinDealMinProtectedPrice()
		{
			if (this._coinDealMinProtectedPrice > 0)
			{
				return this._coinDealMinProtectedPrice;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(14, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealMinProtectedPrice = tableItem.Value;
			}
			if (this._coinDealMinProtectedPrice <= 0)
			{
				this._coinDealMinProtectedPrice = 250;
			}
			return this._coinDealMinProtectedPrice;
		}

		// Token: 0x0600B24E RID: 45646 RVA: 0x00278A14 File Offset: 0x00276E14
		private int GetCoinDealMaxProtectedPrice()
		{
			if (this._coinDealMaxProtectedPrice > 0)
			{
				return this._coinDealMaxProtectedPrice;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(15, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealMaxProtectedPrice = tableItem.Value;
			}
			if (this._coinDealMaxProtectedPrice <= 0)
			{
				this._coinDealMaxProtectedPrice = 2000;
			}
			return this._coinDealMaxProtectedPrice;
		}

		// Token: 0x0600B24F RID: 45647 RVA: 0x00278A7C File Offset: 0x00276E7C
		public int GetCoinDealSinglePriceChangeRate()
		{
			if (this._coinDealSinglePriceChangeRate > 0)
			{
				return this._coinDealSinglePriceChangeRate;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(16, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealSinglePriceChangeRate = tableItem.Value;
			}
			if (this._coinDealSinglePriceChangeRate <= 0)
			{
				this._coinDealSinglePriceChangeRate = 100;
			}
			return this._coinDealSinglePriceChangeRate;
		}

		// Token: 0x0600B250 RID: 45648 RVA: 0x00278AE0 File Offset: 0x00276EE0
		public int GetCoinDealHangListLastTime()
		{
			if (this._coinDealHangListLastTime > 0)
			{
				return this._coinDealHangListLastTime;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(8, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealHangListLastTime = tableItem.Value;
			}
			return this._coinDealHangListLastTime;
		}

		// Token: 0x0600B251 RID: 45649 RVA: 0x00278B30 File Offset: 0x00276F30
		public int GetCoinDealBaseTradeCoinNumber()
		{
			if (this._coinDealBaseTradeCoinNumber > 0)
			{
				return this._coinDealBaseTradeCoinNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(9, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealBaseTradeCoinNumber = tableItem.Value;
			}
			if (this._coinDealBaseTradeCoinNumber <= 0)
			{
				this._coinDealBaseTradeCoinNumber = 100000;
			}
			return this._coinDealBaseTradeCoinNumber;
		}

		// Token: 0x0600B252 RID: 45650 RVA: 0x00278B98 File Offset: 0x00276F98
		public int GetCoinDealMinCoinDealNumber()
		{
			if (this._coinDealMinCoinDealNumber > 0)
			{
				return this._coinDealMinCoinDealNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(9, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealMinCoinDealNumber = tableItem.Value;
			}
			if (this._coinDealMinCoinDealNumber <= 0)
			{
				this._coinDealMinCoinDealNumber = 100000;
			}
			return this._coinDealMinCoinDealNumber;
		}

		// Token: 0x0600B253 RID: 45651 RVA: 0x00278C00 File Offset: 0x00277000
		public int GetCoinDealMaxCoinDealNumber()
		{
			if (this._coinDealMaxCoinDealNumber > 0)
			{
				return this._coinDealMaxCoinDealNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(10, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealMaxCoinDealNumber = tableItem.Value;
			}
			if (this._coinDealMaxCoinDealNumber <= 0)
			{
				this._coinDealMaxCoinDealNumber = 100000000;
			}
			return this._coinDealMaxCoinDealNumber;
		}

		// Token: 0x0600B254 RID: 45652 RVA: 0x00278C68 File Offset: 0x00277068
		public int GetCoinDealSubmitOrderMaxNumber()
		{
			if (this._coinDealSubmitOrderMaxNumber > 0)
			{
				return this._coinDealSubmitOrderMaxNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(4, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealSubmitOrderMaxNumber = tableItem.Value;
			}
			if (this._coinDealSubmitOrderMaxNumber <= 0)
			{
				this._coinDealSubmitOrderMaxNumber = 10;
			}
			return this._coinDealSubmitOrderMaxNumber;
		}

		// Token: 0x0600B255 RID: 45653 RVA: 0x00278CCC File Offset: 0x002770CC
		public int GetCoinDealBaseSinglePriceByCoinNumber()
		{
			if (this._coinDealBaseSinglePriceByCoinNumber > 0)
			{
				return this._coinDealBaseSinglePriceByCoinNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(6, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealBaseSinglePriceByCoinNumber = tableItem.Value;
			}
			if (this._coinDealBaseSinglePriceByCoinNumber <= 0)
			{
				this._coinDealBaseSinglePriceByCoinNumber = 100;
			}
			return this._coinDealBaseSinglePriceByCoinNumber;
		}

		// Token: 0x0600B256 RID: 45654 RVA: 0x00278D30 File Offset: 0x00277130
		public ulong GetCoinDealCoinMaxShowNumber()
		{
			if (this._coinDealCoinNumberMaxShowNumber > 0UL)
			{
				return this._coinDealCoinNumberMaxShowNumber;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(17, string.Empty, string.Empty);
			ulong num = 1UL;
			if (tableItem != null)
			{
				num = (ulong)((long)tableItem.Value);
			}
			this._coinDealCoinNumberMaxShowNumber = num * 100000000UL;
			return this._coinDealCoinNumberMaxShowNumber;
		}

		// Token: 0x0600B257 RID: 45655 RVA: 0x00278D90 File Offset: 0x00277190
		public int GetCoinDealOrderPageRefreshTime()
		{
			if (this._coinDealOrderPageRefreshTime > 0)
			{
				return this._coinDealOrderPageRefreshTime;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(19, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealOrderPageRefreshTime = tableItem.Value;
			}
			if (this._coinDealOrderPageRefreshTime <= 0)
			{
				this._coinDealOrderPageRefreshTime = 5;
			}
			return this._coinDealOrderPageRefreshTime;
		}

		// Token: 0x0600B258 RID: 45656 RVA: 0x00278DF4 File Offset: 0x002771F4
		public int GetCoinDealBaseNumberOfSinglePrice()
		{
			if (this._coinDealBaseNumberOfSinglePrice > 0)
			{
				return this._coinDealBaseNumberOfSinglePrice;
			}
			GoldConsignmentValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GoldConsignmentValueTable>(22, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._coinDealBaseNumberOfSinglePrice = tableItem.Value;
			}
			if (this._coinDealBaseNumberOfSinglePrice <= 0)
			{
				this._coinDealBaseNumberOfSinglePrice = 1000000;
			}
			return this._coinDealBaseNumberOfSinglePrice;
		}

		// Token: 0x0600B259 RID: 45657 RVA: 0x00278E5A File Offset: 0x0027725A
		public ItemTable GetCreditTicketItemTable()
		{
			if (this._creditTicketItemTable != null)
			{
				return this._creditTicketItemTable;
			}
			this._creditTicketItemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(600002551, string.Empty, string.Empty);
			return this._creditTicketItemTable;
		}

		// Token: 0x0600B25A RID: 45658 RVA: 0x00278E94 File Offset: 0x00277294
		public float GetCoinDealBaseTradeRate()
		{
			if (this._coinDealBaseTradeRate > 0f)
			{
				return this._coinDealBaseTradeRate;
			}
			int coinDealBaseNumberOfSinglePrice = this.GetCoinDealBaseNumberOfSinglePrice();
			int coinDealBaseTradeCoinNumber = this.GetCoinDealBaseTradeCoinNumber();
			if (coinDealBaseTradeCoinNumber <= 0)
			{
				this._coinDealBaseTradeRate = 1f;
			}
			else
			{
				this._coinDealBaseTradeRate = (float)coinDealBaseNumberOfSinglePrice / (float)coinDealBaseTradeCoinNumber;
			}
			if (this._coinDealBaseTradeRate <= 0f)
			{
				this._coinDealBaseTradeRate = 1f;
			}
			return this._coinDealBaseTradeRate;
		}

		// Token: 0x0600B25B RID: 45659 RVA: 0x00278F09 File Offset: 0x00277309
		public void ResetCoinDealOrderPageRefreshTimeInterval()
		{
			this._coinDealOrderPageRefreshTimeInterval = -1f;
		}

		// Token: 0x0600B25C RID: 45660 RVA: 0x00278F16 File Offset: 0x00277316
		public void SetCoinDealOrderPageRefreshTimeInterval()
		{
			this._coinDealOrderPageRefreshTimeInterval = (float)this.GetCoinDealOrderPageRefreshTime();
		}

		// Token: 0x0600B25D RID: 45661 RVA: 0x00278F28 File Offset: 0x00277328
		public override void Update(float time)
		{
			if (this._coinDealOrderPageRefreshTimeInterval < 0f)
			{
				return;
			}
			this._coinDealOrderPageRefreshTimeInterval -= time;
			if (this._coinDealOrderPageRefreshTimeInterval < 0f)
			{
				if (!CoinDealUtility.IsCoinDealFrameOpen())
				{
					this.ResetCoinDealOrderPageRefreshTimeInterval();
				}
				else
				{
					this.IsCoinDealRequestTradeItemData = true;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestTradeItemData, null, null, null, null);
				}
			}
		}

		// Token: 0x040063E3 RID: 25571
		public const string CoinDealActivityName = "GoldConsignment";

		// Token: 0x040063E4 RID: 25572
		public const int SecondNumberInHour = 3600;

		// Token: 0x040063E5 RID: 25573
		public const VipPrivilegeTable.eType CreditTicketLimitInMonthGet = VipPrivilegeTable.eType.CREDIT_POINT_MONTH_GET_NUM;

		// Token: 0x040063E6 RID: 25574
		public const VipPrivilegeTable.eType CreditTicketLimitInSelfType = VipPrivilegeTable.eType.CREDIT_POINT_OWN_NUM;

		// Token: 0x040063E7 RID: 25575
		public const VipPrivilegeTable.eType CreditTicketLimitInMonthTransfer = VipPrivilegeTable.eType.CREDIT_POINT_MONTH_CONVERSION_NUM;

		// Token: 0x040063E8 RID: 25576
		public const ulong CoinDealBaseNumberWithHundredMillion = 100000000UL;

		// Token: 0x040063E9 RID: 25577
		public const int CreditTicketItemId = 600002551;

		// Token: 0x040063EA RID: 25578
		private const int CoinDealSubmitOrderMaxNumberId = 4;

		// Token: 0x040063EB RID: 25579
		private const int CoinDealBaseSinglePriceByCoinNumberId = 6;

		// Token: 0x040063EC RID: 25580
		private const int CoinDealHangListLastTimeId = 8;

		// Token: 0x040063ED RID: 25581
		private const int CoinDealBaseTradeCoinNumberId = 9;

		// Token: 0x040063EE RID: 25582
		private const int CoinDealMinCoinDealNumberId = 9;

		// Token: 0x040063EF RID: 25583
		private const int CoinDealMaxCoinDealNumberId = 10;

		// Token: 0x040063F0 RID: 25584
		private const int CoinDealFeeRateId = 11;

		// Token: 0x040063F1 RID: 25585
		private const int CoinDealCreditTicketExchangeRateId = 12;

		// Token: 0x040063F2 RID: 25586
		private const int CoinDealCreditTicketExchangeDayNumberId = 13;

		// Token: 0x040063F3 RID: 25587
		private const int CoinDealMinProtectPriceId = 14;

		// Token: 0x040063F4 RID: 25588
		private const int CoinDealMaxProtectPriceId = 15;

		// Token: 0x040063F5 RID: 25589
		private const int CoinDealSinglePriceChangeRateId = 16;

		// Token: 0x040063F6 RID: 25590
		private const int CoinDealCoinNumberMaxShowNumberId = 17;

		// Token: 0x040063F7 RID: 25591
		private const int CoinDealOrderPageRefreshTimeId = 19;

		// Token: 0x040063F8 RID: 25592
		private const int CoinDealBaseNumberOfSinglePriceId = 22;

		// Token: 0x040063F9 RID: 25593
		private float _coinDealBaseTradeRate;

		// Token: 0x040063FA RID: 25594
		private ItemTable _creditTicketItemTable;

		// Token: 0x040063FB RID: 25595
		private int _coinDealSubmitOrderMaxNumber;

		// Token: 0x040063FC RID: 25596
		private int _coinDealBaseSinglePriceByCoinNumber;

		// Token: 0x040063FD RID: 25597
		private int _coinDealHangListLastTime;

		// Token: 0x040063FE RID: 25598
		private int _coinDealBaseTradeCoinNumber;

		// Token: 0x040063FF RID: 25599
		private int _coinDealMinCoinDealNumber;

		// Token: 0x04006400 RID: 25600
		private int _coinDealMaxCoinDealNumber;

		// Token: 0x04006401 RID: 25601
		private int _coinDealFeeRate;

		// Token: 0x04006402 RID: 25602
		private int _coinDealCreditTicketExchangeRate;

		// Token: 0x04006403 RID: 25603
		private int _coinDealCreditTicketExchangeDayNumber;

		// Token: 0x04006404 RID: 25604
		private int _coinDealMinProtectedPrice;

		// Token: 0x04006405 RID: 25605
		private int _coinDealMaxProtectedPrice;

		// Token: 0x04006406 RID: 25606
		private int _coinDealSinglePriceChangeRate;

		// Token: 0x04006407 RID: 25607
		private int _coinDealOrderPageRefreshTime;

		// Token: 0x04006408 RID: 25608
		private ulong _coinDealCoinNumberMaxShowNumber;

		// Token: 0x04006409 RID: 25609
		private int _coinDealBaseNumberOfSinglePrice;

		// Token: 0x0400640A RID: 25610
		public bool IsAlreadyDealMyOrderPriceInValidFlag;

		// Token: 0x0400640B RID: 25611
		public int CoinDealMinCoinNumberWithBase;

		// Token: 0x0400640C RID: 25612
		public int CoinDealMaxCoinNumberWithBase;

		// Token: 0x0400640D RID: 25613
		public int CreditTicketGetNumberInTrade;

		// Token: 0x0400640E RID: 25614
		private int _maxLevelInAccountByCache = -1;

		// Token: 0x0400640F RID: 25615
		private int _vipLevelByCache = -1;

		// Token: 0x04006410 RID: 25616
		private int _creditTicketMaxNumberInMonth;

		// Token: 0x04006411 RID: 25617
		private int _creditTicketMaxNumberInSelfPlayer;

		// Token: 0x04006412 RID: 25618
		private int _coinDealMinDealPriceValue;

		// Token: 0x04006413 RID: 25619
		private int _coinDealMaxDealPriceValue;

		// Token: 0x04006414 RID: 25620
		public int CloseMarketStartTime;

		// Token: 0x04006415 RID: 25621
		public int CloseMarketEndTime;

		// Token: 0x04006416 RID: 25622
		public int CloseMarketStartTimeStamp;

		// Token: 0x04006417 RID: 25623
		public int CloseMarketEndTimeStamp;

		// Token: 0x04006418 RID: 25624
		public int CoinDealAveragePriceValue;

		// Token: 0x04006419 RID: 25625
		public int CoinDealAveragePriceValueInToday;

		// Token: 0x0400641A RID: 25626
		public int CoinDealAveragePriceValueInRecently;

		// Token: 0x0400641B RID: 25627
		public int CoinDealOwnerOrderNumberWithBuy;

		// Token: 0x0400641C RID: 25628
		public int CoinDealOwnerOrderNumberWithSell;

		// Token: 0x0400641D RID: 25629
		public bool IsCoinDealBuyOrderJustOnce;

		// Token: 0x0400641E RID: 25630
		public bool IsNotShowSubmitBuyOrderTipJustOnce;

		// Token: 0x0400641F RID: 25631
		public bool IsNotShowSubmitBuyOrderTipWithMore;

		// Token: 0x04006420 RID: 25632
		public bool IsNotShowSubmitSellOrderTip;

		// Token: 0x04006421 RID: 25633
		public List<CoinDealTradeDataModel> CoinDealTradeDataModelListWithSell = new List<CoinDealTradeDataModel>();

		// Token: 0x04006422 RID: 25634
		public List<CoinDealTradeDataModel> CoinDealTradeDataModelListWithBuy = new List<CoinDealTradeDataModel>();

		// Token: 0x04006423 RID: 25635
		public bool IsCoinDealRequestTradeItemData;

		// Token: 0x04006424 RID: 25636
		public bool IsCoinDealRequestMyOrderItemData;

		// Token: 0x04006425 RID: 25637
		public bool IsCoinDealRequestRecordItemData;

		// Token: 0x04006426 RID: 25638
		public bool IsNotShowBuyOrderCancelTip;

		// Token: 0x04006427 RID: 25639
		public bool IsNotShowSellOrderCancelTip;

		// Token: 0x04006428 RID: 25640
		public List<CoinDealMyOrderDataModel> CoinDealMyOrderDataModelListWithBuy = new List<CoinDealMyOrderDataModel>();

		// Token: 0x04006429 RID: 25641
		public List<CoinDealMyOrderDataModel> CoinDealMyOrderDataModelListWithSell = new List<CoinDealMyOrderDataModel>();

		// Token: 0x0400642A RID: 25642
		public bool IsCoinDealShowRedPoint;

		// Token: 0x0400642B RID: 25643
		public bool IsCoinDealShowRecordTab;

		// Token: 0x0400642C RID: 25644
		public List<CoinDealRecordDataModel> CoinDealRecordDataModelListWithSell = new List<CoinDealRecordDataModel>();

		// Token: 0x0400642D RID: 25645
		public List<CoinDealRecordDataModel> CoinDealRecordDataModelListWithBuy = new List<CoinDealRecordDataModel>();

		// Token: 0x0400642E RID: 25646
		public CoinDealSubmitOrderDataModel CoinDealSubmitOrderDataModelWithSell;

		// Token: 0x0400642F RID: 25647
		public CoinDealSubmitOrderDataModel CoinDealSubmitOrderDataModelWithBuy;

		// Token: 0x04006430 RID: 25648
		public List<CoinDealRecordDetailDataModel> CoinDealRecordDetailDataModelList = new List<CoinDealRecordDetailDataModel>();

		// Token: 0x04006431 RID: 25649
		private float _coinDealOrderPageRefreshTimeInterval = -1f;
	}
}

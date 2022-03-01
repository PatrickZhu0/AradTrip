using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;

namespace GameClient
{
	// Token: 0x02001226 RID: 4646
	public static class CoinDealUtility
	{
		// Token: 0x0600B26D RID: 45677 RVA: 0x002790AB File Offset: 0x002774AB
		public static void OnCloseCoinDealFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CoinDealFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CoinDealFrame>(null, false);
			}
		}

		// Token: 0x0600B26E RID: 45678 RVA: 0x002790C9 File Offset: 0x002774C9
		public static void OnOpenCoinDealFrame()
		{
			CoinDealUtility.OnCloseCoinDealFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CoinDealFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B26F RID: 45679 RVA: 0x002790E2 File Offset: 0x002774E2
		public static bool IsCoinDealFrameOpen()
		{
			return Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CoinDealFrame>(null);
		}

		// Token: 0x0600B270 RID: 45680 RVA: 0x002790F7 File Offset: 0x002774F7
		public static void OnCloseCoinDealSellRecordFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CoinDealSellRecordFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CoinDealSellRecordFrame>(null, false);
			}
		}

		// Token: 0x0600B271 RID: 45681 RVA: 0x00279115 File Offset: 0x00277515
		public static void OnOpenCoinDealSellRecordFrame()
		{
			CoinDealUtility.OnCloseCoinDealSellRecordFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CoinDealSellRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B272 RID: 45682 RVA: 0x0027912E File Offset: 0x0027752E
		public static void OnCloseCoinDealBuyRecordFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CoinDealBuyRecordFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CoinDealBuyRecordFrame>(null, false);
			}
		}

		// Token: 0x0600B273 RID: 45683 RVA: 0x0027914C File Offset: 0x0027754C
		public static void OnOpenCoinDealBuyRecordFrame()
		{
			CoinDealUtility.OnCloseCoinDealBuyRecordFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CoinDealBuyRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B274 RID: 45684 RVA: 0x00279165 File Offset: 0x00277565
		public static void OnCloseCoinDealRecordDetailFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CoinDealRecordDetailFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CoinDealRecordDetailFrame>(null, false);
			}
		}

		// Token: 0x0600B275 RID: 45685 RVA: 0x00279183 File Offset: 0x00277583
		public static void OnOpenCoinDealRecordDetailFrame()
		{
			CoinDealUtility.OnCloseCoinDealRecordDetailFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CoinDealRecordDetailFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B276 RID: 45686 RVA: 0x0027919C File Offset: 0x0027759C
		public static void OnOpenSubmitOrderTipFrame(string contentStr, OnCommonMsgBoxToggleClick onToggleClick, Action onRightButtonAction)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = onToggleClick,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onRightButtonAction,
				IsSetContentFontSize = true,
				ContentFontSize = 36
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B277 RID: 45687 RVA: 0x00279204 File Offset: 0x00277604
		public static void OnOpenSellOrderCreditTicketExceedTipFrame(string contentStr, Action onMiddleAction, string middleButtonText)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = false,
				IsMiddleButton = true,
				MiddleButtonText = middleButtonText,
				OnMiddleButtonClickCallBack = onMiddleAction,
				IsSetContentFontSize = true,
				ContentFontSize = 32
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B278 RID: 45688 RVA: 0x00279251 File Offset: 0x00277651
		public static void OnCloseCoinDealRelationFrameBySwitchClose()
		{
			CoinDealUtility.OnCloseCoinDealFrame();
			CoinDealUtility.OnCloseCoinDealSellRecordFrame();
			CoinDealUtility.OnCloseCoinDealBuyRecordFrame();
			CoinDealUtility.OnCloseCoinDealRecordDetailFrame();
		}

		// Token: 0x0600B279 RID: 45689 RVA: 0x00279268 File Offset: 0x00277668
		public static void OnOpenCoinDealSwitchToMyOrderTabTipFrame()
		{
			string contentLabel = TR.Value("Coin_Deal_Owner_Order_Price_Invalid_Content_Format", DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMinDealPriceValue(), DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMaxDealPriceValue());
			CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData = new CommonMsgBoxOkCancelNewParamData();
			commonMsgBoxOkCancelNewParamData.ContentLabel = contentLabel;
			commonMsgBoxOkCancelNewParamData.IsShowNotify = false;
			commonMsgBoxOkCancelNewParamData.LeftButtonText = TR.Value("common_data_cancel");
			commonMsgBoxOkCancelNewParamData.RightButtonText = TR.Value("Coin_Deal_Owner_Order_Price_Invalid_Forward_Format");
			CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData2 = commonMsgBoxOkCancelNewParamData;
			if (CoinDealUtility.<>f__mg$cache0 == null)
			{
				CoinDealUtility.<>f__mg$cache0 = new Action(CoinDealUtility.OnForwardSwitchMyOrderTab);
			}
			commonMsgBoxOkCancelNewParamData2.OnRightButtonClickCallBack = CoinDealUtility.<>f__mg$cache0;
			CommonMsgBoxOkCancelNewParamData paramData = commonMsgBoxOkCancelNewParamData;
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B27A RID: 45690 RVA: 0x002792FD File Offset: 0x002776FD
		private static void OnForwardSwitchMyOrderTab()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealSwitchToMyOrderTabMessage, null, null, null, null);
		}

		// Token: 0x0600B27B RID: 45691 RVA: 0x00279314 File Offset: 0x00277714
		public static void OnOpenCancelMyOrderTipFrame(CoinDealMyOrderDataModel myOrderDataModel, string contentStr)
		{
			if (myOrderDataModel == null)
			{
				return;
			}
			CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = true,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = delegate()
				{
					CoinDealUtility.OnCancelMyOrder(myOrderDataModel);
				}
			};
			if (myOrderDataModel.OrderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData2 = commonMsgBoxOkCancelNewParamData;
				if (CoinDealUtility.<>f__mg$cache1 == null)
				{
					CoinDealUtility.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(CoinDealUtility.OnUpdateCancelBuyOrderTip);
				}
				commonMsgBoxOkCancelNewParamData2.OnCommonMsgBoxToggleClick = CoinDealUtility.<>f__mg$cache1;
			}
			else if (myOrderDataModel.OrderType == GoldConsignmentOrderType.GCOT_SELL)
			{
				CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData3 = commonMsgBoxOkCancelNewParamData;
				if (CoinDealUtility.<>f__mg$cache2 == null)
				{
					CoinDealUtility.<>f__mg$cache2 = new OnCommonMsgBoxToggleClick(CoinDealUtility.OnUpdateCancelSellOrderTip);
				}
				commonMsgBoxOkCancelNewParamData3.OnCommonMsgBoxToggleClick = CoinDealUtility.<>f__mg$cache2;
			}
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(commonMsgBoxOkCancelNewParamData);
		}

		// Token: 0x0600B27C RID: 45692 RVA: 0x002793F5 File Offset: 0x002777F5
		private static void OnUpdateCancelBuyOrderTip(bool value)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsNotShowBuyOrderCancelTip = value;
		}

		// Token: 0x0600B27D RID: 45693 RVA: 0x00279402 File Offset: 0x00277802
		private static void OnUpdateCancelSellOrderTip(bool value)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsNotShowSellOrderCancelTip = value;
		}

		// Token: 0x0600B27E RID: 45694 RVA: 0x0027940F File Offset: 0x0027780F
		private static void OnCancelMyOrder(CoinDealMyOrderDataModel myOrderDataModel)
		{
			if (myOrderDataModel == null)
			{
				return;
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() > myOrderDataModel.ExpireTimeStamp)
			{
				return;
			}
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentCancelOrderReq(myOrderDataModel.OrderId, myOrderDataModel.OrderType);
		}

		// Token: 0x0600B27F RID: 45695 RVA: 0x00279444 File Offset: 0x00277844
		public static string GetCoinDealOpenTimeStr()
		{
			ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().GetActivityInfo("GoldConsignment");
			if (activityInfo == null)
			{
				return string.Empty;
			}
			uint startTime = activityInfo.startTime;
			string timeFormatByYearMonthDayAndHour = TimeUtility.GetTimeFormatByYearMonthDayAndHour(startTime);
			uint timeStamp = activityInfo.dueTime + 1U;
			string timeFormatByYearMonthDayAndHour2 = TimeUtility.GetTimeFormatByYearMonthDayAndHour(timeStamp);
			string originalStr = TR.Value("Coin_Deal_Open_Time_Format", timeFormatByYearMonthDayAndHour, timeFormatByYearMonthDayAndHour2);
			return CommonUtility.GetFinalStringByUpdateChangeLineFlag(originalStr);
		}

		// Token: 0x0600B280 RID: 45696 RVA: 0x002794A8 File Offset: 0x002778A8
		public static int GetCoinDealMinCoinNumberWithBase()
		{
			if (DataManager<CoinDealDataManager>.GetInstance().CoinDealMinCoinNumberWithBase > 0)
			{
				return DataManager<CoinDealDataManager>.GetInstance().CoinDealMinCoinNumberWithBase;
			}
			int coinDealMinCoinDealNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMinCoinDealNumber();
			int num = coinDealMinCoinDealNumber / DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeCoinNumber();
			DataManager<CoinDealDataManager>.GetInstance().CoinDealMinCoinNumberWithBase = num;
			return num;
		}

		// Token: 0x0600B281 RID: 45697 RVA: 0x002794F4 File Offset: 0x002778F4
		public static int GetCoinDealMaxCoinNumberWithBase()
		{
			if (DataManager<CoinDealDataManager>.GetInstance().CoinDealMaxCoinNumberWithBase > 0)
			{
				return DataManager<CoinDealDataManager>.GetInstance().CoinDealMaxCoinNumberWithBase;
			}
			int coinDealMaxCoinDealNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMaxCoinDealNumber();
			int num = coinDealMaxCoinDealNumber / DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeCoinNumber();
			DataManager<CoinDealDataManager>.GetInstance().CoinDealMaxCoinNumberWithBase = num;
			return num;
		}

		// Token: 0x0600B282 RID: 45698 RVA: 0x00279540 File Offset: 0x00277940
		public static int GetCoinDealPlayerCoinNumberWithBuy(int singlePrice)
		{
			if (singlePrice <= 0)
			{
				return 0;
			}
			ulong ticket = DataManager<PlayerBaseData>.GetInstance().Ticket;
			float coinDealBaseTradeRate = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeRate();
			float num = ticket / (float)singlePrice;
			float num2 = num * coinDealBaseTradeRate;
			return (int)num2;
		}

		// Token: 0x0600B283 RID: 45699 RVA: 0x0027957C File Offset: 0x0027797C
		public static int GetCoinDealPlayerCoinNumberWithSell()
		{
			ulong gold = DataManager<PlayerBaseData>.GetInstance().Gold;
			ulong num = gold / (ulong)((long)DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeCoinNumber());
			return (int)num;
		}

		// Token: 0x0600B284 RID: 45700 RVA: 0x002795A4 File Offset: 0x002779A4
		public static ulong GetCoinDealCommonCoinNumber(int baseNumber)
		{
			return (ulong)((long)baseNumber * (long)DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeCoinNumber());
		}

		// Token: 0x0600B285 RID: 45701 RVA: 0x002795C4 File Offset: 0x002779C4
		public static string GetCoinDealCommonCoinNumberStr(int baseNumber)
		{
			ulong coinDealCommonCoinNumber = CoinDealUtility.GetCoinDealCommonCoinNumber(baseNumber);
			return Utility.ToThousandsSeparator(coinDealCommonCoinNumber);
		}

		// Token: 0x0600B286 RID: 45702 RVA: 0x002795E0 File Offset: 0x002779E0
		public static List<ComControlData> GetComControlDataInCoinDeal()
		{
			return new List<ComControlData>
			{
				new ComControlDataWithCoinDeal
				{
					Id = 1,
					Name = TR.Value("Coin_Deal_Tab_Content_Trade_With_Buy"),
					IsSelected = true
				},
				new ComControlDataWithCoinDeal
				{
					Id = 2,
					Name = TR.Value("Coin_Deal_Tab_Content_Trade_With_Sell"),
					IsSelected = false
				},
				new ComControlDataWithCoinDeal
				{
					Id = 3,
					Name = TR.Value("Coin_Deal_Tab_Content_My_Deal"),
					IsSelected = false
				},
				new ComControlDataWithCoinDeal
				{
					Id = 4,
					Name = TR.Value("Coin_Deal_Tab_Content_Deal_Record"),
					IsSelected = false,
					IsShowRedPoint = true
				}
			};
		}

		// Token: 0x0600B287 RID: 45703 RVA: 0x002796B0 File Offset: 0x00277AB0
		public static bool IsInCloseMarketIntervalTime()
		{
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			return (ulong)serverTime >= (ulong)((long)DataManager<CoinDealDataManager>.GetInstance().CloseMarketStartTimeStamp) && (ulong)serverTime < (ulong)((long)DataManager<CoinDealDataManager>.GetInstance().CloseMarketEndTimeStamp);
		}

		// Token: 0x0600B288 RID: 45704 RVA: 0x002796F0 File Offset: 0x00277AF0
		public static bool IsPriceInSinglePriceInterval(int inputSinglePrice)
		{
			int coinDealMinDealPriceValue = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMinDealPriceValue();
			if (inputSinglePrice < coinDealMinDealPriceValue)
			{
				return false;
			}
			int coinDealMaxDealPriceValue = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMaxDealPriceValue();
			return inputSinglePrice <= coinDealMaxDealPriceValue;
		}

		// Token: 0x0600B289 RID: 45705 RVA: 0x00279728 File Offset: 0x00277B28
		public static string GetCoinDealCommonSinglePriceStr()
		{
			int coinDealBaseSinglePriceByCoinNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseSinglePriceByCoinNumber();
			return TR.Value("Coin_Deal_Common_Average_Price_Format", coinDealBaseSinglePriceByCoinNumber);
		}

		// Token: 0x0600B28A RID: 45706 RVA: 0x00279754 File Offset: 0x00277B54
		public static string GetCoinDealBaseTradeCoinNumberStr()
		{
			int coinDealBaseTradeCoinNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeCoinNumber();
			if (coinDealBaseTradeCoinNumber == 1000000)
			{
				return TR.Value("Coin_Deal_Coin_Number_Base_Str_With_Hundred");
			}
			if (coinDealBaseTradeCoinNumber == 100000)
			{
				return TR.Value("Coin_Deal_Coin_Number_Base_Str_With_Ten");
			}
			if (coinDealBaseTradeCoinNumber == 200000)
			{
				return TR.Value("Coin_Deal_Coin_Number_Base_Str_With_Twenty");
			}
			if (coinDealBaseTradeCoinNumber == 500000)
			{
				return TR.Value("Coin_Deal_Coin_Number_Base_Str_With_Fifty");
			}
			return string.Empty;
		}

		// Token: 0x0600B28B RID: 45707 RVA: 0x002797CC File Offset: 0x00277BCC
		public static string GetCoinDealCloseMarketStr()
		{
			int closeMarketStartTime = DataManager<CoinDealDataManager>.GetInstance().CloseMarketStartTime;
			int closeMarketEndTime = DataManager<CoinDealDataManager>.GetInstance().CloseMarketEndTime;
			string arg = string.Empty;
			if (closeMarketStartTime >= 10)
			{
				arg = TR.Value("Coin_Deal_Close_Market_Time_Format_Two", closeMarketStartTime);
			}
			else
			{
				arg = TR.Value("Coin_Deal_Close_Market_Time_Format_One", closeMarketStartTime);
			}
			string arg2 = string.Empty;
			if (closeMarketEndTime >= 10)
			{
				arg2 = TR.Value("Coin_Deal_Close_Market_Time_Format_Two", closeMarketEndTime);
			}
			else
			{
				arg2 = TR.Value("Coin_Deal_Close_Market_Time_Format_One", closeMarketEndTime);
			}
			string result = string.Empty;
			if (closeMarketEndTime >= closeMarketStartTime)
			{
				result = TR.Value("Coin_Deal_Close_Market_In_Same_Day_Format", arg, arg2);
			}
			else
			{
				result = TR.Value("Coin_Deal_Close_Market_In_Different_Day_Format", arg, arg2);
			}
			return result;
		}

		// Token: 0x0600B28C RID: 45708 RVA: 0x0027988C File Offset: 0x00277C8C
		public static string GetFeeRateValueStr()
		{
			int coinDealFeeRate = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealFeeRate();
			int num = coinDealFeeRate / 10;
			return TR.Value("Coin_Deal_Sell_Fee_Rate_Format", num);
		}

		// Token: 0x0600B28D RID: 45709 RVA: 0x002798BC File Offset: 0x00277CBC
		public static CoinDealTradeDataModel CreateCoinDealTradeDataModel(OrderGradeInfo orderGradeInfo, GoldConsignmentOrderType orderType = GoldConsignmentOrderType.GCOT_SELL)
		{
			if (orderGradeInfo == null)
			{
				return null;
			}
			return new CoinDealTradeDataModel
			{
				OrderType = orderType,
				SinglePrice = orderGradeInfo.unitPrice,
				DealCoinNumber = orderGradeInfo.tradeNum
			};
		}

		// Token: 0x0600B28E RID: 45710 RVA: 0x002798FC File Offset: 0x00277CFC
		public static CoinDealMyOrderDataModel CreateCoinDealMyOrderDataModel(GoldConsignmentOrder orderDataModel, GoldConsignmentOrderType orderType = GoldConsignmentOrderType.GCOT_SELL)
		{
			if (orderDataModel == null)
			{
				return null;
			}
			return new CoinDealMyOrderDataModel
			{
				OrderType = orderType,
				OrderId = orderDataModel.orderId,
				SinglePrice = orderDataModel.unitPrice,
				DealCoinNumber = orderDataModel.tradeNum,
				SubmitTimeStamp = (uint)(orderDataModel.sumbitTime / 1000UL),
				ExpireTimeStamp = (uint)(orderDataModel.expireTime / 1000UL)
			};
		}

		// Token: 0x0600B28F RID: 45711 RVA: 0x0027996C File Offset: 0x00277D6C
		public static CoinDealRecordDataModel CreateCoinDealRecordDataModel(GoldConsignmentTradeRecord tradeRecord, GoldConsignmentOrderType orderType = GoldConsignmentOrderType.GCOT_SELL)
		{
			if (tradeRecord == null)
			{
				return null;
			}
			CoinDealRecordDataModel coinDealRecordDataModel = new CoinDealRecordDataModel();
			coinDealRecordDataModel.OrderType = orderType;
			coinDealRecordDataModel.SinglePrice = tradeRecord.unitPrice;
			coinDealRecordDataModel.DealCoinNumber = tradeRecord.tradeNum;
			coinDealRecordDataModel.TradeTimeStamp = (uint)(tradeRecord.tradeTime / 1000UL);
			coinDealRecordDataModel.CreditTicketTotalNumber = 0U;
			coinDealRecordDataModel.PointTicketTotalNumber = 0U;
			if (orderType == GoldConsignmentOrderType.GCOT_SELL)
			{
				coinDealRecordDataModel.CreditTicketTotalNumber = tradeRecord.param;
			}
			else if (orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				coinDealRecordDataModel.PointTicketTotalNumber = tradeRecord.param;
			}
			return coinDealRecordDataModel;
		}

		// Token: 0x0600B290 RID: 45712 RVA: 0x002799F4 File Offset: 0x00277DF4
		public static CoinDealRecordDetailDataModel CreateRecordDetailDataModelByRecord(CreditPointRecord creditPointRecord)
		{
			if (creditPointRecord == null)
			{
				return null;
			}
			CoinDealRecordDetailDataModel coinDealRecordDetailDataModel = new CoinDealRecordDetailDataModel();
			coinDealRecordDetailDataModel.TimeStamp = creditPointRecord.getTimeL;
			coinDealRecordDetailDataModel.TotalNumber = creditPointRecord.totalNum;
			coinDealRecordDetailDataModel.TransferNumber = creditPointRecord.transferNum;
			coinDealRecordDetailDataModel.IsParent = true;
			coinDealRecordDetailDataModel.IsAlreadyUnFold = false;
			if (coinDealRecordDetailDataModel.ChildRecordDetailDataModelList == null)
			{
				coinDealRecordDetailDataModel.ChildRecordDetailDataModelList = new List<CoinDealRecordDetailDataModel>();
			}
			coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Clear();
			if (creditPointRecord.totalNum <= 0U)
			{
				coinDealRecordDetailDataModel.IsOwnerChild = false;
				return coinDealRecordDetailDataModel;
			}
			coinDealRecordDetailDataModel.IsOwnerChild = true;
			CreditPointOrder[] orderList = creditPointRecord.orderList;
			List<CoinDealRecordDetailDataModel> list = new List<CoinDealRecordDetailDataModel>();
			if (orderList != null && orderList.Length > 0)
			{
				foreach (CreditPointOrder creditPointOrder in orderList)
				{
					if (creditPointOrder != null)
					{
						CoinDealRecordDetailDataModel coinDealRecordDetailDataModel2 = CoinDealUtility.CreateRecordDetailDataModelByOrder(creditPointOrder);
						if (coinDealRecordDetailDataModel2 != null)
						{
							list.Add(coinDealRecordDetailDataModel2);
						}
					}
				}
				if (list.Count >= 2)
				{
					list.Sort((CoinDealRecordDetailDataModel x, CoinDealRecordDetailDataModel y) => x.TimeStamp.CompareTo(y.TimeStamp));
				}
				if (list.Count >= 1)
				{
					CoinDealRecordDetailDataModel coinDealRecordDetailDataModel3 = list[0];
					uint timeStamp = coinDealRecordDetailDataModel3.TimeStamp;
					coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Add(coinDealRecordDetailDataModel3);
					for (int j = 1; j < list.Count; j++)
					{
						CoinDealRecordDetailDataModel coinDealRecordDetailDataModel4 = list[j];
						if (!TimeUtility.IsInSameMinuteOfTwoTimeStamp((ulong)timeStamp, (ulong)coinDealRecordDetailDataModel4.TimeStamp))
						{
							coinDealRecordDetailDataModel3 = coinDealRecordDetailDataModel4;
							timeStamp = coinDealRecordDetailDataModel3.TimeStamp;
							coinDealRecordDetailDataModel.ChildRecordDetailDataModelList.Add(coinDealRecordDetailDataModel3);
						}
						else
						{
							coinDealRecordDetailDataModel3.TotalNumber += coinDealRecordDetailDataModel4.TotalNumber;
						}
					}
				}
			}
			list.Clear();
			return coinDealRecordDetailDataModel;
		}

		// Token: 0x0600B291 RID: 45713 RVA: 0x00279BAC File Offset: 0x00277FAC
		private static CoinDealRecordDetailDataModel CreateRecordDetailDataModelByOrder(CreditPointOrder creditPointOrder)
		{
			if (creditPointOrder == null)
			{
				return null;
			}
			return new CoinDealRecordDetailDataModel
			{
				TimeStamp = creditPointOrder.getTime,
				TotalNumber = creditPointOrder.getNum,
				IsParent = false
			};
		}

		// Token: 0x0600B292 RID: 45714 RVA: 0x00279BE8 File Offset: 0x00277FE8
		public static bool IsCoinDealOpenByServer()
		{
			return DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_GOLD_CONSIGNMENT);
		}

		// Token: 0x0600B293 RID: 45715 RVA: 0x00279C08 File Offset: 0x00278008
		public static int GetCoinDealExpectPayNumber(int singlePrice, int coinNumber)
		{
			float coinDealBaseTradeRate = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeRate();
			float value = (float)singlePrice / coinDealBaseTradeRate;
			decimal d = (decimal)value;
			decimal value2 = Math.Ceiling(d);
			return (int)value2 * coinNumber;
		}

		// Token: 0x0600B294 RID: 45716 RVA: 0x00279C40 File Offset: 0x00278040
		public static int GetCoinDealExpectReceiveNumber(int singlePrice, int coinNumber, float feeRate)
		{
			float coinDealBaseTradeRate = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseTradeRate();
			float num = (float)singlePrice / coinDealBaseTradeRate;
			float num2 = num * (float)coinNumber;
			float value = num2 * feeRate;
			decimal d = (decimal)value;
			decimal value2 = Math.Ceiling(d);
			float num3 = num2 - (float)value2;
			return (int)num3;
		}

		// Token: 0x04006477 RID: 25719
		[CompilerGenerated]
		private static Action <>f__mg$cache0;

		// Token: 0x04006478 RID: 25720
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;

		// Token: 0x04006479 RID: 25721
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache2;
	}
}

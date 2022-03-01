using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001580 RID: 5504
	public class CoinDealBuyControlView : MonoBehaviour
	{
		// Token: 0x0600D72B RID: 55083 RVA: 0x0035C707 File Offset: 0x0035AB07
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600D72C RID: 55084 RVA: 0x0035C70F File Offset: 0x0035AB0F
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600D72D RID: 55085 RVA: 0x0035C71D File Offset: 0x0035AB1D
		private void BindEvents()
		{
			if (this.buyButtonWithCd != null)
			{
				this.buyButtonWithCd.ResetButtonListener();
				this.buyButtonWithCd.SetButtonListener(new Action(this.OnBuyButtonClick));
			}
		}

		// Token: 0x0600D72E RID: 55086 RVA: 0x0035C752 File Offset: 0x0035AB52
		private void UnBindEvents()
		{
			if (this.buyButtonWithCd != null)
			{
				this.buyButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600D72F RID: 55087 RVA: 0x0035C770 File Offset: 0x0035AB70
		private void ClearData()
		{
			this._coinNumber = 0;
			this._singlePrice = 0;
			this._originalDealBuyPrice = 0;
			this._expectPayNumber = 0;
		}

		// Token: 0x0600D730 RID: 55088 RVA: 0x0035C790 File Offset: 0x0035AB90
		private void OnEnable()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
		}

		// Token: 0x0600D731 RID: 55089 RVA: 0x0035C7FC File Offset: 0x0035ABFC
		private void OnDisable()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
		}

		// Token: 0x0600D732 RID: 55090 RVA: 0x0035C865 File Offset: 0x0035AC65
		public void InitView()
		{
			this._coinNumber = 1;
			this._originalDealBuyPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealBuyPrice();
			this._singlePrice = this._originalDealBuyPrice;
			this.InitControl();
		}

		// Token: 0x0600D733 RID: 55091 RVA: 0x0035C890 File Offset: 0x0035AC90
		public void OnEnableView()
		{
			if (this.commonControl != null)
			{
				this.commonControl.UpdateControl();
			}
			this.OnEnableInputControl();
			if (this.closeMarketControl != null)
			{
				this.closeMarketControl.OnEnableControl();
			}
			this.UpdateExpectPayView();
		}

		// Token: 0x0600D734 RID: 55092 RVA: 0x0035C8E4 File Offset: 0x0035ACE4
		private void InitControl()
		{
			if (this.commonControl != null)
			{
				this.commonControl.InitControl(GoldConsignmentOrderType.GCOT_BUY);
			}
			if (this.inputControl != null)
			{
				this.inputControl.InitControl(GoldConsignmentOrderType.GCOT_BUY, this._coinNumber, this._singlePrice, new OnCoinDealCoinNumberChangeAction(this.OnCoinDealCoinNumberChangeAction), new OnCoinDealSinglePriceChangeAction(this.OnCoinDealSinglePriceChangeAction));
			}
			if (this.closeMarketControl != null)
			{
				this.closeMarketControl.InitControl(GoldConsignmentOrderType.GCOT_BUY);
			}
			if (this.toggleSelectedController != null)
			{
				bool isCoinDealBuyOrderJustOnce = DataManager<CoinDealDataManager>.GetInstance().IsCoinDealBuyOrderJustOnce;
				string labelStr = TR.Value("Coin_Deal_Buy_Order_Type_Tip_Label");
				this.toggleSelectedController.InitToggleSelectedController(isCoinDealBuyOrderJustOnce, labelStr, new OnToggleSelectedClicked(this.OnToggleSelectedClickAction));
			}
			this.UpdateExpectPayView();
		}

		// Token: 0x0600D735 RID: 55093 RVA: 0x0035C9B2 File Offset: 0x0035ADB2
		private void OnToggleSelectedClickAction(bool isSelected)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealBuyOrderJustOnce = isSelected;
		}

		// Token: 0x0600D736 RID: 55094 RVA: 0x0035C9C0 File Offset: 0x0035ADC0
		private void OnEnableInputControl()
		{
			if (this._originalDealBuyPrice > 0)
			{
				if (this.inputControl != null)
				{
					this.inputControl.UpdateCoinDealSinglePriceWithoutSinglePrice();
					this.inputControl.UpdateCoinDealCoinNumberState();
				}
			}
			else
			{
				this._originalDealBuyPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealBuyPrice();
				this._singlePrice = this._originalDealBuyPrice;
				if (this.inputControl != null)
				{
					this.inputControl.UpdateCoinDealSinglePriceWithSinglePrice(this._singlePrice);
					this.inputControl.UpdateCoinDealCoinNumberState();
				}
			}
		}

		// Token: 0x0600D737 RID: 55095 RVA: 0x0035CA4E File Offset: 0x0035AE4E
		private void UpdateExpectPayView()
		{
			this.UpdateExpectPayValue();
			this.UpdateExpectPayLabel();
		}

		// Token: 0x0600D738 RID: 55096 RVA: 0x0035CA5C File Offset: 0x0035AE5C
		private void UpdateExpectPayValue()
		{
			this._expectPayNumber = CoinDealUtility.GetCoinDealExpectPayNumber(this._singlePrice, this._coinNumber);
		}

		// Token: 0x0600D739 RID: 55097 RVA: 0x0035CA78 File Offset: 0x0035AE78
		private void UpdateExpectPayLabel()
		{
			if (this.expectPayValueLabel == null)
			{
				return;
			}
			string text = Utility.ToThousandsSeparator((ulong)((long)this._expectPayNumber));
			this.expectPayValueLabel.text = text;
			this.expectPayValueLabel.color = ((DataManager<PlayerBaseData>.GetInstance().Ticket >= (ulong)((long)this._expectPayNumber)) ? Color.white : Color.red);
		}

		// Token: 0x0600D73A RID: 55098 RVA: 0x0035CAE0 File Offset: 0x0035AEE0
		private void UpdateOriginalDealPrice()
		{
			if (this._originalDealBuyPrice > 0)
			{
				return;
			}
			this._originalDealBuyPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealBuyPrice();
			this._singlePrice = this._originalDealBuyPrice;
			this.UpdateExpectPayView();
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealSinglePriceWithSinglePrice(this._singlePrice);
				this.inputControl.UpdateCoinDealCoinNumberState();
			}
		}

		// Token: 0x0600D73B RID: 55099 RVA: 0x0035CB49 File Offset: 0x0035AF49
		private void UpdateSinglePriceInterval()
		{
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealSinglePriceWithoutSinglePrice();
			}
		}

		// Token: 0x0600D73C RID: 55100 RVA: 0x0035CB67 File Offset: 0x0035AF67
		private void OnCoinDealCoinNumberChangeAction(int coinNumber)
		{
			this._coinNumber = coinNumber;
			this.UpdateExpectPayView();
		}

		// Token: 0x0600D73D RID: 55101 RVA: 0x0035CB76 File Offset: 0x0035AF76
		private void OnCoinDealSinglePriceChangeAction(int singlePrice)
		{
			this._singlePrice = singlePrice;
			this.UpdateExpectPayView();
		}

		// Token: 0x0600D73E RID: 55102 RVA: 0x0035CB85 File Offset: 0x0035AF85
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			if (eTarget != PlayerBaseData.MoneyBinderType.MBT_POINT)
			{
				return;
			}
			this.UpdateExpectPayLabel();
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealCoinNumberState();
			}
		}

		// Token: 0x0600D73F RID: 55103 RVA: 0x0035CBB1 File Offset: 0x0035AFB1
		private void OnReceiveCoinDealAveragePriceUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateSinglePriceInterval();
		}

		// Token: 0x0600D740 RID: 55104 RVA: 0x0035CBB9 File Offset: 0x0035AFB9
		private void OnReceiveCoinDealTodayPriceValueUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateOriginalDealPrice();
		}

		// Token: 0x0600D741 RID: 55105 RVA: 0x0035CBC4 File Offset: 0x0035AFC4
		private void OnBuyButtonClick()
		{
			bool flag = CoinDealUtility.IsInCloseMarketIntervalTime();
			if (flag)
			{
				if (this.closeMarketControl != null)
				{
					this.closeMarketControl.UpdateControl();
				}
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Not_Deal_Already_Close_Market"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (!CoinDealUtility.IsPriceInSinglePriceInterval(this._singlePrice))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Input_Single_Price_Invalid"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Ticket < (ulong)((long)this._expectPayNumber))
			{
				DataManager<CostItemManager>.GetInstance().ShowJumpToVipFrameTip();
				return;
			}
			int coinDealOwnerOrderNumberWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithBuy;
			int coinDealSubmitOrderMaxNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealSubmitOrderMaxNumber();
			if (coinDealOwnerOrderNumberWithBuy >= coinDealSubmitOrderMaxNumber)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Buy_Failed_With_Deal_Time_Is_Zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealBuyOrderJustOnce)
			{
				if (DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitBuyOrderTipJustOnce)
				{
					this.OnSendSubmitBuyOrderReq();
				}
				else
				{
					string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr(this._coinNumber);
					int expectPayNumber = this._expectPayNumber;
					string contentStr = TR.Value("Coin_Deal_Buy_Order_With_Once_Buy", coinDealCommonCoinNumberStr, expectPayNumber);
					CoinDealUtility.OnOpenSubmitOrderTipFrame(contentStr, new OnCommonMsgBoxToggleClick(this.OnUpdateSubmitBuyOrderTipJustOnce), new Action(this.OnSendSubmitBuyOrderReq));
				}
			}
			else if (DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitBuyOrderTipWithMore)
			{
				this.OnSendSubmitBuyOrderReq();
			}
			else
			{
				string coinDealCommonCoinNumberStr2 = CoinDealUtility.GetCoinDealCommonCoinNumberStr(this._coinNumber);
				int expectPayNumber2 = this._expectPayNumber;
				int coinDealHangListLastTime = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealHangListLastTime();
				string contentStr2 = TR.Value("Coin_Deal_Buy_Order_WithOut_Once_Buy", coinDealCommonCoinNumberStr2, expectPayNumber2, coinDealHangListLastTime);
				CoinDealUtility.OnOpenSubmitOrderTipFrame(contentStr2, new OnCommonMsgBoxToggleClick(this.OnUpdateSubmitBuyOrderTipWithMore), new Action(this.OnSendSubmitBuyOrderReq));
			}
		}

		// Token: 0x0600D742 RID: 55106 RVA: 0x0035CD7E File Offset: 0x0035B17E
		private void OnUpdateSubmitBuyOrderTipJustOnce(bool value)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitBuyOrderTipJustOnce = value;
		}

		// Token: 0x0600D743 RID: 55107 RVA: 0x0035CD8B File Offset: 0x0035B18B
		private void OnUpdateSubmitBuyOrderTipWithMore(bool value)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitBuyOrderTipWithMore = value;
		}

		// Token: 0x0600D744 RID: 55108 RVA: 0x0035CD98 File Offset: 0x0035B198
		private void OnSendSubmitBuyOrderReq()
		{
			bool flag = CoinDealUtility.IsInCloseMarketIntervalTime();
			if (flag)
			{
				if (this.closeMarketControl != null)
				{
					this.closeMarketControl.UpdateControl();
				}
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Not_Deal_Already_Close_Market"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			GoldConsignmentTradeType tradeType = GoldConsignmentTradeType.GCOT_HANG_LIST;
			if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealBuyOrderJustOnce)
			{
				tradeType = GoldConsignmentTradeType.GCTT_ONCE;
			}
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentSubmitOrderReq(GoldConsignmentOrderType.GCOT_BUY, this._singlePrice, this._coinNumber, tradeType);
		}

		// Token: 0x04007E50 RID: 32336
		private int _coinNumber;

		// Token: 0x04007E51 RID: 32337
		private int _singlePrice;

		// Token: 0x04007E52 RID: 32338
		private int _originalDealBuyPrice;

		// Token: 0x04007E53 RID: 32339
		private int _expectPayNumber;

		// Token: 0x04007E54 RID: 32340
		[Space(10f)]
		[Header("CommonControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealCommonControl commonControl;

		// Token: 0x04007E55 RID: 32341
		[Space(10f)]
		[Header("inputControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealInputControl inputControl;

		// Token: 0x04007E56 RID: 32342
		[Space(10f)]
		[Header("CloseMarketControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealCloseMarketControl closeMarketControl;

		// Token: 0x04007E57 RID: 32343
		[Space(10f)]
		[Header("ToggleSelected")]
		[Space(10f)]
		[SerializeField]
		private ComToggleSelectedController toggleSelectedController;

		// Token: 0x04007E58 RID: 32344
		[Space(10f)]
		[Header("Text")]
		[Space(10f)]
		[SerializeField]
		private Text expectPayValueLabel;

		// Token: 0x04007E59 RID: 32345
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd buyButtonWithCd;
	}
}

using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001586 RID: 5510
	public class CoinDealSellControlView : MonoBehaviour
	{
		// Token: 0x0600D795 RID: 55189 RVA: 0x0035E292 File Offset: 0x0035C692
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600D796 RID: 55190 RVA: 0x0035E29A File Offset: 0x0035C69A
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600D797 RID: 55191 RVA: 0x0035E2A8 File Offset: 0x0035C6A8
		private void BindEvents()
		{
			if (this.sellButtonWithCd != null)
			{
				this.sellButtonWithCd.ResetButtonListener();
				this.sellButtonWithCd.SetButtonListener(new Action(this.OnSellButtonClick));
			}
		}

		// Token: 0x0600D798 RID: 55192 RVA: 0x0035E2DD File Offset: 0x0035C6DD
		private void UnBindEvents()
		{
			if (this.sellButtonWithCd != null)
			{
				this.sellButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600D799 RID: 55193 RVA: 0x0035E2FB File Offset: 0x0035C6FB
		private void ClearData()
		{
			this._coinNumber = 0;
			this._singlePrice = 0;
			this._originalDealSellPrice = 0;
			this._feeRateValue = 0f;
			this._expectReceiveValue = 0;
		}

		// Token: 0x0600D79A RID: 55194 RVA: 0x0035E324 File Offset: 0x0035C724
		private void OnEnable()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
		}

		// Token: 0x0600D79B RID: 55195 RVA: 0x0035E390 File Offset: 0x0035C790
		private void OnDisable()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
		}

		// Token: 0x0600D79C RID: 55196 RVA: 0x0035E3F9 File Offset: 0x0035C7F9
		public void InitView()
		{
			this._coinNumber = 1;
			this._originalDealSellPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealSellPrice();
			this._singlePrice = this._originalDealSellPrice;
			this.InitFeeRate();
			this.InitCreditTicketIcon();
			this.InitCreditTicketGetInMonth();
			this.InitControl();
		}

		// Token: 0x0600D79D RID: 55197 RVA: 0x0035E438 File Offset: 0x0035C838
		public void OnEnableView()
		{
			this.OnEnableCreditTicketGetInMonth();
			if (this.commonControl != null)
			{
				this.commonControl.UpdateControl();
			}
			this.OnEnableInputControl();
			if (this.closeMarketControl != null)
			{
				this.closeMarketControl.OnEnableControl();
			}
			this.UpdateExpectReceiveView();
		}

		// Token: 0x0600D79E RID: 55198 RVA: 0x0035E490 File Offset: 0x0035C890
		private void InitFeeRate()
		{
			this._feeRateValue = (float)DataManager<CoinDealDataManager>.GetInstance().GetCoinDealFeeRate() / 1000f;
			if (this.feeRateValueLabel != null)
			{
				string feeRateValueStr = CoinDealUtility.GetFeeRateValueStr();
				this.feeRateValueLabel.text = feeRateValueStr;
			}
		}

		// Token: 0x0600D79F RID: 55199 RVA: 0x0035E4D8 File Offset: 0x0035C8D8
		private void InitControl()
		{
			if (this.commonControl != null)
			{
				this.commonControl.InitControl(GoldConsignmentOrderType.GCOT_SELL);
			}
			if (this.inputControl != null)
			{
				this.inputControl.InitControl(GoldConsignmentOrderType.GCOT_SELL, this._coinNumber, this._singlePrice, new OnCoinDealCoinNumberChangeAction(this.OnCoinDealCoinNumberChangeAction), new OnCoinDealSinglePriceChangeAction(this.OnCoinDealSinglePriceChangeAction));
			}
			if (this.closeMarketControl != null)
			{
				this.closeMarketControl.InitControl(GoldConsignmentOrderType.GCOT_SELL);
			}
			this.UpdateExpectReceiveView();
		}

		// Token: 0x0600D7A0 RID: 55200 RVA: 0x0035E568 File Offset: 0x0035C968
		private void InitCreditTicketIcon()
		{
			ItemTable creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
			if (creditTicketItemTable == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(creditTicketItemTable.Icon))
			{
				return;
			}
			if (this.creditTicketIconTwo != null)
			{
				ETCImageLoader.LoadSprite(ref this.creditTicketIconTwo, creditTicketItemTable.Icon, true);
			}
			if (this.creditTicketIconThree != null)
			{
				ETCImageLoader.LoadSprite(ref this.creditTicketIconThree, creditTicketItemTable.Icon, true);
			}
			if (this.creditTicketIconFour != null)
			{
				ETCImageLoader.LoadSprite(ref this.creditTicketIconFour, creditTicketItemTable.Icon, true);
			}
		}

		// Token: 0x0600D7A1 RID: 55201 RVA: 0x0035E604 File Offset: 0x0035CA04
		private void InitCreditTicketGetInMonth()
		{
			if (this.creditTicketNumberControl != null)
			{
				this.creditTicketNumberControl.InitControl(600002551);
			}
		}

		// Token: 0x0600D7A2 RID: 55202 RVA: 0x0035E628 File Offset: 0x0035CA28
		private void OnEnableInputControl()
		{
			if (this._originalDealSellPrice > 0)
			{
				if (this.inputControl != null)
				{
					this.inputControl.UpdateCoinDealSinglePriceWithoutSinglePrice();
					this.inputControl.UpdateCoinDealCoinNumberState();
				}
			}
			else
			{
				this._originalDealSellPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealSellPrice();
				this._singlePrice = this._originalDealSellPrice;
				if (this.inputControl != null)
				{
					this.inputControl.UpdateCoinDealSinglePriceWithSinglePrice(this._singlePrice);
					this.inputControl.UpdateCoinDealCoinNumberState();
				}
			}
		}

		// Token: 0x0600D7A3 RID: 55203 RVA: 0x0035E6B6 File Offset: 0x0035CAB6
		private void OnEnableCreditTicketGetInMonth()
		{
			if (this.creditTicketNumberControl != null)
			{
				this.creditTicketNumberControl.OnEnableControl();
			}
		}

		// Token: 0x0600D7A4 RID: 55204 RVA: 0x0035E6D4 File Offset: 0x0035CAD4
		private void UpdateExpectReceiveView()
		{
			this.UpdateExpectReceiveValue();
			if (this.expectReceiveValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)this._expectReceiveValue));
				this.expectReceiveValueLabel.text = text;
			}
		}

		// Token: 0x0600D7A5 RID: 55205 RVA: 0x0035E711 File Offset: 0x0035CB11
		private void UpdateExpectReceiveValue()
		{
			this._expectReceiveValue = CoinDealUtility.GetCoinDealExpectReceiveNumber(this._singlePrice, this._coinNumber, this._feeRateValue);
		}

		// Token: 0x0600D7A6 RID: 55206 RVA: 0x0035E730 File Offset: 0x0035CB30
		private void UpdateOriginalDealPrice()
		{
			if (this._originalDealSellPrice > 0)
			{
				return;
			}
			this._originalDealSellPrice = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOriginalDealSellPrice();
			this._singlePrice = this._originalDealSellPrice;
			this.UpdateExpectReceiveView();
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealSinglePriceWithSinglePrice(this._singlePrice);
			}
		}

		// Token: 0x0600D7A7 RID: 55207 RVA: 0x0035E78E File Offset: 0x0035CB8E
		private void UpdateSinglePriceInterval()
		{
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealSinglePriceWithoutSinglePrice();
			}
		}

		// Token: 0x0600D7A8 RID: 55208 RVA: 0x0035E7AC File Offset: 0x0035CBAC
		private void OnCoinDealCoinNumberChangeAction(int coinNumber)
		{
			this._coinNumber = coinNumber;
			this.UpdateExpectReceiveView();
		}

		// Token: 0x0600D7A9 RID: 55209 RVA: 0x0035E7BB File Offset: 0x0035CBBB
		private void OnCoinDealSinglePriceChangeAction(int singlePrice)
		{
			this._singlePrice = singlePrice;
			this.UpdateExpectReceiveView();
		}

		// Token: 0x0600D7AA RID: 55210 RVA: 0x0035E7CA File Offset: 0x0035CBCA
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			if (eTarget != PlayerBaseData.MoneyBinderType.MBT_GOLD)
			{
				return;
			}
			if (this.inputControl != null)
			{
				this.inputControl.UpdateCoinDealCoinNumberState();
			}
		}

		// Token: 0x0600D7AB RID: 55211 RVA: 0x0035E7EF File Offset: 0x0035CBEF
		private void OnReceiveCoinDealAveragePriceUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateSinglePriceInterval();
		}

		// Token: 0x0600D7AC RID: 55212 RVA: 0x0035E7F7 File Offset: 0x0035CBF7
		private void OnReceiveCoinDealTodayPriceValueUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateOriginalDealPrice();
		}

		// Token: 0x0600D7AD RID: 55213 RVA: 0x0035E800 File Offset: 0x0035CC00
		private void OnSellButtonClick()
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
			ulong coinDealCommonCoinNumber = CoinDealUtility.GetCoinDealCommonCoinNumber(this._coinNumber);
			if (DataManager<PlayerBaseData>.GetInstance().Gold < coinDealCommonCoinNumber)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Sell_Failed_Without_Enough_Coin"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int coinDealOwnerOrderNumberWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithSell;
			int coinDealSubmitOrderMaxNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealSubmitOrderMaxNumber();
			if (coinDealOwnerOrderNumberWithSell >= coinDealSubmitOrderMaxNumber)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Sell_Failed_With_Deal_Time_Is_Zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int expectReceiveValue = this._expectReceiveValue;
			int num = (int)(DataManager<PlayerBaseData>.GetInstance().CreditTicketGetInMonth + (uint)DataManager<CoinDealDataManager>.GetInstance().CreditTicketGetNumberInTrade + (uint)expectReceiveValue);
			int creditTicketMaxNumberInMonth = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketMaxNumberInMonth();
			if (num > creditTicketMaxNumberInMonth)
			{
				int num2 = creditTicketMaxNumberInMonth - (int)DataManager<PlayerBaseData>.GetInstance().CreditTicketGetInMonth - DataManager<CoinDealDataManager>.GetInstance().CreditTicketGetNumberInTrade;
				string contentStr = TR.Value("Coin_Deal_Sell_Failed_Exceed_Month_Limit", expectReceiveValue, num2);
				CoinDealUtility.OnOpenSellOrderCreditTicketExceedTipFrame(contentStr, null, TR.Value("common_data_sure"));
				return;
			}
			num = (int)(DataManager<PlayerBaseData>.GetInstance().CreditTicketOwnerBySelf + (uint)DataManager<CoinDealDataManager>.GetInstance().CreditTicketGetNumberInTrade + (uint)expectReceiveValue);
			int creditTicketMaxNumberInSelfPlayer = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketMaxNumberInSelfPlayer();
			if (num > creditTicketMaxNumberInSelfPlayer)
			{
				int num3 = creditTicketMaxNumberInSelfPlayer - (int)DataManager<PlayerBaseData>.GetInstance().CreditTicketOwnerBySelf - DataManager<CoinDealDataManager>.GetInstance().CreditTicketGetNumberInTrade;
				string contentStr2 = TR.Value("Coin_Deal_Sell_Failed_Exceed_Owner_Limit", expectReceiveValue, num3);
				CoinDealUtility.OnOpenSellOrderCreditTicketExceedTipFrame(contentStr2, null, TR.Value("common_data_sure"));
				return;
			}
			if (DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitSellOrderTip)
			{
				this.OnSendSubmitSellOrderReq();
				return;
			}
			string arg = Utility.ToThousandsSeparator(coinDealCommonCoinNumber);
			int coinDealHangListLastTime = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealHangListLastTime();
			string contentStr3 = TR.Value("Coin_Deal_Sell_Order_Tip_Content_Format", arg, expectReceiveValue, coinDealHangListLastTime);
			CoinDealUtility.OnOpenSubmitOrderTipFrame(contentStr3, new OnCommonMsgBoxToggleClick(this.OnUpdateSubmitSellOrderTip), new Action(this.OnSendSubmitSellOrderReq));
		}

		// Token: 0x0600D7AE RID: 55214 RVA: 0x0035EA23 File Offset: 0x0035CE23
		private void OnUpdateSubmitSellOrderTip(bool value)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsNotShowSubmitSellOrderTip = value;
		}

		// Token: 0x0600D7AF RID: 55215 RVA: 0x0035EA30 File Offset: 0x0035CE30
		private void OnSendSubmitSellOrderReq()
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
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentSubmitOrderReq(GoldConsignmentOrderType.GCOT_SELL, this._singlePrice, this._coinNumber, GoldConsignmentTradeType.GCOT_HANG_LIST);
		}

		// Token: 0x04007E8E RID: 32398
		private int _coinNumber;

		// Token: 0x04007E8F RID: 32399
		private int _singlePrice;

		// Token: 0x04007E90 RID: 32400
		private int _originalDealSellPrice;

		// Token: 0x04007E91 RID: 32401
		private float _feeRateValue;

		// Token: 0x04007E92 RID: 32402
		private int _expectReceiveValue;

		// Token: 0x04007E93 RID: 32403
		[Space(10f)]
		[Header("CommonControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealCommonControl commonControl;

		// Token: 0x04007E94 RID: 32404
		[Space(10f)]
		[Header("inputControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealInputControl inputControl;

		// Token: 0x04007E95 RID: 32405
		[Space(10f)]
		[Header("CloseMarketControl")]
		[Space(10f)]
		[SerializeField]
		private CoinDealCloseMarketControl closeMarketControl;

		// Token: 0x04007E96 RID: 32406
		[Space(10f)]
		[Header("CreditTicketIcon")]
		[Space(10f)]
		[SerializeField]
		private Image creditTicketIconTwo;

		// Token: 0x04007E97 RID: 32407
		[SerializeField]
		private Image creditTicketIconThree;

		// Token: 0x04007E98 RID: 32408
		[SerializeField]
		private Image creditTicketIconFour;

		// Token: 0x04007E99 RID: 32409
		[Space(10f)]
		[Header("Text")]
		[Space(10f)]
		[SerializeField]
		private Text feeRateValueLabel;

		// Token: 0x04007E9A RID: 32410
		[SerializeField]
		private Text expectReceiveValueLabel;

		// Token: 0x04007E9B RID: 32411
		[SerializeField]
		private CreditTicketNumberControl creditTicketNumberControl;

		// Token: 0x04007E9C RID: 32412
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd sellButtonWithCd;
	}
}

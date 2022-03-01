using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001582 RID: 5506
	public class CoinDealCommonControl : MonoBehaviour
	{
		// Token: 0x0600D758 RID: 55128 RVA: 0x0035D120 File Offset: 0x0035B520
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderNumberUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderNumberUpdateMessage));
		}

		// Token: 0x0600D759 RID: 55129 RVA: 0x0035D180 File Offset: 0x0035B580
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealTodayPriceValueUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTodayPriceValueUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderNumberUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderNumberUpdateMessage));
		}

		// Token: 0x0600D75A RID: 55130 RVA: 0x0035D1DE File Offset: 0x0035B5DE
		public void InitControl(GoldConsignmentOrderType orderType)
		{
			this._orderType = orderType;
			this.InitTitle();
			this.UpdateControl();
		}

		// Token: 0x0600D75B RID: 55131 RVA: 0x0035D1F4 File Offset: 0x0035B5F4
		private void InitTitle()
		{
			if (this.coinTotalTitleLabel != null)
			{
				if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
				{
					this.coinTotalTitleLabel.text = TR.Value("Coin_Deal_Deal_Buy_Coin_Total_Label");
				}
				else
				{
					this.coinTotalTitleLabel.text = TR.Value("Coin_Deal_Deal_Sell_Coin_Total_Label");
				}
			}
			if (this.coinNumberBaseLabel != null)
			{
				string coinDealBaseTradeCoinNumberStr = CoinDealUtility.GetCoinDealBaseTradeCoinNumberStr();
				this.coinNumberBaseLabel.text = coinDealBaseTradeCoinNumberStr;
			}
			if (this.singlePriceTitleLabel != null)
			{
				string coinDealCommonSinglePriceStr = CoinDealUtility.GetCoinDealCommonSinglePriceStr();
				this.singlePriceTitleLabel.text = coinDealCommonSinglePriceStr;
			}
			if (this.singlePriceIntervalTitleLabel != null)
			{
				this.singlePriceIntervalTitleLabel.text = TR.Value("Coin_Deal_Single_Price_Title_Today");
			}
			if (this.dealPriceTitleLabel != null)
			{
				this.dealPriceTitleLabel.text = TR.Value("Coin_Deal_Average_Price_Title_Recently");
			}
		}

		// Token: 0x0600D75C RID: 55132 RVA: 0x0035D2DF File Offset: 0x0035B6DF
		public void UpdateControl()
		{
			this.UpdateSinglePriceValueLabel();
			this.UpdateTodayDealPriceValueLabel();
			this.UpdateDealOwnerOrderValueLabel();
		}

		// Token: 0x0600D75D RID: 55133 RVA: 0x0035D2F4 File Offset: 0x0035B6F4
		private void UpdateSinglePriceValueLabel()
		{
			if (this.singlePriceIntervalValueLabel != null)
			{
				int coinDealMinDealPriceValue = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMinDealPriceValue();
				int coinDealMaxDealPriceValue = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealMaxDealPriceValue();
				string arg = Utility.ToThousandsSeparator((ulong)((long)coinDealMinDealPriceValue));
				string arg2 = Utility.ToThousandsSeparator((ulong)((long)coinDealMaxDealPriceValue));
				string text = TR.Value("Coin_Deal_Single_Price_Value_Today", arg, arg2);
				this.singlePriceIntervalValueLabel.text = text;
			}
		}

		// Token: 0x0600D75E RID: 55134 RVA: 0x0035D354 File Offset: 0x0035B754
		private void UpdateTodayDealPriceValueLabel()
		{
			if (this.dealPriceValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)DataManager<CoinDealDataManager>.GetInstance().CoinDealAveragePriceValueInToday));
				this.dealPriceValueLabel.text = text;
			}
			int num = DataManager<CoinDealDataManager>.GetInstance().CoinDealAveragePriceValueInToday - DataManager<CoinDealDataManager>.GetInstance().CoinDealAveragePriceValueInRecently;
			if (num > 0)
			{
				CommonUtility.UpdateGameObjectVisible(this.dealPriceUpFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.dealPriceDownFlag, false);
			}
			else if (num < 0)
			{
				CommonUtility.UpdateGameObjectVisible(this.dealPriceUpFlag, false);
				CommonUtility.UpdateGameObjectVisible(this.dealPriceDownFlag, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.dealPriceUpFlag, false);
				CommonUtility.UpdateGameObjectVisible(this.dealPriceDownFlag, false);
			}
		}

		// Token: 0x0600D75F RID: 55135 RVA: 0x0035D408 File Offset: 0x0035B808
		private void UpdateDealOwnerOrderValueLabel()
		{
			if (this.dealOrderValueLabel == null)
			{
				return;
			}
			if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				int coinDealOwnerOrderNumberWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithBuy;
				int coinDealSubmitOrderMaxNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealSubmitOrderMaxNumber();
				string text = TR.Value("Coin_Deal_Account_Buy_Order_Format", coinDealOwnerOrderNumberWithBuy, coinDealSubmitOrderMaxNumber);
				this.dealOrderValueLabel.text = text;
			}
			else
			{
				int coinDealOwnerOrderNumberWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithSell;
				int coinDealSubmitOrderMaxNumber2 = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealSubmitOrderMaxNumber();
				string text2 = TR.Value("Coin_Deal_Account_Sell_Order_Format", coinDealOwnerOrderNumberWithSell, coinDealSubmitOrderMaxNumber2);
				this.dealOrderValueLabel.text = text2;
			}
		}

		// Token: 0x0600D760 RID: 55136 RVA: 0x0035D4AE File Offset: 0x0035B8AE
		private void OnReceiveCoinDealAveragePriceUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateSinglePriceValueLabel();
		}

		// Token: 0x0600D761 RID: 55137 RVA: 0x0035D4B6 File Offset: 0x0035B8B6
		private void OnReceiveCoinDealTodayPriceValueUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateTodayDealPriceValueLabel();
		}

		// Token: 0x0600D762 RID: 55138 RVA: 0x0035D4BE File Offset: 0x0035B8BE
		private void OnReceiveCoinDealOwnerOrderNumberUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateDealOwnerOrderValueLabel();
		}

		// Token: 0x04007E64 RID: 32356
		private GoldConsignmentOrderType _orderType;

		// Token: 0x04007E65 RID: 32357
		[Space(10f)]
		[Header("title")]
		[Space(10f)]
		[SerializeField]
		private Text coinTotalTitleLabel;

		// Token: 0x04007E66 RID: 32358
		[SerializeField]
		private Text coinNumberBaseLabel;

		// Token: 0x04007E67 RID: 32359
		[Space(10f)]
		[Header("priceTitle")]
		[Space(10f)]
		[SerializeField]
		private Text singlePriceTitleLabel;

		// Token: 0x04007E68 RID: 32360
		[Space(10f)]
		[Header("SinglePriceInterval")]
		[Space(10f)]
		[SerializeField]
		private Text singlePriceIntervalTitleLabel;

		// Token: 0x04007E69 RID: 32361
		[SerializeField]
		private Text singlePriceIntervalValueLabel;

		// Token: 0x04007E6A RID: 32362
		[Space(10f)]
		[Header("DealPrice")]
		[Space(10f)]
		[SerializeField]
		private Text dealPriceTitleLabel;

		// Token: 0x04007E6B RID: 32363
		[SerializeField]
		private Text dealPriceValueLabel;

		// Token: 0x04007E6C RID: 32364
		[SerializeField]
		private GameObject dealPriceUpFlag;

		// Token: 0x04007E6D RID: 32365
		[SerializeField]
		private GameObject dealPriceDownFlag;

		// Token: 0x04007E6E RID: 32366
		[Space(10f)]
		[Header("other")]
		[Space(10f)]
		[SerializeField]
		private Text dealOrderValueLabel;
	}
}

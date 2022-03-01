using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200157B RID: 5499
	public class CoinDealTradeItem : MonoBehaviour
	{
		// Token: 0x0600D6D5 RID: 54997 RVA: 0x0035AD24 File Offset: 0x00359124
		private void Awake()
		{
		}

		// Token: 0x0600D6D6 RID: 54998 RVA: 0x0035AD26 File Offset: 0x00359126
		private void OnDestroy()
		{
			this._tradeDataModel = null;
		}

		// Token: 0x0600D6D7 RID: 54999 RVA: 0x0035AD30 File Offset: 0x00359130
		public void InitItem(CoinDealTradeDataModel tradeDataModel, int tradeIndex)
		{
			this._tradeDataModel = tradeDataModel;
			if (this._tradeDataModel == null)
			{
				return;
			}
			if (this.tradeItemIndexLabel != null)
			{
				string text = TR.Value("Coin_Deal_Sell_Item_Title_Format", tradeIndex);
				if (tradeDataModel.OrderType == GoldConsignmentOrderType.GCOT_BUY)
				{
					text = TR.Value("Coin_Deal_Buy_Item_Title_Format", tradeIndex);
				}
				this.tradeItemIndexLabel.text = text;
			}
			if (this.singlePriceValueLabel != null)
			{
				string text2 = Utility.ToThousandsSeparator((ulong)this._tradeDataModel.SinglePrice);
				this.singlePriceValueLabel.text = text2;
			}
			if (this.dealCoinValueLabel != null)
			{
				ulong dealCoinNumber = this._tradeDataModel.DealCoinNumber;
				ulong coinDealCommonCoinNumber = CoinDealUtility.GetCoinDealCommonCoinNumber((int)dealCoinNumber);
				ulong coinDealCoinMaxShowNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealCoinMaxShowNumber();
				if (coinDealCommonCoinNumber <= coinDealCoinMaxShowNumber)
				{
					string text3 = Utility.ToThousandsSeparator(coinDealCommonCoinNumber);
					this.dealCoinValueLabel.text = text3;
				}
				else
				{
					string arg = Utility.ToThousandsSeparator(coinDealCoinMaxShowNumber);
					string text4 = TR.Value("Coin_Deal_Coin_Number_Max_Show_Format", arg);
					this.dealCoinValueLabel.text = text4;
				}
			}
			if (this.bgImage != null)
			{
				int num = tradeIndex % 2;
				if (num == 1)
				{
					this.bgImage.color = this.normalColor;
				}
				else
				{
					this.bgImage.color = this.specialColor;
				}
			}
		}

		// Token: 0x0600D6D8 RID: 55000 RVA: 0x0035AE86 File Offset: 0x00359286
		public void RecycleItem()
		{
			this._tradeDataModel = null;
		}

		// Token: 0x04007E24 RID: 32292
		private CoinDealTradeDataModel _tradeDataModel;

		// Token: 0x04007E25 RID: 32293
		[Space(10f)]
		[Header("value")]
		[Space(10f)]
		[SerializeField]
		private Text tradeItemIndexLabel;

		// Token: 0x04007E26 RID: 32294
		[SerializeField]
		private Text singlePriceValueLabel;

		// Token: 0x04007E27 RID: 32295
		[SerializeField]
		private Text dealCoinValueLabel;

		// Token: 0x04007E28 RID: 32296
		[Space(10f)]
		[Header("BgColor")]
		[Space(10f)]
		[SerializeField]
		private Image bgImage;

		// Token: 0x04007E29 RID: 32297
		[SerializeField]
		private Color normalColor;

		// Token: 0x04007E2A RID: 32298
		[SerializeField]
		private Color specialColor;
	}
}

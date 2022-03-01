using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200157A RID: 5498
	public class CoinDealRecordItem : MonoBehaviour
	{
		// Token: 0x0600D6CD RID: 54989 RVA: 0x0035AAF0 File Offset: 0x00358EF0
		private void Awake()
		{
		}

		// Token: 0x0600D6CE RID: 54990 RVA: 0x0035AAF2 File Offset: 0x00358EF2
		private void OnDestroy()
		{
			this._recordDataModel = null;
		}

		// Token: 0x0600D6CF RID: 54991 RVA: 0x0035AAFC File Offset: 0x00358EFC
		public void InitItem(CoinDealRecordDataModel recordDataModel, int tradeIndex = 0)
		{
			this._recordDataModel = recordDataModel;
			if (this._recordDataModel == null)
			{
				return;
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
			GoldConsignmentOrderType orderType = this._recordDataModel.OrderType;
			if (orderType != GoldConsignmentOrderType.GCOT_SELL)
			{
				if (orderType == GoldConsignmentOrderType.GCOT_BUY)
				{
					this.InitBuyRecordItem();
				}
			}
			else
			{
				this.InitSellRecordItem();
			}
		}

		// Token: 0x0600D6D0 RID: 54992 RVA: 0x0035AB9C File Offset: 0x00358F9C
		private void InitBaseItem()
		{
			if (this.tradeDealTimeLabel != null)
			{
				string timeFormatByMonthDayHourMinuteWithCommonFormat = TimeUtility.GetTimeFormatByMonthDayHourMinuteWithCommonFormat(this._recordDataModel.TradeTimeStamp);
				this.tradeDealTimeLabel.text = timeFormatByMonthDayHourMinuteWithCommonFormat;
			}
			if (this.singlePriceValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._recordDataModel.SinglePrice);
				this.singlePriceValueLabel.text = text;
			}
			if (this.dealCoinValueLabel != null)
			{
				string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._recordDataModel.DealCoinNumber);
				if (this.dealCoinValueLabel != null)
				{
					this.dealCoinValueLabel.text = coinDealCommonCoinNumberStr;
				}
			}
		}

		// Token: 0x0600D6D1 RID: 54993 RVA: 0x0035AC48 File Offset: 0x00359048
		private void InitBuyRecordItem()
		{
			this.InitBaseItem();
			if (this.pointTicketValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._recordDataModel.PointTicketTotalNumber);
				this.pointTicketValueLabel.text = text;
			}
		}

		// Token: 0x0600D6D2 RID: 54994 RVA: 0x0035AC8C File Offset: 0x0035908C
		private void InitSellRecordItem()
		{
			this.InitBaseItem();
			if (this.creditTicketValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._recordDataModel.CreditTicketTotalNumber);
				this.creditTicketValueLabel.text = text;
			}
			if (this.creditTicketIcon != null)
			{
				ItemTable creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
				if (creditTicketItemTable != null && !string.IsNullOrEmpty(creditTicketItemTable.Icon))
				{
					ETCImageLoader.LoadSprite(ref this.creditTicketIcon, creditTicketItemTable.Icon, true);
				}
			}
		}

		// Token: 0x0600D6D3 RID: 54995 RVA: 0x0035AD13 File Offset: 0x00359113
		public void RecycleItem()
		{
			this._recordDataModel = null;
		}

		// Token: 0x04007E1A RID: 32282
		private CoinDealRecordDataModel _recordDataModel;

		// Token: 0x04007E1B RID: 32283
		[Space(10f)]
		[Header("value")]
		[Space(10f)]
		[SerializeField]
		private Text tradeDealTimeLabel;

		// Token: 0x04007E1C RID: 32284
		[SerializeField]
		private Text singlePriceValueLabel;

		// Token: 0x04007E1D RID: 32285
		[SerializeField]
		private Text dealCoinValueLabel;

		// Token: 0x04007E1E RID: 32286
		[SerializeField]
		private Text pointTicketValueLabel;

		// Token: 0x04007E1F RID: 32287
		[SerializeField]
		private Text creditTicketValueLabel;

		// Token: 0x04007E20 RID: 32288
		[Space(10f)]
		[Header("Image")]
		[Space(10f)]
		[SerializeField]
		private Image creditTicketIcon;

		// Token: 0x04007E21 RID: 32289
		[Space(10f)]
		[Header("BgColor")]
		[Space(10f)]
		[SerializeField]
		private Image bgImage;

		// Token: 0x04007E22 RID: 32290
		[SerializeField]
		private Color normalColor;

		// Token: 0x04007E23 RID: 32291
		[SerializeField]
		private Color specialColor;
	}
}

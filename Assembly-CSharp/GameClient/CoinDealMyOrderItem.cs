using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001579 RID: 5497
	public class CoinDealMyOrderItem : MonoBehaviour
	{
		// Token: 0x0600D6C1 RID: 54977 RVA: 0x0035A7C0 File Offset: 0x00358BC0
		private void Awake()
		{
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
				this.cancelButton.onClick.AddListener(new UnityAction(this.OnCancelButtonClick));
			}
		}

		// Token: 0x0600D6C2 RID: 54978 RVA: 0x0035A7FF File Offset: 0x00358BFF
		private void OnDestroy()
		{
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
			}
			this._myOrderDataModel = null;
		}

		// Token: 0x0600D6C3 RID: 54979 RVA: 0x0035A82C File Offset: 0x00358C2C
		public void InitItem(CoinDealMyOrderDataModel myOrderDataModel, int tradeIndex = 0)
		{
			this._myOrderDataModel = myOrderDataModel;
			if (this._myOrderDataModel == null)
			{
				return;
			}
			this.InitMyOrderItem();
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

		// Token: 0x0600D6C4 RID: 54980 RVA: 0x0035A898 File Offset: 0x00358C98
		private void InitMyOrderItem()
		{
			if (this.singlePriceValueLabel != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)this._myOrderDataModel.SinglePrice);
				this.singlePriceValueLabel.text = text;
				bool flag = CoinDealUtility.IsPriceInSinglePriceInterval((int)this._myOrderDataModel.SinglePrice);
				this.singlePriceValueLabel.color = ((!flag) ? Color.red : this.normalSinglePriceColor);
			}
			if (this.dealCoinValueLabel != null)
			{
				string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._myOrderDataModel.DealCoinNumber);
				this.dealCoinValueLabel.text = coinDealCommonCoinNumberStr;
			}
			this.UpdateLeftTimeLabel();
		}

		// Token: 0x0600D6C5 RID: 54981 RVA: 0x0035A93C File Offset: 0x00358D3C
		private void UpdateLeftTimeLabel()
		{
			if (this.leftTimeValueLabel != null)
			{
				uint num = 0U;
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				if (this._myOrderDataModel.ExpireTimeStamp > serverTime)
				{
					num = this._myOrderDataModel.ExpireTimeStamp - serverTime;
				}
				string text = string.Empty;
				uint num2 = num / 3600U;
				if (num2 == 0U)
				{
					text = "<" + TR.Value("Coin_Deal_My_Order_Left_Time_Format", num2 + 1U);
				}
				else
				{
					text = TR.Value("Coin_Deal_My_Order_Left_Time_Format", num2);
				}
				this.leftTimeValueLabel.text = text;
			}
		}

		// Token: 0x0600D6C6 RID: 54982 RVA: 0x0035A9D9 File Offset: 0x00358DD9
		public void UpdateItem()
		{
			if (this._myOrderDataModel == null)
			{
				return;
			}
			this.UpdateLeftTimeLabel();
		}

		// Token: 0x0600D6C7 RID: 54983 RVA: 0x0035A9ED File Offset: 0x00358DED
		public void RecycleItem()
		{
			this._myOrderDataModel = null;
		}

		// Token: 0x0600D6C8 RID: 54984 RVA: 0x0035A9F8 File Offset: 0x00358DF8
		private void OnCancelButtonClick()
		{
			if (this._myOrderDataModel == null)
			{
				return;
			}
			if (this._myOrderDataModel.OrderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				this.OnCancelBuyOrder();
			}
			else if (this._myOrderDataModel.OrderType == GoldConsignmentOrderType.GCOT_SELL)
			{
				this.OnCancelSellOrder();
			}
		}

		// Token: 0x0600D6C9 RID: 54985 RVA: 0x0035AA44 File Offset: 0x00358E44
		private void OnCancelBuyOrder()
		{
			if (DataManager<CoinDealDataManager>.GetInstance().IsNotShowBuyOrderCancelTip)
			{
				this.OnSendCancelOrderReq();
				return;
			}
			string contentStr = TR.Value("Coin_Deal_Cancel_Buy_Tip_Format");
			CoinDealUtility.OnOpenCancelMyOrderTipFrame(this._myOrderDataModel, contentStr);
		}

		// Token: 0x0600D6CA RID: 54986 RVA: 0x0035AA80 File Offset: 0x00358E80
		private void OnCancelSellOrder()
		{
			if (DataManager<CoinDealDataManager>.GetInstance().IsNotShowSellOrderCancelTip)
			{
				this.OnSendCancelOrderReq();
				return;
			}
			string contentStr = TR.Value("Coin_Deal_Cancel_Sell_Tip_Format");
			CoinDealUtility.OnOpenCancelMyOrderTipFrame(this._myOrderDataModel, contentStr);
		}

		// Token: 0x0600D6CB RID: 54987 RVA: 0x0035AABA File Offset: 0x00358EBA
		private void OnSendCancelOrderReq()
		{
			if (this._myOrderDataModel == null)
			{
				return;
			}
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentCancelOrderReq(this._myOrderDataModel.OrderId, this._myOrderDataModel.OrderType);
		}

		// Token: 0x04007E11 RID: 32273
		private CoinDealMyOrderDataModel _myOrderDataModel;

		// Token: 0x04007E12 RID: 32274
		[Space(10f)]
		[Header("MyDeal")]
		[Space(10f)]
		[SerializeField]
		private Text singlePriceValueLabel;

		// Token: 0x04007E13 RID: 32275
		[SerializeField]
		private Text dealCoinValueLabel;

		// Token: 0x04007E14 RID: 32276
		[SerializeField]
		private Text leftTimeValueLabel;

		// Token: 0x04007E15 RID: 32277
		[SerializeField]
		private Button cancelButton;

		// Token: 0x04007E16 RID: 32278
		[Space(10f)]
		[Header("BgColor")]
		[Space(10f)]
		[SerializeField]
		private Image bgImage;

		// Token: 0x04007E17 RID: 32279
		[SerializeField]
		private Color normalColor;

		// Token: 0x04007E18 RID: 32280
		[SerializeField]
		private Color specialColor;

		// Token: 0x04007E19 RID: 32281
		[Space(10f)]
		[Header("SinglePriceColor")]
		[Space(10f)]
		[SerializeField]
		private Color normalSinglePriceColor;
	}
}

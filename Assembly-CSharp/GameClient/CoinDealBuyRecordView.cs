using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001589 RID: 5513
	public class CoinDealBuyRecordView : MonoBehaviour
	{
		// Token: 0x0600D7C9 RID: 55241 RVA: 0x0035EE0B File Offset: 0x0035D20B
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D7CA RID: 55242 RVA: 0x0035EE13 File Offset: 0x0035D213
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D7CB RID: 55243 RVA: 0x0035EE21 File Offset: 0x0035D221
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x0600D7CC RID: 55244 RVA: 0x0035EE60 File Offset: 0x0035D260
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D7CD RID: 55245 RVA: 0x0035EE83 File Offset: 0x0035D283
		private void ClearData()
		{
			this._submitBuyOrderDataModel = null;
		}

		// Token: 0x0600D7CE RID: 55246 RVA: 0x0035EE8C File Offset: 0x0035D28C
		public void InitView()
		{
			this._submitBuyOrderDataModel = DataManager<CoinDealDataManager>.GetInstance().CoinDealSubmitOrderDataModelWithBuy;
			this.InitBaseView();
			this.UpdateContentView();
		}

		// Token: 0x0600D7CF RID: 55247 RVA: 0x0035EEAC File Offset: 0x0035D2AC
		private void InitBaseView()
		{
			if (this.dealTipLabel != null)
			{
				this.dealTipLabel.text = TR.Value("Coin_Deal_Buy_Succeed_Title_Label");
			}
			if (this.averagePriceTitleLabel != null)
			{
				int coinDealBaseSinglePriceByCoinNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseSinglePriceByCoinNumber();
				string text = TR.Value("Coin_Deal_Deal_Record_Average_Price_Format", coinDealBaseSinglePriceByCoinNumber);
				this.averagePriceTitleLabel.text = text;
			}
			if (this.closeTipLabel != null)
			{
				this.closeTipLabel.text = TR.Value("Coin_Deal_Deal_Record_Close_Tip_Content");
			}
		}

		// Token: 0x0600D7D0 RID: 55248 RVA: 0x0035EF40 File Offset: 0x0035D340
		private void UpdateContentView()
		{
			if (this._submitBuyOrderDataModel == null)
			{
				return;
			}
			if (this.buyValueLabel != null)
			{
				string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._submitBuyOrderDataModel.DealTotalNumber);
				this.buyValueLabel.text = coinDealCommonCoinNumberStr;
			}
			if (this.payValueLabel != null)
			{
				this.payValueLabel.text = this._submitBuyOrderDataModel.PayNumber.ToString();
			}
			if (this.unBuyValueLabel != null)
			{
				string coinDealCommonCoinNumberStr2 = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._submitBuyOrderDataModel.UnDealNumber);
				this.unBuyValueLabel.text = coinDealCommonCoinNumberStr2;
			}
			if (this.returnValueLabel != null)
			{
				this.returnValueLabel.text = this._submitBuyOrderDataModel.ReturnNumber.ToString();
			}
			if (this.averagePriceValueLabel != null)
			{
				this.averagePriceValueLabel.text = this._submitBuyOrderDataModel.SinglePrice.ToString();
			}
		}

		// Token: 0x0600D7D1 RID: 55249 RVA: 0x0035F04B File Offset: 0x0035D44B
		private void OnCloseButtonClick()
		{
			if (this._submitBuyOrderDataModel != null && this._submitBuyOrderDataModel.UnDealNumber > 0U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Left_Buy_Deal_Label"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.CloseFrame();
		}

		// Token: 0x0600D7D2 RID: 55250 RVA: 0x0035F080 File Offset: 0x0035D480
		private void CloseFrame()
		{
			CoinDealUtility.OnCloseCoinDealBuyRecordFrame();
		}

		// Token: 0x04007EA4 RID: 32420
		private CoinDealSubmitOrderDataModel _submitBuyOrderDataModel;

		// Token: 0x04007EA5 RID: 32421
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text dealTipLabel;

		// Token: 0x04007EA6 RID: 32422
		[SerializeField]
		private Text closeTipLabel;

		// Token: 0x04007EA7 RID: 32423
		[Space(10f)]
		[Header("Value")]
		[Space(10f)]
		[SerializeField]
		private Text buyValueLabel;

		// Token: 0x04007EA8 RID: 32424
		[SerializeField]
		private Text payValueLabel;

		// Token: 0x04007EA9 RID: 32425
		[SerializeField]
		private Text unBuyValueLabel;

		// Token: 0x04007EAA RID: 32426
		[SerializeField]
		private Text returnValueLabel;

		// Token: 0x04007EAB RID: 32427
		[Space(10f)]
		[Header("AveragePrice")]
		[Space(10f)]
		[SerializeField]
		private Text averagePriceTitleLabel;

		// Token: 0x04007EAC RID: 32428
		[SerializeField]
		private Text averagePriceValueLabel;

		// Token: 0x04007EAD RID: 32429
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}

using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200158B RID: 5515
	public class CoinDealSellRecordView : MonoBehaviour
	{
		// Token: 0x0600D7DA RID: 55258 RVA: 0x0035F0EF File Offset: 0x0035D4EF
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D7DB RID: 55259 RVA: 0x0035F0F7 File Offset: 0x0035D4F7
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D7DC RID: 55260 RVA: 0x0035F105 File Offset: 0x0035D505
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x0600D7DD RID: 55261 RVA: 0x0035F144 File Offset: 0x0035D544
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D7DE RID: 55262 RVA: 0x0035F167 File Offset: 0x0035D567
		private void ClearData()
		{
			this._submitSellOrderDataModel = null;
		}

		// Token: 0x0600D7DF RID: 55263 RVA: 0x0035F170 File Offset: 0x0035D570
		public void InitView()
		{
			this._submitSellOrderDataModel = DataManager<CoinDealDataManager>.GetInstance().CoinDealSubmitOrderDataModelWithSell;
			this.InitBaseView();
			this.UpdateContentView();
		}

		// Token: 0x0600D7E0 RID: 55264 RVA: 0x0035F190 File Offset: 0x0035D590
		private void InitBaseView()
		{
			if (this.dealTipLabel != null)
			{
				this.dealTipLabel.text = TR.Value("Coin_Deal_Sell_Succeed_Title_Label");
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
			ItemTable creditTicketItemTable = DataManager<CoinDealDataManager>.GetInstance().GetCreditTicketItemTable();
			if (creditTicketItemTable != null)
			{
				string icon = creditTicketItemTable.Icon;
				if (!string.IsNullOrEmpty(icon))
				{
					if (this.creditTicketIconOne != null)
					{
						ETCImageLoader.LoadSprite(ref this.creditTicketIconOne, icon, true);
					}
					if (this.creditTicketIconTwo != null)
					{
						ETCImageLoader.LoadSprite(ref this.creditTicketIconTwo, icon, true);
					}
				}
			}
		}

		// Token: 0x0600D7E1 RID: 55265 RVA: 0x0035F284 File Offset: 0x0035D684
		private void UpdateContentView()
		{
			if (this._submitSellOrderDataModel == null)
			{
				return;
			}
			if (this.soldOutValueLabel != null)
			{
				string coinDealCommonCoinNumberStr = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._submitSellOrderDataModel.DealTotalNumber);
				this.soldOutValueLabel.text = coinDealCommonCoinNumberStr;
			}
			if (this.dealReceiveValueLabel != null)
			{
				this.dealReceiveValueLabel.text = this._submitSellOrderDataModel.ReceiveNumber.ToString();
			}
			if (this.unSoldValueLabel != null)
			{
				string coinDealCommonCoinNumberStr2 = CoinDealUtility.GetCoinDealCommonCoinNumberStr((int)this._submitSellOrderDataModel.UnDealNumber);
				this.unSoldValueLabel.text = coinDealCommonCoinNumberStr2;
			}
			if (this.feeRateValueLabel != null)
			{
				this.feeRateValueLabel.text = this._submitSellOrderDataModel.FeeValueNumber.ToString();
			}
			if (this.averagePriceValueLabel != null)
			{
				this.averagePriceValueLabel.text = this._submitSellOrderDataModel.SinglePrice.ToString();
			}
		}

		// Token: 0x0600D7E2 RID: 55266 RVA: 0x0035F38F File Offset: 0x0035D78F
		private void OnCloseButtonClick()
		{
			if (this._submitSellOrderDataModel != null && this._submitSellOrderDataModel.UnDealNumber > 0U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Coin_Deal_Left_Sell_Deal_Label"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			this.CloseFrame();
		}

		// Token: 0x0600D7E3 RID: 55267 RVA: 0x0035F3C4 File Offset: 0x0035D7C4
		private void CloseFrame()
		{
			CoinDealUtility.OnCloseCoinDealSellRecordFrame();
		}

		// Token: 0x04007EAF RID: 32431
		private CoinDealSubmitOrderDataModel _submitSellOrderDataModel;

		// Token: 0x04007EB0 RID: 32432
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text dealTipLabel;

		// Token: 0x04007EB1 RID: 32433
		[SerializeField]
		private Text closeTipLabel;

		// Token: 0x04007EB2 RID: 32434
		[Space(10f)]
		[Header("Image")]
		[Space(10f)]
		[SerializeField]
		private Image creditTicketIconOne;

		// Token: 0x04007EB3 RID: 32435
		[SerializeField]
		private Image creditTicketIconTwo;

		// Token: 0x04007EB4 RID: 32436
		[Space(10f)]
		[Header("Value")]
		[Space(10f)]
		[SerializeField]
		private Text soldOutValueLabel;

		// Token: 0x04007EB5 RID: 32437
		[SerializeField]
		private Text dealReceiveValueLabel;

		// Token: 0x04007EB6 RID: 32438
		[SerializeField]
		private Text unSoldValueLabel;

		// Token: 0x04007EB7 RID: 32439
		[SerializeField]
		private Text feeRateValueLabel;

		// Token: 0x04007EB8 RID: 32440
		[Space(10f)]
		[Header("AveragePrice")]
		[Space(10f)]
		[SerializeField]
		private Text averagePriceTitleLabel;

		// Token: 0x04007EB9 RID: 32441
		[SerializeField]
		private Text averagePriceValueLabel;

		// Token: 0x04007EBA RID: 32442
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}

using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001578 RID: 5496
	public class CoinDealView : MonoBehaviour
	{
		// Token: 0x0600D6AE RID: 54958 RVA: 0x0035A0C6 File Offset: 0x003584C6
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D6AF RID: 54959 RVA: 0x0035A0CE File Offset: 0x003584CE
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D6B0 RID: 54960 RVA: 0x0035A0DC File Offset: 0x003584DC
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealSwitchToMyOrderTabMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealSwitchToMyOrderTabMessage));
		}

		// Token: 0x0600D6B1 RID: 54961 RVA: 0x0035A15C File Offset: 0x0035855C
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealAveragePriceUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealAveragePriceUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealSwitchToMyOrderTabMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealSwitchToMyOrderTabMessage));
		}

		// Token: 0x0600D6B2 RID: 54962 RVA: 0x0035A1C0 File Offset: 0x003585C0
		private void ClearData()
		{
			this._preTabType = CoinDealTabType.None;
			this._coinViewTabDataList = null;
			this._refreshTimeInterval = -1f;
		}

		// Token: 0x0600D6B3 RID: 54963 RVA: 0x0035A1DB File Offset: 0x003585DB
		public void InitView()
		{
			this._refreshTimeInterval = 1f;
			DataManager<CoinDealDataManager>.GetInstance().RequestCoinDealOrderItemData();
			this.InitTitleLabel();
			this.InitAveragePriceLabel();
			this.InitCoinDealTab();
			this.InitMoneyControl();
			this.InitCoinDealOpenTime();
		}

		// Token: 0x0600D6B4 RID: 54964 RVA: 0x0035A210 File Offset: 0x00358610
		private void InitTitleLabel()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("Coin_Deal_Title_Label");
			}
		}

		// Token: 0x0600D6B5 RID: 54965 RVA: 0x0035A238 File Offset: 0x00358638
		private void InitAveragePriceLabel()
		{
			if (this.coinDealAveragePriceTitleLabel != null)
			{
				int coinDealBaseSinglePriceByCoinNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealBaseSinglePriceByCoinNumber();
				string text = TR.Value("Coin_Deal_Pre_Day_Deal_Format", coinDealBaseSinglePriceByCoinNumber);
				if (this.coinDealAveragePriceTitleLabel != null)
				{
					this.coinDealAveragePriceTitleLabel.text = text;
				}
			}
			this.UpdateAveragePriceValueLabel();
		}

		// Token: 0x0600D6B6 RID: 54966 RVA: 0x0035A298 File Offset: 0x00358698
		private void UpdateAveragePriceValueLabel()
		{
			if (this.coinDealAveragePriceValueLabel == null)
			{
				return;
			}
			int coinDealAveragePriceValue = DataManager<CoinDealDataManager>.GetInstance().CoinDealAveragePriceValue;
			string text = Utility.ToThousandsSeparator((ulong)((long)coinDealAveragePriceValue));
			this.coinDealAveragePriceValueLabel.text = text;
		}

		// Token: 0x0600D6B7 RID: 54967 RVA: 0x0035A2D8 File Offset: 0x003586D8
		private void InitMoneyControl()
		{
			if (this.coinControl != null)
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
				this.coinControl.InitMoneyItem(moneyIDByType, false, string.Empty);
			}
			if (this.pointTicketControl != null)
			{
				int moneyIDByType2 = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
				this.pointTicketControl.InitMoneyItem(moneyIDByType2, false, string.Empty);
			}
			if (this.creditTicketNumberControl != null)
			{
				int moneyIDByType3 = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_CREDIT_POINT);
				this.creditTicketNumberControl.InitControl(moneyIDByType3);
			}
		}

		// Token: 0x0600D6B8 RID: 54968 RVA: 0x0035A374 File Offset: 0x00358774
		private void InitCoinDealOpenTime()
		{
			if (this.openTimeLabel == null)
			{
				return;
			}
			string coinDealOpenTimeStr = CoinDealUtility.GetCoinDealOpenTimeStr();
			this.openTimeLabel.text = coinDealOpenTimeStr;
		}

		// Token: 0x0600D6B9 RID: 54969 RVA: 0x0035A3A8 File Offset: 0x003587A8
		private void InitCoinDealTab()
		{
			this._selectedTabId = 1;
			this._coinViewTabDataList = CoinDealUtility.GetComControlDataInCoinDeal();
			if (this.toggleControl != null)
			{
				this.toggleControl.InitComToggleControl(this._coinViewTabDataList, new OnComToggleClick(this.OnComToggleClick));
			}
			this.UpdateCoinDealTabContent();
		}

		// Token: 0x0600D6BA RID: 54970 RVA: 0x0035A3FB File Offset: 0x003587FB
		private void OnComToggleClick(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (comControlData.Id == this._selectedTabId)
			{
				return;
			}
			this._selectedTabId = comControlData.Id;
			this.UpdateCoinDealTabContent();
		}

		// Token: 0x0600D6BB RID: 54971 RVA: 0x0035A428 File Offset: 0x00358828
		private void UpdateCoinDealTabContent()
		{
			CoinDealTabType selectedTabId = (CoinDealTabType)this._selectedTabId;
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRecordTab = false;
			if (selectedTabId == CoinDealTabType.MyOrder)
			{
				CommonUtility.UpdateGameObjectVisible(this.tradeViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.recordViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.myOrderViewRoot, true);
				if (this._myOrderView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.myOrderViewRoot);
					if (gameObject != null)
					{
						this._myOrderView = gameObject.GetComponent<CoinDealMyOrderView>();
					}
					if (this._myOrderView != null)
					{
						this._myOrderView.InitView();
					}
				}
				else
				{
					this._myOrderView.OnEnableView();
				}
			}
			else if (selectedTabId == CoinDealTabType.Record)
			{
				DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRecordTab = true;
				if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRedPoint)
				{
					DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRedPoint = false;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, null, null, null, null);
				}
				CommonUtility.UpdateGameObjectVisible(this.tradeViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.myOrderViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.recordViewRoot, true);
				if (this._recordView == null)
				{
					GameObject gameObject2 = CommonUtility.LoadGameObject(this.recordViewRoot);
					if (gameObject2 != null)
					{
						this._recordView = gameObject2.GetComponent<CoinDealRecordView>();
					}
					if (this._recordView != null)
					{
						this._recordView.InitView();
					}
				}
				else
				{
					this._recordView.OnEnableView();
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.myOrderViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.recordViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.tradeViewRoot, true);
				GoldConsignmentOrderType orderType = GoldConsignmentOrderType.GCOT_BUY;
				if (selectedTabId == CoinDealTabType.TradeWithSell)
				{
					orderType = GoldConsignmentOrderType.GCOT_SELL;
				}
				if (this._tradeView == null)
				{
					GameObject gameObject3 = CommonUtility.LoadGameObject(this.tradeViewRoot);
					if (gameObject3 != null)
					{
						this._tradeView = gameObject3.GetComponent<CoinDealTradeView>();
					}
					if (this._tradeView != null)
					{
						this._tradeView.InitView(orderType);
					}
				}
				else if (this._preTabType != CoinDealTabType.TradeWithBuy && this._preTabType != CoinDealTabType.TradeWithSell)
				{
					this._tradeView.OnEnableView(orderType);
				}
				else
				{
					this._tradeView.OnUpdateView(orderType);
				}
			}
			this._preTabType = selectedTabId;
		}

		// Token: 0x0600D6BC RID: 54972 RVA: 0x0035A666 File Offset: 0x00358A66
		private void OnCloseButtonClick()
		{
			CoinDealUtility.OnCloseCoinDealFrame();
		}

		// Token: 0x0600D6BD RID: 54973 RVA: 0x0035A66D File Offset: 0x00358A6D
		private void OnReceiveCoinDealAveragePriceUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateAveragePriceValueLabel();
		}

		// Token: 0x0600D6BE RID: 54974 RVA: 0x0035A678 File Offset: 0x00358A78
		private void OnReceiveCoinDealSwitchToMyOrderTabMessage(UIEvent uiEvent)
		{
			int num = 3;
			if (this._coinViewTabDataList == null || this._coinViewTabDataList.Count <= 0)
			{
				return;
			}
			int num2 = -1;
			for (int i = 0; i < this._coinViewTabDataList.Count; i++)
			{
				ComControlData comControlData = this._coinViewTabDataList[i];
				if (comControlData != null)
				{
					if (comControlData.Id == num)
					{
						num2 = i;
						break;
					}
				}
			}
			if (this.toggleControl != null && num2 >= 0)
			{
				this.toggleControl.SetComToggleIsOnByIndex(num2);
			}
		}

		// Token: 0x0600D6BF RID: 54975 RVA: 0x0035A714 File Offset: 0x00358B14
		private void Update()
		{
			this._refreshTimeInterval -= Time.deltaTime;
			if (this._refreshTimeInterval < 0f)
			{
				if (DataManager<CoinDealDataManager>.GetInstance().CloseMarketStartTimeStamp != 0 && DataManager<CoinDealDataManager>.GetInstance().CloseMarketEndTimeStamp != 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRefreshCloseMarketControlMessage, null, null, null, null);
					if ((ulong)DataManager<TimeManager>.GetInstance().GetServerTime() == (ulong)((long)DataManager<CoinDealDataManager>.GetInstance().CloseMarketEndTimeStamp))
					{
						DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestTradeItemData = true;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveCoinDealRequestTradeItemData, null, null, null, null);
					}
				}
				this._refreshTimeInterval = 1f;
			}
		}

		// Token: 0x04007DFE RID: 32254
		private int _selectedTabId = 1;

		// Token: 0x04007DFF RID: 32255
		private CoinDealTabType _preTabType;

		// Token: 0x04007E00 RID: 32256
		private CoinDealTradeView _tradeView;

		// Token: 0x04007E01 RID: 32257
		private CoinDealMyOrderView _myOrderView;

		// Token: 0x04007E02 RID: 32258
		private CoinDealRecordView _recordView;

		// Token: 0x04007E03 RID: 32259
		private List<ComControlData> _coinViewTabDataList;

		// Token: 0x04007E04 RID: 32260
		private float _refreshTimeInterval = 1f;

		// Token: 0x04007E05 RID: 32261
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007E06 RID: 32262
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007E07 RID: 32263
		[Space(10f)]
		[Header("Tab")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControl toggleControl;

		// Token: 0x04007E08 RID: 32264
		[SerializeField]
		private GameObject tradeViewRoot;

		// Token: 0x04007E09 RID: 32265
		[SerializeField]
		private GameObject myOrderViewRoot;

		// Token: 0x04007E0A RID: 32266
		[SerializeField]
		private GameObject recordViewRoot;

		// Token: 0x04007E0B RID: 32267
		[Space(10f)]
		[Header("BaseContent")]
		[Space(10f)]
		[SerializeField]
		private Text coinDealAveragePriceTitleLabel;

		// Token: 0x04007E0C RID: 32268
		[SerializeField]
		private Text coinDealAveragePriceValueLabel;

		// Token: 0x04007E0D RID: 32269
		[Space(10f)]
		[Header("MoneyRoot")]
		[Space(10f)]
		[SerializeField]
		private CommonMoneyControl coinControl;

		// Token: 0x04007E0E RID: 32270
		[SerializeField]
		private CommonMoneyControl pointTicketControl;

		// Token: 0x04007E0F RID: 32271
		[SerializeField]
		private CreditTicketNumberControl creditTicketNumberControl;

		// Token: 0x04007E10 RID: 32272
		[Space(10f)]
		[Header("OpenTime")]
		[Space(10f)]
		[SerializeField]
		private Text openTimeLabel;
	}
}

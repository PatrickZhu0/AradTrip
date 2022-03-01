using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200157D RID: 5501
	public class CoinDealMyOrderView : MonoBehaviour
	{
		// Token: 0x0600D6E1 RID: 55009 RVA: 0x0035AF7A File Offset: 0x0035937A
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600D6E2 RID: 55010 RVA: 0x0035AF82 File Offset: 0x00359382
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600D6E3 RID: 55011 RVA: 0x0035AF90 File Offset: 0x00359390
		private void BindEvents()
		{
			if (this.myOrderItemListExWithSell != null)
			{
				this.myOrderItemListExWithSell.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.myOrderItemListExWithSell;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.myOrderItemListExWithSell;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
				ComUIListScriptEx comUIListScriptEx3 = this.myOrderItemListExWithSell;
				comUIListScriptEx3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnSellItemUpdate));
			}
			if (this.myOrderItemListExWithBuy != null)
			{
				this.myOrderItemListExWithBuy.Initialize();
				ComUIListScriptEx comUIListScriptEx4 = this.myOrderItemListExWithBuy;
				comUIListScriptEx4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx5 = this.myOrderItemListExWithBuy;
				comUIListScriptEx5.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx5.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemRecycle));
				ComUIListScriptEx comUIListScriptEx6 = this.myOrderItemListExWithBuy;
				comUIListScriptEx6.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx6.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnBuyItemUpdate));
			}
		}

		// Token: 0x0600D6E4 RID: 55012 RVA: 0x0035B0C0 File Offset: 0x003594C0
		private void UnBindEvents()
		{
			if (this.myOrderItemListExWithSell != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.myOrderItemListExWithSell;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.myOrderItemListExWithSell;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
				ComUIListScriptEx comUIListScriptEx3 = this.myOrderItemListExWithSell;
				comUIListScriptEx3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnSellItemUpdate));
			}
			if (this.myOrderItemListExWithBuy != null)
			{
				ComUIListScriptEx comUIListScriptEx4 = this.myOrderItemListExWithBuy;
				comUIListScriptEx4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx5 = this.myOrderItemListExWithBuy;
				comUIListScriptEx5.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx5.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemRecycle));
				ComUIListScriptEx comUIListScriptEx6 = this.myOrderItemListExWithBuy;
				comUIListScriptEx6.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx6.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnBuyItemUpdate));
			}
		}

		// Token: 0x0600D6E5 RID: 55013 RVA: 0x0035B1D9 File Offset: 0x003595D9
		private void ClearData()
		{
			this._myOrderDataModelListWithBuy.Clear();
			this._myOrderDataModelListWithSell.Clear();
			this.ResetRefreshTimeInterval();
		}

		// Token: 0x0600D6E6 RID: 55014 RVA: 0x0035B1F7 File Offset: 0x003595F7
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600D6E7 RID: 55015 RVA: 0x0035B1FF File Offset: 0x003595FF
		private void OnDisable()
		{
			this.UnBindUiMessages();
			this.ResetRefreshTimeInterval();
		}

		// Token: 0x0600D6E8 RID: 55016 RVA: 0x0035B210 File Offset: 0x00359610
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderMessageRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderNumberUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderNumberUpdateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestMyOrderItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRefreshMyOrderItemData));
		}

		// Token: 0x0600D6E9 RID: 55017 RVA: 0x0035B270 File Offset: 0x00359670
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderMessageRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealOwnerOrderNumberUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealOwnerOrderNumberUpdateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestMyOrderItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRefreshMyOrderItemData));
		}

		// Token: 0x0600D6EA RID: 55018 RVA: 0x0035B2CE File Offset: 0x003596CE
		public void InitView()
		{
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestMyOrderItemData = false;
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentOwnerOrderReq();
			this.SetRefreshTimeInterval();
			this.InitTitle();
			this.UpdateCoinDealOrderItemList();
		}

		// Token: 0x0600D6EB RID: 55019 RVA: 0x0035B2F7 File Offset: 0x003596F7
		public void OnEnableView()
		{
			this.SetRefreshTimeInterval();
			if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestMyOrderItemData)
			{
				DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestMyOrderItemData = false;
				DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentOwnerOrderReq();
			}
			else
			{
				this.UpdateMyOrderTitleLabel();
				this.UpdateCoinDealOrderItemList();
			}
		}

		// Token: 0x0600D6EC RID: 55020 RVA: 0x0035B334 File Offset: 0x00359734
		private void InitTitle()
		{
			string coinDealCommonSinglePriceStr = CoinDealUtility.GetCoinDealCommonSinglePriceStr();
			if (this.buyTipLabel != null)
			{
				this.buyTipLabel.text = TR.Value("Coin_Deal_My_Deal_Buy_Title_Label");
			}
			if (this.buySinglePriceLabel != null)
			{
				this.buySinglePriceLabel.text = coinDealCommonSinglePriceStr;
			}
			if (this.buyCoinLabel != null)
			{
				this.buyCoinLabel.text = TR.Value("Coin_Deal_Deal_Buy_Coin_Total_Label");
			}
			if (this.sellTipLabel != null)
			{
				this.sellTipLabel.text = TR.Value("Coin_Deal_My_Deal_Sell_Title_Label");
			}
			if (this.sellSinglePriceLabel != null)
			{
				this.sellSinglePriceLabel.text = coinDealCommonSinglePriceStr;
			}
			if (this.sellCoinLabel != null)
			{
				this.sellCoinLabel.text = TR.Value("Coin_Deal_Deal_Sell_Coin_Total_Label");
			}
			this.UpdateMyOrderTitleLabel();
		}

		// Token: 0x0600D6ED RID: 55021 RVA: 0x0035B420 File Offset: 0x00359820
		private void UpdateMyOrderTitleLabel()
		{
			int coinDealSubmitOrderMaxNumber = DataManager<CoinDealDataManager>.GetInstance().GetCoinDealSubmitOrderMaxNumber();
			int coinDealOwnerOrderNumberWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithBuy;
			int coinDealOwnerOrderNumberWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealOwnerOrderNumberWithSell;
			if (this.buyOrderLabel != null)
			{
				string text = TR.Value("Coin_Deal_Account_Buy_Order_Format", coinDealOwnerOrderNumberWithBuy, coinDealSubmitOrderMaxNumber);
				this.buyOrderLabel.text = text;
			}
			if (this.sellOrderLabel != null)
			{
				string text2 = TR.Value("Coin_Deal_Account_Sell_Order_Format", coinDealOwnerOrderNumberWithSell, coinDealSubmitOrderMaxNumber);
				this.sellOrderLabel.text = text2;
			}
		}

		// Token: 0x0600D6EE RID: 55022 RVA: 0x0035B4B8 File Offset: 0x003598B8
		public void UpdateCoinDealOrderItemList()
		{
			this.UpdateCoinDealMyOrderItemListWithBuy();
			this.UpdateCoinDealMyOrderItemListWithSell();
		}

		// Token: 0x0600D6EF RID: 55023 RVA: 0x0035B4C8 File Offset: 0x003598C8
		private void UpdateCoinDealMyOrderDataListWithBuy()
		{
			List<CoinDealMyOrderDataModel> coinDealMyOrderDataModelListWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealMyOrderDataModelListWithBuy;
			this._myOrderDataModelListWithBuy.Clear();
			if (coinDealMyOrderDataModelListWithBuy != null && coinDealMyOrderDataModelListWithBuy.Count > 0)
			{
				for (int i = 0; i < coinDealMyOrderDataModelListWithBuy.Count; i++)
				{
					CoinDealMyOrderDataModel coinDealMyOrderDataModel = coinDealMyOrderDataModelListWithBuy[i];
					if (coinDealMyOrderDataModel != null)
					{
						if (DataManager<TimeManager>.GetInstance().GetServerTime() <= coinDealMyOrderDataModel.ExpireTimeStamp)
						{
							this._myOrderDataModelListWithBuy.Add(coinDealMyOrderDataModel);
						}
					}
				}
			}
		}

		// Token: 0x0600D6F0 RID: 55024 RVA: 0x0035B550 File Offset: 0x00359950
		private void UpdateCoinDealMyOrderItemListWithBuy()
		{
			this.UpdateCoinDealMyOrderDataListWithBuy();
			int elementAmount = 0;
			if (this._myOrderDataModelListWithBuy != null)
			{
				elementAmount = this._myOrderDataModelListWithBuy.Count;
			}
			if (this.myOrderItemListExWithBuy != null)
			{
				this.myOrderItemListExWithBuy.ResetComUiListScriptEx();
				this.myOrderItemListExWithBuy.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D6F1 RID: 55025 RVA: 0x0035B5A4 File Offset: 0x003599A4
		private void UpdateCoinDealMyOrderDataListWithSell()
		{
			List<CoinDealMyOrderDataModel> coinDealMyOrderDataModelListWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealMyOrderDataModelListWithSell;
			this._myOrderDataModelListWithSell.Clear();
			if (coinDealMyOrderDataModelListWithSell != null && coinDealMyOrderDataModelListWithSell.Count > 0)
			{
				for (int i = 0; i < coinDealMyOrderDataModelListWithSell.Count; i++)
				{
					CoinDealMyOrderDataModel coinDealMyOrderDataModel = coinDealMyOrderDataModelListWithSell[i];
					if (coinDealMyOrderDataModel != null)
					{
						if (DataManager<TimeManager>.GetInstance().GetServerTime() <= coinDealMyOrderDataModel.ExpireTimeStamp)
						{
							this._myOrderDataModelListWithSell.Add(coinDealMyOrderDataModel);
						}
					}
				}
			}
		}

		// Token: 0x0600D6F2 RID: 55026 RVA: 0x0035B62C File Offset: 0x00359A2C
		private void UpdateCoinDealMyOrderItemListWithSell()
		{
			this.UpdateCoinDealMyOrderDataListWithSell();
			int elementAmount = 0;
			if (this._myOrderDataModelListWithSell != null)
			{
				elementAmount = this._myOrderDataModelListWithSell.Count;
			}
			if (this.myOrderItemListExWithSell != null)
			{
				this.myOrderItemListExWithSell.ResetComUiListScriptEx();
				this.myOrderItemListExWithSell.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D6F3 RID: 55027 RVA: 0x0035B680 File Offset: 0x00359A80
		private void RefreshCoinDealMyOrderItemListByTimeStamp()
		{
			bool flag = this.IsExistMyOrderItemExpire(this._myOrderDataModelListWithBuy);
			if (!flag)
			{
				flag = this.IsExistMyOrderItemExpire(this._myOrderDataModelListWithSell);
			}
			if (flag)
			{
				this.UpdateCoinDealOrderItemList();
			}
			else
			{
				if (this.myOrderItemListExWithBuy != null)
				{
					this.myOrderItemListExWithBuy.UpdateElement();
				}
				if (this.myOrderItemListExWithSell != null)
				{
					this.myOrderItemListExWithSell.UpdateElement();
				}
			}
		}

		// Token: 0x0600D6F4 RID: 55028 RVA: 0x0035B6F6 File Offset: 0x00359AF6
		private void OnReceiveCoinDealOwnerOrderMessageRes(UIEvent uiEvent)
		{
			this.UpdateMyOrderTitleLabel();
			this.UpdateCoinDealOrderItemList();
		}

		// Token: 0x0600D6F5 RID: 55029 RVA: 0x0035B704 File Offset: 0x00359B04
		private void OnReceiveCoinDealOwnerOrderNumberUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateMyOrderTitleLabel();
		}

		// Token: 0x0600D6F6 RID: 55030 RVA: 0x0035B70C File Offset: 0x00359B0C
		private void OnReceiveCoinDealRefreshMyOrderItemData(UIEvent uiEvent)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestMyOrderItemData = false;
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentOwnerOrderReq();
			this.SetRefreshTimeInterval();
		}

		// Token: 0x0600D6F7 RID: 55031 RVA: 0x0035B72C File Offset: 0x00359B2C
		private void OnSellItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.myOrderItemListExWithSell == null)
			{
				return;
			}
			if (this._myOrderDataModelListWithSell == null || this._myOrderDataModelListWithSell.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._myOrderDataModelListWithSell.Count)
			{
				return;
			}
			CoinDealMyOrderDataModel coinDealMyOrderDataModel = this._myOrderDataModelListWithSell[item.m_index];
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealMyOrderDataModel != null)
			{
				component.InitItem(coinDealMyOrderDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D6F8 RID: 55032 RVA: 0x0035B7D4 File Offset: 0x00359BD4
		private void OnSellItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D6F9 RID: 55033 RVA: 0x0035B808 File Offset: 0x00359C08
		private void OnSellItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600D6FA RID: 55034 RVA: 0x0035B83C File Offset: 0x00359C3C
		private void OnBuyItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.myOrderItemListExWithBuy == null)
			{
				return;
			}
			if (this._myOrderDataModelListWithBuy == null || this._myOrderDataModelListWithBuy.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._myOrderDataModelListWithBuy.Count)
			{
				return;
			}
			CoinDealMyOrderDataModel coinDealMyOrderDataModel = this._myOrderDataModelListWithBuy[item.m_index];
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealMyOrderDataModel != null)
			{
				component.InitItem(coinDealMyOrderDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D6FB RID: 55035 RVA: 0x0035B8E4 File Offset: 0x00359CE4
		private void OnBuyItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D6FC RID: 55036 RVA: 0x0035B918 File Offset: 0x00359D18
		private void OnBuyItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealMyOrderItem component = item.GetComponent<CoinDealMyOrderItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600D6FD RID: 55037 RVA: 0x0035B94B File Offset: 0x00359D4B
		private void SetRefreshTimeInterval()
		{
			this._refreshTimeInterval = (float)DataManager<CoinDealDataManager>.GetInstance().GetCoinDealOrderPageRefreshTime();
		}

		// Token: 0x0600D6FE RID: 55038 RVA: 0x0035B95E File Offset: 0x00359D5E
		private void ResetRefreshTimeInterval()
		{
			this._refreshTimeInterval = -1f;
		}

		// Token: 0x0600D6FF RID: 55039 RVA: 0x0035B96C File Offset: 0x00359D6C
		private void Update()
		{
			if (this._refreshTimeInterval < 0f)
			{
				return;
			}
			this._refreshTimeInterval -= Time.deltaTime;
			if (this._refreshTimeInterval < 0f)
			{
				this.SetRefreshTimeInterval();
				this.RefreshCoinDealMyOrderItemListByTimeStamp();
			}
		}

		// Token: 0x0600D700 RID: 55040 RVA: 0x0035B9B8 File Offset: 0x00359DB8
		private bool IsExistMyOrderItemExpire(List<CoinDealMyOrderDataModel> orderDataModelList)
		{
			if (orderDataModelList == null || orderDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < orderDataModelList.Count; i++)
			{
				CoinDealMyOrderDataModel coinDealMyOrderDataModel = orderDataModelList[i];
				if (coinDealMyOrderDataModel != null)
				{
					if (DataManager<TimeManager>.GetInstance().GetServerTime() > coinDealMyOrderDataModel.ExpireTimeStamp)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04007E2D RID: 32301
		private List<CoinDealMyOrderDataModel> _myOrderDataModelListWithBuy = new List<CoinDealMyOrderDataModel>();

		// Token: 0x04007E2E RID: 32302
		private List<CoinDealMyOrderDataModel> _myOrderDataModelListWithSell = new List<CoinDealMyOrderDataModel>();

		// Token: 0x04007E2F RID: 32303
		private float _refreshTimeInterval = -1f;

		// Token: 0x04007E30 RID: 32304
		[Space(10f)]
		[Header("buy")]
		[Space(10f)]
		[SerializeField]
		private Text buyTipLabel;

		// Token: 0x04007E31 RID: 32305
		[SerializeField]
		private Text buySinglePriceLabel;

		// Token: 0x04007E32 RID: 32306
		[SerializeField]
		private Text buyCoinLabel;

		// Token: 0x04007E33 RID: 32307
		[SerializeField]
		private Text buyOrderLabel;

		// Token: 0x04007E34 RID: 32308
		[Space(10f)]
		[Header("sell")]
		[Space(10f)]
		[SerializeField]
		private Text sellTipLabel;

		// Token: 0x04007E35 RID: 32309
		[SerializeField]
		private Text sellSinglePriceLabel;

		// Token: 0x04007E36 RID: 32310
		[SerializeField]
		private Text sellCoinLabel;

		// Token: 0x04007E37 RID: 32311
		[SerializeField]
		private Text sellOrderLabel;

		// Token: 0x04007E38 RID: 32312
		[Space(10f)]
		[Header("MyOrderItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx myOrderItemListExWithBuy;

		// Token: 0x04007E39 RID: 32313
		[SerializeField]
		private ComUIListScriptEx myOrderItemListExWithSell;
	}
}

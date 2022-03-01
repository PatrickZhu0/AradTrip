using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200157E RID: 5502
	public class CoinDealRecordView : MonoBehaviour
	{
		// Token: 0x0600D702 RID: 55042 RVA: 0x0035BA23 File Offset: 0x00359E23
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600D703 RID: 55043 RVA: 0x0035BA2B File Offset: 0x00359E2B
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600D704 RID: 55044 RVA: 0x0035BA3C File Offset: 0x00359E3C
		private void BindEvents()
		{
			if (this.dealRecordSellItemListEx != null)
			{
				this.dealRecordSellItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.dealRecordSellItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.dealRecordSellItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
			}
			if (this.dealRecordBuyItemListEx != null)
			{
				this.dealRecordBuyItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx3 = this.dealRecordBuyItemListEx;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.dealRecordBuyItemListEx;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemRecycle));
			}
		}

		// Token: 0x0600D705 RID: 55045 RVA: 0x0035BB20 File Offset: 0x00359F20
		private void UnBindEvents()
		{
			if (this.dealRecordSellItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.dealRecordSellItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.dealRecordSellItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
			}
			if (this.dealRecordBuyItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx3 = this.dealRecordBuyItemListEx;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.dealRecordBuyItemListEx;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemVisible));
			}
		}

		// Token: 0x0600D706 RID: 55046 RVA: 0x0035BBEB File Offset: 0x00359FEB
		private void ClearData()
		{
			this._dealRecordDataModelListWithBuy = null;
			this._dealRecordDataModelListWithSell = null;
		}

		// Token: 0x0600D707 RID: 55047 RVA: 0x0035BBFB File Offset: 0x00359FFB
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600D708 RID: 55048 RVA: 0x0035BC03 File Offset: 0x0035A003
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600D709 RID: 55049 RVA: 0x0035BC0B File Offset: 0x0035A00B
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealRecordMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRecordMessageRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestRecordItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRequestRecordItemData));
		}

		// Token: 0x0600D70A RID: 55050 RVA: 0x0035BC43 File Offset: 0x0035A043
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealRecordMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRecordMessageRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestRecordItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRequestRecordItemData));
		}

		// Token: 0x0600D70B RID: 55051 RVA: 0x0035BC7B File Offset: 0x0035A07B
		public void InitView()
		{
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestRecordItemData = false;
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentDealRecordReq();
			this.InitTitle();
			this.UpdateCoinDealRecordItemList();
		}

		// Token: 0x0600D70C RID: 55052 RVA: 0x0035BC9E File Offset: 0x0035A09E
		public void OnEnableView()
		{
			if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestRecordItemData)
			{
				DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestRecordItemData = false;
				DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentDealRecordReq();
			}
			else
			{
				this.UpdateCoinDealRecordItemList();
			}
		}

		// Token: 0x0600D70D RID: 55053 RVA: 0x0035BCD0 File Offset: 0x0035A0D0
		private void InitTitle()
		{
			string coinDealCommonSinglePriceStr = CoinDealUtility.GetCoinDealCommonSinglePriceStr();
			string text = TR.Value("Coin_Deal_Record_Buy_Coin_Tip_Title");
			if (this.buyTipLabel != null)
			{
				string text2 = TR.Value("Coin_Deal_Record_Title_Format", text);
				this.buyTipLabel.text = text2;
			}
			if (this.buySinglePriceLabel != null)
			{
				this.buySinglePriceLabel.text = coinDealCommonSinglePriceStr;
			}
			if (this.buyCoinLabel != null)
			{
				this.buyCoinLabel.text = text;
			}
			if (this.buyCostLabel != null)
			{
				this.buyCostLabel.text = TR.Value("Coin_Deal_Record_Buy_Coin_Cost_Title");
			}
			string text3 = TR.Value("Coin_Deal_Record_Sell_Coin_Tip_Title");
			if (this.sellTipLabel != null)
			{
				string text4 = TR.Value("Coin_Deal_Record_Title_Format", text3);
				this.sellTipLabel.text = text4;
			}
			if (this.sellSinglePriceLabel != null)
			{
				this.sellSinglePriceLabel.text = coinDealCommonSinglePriceStr;
			}
			if (this.sellCoinLabel != null)
			{
				this.sellCoinLabel.text = text3;
			}
			if (this.sellReceiveLabel != null)
			{
				this.sellReceiveLabel.text = TR.Value("Coin_Deal_Record_Sell_Coin_Receive_Title");
			}
		}

		// Token: 0x0600D70E RID: 55054 RVA: 0x0035BE10 File Offset: 0x0035A210
		public void UpdateCoinDealRecordItemList()
		{
			this._dealRecordDataModelListWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealRecordDataModelListWithBuy;
			int elementAmount = 0;
			if (this._dealRecordDataModelListWithBuy != null)
			{
				elementAmount = this._dealRecordDataModelListWithBuy.Count;
			}
			if (this.dealRecordBuyItemListEx != null)
			{
				this.dealRecordBuyItemListEx.ResetComUiListScriptEx();
				this.dealRecordBuyItemListEx.SetElementAmount(elementAmount);
			}
			this._dealRecordDataModelListWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealRecordDataModelListWithSell;
			int elementAmount2 = 0;
			if (this._dealRecordDataModelListWithSell != null)
			{
				elementAmount2 = this._dealRecordDataModelListWithSell.Count;
			}
			if (this.dealRecordSellItemListEx != null)
			{
				this.dealRecordSellItemListEx.ResetComUiListScriptEx();
				this.dealRecordSellItemListEx.SetElementAmount(elementAmount2);
			}
		}

		// Token: 0x0600D70F RID: 55055 RVA: 0x0035BEBF File Offset: 0x0035A2BF
		private void OnReceiveCoinDealRecordMessageRes(UIEvent uiEvent)
		{
			this.UpdateCoinDealRecordItemList();
		}

		// Token: 0x0600D710 RID: 55056 RVA: 0x0035BEC7 File Offset: 0x0035A2C7
		private void OnReceiveCoinDealRequestRecordItemData(UIEvent uiEvent)
		{
			DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestRecordItemData = false;
			DataManager<CoinDealDataManager>.GetInstance().OnSendUnionGoldConsignmentDealRecordReq();
		}

		// Token: 0x0600D711 RID: 55057 RVA: 0x0035BEE0 File Offset: 0x0035A2E0
		private void OnBuyItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.dealRecordBuyItemListEx == null)
			{
				return;
			}
			if (this._dealRecordDataModelListWithBuy == null || this._dealRecordDataModelListWithBuy.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dealRecordDataModelListWithBuy.Count)
			{
				return;
			}
			CoinDealRecordDataModel coinDealRecordDataModel = this._dealRecordDataModelListWithBuy[item.m_index];
			CoinDealRecordItem component = item.GetComponent<CoinDealRecordItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealRecordDataModel != null)
			{
				component.InitItem(coinDealRecordDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D712 RID: 55058 RVA: 0x0035BF88 File Offset: 0x0035A388
		private void OnBuyItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealRecordItem component = item.GetComponent<CoinDealRecordItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D713 RID: 55059 RVA: 0x0035BFBC File Offset: 0x0035A3BC
		private void OnSellItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.dealRecordSellItemListEx == null)
			{
				return;
			}
			if (this._dealRecordDataModelListWithSell == null || this._dealRecordDataModelListWithSell.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dealRecordDataModelListWithSell.Count)
			{
				return;
			}
			CoinDealRecordDataModel coinDealRecordDataModel = this._dealRecordDataModelListWithSell[item.m_index];
			CoinDealRecordItem component = item.GetComponent<CoinDealRecordItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealRecordDataModel != null)
			{
				component.InitItem(coinDealRecordDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D714 RID: 55060 RVA: 0x0035C064 File Offset: 0x0035A464
		private void OnSellItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealRecordItem component = item.GetComponent<CoinDealRecordItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x04007E3A RID: 32314
		private List<CoinDealRecordDataModel> _dealRecordDataModelListWithBuy;

		// Token: 0x04007E3B RID: 32315
		private List<CoinDealRecordDataModel> _dealRecordDataModelListWithSell;

		// Token: 0x04007E3C RID: 32316
		[Space(10f)]
		[Header("buy")]
		[Space(10f)]
		[SerializeField]
		private Text buyTipLabel;

		// Token: 0x04007E3D RID: 32317
		[SerializeField]
		private Text buySinglePriceLabel;

		// Token: 0x04007E3E RID: 32318
		[SerializeField]
		private Text buyCoinLabel;

		// Token: 0x04007E3F RID: 32319
		[SerializeField]
		private Text buyCostLabel;

		// Token: 0x04007E40 RID: 32320
		[Space(10f)]
		[Header("sell")]
		[Space(10f)]
		[SerializeField]
		private Text sellTipLabel;

		// Token: 0x04007E41 RID: 32321
		[SerializeField]
		private Text sellSinglePriceLabel;

		// Token: 0x04007E42 RID: 32322
		[SerializeField]
		private Text sellCoinLabel;

		// Token: 0x04007E43 RID: 32323
		[SerializeField]
		private Text sellReceiveLabel;

		// Token: 0x04007E44 RID: 32324
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx dealRecordBuyItemListEx;

		// Token: 0x04007E45 RID: 32325
		[SerializeField]
		private ComUIListScriptEx dealRecordSellItemListEx;
	}
}

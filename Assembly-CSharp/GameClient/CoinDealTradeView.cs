using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200157F RID: 5503
	public class CoinDealTradeView : MonoBehaviour
	{
		// Token: 0x0600D716 RID: 55062 RVA: 0x0035C09F File Offset: 0x0035A49F
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600D717 RID: 55063 RVA: 0x0035C0A7 File Offset: 0x0035A4A7
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600D718 RID: 55064 RVA: 0x0035C0B8 File Offset: 0x0035A4B8
		private void BindEvents()
		{
			if (this.tradeItemListExWithSell != null)
			{
				this.tradeItemListExWithSell.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.tradeItemListExWithSell;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.tradeItemListExWithSell;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
			}
			if (this.tradeItemListExWithBuy != null)
			{
				this.tradeItemListExWithBuy.Initialize();
				ComUIListScriptEx comUIListScriptEx3 = this.tradeItemListExWithBuy;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.tradeItemListExWithBuy;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemRecycle));
			}
		}

		// Token: 0x0600D719 RID: 55065 RVA: 0x0035C19C File Offset: 0x0035A59C
		private void UnBindEvents()
		{
			if (this.tradeItemListExWithSell != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.tradeItemListExWithSell;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.tradeItemListExWithSell;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellItemRecycle));
			}
			if (this.tradeItemListExWithBuy != null)
			{
				ComUIListScriptEx comUIListScriptEx3 = this.tradeItemListExWithBuy;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBuyItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.tradeItemListExWithBuy;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnBuyItemVisible));
			}
		}

		// Token: 0x0600D71A RID: 55066 RVA: 0x0035C267 File Offset: 0x0035A667
		private void ClearData()
		{
			this._tradeDataModelListWithBuy = null;
			this._tradeDataModelListWithSell = null;
		}

		// Token: 0x0600D71B RID: 55067 RVA: 0x0035C277 File Offset: 0x0035A677
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestTradeItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRequestTradeItemData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealTradeItemMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTradeItemMessageRes));
		}

		// Token: 0x0600D71C RID: 55068 RVA: 0x0035C2AF File Offset: 0x0035A6AF
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealRequestTradeItemData, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealRequestTradeItemData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealTradeItemMessageRes, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealTradeItemMessageRes));
		}

		// Token: 0x0600D71D RID: 55069 RVA: 0x0035C2E7 File Offset: 0x0035A6E7
		public void InitView(GoldConsignmentOrderType orderType)
		{
			this._orderType = orderType;
			this.InitTitle();
			this.UpdateTradeView();
		}

		// Token: 0x0600D71E RID: 55070 RVA: 0x0035C2FC File Offset: 0x0035A6FC
		private void InitTitle()
		{
			string coinDealCommonSinglePriceStr = CoinDealUtility.GetCoinDealCommonSinglePriceStr();
			if (this.singlePriceTitleLabel != null)
			{
				this.singlePriceTitleLabel.text = coinDealCommonSinglePriceStr;
			}
		}

		// Token: 0x0600D71F RID: 55071 RVA: 0x0035C32C File Offset: 0x0035A72C
		public void OnEnableView(GoldConsignmentOrderType orderType)
		{
			this._orderType = orderType;
			if (DataManager<CoinDealDataManager>.GetInstance().IsCoinDealRequestTradeItemData)
			{
				DataManager<CoinDealDataManager>.GetInstance().RequestCoinDealOrderItemData();
			}
			else
			{
				this.UpdateCoinDealTradeItemList();
			}
			this.UpdateBuyAndSellControl();
		}

		// Token: 0x0600D720 RID: 55072 RVA: 0x0035C35F File Offset: 0x0035A75F
		public void OnUpdateView(GoldConsignmentOrderType orderType)
		{
			this._orderType = orderType;
			this.UpdateBuyAndSellControl();
		}

		// Token: 0x0600D721 RID: 55073 RVA: 0x0035C36E File Offset: 0x0035A76E
		private void UpdateTradeView()
		{
			this.UpdateCoinDealTradeItemList();
			this.UpdateBuyAndSellControl();
		}

		// Token: 0x0600D722 RID: 55074 RVA: 0x0035C37C File Offset: 0x0035A77C
		private void UpdateBuyAndSellControl()
		{
			if (this._orderType == GoldConsignmentOrderType.GCOT_BUY)
			{
				CommonUtility.UpdateGameObjectVisible(this.sellControlRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.buyControlRoot, true);
				if (this._buyControlView == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.buyControlRoot);
					if (gameObject != null)
					{
						this._buyControlView = gameObject.GetComponent<CoinDealBuyControlView>();
					}
					if (this._buyControlView != null)
					{
						this._buyControlView.InitView();
					}
				}
				else
				{
					this._buyControlView.OnEnableView();
				}
			}
			else if (this._orderType == GoldConsignmentOrderType.GCOT_SELL)
			{
				CommonUtility.UpdateGameObjectVisible(this.buyControlRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.sellControlRoot, true);
				if (this._sellControlView == null)
				{
					GameObject gameObject2 = CommonUtility.LoadGameObject(this.sellControlRoot);
					if (gameObject2 != null)
					{
						this._sellControlView = gameObject2.GetComponent<CoinDealSellControlView>();
					}
					if (this._sellControlView != null)
					{
						this._sellControlView.InitView();
					}
				}
				else
				{
					this._sellControlView.OnEnableView();
				}
			}
		}

		// Token: 0x0600D723 RID: 55075 RVA: 0x0035C498 File Offset: 0x0035A898
		private void OnReceiveCoinDealRequestTradeItemData(UIEvent uiEvent)
		{
			DataManager<CoinDealDataManager>.GetInstance().RequestCoinDealOrderItemData();
		}

		// Token: 0x0600D724 RID: 55076 RVA: 0x0035C4A4 File Offset: 0x0035A8A4
		private void OnReceiveCoinDealTradeItemMessageRes(UIEvent uiEvent)
		{
			this.UpdateCoinDealTradeItemList();
		}

		// Token: 0x0600D725 RID: 55077 RVA: 0x0035C4AC File Offset: 0x0035A8AC
		public void UpdateCoinDealTradeItemList()
		{
			this._tradeDataModelListWithSell = DataManager<CoinDealDataManager>.GetInstance().CoinDealTradeDataModelListWithSell;
			int elementAmount = 0;
			if (this._tradeDataModelListWithSell != null)
			{
				elementAmount = this._tradeDataModelListWithSell.Count;
			}
			if (this.tradeItemListExWithSell != null)
			{
				this.tradeItemListExWithSell.SetElementAmount(elementAmount);
			}
			this._tradeDataModelListWithBuy = DataManager<CoinDealDataManager>.GetInstance().CoinDealTradeDataModelListWithBuy;
			int elementAmount2 = 0;
			if (this._tradeDataModelListWithBuy != null)
			{
				elementAmount2 = this._tradeDataModelListWithBuy.Count;
			}
			if (this.tradeItemListExWithBuy != null)
			{
				this.tradeItemListExWithBuy.SetElementAmount(elementAmount2);
			}
		}

		// Token: 0x0600D726 RID: 55078 RVA: 0x0035C548 File Offset: 0x0035A948
		private void OnSellItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.tradeItemListExWithSell == null)
			{
				return;
			}
			if (this._tradeDataModelListWithSell == null || this._tradeDataModelListWithSell.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._tradeDataModelListWithSell.Count)
			{
				return;
			}
			CoinDealTradeDataModel coinDealTradeDataModel = this._tradeDataModelListWithSell[item.m_index];
			CoinDealTradeItem component = item.GetComponent<CoinDealTradeItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealTradeDataModel != null)
			{
				component.InitItem(coinDealTradeDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D727 RID: 55079 RVA: 0x0035C5F0 File Offset: 0x0035A9F0
		private void OnSellItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealTradeItem component = item.GetComponent<CoinDealTradeItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D728 RID: 55080 RVA: 0x0035C624 File Offset: 0x0035AA24
		private void OnBuyItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.tradeItemListExWithBuy == null)
			{
				return;
			}
			if (this._tradeDataModelListWithBuy == null || this._tradeDataModelListWithBuy.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._tradeDataModelListWithBuy.Count)
			{
				return;
			}
			CoinDealTradeDataModel coinDealTradeDataModel = this._tradeDataModelListWithBuy[item.m_index];
			CoinDealTradeItem component = item.GetComponent<CoinDealTradeItem>();
			int tradeIndex = item.m_index + 1;
			if (component != null && coinDealTradeDataModel != null)
			{
				component.InitItem(coinDealTradeDataModel, tradeIndex);
			}
		}

		// Token: 0x0600D729 RID: 55081 RVA: 0x0035C6CC File Offset: 0x0035AACC
		private void OnBuyItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CoinDealTradeItem component = item.GetComponent<CoinDealTradeItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x04007E46 RID: 32326
		private GoldConsignmentOrderType _orderType;

		// Token: 0x04007E47 RID: 32327
		private List<CoinDealTradeDataModel> _tradeDataModelListWithSell;

		// Token: 0x04007E48 RID: 32328
		private List<CoinDealTradeDataModel> _tradeDataModelListWithBuy;

		// Token: 0x04007E49 RID: 32329
		private CoinDealBuyControlView _buyControlView;

		// Token: 0x04007E4A RID: 32330
		private CoinDealSellControlView _sellControlView;

		// Token: 0x04007E4B RID: 32331
		[Space(10f)]
		[Header("title")]
		[Space(10f)]
		[SerializeField]
		private Text singlePriceTitleLabel;

		// Token: 0x04007E4C RID: 32332
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx tradeItemListExWithSell;

		// Token: 0x04007E4D RID: 32333
		[SerializeField]
		private ComUIListScriptEx tradeItemListExWithBuy;

		// Token: 0x04007E4E RID: 32334
		[Space(10f)]
		[Header("ControlRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject buyControlRoot;

		// Token: 0x04007E4F RID: 32335
		[SerializeField]
		private GameObject sellControlRoot;
	}
}

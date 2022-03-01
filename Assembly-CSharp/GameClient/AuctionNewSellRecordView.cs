using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200149E RID: 5278
	public class AuctionNewSellRecordView : MonoBehaviour
	{
		// Token: 0x0600CCA4 RID: 52388 RVA: 0x00324074 File Offset: 0x00322474
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CCA5 RID: 52389 RVA: 0x0032407C File Offset: 0x0032247C
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CCA6 RID: 52390 RVA: 0x0032408A File Offset: 0x0032248A
		private void ResetData()
		{
			this._treasureBuyRecordList = null;
			this._treasureSellRecordList = null;
		}

		// Token: 0x0600CCA7 RID: 52391 RVA: 0x0032409A File Offset: 0x0032249A
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewGetTreasureTransactionRecordSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveTreasureItemTransactionRes));
		}

		// Token: 0x0600CCA8 RID: 52392 RVA: 0x003240B7 File Offset: 0x003224B7
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewGetTreasureTransactionRecordSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveTreasureItemTransactionRes));
		}

		// Token: 0x0600CCA9 RID: 52393 RVA: 0x003240D4 File Offset: 0x003224D4
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.treasureItemSellList != null)
			{
				this.treasureItemSellList.Initialize();
				ComUIListScript comUIListScript = this.treasureItemSellList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTreasureItemSellVisible));
				ComUIListScript comUIListScript2 = this.treasureItemSellList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTreasureItemSellRecycle));
			}
		}

		// Token: 0x0600CCAA RID: 52394 RVA: 0x00324188 File Offset: 0x00322588
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.treasureItemSellList != null)
			{
				ComUIListScript comUIListScript = this.treasureItemSellList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTreasureItemSellVisible));
				ComUIListScript comUIListScript2 = this.treasureItemSellList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTreasureItemSellRecycle));
			}
		}

		// Token: 0x0600CCAB RID: 52395 RVA: 0x00324215 File Offset: 0x00322615
		public void InitView()
		{
			this.InitBaseView();
			this.SendTreasureItemTransactionReq();
		}

		// Token: 0x0600CCAC RID: 52396 RVA: 0x00324224 File Offset: 0x00322624
		private void InitBaseView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("auction_new_sell_record");
			}
			if (this.sellItemLabel != null)
			{
				this.sellItemLabel.text = TR.Value("auction_new_sell_record_sell_item");
			}
			if (this.getTimeLabel != null)
			{
				this.getTimeLabel.text = TR.Value("auction_new_sell_record_get_time");
			}
			if (this.zeroSellItemTips != null)
			{
				this.zeroSellItemTips.text = TR.Value("auction_new_sell_record_zero_sell_item");
			}
		}

		// Token: 0x0600CCAD RID: 52397 RVA: 0x003242C9 File Offset: 0x003226C9
		private void SendTreasureItemTransactionReq()
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewTreasureTransactionReq();
		}

		// Token: 0x0600CCAE RID: 52398 RVA: 0x003242D8 File Offset: 0x003226D8
		private void OnReceiveTreasureItemTransactionRes(UIEvent uiEvent)
		{
			this._treasureBuyRecordList = DataManager<AuctionNewDataManager>.GetInstance().GetTreasureItemBuyRecordList();
			this._treasureSellRecordList = DataManager<AuctionNewDataManager>.GetInstance().GetTreasureItemSaleRecordList();
			if (this.treasureItemSellList != null)
			{
				if (this._treasureSellRecordList != null && this._treasureSellRecordList.Count > 0)
				{
					this.treasureItemSellList.SetElementAmount(this._treasureSellRecordList.Count);
				}
				else
				{
					this.treasureItemSellList.SetElementAmount(0);
				}
			}
		}

		// Token: 0x0600CCAF RID: 52399 RVA: 0x0032435C File Offset: 0x0032275C
		private void OnTreasureItemBuyVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._treasureBuyRecordList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._treasureBuyRecordList.Count)
			{
				return;
			}
			AuctionTransaction auctionTransaction = this._treasureBuyRecordList[item.m_index];
			AuctionNewTreasureRecordItem component = item.GetComponent<AuctionNewTreasureRecordItem>();
			if (component != null && auctionTransaction != null)
			{
				component.InitItem(auctionTransaction, false);
			}
		}

		// Token: 0x0600CCB0 RID: 52400 RVA: 0x003243D8 File Offset: 0x003227D8
		private void OnTreasureItemBuyRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewTreasureRecordItem component = item.GetComponent<AuctionNewTreasureRecordItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CCB1 RID: 52401 RVA: 0x0032440C File Offset: 0x0032280C
		private void OnTreasureItemSellVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._treasureSellRecordList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._treasureSellRecordList.Count)
			{
				return;
			}
			AuctionTransaction auctionTransaction = this._treasureSellRecordList[item.m_index];
			AuctionNewTreasureRecordItem component = item.GetComponent<AuctionNewTreasureRecordItem>();
			if (component != null && auctionTransaction != null)
			{
				component.InitItem(auctionTransaction, true);
			}
		}

		// Token: 0x0600CCB2 RID: 52402 RVA: 0x00324488 File Offset: 0x00322888
		private void OnTreasureItemSellRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewTreasureRecordItem component = item.GetComponent<AuctionNewTreasureRecordItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CCB3 RID: 52403 RVA: 0x003244BB File Offset: 0x003228BB
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewSellRecordFrame>(null, false);
		}

		// Token: 0x04007722 RID: 30498
		private List<AuctionTransaction> _treasureSellRecordList;

		// Token: 0x04007723 RID: 30499
		private List<AuctionTransaction> _treasureBuyRecordList;

		// Token: 0x04007724 RID: 30500
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007725 RID: 30501
		[Space(5f)]
		[Header("Button")]
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007726 RID: 30502
		[Space(15f)]
		[Header("AuctionNewSellRecord")]
		[Space(5f)]
		[SerializeField]
		private Text sellItemLabel;

		// Token: 0x04007727 RID: 30503
		[SerializeField]
		private Text getTimeLabel;

		// Token: 0x04007728 RID: 30504
		[SerializeField]
		private Text zeroSellItemTips;

		// Token: 0x04007729 RID: 30505
		[SerializeField]
		private ComUIListScript treasureItemSellList;
	}
}

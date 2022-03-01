using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001491 RID: 5265
	public class AuctionNewOtherPlayerControl : MonoBehaviour
	{
		// Token: 0x0600CC21 RID: 52257 RVA: 0x00321418 File Offset: 0x0031F818
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC22 RID: 52258 RVA: 0x00321420 File Offset: 0x0031F820
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CC23 RID: 52259 RVA: 0x00321430 File Offset: 0x0031F830
		private void BindEvents()
		{
			if (this.otherPlayerOnShelfItemList != null)
			{
				this.otherPlayerOnShelfItemList.Initialize();
				ComUIListScript comUIListScript = this.otherPlayerOnShelfItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnOtherPlayerOnShelfItemVisible));
				ComUIListScript comUIListScript2 = this.otherPlayerOnShelfItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnOtherPlayerOnShelfItemRecycle));
			}
		}

		// Token: 0x0600CC24 RID: 52260 RVA: 0x003214A8 File Offset: 0x0031F8A8
		private void UnBindEvents()
		{
			if (this.otherPlayerOnShelfItemList != null)
			{
				ComUIListScript comUIListScript = this.otherPlayerOnShelfItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnOtherPlayerOnShelfItemVisible));
				ComUIListScript comUIListScript2 = this.otherPlayerOnShelfItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnOtherPlayerOnShelfItemRecycle));
			}
		}

		// Token: 0x0600CC25 RID: 52261 RVA: 0x00321514 File Offset: 0x0031F914
		private void ClearData()
		{
			this._otherPlayerOnShelfDataList = null;
			this._otherPlayerOnSaleDataList.Clear();
			this._otherPlayerOnNoticeDataList.Clear();
			this._tabsDataList.Clear();
			this._worldAuctionQueryItemPriceRes = null;
			this._isTreasure = false;
			this._isOnNoticeAlreadySendReq = false;
			this._otherPlayerSellRecordControl = null;
			this._onSendWorldAuctionQueryItemPriceListReq = null;
			this._onSendWorldAuctionQueryItemTransListReq = null;
		}

		// Token: 0x0600CC26 RID: 52262 RVA: 0x00321573 File Offset: 0x0031F973
		public void InitOtherPlayerControlBaseView(bool isTreasure, OnSendWorldAuctionQueryItemPriceListReq onSendWorldAuctionQueryItemPriceListReq = null, OnSendWorldAuctionQueryItemTransListReq onSendWorldAuctionQueryItemTransListReq = null)
		{
			this._isTreasure = isTreasure;
			this._onSendWorldAuctionQueryItemPriceListReq = onSendWorldAuctionQueryItemPriceListReq;
			this._onSendWorldAuctionQueryItemTransListReq = onSendWorldAuctionQueryItemTransListReq;
			this.InitOnShelfOtherPlayerTabs();
		}

		// Token: 0x0600CC27 RID: 52263 RVA: 0x00321590 File Offset: 0x0031F990
		private void InitOnShelfOtherPlayerTabs()
		{
			this._tabsDataList.Clear();
			ComControlData item = new ComControlData
			{
				Id = 1,
				Name = TR.Value("auction_new_other_on_sale_label"),
				IsSelected = true
			};
			this._tabsDataList.Add(item);
			if (this._isTreasure)
			{
				ComControlData item2 = new ComControlData
				{
					Id = 2,
					Name = TR.Value("auction_new_other_on_notice_label"),
					IsSelected = false
				};
				this._tabsDataList.Add(item2);
			}
			if (this.tabControl != null)
			{
				this.tabControl.InitComToggleControl(this._tabsDataList, new OnComToggleClick(this.OnTabClick));
			}
		}

		// Token: 0x0600CC28 RID: 52264 RVA: 0x00321645 File Offset: 0x0031FA45
		private void OnTabClick(ComControlData comToggleData)
		{
			if (comToggleData == null)
			{
				return;
			}
			if (this._tabData != null && this._tabData.Id == comToggleData.Id)
			{
				return;
			}
			this._tabData = comToggleData;
			this.DealWithTabClick();
		}

		// Token: 0x0600CC29 RID: 52265 RVA: 0x00321680 File Offset: 0x0031FA80
		private void DealWithTabClick()
		{
			if (this._tabData == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.normalItemListRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.sellRecordItemListRoot, false);
			AuctionNewOtherPlayerShelfItemType id = (AuctionNewOtherPlayerShelfItemType)this._tabData.Id;
			if (id == AuctionNewOtherPlayerShelfItemType.OnNotice || id == AuctionNewOtherPlayerShelfItemType.OnSale)
			{
				CommonUtility.UpdateGameObjectVisible(this.normalItemListRoot, true);
				this.SetOnShelfNoItemTip();
				this.UpdateOtherPlayerOnShelfItemList();
				if (id == AuctionNewOtherPlayerShelfItemType.OnNotice && !this._isOnNoticeAlreadySendReq)
				{
					this._isOnNoticeAlreadySendReq = true;
					if (this._onSendWorldAuctionQueryItemPriceListReq != null)
					{
						this._onSendWorldAuctionQueryItemPriceListReq(1);
					}
				}
			}
			else if (id == AuctionNewOtherPlayerShelfItemType.SellRecord)
			{
			}
		}

		// Token: 0x0600CC2A RID: 52266 RVA: 0x00321720 File Offset: 0x0031FB20
		public void InitOtherPlayerOnSaleItemList(AuctionBaseInfo[] auctionItems)
		{
			if (auctionItems == null || auctionItems.Length <= 0)
			{
				return;
			}
			this._otherPlayerOnSaleDataList.Clear();
			foreach (AuctionBaseInfo auctionBaseInfo in auctionItems)
			{
				if (auctionBaseInfo != null)
				{
					this._otherPlayerOnSaleDataList.Add(auctionBaseInfo);
				}
			}
			AuctionNewUtility.SortItemListBySinglePrice(this._otherPlayerOnSaleDataList);
			if (this._tabData != null && this._tabData.Id == 1)
			{
				this.UpdateOtherPlayerOnShelfItemList();
			}
		}

		// Token: 0x0600CC2B RID: 52267 RVA: 0x003217A0 File Offset: 0x0031FBA0
		public void InitOtherPlayerOnNoticeItemList(AuctionBaseInfo[] auctionItems)
		{
			if (auctionItems == null || auctionItems.Length <= 0)
			{
				return;
			}
			this._otherPlayerOnNoticeDataList.Clear();
			foreach (AuctionBaseInfo auctionBaseInfo in auctionItems)
			{
				if (auctionBaseInfo != null)
				{
					this._otherPlayerOnNoticeDataList.Add(auctionBaseInfo);
				}
			}
			AuctionNewUtility.SortItemListBySinglePrice(this._otherPlayerOnNoticeDataList);
			if (this._tabData != null && this._tabData.Id == 2)
			{
				this.UpdateOtherPlayerOnShelfItemList();
			}
		}

		// Token: 0x0600CC2C RID: 52268 RVA: 0x0032181F File Offset: 0x0031FC1F
		public void InitOtherPlayerSellRecordItemList(AuctionTransaction[] auctionTransactions)
		{
		}

		// Token: 0x0600CC2D RID: 52269 RVA: 0x00321824 File Offset: 0x0031FC24
		private void UpdateOtherPlayerOnShelfItemList()
		{
			this._otherPlayerOnShelfDataList = this._otherPlayerOnSaleDataList;
			if (this._tabData != null && this._tabData.Id == 2)
			{
				this._otherPlayerOnShelfDataList = this._otherPlayerOnNoticeDataList;
			}
			int elementAmount = 0;
			if (this._otherPlayerOnShelfDataList != null)
			{
				elementAmount = this._otherPlayerOnShelfDataList.Count;
			}
			if (this.otherPlayerOnShelfItemList != null)
			{
				this.otherPlayerOnShelfItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600CC2E RID: 52270 RVA: 0x0032189C File Offset: 0x0031FC9C
		private void OnOtherPlayerOnShelfItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._otherPlayerOnShelfDataList == null || item.m_index < 0 || item.m_index >= this._otherPlayerOnShelfDataList.Count)
			{
				return;
			}
			AuctionBaseInfo auctionBaseInfo = this._otherPlayerOnShelfDataList[item.m_index];
			AuctionNewOtherPlayerOnShelfItem component = item.GetComponent<AuctionNewOtherPlayerOnShelfItem>();
			if (component != null)
			{
				component.InitItem(auctionBaseInfo);
			}
		}

		// Token: 0x0600CC2F RID: 52271 RVA: 0x00321910 File Offset: 0x0031FD10
		private void OnOtherPlayerOnShelfItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewOtherPlayerOnShelfItem component = item.GetComponent<AuctionNewOtherPlayerOnShelfItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CC30 RID: 52272 RVA: 0x00321944 File Offset: 0x0031FD44
		private void SetOnShelfNoItemTip()
		{
			if (this.otherPlayerNoItemTip != null)
			{
				if (this._tabData.Id == 2)
				{
					this.otherPlayerNoItemTip.text = TR.Value("auction_new_other_not_on_notice_label");
				}
				else if (this._tabData.Id == 1)
				{
					this.otherPlayerNoItemTip.text = TR.Value("auction_new_other_not_on_sale_label");
				}
			}
		}

		// Token: 0x0600CC31 RID: 52273 RVA: 0x003219B4 File Offset: 0x0031FDB4
		private AuctionNewOtherPlayerSellRecordControl LoadOtherPlayerSellRecordControl(GameObject sellRecordRoot)
		{
			if (sellRecordRoot == null)
			{
				return null;
			}
			GameObject gameObject = CommonUtility.LoadGameObject(sellRecordRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<AuctionNewOtherPlayerSellRecordControl>();
		}

		// Token: 0x040076C0 RID: 30400
		private bool _isTreasure;

		// Token: 0x040076C1 RID: 30401
		private bool _isOnNoticeAlreadySendReq;

		// Token: 0x040076C2 RID: 30402
		private ComControlData _tabData;

		// Token: 0x040076C3 RID: 30403
		private List<ComControlData> _tabsDataList = new List<ComControlData>();

		// Token: 0x040076C4 RID: 30404
		private WorldAuctionQueryItemPricesRes _worldAuctionQueryItemPriceRes;

		// Token: 0x040076C5 RID: 30405
		private List<AuctionBaseInfo> _otherPlayerOnShelfDataList;

		// Token: 0x040076C6 RID: 30406
		private List<AuctionBaseInfo> _otherPlayerOnSaleDataList = new List<AuctionBaseInfo>();

		// Token: 0x040076C7 RID: 30407
		private List<AuctionBaseInfo> _otherPlayerOnNoticeDataList = new List<AuctionBaseInfo>();

		// Token: 0x040076C8 RID: 30408
		private OnSendWorldAuctionQueryItemPriceListReq _onSendWorldAuctionQueryItemPriceListReq;

		// Token: 0x040076C9 RID: 30409
		private OnSendWorldAuctionQueryItemTransListReq _onSendWorldAuctionQueryItemTransListReq;

		// Token: 0x040076CA RID: 30410
		private AuctionNewOtherPlayerSellRecordControl _otherPlayerSellRecordControl;

		// Token: 0x040076CB RID: 30411
		[Space(10f)]
		[Header("tabControl")]
		[Space(5f)]
		[SerializeField]
		private ComToggleControl tabControl;

		// Token: 0x040076CC RID: 30412
		[Space(15f)]
		[Header("NormalItemList")]
		[Space(15f)]
		[SerializeField]
		private GameObject normalItemListRoot;

		// Token: 0x040076CD RID: 30413
		[SerializeField]
		private ComUIListScript otherPlayerOnShelfItemList;

		// Token: 0x040076CE RID: 30414
		[SerializeField]
		private Text otherPlayerNoItemTip;

		// Token: 0x040076CF RID: 30415
		[Space(15f)]
		[Header("SellRecordItemList")]
		[Space(15f)]
		[SerializeField]
		private GameObject sellRecordItemListRoot;
	}
}

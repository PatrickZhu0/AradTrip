using System;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200146E RID: 5230
	public class AuctionNewBuyNoticeDetailController : AuctionNewBuyNoticeBaseController
	{
		// Token: 0x0600CABC RID: 51900 RVA: 0x0031A1B1 File Offset: 0x003185B1
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CABD RID: 51901 RVA: 0x0031A1B9 File Offset: 0x003185B9
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
			this._filterData = null;
		}

		// Token: 0x0600CABE RID: 51902 RVA: 0x0031A1D0 File Offset: 0x003185D0
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewReceiveItemDetailDataResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewReceiveItemDetailResSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewNotifyRefreshToRequestDetailItems, new ClientEventSystem.UIEventHandler(this.OnAuctionNewNotifyRefreshToRequestDetailItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewSelectMagicCardStrengthenLevel, new ClientEventSystem.UIEventHandler(this.OnAuctionNewSelectMagicCardStrengthenLevel));
		}

		// Token: 0x0600CABF RID: 51903 RVA: 0x0031A230 File Offset: 0x00318630
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewReceiveItemDetailDataResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewReceiveItemDetailResSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewNotifyRefreshToRequestDetailItems, new ClientEventSystem.UIEventHandler(this.OnAuctionNewNotifyRefreshToRequestDetailItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewSelectMagicCardStrengthenLevel, new ClientEventSystem.UIEventHandler(this.OnAuctionNewSelectMagicCardStrengthenLevel));
		}

		// Token: 0x0600CAC0 RID: 51904 RVA: 0x0031A290 File Offset: 0x00318690
		private void BindEvents()
		{
			if (this.detailItemList != null)
			{
				this.detailItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.detailItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDetailItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.detailItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnDetailItemRecycle));
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.AddListener(new UnityAction(this.OnPrePageButtonClick));
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.AddListener(new UnityAction(this.OnNextPageButtonClick));
			}
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
				this.backButton.onClick.AddListener(new UnityAction(this.OnBackButtonClick));
			}
			if (this.strengthenLevelButton != null)
			{
				this.strengthenLevelButton.onClick.RemoveAllListeners();
				this.strengthenLevelButton.onClick.AddListener(new UnityAction(this.OnStrengthenLevelButtonClick));
			}
		}

		// Token: 0x0600CAC1 RID: 51905 RVA: 0x0031A3DC File Offset: 0x003187DC
		private void UnBindEvents()
		{
			if (this.detailItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.detailItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDetailItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.detailItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnDetailItemRecycle));
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
			}
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
			}
			if (this.strengthenLevelButton != null)
			{
				this.strengthenLevelButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CAC2 RID: 51906 RVA: 0x0031A4CC File Offset: 0x003188CC
		private void ResetData()
		{
			this._isNoticeTab = false;
			this._itemId = 0;
			this._auctionItemBaseInfo = null;
			this._mainTabType = AuctionNewMainTabType.None;
			this._curPage = 0;
			this._maxPage = 0;
			this._auctionNewItemDetailData = null;
		}

		// Token: 0x0600CAC3 RID: 51907 RVA: 0x0031A4FF File Offset: 0x003188FF
		public void InitDetailController(OnUpdateFilterBackground onUpdateFilterBackground, Action onBackButtonClick = null)
		{
			this._onUpdateFilterBackground = onUpdateFilterBackground;
			this._onBackButtonClick = onBackButtonClick;
			this.InitBackButtonText();
		}

		// Token: 0x0600CAC4 RID: 51908 RVA: 0x0031A518 File Offset: 0x00318918
		public void OnEnableDetailController(AuctionNewMainTabType auctionNewMainTabType, bool isNoticeTab, AuctionItemBaseInfo auctionItemBaseInfo = null, bool isResetStrengthenLevel = false)
		{
			this.ResetData();
			this._mainTabType = auctionNewMainTabType;
			this._isNoticeTab = isNoticeTab;
			this._curPage = 1;
			this._maxPage = 1;
			this._auctionItemBaseInfo = auctionItemBaseInfo;
			this._itemId = 0;
			if (!this._isNoticeTab)
			{
				if (this._auctionItemBaseInfo == null)
				{
					Logger.LogErrorFormat("This is not NoticeTab and auctionItemBaseInfo is null", new object[0]);
					return;
				}
				this._itemId = (int)this._auctionItemBaseInfo.itemTypeId;
			}
			if (isResetStrengthenLevel && AuctionNewUtility.IsMagicCardItem((uint)this._itemId))
			{
				this._selectedStrengthenLevel = -1;
			}
			this.UpdateDetailController();
		}

		// Token: 0x0600CAC5 RID: 51909 RVA: 0x0031A5B1 File Offset: 0x003189B1
		private void UpdateDetailController()
		{
			this.ResetDetailControllerView();
			if (this._isNoticeTab)
			{
				this.UpdateDetailControllerViewOfNoticeTab();
			}
			else
			{
				this.UpdateDetailControllerViewOnNormalTab();
			}
			this.SendAuctionNewItemDetailListReq(this._curPage);
		}

		// Token: 0x0600CAC6 RID: 51910 RVA: 0x0031A5E4 File Offset: 0x003189E4
		private void UpdateDetailControllerViewOfNoticeTab()
		{
			if (this.backButtonRoot != null)
			{
				this.backButtonRoot.CustomActive(false);
			}
			if (this._onUpdateFilterBackground != null)
			{
				this._onUpdateFilterBackground(false);
			}
			if (this.auctionNewFilterView != null)
			{
				this.auctionNewFilterView.gameObject.CustomActive(false);
			}
			if (this.detailItemContentRoot != null && this.detailItemNoFilterRoot != null)
			{
				this.detailItemContentRoot.transform.localPosition = new Vector3(this.detailItemContentRoot.transform.localPosition.x, this.detailItemNoFilterRoot.transform.localPosition.y, this.detailItemContentRoot.transform.localPosition.z);
			}
		}

		// Token: 0x0600CAC7 RID: 51911 RVA: 0x0031A6C8 File Offset: 0x00318AC8
		private void UpdateDetailControllerViewOnNormalTab()
		{
			if (this.backButtonRoot != null)
			{
				this.backButtonRoot.CustomActive(true);
			}
			if (this._onUpdateFilterBackground != null)
			{
				this._onUpdateFilterBackground(true);
			}
			if (this.detailItemContentRoot != null && this.detailItemHaveFilterRoot != null)
			{
				this.detailItemContentRoot.transform.localPosition = new Vector3(this.detailItemContentRoot.transform.localPosition.x, this.detailItemHaveFilterRoot.transform.localPosition.y, this.detailItemContentRoot.transform.localPosition.z);
			}
			this.InitDetailControllerFilterData();
			this.UpdateBuyNoticeDetailFilterView();
			this.UpdateStrengthenLevelButton();
		}

		// Token: 0x0600CAC8 RID: 51912 RVA: 0x0031A79A File Offset: 0x00318B9A
		private void ResetDetailControllerView()
		{
			this.UpdatePageButtonView();
			if (this.detailItemList != null)
			{
				this.detailItemList.ResetContentPosition();
				this.detailItemList.SetElementAmount(0);
			}
		}

		// Token: 0x0600CAC9 RID: 51913 RVA: 0x0031A7CC File Offset: 0x00318BCC
		private void InitDetailControllerFilterData()
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_AUCTION_PAGE))
			{
				this._isHaveFilterAndPageButtonEnabled = true;
				return;
			}
			this._isHaveFilterAndPageButtonEnabled = false;
			if (this._auctionItemBaseInfo.isTreas == 1)
			{
				this._isHaveFilterAndPageButtonEnabled = true;
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.Type == ItemTable.eType.EQUIP)
			{
				this._isHaveFilterAndPageButtonEnabled = true;
				return;
			}
		}

		// Token: 0x0600CACA RID: 51914 RVA: 0x0031A84C File Offset: 0x00318C4C
		private void UpdateBuyNoticeDetailFilterView()
		{
			if (!this._isHaveFilterAndPageButtonEnabled)
			{
				this._sortType = AuctionSortType.PriceAsc;
				if (this.auctionNewFilterView != null)
				{
					this.auctionNewFilterView.gameObject.CustomActive(false);
				}
				return;
			}
			if (this.auctionNewFilterView != null)
			{
				this.auctionNewFilterView.gameObject.CustomActive(true);
			}
			if (this._filterData == null)
			{
				AuctionNewFrameTable.eFilterItemType filterType = AuctionNewFrameTable.eFilterItemType.FIT_PRICE;
				int filterSortType = 1;
				this._filterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(filterType, filterSortType);
				this.InitAuctionNewFilterView();
			}
			this._sortType = this.GetAuctionSortType(this._filterData);
		}

		// Token: 0x0600CACB RID: 51915 RVA: 0x0031A8E9 File Offset: 0x00318CE9
		private void InitAuctionNewFilterView()
		{
			if (this.auctionNewFilterView != null)
			{
				this.auctionNewFilterView.InitAuctionNewFilterView(this._filterData, new OnAuctionNewFilterElementItemButtonClick(this.OnFilterElementItemSelected), null, null, null, null);
			}
		}

		// Token: 0x0600CACC RID: 51916 RVA: 0x0031A91D File Offset: 0x00318D1D
		private void OnFilterElementItemSelected(AuctionNewFilterData auctionNewFilterData)
		{
			this._filterData = auctionNewFilterData;
			this._sortType = this.GetAuctionSortType(this._filterData);
			this.SendAuctionNewItemDetailListReq(this._curPage);
		}

		// Token: 0x0600CACD RID: 51917 RVA: 0x0031A944 File Offset: 0x00318D44
		private AuctionSortType GetAuctionSortType(AuctionNewFilterData filterData)
		{
			if (filterData == null || filterData.Sort == 1)
			{
				return AuctionSortType.PriceAsc;
			}
			return AuctionSortType.PriceDesc;
		}

		// Token: 0x0600CACE RID: 51918 RVA: 0x0031A95C File Offset: 0x00318D5C
		private void OnPrePageButtonClick()
		{
			if (this._isNoticeTab)
			{
				if (this._curPage <= 1)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_first_page"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					this._curPage--;
					this.UpdatePageData();
					this.UpdateDetailItemList();
				}
				return;
			}
			if (!this._isHaveFilterAndPageButtonEnabled)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_limit_item"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._curPage > 1)
			{
				this.SendAuctionNewItemDetailListReq(this._curPage - 1);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_first_page"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600CACF RID: 51919 RVA: 0x0031AA00 File Offset: 0x00318E00
		private void OnNextPageButtonClick()
		{
			if (this._isNoticeTab)
			{
				if (this._curPage >= this._maxPage)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_last_page"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					this._curPage++;
					this.UpdatePageData();
					this.UpdateDetailItemList();
				}
				return;
			}
			if (!this._isHaveFilterAndPageButtonEnabled)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_limit_item"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._curPage >= this._maxPage)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_itemDetail_last_page"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				this.SendAuctionNewItemDetailListReq(this._curPage + 1);
			}
		}

		// Token: 0x0600CAD0 RID: 51920 RVA: 0x0031AAAC File Offset: 0x00318EAC
		private void OnAuctionNewReceiveItemDetailResSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			AuctionGoodState auctionGoodState = (AuctionGoodState)num;
			if (!AuctionNewUtility.IsAuctionNewSameState(this._mainTabType, auctionGoodState))
			{
				return;
			}
			AuctionNewItemDetailData auctionNewItemDetailData = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewItemDetailData(num);
			if ((this._isNoticeTab && auctionNewItemDetailData.NoticeType != 1) || (!this._isNoticeTab && auctionNewItemDetailData.NoticeType == 1))
			{
				return;
			}
			if (auctionNewItemDetailData == null)
			{
				Logger.LogErrorFormat("_AuctionNewItemDetailData is null", new object[0]);
				return;
			}
			if (auctionNewItemDetailData.CurPage > auctionNewItemDetailData.MaxPage && (auctionNewItemDetailData.ItemDetailDataList == null || auctionNewItemDetailData.ItemDetailDataList.Count <= 0))
			{
				this.SendAuctionNewItemDetailListReq(auctionNewItemDetailData.MaxPage);
				return;
			}
			this._auctionNewItemDetailData = auctionNewItemDetailData;
			this._curPage = this._auctionNewItemDetailData.CurPage;
			this._maxPage = this._auctionNewItemDetailData.MaxPage;
			this.UpdateMaxPageInfoInNoticeTab();
			this.UpdatePageData();
			this.UpdateDetailItemList();
		}

		// Token: 0x0600CAD1 RID: 51921 RVA: 0x0031ABB4 File Offset: 0x00318FB4
		private void UpdateMaxPageInfoInNoticeTab()
		{
			if (this._isNoticeTab)
			{
				if (this._auctionNewItemDetailData != null && this._auctionNewItemDetailData.ItemDetailDataList != null)
				{
					if (this._auctionNewItemDetailData.ItemDetailDataList.Count <= 0)
					{
						this._maxPage = 1;
					}
					else
					{
						this._maxPage = 1 + (this._auctionNewItemDetailData.ItemDetailDataList.Count - 1) / DataManager<AuctionNewDataManager>.GetInstance().PageNumber;
					}
				}
				if (this._curPage > this._maxPage)
				{
					this._curPage = this._maxPage;
				}
			}
		}

		// Token: 0x0600CAD2 RID: 51922 RVA: 0x0031AC4B File Offset: 0x0031904B
		private void UpdatePageData()
		{
			if (this._maxPage < 1)
			{
				this._maxPage = 1;
			}
			if (this._curPage < 1)
			{
				this._curPage = 1;
			}
			this.UpdatePageButtonView();
		}

		// Token: 0x0600CAD3 RID: 51923 RVA: 0x0031AC7C File Offset: 0x0031907C
		private void UpdatePageButtonView()
		{
			if (this._curPage <= 1)
			{
				if (this.prePageButton != null)
				{
					this.prePageButton.interactable = false;
				}
				if (this.prePageGray != null)
				{
					this.prePageGray.enabled = true;
				}
			}
			else
			{
				if (this.prePageButton != null)
				{
					this.prePageButton.interactable = true;
				}
				if (this.prePageGray != null)
				{
					this.prePageGray.enabled = false;
				}
			}
			if (this._curPage >= this._maxPage)
			{
				if (this.nextPageButton != null)
				{
					this.nextPageButton.interactable = false;
				}
				if (this.nextPageGray != null)
				{
					this.nextPageGray.enabled = true;
				}
			}
			else
			{
				if (this.nextPageButton != null)
				{
					this.nextPageButton.interactable = true;
				}
				if (this.nextPageGray != null)
				{
					this.nextPageGray.enabled = false;
				}
			}
			if (this.pageValue != null)
			{
				this.pageValue.text = string.Format(TR.Value("auction_new_itemDetail_page_value"), this._curPage, this._maxPage);
			}
		}

		// Token: 0x0600CAD4 RID: 51924 RVA: 0x0031ADDC File Offset: 0x003191DC
		private void UpdateDetailItemList()
		{
			if (this.detailItemList != null)
			{
				this.detailItemList.ResetContentPosition();
				if (this._auctionNewItemDetailData.ItemDetailDataList == null || this._auctionNewItemDetailData.ItemDetailDataList.Count <= 0)
				{
					this.detailItemList.SetElementAmount(0);
				}
				else if (!this._isNoticeTab)
				{
					this.detailItemList.SetElementAmount(this._auctionNewItemDetailData.ItemDetailDataList.Count);
				}
				else
				{
					int count = this._auctionNewItemDetailData.ItemDetailDataList.Count;
					int num = DataManager<AuctionNewDataManager>.GetInstance().PageNumber;
					if (count < this._curPage * DataManager<AuctionNewDataManager>.GetInstance().PageNumber)
					{
						num = count - (this._curPage - 1) * DataManager<AuctionNewDataManager>.GetInstance().PageNumber;
						if (num <= 0)
						{
							num = 0;
						}
					}
					this.detailItemList.SetElementAmount(num);
				}
			}
		}

		// Token: 0x0600CAD5 RID: 51925 RVA: 0x0031AEC8 File Offset: 0x003192C8
		private void OnDetailItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewBuyNoticeDetailItem component = item.GetComponent<AuctionNewBuyNoticeDetailItem>();
			if (component == null)
			{
				return;
			}
			AuctionBaseInfo auctionBaseInfo;
			if (!this._isNoticeTab)
			{
				if (item.m_index < 0 || item.m_index >= this._auctionNewItemDetailData.ItemDetailDataList.Count)
				{
					return;
				}
				auctionBaseInfo = this._auctionNewItemDetailData.ItemDetailDataList[item.m_index];
			}
			else
			{
				if (item.m_index < 0)
				{
					return;
				}
				int num = (this._curPage - 1) * DataManager<AuctionNewDataManager>.GetInstance().PageNumber + item.m_index;
				if (num < 0 || num >= this._auctionNewItemDetailData.ItemDetailDataList.Count)
				{
					return;
				}
				auctionBaseInfo = this._auctionNewItemDetailData.ItemDetailDataList[num];
			}
			if (auctionBaseInfo != null)
			{
				component.InitItem(this._mainTabType, auctionBaseInfo);
			}
		}

		// Token: 0x0600CAD6 RID: 51926 RVA: 0x0031AFB4 File Offset: 0x003193B4
		private void OnDetailItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewBuyNoticeDetailItem component = item.GetComponent<AuctionNewBuyNoticeDetailItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CAD7 RID: 51927 RVA: 0x0031AFE8 File Offset: 0x003193E8
		private void OnAuctionNewNotifyRefreshToRequestDetailItems(UIEvent uiEvent)
		{
			if (!this._isNoticeTab)
			{
				this.SendAuctionNewItemDetailListReq(this._curPage);
			}
			else
			{
				if (uiEvent == null || uiEvent.Param1 == null)
				{
					return;
				}
				ulong buyGuid = (ulong)uiEvent.Param1;
				this.RefreshNoticeDetailViewByBuyItem(buyGuid);
			}
		}

		// Token: 0x0600CAD8 RID: 51928 RVA: 0x0031B038 File Offset: 0x00319438
		private void RefreshNoticeDetailViewByBuyItem(ulong buyGuid)
		{
			if (this._auctionNewItemDetailData == null || this._auctionNewItemDetailData.ItemDetailDataList == null || this._auctionNewItemDetailData.ItemDetailDataList.Count <= 0)
			{
				Logger.LogErrorFormat("auctionNewItemDetailData is null or ItemDetailDataList is null or count is zero", new object[0]);
				return;
			}
			for (int i = 0; i < this._auctionNewItemDetailData.ItemDetailDataList.Count; i++)
			{
				AuctionBaseInfo auctionBaseInfo = this._auctionNewItemDetailData.ItemDetailDataList[i];
				if (auctionBaseInfo != null && auctionBaseInfo.guid == buyGuid)
				{
					this._auctionNewItemDetailData.ItemDetailDataList.RemoveAt(i);
					this.UpdateMaxPageInfoInNoticeTab();
					this.UpdatePageData();
					this.UpdateDetailItemList();
					return;
				}
			}
		}

		// Token: 0x0600CAD9 RID: 51929 RVA: 0x0031B0F0 File Offset: 0x003194F0
		private void SendAuctionNewItemDetailListReq(int pageIndex)
		{
			if (!this._isNoticeTab)
			{
				if (AuctionNewUtility.IsMagicCardItem((uint)this._itemId))
				{
					int minStrengthenLevel = 0;
					int maxStrengthenLevel = 0;
					if (this._selectedStrengthenLevel == 0)
					{
						minStrengthenLevel = DataManager<AuctionNewDataManager>.GetInstance().DefaultMagicCardZeroStrengthenLevelQuery;
						maxStrengthenLevel = DataManager<AuctionNewDataManager>.GetInstance().DefaultMagicCardZeroStrengthenLevelQuery;
					}
					else if (this._selectedStrengthenLevel > 0)
					{
						minStrengthenLevel = this._selectedStrengthenLevel;
						maxStrengthenLevel = this._selectedStrengthenLevel;
					}
					DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewItemDetailListReq(this._itemId, this._mainTabType, pageIndex, (int)this._sortType, 0, minStrengthenLevel, maxStrengthenLevel);
				}
				else
				{
					DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewItemDetailListReq(this._itemId, this._mainTabType, pageIndex, (int)this._sortType, 0, 0, 0);
				}
			}
			else
			{
				DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewItemDetailListReq(0, this._mainTabType, pageIndex, 0, 1, 0, 0);
			}
		}

		// Token: 0x0600CADA RID: 51930 RVA: 0x0031B1BC File Offset: 0x003195BC
		private void InitBackButtonText()
		{
			if (this.backButtonText != null)
			{
				this.backButtonText.text = TR.Value("auction_new_return_layer");
			}
		}

		// Token: 0x0600CADB RID: 51931 RVA: 0x0031B1E4 File Offset: 0x003195E4
		private void OnBackButtonClick()
		{
			if (this._onBackButtonClick != null)
			{
				this._onBackButtonClick();
			}
		}

		// Token: 0x0600CADC RID: 51932 RVA: 0x0031B1FC File Offset: 0x003195FC
		private void UpdateStrengthenLevelButton()
		{
			this.strengthenLevelButton.gameObject.CustomActive(false);
			if (this.strengthenLevelButton != null && this._auctionItemBaseInfo != null && AuctionNewUtility.IsMagicCardItem(this._auctionItemBaseInfo.itemTypeId))
			{
				this.strengthenLevelButton.gameObject.CustomActive(true);
				this.UpdateStrengthenLevelText();
				if (this.auctionNewFilterView != null)
				{
					this.auctionNewFilterView.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600CADD RID: 51933 RVA: 0x0031B284 File Offset: 0x00319684
		private void UpdateStrengthenLevelText()
		{
			if (this.strengthenLevelText != null)
			{
				if (this._selectedStrengthenLevel <= -1)
				{
					this.strengthenLevelText.text = TR.Value("auction_new_magic_card_all_level");
				}
				else
				{
					this.strengthenLevelText.text = TR.Value("auction_new_magic_card_strengthen_level_normal", this._selectedStrengthenLevel);
				}
			}
		}

		// Token: 0x0600CADE RID: 51934 RVA: 0x0031B2E8 File Offset: 0x003196E8
		private void OnStrengthenLevelButtonClick()
		{
			AuctionNewUtility.OnOpenAuctionNewMagicCardStrengthLevelFrame(this._auctionItemBaseInfo.itemTypeId, this._selectedStrengthenLevel);
		}

		// Token: 0x0600CADF RID: 51935 RVA: 0x0031B300 File Offset: 0x00319700
		private void OnAuctionNewSelectMagicCardStrengthenLevel(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			int selectedStrengthenLevel = (int)uiEvent.Param2;
			if (this._isNoticeTab)
			{
				return;
			}
			if (this._itemId != num)
			{
				return;
			}
			if (!AuctionNewUtility.IsMagicCardItem((uint)this._itemId))
			{
				return;
			}
			this._selectedStrengthenLevel = selectedStrengthenLevel;
			this.UpdateStrengthenLevelText();
			this.SendAuctionNewItemDetailListReq(1);
		}

		// Token: 0x040075BC RID: 30140
		private bool _isNoticeTab;

		// Token: 0x040075BD RID: 30141
		private AuctionItemBaseInfo _auctionItemBaseInfo;

		// Token: 0x040075BE RID: 30142
		private AuctionNewMenuTabDataModel _auctionNewMenuTabDataModel;

		// Token: 0x040075BF RID: 30143
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x040075C0 RID: 30144
		private int _itemId;

		// Token: 0x040075C1 RID: 30145
		private AuctionSortType _sortType = AuctionSortType.PriceDesc;

		// Token: 0x040075C2 RID: 30146
		private AuctionNewItemDetailData _auctionNewItemDetailData;

		// Token: 0x040075C3 RID: 30147
		private int _curPage;

		// Token: 0x040075C4 RID: 30148
		private int _maxPage;

		// Token: 0x040075C5 RID: 30149
		private int _selectedStrengthenLevel = -1;

		// Token: 0x040075C6 RID: 30150
		private bool _isHaveFilterAndPageButtonEnabled = true;

		// Token: 0x040075C7 RID: 30151
		private OnUpdateFilterBackground _onUpdateFilterBackground;

		// Token: 0x040075C8 RID: 30152
		private Action _onBackButtonClick;

		// Token: 0x040075C9 RID: 30153
		private AuctionNewFilterData _filterData;

		// Token: 0x040075CA RID: 30154
		[SerializeField]
		private AuctionNewFilterView auctionNewFilterView;

		// Token: 0x040075CB RID: 30155
		[Space(10f)]
		[Header("ItemList")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx detailItemList;

		// Token: 0x040075CC RID: 30156
		[SerializeField]
		private GameObject detailItemContentRoot;

		// Token: 0x040075CD RID: 30157
		[SerializeField]
		private GameObject detailItemHaveFilterRoot;

		// Token: 0x040075CE RID: 30158
		[SerializeField]
		private GameObject detailItemNoFilterRoot;

		// Token: 0x040075CF RID: 30159
		[Space(10f)]
		[Header("PageButton")]
		[Space(5f)]
		[SerializeField]
		private Button prePageButton;

		// Token: 0x040075D0 RID: 30160
		[SerializeField]
		private UIGray prePageGray;

		// Token: 0x040075D1 RID: 30161
		[SerializeField]
		private Button nextPageButton;

		// Token: 0x040075D2 RID: 30162
		[SerializeField]
		private UIGray nextPageGray;

		// Token: 0x040075D3 RID: 30163
		[SerializeField]
		private Text pageValue;

		// Token: 0x040075D4 RID: 30164
		[Space(10f)]
		[Header("ReturnButton")]
		[Space(5f)]
		[SerializeField]
		private GameObject backButtonRoot;

		// Token: 0x040075D5 RID: 30165
		[SerializeField]
		private Button backButton;

		// Token: 0x040075D6 RID: 30166
		[SerializeField]
		private Text backButtonText;

		// Token: 0x040075D7 RID: 30167
		[SerializeField]
		private Button strengthenLevelButton;

		// Token: 0x040075D8 RID: 30168
		[SerializeField]
		private Text strengthenLevelText;
	}
}

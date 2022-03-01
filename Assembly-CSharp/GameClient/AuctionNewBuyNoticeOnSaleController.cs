using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200147D RID: 5245
	public class AuctionNewBuyNoticeOnSaleController : AuctionNewBuyNoticeBaseController
	{
		// Token: 0x0600CB5E RID: 52062 RVA: 0x0031D3E2 File Offset: 0x0031B7E2
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CB5F RID: 52063 RVA: 0x0031D3EA File Offset: 0x0031B7EA
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CB60 RID: 52064 RVA: 0x0031D3F8 File Offset: 0x0031B7F8
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewReceiveItemNumResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewReceiveItemNumResSucceed));
		}

		// Token: 0x0600CB61 RID: 52065 RVA: 0x0031D415 File Offset: 0x0031B815
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewReceiveItemNumResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewReceiveItemNumResSucceed));
			this.ResetOnSaleItemList();
		}

		// Token: 0x0600CB62 RID: 52066 RVA: 0x0031D438 File Offset: 0x0031B838
		private void BindEvents()
		{
			if (this.onSaleItemList != null)
			{
				this.onSaleItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.onSaleItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.onSaleItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600CB63 RID: 52067 RVA: 0x0031D4B0 File Offset: 0x0031B8B0
		private void UnBindEvents()
		{
			if (this.onSaleItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.onSaleItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.onSaleItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600CB64 RID: 52068 RVA: 0x0031D51C File Offset: 0x0031B91C
		private void ResetData()
		{
			this._onBuyNoticeOnSaleItemClick = null;
			this._firstLayerMenuDataModel = null;
			this._secondLayerMenuDataModel = null;
			this._thirdLayerMenuDataModel = null;
			this._mainTabType = AuctionNewMainTabType.None;
			this._auctionNewItemResList = null;
			this._isHaveFilter = false;
			this.ResetToggleControllerFlag();
		}

		// Token: 0x0600CB65 RID: 52069 RVA: 0x0031D555 File Offset: 0x0031B955
		public void InitOnSaleController(OnBuyNoticeOnSaleItemClick onBuyNoticeOnSaleItemClick, OnUpdateFilterBackground onUpdateFilterBackground, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.AuctionBuyType)
		{
			this._onBuyNoticeOnSaleItemClick = onBuyNoticeOnSaleItemClick;
			this._onUpdateFilterBackground = onUpdateFilterBackground;
			this.InitToggleSelectedController(auctionNewMainTabType);
		}

		// Token: 0x0600CB66 RID: 52070 RVA: 0x0031D56C File Offset: 0x0031B96C
		private void ResetToggleControllerFlag()
		{
			this._onlyShowOnSaleItemFlag = true;
			this._onlyShowTreasureItmFlag = false;
		}

		// Token: 0x0600CB67 RID: 52071 RVA: 0x0031D57C File Offset: 0x0031B97C
		private void InitToggleSelectedController(AuctionNewMainTabType auctionNewMainTabType)
		{
			this.ResetToggleControllerFlag();
			this._isShowTreasure = true;
			if (auctionNewMainTabType == AuctionNewMainTabType.AuctionNoticeType)
			{
				if (this.onlyShowTreasureItemController != null)
				{
					this.onlyShowTreasureItemController.gameObject.CustomActive(false);
				}
				if (this.onlyShowOnSaleItemController != null)
				{
					this.onlyShowOnSaleItemController.InitToggleSelectedController(this._onlyShowOnSaleItemFlag, TR.Value("auction_new_only_show_onSale"), new OnToggleSelectedClicked(this.OnOnlyShowOnSaleItemButtonClick));
				}
			}
			else
			{
				if (!AuctionNewUtility.IsAuctionTreasureItemOpen())
				{
					this._isShowTreasure = false;
				}
				if (this.onlyShowOnSaleItemController != null)
				{
					this.onlyShowOnSaleItemController.InitToggleSelectedController(this._onlyShowOnSaleItemFlag, TR.Value("auction_new_only_show_onSale"), new OnToggleSelectedClicked(this.OnOnlyShowOnSaleItemButtonClick));
				}
				if (this.onlyShowTreasureItemController != null)
				{
					this.onlyShowTreasureItemController.InitToggleSelectedController(this._onlyShowTreasureItmFlag, TR.Value("auction_new_only_show_treasure"), new OnToggleSelectedClicked(this.OnOnlyShowTreasureItemButtonClick));
				}
				if (!this._isShowTreasure && this.onlyShowTreasureItemController != null)
				{
					this.onlyShowTreasureItemController.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600CB68 RID: 52072 RVA: 0x0031D6AC File Offset: 0x0031BAAC
		public void OnEnableOnSaleController(AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, AuctionNewMenuTabDataModel secondLayerMenuTabDataModel, AuctionNewMenuTabDataModel thirdLayerMenuTabDataModel, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.None)
		{
			if (!this.IsSameOnSaleLayer(firstLayerMenuTabDataModel, secondLayerMenuTabDataModel, thirdLayerMenuTabDataModel, auctionNewMainTabType))
			{
				this.ResetOnSaleItemList();
				this._itemIdList = null;
			}
			this.ResetOnSaleToggleController();
			this._firstLayerMenuDataModel = firstLayerMenuTabDataModel;
			this._secondLayerMenuDataModel = secondLayerMenuTabDataModel;
			this._thirdLayerMenuDataModel = thirdLayerMenuTabDataModel;
			this._mainTabType = auctionNewMainTabType;
			this.UpdateBuyNoticeOnSaleFilter();
			this.UpdateOnSaleItemListPosition();
			if (this._onUpdateFilterBackground != null)
			{
				this._onUpdateFilterBackground(this._isHaveFilter);
			}
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB69 RID: 52073 RVA: 0x0031D729 File Offset: 0x0031BB29
		private void ResetOnSaleToggleController()
		{
			if (this.onlyShowOnSaleItemController != null)
			{
				this.onlyShowOnSaleItemController.ResetAuctionNewToggleSelectedController();
			}
			if (this.onlyShowTreasureItemController != null)
			{
				this.onlyShowTreasureItemController.ResetAuctionNewToggleSelectedController();
			}
		}

		// Token: 0x0600CB6A RID: 52074 RVA: 0x0031D764 File Offset: 0x0031BB64
		private void UpdateOnSaleItemListPosition()
		{
			if (this._isHaveFilter)
			{
				if (this.onSaleItemListRoot != null && this.onSaleItemHaveFilterRoot != null)
				{
					this.onSaleItemListRoot.transform.localPosition = new Vector3(this.onSaleItemListRoot.transform.localPosition.x, this.onSaleItemHaveFilterRoot.transform.localPosition.y, this.onSaleItemListRoot.transform.localPosition.z);
				}
			}
			else if (this.onSaleItemListRoot != null && this.onSaleItemNoFilterRoot != null)
			{
				this.onSaleItemListRoot.transform.localPosition = new Vector3(this.onSaleItemListRoot.transform.localPosition.x, this.onSaleItemNoFilterRoot.transform.localPosition.y, this.onSaleItemListRoot.transform.localPosition.z);
			}
		}

		// Token: 0x0600CB6B RID: 52075 RVA: 0x0031D881 File Offset: 0x0031BC81
		private void ResetOnSaleItemList()
		{
			if (this.onSaleItemList != null)
			{
				this.onSaleItemList.SetElementAmount(0);
			}
		}

		// Token: 0x0600CB6C RID: 52076 RVA: 0x0031D8A0 File Offset: 0x0031BCA0
		private void BuyNoticeOnSaleSendReq()
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewOnSaleItemListReq(this._mainTabType, this._firstLayerMenuDataModel, this._secondLayerMenuDataModel, this._thirdLayerMenuDataModel, this._firstFilterData, this._secondFilterData, this._thirdFilterData);
		}

		// Token: 0x0600CB6D RID: 52077 RVA: 0x0031D8D8 File Offset: 0x0031BCD8
		private void UpdateBuyNoticeOnSaleFilter()
		{
			FlatBufferArray<AuctionNewFrameTable.eFilterItemType> filterItemType = this._firstLayerMenuDataModel.AuctionNewFrameTable.FilterItemType;
			FlatBufferArray<int> filterSortType = this._firstLayerMenuDataModel.AuctionNewFrameTable.FilterSortType;
			if (this._thirdLayerMenuDataModel != null && this._thirdLayerMenuDataModel.AuctionNewFrameTable != null)
			{
				filterItemType = this._thirdLayerMenuDataModel.AuctionNewFrameTable.FilterItemType;
				filterSortType = this._thirdLayerMenuDataModel.AuctionNewFrameTable.FilterSortType;
			}
			else if (this._secondLayerMenuDataModel != null && this._secondLayerMenuDataModel.AuctionNewFrameTable != null)
			{
				filterItemType = this._secondLayerMenuDataModel.AuctionNewFrameTable.FilterItemType;
				filterSortType = this._secondLayerMenuDataModel.AuctionNewFrameTable.FilterSortType;
			}
			if (filterItemType == null || filterItemType.Count <= 0 || (filterItemType.Count == 1 && filterItemType[0] == AuctionNewFrameTable.eFilterItemType.FIT_NONE))
			{
				this._firstFilterData = null;
				this._secondFilterData = null;
				this._thirdFilterData = null;
				this.InitAuctionNewFilterView();
			}
			else if (filterItemType.Count == 1)
			{
				AuctionNewFrameTable.eFilterItemType eFilterItemType = filterItemType[0];
				int filterSortType2 = 1;
				if (filterSortType != null && filterSortType.Count == 1 && filterSortType[0] != 0)
				{
					filterSortType2 = filterSortType[0];
				}
				this._secondFilterData = null;
				this._thirdFilterData = null;
				if (AuctionNewUtility.IsFilterDataNeedReset(this._firstFilterData, eFilterItemType))
				{
					this._firstFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType, filterSortType2);
				}
				this.InitAuctionNewFilterView();
			}
			else if (filterItemType.Count == 2)
			{
				AuctionNewFrameTable.eFilterItemType eFilterItemType2 = filterItemType[0];
				AuctionNewFrameTable.eFilterItemType eFilterItemType3 = filterItemType[1];
				int filterSortType3 = 1;
				int filterSortType4 = 1;
				if (filterSortType != null && filterSortType.Count == 2)
				{
					filterSortType3 = filterSortType[0];
					filterSortType4 = filterSortType[1];
				}
				if (this._firstFilterData != null && this._firstFilterData.FilterItemType == eFilterItemType2 && this._secondFilterData != null && this._secondFilterData.FilterItemType == eFilterItemType3 && this._thirdFilterData == null)
				{
					return;
				}
				this._thirdFilterData = null;
				if (AuctionNewUtility.IsFilterDataNeedReset(this._firstFilterData, eFilterItemType2))
				{
					this._firstFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType2, filterSortType3);
				}
				if (AuctionNewUtility.IsFilterDataNeedReset(this._secondFilterData, eFilterItemType3))
				{
					this._secondFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType3, filterSortType4);
				}
				this.InitAuctionNewFilterView();
			}
			else if (filterItemType.Count == 3)
			{
				AuctionNewFrameTable.eFilterItemType eFilterItemType4 = filterItemType[0];
				AuctionNewFrameTable.eFilterItemType eFilterItemType5 = filterItemType[1];
				AuctionNewFrameTable.eFilterItemType eFilterItemType6 = filterItemType[2];
				int filterSortType5 = 1;
				int filterSortType6 = 1;
				int filterSortType7 = 1;
				if (filterSortType != null && filterSortType.Count == 3)
				{
					filterSortType5 = filterSortType[0];
					filterSortType6 = filterSortType[1];
					filterSortType7 = filterSortType[2];
				}
				if (this._firstFilterData != null && this._firstFilterData.FilterItemType == eFilterItemType4 && this._secondFilterData != null && this._secondFilterData.FilterItemType == eFilterItemType5 && this._thirdFilterData != null && this._thirdFilterData.FilterItemType == eFilterItemType6)
				{
					return;
				}
				if (AuctionNewUtility.IsFilterDataNeedReset(this._firstFilterData, eFilterItemType4))
				{
					this._firstFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType4, filterSortType5);
				}
				if (AuctionNewUtility.IsFilterDataNeedReset(this._secondFilterData, eFilterItemType5))
				{
					this._secondFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType5, filterSortType6);
				}
				if (AuctionNewUtility.IsFilterDataNeedReset(this._thirdFilterData, eFilterItemType6))
				{
					this._thirdFilterData = DataManager<AuctionNewDataManager>.GetInstance().GetDefaultAuctionNewFilterData(eFilterItemType6, filterSortType7);
				}
				this.InitAuctionNewFilterView();
			}
		}

		// Token: 0x0600CB6E RID: 52078 RVA: 0x0031DC64 File Offset: 0x0031C064
		private void InitAuctionNewFilterView()
		{
			if (this.auctionNewFilterView != null)
			{
				this.auctionNewFilterView.InitAuctionNewFilterView(this._firstFilterData, new OnAuctionNewFilterElementItemButtonClick(this.OnFirstFilterElementItemSelected), this._secondFilterData, new OnAuctionNewFilterElementItemButtonClick(this.OnSecondFilterElementItemSelected), this._thirdFilterData, new OnAuctionNewFilterElementItemButtonClick(this.OnThirdFilterElementItemSelected));
			}
			this._isHaveFilter = false;
			if (this._firstFilterData != null && this._firstFilterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_NONE)
			{
				this._isHaveFilter = true;
			}
			if (this._secondFilterData != null && this._secondFilterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_NONE)
			{
				this._isHaveFilter = true;
			}
			if (!this._isHaveFilter && this._thirdFilterData != null && this._thirdFilterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_NONE)
			{
				this._isHaveFilter = true;
			}
		}

		// Token: 0x0600CB6F RID: 52079 RVA: 0x0031DD3B File Offset: 0x0031C13B
		private void OnFirstFilterElementItemSelected(AuctionNewFilterData auctionNewFilterData)
		{
			this._firstFilterData = auctionNewFilterData;
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB70 RID: 52080 RVA: 0x0031DD4A File Offset: 0x0031C14A
		private void OnSecondFilterElementItemSelected(AuctionNewFilterData auctionNewFilterData)
		{
			this._secondFilterData = auctionNewFilterData;
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB71 RID: 52081 RVA: 0x0031DD59 File Offset: 0x0031C159
		private void OnThirdFilterElementItemSelected(AuctionNewFilterData auctionNewFilterData)
		{
			this._thirdFilterData = auctionNewFilterData;
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB72 RID: 52082 RVA: 0x0031DD68 File Offset: 0x0031C168
		private void OnAuctionNewReceiveItemNumResSucceed(UIEvent uiEvent)
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
			List<AuctionItemBaseInfo> auctionNewItemNumResList = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewItemNumResList(num);
			this.UpdateAuctionNewShowItemList(auctionNewItemNumResList);
			this.OnUpdateOnSaleItemView();
		}

		// Token: 0x0600CB73 RID: 52083 RVA: 0x0031DDC4 File Offset: 0x0031C1C4
		private void OnUpdateOnSaleItemView()
		{
			if (this._auctionNewItemResList == null)
			{
				return;
			}
			int count = this._auctionNewItemResList.Count;
			this.StopOnSaleItemScrollView();
			if (this.onSaleItemList != null)
			{
				this.onSaleItemList.ResetContentPosition();
				this.onSaleItemList.SetElementAmount(count);
			}
		}

		// Token: 0x0600CB74 RID: 52084 RVA: 0x0031DE17 File Offset: 0x0031C217
		private void StopOnSaleItemScrollView()
		{
			if (this.onSaleItemList != null && this.onSaleItemList.m_scrollRect != null)
			{
				this.onSaleItemList.m_scrollRect.StopMovement();
			}
		}

		// Token: 0x0600CB75 RID: 52085 RVA: 0x0031DE50 File Offset: 0x0031C250
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._auctionNewItemResList.Count)
			{
				return;
			}
			AuctionItemBaseInfo auctionItemBaseInfo = this._auctionNewItemResList[item.m_index];
			AuctionNewBuyNoticeOnSaleItem component = item.GetComponent<AuctionNewBuyNoticeOnSaleItem>();
			if (auctionItemBaseInfo != null && component != null)
			{
				component.InitItem(this._mainTabType, auctionItemBaseInfo, new OnAuctionNewOnSaleItemClick(this.OnAuctionNewOnSaleItemClick));
			}
		}

		// Token: 0x0600CB76 RID: 52086 RVA: 0x0031DED4 File Offset: 0x0031C2D4
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewBuyNoticeOnSaleItem component = item.GetComponent<AuctionNewBuyNoticeOnSaleItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CB77 RID: 52087 RVA: 0x0031DF07 File Offset: 0x0031C307
		private void OnAuctionNewOnSaleItemClick(AuctionItemBaseInfo auctionItemBaseInfo)
		{
			if (this._onBuyNoticeOnSaleItemClick != null && auctionItemBaseInfo != null)
			{
				this._onBuyNoticeOnSaleItemClick(auctionItemBaseInfo);
			}
		}

		// Token: 0x0600CB78 RID: 52088 RVA: 0x0031DF28 File Offset: 0x0031C328
		private void UpdateAuctionNewShowItemList(List<AuctionItemBaseInfo> auctionNewOnSaleItemList)
		{
			if (this._auctionNewItemResList == null)
			{
				this._auctionNewItemResList = new List<AuctionItemBaseInfo>();
			}
			this._auctionNewItemResList.Clear();
			for (int i = 0; i < auctionNewOnSaleItemList.Count; i++)
			{
				AuctionItemBaseInfo auctionItemBaseInfo = auctionNewOnSaleItemList[i];
				if (auctionItemBaseInfo != null)
				{
					int itemTypeId = (int)auctionItemBaseInfo.itemTypeId;
					if (AuctionNewUtility.IsItemOfOnSaleCanShow(itemTypeId, this._firstFilterData, this._secondFilterData, this._thirdFilterData))
					{
						if (this._mainTabType == AuctionNewMainTabType.AuctionBuyType)
						{
							if (this._onlyShowTreasureItmFlag)
							{
								if (auctionItemBaseInfo.isTreas == 1)
								{
									this._auctionNewItemResList.Add(auctionItemBaseInfo);
								}
							}
							else
							{
								this._auctionNewItemResList.Add(auctionItemBaseInfo);
							}
						}
						else
						{
							this._auctionNewItemResList.Add(auctionItemBaseInfo);
						}
					}
				}
			}
			AuctionNewUtility.SortOnSaleItemList(this._auctionNewItemResList);
			if (this._onlyShowOnSaleItemFlag)
			{
				return;
			}
			if (this._itemIdList == null)
			{
				this._itemIdList = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewItemIdList(this._firstLayerMenuDataModel, this._secondLayerMenuDataModel, this._thirdLayerMenuDataModel);
			}
			if (this._itemIdList == null || this._itemIdList.Count <= 0)
			{
				return;
			}
			List<ItemTable> list = new List<ItemTable>();
			for (int j = 0; j < this._itemIdList.Count; j++)
			{
				int itemId = this._itemIdList[j];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemIdList[j], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this._mainTabType != AuctionNewMainTabType.AuctionBuyType || !this._onlyShowTreasureItmFlag || tableItem.IsTreas != 0)
					{
						if (this._mainTabType != AuctionNewMainTabType.AuctionNoticeType || tableItem.IsTreas != 0)
						{
							bool flag = AuctionNewUtility.IsItemCanShow(tableItem, this._firstFilterData);
							if (flag)
							{
								flag = AuctionNewUtility.IsItemCanShow(tableItem, this._secondFilterData);
							}
							if (flag)
							{
								flag = AuctionNewUtility.IsItemCanShow(tableItem, this._thirdFilterData);
							}
							if (flag)
							{
								bool flag2 = DataManager<AuctionNewDataManager>.GetInstance().IsNotOnSaleItemNeedBeDeleted(itemId);
								if (!flag2)
								{
									list.Add(tableItem);
								}
							}
						}
					}
				}
			}
			AuctionNewUtility.SortOnSaleItemTableList(list);
			for (int k = 0; k < list.Count; k++)
			{
				ItemTable itemTable = list[k];
				if (itemTable != null)
				{
					bool flag3 = AuctionNewUtility.IsItemOnSale(itemTable, auctionNewOnSaleItemList);
					if (!flag3)
					{
						AuctionItemBaseInfo auctionItemBaseInfo2 = new AuctionItemBaseInfo
						{
							itemTypeId = (uint)itemTable.ID,
							num = 0U,
							isTreas = (byte)itemTable.IsTreas
						};
						if (this._mainTabType == AuctionNewMainTabType.AuctionBuyType && !this._isShowTreasure)
						{
							auctionItemBaseInfo2.isTreas = 0;
						}
						this._auctionNewItemResList.Add(auctionItemBaseInfo2);
					}
				}
			}
		}

		// Token: 0x0600CB79 RID: 52089 RVA: 0x0031E21D File Offset: 0x0031C61D
		private void OnOnlyShowOnSaleItemButtonClick(bool value)
		{
			this._onlyShowOnSaleItemFlag = value;
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB7A RID: 52090 RVA: 0x0031E22C File Offset: 0x0031C62C
		private void OnOnlyShowTreasureItemButtonClick(bool value)
		{
			this._onlyShowTreasureItmFlag = value;
			this.BuyNoticeOnSaleSendReq();
		}

		// Token: 0x0600CB7B RID: 52091 RVA: 0x0031E23C File Offset: 0x0031C63C
		private bool IsSameOnSaleLayer(AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, AuctionNewMenuTabDataModel secondLayerMenuTabDataModel, AuctionNewMenuTabDataModel thirdLayerMenuTabDataModel, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.None)
		{
			return auctionNewMainTabType == this._mainTabType && (thirdLayerMenuTabDataModel == null || this._thirdLayerMenuDataModel != null) && (thirdLayerMenuTabDataModel != null || this._thirdLayerMenuDataModel == null) && (thirdLayerMenuTabDataModel == null || this._thirdLayerMenuDataModel == null || thirdLayerMenuTabDataModel.Id == this._thirdLayerMenuDataModel.Id) && (secondLayerMenuTabDataModel == null || this._secondLayerMenuDataModel != null) && (secondLayerMenuTabDataModel != null || this._secondLayerMenuDataModel == null) && (secondLayerMenuTabDataModel == null || this._secondLayerMenuDataModel == null || secondLayerMenuTabDataModel.Id == this._secondLayerMenuDataModel.Id) && (firstLayerMenuTabDataModel == null || this._firstLayerMenuDataModel != null) && (firstLayerMenuTabDataModel != null || this._firstLayerMenuDataModel == null) && (firstLayerMenuTabDataModel == null || this._firstLayerMenuDataModel == null || firstLayerMenuTabDataModel.Id == this._firstLayerMenuDataModel.Id);
		}

		// Token: 0x04007629 RID: 30249
		private bool _isHaveFilter;

		// Token: 0x0400762A RID: 30250
		private AuctionNewMenuTabDataModel _firstLayerMenuDataModel;

		// Token: 0x0400762B RID: 30251
		private AuctionNewMenuTabDataModel _secondLayerMenuDataModel;

		// Token: 0x0400762C RID: 30252
		private AuctionNewMenuTabDataModel _thirdLayerMenuDataModel;

		// Token: 0x0400762D RID: 30253
		private AuctionNewFilterData _firstFilterData;

		// Token: 0x0400762E RID: 30254
		private AuctionNewFilterData _secondFilterData;

		// Token: 0x0400762F RID: 30255
		private AuctionNewFilterData _thirdFilterData;

		// Token: 0x04007630 RID: 30256
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x04007631 RID: 30257
		private List<AuctionItemBaseInfo> _auctionNewItemResList;

		// Token: 0x04007632 RID: 30258
		[SerializeField]
		private AuctionNewFilterView auctionNewFilterView;

		// Token: 0x04007633 RID: 30259
		private OnBuyNoticeOnSaleItemClick _onBuyNoticeOnSaleItemClick;

		// Token: 0x04007634 RID: 30260
		private OnUpdateFilterBackground _onUpdateFilterBackground;

		// Token: 0x04007635 RID: 30261
		private List<int> _itemIdList;

		// Token: 0x04007636 RID: 30262
		private bool _isShowTreasure;

		// Token: 0x04007637 RID: 30263
		private bool _onlyShowOnSaleItemFlag = true;

		// Token: 0x04007638 RID: 30264
		private bool _onlyShowTreasureItmFlag;

		// Token: 0x04007639 RID: 30265
		[Space(10f)]
		[Header("ItemList")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx onSaleItemList;

		// Token: 0x0400763A RID: 30266
		[SerializeField]
		private GameObject onSaleItemListRoot;

		// Token: 0x0400763B RID: 30267
		[SerializeField]
		private GameObject onSaleItemHaveFilterRoot;

		// Token: 0x0400763C RID: 30268
		[SerializeField]
		private GameObject onSaleItemNoFilterRoot;

		// Token: 0x0400763D RID: 30269
		[Space(10f)]
		[Header("ToggleSelected")]
		[Space(5f)]
		[SerializeField]
		private AuctionNewToggleSelectedController onlyShowOnSaleItemController;

		// Token: 0x0400763E RID: 30270
		[SerializeField]
		private AuctionNewToggleSelectedController onlyShowTreasureItemController;
	}
}

using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001452 RID: 5202
	internal class AuctionFrame : ClientFrame
	{
		// Token: 0x0600C989 RID: 51593 RVA: 0x00310AF0 File Offset: 0x0030EEF0
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length >= 3)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewFrame>(null, false);
					AuctionNewUserData userData = AuctionNewUtility.ConvertToAuctionNewUserData(new OutComeAuctionData
					{
						eLabelType = (AuctionPage)int.Parse(array[0]),
						CurBaseType = (AuctionMainItemType)int.Parse(array[1]),
						CurBuyPageState = (AuctionBuyPageState)int.Parse(array[2])
					});
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewFrame>(FrameLayer.Middle, userData, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600C98A RID: 51594 RVA: 0x00310B94 File Offset: 0x0030EF94
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Auction/AuctionFrame";
		}

		// Token: 0x0600C98B RID: 51595 RVA: 0x00310B9B File Offset: 0x0030EF9B
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.OutData = (this.userData as OutComeAuctionData);
			}
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0600C98C RID: 51596 RVA: 0x00310BC5 File Offset: 0x0030EFC5
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
		}

		// Token: 0x0600C98D RID: 51597 RVA: 0x00310BD4 File Offset: 0x0030EFD4
		private void ClearData()
		{
			this.CurAuctionPage = AuctionPage.AuctionBuyPage;
			this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
			this.CurBaseType = AuctionMainItemType.AMIT_INVALID;
			this.CurSelJobType = AuctionClassify.eJob.AC_JIANSHI;
			this.CurSelLevelIndex = 0;
			this.WeaponSellevelIndex = 0;
			this.CurSelQualityIndex = 0;
			this.CurSelPriceSortIndex = 0;
			this.bInitBuyItemScrollBind = false;
			this.bInitSellItemScrollBind = false;
			this.bInitPackageItemScrollBind = false;
			this.bInitSearchListScrollBind = false;
			this.CurSelSubTypeFirstMenuIndex = 0;
			this.CurSelSubTypeSecondMenuIndex = 0;
			this.CurSelectItemIndex = 0;
			this.CurBuyIndex = 0;
			this.CurSelOnSaleItemIndex = 0;
			this.MaxOnSaleItemNum = 0;
			this.CurPage = 1;
			this.MaxPage = 0;
			this.OutData = null;
			this.SearchItemTypeID = 0;
			this.SelSearchItemState = false;
			this.bHasSearchedItem = false;
			this.bOnlyShowOnSaleItem = true;
			this.PackingData = null;
			for (int i = 0; i < this.SubTypeFirstMenuObjList.Count; i++)
			{
				ComAuctionFirstMenu component = this.SubTypeFirstMenuObjList[i].GetComponent<ComAuctionFirstMenu>();
				if (!(component == null))
				{
					component.tgFirstMenu.onValueChanged.RemoveAllListeners();
				}
			}
			this.SubTypeFirstMenuObjList.Clear();
			foreach (KeyValuePair<int, List<GameObject>> keyValuePair in this.SubTypeSecondMenuObjDict)
			{
				List<GameObject> value = keyValuePair.Value;
				if (value != null)
				{
					for (int j = 0; j < value.Count; j++)
					{
						ComAuctionSecondMenu component2 = value[j].GetComponent<ComAuctionSecondMenu>();
						if (!(component2 == null))
						{
							component2.tgSecondMenu.onValueChanged.RemoveAllListeners();
						}
					}
				}
			}
			this.SubTypeSecondMenuObjDict.Clear();
			this._subTypeSecondMenuFlagDict.Clear();
			this.SubTypeMenuGroupObjList.Clear();
			this.ShowItemTypeList.Clear();
			this.ShowItemList.Clear();
			this.SelfOnSaleItemList.Clear();
			this.SelfOnSaleItemFliterList.Clear();
			this.PackageItemsUid.Clear();
			this.PackageItemsFliterUid.Clear();
			this.ItemDetailList.Clear();
			this.SearchItemList.Clear();
			this.iMaxAddFieldNum = 0;
			this.iAuctionRefreshTime = 0;
			this.bCanFreeRefresh = false;
			this.iRefreshCostNum = 0;
			this.mItemNameInput.onValueChanged.RemoveListener(new UnityAction<string>(this.OnItemNameInputEnd));
			this.requestServerReturnSuccess = false;
		}

		// Token: 0x0600C98E RID: 51598 RVA: 0x00310E2F File Offset: 0x0030F22F
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600C98F RID: 51599 RVA: 0x00310E31 File Offset: 0x0030F231
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600C990 RID: 51600 RVA: 0x00310E34 File Offset: 0x0030F234
		private void OnItemAttrChanged(UIEvent iEvent)
		{
			EItemProperty eitemProperty = (EItemProperty)iEvent.Param2;
			if (eitemProperty == EItemProperty.EP_SEAL_STATE)
			{
				this.RefreshForSaleScrollRect();
			}
		}

		// Token: 0x0600C991 RID: 51601 RVA: 0x00310E5B File Offset: 0x0030F25B
		[UIEventHandle("Title/Close")]
		private void OnClose()
		{
			this.ClearData();
			this.frameMgr.CloseFrame<AuctionFrame>(this, false);
		}

		// Token: 0x0600C992 RID: 51602 RVA: 0x00310E70 File Offset: 0x0030F270
		private AuctionClassify.eJob GetJobIDByType(int curJobType)
		{
			if (curJobType == 10)
			{
				return AuctionClassify.eJob.AC_JIANSHI;
			}
			if (curJobType == 20)
			{
				return AuctionClassify.eJob.AC_QIANGSHOU;
			}
			if (curJobType == 30)
			{
				return AuctionClassify.eJob.AC_FASHI;
			}
			if (curJobType == 40)
			{
				return AuctionClassify.eJob.AC_GEDOU;
			}
			if (curJobType == 50)
			{
				return AuctionClassify.eJob.AC_QIANGSHOU;
			}
			return AuctionClassify.eJob.AC_JOB_ALL;
		}

		// Token: 0x0600C993 RID: 51603 RVA: 0x00310EA8 File Offset: 0x0030F2A8
		[UIEventHandle("Type/ItemType{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 6)]
		private void OnSwitchBaseType(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (this.CurAuctionPage != AuctionPage.AuctionBuyPage)
			{
				return;
			}
			bool flag = true;
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				flag = false;
			}
			if (this.OutData != null && this.OutData.CurBaseType != AuctionMainItemType.AMIT_NUM)
			{
				flag = false;
				this.OutData.CurBaseType = AuctionMainItemType.AMIT_NUM;
			}
			else if (iIndex != (int)this.CurBaseType)
			{
				flag = false;
			}
			if (flag && !this.bHasSearchedItem)
			{
				return;
			}
			this.CurBaseType = (AuctionMainItemType)iIndex;
			this.CurSelSubTypeSecondMenuIndex = 0;
			this.CurSelectItemIndex = 0;
			this.CurPage = 1;
			int baseJobID = Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			this.CurSelJobType = this.GetJobIDByType(baseJobID);
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				this.CurSelSubTypeFirstMenuIndex = (int)this.CurSelJobType;
			}
			else
			{
				this.CurSelSubTypeFirstMenuIndex = 0;
			}
			if (this.CurBaseType == AuctionMainItemType.AMIT_COST || this.CurBaseType == AuctionMainItemType.AMIT_MATERIAL)
			{
				this.CurSelLevelIndex = 0;
			}
			else
			{
				this.CurSelLevelIndex = this.WeaponSellevelIndex;
			}
			if (this.CurBaseType != AuctionMainItemType.AMIT_COST && this.CurBaseType != AuctionMainItemType.AMIT_MATERIAL)
			{
				this.UpdateSelLvShow();
			}
			else
			{
				this.mLvSelRootObj.CustomActive(false);
			}
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON || this.CurBaseType == AuctionMainItemType.AMIT_ARMOR || this.CurBaseType == AuctionMainItemType.AMIT_COST)
			{
				this.mSubTypeToggleGroup.allowSwitchOff = true;
			}
			else
			{
				this.mSubTypeToggleGroup.allowSwitchOff = false;
			}
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				this.bInitBuyItemScrollBind = false;
			}
			this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
			this.bHasSearchedItem = false;
			this.mItemNameInput.text = string.Empty;
			this.SearchItemTypeID = 0;
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			this.requestServerReturnSuccess = false;
			this.SendItemTypeListReq(this.CurBaseType);
			this.UpdateSubTypeMenuGroupPrefabs();
		}

		// Token: 0x0600C994 RID: 51604 RVA: 0x00311088 File Offset: 0x0030F488
		private void OnChooseFirstMenu(int iIndex, bool value)
		{
			if (iIndex < 0 || this.SubTypeMenuGroupObjList.Count <= 0 || iIndex >= this.SubTypeMenuGroupObjList.Count || this.SubTypeFirstMenuObjList.Count <= 0 || iIndex >= this.SubTypeFirstMenuObjList.Count)
			{
				return;
			}
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			ComSubTypeMenuGroup component = this.SubTypeMenuGroupObjList[iIndex].GetComponent<ComSubTypeMenuGroup>();
			if (component == null)
			{
				return;
			}
			ComAuctionFirstMenu component2 = this.SubTypeFirstMenuObjList[iIndex].GetComponent<ComAuctionFirstMenu>();
			if (component2 == null)
			{
				return;
			}
			if (!value)
			{
				if (iIndex == this.CurSelSubTypeFirstMenuIndex)
				{
					this.mItemNameInput.text = string.Empty;
					this.SearchItemTypeID = 0;
					if (this.bHasSearchedItem)
					{
						this.ShowItemTypeList.Clear();
						this.UpdateAuctionItemPrefabs(this.ShowItemTypeList.Count);
					}
					component.SecondMenuRoot.CustomActive(false);
					component2.UpArrow.gameObject.CustomActive(false);
					component2.DownArrow.gameObject.CustomActive(false);
					if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON || (this.CurBaseType == AuctionMainItemType.AMIT_ARMOR && iIndex != 0) || (this.CurBaseType == AuctionMainItemType.AMIT_COST && DataManager<AuctionDataManager>.GetInstance().BConsumableIsHasSecendTab(iIndex)))
					{
						component2.UpArrow.gameObject.CustomActive(true);
					}
				}
				return;
			}
			if (this.IsShowSecondMenuTabs(iIndex))
			{
				component.SecondMenuRoot.CustomActive(true);
				component2.UpArrow.gameObject.CustomActive(false);
				component2.DownArrow.gameObject.CustomActive(true);
				this.IsCreateSecondMenuTabs(iIndex);
			}
			bool flag = true;
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage && this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				flag = false;
			}
			if (iIndex == this.CurSelSubTypeFirstMenuIndex && flag && !this.bHasSearchedItem)
			{
				return;
			}
			this.CurSelSubTypeFirstMenuIndex = iIndex;
			this.CurSelSubTypeSecondMenuIndex = 0;
			this.CurSelectItemIndex = 0;
			this.CurPage = 1;
			this.bHasSearchedItem = false;
			this.mItemNameInput.text = string.Empty;
			this.SearchItemTypeID = 0;
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				this.CurSelJobType = (AuctionClassify.eJob)iIndex;
			}
			if (this.CurBaseType == AuctionMainItemType.AMIT_JEWELRY && iIndex == 4)
			{
				this.CurSelLevelIndex = 0;
				this.UpdateSelLvShow();
			}
			if (this.CurBaseType == AuctionMainItemType.AMIT_JEWELRY && iIndex != 4)
			{
				this.CurSelLevelIndex = this.WeaponSellevelIndex;
				this.UpdateSelLvShow();
			}
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				this.bInitBuyItemScrollBind = false;
			}
			this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
			this.SendItemTypeListReq(this.CurBaseType);
			List<GameObject> list = new List<GameObject>();
			if (this.SubTypeSecondMenuObjDict.TryGetValue(iIndex, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					ComAuctionSecondMenu component3 = list[i].GetComponent<ComAuctionSecondMenu>();
					if (!(component3 == null))
					{
						component3.tgSecondMenu.isOn = false;
						if (i == 0)
						{
							component3.tgSecondMenu.isOn = true;
						}
					}
				}
			}
		}

		// Token: 0x0600C995 RID: 51605 RVA: 0x0031139C File Offset: 0x0030F79C
		private void OnChooseSecondMenu(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			bool flag = true;
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage && this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				flag = false;
			}
			if (iIndex == this.CurSelSubTypeSecondMenuIndex && flag && !this.bHasSearchedItem)
			{
				return;
			}
			this.CurSelSubTypeSecondMenuIndex = iIndex;
			this.CurSelectItemIndex = 0;
			this.CurPage = 1;
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				this.CurSelJobType = (AuctionClassify.eJob)this.CurSelSubTypeFirstMenuIndex;
			}
			this.bHasSearchedItem = false;
			this.mItemNameInput.text = string.Empty;
			this.SearchItemTypeID = 0;
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemList)
			{
				this.bInitBuyItemScrollBind = false;
			}
			this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
			this.SendItemTypeListReq(this.CurBaseType);
		}

		// Token: 0x0600C996 RID: 51606 RVA: 0x00311464 File Offset: 0x0030F864
		private void OnSelItemType(int iIndex)
		{
			if (iIndex < 0)
			{
				return;
			}
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage && this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList)
			{
				if (iIndex >= this.ShowItemTypeList.Count || this.ShowItemTypeList[iIndex].num <= 0U)
				{
					return;
				}
				this.CurSelectItemIndex = iIndex;
				this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemList;
				this.bInitBuyItemScrollBind = false;
				this.SendItemListReq();
			}
			else if (this.CurAuctionPage == AuctionPage.MyAuctionPage && this.SelfOnSaleItemFliterListNew.Count - 1 == this.MaxOnSaleItemNum && DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.iMaxAddFieldNum)
			{
				if (iIndex != this.SelfOnSaleItemFliterListNew.Count - 1)
				{
					return;
				}
				AuctionBoothTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionBoothTable>(DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + 1, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format("是否花费{0}{1}购买1个永久栏位？", tableItem.Num, DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(tableItem.CostItemID)), new UnityAction(this.OnBuyFieldOK), null, 0f, false);
			}
		}

		// Token: 0x0600C997 RID: 51607 RVA: 0x0031159C File Offset: 0x0030F99C
		private void OnBuyFieldOK()
		{
			AuctionBoothTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionBoothTable>(DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + 1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum >= this.iMaxAddFieldNum)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已达最大购买栏位数量", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = tableItem.CostItemID;
			costInfo.nCount = tableItem.Num;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendBuyField();
			}, "common_money_cost", null);
		}

		// Token: 0x0600C998 RID: 51608 RVA: 0x00311630 File Offset: 0x0030FA30
		private void OnBuyOrSell(int iIndex)
		{
			if (iIndex < 0)
			{
				return;
			}
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				if (iIndex >= this.ShowItemList.Count || this.ShowItemList[iIndex].num <= 0U)
				{
					return;
				}
				this.CurBuyIndex = iIndex;
				if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.ShowItemList[iIndex].itemTypeId, string.Empty, string.Empty) == null)
				{
					return;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionBuyFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionBuyFrame>(null, false);
				}
				BuyItemData buyItemData = default(BuyItemData);
				buyItemData.SetItemDataByAuction(this.ShowItemList[iIndex]);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionBuyFrame>(FrameLayer.Middle, buyItemData, string.Empty);
			}
			else
			{
				if (this.CurAuctionPage != AuctionPage.MyAuctionPage)
				{
					return;
				}
				if (this.CurSelOnSaleItemIndex < 0 || this.SelfOnSaleItemFliterList.Count <= 0 || this.CurSelOnSaleItemIndex >= this.SelfOnSaleItemFliterList.Count)
				{
					return;
				}
				this.CurSelOnSaleItemIndex = iIndex;
				SystemNotifyManager.SystemNotify(1038, new UnityAction(this.OnClickOffAuction));
			}
		}

		// Token: 0x0600C999 RID: 51609 RVA: 0x00311764 File Offset: 0x0030FB64
		private void OnClickOffAuction()
		{
			if (this.SelfOnSaleItemFliterList == null || this.CurSelOnSaleItemIndex < 0 || this.CurSelOnSaleItemIndex >= this.SelfOnSaleItemFliterList.Count)
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionCancel>(ServerType.GATE_SERVER, new WorldAuctionCancel
			{
				id = this.SelfOnSaleItemFliterList[this.CurSelOnSaleItemIndex].guid
			});
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			this.CurSelOnSaleItemIndex = 0;
		}

		// Token: 0x0600C99A RID: 51610 RVA: 0x003117E4 File Offset: 0x0030FBE4
		private void OnShowItemDetailData(int iIndex)
		{
			ulong guid;
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList)
				{
					if (iIndex >= this.ShowItemTypeList.Count)
					{
						return;
					}
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.ShowItemTypeList[iIndex].itemTypeId, 100, 0);
					if (itemData == null)
					{
						return;
					}
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					return;
				}
				else
				{
					if (iIndex >= this.ShowItemList.Count)
					{
						return;
					}
					guid = this.ShowItemList[iIndex].guid;
				}
			}
			else
			{
				if (iIndex >= this.SelfOnSaleItemFliterList.Count)
				{
					return;
				}
				guid = this.SelfOnSaleItemFliterList[iIndex].guid;
			}
			ItemData a_item = null;
			if (!this.ItemDetailList.TryGetValue(guid, out a_item))
			{
				this.SendItemDetailReq(guid);
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600C99B RID: 51611 RVA: 0x003118C8 File Offset: 0x0030FCC8
		private void OnShowPackageItemDetailData(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.PackageItemsFliterUid.Count)
			{
				return;
			}
			ulong uId = this.PackageItemsFliterUid[iIndex].uId;
			ItemData a_item = null;
			if (!this.ItemDetailList.TryGetValue(uId, out a_item))
			{
				this.SendItemDetailReq(uId);
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600C99C RID: 51612 RVA: 0x00311930 File Offset: 0x0030FD30
		[UIEventHandle("btMyAuction")]
		private void OnMyAuction()
		{
			if (!this.requestServerReturnSuccess)
			{
				return;
			}
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = true;
			this.requestServerReturnSuccess = false;
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				this.SendSelfAuctionList();
				this.UpdatePackageItemData();
			}
			else
			{
				this.CurBaseType = AuctionMainItemType.AMIT_WEAPON;
				this.CurSelSubTypeFirstMenuIndex = (int)this.CurSelJobType;
				this.CurSelSubTypeSecondMenuIndex = 0;
				this.SendItemTypeListReq(this.CurBaseType);
			}
		}

		// Token: 0x0600C99D RID: 51613 RVA: 0x003119A0 File Offset: 0x0030FDA0
		private void OnSelPackageItem(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (iIndex >= this.PackageItemsFliterUid.Count)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.PackageItemsFliterUid[iIndex].uId);
			if (item == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionSellFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionSellFrame>(null, false);
			}
			if (item.IsNeedPacking())
			{
				this.PackingData = item;
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("Auction_item_packing"), new UnityAction(this.ClickOKPacking), null, 0f, false);
			}
			else
			{
				AuctionSellBaseData auctionSellBaseData = default(AuctionSellBaseData);
				auctionSellBaseData.PackageItemGuid = this.PackageItemsFliterUid[iIndex].uId;
				auctionSellBaseData.MaxOnSaleItemNum = this.MaxOnSaleItemNum;
				auctionSellBaseData.SelfOnSaleNum = this.SelfOnSaleItemList.Count;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionSellFrame>(FrameLayer.Middle, auctionSellBaseData, string.Empty);
			}
		}

		// Token: 0x0600C99E RID: 51614 RVA: 0x00311A9C File Offset: 0x0030FE9C
		private void ClickOKPacking()
		{
			if (this.PackingData == null)
			{
				return;
			}
			SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
			smithShopNewLinkData.itemData = this.PackingData;
			smithShopNewLinkData.iDefaultFirstTabId = 7;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
		}

		// Token: 0x0600C99F RID: 51615 RVA: 0x00311AEC File Offset: 0x0030FEEC
		private void OnSelSearchItem(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.SearchItemList.Count)
			{
				return;
			}
			this.SearchItemTypeID = this.SearchItemList[iIndex].ItemTypeID;
			this.SelSearchItemState = true;
			this.mItemNameInput.text = this.SearchItemList[iIndex].Name;
		}

		// Token: 0x0600C9A0 RID: 51616 RVA: 0x00311B54 File Offset: 0x0030FF54
		[UIEventHandle("Levelselect/LevelList/Level{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnSelLevel(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON || this.CurBaseType == AuctionMainItemType.AMIT_ARMOR || this.CurBaseType == AuctionMainItemType.AMIT_JEWELRY)
			{
				this.WeaponSellevelIndex = iIndex;
			}
			this.CurSelLevelIndex = iIndex;
			this.UpdateSelLvShow();
			if (!this.bHasSearchedItem)
			{
				this.SendItemTypeListReq(this.CurBaseType);
			}
		}

		// Token: 0x0600C9A1 RID: 51617 RVA: 0x00311BBE File Offset: 0x0030FFBE
		[UIEventHandle("Qualityselect/QualityList/Quality{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 7)]
		private void OnSelQuality(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.CurSelQualityIndex = iIndex;
			this.UpdateSelQualityShow();
			if (!this.bHasSearchedItem)
			{
				this.SendItemTypeListReq(this.CurBaseType);
			}
		}

		// Token: 0x0600C9A2 RID: 51618 RVA: 0x00311BF2 File Offset: 0x0030FFF2
		[UIEventHandle("Priceselect/PriceList/Price{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void OnSelPriceSort(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.CurSelPriceSortIndex = iIndex;
			this.mPriceList.CustomActive(false);
			this.SendItemListReq();
		}

		// Token: 0x0600C9A3 RID: 51619 RVA: 0x00311C1C File Offset: 0x0031001C
		private void OnItemNameInputEnd(string name)
		{
			if (string.IsNullOrEmpty(name) || name == this.mInputHoldText.text)
			{
				this.mSearchListRoot.CustomActive(false);
				return;
			}
			if (this.SelSearchItemState)
			{
				this.SelSearchItemState = false;
				return;
			}
			List<ItemTable> list = Singleton<ItemSearchEngine>.GetInstance().FindItemListByName(name);
			if (list == null || list.Count <= 0)
			{
				this.mSearchListRoot.CustomActive(false);
				return;
			}
			this.SearchItemList.Clear();
			this.SearchItemTypeID = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (DataManager<ItemDataManager>.GetInstance().TradeItemStateFliter(list[i]))
				{
					SearchItemData item = default(SearchItemData);
					item.ItemTypeID = list[i].ID;
					item.Name = list[i].Name;
					this.SearchItemList.Add(item);
				}
			}
			if (this.SearchItemList.Count <= 0)
			{
				this.mSearchListRoot.CustomActive(false);
				SystemNotifyManager.SystemNotify(1097, string.Empty);
				return;
			}
			this.mSearchListRoot.CustomActive(true);
			this.InitSearchItemListBind();
			this.RefreshSearchListScrollRect();
		}

		// Token: 0x0600C9A4 RID: 51620 RVA: 0x00311D58 File Offset: 0x00310158
		private void OnClickRefreshOK()
		{
			CurrencyConfigureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CurrencyConfigureTable>(1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = tableItem.CostItemID;
			costInfo.nCount = tableItem.Num;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendRefreshItemList();
			}, "common_money_cost", null);
		}

		// Token: 0x0600C9A5 RID: 51621 RVA: 0x00311DD0 File Offset: 0x003101D0
		private void InitInterface()
		{
			this.InitData();
			this.InitShow();
			if (this.OutData != null)
			{
				if (this.OutData.eLabelType == AuctionPage.MyAuctionPage)
				{
					this.CurAuctionPage = AuctionPage.AuctionBuyPage;
					this.requestServerReturnSuccess = true;
					this.OnMyAuction();
				}
				else
				{
					this.CurAuctionPage = this.OutData.eLabelType;
					this.CurBaseType = this.OutData.CurBaseType;
					this.CurBuyPageState = this.OutData.CurBuyPageState;
					this.UpdateChoosenMainType((int)this.CurBaseType);
				}
			}
			else
			{
				this.UpdateChoosenMainType((int)(this.CurBaseType + 1));
			}
		}

		// Token: 0x0600C9A6 RID: 51622 RVA: 0x00311E70 File Offset: 0x00310270
		private void InitData()
		{
			CurrencyConfigureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CurrencyConfigureTable>(1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.iRefreshCostNum = tableItem.Num;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(24, string.Empty, string.Empty);
			this.MaxOnSaleItemNum = tableItem2.Value + DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum;
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(190, string.Empty, string.Empty);
			this.iAuctionRefreshTime = tableItem3.Value;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionBoothTable>();
			this.iMaxAddFieldNum = table.Count;
			this.CurSelLevelIndex = this.GetSelLvIndexByPlayerLv();
			this.WeaponSellevelIndex = this.CurSelLevelIndex;
			this.CurSelPriceSortIndex = 0;
		}

		// Token: 0x0600C9A7 RID: 51623 RVA: 0x00311F30 File Offset: 0x00310330
		private void InitShow()
		{
			UIGray uigray = this.mBtPre.gameObject.AddComponent<UIGray>();
			uigray.enabled = false;
			UIGray uigray2 = this.mBtNext.gameObject.AddComponent<UIGray>();
			uigray2.enabled = false;
			this.UpdateSelLvShow();
			this.mPage.CustomActive(false);
			this.mItemNameInput.onValueChanged.AddListener(new UnityAction<string>(this.OnItemNameInputEnd));
		}

		// Token: 0x0600C9A8 RID: 51624 RVA: 0x00311F9B File Offset: 0x0031039B
		private void InitShowScrollViewItemBind()
		{
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				this.InitBuyItemScrollViewBind();
			}
			else
			{
				this.InitSelfOnSaleScrollViewBind();
				this.InitPackageItemScrollViewBind();
			}
		}

		// Token: 0x0600C9A9 RID: 51625 RVA: 0x00311FC0 File Offset: 0x003103C0
		private void InitBuyItemScrollViewBind()
		{
			if (this.bInitBuyItemScrollBind)
			{
				return;
			}
			if (this.CurAuctionPage != AuctionPage.AuctionBuyPage)
			{
				return;
			}
			List<AuctionItemBaseInfo> showItemTypeList = null;
			List<AuctionBaseInfo> showItemList = null;
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList)
			{
				showItemTypeList = this.ShowItemTypeList;
			}
			else
			{
				showItemList = this.ShowItemList;
			}
			if (showItemTypeList == null && showItemList == null)
			{
				return;
			}
			if (showItemTypeList != null && showItemTypeList.Count <= 0)
			{
				return;
			}
			if (showItemList != null && showItemList.Count <= 0)
			{
				return;
			}
			this.bInitBuyItemScrollBind = true;
			this.ScrollViewRoots[0].Initialize();
			this.ScrollViewRoots[0].onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && showItemTypeList != null && item.m_index < showItemTypeList.Count)
				{
					this.UpdateShowItemBaseBind(item, showItemTypeList);
				}
				else if (item.m_index >= 0 && showItemList != null && item.m_index < showItemList.Count)
				{
					this.UpdateShowItemDetailBind(item, showItemList);
				}
			};
			this.ScrollViewRoots[0].OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComAuctionItem component = item.GetComponent<ComAuctionItem>();
				if (component == null)
				{
					return;
				}
				component.btBuy.onClick.RemoveAllListeners();
				component.btSelect.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600C9AA RID: 51626 RVA: 0x003120D0 File Offset: 0x003104D0
		private void InitSelfOnSaleScrollViewBind()
		{
			if (this.bInitSellItemScrollBind)
			{
				return;
			}
			if (this.CurAuctionPage != AuctionPage.MyAuctionPage)
			{
				return;
			}
			if (this.SelfOnSaleItemFliterListNew == null || this.SelfOnSaleItemFliterListNew.Count < 0)
			{
				return;
			}
			this.bInitSellItemScrollBind = true;
			this.ScrollViewRoots[1].Initialize();
			this.ScrollViewRoots[1].onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && this.SelfOnSaleItemFliterListNew != null && item.m_index < this.SelfOnSaleItemFliterListNew.Count)
				{
					this.UpdateShowItemDetailBind(item, this.SelfOnSaleItemFliterListNew);
				}
			};
			this.ScrollViewRoots[1].OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComAuctionItem component = item.GetComponent<ComAuctionItem>();
				if (component == null)
				{
					return;
				}
				component.btBuy.onClick.RemoveAllListeners();
				component.btSelect.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600C9AB RID: 51627 RVA: 0x0031216C File Offset: 0x0031056C
		private void InitPackageItemScrollViewBind()
		{
			if (this.bInitPackageItemScrollBind)
			{
				return;
			}
			if (this.CurAuctionPage != AuctionPage.MyAuctionPage)
			{
				return;
			}
			if (this.PackageItemsFliterUid == null || this.PackageItemsFliterUid.Count <= 0)
			{
				return;
			}
			this.bInitPackageItemScrollBind = true;
			this.ScrollViewRoots[2].Initialize();
			this.ScrollViewRoots[2].onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && this.PackageItemsFliterUid != null && item.m_index < this.PackageItemsFliterUid.Count)
				{
					this.UpdatePackageItemBind(item);
				}
			};
			this.ScrollViewRoots[2].OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComAuctionPackageItem component = item.GetComponent<ComAuctionPackageItem>();
				if (component == null)
				{
					return;
				}
				component.ItemToggle.onValueChanged.RemoveAllListeners();
			};
		}

		// Token: 0x0600C9AC RID: 51628 RVA: 0x00312208 File Offset: 0x00310608
		private void InitSearchItemListBind()
		{
			if (this.bInitSearchListScrollBind)
			{
				return;
			}
			if (this.SearchItemList.Count <= 0)
			{
				return;
			}
			this.bInitSearchListScrollBind = true;
			this.mSearchScrollViewRoot.Initialize();
			this.mSearchScrollViewRoot.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.SearchItemList.Count)
				{
					this.UpdateSearchListBind(item, this.SearchItemList);
				}
			};
			this.mSearchScrollViewRoot.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				component.GetCom<Button>("BtSelSearchItem").onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600C9AD RID: 51629 RVA: 0x00312284 File Offset: 0x00310684
		private void UpdateShowItemBaseBind(ComUIListElementScript item, List<AuctionItemBaseInfo> showItemTypeList)
		{
			ComAuctionItem component = item.GetComponent<ComAuctionItem>();
			if (component == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)showItemTypeList[item.m_index].itemTypeId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)showItemTypeList[item.m_index].itemTypeId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			component.ItemRoot.CustomActive(true);
			component.BuyFieldRoot.CustomActive(false);
			component.Tip.gameObject.CustomActive(true);
			itemData.Count = (int)showItemTypeList[item.m_index].num;
			ComItem comItem = component.pos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(component.pos);
			}
			int iIndex = item.m_index;
			comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
			{
				this.OnShowItemDetailData(iIndex);
			});
			component.name.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
			component.typename.text = string.Empty;
			component.LeftTime.gameObject.CustomActive(false);
			component.BuyBackRoot.CustomActive(false);
			component.SellBackRoot.CustomActive(false);
			component.TimeBack.gameObject.CustomActive(false);
			component.SaleNum.text = "在售:" + showItemTypeList[item.m_index].num;
			component.SaleNum.gameObject.CustomActive(true);
			component.btBuy.gameObject.CustomActive(false);
			component.btBuy.onClick.RemoveAllListeners();
			int index = item.m_index;
			component.btSelect.onClick.RemoveAllListeners();
			component.btSelect.onClick.AddListener(delegate()
			{
				this.OnSelItemType(index);
			});
		}

		// Token: 0x0600C9AE RID: 51630 RVA: 0x00312488 File Offset: 0x00310888
		private void UpdateShowItemDetailBind(ComUIListElementScript item, List<AuctionBaseInfo> showItemList)
		{
			ComAuctionItem component = item.GetComponent<ComAuctionItem>();
			if (component == null)
			{
				return;
			}
			component.btSelect.onClick.RemoveAllListeners();
			component.btBuy.onClick.RemoveAllListeners();
			component.typename.text = string.Empty;
			component.Tip.gameObject.CustomActive(false);
			if (this.CurAuctionPage == AuctionPage.MyAuctionPage && showItemList.Count - 1 == this.MaxOnSaleItemNum && DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.iMaxAddFieldNum && item.m_index == showItemList.Count - 1)
			{
				component.Des.CustomActive(false);
				component.ItemRoot.CustomActive(false);
				component.BuyFieldRoot.CustomActive(true);
				AuctionBoothTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionBoothTable>(DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + 1, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				component.CostMoney.text = Utility.GetShowPrice((ulong)((long)tableItem.Num), false);
				ETCImageLoader.LoadSprite(ref component.FieldMoneyIcon, DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(tableItem.CostItemID), true);
				if (showItemList[item.m_index].itemScore > 0U)
				{
					component.typename.text = string.Format("评分:{0}", showItemList[item.m_index].itemScore);
				}
				int idx = item.m_index;
				component.btSelect.onClick.AddListener(delegate()
				{
					this.OnSelItemType(idx);
				});
			}
			else
			{
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)showItemList[item.m_index].itemTypeId, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					component.BuyFieldRoot.CustomActive(false);
					component.ItemRoot.CustomActive(false);
					component.BuyFieldRoot.CustomActive(false);
					component.Des.CustomActive(true);
					return;
				}
				ItemData itemData = null;
				if (!this.ItemDetailList.TryGetValue(showItemList[item.m_index].guid, out itemData))
				{
					itemData = ItemDataManager.CreateItemDataFromTable((int)showItemList[item.m_index].itemTypeId, 100, 0);
					if (itemData == null)
					{
						return;
					}
					itemData.Count = (int)showItemList[item.m_index].num;
					itemData.StrengthenLevel = (int)showItemList[item.m_index].strengthed;
				}
				component.ItemRoot.CustomActive(true);
				component.BuyFieldRoot.CustomActive(false);
				ComItem comItem = component.pos.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = base.CreateComItem(component.pos);
				}
				int iIndex = item.m_index;
				comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
				{
					this.OnShowItemDetailData(iIndex);
				});
				component.name.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem2.Name, (PetTable.eQuality)tableItem2.Color);
				if (showItemList[item.m_index].itemScore > 0U)
				{
					component.typename.text = string.Format("评分:{0}", showItemList[item.m_index].itemScore);
				}
				component.LeftTime.gameObject.CustomActive(false);
				int num = (int)(showItemList[item.m_index].price / showItemList[item.m_index].num);
				if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
				{
					component.BuyBackRoot.CustomActive(true);
					component.SellBackRoot.CustomActive(false);
					component.BuyPrice.text = Utility.ToThousandsSeparator((ulong)((long)num));
				}
				else if (this.CurAuctionPage == AuctionPage.MyAuctionPage)
				{
					component.BuyBackRoot.CustomActive(false);
					component.SellBackRoot.CustomActive(true);
					component.SellPrice.text = Utility.ToThousandsSeparator((ulong)((long)num));
				}
				component.TimeBack.gameObject.CustomActive(true);
				component.SaleNum.gameObject.CustomActive(false);
				component.Des.CustomActive(false);
				int index = item.m_index;
				component.btBuy.gameObject.CustomActive(true);
				component.btBuy.onClick.AddListener(delegate()
				{
					this.OnBuyOrSell(index);
				});
			}
		}

		// Token: 0x0600C9AF RID: 51631 RVA: 0x003128E8 File Offset: 0x00310CE8
		private void UpdatePackageItemBind(ComUIListElementScript item)
		{
			ComAuctionPackageItem component = item.GetComponent<ComAuctionPackageItem>();
			if (component == null)
			{
				return;
			}
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(this.PackageItemsFliterUid[item.m_index].uId);
			if (item2 == null)
			{
				return;
			}
			ComItem comItem = component.pos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(component.pos);
			}
			int iIndex = item.m_index;
			comItem.Setup(item2, delegate(GameObject Obj, ItemData sitem)
			{
				this.OnShowPackageItemDetailData(iIndex);
			});
			ItemData itemData = null;
			if (!this.ItemDetailList.TryGetValue(this.PackageItemsFliterUid[item.m_index].uId, out itemData))
			{
				this.ItemDetailList.Add(this.PackageItemsFliterUid[item.m_index].uId, item2);
			}
			component.name.text = item2.Name;
			component.ItemToggle.group = this.mPackageItemToggleGroup;
			int index = item.m_index;
			component.ItemToggle.onValueChanged.RemoveAllListeners();
			component.ItemToggle.onValueChanged.AddListener(delegate(bool value)
			{
				this.OnSelPackageItem(index, value);
			});
			component.state.gameObject.CustomActive(item2.IsNeedPacking());
		}

		// Token: 0x0600C9B0 RID: 51632 RVA: 0x00312A40 File Offset: 0x00310E40
		private void UpdateSearchListBind(ComUIListElementScript item, List<SearchItemData> searchItemList)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			component.GetCom<Text>("SearchItemName").text = searchItemList[item.m_index].Name;
			Button com = component.GetCom<Button>("BtSelSearchItem");
			com.onClick.RemoveAllListeners();
			int index = item.m_index;
			com.onClick.AddListener(delegate()
			{
				this.OnSelSearchItem(index);
			});
		}

		// Token: 0x0600C9B1 RID: 51633 RVA: 0x00312ACC File Offset: 0x00310ECC
		private void UpdateInterface()
		{
			this.UpdatePageState();
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				this.UpdateAuctionItemListPage();
			}
			else if (this.CurAuctionPage == AuctionPage.MyAuctionPage)
			{
				this.UpdateMyAuctionPage();
			}
		}

		// Token: 0x0600C9B2 RID: 51634 RVA: 0x00312AFC File Offset: 0x00310EFC
		private void UpdateCurPage()
		{
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				this.CurAuctionPage = AuctionPage.MyAuctionPage;
			}
			else
			{
				this.CurAuctionPage = AuctionPage.AuctionBuyPage;
			}
		}

		// Token: 0x0600C9B3 RID: 51635 RVA: 0x00312B1C File Offset: 0x00310F1C
		private void UpdateAuctionItemListPage()
		{
			if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList)
			{
				if (this.ShowItemTypeList.Count <= 0 && this.bOnlyShowOnSaleItem)
				{
					this.mBuyItemTips.text = TR.Value("Auction_item_not_exist");
					this.mBuyItemTips.gameObject.CustomActive(true);
				}
				else
				{
					this.mBuyItemTips.text = string.Empty;
				}
				this.UpdateAuctionItemPrefabs(this.ShowItemTypeList.Count);
			}
			else
			{
				if (this.ShowItemList.Count <= 0)
				{
					this.mBuyItemTips.text = TR.Value("Auction_item_not_exist");
					this.mBuyItemTips.gameObject.CustomActive(true);
				}
				else
				{
					this.mBuyItemTips.text = string.Empty;
				}
				this.UpdateAuctionItemPrefabs(this.ShowItemList.Count);
				this.UpdatePage();
			}
		}

		// Token: 0x0600C9B4 RID: 51636 RVA: 0x00312C04 File Offset: 0x00311004
		private void UpdateMyAuctionPage()
		{
			this.UpdateOnSaleItemsFliterData();
			if (this.mEquipTog.isOn)
			{
				this.UpdatePackageItemsFliterUid(AuctionSellItemType.ASIT_EQUIP);
			}
			else
			{
				this.UpdatePackageItemsFliterUid(AuctionSellItemType.ASIT_CONSUMABLEMATERIA);
			}
			this._updateOnSaleTips();
			this._updateForSaleTips();
			this.PackageItemsFliterUid.Sort();
			this.InitShowScrollViewItemBind();
			this.RefreshOnSaleScrollRect();
			this.RefreshForSaleScrollRect();
		}

		// Token: 0x0600C9B5 RID: 51637 RVA: 0x00312C64 File Offset: 0x00311064
		private void _updateOnSaleTips()
		{
			if (this.SelfOnSaleItemFliterListNew.Count < 0)
			{
				this.mOnSaleTips.text = "当前没有正在拍卖的物品";
				this.mOnSaleTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mOnSaleTips.text = string.Empty;
			}
		}

		// Token: 0x0600C9B6 RID: 51638 RVA: 0x00312CB8 File Offset: 0x003110B8
		private void _updateForSaleTips()
		{
			if (this.PackageItemsFliterUid.Count <= 0)
			{
				this.mForSaleTips.text = "没有物品可上架";
				this.mForSaleTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mForSaleTips.text = string.Empty;
			}
		}

		// Token: 0x0600C9B7 RID: 51639 RVA: 0x00312D0C File Offset: 0x0031110C
		private void UpdateSubTypeMenuGroupPrefabs()
		{
			int iFirstMenuNum;
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				iFirstMenuNum = 4;
			}
			else
			{
				iFirstMenuNum = DataManager<AuctionDataManager>.GetInstance().GetSubTypeNumByMainType(this.CurBaseType);
			}
			this.UpdateAuctionFirstMenu(iFirstMenuNum);
		}

		// Token: 0x0600C9B8 RID: 51640 RVA: 0x00312D48 File Offset: 0x00311148
		private bool IsShowSecondMenuTabs(int index)
		{
			return this.CurBaseType == AuctionMainItemType.AMIT_WEAPON || (this.CurBaseType == AuctionMainItemType.AMIT_ARMOR && index != 0) || (this.CurBaseType == AuctionMainItemType.AMIT_COST && DataManager<AuctionDataManager>.GetInstance().BConsumableIsHasSecendTab(index));
		}

		// Token: 0x0600C9B9 RID: 51641 RVA: 0x00312D98 File Offset: 0x00311198
		private void IsCreateSecondMenuTabs(int index)
		{
			bool flag = false;
			if (!this._subTypeSecondMenuFlagDict.TryGetValue(index, out flag))
			{
				this._subTypeSecondMenuFlagDict.Add(index, true);
				this.UpdateAuctionSecondMenu(this.SubTypeMenuGroupObjList[index], this.SubTypeFirstMenuObjList[index], index);
			}
		}

		// Token: 0x0600C9BA RID: 51642 RVA: 0x00312DE8 File Offset: 0x003111E8
		private void UpdateAuctionFirstMenu(int iFirstMenuNum)
		{
			if (this.SubTypeMenuGroupObjList.Count < iFirstMenuNum)
			{
				int count = this.SubTypeMenuGroupObjList.Count;
				int num = iFirstMenuNum - count;
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.MenuGroupPrefabPath, true, 0U);
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.FirstMenuPrefabPath, true, 0U);
				for (int i = 0; i < num; i++)
				{
					if (!(gameObject == null))
					{
						GameObject gameObject3 = Object.Instantiate<GameObject>(gameObject);
						if (!(gameObject3 == null))
						{
							Utility.AttachTo(gameObject3, this.mSubTypeContentRoot, false);
							this.SubTypeMenuGroupObjList.Add(gameObject3);
							if (!(gameObject2 == null))
							{
								GameObject gameObject4 = Object.Instantiate<GameObject>(gameObject2);
								if (!(gameObject4 == null))
								{
									ComSubTypeMenuGroup component = gameObject3.GetComponent<ComSubTypeMenuGroup>();
									if (component != null)
									{
										Utility.AttachTo(gameObject4, component.FirstMenuRoot, false);
										this.SubTypeFirstMenuObjList.Add(gameObject4);
										ComAuctionFirstMenu component2 = gameObject4.GetComponent<ComAuctionFirstMenu>();
										if (component2 != null)
										{
											component2.tgFirstMenu.group = this.mSubTypeToggleGroup;
										}
									}
									else
									{
										Object.Destroy(gameObject4);
									}
								}
							}
						}
					}
				}
				Object.Destroy(gameObject);
				Object.Destroy(gameObject2);
			}
			this._subTypeSecondMenuFlagDict.Clear();
			int num2 = 0;
			while (num2 < this.SubTypeMenuGroupObjList.Count && num2 < this.SubTypeFirstMenuObjList.Count)
			{
				ComSubTypeMenuGroup component3 = this.SubTypeMenuGroupObjList[num2].GetComponent<ComSubTypeMenuGroup>();
				if (component3 == null)
				{
					this.SubTypeMenuGroupObjList[num2].CustomActive(false);
				}
				else
				{
					ComAuctionFirstMenu component4 = this.SubTypeFirstMenuObjList[num2].GetComponent<ComAuctionFirstMenu>();
					if (component4 == null)
					{
						this.SubTypeMenuGroupObjList[num2].CustomActive(false);
					}
					else
					{
						component4.tgFirstMenu.group = this.mSubTypeToggleGroup;
						if (num2 < iFirstMenuNum)
						{
							if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
							{
								component4.name.text = DataManager<AuctionDataManager>.GetInstance().GetStrOfAuctionJobType((AuctionClassify.eJob)num2);
							}
							else
							{
								component4.name.text = DataManager<AuctionDataManager>.GetInstance().GetAuctionSubTypeName(this.CurBaseType, num2, this.CurSelJobType);
							}
							component4.DownArrow.gameObject.CustomActive(false);
							this.SubTypeFirstMenuObjList[num2].CustomActive(true);
							int index = num2;
							component4.tgFirstMenu.onValueChanged.RemoveAllListeners();
							component4.tgFirstMenu.onValueChanged.AddListener(delegate(bool value)
							{
								this.OnChooseFirstMenu(index, value);
							});
							component4.tgFirstMenu.isOn = false;
							if (this.CurSelSubTypeFirstMenuIndex == num2)
							{
								component4.tgFirstMenu.isOn = true;
							}
							if (this.IsShowSecondMenuTabs(num2))
							{
								component4.UpArrow.gameObject.CustomActive(!component4.tgFirstMenu.isOn);
								component4.DownArrow.gameObject.CustomActive(component4.tgFirstMenu.isOn);
								component3.SecondMenuRoot.CustomActive(component4.tgFirstMenu.isOn);
							}
							else
							{
								component4.UpArrow.gameObject.CustomActive(false);
								component4.DownArrow.gameObject.CustomActive(false);
								component3.SecondMenuRoot.CustomActive(false);
							}
						}
						else
						{
							this.SubTypeFirstMenuObjList[num2].CustomActive(false);
							component4.UpArrow.gameObject.CustomActive(false);
							component4.DownArrow.gameObject.CustomActive(false);
							component3.SecondMenuRoot.CustomActive(false);
						}
					}
				}
				num2++;
			}
		}

		// Token: 0x0600C9BB RID: 51643 RVA: 0x003131C0 File Offset: 0x003115C0
		private void UpdateAuctionSecondMenu(GameObject MenuGroupObj, GameObject FirstMenuObj, int iFirstMenuIndex)
		{
			ComSubTypeMenuGroup component = MenuGroupObj.GetComponent<ComSubTypeMenuGroup>();
			if (component == null)
			{
				return;
			}
			List<GameObject> list;
			if (!this.SubTypeSecondMenuObjDict.TryGetValue(iFirstMenuIndex, out list))
			{
				list = new List<GameObject>();
				this.SubTypeSecondMenuObjDict.Add(iFirstMenuIndex, list);
			}
			int num = 0;
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				num = DataManager<AuctionDataManager>.GetInstance().GetWeaponSubTypeNumOfDiffJob((AuctionClassify.eJob)iFirstMenuIndex);
			}
			else if (this.CurBaseType == AuctionMainItemType.AMIT_COST)
			{
				List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
				if (auctionConsumablesList != null)
				{
					AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iFirstMenuIndex], string.Empty, string.Empty);
					if (tableItem != null && tableItem.ChildrenIDs[0] != 0)
					{
						num = tableItem.ChildrenIDs.Count;
					}
				}
			}
			else
			{
				num = Singleton<TableManager>.GetInstance().GetAuctionDefenceList().Count;
			}
			if (list.Count < num)
			{
				int num2 = num - list.Count;
				ToggleGroup componentInChildren = MenuGroupObj.GetComponentInChildren<ToggleGroup>();
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.secondMenuPrefabPath, true, 0U);
				for (int i = 0; i < num2; i++)
				{
					if (!(gameObject == null))
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
						if (!(gameObject2 == null))
						{
							Utility.AttachTo(gameObject2, component.SecondMenuRoot, false);
							list.Add(gameObject2);
							ComAuctionSecondMenu component2 = gameObject2.GetComponent<ComAuctionSecondMenu>();
							if (component2 != null)
							{
								component2.tgSecondMenu.group = componentInChildren;
							}
						}
					}
				}
				Object.Destroy(gameObject);
			}
			for (int j = 0; j < list.Count; j++)
			{
				ComAuctionSecondMenu component3 = list[j].GetComponent<ComAuctionSecondMenu>();
				if (component3 == null)
				{
					list[j].CustomActive(false);
				}
				else if (j < num)
				{
					if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
					{
						component3.name.text = DataManager<AuctionDataManager>.GetInstance().GetAuctionSubTypeName(this.CurBaseType, j, (AuctionClassify.eJob)iFirstMenuIndex);
					}
					else if (this.CurBaseType == AuctionMainItemType.AMIT_ARMOR)
					{
						component3.name.text = DataManager<AuctionDataManager>.GetInstance().GetStrOfAuctionDefenceType(j);
					}
					else if (this.CurBaseType == AuctionMainItemType.AMIT_COST)
					{
						component3.name.text = DataManager<AuctionDataManager>.GetInstance().GetStrOfAuctionConsumables(j);
					}
					list[j].CustomActive(true);
					int idx = j;
					component3.tgSecondMenu.onValueChanged.RemoveAllListeners();
					component3.tgSecondMenu.onValueChanged.AddListener(delegate(bool value)
					{
						this.OnChooseSecondMenu(idx, value);
					});
					component3.tgSecondMenu.isOn = false;
					if (this.CurSelSubTypeSecondMenuIndex == j)
					{
						component3.tgSecondMenu.isOn = true;
					}
				}
				else
				{
					list[j].CustomActive(false);
				}
			}
		}

		// Token: 0x0600C9BC RID: 51644 RVA: 0x003134B0 File Offset: 0x003118B0
		private void UpdateAuctionItemPrefabs(int iCount)
		{
			this.ScrollViewRoots[0].SetElementAmount(iCount);
			this.ScrollRects[0].verticalNormalizedPosition = 1f;
		}

		// Token: 0x0600C9BD RID: 51645 RVA: 0x003134D4 File Offset: 0x003118D4
		private void RefreshOnSaleScrollRect()
		{
			this.SelfOnSaleItemFliterListNew.Clear();
			for (int i = 0; i < this.SelfOnSaleItemFliterList.Count; i++)
			{
				this.SelfOnSaleItemFliterListNew.Add(this.SelfOnSaleItemFliterList[i]);
			}
			if (this.SelfOnSaleItemFliterListNew.Count <= this.MaxOnSaleItemNum)
			{
				if (this.MaxOnSaleItemNum < 10)
				{
					this.ShelvesItem(1);
				}
				else
				{
					this.ShelvesItem(0);
				}
			}
			this.ScrollViewRoots[1].SetElementAmount(this.SelfOnSaleItemFliterListNew.Count);
			this.ScrollRects[1].verticalNormalizedPosition = 1f;
			if (this.MaxOnSaleItemNum < 10)
			{
				this.RefreshOnSaleInfo(1);
			}
			else
			{
				this.RefreshOnSaleInfo(0);
			}
		}

		// Token: 0x0600C9BE RID: 51646 RVA: 0x003135A0 File Offset: 0x003119A0
		private void ShelvesItem(int inum)
		{
			for (int i = 0; i < this.MaxOnSaleItemNum + inum - this.SelfOnSaleItemFliterList.Count; i++)
			{
				AuctionBaseInfo item = new AuctionBaseInfo();
				this.SelfOnSaleItemFliterListNew.Add(item);
			}
		}

		// Token: 0x0600C9BF RID: 51647 RVA: 0x003135E4 File Offset: 0x003119E4
		private void RefreshOnSaleInfo(int inum)
		{
			int num;
			if (inum == 0)
			{
				num = this.SelfOnSaleItemFliterListNew.Count - (this.MaxOnSaleItemNum + inum - this.SelfOnSaleItemFliterList.Count);
			}
			else if (DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.iMaxAddFieldNum && this.SelfOnSaleItemFliterListNew.Count - (this.MaxOnSaleItemNum + inum - this.SelfOnSaleItemFliterList.Count) >= this.MaxOnSaleItemNum)
			{
				num = this.SelfOnSaleItemFliterListNew.Count - (this.MaxOnSaleItemNum + inum - this.SelfOnSaleItemFliterList.Count) - 1;
			}
			else
			{
				num = this.SelfOnSaleItemFliterListNew.Count - (this.MaxOnSaleItemNum + inum - this.SelfOnSaleItemFliterList.Count);
			}
			this.mOnSaleNum.text = string.Format("({0}/{1})", num, this.MaxOnSaleItemNum);
		}

		// Token: 0x0600C9C0 RID: 51648 RVA: 0x003136CE File Offset: 0x00311ACE
		private void RefreshForSaleScrollRect()
		{
			this.ScrollViewRoots[2].SetElementAmount(this.PackageItemsFliterUid.Count);
		}

		// Token: 0x0600C9C1 RID: 51649 RVA: 0x003136E8 File Offset: 0x00311AE8
		private void RefreshSearchListScrollRect()
		{
			this.mSearchScrollViewRoot.SetElementAmount(this.SearchItemList.Count);
			ScrollRect component = this.mSearchScrollViewRoot.GetComponent<ScrollRect>();
		}

		// Token: 0x0600C9C2 RID: 51650 RVA: 0x00313718 File Offset: 0x00311B18
		private void UpdatePackageItemData()
		{
			this.PackageItemsUid.Clear();
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				return;
			}
			List<EPackageType> list = new List<EPackageType>();
			list.Add(EPackageType.Equip);
			list.Add(EPackageType.Material);
			list.Add(EPackageType.Consumable);
			list.Add(EPackageType.Task);
			list.Add(EPackageType.Fashion);
			list.Add(EPackageType.Title);
			foreach (KeyValuePair<ulong, ItemData> keyValuePair in allPackageItems)
			{
				ulong key = keyValuePair.Key;
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(key);
				if (item != null)
				{
					if (DataManager<ItemDataManager>.GetInstance().TradeItemTypeFliter(list, item.PackageType))
					{
						if (DataManager<ItemDataManager>.GetInstance().TradeItemStateFliter(item))
						{
							this.PackageItemsUid.Add(key);
						}
					}
				}
			}
		}

		// Token: 0x0600C9C3 RID: 51651 RVA: 0x003137F4 File Offset: 0x00311BF4
		private void UpdatePackageItemsFliterUid(AuctionSellItemType sellItemType)
		{
			this.PackageItemsFliterUid.Clear();
			for (int i = 0; i < this.PackageItemsUid.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.PackageItemsUid[i]);
				if (item != null)
				{
					if (!item.isInSidePack)
					{
						AuctionSellItemData auctionSellItemData = null;
						if (this.CurBaseType == AuctionMainItemType.AMIT_INVALID)
						{
							if (sellItemType == AuctionSellItemType.ASIT_EQUIP)
							{
								if (this.IsEquipItems(item))
								{
									auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, false);
								}
							}
							else if (!this.IsEquipItems(item))
							{
								auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, false);
							}
							if (auctionSellItemData != null)
							{
								if (!item.bLocked)
								{
									this.PackageItemsFliterUid.Add(auctionSellItemData);
								}
							}
						}
						else if (this.CurBaseType == DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID(item.TableID))
						{
							if (sellItemType == AuctionSellItemType.ASIT_EQUIP)
							{
								if (this.IsEquipItems(item))
								{
									auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, false);
								}
							}
							else if (!this.IsEquipItems(item))
							{
								auctionSellItemData = new AuctionSellItemData(item.GUID, (int)item.Quality, item.LevelLimit, false);
							}
							if (auctionSellItemData != null)
							{
								if (!item.bLocked)
								{
									this.PackageItemsFliterUid.Add(auctionSellItemData);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C9C4 RID: 51652 RVA: 0x00313978 File Offset: 0x00311D78
		private bool IsEquipItems(ItemData data)
		{
			return DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID(data.TableID) == AuctionMainItemType.AMIT_WEAPON || DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID(data.TableID) == AuctionMainItemType.AMIT_ARMOR || DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID(data.TableID) == AuctionMainItemType.AMIT_JEWELRY;
		}

		// Token: 0x0600C9C5 RID: 51653 RVA: 0x003139CC File Offset: 0x00311DCC
		private void UpdateOnSaleItemsFliterData()
		{
			this.SelfOnSaleItemFliterList.Clear();
			for (int i = 0; i < this.SelfOnSaleItemList.Count; i++)
			{
				if (this.CurBaseType == AuctionMainItemType.AMIT_INVALID)
				{
					this.SelfOnSaleItemFliterList.Add(this.SelfOnSaleItemList[i]);
				}
				else if (this.CurBaseType == DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID((int)this.SelfOnSaleItemList[i].itemTypeId))
				{
					this.SelfOnSaleItemFliterList.Add(this.SelfOnSaleItemList[i]);
				}
			}
			if (this.SelfOnSaleItemList.Count == this.MaxOnSaleItemNum && DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum < this.iMaxAddFieldNum)
			{
				AuctionBaseInfo item = new AuctionBaseInfo();
				this.SelfOnSaleItemFliterList.Add(item);
			}
		}

		// Token: 0x0600C9C6 RID: 51654 RVA: 0x00313AA1 File Offset: 0x00311EA1
		private void UpdatePage()
		{
			this.mShowPage.text = string.Format("{0}/{1}", this.CurPage, this.MaxPage);
		}

		// Token: 0x0600C9C7 RID: 51655 RVA: 0x00313ACE File Offset: 0x00311ECE
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C9C8 RID: 51656 RVA: 0x00313AD4 File Offset: 0x00311ED4
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			int num = (int)(DataManager<PlayerBaseData>.GetInstance().AuctionLastRefreshTime + (uint)this.iAuctionRefreshTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			if (num > this.iAuctionRefreshTime)
			{
				num = this.iAuctionRefreshTime;
			}
			if (num > 0)
			{
				this.mAutoRefreshTime.text = string.Format("自动刷新:{0}", Function.GetLeftTime((int)((ulong)DataManager<PlayerBaseData>.GetInstance().AuctionLastRefreshTime + (ulong)((long)this.iAuctionRefreshTime)), (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.Normal));
				this.mRefreshCost.text = this.iRefreshCostNum.ToString();
				this.bCanFreeRefresh = false;
			}
			else
			{
				this.mAutoRefreshTime.text = string.Format("免费刷新", new object[0]);
				this.mRefreshCost.text = "0";
				this.bCanFreeRefresh = true;
			}
		}

		// Token: 0x0600C9C9 RID: 51657 RVA: 0x00313BAC File Offset: 0x00311FAC
		private void SendItemTypeListReq(AuctionMainItemType MainType)
		{
			WorldAuctionItemNumReq worldAuctionItemNumReq = new WorldAuctionItemNumReq();
			worldAuctionItemNumReq.cond.type = 0;
			worldAuctionItemNumReq.cond.itemMainType = (byte)MainType;
			worldAuctionItemNumReq.cond.quality = (byte)this.CurSelQualityIndex;
			if (this.CurBaseType != AuctionMainItemType.AMIT_COST && this.CurBaseType != AuctionMainItemType.AMIT_MATERIAL)
			{
				this.SetLevel(ref worldAuctionItemNumReq.cond);
			}
			else
			{
				worldAuctionItemNumReq.cond.minLevel = 0;
				worldAuctionItemNumReq.cond.maxLevel = (byte)DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			}
			bool flag = false;
			if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				flag = DataManager<AuctionDataManager>.GetInstance().IsSelAuctionSum(this.CurBaseType, this.CurSelSubTypeSecondMenuIndex, this.CurSelJobType);
			}
			else if (this.CurBaseType == AuctionMainItemType.AMIT_ARMOR)
			{
				if (this.CurSelSubTypeFirstMenuIndex == 0)
				{
					flag = true;
				}
			}
			else
			{
				flag = DataManager<AuctionDataManager>.GetInstance().IsSelAuctionSum(this.CurBaseType, this.CurSelSubTypeFirstMenuIndex, this.CurSelJobType);
			}
			int num = 1;
			if (!flag)
			{
				if (this.CurBaseType == AuctionMainItemType.AMIT_ARMOR)
				{
					if (this.CurSelSubTypeSecondMenuIndex == 0)
					{
						num = DataManager<AuctionDataManager>.GetInstance().GetConditionNumByLimitType(AuctionSearchLimitType.ArmorTypeLimit);
					}
					worldAuctionItemNumReq.cond.itemSubTypes = new uint[num];
					if (this.CurSelSubTypeSecondMenuIndex != 0)
					{
						int itemTableType = DataManager<AuctionDataManager>.GetInstance().GetItemTableType(this.CurBaseType, this.CurSelSubTypeFirstMenuIndex, this.CurSelJobType, this.CurSelSubTypeSecondMenuIndex);
						if (itemTableType <= 0)
						{
							Logger.LogError("Auction Item Type < 0 four");
							return;
						}
						worldAuctionItemNumReq.cond.itemSubTypes[0] = (uint)itemTableType;
					}
					else
					{
						for (int i = 0; i < num; i++)
						{
							int itemTableType2 = DataManager<AuctionDataManager>.GetInstance().GetItemTableType(this.CurBaseType, this.CurSelSubTypeFirstMenuIndex, this.CurSelJobType, i + 1);
							if (itemTableType2 <= 0)
							{
								Logger.LogError("Auction Item Type < 0 four");
								return;
							}
							worldAuctionItemNumReq.cond.itemSubTypes[i] = (uint)itemTableType2;
						}
					}
				}
				else if (this.CurBaseType == AuctionMainItemType.AMIT_COST && DataManager<AuctionDataManager>.GetInstance().BConsumableIsHasSecendTab(this.CurSelSubTypeFirstMenuIndex))
				{
					if (this.CurSelSubTypeSecondMenuIndex == 0)
					{
						num = DataManager<AuctionDataManager>.GetInstance().GetIntDrugNodeCount(this.CurSelSubTypeFirstMenuIndex);
					}
					worldAuctionItemNumReq.cond.itemSubTypes = new uint[num];
					if (this.CurSelSubTypeSecondMenuIndex != 0)
					{
						int num2 = DataManager<AuctionDataManager>.GetInstance().SwichConsumablesDrugType(this.CurSelSubTypeFirstMenuIndex, this.CurSelSubTypeSecondMenuIndex);
						if (num2 <= 0)
						{
							Logger.LogError("Auction Item Type < 0 four");
							return;
						}
						worldAuctionItemNumReq.cond.itemSubTypes[0] = (uint)num2;
					}
					else
					{
						for (int j = 0; j < num; j++)
						{
							int num3 = DataManager<AuctionDataManager>.GetInstance().SwichConsumablesDrugType(this.CurSelSubTypeFirstMenuIndex, j + 1);
							if (num3 <= 0)
							{
								Logger.LogError("Auction Item Type < 0 four");
								return;
							}
							worldAuctionItemNumReq.cond.itemSubTypes[j] = (uint)num3;
						}
					}
				}
				else
				{
					int itemTableType3;
					if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
					{
						itemTableType3 = DataManager<AuctionDataManager>.GetInstance().GetItemTableType(this.CurBaseType, this.CurSelSubTypeSecondMenuIndex, this.CurSelJobType, -1);
					}
					else
					{
						itemTableType3 = DataManager<AuctionDataManager>.GetInstance().GetItemTableType(this.CurBaseType, this.CurSelSubTypeFirstMenuIndex, this.CurSelJobType, -1);
					}
					if (itemTableType3 <= 0)
					{
						Logger.LogError("Auction Item Type <= 0 sec");
						return;
					}
					worldAuctionItemNumReq.cond.itemSubTypes = new uint[num];
					worldAuctionItemNumReq.cond.itemSubTypes[0] = (uint)itemTableType3;
				}
			}
			else if (this.CurBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				num = Singleton<TableManager>.GetInstance().GetAuctionWeaponList(this.CurSelJobType).Count - 1;
				worldAuctionItemNumReq.cond.itemSubTypes = new uint[num];
				for (int k = 0; k < num; k++)
				{
					int itemTableType4 = DataManager<AuctionDataManager>.GetInstance().GetItemTableType(this.CurBaseType, k + 1, this.CurSelJobType, -1);
					if (itemTableType4 <= 0)
					{
						Logger.LogError("Auction Item Type < 0 seven");
						return;
					}
					worldAuctionItemNumReq.cond.itemSubTypes[k] = (uint)itemTableType4;
				}
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionItemNumReq>(ServerType.GATE_SERVER, worldAuctionItemNumReq);
		}

		// Token: 0x0600C9CA RID: 51658 RVA: 0x00313FA4 File Offset: 0x003123A4
		private void SendItemListReq()
		{
			if (this.CurSelectItemIndex >= this.ShowItemTypeList.Count)
			{
				return;
			}
			WorldAuctionListReq worldAuctionListReq = new WorldAuctionListReq();
			worldAuctionListReq.cond.type = 0;
			worldAuctionListReq.cond.page = (ushort)this.CurPage;
			worldAuctionListReq.cond.itemNumPerPage = 40;
			worldAuctionListReq.cond.sortType = (byte)this.CurSelPriceSortIndex;
			worldAuctionListReq.cond.itemTypeID = this.ShowItemTypeList[this.CurSelectItemIndex].itemTypeId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionListReq>(ServerType.GATE_SERVER, worldAuctionListReq);
		}

		// Token: 0x0600C9CB RID: 51659 RVA: 0x0031403C File Offset: 0x0031243C
		private void SendSearchItemReq()
		{
			WorldAuctionItemNumReq worldAuctionItemNumReq = new WorldAuctionItemNumReq();
			worldAuctionItemNumReq.cond.type = 0;
			worldAuctionItemNumReq.cond.itemTypeID = (uint)this.SearchItemTypeID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionItemNumReq>(ServerType.GATE_SERVER, worldAuctionItemNumReq);
		}

		// Token: 0x0600C9CC RID: 51660 RVA: 0x0031407C File Offset: 0x0031247C
		private void SendItemDetailReq(ulong guid)
		{
			WorldAuctionQueryItemReq worldAuctionQueryItemReq = new WorldAuctionQueryItemReq();
			worldAuctionQueryItemReq.id = guid;
			NetManager netManager = NetManager.Instance();
			NetManager.Instance().SendCommand<WorldAuctionQueryItemReq>(ServerType.GATE_SERVER, worldAuctionQueryItemReq);
		}

		// Token: 0x0600C9CD RID: 51661 RVA: 0x003140AC File Offset: 0x003124AC
		private void SendSelfAuctionList()
		{
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionSelfListReq>(ServerType.GATE_SERVER, new WorldAuctionSelfListReq
			{
				type = 0
			});
		}

		// Token: 0x0600C9CE RID: 51662 RVA: 0x003140D8 File Offset: 0x003124D8
		private void SendRefreshItemList()
		{
			NetManager netManager = NetManager.Instance();
			SceneAuctionRefreshReq cmd = new SceneAuctionRefreshReq();
			netManager.SendCommand<SceneAuctionRefreshReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C9CF RID: 51663 RVA: 0x003140FC File Offset: 0x003124FC
		private void SendBuyField()
		{
			NetManager netManager = NetManager.Instance();
			SceneAuctionBuyBoothReq cmd = new SceneAuctionBuyBoothReq();
			netManager.SendCommand<SceneAuctionBuyBoothReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C9D0 RID: 51664 RVA: 0x00314120 File Offset: 0x00312520
		[MessageHandle(603921U, false, 0)]
		private void OnAuctionItemTypeListRet(MsgDATA msg)
		{
			WorldAuctionItemNumRes worldAuctionItemNumRes = new WorldAuctionItemNumRes();
			worldAuctionItemNumRes.decode(msg.bytes);
			this.requestServerReturnSuccess = true;
			if (DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage)
			{
				this.UpdateCurPage();
				this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
				this.CurSelectItemIndex = 0;
				this.mTgShowOnSale.isOn = true;
				this.bInitBuyItemScrollBind = false;
				this.bHasSearchedItem = false;
				this.mItemNameInput.text = string.Empty;
				this.SearchItemTypeID = 0;
				this.mMyAuctionText.text = "我的寄售";
				this.UpdateSubTypeMenuGroupPrefabs();
				this.UpdateChoosenMainType((int)this.CurBaseType);
			}
			this.ShowItemTypeList.Clear();
			for (int i = 0; i < worldAuctionItemNumRes.items.Length; i++)
			{
				if (this.ShowItemTypeList.Count <= 0 || this.CurSelQualityIndex > 0)
				{
					this.ShowItemTypeList.Add(worldAuctionItemNumRes.items[i]);
				}
				else
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)worldAuctionItemNumRes.items[i].itemTypeId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						for (int j = 0; j < this.ShowItemTypeList.Count; j++)
						{
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.ShowItemTypeList[j].itemTypeId, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem.Color > tableItem2.Color)
								{
									this.ShowItemTypeList.Insert(j, worldAuctionItemNumRes.items[i]);
									break;
								}
								if (j == this.ShowItemTypeList.Count - 1)
								{
									this.ShowItemTypeList.Add(worldAuctionItemNumRes.items[i]);
									break;
								}
							}
						}
					}
				}
			}
			if (!this.bHasSearchedItem && !this.bOnlyShowOnSaleItem)
			{
				this.AddAuctionTableItemTypeList();
			}
			this.CurPage = 1;
			this.InitShowScrollViewItemBind();
			this.UpdateInterface();
			this.UpdatePageButtonState();
		}

		// Token: 0x0600C9D1 RID: 51665 RVA: 0x0031431C File Offset: 0x0031271C
		[MessageHandle(603902U, false, 0)]
		private void OnAuctionItemListRet(MsgDATA msg)
		{
			WorldAuctionListQueryRet worldAuctionListQueryRet = new WorldAuctionListQueryRet();
			worldAuctionListQueryRet.decode(msg.bytes);
			if (worldAuctionListQueryRet.type != 0)
			{
				return;
			}
			this.CurPage = (int)worldAuctionListQueryRet.curPage;
			this.MaxPage = (int)worldAuctionListQueryRet.maxPage;
			if (this.CurPage >= this.MaxPage)
			{
				this.CurPage = this.MaxPage;
			}
			this.ShowItemList.Clear();
			for (int i = 0; i < worldAuctionListQueryRet.data.Length; i++)
			{
				this.ShowItemList.Add(worldAuctionListQueryRet.data[i]);
			}
			this.InitShowScrollViewItemBind();
			this.UpdateInterface();
			this.UpdatePageButtonState();
		}

		// Token: 0x0600C9D2 RID: 51666 RVA: 0x003143C8 File Offset: 0x003127C8
		[MessageHandle(603917U, false, 0)]
		private void OnAuctionItemDetailRet(MsgDATA msg)
		{
			int num = 0;
			ulong num2 = 0UL;
			BaseDLL.decode_uint64(msg.bytes, ref num, ref num2);
			uint dataid = 0U;
			BaseDLL.decode_uint32(msg.bytes, ref num, ref dataid);
			Item item = new Item();
			item.uid = num2;
			item.dataid = dataid;
			StreamObjectDecoder<Item>.DecodePropertys(ref item, msg.bytes, ref num, msg.bytes.Length);
			ItemData itemData = null;
			if (this.ItemDetailList.TryGetValue(num2, out itemData))
			{
				this.ItemDetailList.Remove(num2);
				itemData = null;
			}
			itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(item);
			if (itemData == null)
			{
				Logger.LogError("itemData is null in [OnAuctionItemDetailRet] in AuctionItemFrame");
				return;
			}
			this.ItemDetailList.Add(num2, itemData);
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600C9D3 RID: 51667 RVA: 0x0031448C File Offset: 0x0031288C
		[MessageHandle(603911U, false, 0)]
		private void OnBuyItemRefresh(MsgDATA msg)
		{
			WorldAuctionNotifyRefresh worldAuctionNotifyRefresh = new WorldAuctionNotifyRefresh();
			worldAuctionNotifyRefresh.decode(msg.bytes);
			if (worldAuctionNotifyRefresh.type != 0)
			{
				return;
			}
			if (worldAuctionNotifyRefresh.reason == 0)
			{
				if (this.CurBuyIndex < 0 || this.CurBuyIndex >= this.ShowItemList.Count)
				{
					Logger.LogErrorFormat("[OnBuyItemRefresh] CurBuyIndex = {0} , ShowItemList = {1} ", new object[]
					{
						this.CurBuyIndex,
						this.ShowItemList.Count
					});
					if (this.ShowItemList.Count >= 1)
					{
						Logger.LogErrorFormat("[OnBuyItemRefresh] ShowItemList[0].guid = {0} , ShowItemList[0].itemTypeId = {1}", new object[]
						{
							this.ShowItemList[0].guid,
							this.ShowItemList[0].itemTypeId
						});
					}
				}
				else
				{
					this.ShowItemList.RemoveAt(this.CurBuyIndex);
				}
				this.SendItemListReq();
			}
			else
			{
				if (worldAuctionNotifyRefresh.reason != 1 && worldAuctionNotifyRefresh.reason != 2)
				{
					return;
				}
				this.UpdatePackageItemData();
				this.SendSelfAuctionList();
			}
			this.UpdatePageButtonState();
		}

		// Token: 0x0600C9D4 RID: 51668 RVA: 0x003145BC File Offset: 0x003129BC
		[MessageHandle(603905U, false, 0)]
		private void OnSelfAuctionListRet(MsgDATA msg)
		{
			WorldAuctionSelfListRes worldAuctionSelfListRes = new WorldAuctionSelfListRes();
			worldAuctionSelfListRes.decode(msg.bytes);
			if (worldAuctionSelfListRes.type != 0)
			{
				return;
			}
			this.requestServerReturnSuccess = true;
			if (DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage)
			{
				this.UpdateCurPage();
				this.CurBaseType = AuctionMainItemType.AMIT_INVALID;
				this.bInitSellItemScrollBind = false;
				this.bInitPackageItemScrollBind = false;
				this.mMyAuctionText.text = "返回";
				this.ScrollRects[2].verticalNormalizedPosition = 1f;
			}
			this.SelfOnSaleItemList.Clear();
			for (int i = 0; i < worldAuctionSelfListRes.data.Length; i++)
			{
				this.SelfOnSaleItemList.Add(worldAuctionSelfListRes.data[i]);
			}
			if (this.CurAuctionPage == AuctionPage.MyAuctionPage)
			{
				this.UpdateInterface();
			}
			if (this.OutData != null)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionSellFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionSellFrame>(null, false);
				}
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.OutData.uiLinkId);
				if (item == null)
				{
					return;
				}
				if (this.IsEquipItems(item))
				{
					if (this.mEquipTog)
					{
						this.mEquipTog.isOn = true;
					}
				}
				else if (this.mConsumableMaterialTog)
				{
					this.mConsumableMaterialTog.isOn = true;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionSellFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionSellFrame>(null, false);
				}
				if (item.IsNeedPacking())
				{
					this.PackingData = item;
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("Auction_item_packing"), new UnityAction(this.ClickOKPacking), null, 0f, false);
				}
				else
				{
					AuctionSellBaseData auctionSellBaseData = default(AuctionSellBaseData);
					auctionSellBaseData.PackageItemGuid = this.OutData.uiLinkId;
					auctionSellBaseData.MaxOnSaleItemNum = this.MaxOnSaleItemNum;
					auctionSellBaseData.SelfOnSaleNum = this.SelfOnSaleItemList.Count;
					if (auctionSellBaseData.PackageItemGuid != 0UL)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionSellFrame>(FrameLayer.Middle, auctionSellBaseData, string.Empty);
					}
				}
				this.OutData = null;
			}
		}

		// Token: 0x0600C9D5 RID: 51669 RVA: 0x003147CC File Offset: 0x00312BCC
		[MessageHandle(503902U, false, 0)]
		private void OnItemListRefreshRes(MsgDATA msg)
		{
			SceneAuctionRefreshRes sceneAuctionRefreshRes = new SceneAuctionRefreshRes();
			sceneAuctionRefreshRes.decode(msg.bytes);
			if (sceneAuctionRefreshRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneAuctionRefreshRes.result, string.Empty);
				return;
			}
			this.CurBuyPageState = AuctionBuyPageState.ShowAuctionItemTypeList;
			this.bInitBuyItemScrollBind = false;
			if (this.bHasSearchedItem)
			{
				this.SendSearchItemReq();
			}
			else
			{
				this.SendItemTypeListReq(this.CurBaseType);
			}
			SystemNotifyManager.SysNotifyFloatingEffect("刷新成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600C9D6 RID: 51670 RVA: 0x00314844 File Offset: 0x00312C44
		[MessageHandle(503904U, false, 0)]
		private void OnBuyNewFieldRes(MsgDATA msg)
		{
			SceneAuctionBuyBoothRes sceneAuctionBuyBoothRes = new SceneAuctionBuyBoothRes();
			sceneAuctionBuyBoothRes.decode(msg.bytes);
			if (sceneAuctionBuyBoothRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneAuctionBuyBoothRes.result, string.Empty);
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum = (int)sceneAuctionBuyBoothRes.boothNum;
			this.MaxOnSaleItemNum++;
			SystemNotifyManager.SysNotifyFloatingEffect("拍卖行栏位购买成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			if (this.SelfOnSaleItemFliterList.Count >= this.MaxOnSaleItemNum)
			{
				this.SelfOnSaleItemFliterList.RemoveAt(this.SelfOnSaleItemFliterList.Count - 1);
			}
			this.bInitSellItemScrollBind = false;
			this.RefreshOnSaleScrollRect();
		}

		// Token: 0x0600C9D7 RID: 51671 RVA: 0x003148E4 File Offset: 0x00312CE4
		private void AddAuctionTableItemTypeList()
		{
			this.mBuyItemTips.text = string.Empty;
			ItemTable.eThirdType eThirdType = ItemTable.eThirdType.TT_NONE;
			ItemTable.eType itemTableTypeByAuctionType = DataManager<AuctionDataManager>.GetInstance().GetItemTableTypeByAuctionType(this.CurBaseType);
			List<ItemTable.eSubType> itemTableSubType = DataManager<AuctionDataManager>.GetInstance().GetItemTableSubType(this.CurBaseType, this.CurSelSubTypeFirstMenuIndex, this.CurSelSubTypeSecondMenuIndex, this.CurSelJobType, ref eThirdType);
			if (itemTableSubType == null)
			{
				return;
			}
			WorldAuctionItemNumReq worldAuctionItemNumReq = new WorldAuctionItemNumReq();
			if (this.CurBaseType != AuctionMainItemType.AMIT_COST && this.CurBaseType != AuctionMainItemType.AMIT_MATERIAL)
			{
				this.SetLevel(ref worldAuctionItemNumReq.cond);
			}
			else
			{
				worldAuctionItemNumReq.cond.minLevel = 0;
				worldAuctionItemNumReq.cond.maxLevel = (byte)DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < itemTableSubType.Count; i++)
			{
				List<int> auctionItemListBaseFliter = DataManager<ItemDataManager>.GetInstance().GetAuctionItemListBaseFliter(itemTableTypeByAuctionType, itemTableSubType[i]);
				if (auctionItemListBaseFliter != null)
				{
					for (int j = 0; j < auctionItemListBaseFliter.Count; j++)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(auctionItemListBaseFliter[j], string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (tableItem.NeedLevel >= (int)worldAuctionItemNumReq.cond.minLevel && tableItem.NeedLevel <= (int)worldAuctionItemNumReq.cond.maxLevel)
							{
								if (this.CurSelQualityIndex == 0 || tableItem.Color == (ItemTable.eColor)this.CurSelQualityIndex)
								{
									if (eThirdType != ItemTable.eThirdType.TT_NONE)
									{
										if (tableItem.ThirdType != eThirdType)
										{
											goto IL_223;
										}
									}
									else if (tableItem.Occu.Count >= 1 && tableItem.Occu[0] != 0)
									{
										bool flag = false;
										for (int k = 0; k < tableItem.Occu.Count; k++)
										{
											JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(tableItem.Occu[k], string.Empty, string.Empty);
											if (tableItem2 != null)
											{
												if (this.CurSelJobType == (AuctionClassify.eJob)tableItem2.AuctionJob)
												{
													flag = true;
													break;
												}
											}
										}
										if (!flag)
										{
											goto IL_223;
										}
									}
									list.Add(auctionItemListBaseFliter[j]);
								}
							}
						}
						IL_223:;
					}
				}
			}
			List<int> list2 = new List<int>();
			for (int l = 0; l < list.Count; l++)
			{
				if (list2.Count <= 0 || this.CurSelQualityIndex > 0)
				{
					list2.Add(list[l]);
				}
				else
				{
					ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list[l], string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						for (int m = 0; m < list2.Count; m++)
						{
							ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(list2[m], string.Empty, string.Empty);
							if (tableItem4 != null)
							{
								if (tableItem3.Color > tableItem4.Color)
								{
									list2.Insert(m, list[l]);
									break;
								}
								if (m == list2.Count - 1)
								{
									list2.Add(list[l]);
									break;
								}
							}
						}
					}
				}
			}
			for (int n = 0; n < list2.Count; n++)
			{
				bool flag2 = false;
				for (int num = 0; num < this.ShowItemTypeList.Count; num++)
				{
					if ((ulong)this.ShowItemTypeList[num].itemTypeId == (ulong)((long)list2[n]))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					AuctionItemBaseInfo auctionItemBaseInfo = new AuctionItemBaseInfo();
					auctionItemBaseInfo.itemTypeId = (uint)list2[n];
					auctionItemBaseInfo.num = 0U;
					this.ShowItemTypeList.Add(auctionItemBaseInfo);
				}
			}
		}

		// Token: 0x0600C9D8 RID: 51672 RVA: 0x00314CEC File Offset: 0x003130EC
		private void RemoveAuctionTableItemTypeList()
		{
			for (int i = 0; i < this.ShowItemTypeList.Count; i++)
			{
				if (this.ShowItemTypeList[i].num <= 0U)
				{
					this.ShowItemTypeList.RemoveAt(i);
					i--;
				}
			}
			if (this.ShowItemTypeList.Count > 0)
			{
				this.mBuyItemTips.text = string.Empty;
			}
			else
			{
				this.mBuyItemTips.text = TR.Value("Auction_item_not_exist");
			}
		}

		// Token: 0x0600C9D9 RID: 51673 RVA: 0x00314D78 File Offset: 0x00313178
		private void UpdatePageState()
		{
			this.mSearchListRoot.CustomActive(false);
			if (this.CurAuctionPage == AuctionPage.AuctionBuyPage)
			{
				this.funcs[1].gameObject.CustomActive(false);
				this.funcs[2].gameObject.CustomActive(false);
				this.mMyAuctionTitle.CustomActive(false);
				this.mOnSaleRefreshTip.gameObject.CustomActive(false);
				this.mBack.gameObject.CustomActive(true);
				if (this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList)
				{
					this.mPriceSelRootObj.CustomActive(false);
					this.mReturnRootObj.CustomActive(false);
					this.mPage.CustomActive(false);
					this.mQualitySelectRoot.CustomActive(true);
					if (this.CurBaseType != AuctionMainItemType.AMIT_COST && this.CurBaseType != AuctionMainItemType.AMIT_MATERIAL)
					{
						this.mLvSelRootObj.CustomActive(true);
					}
					this.mBtSearch.gameObject.CustomActive(true);
					this.mShowOnSaleRoot.CustomActive(true);
				}
				else
				{
					this.mQualitySelectRoot.CustomActive(false);
					this.mLvSelRootObj.CustomActive(false);
					this.mBtSearch.gameObject.CustomActive(false);
					this.mShowOnSaleRoot.CustomActive(false);
					this.mPriceSelRootObj.CustomActive(true);
					this.mReturnRootObj.CustomActive(true);
					this.mPage.CustomActive(true);
				}
				this.mMainTypeRoot.CustomActive(true);
				this.mSubTypeRoot.CustomActive(true);
				this.funcs[0].gameObject.CustomActive(true);
				this.mRefresh.CustomActive(true);
			}
			else if (this.CurAuctionPage == AuctionPage.MyAuctionPage)
			{
				this.mMainTypeRoot.CustomActive(false);
				this.mSubTypeRoot.CustomActive(false);
				this.mShowOnSaleRoot.CustomActive(false);
				this.funcs[0].gameObject.CustomActive(false);
				this.mQualitySelectRoot.CustomActive(false);
				this.mLvSelRootObj.CustomActive(false);
				this.mPriceSelRootObj.CustomActive(false);
				this.mReturnRootObj.CustomActive(false);
				this.mBtSearch.gameObject.CustomActive(false);
				this.mRefresh.CustomActive(false);
				this.mPage.CustomActive(false);
				this.mBack.gameObject.CustomActive(false);
				this.mMyAuctionTitle.CustomActive(true);
				this.funcs[1].gameObject.CustomActive(true);
				this.funcs[2].gameObject.CustomActive(true);
				this.mOnSaleRefreshTip.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600C9DA RID: 51674 RVA: 0x00314FF8 File Offset: 0x003133F8
		private void UpdateChoosenMainType(int iIndex)
		{
			for (int i = 0; i < this.MainTypes.Length; i++)
			{
				this.MainTypes[i].isOn = false;
				if (i == iIndex)
				{
					this.MainTypes[i].isOn = true;
				}
			}
		}

		// Token: 0x0600C9DB RID: 51675 RVA: 0x00315041 File Offset: 0x00313441
		private void UpdateSelLvShow()
		{
			Utility.FindChild(this.LevelTypes[this.CurSelLevelIndex].gameObject, "Image").CustomActive(false);
			this.mLevelList.CustomActive(false);
		}

		// Token: 0x0600C9DC RID: 51676 RVA: 0x00315071 File Offset: 0x00313471
		private void UpdateSelQualityShow()
		{
			this.mQualityListRoot.CustomActive(false);
		}

		// Token: 0x0600C9DD RID: 51677 RVA: 0x00315080 File Offset: 0x00313480
		private void UpdatePageButtonState()
		{
			if ((this.CurAuctionPage == AuctionPage.AuctionBuyPage && this.CurBuyPageState == AuctionBuyPageState.ShowAuctionItemTypeList) || this.CurAuctionPage == AuctionPage.MyAuctionPage)
			{
				this.mPage.CustomActive(false);
				return;
			}
			this.mPage.CustomActive(true);
			if (this.MaxPage > 1)
			{
				if (this.CurPage <= 1)
				{
					this.mBtPre.gameObject.GetComponent<UIGray>().enabled = true;
					this.mBtPre.interactable = false;
					this.mBtNext.gameObject.GetComponent<UIGray>().enabled = false;
					this.mBtNext.interactable = true;
				}
				else if (this.CurPage >= this.MaxPage)
				{
					this.mBtPre.gameObject.GetComponent<UIGray>().enabled = false;
					this.mBtPre.interactable = true;
					this.mBtNext.gameObject.GetComponent<UIGray>().enabled = true;
					this.mBtNext.interactable = false;
				}
				else
				{
					this.mBtPre.gameObject.GetComponent<UIGray>().enabled = false;
					this.mBtPre.interactable = true;
					this.mBtNext.gameObject.GetComponent<UIGray>().enabled = false;
					this.mBtNext.interactable = true;
				}
			}
			else
			{
				this.mBtPre.gameObject.GetComponent<UIGray>().enabled = true;
				this.mBtPre.interactable = false;
				this.mBtNext.gameObject.GetComponent<UIGray>().enabled = true;
				this.mBtNext.interactable = false;
			}
		}

		// Token: 0x0600C9DE RID: 51678 RVA: 0x00315210 File Offset: 0x00313610
		public void SetLevel(ref AuctionQueryCondition cond)
		{
			if (this.CurSelLevelIndex == 0)
			{
				cond.minLevel = 0;
				cond.maxLevel = 19;
			}
			else if (this.CurSelLevelIndex == 1)
			{
				cond.minLevel = 20;
				cond.maxLevel = 39;
			}
			else
			{
				cond.minLevel = 40;
				cond.maxLevel = (byte)DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			}
		}

		// Token: 0x0600C9DF RID: 51679 RVA: 0x0031527C File Offset: 0x0031367C
		private int GetSelLvIndexByPlayerLv()
		{
			if (DataManager<PlayerBaseData>.GetInstance().Level >= 1 && DataManager<PlayerBaseData>.GetInstance().Level <= 19)
			{
				return 0;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level >= 20 && DataManager<PlayerBaseData>.GetInstance().Level <= 39)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x0600C9E0 RID: 51680 RVA: 0x003152D4 File Offset: 0x003136D4
		protected sealed override void _bindExUI()
		{
			this.mPage = this.mBind.GetGameObject("Page");
			this.mBtSearch = this.mBind.GetCom<Button>("BtSearch");
			this.mBtSearch.onClick.AddListener(new UnityAction(this._onBtSearchButtonClick));
			this.mLvSelRootObj = this.mBind.GetGameObject("LvSelRootObj");
			this.mBtLevelSel = this.mBind.GetCom<Button>("BtLevelSel");
			this.mBtLevelSel.onClick.AddListener(new UnityAction(this._onBtLevelSelButtonClick));
			this.mLevelList = this.mBind.GetGameObject("LevelList");
			this.mShowLevel = this.mBind.GetCom<Text>("ShowLevel");
			this.mPriceSelRootObj = this.mBind.GetGameObject("PriceSelRootObj");
			this.mShowPrice = this.mBind.GetCom<Text>("ShowPrice");
			this.mBtPriceSel = this.mBind.GetCom<Button>("BtPriceSel");
			this.mBtPriceSel.onClick.AddListener(new UnityAction(this._onBtPriceSelButtonClick));
			this.mPriceList = this.mBind.GetGameObject("PriceList");
			this.mRefresh = this.mBind.GetGameObject("Refresh");
			this.mAutoRefreshTime = this.mBind.GetCom<Text>("AutoRefreshTime");
			this.mBtRefresh = this.mBind.GetCom<Button>("BtRefresh");
			this.mBtRefresh.onClick.AddListener(new UnityAction(this._onBtRefreshButtonClick));
			this.mRefreshCost = this.mBind.GetCom<Text>("RefreshCost");
			this.mOnSaleRefreshTip = this.mBind.GetCom<Text>("OnSaleRefreshTip");
			this.mMainTypeRoot = this.mBind.GetGameObject("MainTypeRoot");
			this.mMyAuctionTitle = this.mBind.GetGameObject("MyAuctionTitle");
			this.mSubTypeRoot = this.mBind.GetGameObject("SubTypeRoot");
			this.mSubTypeScrollRect = this.mBind.GetCom<ScrollRect>("SubTypeScrollRect");
			this.mSubTypeContentRoot = this.mBind.GetGameObject("SubTypeContentRoot");
			this.mOnSaleTips = this.mBind.GetCom<Text>("OnSaleTips");
			this.mForSaleTips = this.mBind.GetCom<Text>("ForSaleTips");
			this.mBuyItemTips = this.mBind.GetCom<Text>("BuyItemTips");
			this.mSubTypeToggleGroup = this.mBind.GetCom<ToggleGroup>("SubTypeToggleGroup");
			this.mPackageItemToggleGroup = this.mBind.GetCom<ToggleGroup>("PackageItemToggleGroup");
			this.mShowPage = this.mBind.GetCom<Text>("ShowPage");
			this.mBtPre = this.mBind.GetCom<Button>("BtPre");
			this.mBtPre.onClick.AddListener(new UnityAction(this._onBtPreButtonClick));
			this.mBtNext = this.mBind.GetCom<Button>("BtNext");
			this.mBtNext.onClick.AddListener(new UnityAction(this._onBtNextButtonClick));
			this.mMyAuctionText = this.mBind.GetCom<Text>("MyAuctionText");
			this.mOnSaleNum = this.mBind.GetCom<Text>("OnSaleNum");
			this.mItemNameInput = this.mBind.GetCom<InputField>("ItemNameInput");
			this.mInputHoldText = this.mBind.GetCom<Text>("InputHoldText");
			this.mSearchListRoot = this.mBind.GetGameObject("SearchListRoot");
			this.mSearchScrollViewRoot = this.mBind.GetCom<ComUIListScript>("SearchScrollViewRoot");
			this.mShowOnSaleRoot = this.mBind.GetGameObject("ShowOnSaleRoot");
			this.mTgShowOnSale = this.mBind.GetCom<Toggle>("tgShowOnSale");
			this.mTgShowOnSale.onValueChanged.AddListener(new UnityAction<bool>(this._onTgShowOnSaleToggleValueChange));
			this.mBack = this.mBind.GetCom<Image>("Back");
			this.mQualitySelectRoot = this.mBind.GetGameObject("QualitySelectRoot");
			this.mQualityListRoot = this.mBind.GetGameObject("QualityListRoot");
			this.mBtQualitySel = this.mBind.GetCom<Button>("btQualitySel");
			this.mBtQualitySel.onClick.AddListener(new UnityAction(this._onBtQualitySelButtonClick));
			this.mQuality = this.mBind.GetCom<Text>("Quality");
			this.mReturnRootObj = this.mBind.GetGameObject("ReturnRootObj");
			this.mReturnButton = this.mBind.GetCom<Button>("ReturnButton");
			this.mReturnButton.onClick.AddListener(new UnityAction(this._OnRetunClick));
			this.mEquipTog = this.mBind.GetCom<Toggle>("equipTog");
			this.mEquipTog.onValueChanged.AddListener(new UnityAction<bool>(this._onEquipTogValueChange));
			this.mConsumableMaterialTog = this.mBind.GetCom<Toggle>("ConsumableMaterialTog");
			this.mConsumableMaterialTog.onValueChanged.AddListener(new UnityAction<bool>(this._onConsumableMaterialTogValueChange));
		}

		// Token: 0x0600C9E1 RID: 51681 RVA: 0x003157F4 File Offset: 0x00313BF4
		protected sealed override void _unbindExUI()
		{
			this.mPage = null;
			this.mBtSearch.onClick.RemoveListener(new UnityAction(this._onBtSearchButtonClick));
			this.mBtSearch = null;
			this.mLvSelRootObj = null;
			this.mBtLevelSel.onClick.RemoveListener(new UnityAction(this._onBtLevelSelButtonClick));
			this.mBtLevelSel = null;
			this.mLevelList = null;
			this.mShowLevel = null;
			this.mPriceSelRootObj = null;
			this.mShowPrice = null;
			this.mBtPriceSel.onClick.RemoveListener(new UnityAction(this._onBtPriceSelButtonClick));
			this.mBtPriceSel = null;
			this.mPriceList = null;
			this.mRefresh = null;
			this.mAutoRefreshTime = null;
			this.mBtRefresh.onClick.RemoveListener(new UnityAction(this._onBtRefreshButtonClick));
			this.mBtRefresh = null;
			this.mRefreshCost = null;
			this.mOnSaleRefreshTip = null;
			this.mMainTypeRoot = null;
			this.mMyAuctionTitle = null;
			this.mSubTypeRoot = null;
			this.mSubTypeScrollRect = null;
			this.mSubTypeContentRoot = null;
			this.mOnSaleTips = null;
			this.mForSaleTips = null;
			this.mBuyItemTips = null;
			this.mSubTypeToggleGroup = null;
			this.mPackageItemToggleGroup = null;
			this.mShowPage = null;
			this.mBtPre.onClick.RemoveListener(new UnityAction(this._onBtPreButtonClick));
			this.mBtPre = null;
			this.mBtNext.onClick.RemoveListener(new UnityAction(this._onBtNextButtonClick));
			this.mBtNext = null;
			this.mMyAuctionText = null;
			this.mOnSaleNum = null;
			this.mItemNameInput = null;
			this.mInputHoldText = null;
			this.mSearchListRoot = null;
			this.mSearchScrollViewRoot = null;
			this.mShowOnSaleRoot = null;
			this.mTgShowOnSale.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTgShowOnSaleToggleValueChange));
			this.mTgShowOnSale = null;
			this.mBack = null;
			this.mQualitySelectRoot = null;
			this.mQualityListRoot = null;
			this.mBtQualitySel.onClick.RemoveListener(new UnityAction(this._onBtQualitySelButtonClick));
			this.mBtQualitySel = null;
			this.mQuality = null;
			this.mReturnRootObj = null;
			this.mReturnButton.onClick.RemoveListener(new UnityAction(this._OnRetunClick));
			this.mReturnButton = null;
			this.mEquipTog.onValueChanged.RemoveListener(new UnityAction<bool>(this._onEquipTogValueChange));
			this.mEquipTog = null;
			this.mConsumableMaterialTog.onValueChanged.RemoveListener(new UnityAction<bool>(this._onConsumableMaterialTogValueChange));
			this.mConsumableMaterialTog = null;
		}

		// Token: 0x0600C9E2 RID: 51682 RVA: 0x00315A70 File Offset: 0x00313E70
		private void _onBtSearchButtonClick()
		{
			if (this.SearchItemTypeID <= 0)
			{
				return;
			}
			this.SendSearchItemReq();
			this.bHasSearchedItem = true;
			this.mSearchListRoot.CustomActive(false);
		}

		// Token: 0x0600C9E3 RID: 51683 RVA: 0x00315A98 File Offset: 0x00313E98
		private void _onBtLevelSelButtonClick()
		{
			if (this.mLevelList.activeSelf)
			{
				this.mLevelList.CustomActive(false);
			}
			else
			{
				this.mLevelList.CustomActive(true);
			}
		}

		// Token: 0x0600C9E4 RID: 51684 RVA: 0x00315AC7 File Offset: 0x00313EC7
		private void _onBtPriceSelButtonClick()
		{
			if (this.mPriceList.activeSelf)
			{
				this.mPriceList.CustomActive(false);
			}
			else
			{
				this.mPriceList.CustomActive(true);
			}
		}

		// Token: 0x0600C9E5 RID: 51685 RVA: 0x00315AF8 File Offset: 0x00313EF8
		private void _onBtRefreshButtonClick()
		{
			if (this.bCanFreeRefresh)
			{
				this.SendRefreshItemList();
			}
			else
			{
				CurrencyConfigureTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CurrencyConfigureTable>(1, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				string msgContent = string.Format("是否花费{0}{1}刷新商品", tableItem.Num, DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(tableItem.CostItemID));
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this.OnClickRefreshOK), null, 0f, false);
			}
		}

		// Token: 0x0600C9E6 RID: 51686 RVA: 0x00315B77 File Offset: 0x00313F77
		private void _onBtPreButtonClick()
		{
			if (this.CurPage <= 1)
			{
				return;
			}
			this.CurPage--;
			this.SendItemListReq();
			this.UpdatePageButtonState();
		}

		// Token: 0x0600C9E7 RID: 51687 RVA: 0x00315BA0 File Offset: 0x00313FA0
		private void _onBtNextButtonClick()
		{
			if (this.CurPage >= this.MaxPage)
			{
				return;
			}
			this.CurPage++;
			this.SendItemListReq();
			this.UpdatePageButtonState();
		}

		// Token: 0x0600C9E8 RID: 51688 RVA: 0x00315BCE File Offset: 0x00313FCE
		private void _onTgShowOnSaleToggleValueChange(bool changed)
		{
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			this.requestServerReturnSuccess = false;
			this.bOnlyShowOnSaleItem = changed;
			if (this.bHasSearchedItem)
			{
				this.SendSearchItemReq();
			}
			else
			{
				this.SendItemTypeListReq(this.CurBaseType);
			}
		}

		// Token: 0x0600C9E9 RID: 51689 RVA: 0x00315C0B File Offset: 0x0031400B
		private void _onBtQualitySelButtonClick()
		{
			if (this.mQualityListRoot.activeSelf)
			{
				this.mQualityListRoot.CustomActive(false);
			}
			else
			{
				this.mQualityListRoot.CustomActive(true);
			}
		}

		// Token: 0x0600C9EA RID: 51690 RVA: 0x00315C3A File Offset: 0x0031403A
		private void _OnRetunClick()
		{
			this.UpdateSubTypeMenuGroupPrefabs();
		}

		// Token: 0x0600C9EB RID: 51691 RVA: 0x00315C42 File Offset: 0x00314042
		private void _onEquipTogValueChange(bool change)
		{
			this.UpdatePackageItemsFliterUid(AuctionSellItemType.ASIT_EQUIP);
			this._updateForSaleTips();
			this.PackageItemsFliterUid.Sort();
			this.InitPackageItemScrollViewBind();
			this.RefreshForSaleScrollRect();
		}

		// Token: 0x0600C9EC RID: 51692 RVA: 0x00315C68 File Offset: 0x00314068
		private void _onConsumableMaterialTogValueChange(bool change)
		{
			this.UpdatePackageItemsFliterUid(AuctionSellItemType.ASIT_CONSUMABLEMATERIA);
			this._updateForSaleTips();
			this.PackageItemsFliterUid.Sort();
			this.InitPackageItemScrollViewBind();
			this.RefreshForSaleScrollRect();
		}

		// Token: 0x0400748B RID: 29835
		private string MenuGroupPrefabPath = "UIFlatten/Prefabs/Auction/AuctionMenuGroup";

		// Token: 0x0400748C RID: 29836
		private string FirstMenuPrefabPath = "UIFlatten/Prefabs/Auction/AuctionFirstMenu";

		// Token: 0x0400748D RID: 29837
		private string secondMenuPrefabPath = "UIFlatten/Prefabs/Auction/AuctionSecondMenu";

		// Token: 0x0400748E RID: 29838
		private const int BaseTypeNum = 6;

		// Token: 0x0400748F RID: 29839
		private const int FuncNum = 3;

		// Token: 0x04007490 RID: 29840
		private const int LevelNum = 3;

		// Token: 0x04007491 RID: 29841
		private const int QualityNum = 7;

		// Token: 0x04007492 RID: 29842
		private const int PriceSortNum = 2;

		// Token: 0x04007493 RID: 29843
		private AuctionPage CurAuctionPage;

		// Token: 0x04007494 RID: 29844
		private AuctionBuyPageState CurBuyPageState;

		// Token: 0x04007495 RID: 29845
		private AuctionMainItemType CurBaseType;

		// Token: 0x04007496 RID: 29846
		private AuctionClassify.eJob CurSelJobType;

		// Token: 0x04007497 RID: 29847
		private int MaxOnSaleItemNum;

		// Token: 0x04007498 RID: 29848
		private int CurSelSubTypeFirstMenuIndex;

		// Token: 0x04007499 RID: 29849
		private int CurSelSubTypeSecondMenuIndex;

		// Token: 0x0400749A RID: 29850
		private int CurPage = 1;

		// Token: 0x0400749B RID: 29851
		private int MaxPage;

		// Token: 0x0400749C RID: 29852
		private int CurSelectItemIndex;

		// Token: 0x0400749D RID: 29853
		private int CurBuyIndex;

		// Token: 0x0400749E RID: 29854
		private int CurSelOnSaleItemIndex;

		// Token: 0x0400749F RID: 29855
		private int CurSelLevelIndex;

		// Token: 0x040074A0 RID: 29856
		private int WeaponSellevelIndex;

		// Token: 0x040074A1 RID: 29857
		private int CurSelQualityIndex;

		// Token: 0x040074A2 RID: 29858
		private int CurSelPriceSortIndex;

		// Token: 0x040074A3 RID: 29859
		private bool bInitBuyItemScrollBind;

		// Token: 0x040074A4 RID: 29860
		private bool bInitSellItemScrollBind;

		// Token: 0x040074A5 RID: 29861
		private bool bInitPackageItemScrollBind;

		// Token: 0x040074A6 RID: 29862
		private bool bInitSearchListScrollBind;

		// Token: 0x040074A7 RID: 29863
		private int SearchItemTypeID;

		// Token: 0x040074A8 RID: 29864
		private bool SelSearchItemState;

		// Token: 0x040074A9 RID: 29865
		private bool bHasSearchedItem;

		// Token: 0x040074AA RID: 29866
		private bool bOnlyShowOnSaleItem = true;

		// Token: 0x040074AB RID: 29867
		private int iMaxAddFieldNum;

		// Token: 0x040074AC RID: 29868
		private int iAuctionRefreshTime;

		// Token: 0x040074AD RID: 29869
		private bool bCanFreeRefresh;

		// Token: 0x040074AE RID: 29870
		private int iRefreshCostNum;

		// Token: 0x040074AF RID: 29871
		private bool requestServerReturnSuccess;

		// Token: 0x040074B0 RID: 29872
		private List<GameObject> SubTypeMenuGroupObjList = new List<GameObject>();

		// Token: 0x040074B1 RID: 29873
		private List<GameObject> SubTypeFirstMenuObjList = new List<GameObject>();

		// Token: 0x040074B2 RID: 29874
		private Dictionary<int, bool> _subTypeSecondMenuFlagDict = new Dictionary<int, bool>();

		// Token: 0x040074B3 RID: 29875
		private Dictionary<int, List<GameObject>> SubTypeSecondMenuObjDict = new Dictionary<int, List<GameObject>>();

		// Token: 0x040074B4 RID: 29876
		private Dictionary<ulong, ItemData> ItemDetailList = new Dictionary<ulong, ItemData>();

		// Token: 0x040074B5 RID: 29877
		private ItemData PackingData;

		// Token: 0x040074B6 RID: 29878
		private OutComeAuctionData OutData;

		// Token: 0x040074B7 RID: 29879
		private List<AuctionItemBaseInfo> ShowItemTypeList = new List<AuctionItemBaseInfo>();

		// Token: 0x040074B8 RID: 29880
		private List<AuctionBaseInfo> ShowItemList = new List<AuctionBaseInfo>();

		// Token: 0x040074B9 RID: 29881
		private List<AuctionBaseInfo> SelfOnSaleItemList = new List<AuctionBaseInfo>();

		// Token: 0x040074BA RID: 29882
		private List<AuctionBaseInfo> SelfOnSaleItemFliterList = new List<AuctionBaseInfo>();

		// Token: 0x040074BB RID: 29883
		private List<ulong> PackageItemsUid = new List<ulong>();

		// Token: 0x040074BC RID: 29884
		private List<AuctionSellItemData> PackageItemsFliterUid = new List<AuctionSellItemData>();

		// Token: 0x040074BD RID: 29885
		private List<SearchItemData> SearchItemList = new List<SearchItemData>();

		// Token: 0x040074BE RID: 29886
		private List<AuctionBaseInfo> SelfOnSaleItemFliterListNew = new List<AuctionBaseInfo>();

		// Token: 0x040074BF RID: 29887
		[UIControl("Type/ItemType{0}", typeof(Toggle), 1)]
		private Toggle[] MainTypes = new Toggle[6];

		// Token: 0x040074C0 RID: 29888
		[UIControl("middle/right/func{0}", typeof(RectTransform), 1)]
		private RectTransform[] funcs = new RectTransform[3];

		// Token: 0x040074C1 RID: 29889
		[UIControl("middle/right/func{0}/Scroll View", typeof(ComUIListScript), 1)]
		private ComUIListScript[] ScrollViewRoots = new ComUIListScript[3];

		// Token: 0x040074C2 RID: 29890
		[UIControl("middle/right/func{0}/Scroll View", typeof(ScrollRect), 1)]
		private ScrollRect[] ScrollRects = new ScrollRect[3];

		// Token: 0x040074C3 RID: 29891
		[UIControl("Levelselect/LevelList/Level{0}", typeof(Toggle), 1)]
		private Toggle[] LevelTypes = new Toggle[3];

		// Token: 0x040074C4 RID: 29892
		private GameObject mPage;

		// Token: 0x040074C5 RID: 29893
		private Button mBtSearch;

		// Token: 0x040074C6 RID: 29894
		private GameObject mLvSelRootObj;

		// Token: 0x040074C7 RID: 29895
		private Button mBtLevelSel;

		// Token: 0x040074C8 RID: 29896
		private GameObject mLevelList;

		// Token: 0x040074C9 RID: 29897
		private Text mShowLevel;

		// Token: 0x040074CA RID: 29898
		private GameObject mPriceSelRootObj;

		// Token: 0x040074CB RID: 29899
		private Text mShowPrice;

		// Token: 0x040074CC RID: 29900
		private Button mBtPriceSel;

		// Token: 0x040074CD RID: 29901
		private GameObject mPriceList;

		// Token: 0x040074CE RID: 29902
		private GameObject mRefresh;

		// Token: 0x040074CF RID: 29903
		private Text mAutoRefreshTime;

		// Token: 0x040074D0 RID: 29904
		private Button mBtRefresh;

		// Token: 0x040074D1 RID: 29905
		private Text mRefreshCost;

		// Token: 0x040074D2 RID: 29906
		private Text mOnSaleRefreshTip;

		// Token: 0x040074D3 RID: 29907
		private GameObject mMainTypeRoot;

		// Token: 0x040074D4 RID: 29908
		private GameObject mMyAuctionTitle;

		// Token: 0x040074D5 RID: 29909
		private GameObject mSubTypeRoot;

		// Token: 0x040074D6 RID: 29910
		private ScrollRect mSubTypeScrollRect;

		// Token: 0x040074D7 RID: 29911
		private GameObject mSubTypeContentRoot;

		// Token: 0x040074D8 RID: 29912
		private Text mOnSaleTips;

		// Token: 0x040074D9 RID: 29913
		private Text mForSaleTips;

		// Token: 0x040074DA RID: 29914
		private Text mBuyItemTips;

		// Token: 0x040074DB RID: 29915
		private ToggleGroup mSubTypeToggleGroup;

		// Token: 0x040074DC RID: 29916
		private ToggleGroup mPackageItemToggleGroup;

		// Token: 0x040074DD RID: 29917
		private Text mShowPage;

		// Token: 0x040074DE RID: 29918
		private Button mBtPre;

		// Token: 0x040074DF RID: 29919
		private Button mBtNext;

		// Token: 0x040074E0 RID: 29920
		private Text mMyAuctionText;

		// Token: 0x040074E1 RID: 29921
		private Text mOnSaleNum;

		// Token: 0x040074E2 RID: 29922
		private InputField mItemNameInput;

		// Token: 0x040074E3 RID: 29923
		private Text mInputHoldText;

		// Token: 0x040074E4 RID: 29924
		private GameObject mSearchListRoot;

		// Token: 0x040074E5 RID: 29925
		private ComUIListScript mSearchScrollViewRoot;

		// Token: 0x040074E6 RID: 29926
		private GameObject mShowOnSaleRoot;

		// Token: 0x040074E7 RID: 29927
		private Toggle mTgShowOnSale;

		// Token: 0x040074E8 RID: 29928
		private Image mBack;

		// Token: 0x040074E9 RID: 29929
		private GameObject mQualitySelectRoot;

		// Token: 0x040074EA RID: 29930
		private GameObject mQualityListRoot;

		// Token: 0x040074EB RID: 29931
		private Button mBtQualitySel;

		// Token: 0x040074EC RID: 29932
		private Text mQuality;

		// Token: 0x040074ED RID: 29933
		private GameObject mReturnRootObj;

		// Token: 0x040074EE RID: 29934
		private Button mReturnButton;

		// Token: 0x040074EF RID: 29935
		private Toggle mEquipTog;

		// Token: 0x040074F0 RID: 29936
		private Toggle mConsumableMaterialTog;
	}
}

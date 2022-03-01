using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A7A RID: 6778
	public class ShopNewElementItem : MonoBehaviour
	{
		// Token: 0x06010A21 RID: 68129 RVA: 0x004B4CFC File Offset: 0x004B30FC
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06010A22 RID: 68130 RVA: 0x004B4D04 File Offset: 0x004B3104
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClick));
			}
			if (this.itemLockLimitButton != null)
			{
				this.itemLockLimitButton.onClick.RemoveAllListeners();
				this.itemLockLimitButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopNewBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this.OnShopNewBuyItemSucceed));
		}

		// Token: 0x06010A23 RID: 68131 RVA: 0x004B4DA6 File Offset: 0x004B31A6
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06010A24 RID: 68132 RVA: 0x004B4DB4 File Offset: 0x004B31B4
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			if (this.itemLockLimitButton != null)
			{
				this.itemLockLimitButton.onClick.RemoveAllListeners();
			}
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopNewBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this.OnShopNewBuyItemSucceed));
		}

		// Token: 0x06010A25 RID: 68133 RVA: 0x004B4E41 File Offset: 0x004B3241
		private void ClearData()
		{
			this.OnRecycleElementItem();
			this._limitTimeStr = null;
			this._shopCostEqualItemIdList = null;
			this._discountValue = 0;
			this.ResetShopNewCostItemData();
		}

		// Token: 0x06010A26 RID: 68134 RVA: 0x004B4E64 File Offset: 0x004B3264
		public void InitElementItem(ShopNewShopItemTable shopNewShopItemTable)
		{
			this._shopNewShopItemTable = shopNewShopItemTable;
			if (this._shopNewShopItemTable == null)
			{
				return;
			}
			if (this._shopNewShopItemTable.ShopItemTable == null)
			{
				return;
			}
			this.InitShopItemDiscountValue();
			this._shopItemData = ItemDataManager.CreateItemDataFromTable(this._shopNewShopItemTable.ShopItemTable.ItemID, 100, 0);
			if (this._shopItemData == null)
			{
				Logger.LogErrorFormat("ShopNewElementItem InitElementItemData shopItemData is null and ItemId is {0}", new object[]
				{
					this._shopNewShopItemTable.ShopItemTable.ItemID
				});
				return;
			}
			this._shopItemData.Count = this._shopNewShopItemTable.ShopItemTable.GroupNum;
			this._shopCostItemData = ItemDataManager.CreateItemDataFromTable(this._shopNewShopItemTable.ShopItemTable.CostItemID, 100, 0);
			if (this._shopCostItemData == null)
			{
				Logger.LogErrorFormat("ShopCostItemData is null and costItemId is {0}", new object[]
				{
					this._shopNewShopItemTable.ShopItemTable.ID
				});
				return;
			}
			this._shopCostEqualItemIdList = ShopNewUtility.GetShopCostItemEqualItemIdListByOneItem(this._shopCostItemData.TableID);
			this.InitShopNewCostItemData();
			this.InitElementItemView();
		}

		// Token: 0x06010A27 RID: 68135 RVA: 0x004B4F7C File Offset: 0x004B337C
		private void InitShopItemDiscountValue()
		{
			this._discountValue = 0;
			if (this._shopNewShopItemTable.VipDiscount > 0 && this._shopNewShopItemTable.VipDiscount < 100)
			{
				this._discountValue = this._shopNewShopItemTable.VipDiscount;
			}
			else if (this._shopNewShopItemTable.GoodDiscount > 0 && this._shopNewShopItemTable.GoodDiscount < 100)
			{
				this._discountValue = this._shopNewShopItemTable.GoodDiscount;
			}
		}

		// Token: 0x06010A28 RID: 68136 RVA: 0x004B4FFD File Offset: 0x004B33FD
		private void InitElementItemView()
		{
			this.BindItemEventSystem();
			this.InitElementItemComItem();
			this.InitElementItemPrice();
			this.InitElementItemLimitData();
			this.UpdateElementItemLimitInfo();
			this.InitElementOtherInfo();
		}

		// Token: 0x06010A29 RID: 68137 RVA: 0x004B5024 File Offset: 0x004B3424
		private void InitElementItemComItem()
		{
			if (this.itemRoot != null)
			{
				this._comItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (this._comItem == null)
				{
					this._comItem = ComItemManager.Create(this.itemRoot);
				}
				if (this._comItem != null && this._shopItemData != null)
				{
					this._comItem.Setup(this._shopItemData, new ComItem.OnItemClicked(this.ShowElementItemTip));
				}
			}
			if (this.itemName != null && this._shopItemData != null)
			{
				this.itemName.text = this._shopItemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06010A2A RID: 68138 RVA: 0x004B50E8 File Offset: 0x004B34E8
		private void InitElementItemPrice()
		{
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				this.InitElementSpecialPriceControl();
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.specialPriceRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.normalPriceRoot, true);
			bool flag = DataManager<ShopNewDataManager>.GetInstance().IsMoneyItemShowName(this._shopCostItemData.TableID);
			if (flag)
			{
				if (this.priceIcon != null)
				{
					this.priceIcon.gameObject.CustomActive(false);
				}
				if (this.priceName != null)
				{
					this.priceName.text = this._shopCostItemData.Name;
					this.priceName.gameObject.CustomActive(true);
				}
			}
			else
			{
				if (this.priceIcon != null)
				{
					EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(this._shopCostItemData.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.EqualItemIDs[0], string.Empty, string.Empty);
						ETCImageLoader.LoadSprite(ref this.priceIcon, tableItem2.Icon, true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.priceIcon, this._shopCostItemData.Icon, true);
					}
					this.priceIcon.gameObject.CustomActive(true);
				}
				if (this.priceName != null)
				{
					this.priceName.gameObject.CustomActive(false);
				}
			}
			this._isShowOldChangeNewComItem = (DataManager<ShopNewDataManager>.GetInstance().IsShowOldChangeNew(this._shopNewShopItemTable) && this._shopNewShopItemTable.LimitBuyTimes != 0);
			this.comOldChangeNewItem.gameObject.CustomActive(this._isShowOldChangeNewComItem);
			this._oldChangeNewItemList.Clear();
			if (this._isShowOldChangeNewComItem)
			{
				DataManager<ShopNewDataManager>.GetInstance().GetOldChangeNewItem(this._shopNewShopItemTable.ShopItemTable, this._oldChangeNewItemList);
			}
			this.InitShopNewSecondCostItemView();
			this.UpdateCostValue();
		}

		// Token: 0x06010A2B RID: 68139 RVA: 0x004B52E8 File Offset: 0x004B36E8
		private void InitElementSpecialPriceControl()
		{
			CommonUtility.UpdateGameObjectVisible(this.specialPriceRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.normalPriceRoot, false);
			if (this._shopNewSpecialPriceControl == null)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.specialPriceControlPath, true, 0U);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.specialPriceRoot.transform, false);
					this._shopNewSpecialPriceControl = gameObject.GetComponent<ShopNewSpecialPriceControl>();
				}
			}
			if (this._shopNewSpecialPriceControl != null)
			{
				this._shopNewSpecialPriceControl.InitSpecialPriceControl(this._shopNewTotalCostItemDataModelList, this._discountValue, 1);
			}
		}

		// Token: 0x06010A2C RID: 68140 RVA: 0x004B538C File Offset: 0x004B378C
		private void InitElementItemLimitData()
		{
			try
			{
				int shopID = this._shopNewShopItemTable.ShopItemTable.ShopID;
				bool flag = false;
				int num = -1;
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(shopID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if ((tableItem.Refresh == 2 || tableItem.Refresh == 1) && tableItem.SubType.Count == tableItem.NeedRefreshTabs.Count && tableItem.SubType.Count == tableItem.RefreshCycle.Count)
					{
						for (int i = 0; i < tableItem.SubType.Count; i++)
						{
							if (tableItem.SubType[i] == (ShopTable.eSubType)this._shopNewShopItemTable.ShopItemTable.SubType)
							{
								num = i;
								break;
							}
						}
					}
					if (num != -1 && tableItem.NeedRefreshTabs[num] == 1)
					{
						flag = true;
					}
					if (flag)
					{
						switch (tableItem.RefreshCycle[num])
						{
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_NONE:
							this._limitTimeStr = "shop_item_limit_buy_forever";
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_DAILY:
							this._limitTimeStr = "shop_item_limit_buy_daily";
							if (tableItem.Refresh == 1)
							{
								this._limitTimeStr = "shop_item_limit_buy_mystery";
							}
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_WEEK:
							this._limitTimeStr = "shop_item_limit_buy_weekly";
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_MONTH:
							this._limitTimeStr = "shop_item_limit_buy_monthly";
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_ACTIVITY:
							this._limitTimeStr = "shop_item_limit_buy_activity";
							break;
						}
					}
					else if (this._shopNewShopItemTable.LimitBuyTimes > 0)
					{
						this._limitTimeStr = "shop_item_limit_buy_forever";
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("ShopNewElementItem InitElementItemLimit Exception is {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x06010A2D RID: 68141 RVA: 0x004B5580 File Offset: 0x004B3980
		private void UpdateElementItemLimitInfo()
		{
			int limitBuyTimes = this._shopNewShopItemTable.LimitBuyTimes;
			this.itemLimitTimes.gameObject.CustomActive(limitBuyTimes > 0);
			if (limitBuyTimes > 0 && !string.IsNullOrEmpty(this._limitTimeStr))
			{
				this.itemLimitTimes.text = TR.Value(this._limitTimeStr, this._shopNewShopItemTable.LimitBuyTimes);
			}
			if (limitBuyTimes == 0)
			{
				this.buyButton.enabled = false;
				this.buyButtonGray.enabled = true;
				this.soldOverText.gameObject.CustomActive(true);
				this.priceRoot.gameObject.CustomActive(false);
			}
			else
			{
				this.buyButton.enabled = true;
				this.buyButtonGray.enabled = false;
				this.soldOverText.gameObject.CustomActive(false);
				this.priceRoot.gameObject.CustomActive(true);
			}
		}

		// Token: 0x06010A2E RID: 68142 RVA: 0x004B566C File Offset: 0x004B3A6C
		private void InitElementOtherInfo()
		{
			bool flag = true;
			GoodsLimitButyType exLimite = (GoodsLimitButyType)this._shopNewShopItemTable.ShopItemTable.ExLimite;
			int exValue = this._shopNewShopItemTable.ShopItemTable.ExValue;
			switch (exLimite)
			{
			case GoodsLimitButyType.GLBT_NONE:
				this.itemLockLimitRoot.gameObject.CustomActive(false);
				break;
			case GoodsLimitButyType.GLBT_FIGHT_SCORE:
			{
				int num = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
				this.itemLockLimitRoot.CustomActive(num < exValue);
				string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(exValue, true);
				this.itemLockLimitText.text = string.Format(TR.Value("shop_refresh_need_fight_score"), rankName);
				flag = (num >= exValue);
				break;
			}
			case GoodsLimitButyType.GLBT_TOWER_LEVEL:
			{
				int num = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
				this.itemLockLimitRoot.CustomActive(num < exValue);
				this.itemLockLimitText.text = string.Format(TR.Value("shop_refresh_need_tower_level"), exValue);
				flag = (num >= exValue);
				break;
			}
			case GoodsLimitButyType.GLBT_GUILD_LEVEL:
			{
				int num = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
				this.itemLockLimitRoot.CustomActive(num < exValue);
				this.itemLockLimitText.text = string.Format(TR.Value("shop_refresh_need_guild_level"), exValue);
				flag = (num >= exValue);
				break;
			}
			case GoodsLimitButyType.GLBT_HONOR_LEVEL_LIMIT:
			{
				int num = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel;
				this.itemLockLimitRoot.CustomActive(num < exValue);
				this.itemLockLimitText.text = TR.Value("Honor_System_Shop_Item_Level_Limit", exValue);
				flag = (num >= exValue);
				break;
			}
			}
			if (this.itemLockLimitRoot.activeSelf)
			{
				this.buyButton.gameObject.CustomActive(false);
				this.priceRoot.gameObject.CustomActive(false);
			}
			else
			{
				this.buyButton.gameObject.CustomActive(true);
				this.priceRoot.gameObject.CustomActive(!this.soldOverText.gameObject.activeSelf);
			}
			GoodsData.GoodsDataShowType elementShowType = this.GetElementShowType();
			this.vipRoot.gameObject.CustomActive(false);
			if (elementShowType == GoodsData.GoodsDataShowType.GDST_VIP)
			{
				this.vipRoot.gameObject.CustomActive(true);
				this.vipText.text = string.Format(TR.Value("vipFormat"), this._shopNewShopItemTable.VipLimitLevel);
			}
			if (flag && this._shopNewShopItemTable.VipLimitLevel > 0 && this._shopNewShopItemTable.VipLimitLevel > DataManager<PlayerBaseData>.GetInstance().VipLevel)
			{
				flag = false;
			}
			this.canNotBuyMask.CustomActive(!flag);
			if (this.discountRoot != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.discountRoot, false);
				if (this._discountValue > 0 && this._discountValue < 100)
				{
					CommonUtility.UpdateGameObjectVisible(this.discountRoot, true);
					ShopItemDiscountController componentInChildren = this.discountRoot.GetComponentInChildren<ShopItemDiscountController>();
					if (componentInChildren == null)
					{
						CommonUtility.LoadGameObject(this.discountRoot);
						componentInChildren = this.discountRoot.GetComponentInChildren<ShopItemDiscountController>();
					}
					if (componentInChildren != null)
					{
						componentInChildren.InitShopItemDiscount(this._discountValue);
					}
				}
			}
		}

		// Token: 0x06010A2F RID: 68143 RVA: 0x004B5994 File Offset: 0x004B3D94
		private void BindItemEventSystem()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010A30 RID: 68144 RVA: 0x004B5A3C File Offset: 0x004B3E3C
		private void UnBindItemEventSystem()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010A31 RID: 68145 RVA: 0x004B5AE4 File Offset: 0x004B3EE4
		private void OnAddNewItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null)
				{
					if (this.IsCostItemData(item.TableID))
					{
						this.UpdateCostValue();
						break;
					}
					if (this.IsItemOldChangeNew(item.TableID))
					{
						this.UpdateCostValue();
						break;
					}
				}
			}
		}

		// Token: 0x06010A32 RID: 68146 RVA: 0x004B5B5D File Offset: 0x004B3F5D
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.IsCostItemData(itemData.TableID))
			{
				this.UpdateCostValue();
				return;
			}
			if (this.IsItemOldChangeNew(itemData.TableID))
			{
				this.UpdateCostValue();
				return;
			}
		}

		// Token: 0x06010A33 RID: 68147 RVA: 0x004B5B98 File Offset: 0x004B3F98
		private void OnUpdateItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null)
				{
					if (this.IsCostItemData(item.TableID))
					{
						this.UpdateCostValue();
						break;
					}
					if (this.IsItemOldChangeNew(item.TableID))
					{
						this.UpdateCostValue();
						break;
					}
				}
			}
		}

		// Token: 0x06010A34 RID: 68148 RVA: 0x004B5C16 File Offset: 0x004B4016
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateCostValue();
		}

		// Token: 0x06010A35 RID: 68149 RVA: 0x004B5C20 File Offset: 0x004B4020
		private bool IsCostItemData(int itemId)
		{
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				for (int i = 0; i < this._shopNewTotalCostItemDataModelList.Count; i++)
				{
					ShopNewCostItemDataModel shopNewCostItemDataModel = this._shopNewTotalCostItemDataModelList[i];
					if (shopNewCostItemDataModel != null)
					{
						if (shopNewCostItemDataModel.CostItemId == itemId)
						{
							return true;
						}
					}
				}
				if (this._shopNewTotalCostEqualItemIdList != null && this._shopNewTotalCostEqualItemIdList.Count > 0)
				{
					for (int j = 0; j < this._shopNewTotalCostEqualItemIdList.Count; j++)
					{
						if (this._shopNewTotalCostEqualItemIdList[j] == itemId)
						{
							return true;
						}
					}
				}
				return false;
			}
			if (this._shopCostItemData == null)
			{
				return false;
			}
			if (this._shopCostItemData.TableID == itemId)
			{
				return true;
			}
			if (this._shopCostEqualItemIdList == null || this._shopCostEqualItemIdList.Count <= 0)
			{
				return false;
			}
			for (int k = 0; k < this._shopCostEqualItemIdList.Count; k++)
			{
				if (this._shopCostEqualItemIdList[k] == itemId)
				{
					return true;
				}
			}
			if (this._shopNewSecondCostItemId > 0 && this._shopNewSecondCostItemId == itemId)
			{
				return true;
			}
			if (this._shopNewSecondCostEqualItemIdList != null && this._shopNewSecondCostEqualItemIdList.Count > 0)
			{
				for (int l = 0; l < this._shopNewSecondCostEqualItemIdList.Count; l++)
				{
					if (this._shopNewSecondCostEqualItemIdList[l] == itemId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06010A36 RID: 68150 RVA: 0x004B5DB4 File Offset: 0x004B41B4
		private void UpdateCostValue()
		{
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				if (this._shopNewSpecialPriceControl != null)
				{
					this._shopNewSpecialPriceControl.UpdateCostItemListValue();
				}
				return;
			}
			this.UpdateShopNewSecondCostItemView();
			if (this.priceValue == null)
			{
				return;
			}
			if (this._shopNewShopItemTable == null)
			{
				return;
			}
			if (this._shopCostItemData == null)
			{
				return;
			}
			int num = this._shopNewShopItemTable.ShopItemTable.CostNum;
			num = ShopNewUtility.GetRealCostValue(num, this._discountValue);
			this.priceValue.text = num.ToString();
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._shopCostItemData.TableID, true);
			if (ownedItemCount >= num)
			{
				this.priceValue.color = Color.white;
			}
			else
			{
				this.priceValue.color = Color.red;
			}
			this.UpdateOldChangeNewComItem();
		}

		// Token: 0x06010A37 RID: 68151 RVA: 0x004B5EA9 File Offset: 0x004B42A9
		private void UpdateOldChangeNewComItem()
		{
			if (this._isShowOldChangeNewComItem && this.comOldChangeNewItem.gameObject.activeSelf)
			{
				this.comOldChangeNewItem.SetItemId(this._shopNewShopItemTable.ShopItemTable.ID);
			}
		}

		// Token: 0x06010A38 RID: 68152 RVA: 0x004B5EE8 File Offset: 0x004B42E8
		private bool IsItemOldChangeNew(int itemId)
		{
			if (this._oldChangeNewItemList == null || this._oldChangeNewItemList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._oldChangeNewItemList.Count; i++)
			{
				if (this._oldChangeNewItemList[i].ID == itemId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010A39 RID: 68153 RVA: 0x004B5F4C File Offset: 0x004B434C
		private void OnShopNewBuyItemSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (this._shopNewShopItemTable == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._shopNewShopItemTable.ShopItemId != num)
			{
				return;
			}
			if (this._shopNewShopItemTable.LimitBuyTimes == -1)
			{
				return;
			}
			this.UpdateElementItemLimitInfo();
		}

		// Token: 0x06010A3A RID: 68154 RVA: 0x004B5FA2 File Offset: 0x004B43A2
		public void OnRecycleElementItem()
		{
			this.UnBindItemEventSystem();
			this._shopNewShopItemTable = null;
			this.ResetShopNewCostItemData();
		}

		// Token: 0x06010A3B RID: 68155 RVA: 0x004B5FB7 File Offset: 0x004B43B7
		private GoodsData.GoodsDataShowType GetElementShowType()
		{
			if (this._shopNewShopItemTable.VipLimitLevel > 0)
			{
				return GoodsData.GoodsDataShowType.GDST_VIP;
			}
			if (this._shopNewShopItemTable.LimitBuyTimes >= 0)
			{
				return GoodsData.GoodsDataShowType.GDST_LIMIT_COUNT;
			}
			return GoodsData.GoodsDataShowType.GDST_NORMAL;
		}

		// Token: 0x06010A3C RID: 68156 RVA: 0x004B5FE0 File Offset: 0x004B43E0
		private void OnBuyButtonClick()
		{
			if (this._shopNewShopItemTable == null || this._shopNewShopItemTable.ShopItemTable == null)
			{
				return;
			}
			Utility.DoStartFrameOperation("ShopNewElementItem", string.Format("ShopItemID/{0}", this._shopNewShopItemTable.ShopItemId));
			GoodsLimitButyType exLimite = (GoodsLimitButyType)this._shopNewShopItemTable.ShopItemTable.ExLimite;
			int exValue = this._shopNewShopItemTable.ShopItemTable.ExValue;
			if (exLimite != GoodsLimitButyType.GLBT_NONE)
			{
				if (exLimite == GoodsLimitButyType.GLBT_TOWER_LEVEL)
				{
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
					if (count < exValue)
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_tower_level"), exValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				else if (exLimite == GoodsLimitButyType.GLBT_FIGHT_SCORE)
				{
					int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					if (seasonLevel < exValue)
					{
						string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(exValue, true);
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_fight_score"), rankName), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				else if (exLimite == GoodsLimitButyType.GLBT_GUILD_LEVEL)
				{
					int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
					if (buildingLevel < exValue)
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_guild_level"), exValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				else if (exLimite == GoodsLimitButyType.GLBT_HONOR_LEVEL_LIMIT)
				{
					int playerHonorLevel = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel;
					if (playerHonorLevel < exValue)
					{
						string msgContent = string.Format(TR.Value("Honor_System_Item_UnLock_Need_Level_In_Shop"), exValue);
						SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
			}
			int vipLimitLevel = this._shopNewShopItemTable.VipLimitLevel;
			if (vipLimitLevel > 0 && vipLimitLevel > DataManager<PlayerBaseData>.GetInstance().VipLevel)
			{
				SystemNotifyManager.SystemNotify(1800011, delegate()
				{
					VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
					if (vipFrame != null)
					{
						vipFrame.OpenPayTab();
					}
				});
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ShopNewPurchaseItemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewPurchaseItemFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShopNewPurchaseItemFrame>(FrameLayer.Middle, this._shopNewShopItemTable, string.Empty);
		}

		// Token: 0x06010A3D RID: 68157 RVA: 0x004B61D1 File Offset: 0x004B45D1
		private void ShowElementItemTip(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x06010A3E RID: 68158 RVA: 0x004B61E3 File Offset: 0x004B45E3
		private void ResetShopNewCostItemData()
		{
			this._isShowOldChangeNewComItem = false;
			this._oldChangeNewItemList.Clear();
			this._shopNewSecondCostItemNumber = 0;
			this._shopNewSecondCostItemId = 0;
			this._shopNewSecondCostEqualItemIdList = null;
			this._shopNewTotalCostItemDataModelList.Clear();
			this._shopNewTotalCostEqualItemIdList = null;
		}

		// Token: 0x06010A3F RID: 68159 RVA: 0x004B6220 File Offset: 0x004B4620
		private void InitShopNewCostItemData()
		{
			this.ResetShopNewCostItemData();
			if (this._shopNewShopItemTable == null || this._shopNewShopItemTable.ShopItemTable == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._shopNewShopItemTable.ShopItemTable.OtherCostItems))
			{
				return;
			}
			List<ShopNewCostItemDataModel> shopItemOtherCostItemDataModelList = ShopNewUtility.GetShopItemOtherCostItemDataModelList(this._shopNewShopItemTable.ShopItemTable.OtherCostItems);
			if (shopItemOtherCostItemDataModelList == null || shopItemOtherCostItemDataModelList.Count < 1)
			{
				return;
			}
			if (shopItemOtherCostItemDataModelList.Count == 1)
			{
				ShopNewCostItemDataModel shopNewCostItemDataModel = shopItemOtherCostItemDataModelList[0];
				if (shopNewCostItemDataModel != null)
				{
					this._shopNewSecondCostItemId = shopNewCostItemDataModel.CostItemId;
					this._shopNewSecondCostItemNumber = shopNewCostItemDataModel.CostItemNumber;
				}
				this._shopNewSecondCostEqualItemIdList = ShopNewUtility.GetShopCostItemEqualItemIdListByOneItem(this._shopNewSecondCostItemId);
			}
			else if (shopItemOtherCostItemDataModelList.Count > 1)
			{
				ShopNewCostItemDataModel shopNewCostItemDataModel2 = new ShopNewCostItemDataModel();
				shopNewCostItemDataModel2.CostItemId = this._shopCostItemData.TableID;
				shopNewCostItemDataModel2.CostItemNumber = this._shopNewShopItemTable.ShopItemTable.CostNum;
				this._shopNewTotalCostItemDataModelList.Add(shopNewCostItemDataModel2);
				for (int i = 0; i < shopItemOtherCostItemDataModelList.Count; i++)
				{
					ShopNewCostItemDataModel shopNewCostItemDataModel3 = shopItemOtherCostItemDataModelList[i];
					if (shopNewCostItemDataModel3 != null)
					{
						ShopNewCostItemDataModel shopNewCostItemDataModel4 = new ShopNewCostItemDataModel();
						shopNewCostItemDataModel4.CostItemId = shopNewCostItemDataModel3.CostItemId;
						shopNewCostItemDataModel4.CostItemNumber = shopNewCostItemDataModel3.CostItemNumber;
						this._shopNewTotalCostItemDataModelList.Add(shopNewCostItemDataModel4);
					}
				}
				this._shopNewTotalCostEqualItemIdList = ShopNewUtility.GetShopCostItemEqualItemIdListByItemList(this._shopNewTotalCostItemDataModelList);
			}
		}

		// Token: 0x06010A40 RID: 68160 RVA: 0x004B6388 File Offset: 0x004B4788
		private void InitShopNewSecondCostItemView()
		{
			if (this.shopNewOtherCostItem == null)
			{
				return;
			}
			this.shopNewOtherCostItem.gameObject.CustomActive(false);
			if (this._shopNewSecondCostItemId <= 0 || this._shopNewSecondCostItemNumber <= 0)
			{
				return;
			}
			this.shopNewOtherCostItem.gameObject.CustomActive(true);
			this.shopNewOtherCostItem.InitCostItem(this._shopNewSecondCostItemId, this._shopNewSecondCostItemNumber, this._discountValue);
			this.shopNewOtherCostItem.UpdateCostItemValue();
		}

		// Token: 0x06010A41 RID: 68161 RVA: 0x004B640A File Offset: 0x004B480A
		private void UpdateShopNewSecondCostItemView()
		{
			if (this.shopNewOtherCostItem == null)
			{
				return;
			}
			if (this._shopNewSecondCostItemId <= 0 || this._shopNewSecondCostItemNumber <= 0)
			{
				return;
			}
			this.shopNewOtherCostItem.UpdateCostItemValue();
		}

		// Token: 0x0400A9DD RID: 43485
		private ShopNewShopItemTable _shopNewShopItemTable;

		// Token: 0x0400A9DE RID: 43486
		private ItemData _shopItemData;

		// Token: 0x0400A9DF RID: 43487
		private ItemData _shopCostItemData;

		// Token: 0x0400A9E0 RID: 43488
		private List<int> _shopCostEqualItemIdList;

		// Token: 0x0400A9E1 RID: 43489
		private ComItem _comItem;

		// Token: 0x0400A9E2 RID: 43490
		private string _limitTimeStr;

		// Token: 0x0400A9E3 RID: 43491
		private bool _isShowOldChangeNewComItem;

		// Token: 0x0400A9E4 RID: 43492
		private List<AwardItemData> _oldChangeNewItemList = new List<AwardItemData>();

		// Token: 0x0400A9E5 RID: 43493
		private int _shopNewSecondCostItemId;

		// Token: 0x0400A9E6 RID: 43494
		private int _shopNewSecondCostItemNumber;

		// Token: 0x0400A9E7 RID: 43495
		private List<int> _shopNewSecondCostEqualItemIdList;

		// Token: 0x0400A9E8 RID: 43496
		private List<ShopNewCostItemDataModel> _shopNewTotalCostItemDataModelList = new List<ShopNewCostItemDataModel>();

		// Token: 0x0400A9E9 RID: 43497
		private List<int> _shopNewTotalCostEqualItemIdList;

		// Token: 0x0400A9EA RID: 43498
		private ShopNewSpecialPriceControl _shopNewSpecialPriceControl;

		// Token: 0x0400A9EB RID: 43499
		private int _discountValue;

		// Token: 0x0400A9EC RID: 43500
		[Space(5f)]
		[Header("NormalContent")]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400A9ED RID: 43501
		[SerializeField]
		private Text itemName;

		// Token: 0x0400A9EE RID: 43502
		[SerializeField]
		private Text itemLimitTimes;

		// Token: 0x0400A9EF RID: 43503
		[SerializeField]
		private Button buyButton;

		// Token: 0x0400A9F0 RID: 43504
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x0400A9F1 RID: 43505
		[Space(10f)]
		[Header("PriceInfo")]
		[SerializeField]
		private GameObject priceRoot;

		// Token: 0x0400A9F2 RID: 43506
		[SerializeField]
		private GameObject normalPriceRoot;

		// Token: 0x0400A9F3 RID: 43507
		[SerializeField]
		private Text priceName;

		// Token: 0x0400A9F4 RID: 43508
		[SerializeField]
		private Image priceIcon;

		// Token: 0x0400A9F5 RID: 43509
		[SerializeField]
		private Text priceValue;

		// Token: 0x0400A9F6 RID: 43510
		[SerializeField]
		private ComOldChangeNewItem comOldChangeNewItem;

		// Token: 0x0400A9F7 RID: 43511
		[Space(15f)]
		[Header("ShopNewOtherCostItem")]
		[Space(10f)]
		[SerializeField]
		private ShopNewCostItem shopNewOtherCostItem;

		// Token: 0x0400A9F8 RID: 43512
		[Space(20f)]
		[Header("ShopNewSpecialPriceRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject specialPriceRoot;

		// Token: 0x0400A9F9 RID: 43513
		[SerializeField]
		private string specialPriceControlPath = "UIFlatten/Prefabs/ShopNew/Control/ElementItemCostPriceControl";

		// Token: 0x0400A9FA RID: 43514
		[Space(10f)]
		[Header("OtherInfo")]
		[SerializeField]
		private Text soldOverText;

		// Token: 0x0400A9FB RID: 43515
		[SerializeField]
		private GameObject vipRoot;

		// Token: 0x0400A9FC RID: 43516
		[SerializeField]
		private Text vipText;

		// Token: 0x0400A9FD RID: 43517
		[SerializeField]
		private GameObject itemLockLimitRoot;

		// Token: 0x0400A9FE RID: 43518
		[SerializeField]
		private Button itemLockLimitButton;

		// Token: 0x0400A9FF RID: 43519
		[SerializeField]
		private Text itemLockLimitText;

		// Token: 0x0400AA00 RID: 43520
		[SerializeField]
		private GameObject canNotBuyMask;

		// Token: 0x0400AA01 RID: 43521
		[Space(20f)]
		[Header("Discount")]
		[Space(15f)]
		[SerializeField]
		private Text discountValueLabel;

		// Token: 0x0400AA02 RID: 43522
		[SerializeField]
		private GameObject discountRoot;
	}
}

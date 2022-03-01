using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A88 RID: 6792
	public class ShopNewPurchaseItemView : MonoBehaviour
	{
		// Token: 0x06010A98 RID: 68248 RVA: 0x004B7AD4 File Offset: 0x004B5ED4
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06010A99 RID: 68249 RVA: 0x004B7ADC File Offset: 0x004B5EDC
		private void BindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.selectedSlider != null)
			{
				this.selectedSlider.onValueChanged.RemoveAllListeners();
				this.selectedSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnSelectedSliderChangeValue));
			}
			if (this.selectedCountInputField != null)
			{
				this.selectedCountInputField.onValueChanged.RemoveAllListeners();
				this.selectedCountInputField.onValueChanged.AddListener(new UnityAction<string>(this.OnInputFieldValueChanged));
			}
			if (this.minButton != null)
			{
				this.minButton.onClick.RemoveAllListeners();
				this.minButton.onClick.AddListener(new UnityAction(this.OnMinButtonClickCallBack));
			}
			if (this.minusButton != null)
			{
				this.minusButton.onClick.RemoveAllListeners();
				this.minusButton.onClick.AddListener(new UnityAction(this.OnMinusButtonClickCallBack));
			}
			if (this.maxButton != null)
			{
				this.maxButton.onClick.RemoveAllListeners();
				this.maxButton.onClick.AddListener(new UnityAction(this.OnMaxButtonClickCallBack));
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.RemoveAllListeners();
				this.addButton.onClick.AddListener(new UnityAction(this.OnAddButtonClickCallBack));
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClickCallBack));
			}
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		}

		// Token: 0x06010A9A RID: 68250 RVA: 0x004B7D43 File Offset: 0x004B6143
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06010A9B RID: 68251 RVA: 0x004B7D54 File Offset: 0x004B6154
		private void ClearData()
		{
			this._shopNewShopItemTable = null;
			this._shopItemTable = null;
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
			this._curBuyNumber = 1;
			this._totalCanBuyNumber = 1;
			this._isShowOldChangeNewFlag = false;
			if (this._itemInfoList != null)
			{
				this._itemInfoList.Clear();
			}
			if (this._oldGameObjectList != null)
			{
				this._oldGameObjectList.Clear();
			}
			if (this._oldItemComItemList != null)
			{
				for (int i = 0; i < this._oldItemComItemList.Count; i++)
				{
					ComItemManager.Destroy(this._oldItemComItemList[i]);
				}
			}
			this._costItemData = null;
			this.ResetShopNewCostItemData();
		}

		// Token: 0x06010A9C RID: 68252 RVA: 0x004B7E18 File Offset: 0x004B6218
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.selectedSlider != null)
			{
				this.selectedSlider.onValueChanged.RemoveAllListeners();
			}
			if (this.selectedCountInputField != null)
			{
				this.selectedCountInputField.onValueChanged.RemoveAllListeners();
			}
			if (this.minButton != null)
			{
				this.minButton.onClick.RemoveAllListeners();
			}
			if (this.minusButton != null)
			{
				this.minusButton.onClick.RemoveAllListeners();
			}
			if (this.maxButton != null)
			{
				this.maxButton.onClick.RemoveAllListeners();
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.RemoveAllListeners();
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		}

		// Token: 0x06010A9D RID: 68253 RVA: 0x004B7FA0 File Offset: 0x004B63A0
		public void InitShop(ShopNewShopItemTable shopNewShopItemTable)
		{
			this._shopNewShopItemTable = shopNewShopItemTable;
			if (this._shopNewShopItemTable == null)
			{
				Logger.LogErrorFormat("ShopNewPurchaseItemView InitShop ItemData is null", new object[0]);
				return;
			}
			if (this._shopNewShopItemTable.ShopItemTable == null)
			{
				Logger.LogErrorFormat("ShopNewShopItemTable InitShop shopItemTable is null", new object[0]);
				return;
			}
			this.InitShopItemDiscountValue();
			this._shopItemTable = this._shopNewShopItemTable.ShopItemTable;
			this.InitShopItemBuyData();
			this.InitShopItemView();
		}

		// Token: 0x06010A9E RID: 68254 RVA: 0x004B8014 File Offset: 0x004B6414
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

		// Token: 0x06010A9F RID: 68255 RVA: 0x004B8098 File Offset: 0x004B6498
		private void InitShopItemBuyData()
		{
			this._isShowOldChangeNewFlag = DataManager<ShopNewDataManager>.GetInstance().IsShowOldChangeNew(this._shopNewShopItemTable);
			this._costItemData = ItemDataManager.CreateItemDataFromTable(this._shopItemTable.CostItemID, 100, 0);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._costItemData.TableID, true);
			int num = this._shopItemTable.CostNum;
			num = ShopNewUtility.GetRealCostValue(num, this._discountValue);
			if (num <= 0)
			{
				Logger.LogErrorFormat("InitShopData CostItem CostNumber is Invalid and costItemId is {0}", new object[]
				{
					this._shopItemTable.CostItemID
				});
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._shopItemTable.ItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("itemTable is null and itemId is {0}", new object[]
				{
					this._shopItemTable.ItemID
				});
				return;
			}
			this._totalCanBuyNumber = ownedItemCount / num;
			this.InitShopNewCostItemData();
			if (this._shopNewSecondCostItemId > 0 && this._shopNewSecondCostItemNumber > 0)
			{
				int num2 = ShopNewUtility.ShopNewBuyItemNumberByOtherCostItem(this._shopNewSecondCostItemId, this._shopNewSecondCostItemNumber, this._discountValue);
				this._totalCanBuyNumber = ((this._totalCanBuyNumber <= num2) ? this._totalCanBuyNumber : num2);
			}
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				for (int i = 0; i < this._shopNewTotalCostItemDataModelList.Count; i++)
				{
					ShopNewCostItemDataModel shopNewCostItemDataModel = this._shopNewTotalCostItemDataModelList[i];
					if (shopNewCostItemDataModel != null)
					{
						int num3 = ShopNewUtility.ShopNewBuyItemNumberByOtherCostItem(shopNewCostItemDataModel.CostItemId, shopNewCostItemDataModel.CostItemNumber, this._discountValue);
						this._totalCanBuyNumber = ((this._totalCanBuyNumber <= num3) ? this._totalCanBuyNumber : num3);
					}
				}
			}
			this._totalCanBuyNumber = ((tableItem.MaxNum >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : tableItem.MaxNum);
			int limitBuyTimes = this._shopNewShopItemTable.LimitBuyTimes;
			if (limitBuyTimes >= 0)
			{
				this._totalCanBuyNumber = ((limitBuyTimes >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : limitBuyTimes);
			}
			if (this._shopItemTable.BuyLimit > 0 && this._totalCanBuyNumber > this._shopItemTable.BuyLimit)
			{
				this._totalCanBuyNumber = this._shopItemTable.BuyLimit;
			}
			if (this._totalCanBuyNumber < 1)
			{
				this._totalCanBuyNumber = 1;
			}
		}

		// Token: 0x06010AA0 RID: 68256 RVA: 0x004B830B File Offset: 0x004B670B
		private void InitShopItemView()
		{
			this.InitShopBuyItem();
			this.InitShopCostItem();
			this.InitItemLeftNumberInfo();
			this.InitShopOldChangedNewItem();
			this.OnValueChanged();
		}

		// Token: 0x06010AA1 RID: 68257 RVA: 0x004B832C File Offset: 0x004B672C
		private void InitShopBuyItem()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._shopItemTable.ItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("itemTable is null and itemId is {0}", new object[]
				{
					this._shopItemTable.ItemID
				});
				return;
			}
			this.buyItemDescriptionText.text = tableItem.Description;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this._shopItemTable.ItemID, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemData is null and ItemId is {0}", new object[]
				{
					this._shopItemTable.ItemID
				});
				return;
			}
			this.buyItemName.text = itemData.GetColorName(string.Empty, false);
			itemData.Count = this._shopItemTable.GroupNum;
			this._comItem = this.buyItemRoot.GetComponent<ComItem>();
			if (this._comItem == null)
			{
				this._comItem = ComItemManager.Create(this.buyItemRoot);
			}
			this._comItem.Setup(itemData, null);
		}

		// Token: 0x06010AA2 RID: 68258 RVA: 0x004B843C File Offset: 0x004B683C
		private void InitShopCostItem()
		{
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				this.InitItemSpecialPriceControl();
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.specialPriceRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.normalPriceRoot, true);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._shopItemTable.CostItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("CostItemTable is null and costItemId is {0}", new object[]
				{
					this._shopItemTable.CostItemID
				});
				return;
			}
			EqualItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(this._shopItemTable.CostItemID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem2.EqualItemIDs[0], string.Empty, string.Empty);
				ETCImageLoader.LoadSprite(ref this.costIcon, tableItem3.Icon, true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.costIcon, tableItem.Icon, true);
			}
			this.costNameText.text = tableItem.Name;
			bool flag = DataManager<ShopNewDataManager>.GetInstance().IsMoneyItemShowName(this._shopItemTable.CostItemID);
			if (flag)
			{
				this.costNameText.gameObject.CustomActive(true);
				this.costIcon.gameObject.CustomActive(false);
			}
			else
			{
				this.costNameText.gameObject.CustomActive(false);
				this.costIcon.gameObject.CustomActive(true);
			}
			this.InitShopNewSecondCostItemView();
			this.UpdateShopCostItem();
		}

		// Token: 0x06010AA3 RID: 68259 RVA: 0x004B85C4 File Offset: 0x004B69C4
		private void InitItemSpecialPriceControl()
		{
			CommonUtility.UpdateGameObjectVisible(this.normalPriceRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.specialPriceRoot, true);
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
				this._shopNewSpecialPriceControl.InitSpecialPriceControl(this._shopNewTotalCostItemDataModelList, this._discountValue, this._curBuyNumber);
			}
		}

		// Token: 0x06010AA4 RID: 68260 RVA: 0x004B866C File Offset: 0x004B6A6C
		private void InitItemLeftNumberInfo()
		{
			int limitBuyTimes = this._shopNewShopItemTable.LimitBuyTimes;
			this.leftItemNumberText.text = string.Format(TR.Value("shop_buy_limit", limitBuyTimes), new object[0]);
			this.leftItemNumberText.gameObject.CustomActive(limitBuyTimes > 0 && !this._isShowOldChangeNewFlag);
		}

		// Token: 0x06010AA5 RID: 68261 RVA: 0x004B86D0 File Offset: 0x004B6AD0
		private void UpdateShopCostItem()
		{
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				if (this._shopNewSpecialPriceControl != null)
				{
					this._shopNewSpecialPriceControl.UpdateCostItemListValueByNumber(this._curBuyNumber);
				}
				return;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._shopItemTable.CostItemID, true);
			int num = this._shopItemTable.CostNum;
			num = ShopNewUtility.GetRealCostValue(num, this._discountValue);
			int num2 = num * this._curBuyNumber;
			this.costNumberText.text = num2.ToString();
			this.costNumberText.color = ((ownedItemCount >= num2) ? DataManager<ShopNewDataManager>.GetInstance().specialColor : Color.red);
			this.UpdateShopNewOtherCostItemView();
		}

		// Token: 0x06010AA6 RID: 68262 RVA: 0x004B879C File Offset: 0x004B6B9C
		private void InitShopOldChangedNewItem()
		{
			this.comOldChangeNewItem.gameObject.CustomActive(this._isShowOldChangeNewFlag);
			if (this._isShowOldChangeNewFlag)
			{
				this.comOldChangeNewItem.SetItemId(this._shopItemTable.ID);
				this.selectedRoot.gameObject.CustomActive(false);
				this.OldChangeNewRoot.CustomActive(true);
			}
			else
			{
				this.selectedRoot.gameObject.CustomActive(true);
				this.OldChangeNewRoot.CustomActive(false);
			}
			if (!this._isShowOldChangeNewFlag)
			{
				return;
			}
			List<ulong> packageOldChangeNewEquip = DataManager<ShopNewDataManager>.GetInstance().GetPackageOldChangeNewEquip(this._shopItemTable.ID);
			if (packageOldChangeNewEquip == null || packageOldChangeNewEquip.Count <= 0)
			{
				this.oldItemNotExistNoticeText.gameObject.CustomActive(true);
				this.oldItemScrollView.gameObject.CustomActive(false);
			}
			else
			{
				this.oldItemNotExistNoticeText.gameObject.CustomActive(false);
				this.oldItemScrollView.gameObject.CustomActive(true);
				for (int i = 0; i < packageOldChangeNewEquip.Count; i++)
				{
					ulong num = packageOldChangeNewEquip[i];
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.oldItemPrefab);
						if (!(gameObject == null))
						{
							ShopNewPurchaseOldItem purchaseOldItem = gameObject.GetComponent<ShopNewPurchaseOldItem>();
							if (purchaseOldItem == null)
							{
								Object.Destroy(gameObject);
							}
							else
							{
								this._oldGameObjectList.Add(gameObject);
								Utility.AttachTo(gameObject, this.oldItemScrollViewContent, false);
								gameObject.CustomActive(true);
								ComItem comItem = ComItemManager.Create(purchaseOldItem.ItemParent);
								this._oldItemComItemList.Add(comItem);
								comItem.Setup(item, new ComItem.OnItemClicked(this.ShowOldItemTipFrame));
								purchaseOldItem.ItemGuid = num;
								purchaseOldItem.SelectedToggle.group = this.oldItemScrollViewGroup;
								purchaseOldItem.SelectedToggle.onValueChanged.RemoveAllListeners();
								purchaseOldItem.SelectedToggle.onValueChanged.AddListener(delegate(bool isOn)
								{
									this.OnToggleValueChanged(isOn, purchaseOldItem);
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x06010AA7 RID: 68263 RVA: 0x004B89DC File Offset: 0x004B6DDC
		private void OnToggleValueChanged(bool value, ShopNewPurchaseOldItem purchaseOldItem)
		{
			purchaseOldItem.SelectedFlag.gameObject.CustomActive(value);
			if (value)
			{
				this.UpdateConsumeItemGuid(new ItemInfo
				{
					uid = purchaseOldItem.ItemGuid,
					num = 1U
				});
			}
		}

		// Token: 0x06010AA8 RID: 68264 RVA: 0x004B8A20 File Offset: 0x004B6E20
		private void ShowOldItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x06010AA9 RID: 68265 RVA: 0x004B8A32 File Offset: 0x004B6E32
		private void UpdateConsumeItemGuid(ItemInfo itemInfo)
		{
			this._itemInfoList.Clear();
			this._itemInfoList.Add(itemInfo);
		}

		// Token: 0x06010AAA RID: 68266 RVA: 0x004B8A4B File Offset: 0x004B6E4B
		private void OnMinButtonClickCallBack()
		{
			this._curBuyNumber = 1;
			this.OnValueChanged();
		}

		// Token: 0x06010AAB RID: 68267 RVA: 0x004B8A5A File Offset: 0x004B6E5A
		private void OnMinusButtonClickCallBack()
		{
			this._curBuyNumber--;
			this.OnValueChanged();
		}

		// Token: 0x06010AAC RID: 68268 RVA: 0x004B8A70 File Offset: 0x004B6E70
		private void OnMaxButtonClickCallBack()
		{
			this._curBuyNumber = this._totalCanBuyNumber;
			this.OnValueChanged();
		}

		// Token: 0x06010AAD RID: 68269 RVA: 0x004B8A84 File Offset: 0x004B6E84
		private void OnAddButtonClickCallBack()
		{
			this._curBuyNumber++;
			this.OnValueChanged();
		}

		// Token: 0x06010AAE RID: 68270 RVA: 0x004B8A9C File Offset: 0x004B6E9C
		private void OnInputFieldValueChanged(string value)
		{
			int curBuyNumber = 0;
			if (value.Length > 0)
			{
				curBuyNumber = int.Parse(value);
			}
			this._curBuyNumber = curBuyNumber;
			this.OnValueChanged();
		}

		// Token: 0x06010AAF RID: 68271 RVA: 0x004B8ACC File Offset: 0x004B6ECC
		private void OnValueChanged()
		{
			if (this._curBuyNumber < 1)
			{
				this._curBuyNumber = 1;
			}
			if (this._curBuyNumber > this._totalCanBuyNumber)
			{
				this._curBuyNumber = this._totalCanBuyNumber;
			}
			this.minusButton.enabled = (this._curBuyNumber > 1);
			this.minusButtonGray.enabled = !this.minusButton.enabled;
			this.minButton.enabled = (this._curBuyNumber > 1);
			this.minButtonGray.enabled = !this.minButton.enabled;
			this.addButton.enabled = (this._curBuyNumber < this._totalCanBuyNumber);
			this.addButtonGray.enabled = !this.addButton.enabled;
			this.maxButton.enabled = (this._curBuyNumber < this._totalCanBuyNumber);
			this.maxButtonGray.enabled = !this.maxButton.enabled;
			this.selectedCountInputField.text = this._curBuyNumber.ToString();
			if (this._totalCanBuyNumber > 1)
			{
				float num = (float)(this._curBuyNumber - 1) * 1f / (float)(this._totalCanBuyNumber - 1);
				if (this.selectedSlider.value != num)
				{
					this.selectedSlider.value = num;
				}
			}
			else if (this.selectedSlider.value != 1f)
			{
				this.selectedSlider.value = 1f;
			}
			this.UpdateShopCostItem();
		}

		// Token: 0x06010AB0 RID: 68272 RVA: 0x004B8C58 File Offset: 0x004B7058
		private void OnSelectedSliderChangeValue(float fValue)
		{
			int num = 0;
			if (int.TryParse(this.selectedCountInputField.text, out num))
			{
				if (this._totalCanBuyNumber <= 1)
				{
					if (fValue != 1f)
					{
						this.selectedSlider.value = 1f;
						return;
					}
					this.selectedCountInputField.text = 1.ToString();
					return;
				}
				else
				{
					int num2 = (int)(fValue / (1f / (float)(this._totalCanBuyNumber - 1)) + 0.5f) + 1;
					if (num2 < 1)
					{
						num2 = 1;
					}
					float num3 = (float)(num2 - 1) * 1f / (float)(this._totalCanBuyNumber - 1);
					if (num3 != fValue)
					{
						this.selectedSlider.value = num3;
						return;
					}
					if (num != num2)
					{
						this.selectedCountInputField.text = num2.ToString();
					}
				}
			}
		}

		// Token: 0x06010AB1 RID: 68273 RVA: 0x004B8D37 File Offset: 0x004B7137
		private void ShopItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x06010AB2 RID: 68274 RVA: 0x004B8D4C File Offset: 0x004B714C
		private void OnBuyButtonClickCallBack()
		{
			if (!this._isShowOldChangeNewFlag)
			{
				this.OnPurchaseShopItem();
			}
			else
			{
				ItemData itemData = new ItemData(0);
				if (DataManager<ShopNewDataManager>.GetInstance().IsPackageHaveExchangeEquipment(this._shopItemTable.ID, EPackageType.WearEquip, ref itemData) && DataManager<ShopNewDataManager>.GetInstance().IsPackageHaveExchangeEquipment(this._shopItemTable.ID, EPackageType.Equip, ref itemData))
				{
					this.OnPurchaseShopItem();
					return;
				}
				if (DataManager<ShopNewDataManager>.GetInstance().IsPackageHaveExchangeEquipment(this._shopItemTable.ID, EPackageType.WearEquip, ref itemData))
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_pack_wearequip_have_changeequipmaterials"), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (!DataManager<ShopNewDataManager>.GetInstance().IsPackageHaveExchangeEquipment(this._shopItemTable.ID, EPackageType.Equip, ref itemData))
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials", itemData.Name), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (this._itemInfoList == null || this._itemInfoList.Count <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_pack_Consum_Item"), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				this.OnPurchaseShopItem();
			}
		}

		// Token: 0x06010AB3 RID: 68275 RVA: 0x004B8E70 File Offset: 0x004B7270
		private void OnPurchaseShopItem()
		{
			int num = this._shopItemTable.CostNum;
			num = ShopNewUtility.GetRealCostValue(num, this._discountValue);
			int num2 = num * this._curBuyNumber;
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._costItemData.TableID, true);
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._costItemData.TableID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("OnPurchaseShopItem CostItemTable is null and costtItemTableId is {0}", new object[]
				{
					this._costItemData.TableID
				});
				return;
			}
			if (num2 > ownedItemCount)
			{
				if (!ItemComeLink.IsLinkMoney(this._costItemData.TableID, new ComLinkFrame.OnClick(this.OnCloseFrame), null))
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials"), this._costItemData.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
					ItemComeLink.OnLink(this._costItemData.TableID, 0, true, null, false, false, false, null, string.Empty);
				}
				return;
			}
			if (this._shopNewSecondCostItemId > 0 && this._shopNewSecondCostItemNumber > 0)
			{
				int realCostValue = ShopNewUtility.GetRealCostValue(this._shopNewSecondCostItemNumber, this._discountValue);
				int num3 = realCostValue * this._curBuyNumber;
				int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._shopNewSecondCostItemId, true);
				if (num3 > ownedItemCount2)
				{
					if (!ItemComeLink.IsLinkMoney(this._shopNewSecondCostItemId, new ComLinkFrame.OnClick(this.OnCloseFrame), null))
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._shopNewSecondCostItemId, string.Empty, string.Empty);
						if (tableItem != null)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials"), tableItem.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						ItemComeLink.OnLink(this._shopNewSecondCostItemId, 0, true, null, false, false, false, null, string.Empty);
					}
					return;
				}
			}
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				for (int i = 0; i < this._shopNewTotalCostItemDataModelList.Count; i++)
				{
					ShopNewCostItemDataModel shopNewCostItemDataModel = this._shopNewTotalCostItemDataModelList[i];
					if (shopNewCostItemDataModel != null)
					{
						int realCostValue2 = ShopNewUtility.GetRealCostValue(shopNewCostItemDataModel.CostItemNumber, this._discountValue);
						int num4 = realCostValue2 * this._curBuyNumber;
						int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(shopNewCostItemDataModel.CostItemId, true);
						if (num4 > ownedItemCount3)
						{
							if (!ItemComeLink.IsLinkMoney(shopNewCostItemDataModel.CostItemId, new ComLinkFrame.OnClick(this.OnCloseFrame), null))
							{
								ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(shopNewCostItemDataModel.CostItemId, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials"), tableItem2.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
								}
								ItemComeLink.OnLink(shopNewCostItemDataModel.CostItemId, 0, true, null, false, false, false, null, string.Empty);
							}
							return;
						}
					}
				}
			}
			if (this._curBuyNumber <= 0)
			{
				return;
			}
			CostItemManager.CostInfo a_costInfo = new CostItemManager.CostInfo
			{
				nMoneyID = this._costItemData.TableID,
				nCount = num2
			};
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(a_costInfo, new Action(this.OnPurchaseShopItemAction), "common_money_cost", null);
		}

		// Token: 0x06010AB4 RID: 68276 RVA: 0x004B9190 File Offset: 0x004B7590
		private void OnPurchaseShopItemAction()
		{
			DataManager<ShopNewDataManager>.GetInstance().BuyGoods(this._shopNewShopItemTable.ShopId, this._shopNewShopItemTable.ShopItemId, this._curBuyNumber, this._itemInfoList);
			this.OnCloseFrame();
		}

		// Token: 0x06010AB5 RID: 68277 RVA: 0x004B91C4 File Offset: 0x004B75C4
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewPurchaseItemFrame>(null, false);
		}

		// Token: 0x06010AB6 RID: 68278 RVA: 0x004B91D2 File Offset: 0x004B75D2
		private void ResetShopNewCostItemData()
		{
			this._shopNewSecondCostItemNumber = 0;
			this._shopNewSecondCostItemId = 0;
			this._shopNewTotalCostItemDataModelList.Clear();
			this._shopNewSpecialPriceControl = null;
		}

		// Token: 0x06010AB7 RID: 68279 RVA: 0x004B91F4 File Offset: 0x004B75F4
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
			}
			else if (shopItemOtherCostItemDataModelList.Count > 1)
			{
				ShopNewCostItemDataModel shopNewCostItemDataModel2 = new ShopNewCostItemDataModel();
				shopNewCostItemDataModel2.CostItemId = this._shopItemTable.CostItemID;
				shopNewCostItemDataModel2.CostItemNumber = this._shopItemTable.CostNum;
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
			}
		}

		// Token: 0x06010AB8 RID: 68280 RVA: 0x004B9338 File Offset: 0x004B7738
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
			this.shopNewOtherCostItem.UpdateCostItemValueByBuyNumber(this._curBuyNumber);
		}

		// Token: 0x06010AB9 RID: 68281 RVA: 0x004B93C0 File Offset: 0x004B77C0
		private void UpdateShopNewOtherCostItemView()
		{
			if (this.shopNewOtherCostItem == null)
			{
				return;
			}
			if (this._shopNewSecondCostItemId <= 0 || this._shopNewSecondCostItemNumber <= 0)
			{
				return;
			}
			this.shopNewOtherCostItem.UpdateCostItemValueByBuyNumber(this._curBuyNumber);
		}

		// Token: 0x06010ABA RID: 68282 RVA: 0x004B9400 File Offset: 0x004B7800
		private void OnAddNewItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null && this.IsCostItemData(item.TableID))
				{
					this.OnCostItemNumberChanged();
					break;
				}
			}
		}

		// Token: 0x06010ABB RID: 68283 RVA: 0x004B945D File Offset: 0x004B785D
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (this.IsCostItemData(itemData.TableID))
			{
				this.OnCostItemNumberChanged();
				return;
			}
		}

		// Token: 0x06010ABC RID: 68284 RVA: 0x004B9480 File Offset: 0x004B7880
		private void OnUpdateItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null)
				{
					if (this.IsCostItemData(item.TableID))
					{
						this.OnCostItemNumberChanged();
						break;
					}
				}
			}
		}

		// Token: 0x06010ABD RID: 68285 RVA: 0x004B94E2 File Offset: 0x004B78E2
		private void OnCostItemNumberChanged()
		{
			this.UpdateTotalBuyNumber();
			this.OnValueChanged();
		}

		// Token: 0x06010ABE RID: 68286 RVA: 0x004B94F0 File Offset: 0x004B78F0
		private void UpdateTotalBuyNumber()
		{
			ItemTable itemTable = null;
			if (this._costItemData != null && this._shopItemTable != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._costItemData.TableID, true);
				int num = this._shopItemTable.CostNum;
				num = ShopNewUtility.GetRealCostValue(num, this._discountValue);
				if (num <= 0)
				{
					Logger.LogErrorFormat("InitShopData CostItem CostNumber is Invalid and costItemId is {0}", new object[]
					{
						this._shopItemTable.CostItemID
					});
					return;
				}
				itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._shopItemTable.ItemID, string.Empty, string.Empty);
				if (itemTable == null)
				{
					Logger.LogErrorFormat("itemTable is null and itemId is {0}", new object[]
					{
						this._shopItemTable.ItemID
					});
					return;
				}
				this._totalCanBuyNumber = ownedItemCount / num;
			}
			if (this._shopNewSecondCostItemId > 0 && this._shopNewSecondCostItemNumber > 0)
			{
				int num2 = ShopNewUtility.ShopNewBuyItemNumberByOtherCostItem(this._shopNewSecondCostItemId, this._shopNewSecondCostItemNumber, this._discountValue);
				this._totalCanBuyNumber = ((this._totalCanBuyNumber <= num2) ? this._totalCanBuyNumber : num2);
			}
			if (this._shopNewTotalCostItemDataModelList != null && this._shopNewTotalCostItemDataModelList.Count > 0)
			{
				for (int i = 0; i < this._shopNewTotalCostItemDataModelList.Count; i++)
				{
					ShopNewCostItemDataModel shopNewCostItemDataModel = this._shopNewTotalCostItemDataModelList[i];
					if (shopNewCostItemDataModel != null)
					{
						int num3 = ShopNewUtility.ShopNewBuyItemNumberByOtherCostItem(shopNewCostItemDataModel.CostItemId, shopNewCostItemDataModel.CostItemNumber, this._discountValue);
						this._totalCanBuyNumber = ((this._totalCanBuyNumber <= num3) ? this._totalCanBuyNumber : num3);
					}
				}
			}
			if (itemTable != null)
			{
				this._totalCanBuyNumber = ((itemTable.MaxNum >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : itemTable.MaxNum);
			}
			if (this._shopNewShopItemTable != null)
			{
				int limitBuyTimes = this._shopNewShopItemTable.LimitBuyTimes;
				if (limitBuyTimes >= 0)
				{
					this._totalCanBuyNumber = ((limitBuyTimes >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : limitBuyTimes);
				}
			}
			if (this._shopItemTable != null && this._shopItemTable.BuyLimit > 0 && this._totalCanBuyNumber > this._shopItemTable.BuyLimit)
			{
				this._totalCanBuyNumber = this._shopItemTable.BuyLimit;
			}
			if (this._totalCanBuyNumber < 1)
			{
				this._totalCanBuyNumber = 1;
			}
		}

		// Token: 0x06010ABF RID: 68287 RVA: 0x004B9764 File Offset: 0x004B7B64
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
				return false;
			}
			return this._costItemData != null && (this._costItemData.TableID == itemId || (this._shopNewSecondCostItemId > 0 && this._shopNewSecondCostItemId == itemId));
		}

		// Token: 0x0400AA39 RID: 43577
		private ShopNewShopItemTable _shopNewShopItemTable;

		// Token: 0x0400AA3A RID: 43578
		private ShopItemTable _shopItemTable;

		// Token: 0x0400AA3B RID: 43579
		private ComItem _comItem;

		// Token: 0x0400AA3C RID: 43580
		private ItemData _costItemData;

		// Token: 0x0400AA3D RID: 43581
		private bool _isShowOldChangeNewFlag;

		// Token: 0x0400AA3E RID: 43582
		private int _curBuyNumber = 1;

		// Token: 0x0400AA3F RID: 43583
		private int _totalCanBuyNumber = 1;

		// Token: 0x0400AA40 RID: 43584
		private List<GameObject> _oldGameObjectList = new List<GameObject>();

		// Token: 0x0400AA41 RID: 43585
		private List<ComItem> _oldItemComItemList = new List<ComItem>();

		// Token: 0x0400AA42 RID: 43586
		private List<ItemInfo> _itemInfoList = new List<ItemInfo>();

		// Token: 0x0400AA43 RID: 43587
		private int _shopNewSecondCostItemId;

		// Token: 0x0400AA44 RID: 43588
		private int _shopNewSecondCostItemNumber;

		// Token: 0x0400AA45 RID: 43589
		private List<ShopNewCostItemDataModel> _shopNewTotalCostItemDataModelList = new List<ShopNewCostItemDataModel>();

		// Token: 0x0400AA46 RID: 43590
		private ShopNewSpecialPriceControl _shopNewSpecialPriceControl;

		// Token: 0x0400AA47 RID: 43591
		private int _discountValue;

		// Token: 0x0400AA48 RID: 43592
		[Space(10f)]
		[Header("Close")]
		[SerializeField]
		private Text purchaseItemTitle;

		// Token: 0x0400AA49 RID: 43593
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400AA4A RID: 43594
		[Space(10f)]
		[Header("Item")]
		[SerializeField]
		private Text buyItemName;

		// Token: 0x0400AA4B RID: 43595
		[SerializeField]
		private GameObject buyItemRoot;

		// Token: 0x0400AA4C RID: 43596
		[SerializeField]
		private GameObject buyItemDiscountRoot;

		// Token: 0x0400AA4D RID: 43597
		[SerializeField]
		private Text buyItemDiscountText;

		// Token: 0x0400AA4E RID: 43598
		[SerializeField]
		private Text buyItemDescriptionText;

		// Token: 0x0400AA4F RID: 43599
		[Space(15f)]
		[Header("Cost")]
		[SerializeField]
		private Text costTitle;

		// Token: 0x0400AA50 RID: 43600
		[SerializeField]
		private Image costIcon;

		// Token: 0x0400AA51 RID: 43601
		[SerializeField]
		private Text costNameText;

		// Token: 0x0400AA52 RID: 43602
		[SerializeField]
		private Text costNumberText;

		// Token: 0x0400AA53 RID: 43603
		[SerializeField]
		private ComOldChangeNewItem comOldChangeNewItem;

		// Token: 0x0400AA54 RID: 43604
		[Space(15f)]
		[Header("ShopNewOtherCostItem")]
		[Space(10f)]
		[SerializeField]
		private ShopNewCostItem shopNewOtherCostItem;

		// Token: 0x0400AA55 RID: 43605
		[SerializeField]
		private GameObject normalPriceRoot;

		// Token: 0x0400AA56 RID: 43606
		[Space(20f)]
		[Header("ShopNewSpecialPriceRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject specialPriceRoot;

		// Token: 0x0400AA57 RID: 43607
		[SerializeField]
		private string specialPriceControlPath = "UIFlatten/Prefabs/ShopNew/Control/SpecialCostPriceControl";

		// Token: 0x0400AA58 RID: 43608
		[Space(15f)]
		[Header("Selected")]
		[SerializeField]
		private GameObject selectedRoot;

		// Token: 0x0400AA59 RID: 43609
		[SerializeField]
		private Text leftItemNumberText;

		// Token: 0x0400AA5A RID: 43610
		[SerializeField]
		private Button minButton;

		// Token: 0x0400AA5B RID: 43611
		[SerializeField]
		private UIGray minButtonGray;

		// Token: 0x0400AA5C RID: 43612
		[SerializeField]
		private Button minusButton;

		// Token: 0x0400AA5D RID: 43613
		[SerializeField]
		private UIGray minusButtonGray;

		// Token: 0x0400AA5E RID: 43614
		[SerializeField]
		private Button addButton;

		// Token: 0x0400AA5F RID: 43615
		[SerializeField]
		private UIGray addButtonGray;

		// Token: 0x0400AA60 RID: 43616
		[SerializeField]
		private Button maxButton;

		// Token: 0x0400AA61 RID: 43617
		[SerializeField]
		private UIGray maxButtonGray;

		// Token: 0x0400AA62 RID: 43618
		[SerializeField]
		private Slider selectedSlider;

		// Token: 0x0400AA63 RID: 43619
		[SerializeField]
		private InputField selectedCountInputField;

		// Token: 0x0400AA64 RID: 43620
		[Space(15f)]
		[Header("OldChangeNew")]
		[SerializeField]
		private GameObject OldChangeNewRoot;

		// Token: 0x0400AA65 RID: 43621
		[SerializeField]
		private GameObject oldItemScrollView;

		// Token: 0x0400AA66 RID: 43622
		[SerializeField]
		private GameObject oldItemScrollViewContent;

		// Token: 0x0400AA67 RID: 43623
		[SerializeField]
		private ToggleGroup oldItemScrollViewGroup;

		// Token: 0x0400AA68 RID: 43624
		[SerializeField]
		private GameObject oldItemPrefab;

		// Token: 0x0400AA69 RID: 43625
		[SerializeField]
		private GameObject oldItemNotExistNoticeText;

		// Token: 0x0400AA6A RID: 43626
		[Space(15f)]
		[Header("BuyButton")]
		[SerializeField]
		private Button buyButton;

		// Token: 0x0400AA6B RID: 43627
		[SerializeField]
		private Text buyButtonText;
	}
}

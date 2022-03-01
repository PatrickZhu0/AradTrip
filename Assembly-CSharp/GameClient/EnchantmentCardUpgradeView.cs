using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AFD RID: 6909
	internal class EnchantmentCardUpgradeView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010F2B RID: 69419 RVA: 0x004D70E4 File Offset: 0x004D54E4
		private void Awake()
		{
			this.InitEnchantmentCardUIList();
			this.UpdateGoldCoinItem(this.iBindGoldCoinID);
			if (this.mBtnConsumGoldCoinLink != null)
			{
				this.mBtnConsumGoldCoinLink.onClick.RemoveAllListeners();
				this.mBtnConsumGoldCoinLink.onClick.AddListener(delegate()
				{
					ItemComeLink.OnLink(this.iCurrentGoldCoinID, 0, true, null, false, false, false, null, string.Empty);
				});
			}
			if (this.mOpenViceCardFrameBtn != null)
			{
				this.mOpenViceCardFrameBtn.onClick.RemoveAllListeners();
				this.mOpenViceCardFrameBtn.onClick.AddListener(new UnityAction(this.OpenEnchantmentCardViceCardFrame));
			}
			if (this.mUpgradeEnchantmentCardBtn != null)
			{
				this.mUpgradeEnchantmentCardBtn.onClick.RemoveAllListeners();
				this.mUpgradeEnchantmentCardBtn.onClick.AddListener(delegate()
				{
					if (this.mUpgradeEnchantmentCardBtn != null)
					{
						this.mUpgradeEnchantmentCardBtn.enabled = false;
					}
					InvokeMethod.Invoke(0.5f, delegate()
					{
						if (this.mUpgradeEnchantmentCardBtn != null)
						{
							this.mUpgradeEnchantmentCardBtn.enabled = true;
						}
					});
					this.OnUpgradeEnchantmentCardClick();
				});
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEnchantmentCardUpgradeRetun, new ClientEventSystem.UIEventHandler(this.OnEnchantmentCardUpgradeRetun));
			this.RegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010F2C RID: 69420 RVA: 0x004D7204 File Offset: 0x004D5604
		private void OnDestroy()
		{
			this.UnInitEnchantmentCardUIList();
			this.mEnchantmentCardItems.Clear();
			this.mEnchantmentCardViceCardItems.Clear();
			this.mLinkData = null;
			this.mConsumGoldCoinItem = null;
			this.iCurrentGoldCoinID = 0;
			this.bIsRefreshViceCardInfo = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEnchantmentCardUpgradeRetun, new ClientEventSystem.UIEventHandler(this.OnEnchantmentCardUpgradeRetun));
			this.UnRegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010F2D RID: 69421 RVA: 0x004D7290 File Offset: 0x004D5690
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
		}

		// Token: 0x06010F2E RID: 69422 RVA: 0x004D72B8 File Offset: 0x004D56B8
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
		}

		// Token: 0x06010F2F RID: 69423 RVA: 0x004D72E0 File Offset: 0x004D56E0
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(items[i]);
				if (itemData.SubType == 25)
				{
					this.LoadAllEnchantmentCardItems(false, false);
					break;
				}
			}
		}

		// Token: 0x06010F30 RID: 69424 RVA: 0x004D7335 File Offset: 0x004D5735
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD || eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_GOLD)
			{
				this.UpdateGoldCoinItemInfo(this.mCurrentSelectEnchantmentCardItem);
			}
		}

		// Token: 0x06010F31 RID: 69425 RVA: 0x004D7350 File Offset: 0x004D5750
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.mLinkData = linkData;
			this.LoadAllEnchantmentCardItems(true, true);
		}

		// Token: 0x06010F32 RID: 69426 RVA: 0x004D7361 File Offset: 0x004D5761
		public void OnEnableView()
		{
			this.RegisterDelegateHandler();
			this.LoadAllEnchantmentCardItems(true, true);
		}

		// Token: 0x06010F33 RID: 69427 RVA: 0x004D7371 File Offset: 0x004D5771
		public void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06010F34 RID: 69428 RVA: 0x004D737C File Offset: 0x004D577C
		private void OnEnchantmentCardUpgradeRetun(UIEvent uiEvent)
		{
			EnchantmentCardUpgradeSuccessData enchantmentCardUpgradeSuccessData = uiEvent.Param1 as EnchantmentCardUpgradeSuccessData;
			if (enchantmentCardUpgradeSuccessData != null)
			{
				if (this.mCurrentSelectEnchantmentCardItem != null)
				{
					List<EnchantmentCardViceCardData> list = new List<EnchantmentCardViceCardData>();
					if (this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(enchantmentCardUpgradeSuccessData.mEquipGUID);
						if (item != null)
						{
							this.mCurrentSelectEnchantmentCardItem.mEquipItemData = item;
							list = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardViceCardDatas(this.mCurrentSelectEnchantmentCardItem.mEquipItemData, this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType);
						}
						else
						{
							list = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardViceCardDatas(this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData, this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType);
						}
					}
					else
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(enchantmentCardUpgradeSuccessData.mEnchantmentCardGUID);
						if (item2 != null)
						{
							this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData = item2;
						}
						list = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardViceCardDatas(this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData, this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType);
					}
					bool flag = false;
					int index = 0;
					for (int i = 0; i < list.Count; i++)
					{
						if (this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData == null || this.mCureentSelectEnchantmentCardViceCardItem == null)
						{
							break;
						}
						index = i;
						EnchantmentCardViceCardData enchantmentCardViceCardData = list[i];
						if (enchantmentCardViceCardData.mViceCardItemData.GUID == this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.GUID)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						this.mCureentSelectEnchantmentCardViceCardItem = list[index];
					}
					else if (this.mCureentSelectEnchantmentCardViceCardItem != null)
					{
						this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData = null;
					}
				}
				if (this.mEnchantmentCardUIList != null)
				{
					this.mEnchantmentCardUIList.ResetSelectedElementIndex();
				}
				this.LoadAllEnchantmentCardItems(true, false);
			}
		}

		// Token: 0x06010F35 RID: 69429 RVA: 0x004D7544 File Offset: 0x004D5944
		private bool CheckEnchantmentCardBindType()
		{
			bool result = false;
			if (this.mCurrentSelectEnchantmentCardItem == null || this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData == null || this.mCureentSelectEnchantmentCardViceCardItem == null || this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData == null)
			{
				return false;
			}
			if (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.BindAttr == ItemTable.eOwner.ROLEBIND || (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.BindAttr == ItemTable.eOwner.NOTBIND && this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.BindAttr == ItemTable.eOwner.NOTBIND) || this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted)
			{
				return false;
			}
			if (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.BindAttr != this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.BindAttr || (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.BindAttr == ItemTable.eOwner.ACCBIND && this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.BindAttr == ItemTable.eOwner.ACCBIND))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06010F36 RID: 69430 RVA: 0x004D7634 File Offset: 0x004D5A34
		private string GetBindDesc(ItemTable.eOwner ower)
		{
			string result = string.Empty;
			switch (ower)
			{
			case ItemTable.eOwner.Owner_None:
			case ItemTable.eOwner.NOTBIND:
				result = "非绑定";
				break;
			case ItemTable.eOwner.ROLEBIND:
				result = "角色绑定";
				break;
			case ItemTable.eOwner.ACCBIND:
				result = "账号绑定";
				break;
			}
			return result;
		}

		// Token: 0x06010F37 RID: 69431 RVA: 0x004D768C File Offset: 0x004D5A8C
		private void OpenEnchantmentCardViceCardFrame()
		{
			ViceCardDataModel viceCardDataModel = new ViceCardDataModel();
			viceCardDataModel.mCurrentEnchantmentCardItemData = ((this.mCurrentSelectEnchantmentCardItem != null) ? this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData : null);
			viceCardDataModel.mUpgradePrecType = ((this.mCurrentSelectEnchantmentCardItem != null) ? this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType : UpgradePrecType.UnMounted);
			ViceCardDataModel viceCardDataModel2 = viceCardDataModel;
			viceCardDataModel2.mOnEnchantmentCardViceCardClick = (OnEnchantmentCardViceCardClick)Delegate.Combine(viceCardDataModel2.mOnEnchantmentCardViceCardClick, new OnEnchantmentCardViceCardClick(this.UpdateViceCardItemInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EnchantmentCardViceCardFrame>(FrameLayer.Middle, viceCardDataModel, string.Empty);
		}

		// Token: 0x06010F38 RID: 69432 RVA: 0x004D7717 File Offset: 0x004D5B17
		private void OnViceCardItemClick()
		{
			this.OpenEnchantmentCardViceCardFrame();
		}

		// Token: 0x06010F39 RID: 69433 RVA: 0x004D7720 File Offset: 0x004D5B20
		private void UpdateViceCardItemInfo(EnchantmentCardViceCardData viceCardData)
		{
			if (viceCardData == null)
			{
				return;
			}
			this.mCureentSelectEnchantmentCardViceCardItem = viceCardData;
			if (this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData != null)
			{
				ItemData mViceCardItemData = this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData;
				if (this.mViceCardLevel != null)
				{
					if (mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
					{
						this.mViceCardLevel.text = string.Format(this.sLevelDesc, mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel);
					}
					else
					{
						this.mViceCardLevel.text = string.Empty;
					}
				}
				if (this.mViceCardBg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mViceCardBg, mViceCardItemData.GetQualityInfo().Background, true);
				}
				if (this.mViceCardIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mViceCardIcon, mViceCardItemData.Icon, true);
				}
				if (this.mViceCardBtn != null)
				{
					this.mViceCardBtn.onClick.RemoveAllListeners();
					this.mViceCardBtn.onClick.AddListener(new UnityAction(this.OnViceCardItemClick));
				}
				if (this.mSuccessRateDesc != null)
				{
					this.mSuccessRateDesc.text = string.Format(this.sSuccessRateDesc, DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardProbabilityDesc(this.mCureentSelectEnchantmentCardViceCardItem.mAllSuccessRate));
				}
				if (this.mViceCardCount != null)
				{
					if (this.mCureentSelectEnchantmentCardViceCardItem.mViceCardCount >= this.mCureentSelectEnchantmentCardViceCardItem.mConsumViceCardCount)
					{
						this.mViceCardCount.text = TR.Value("enchantmentCard_green", this.mCureentSelectEnchantmentCardViceCardItem.mViceCardCount, this.mCureentSelectEnchantmentCardViceCardItem.mConsumViceCardCount);
					}
					else
					{
						this.mViceCardCount.text = TR.Value("enchantmentCard_red", this.mCureentSelectEnchantmentCardViceCardItem.mViceCardCount, this.mCureentSelectEnchantmentCardViceCardItem.mConsumViceCardCount);
					}
				}
				this.mSelectViceCardStateControl.Key = this.sSelected;
			}
			else
			{
				this.mSelectViceCardStateControl.Key = this.sUnSelected;
			}
		}

		// Token: 0x06010F3A RID: 69434 RVA: 0x004D793C File Offset: 0x004D5D3C
		private void UpdateGoldCoinItem(int coinID)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(coinID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (this.mConsumGoldCoinItem == null)
			{
				this.mConsumGoldCoinItem = ComItemManager.Create(this.mGoldCoinItemParent);
			}
			if (this.mConsumGoldCoinItem != null)
			{
				ComItem comItem = this.mConsumGoldCoinItem;
				ItemData item = itemData;
				if (EnchantmentCardUpgradeView.<>f__mg$cache0 == null)
				{
					EnchantmentCardUpgradeView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, EnchantmentCardUpgradeView.<>f__mg$cache0);
			}
		}

		// Token: 0x06010F3B RID: 69435 RVA: 0x004D79B8 File Offset: 0x004D5DB8
		private void UpdateGoldCoinItemInfo(EnchantmentCardItemDataModel enchatmentCardItemData)
		{
			if (enchatmentCardItemData == null || enchatmentCardItemData.mConsumableMaterialData == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(enchatmentCardItemData.mConsumableMaterialData.ItemID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			int count = enchatmentCardItemData.mConsumableMaterialData.Count;
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemData.TableID, true);
			if (this.mConsumGoldCoinNum != null)
			{
				this.mConsumGoldCoinNum.text = count.ToString();
				if (ownedItemCount < count && count > 0)
				{
					this.mConsumGoldCoinNum.color = Color.red;
				}
				else
				{
					this.mConsumGoldCoinNum.color = Color.white;
				}
			}
			this.iCurrentGoldCoinID = itemData.TableID;
			this.UpdateGoldCoinItem(this.iCurrentGoldCoinID);
			this.mGoConsumGoldCoinLink.gameObject.CustomActive(ownedItemCount < count && count > 0);
		}

		// Token: 0x06010F3C RID: 69436 RVA: 0x004D7AA4 File Offset: 0x004D5EA4
		private void UpdateEnchantmentCardItem(EnchantmentCardItemDataModel enchatmentCardItemData)
		{
			if (enchatmentCardItemData == null)
			{
				return;
			}
			ItemData itemData = enchatmentCardItemData.mEnchantmentCardItemData;
			this.mItemParent.CustomActive(true);
			if (this.mEnchantmentCardBg != null)
			{
				ETCImageLoader.LoadSprite(ref this.mEnchantmentCardBg, itemData.GetQualityInfo().Background, true);
			}
			if (this.mEnchantmentCardIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mEnchantmentCardIcon, itemData.Icon, true);
			}
			if (this.mEnchantmentCardBtn != null)
			{
				this.mEnchantmentCardBtn.onClick.RemoveAllListeners();
				this.mEnchantmentCardBtn.onClick.AddListener(delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				});
			}
			if (this.mEnchantmentCardName != null)
			{
				this.mEnchantmentCardName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.mEnchantmentCardLevel != null)
			{
				if (itemData.mPrecEnchantmentCard.iEnchantmentCardLevel > 0)
				{
					this.mEnchantmentCardLevel.text = string.Format(this.sLevelDesc, itemData.mPrecEnchantmentCard.iEnchantmentCardLevel);
				}
				else
				{
					this.mEnchantmentCardLevel.text = string.Empty;
				}
			}
			if (this.mLevelIsFullStateControl != null)
			{
				bool flag = DataManager<EnchantmentsCardManager>.GetInstance().CheckEnchantmentCardLevelIsFull(enchatmentCardItemData);
				if (flag)
				{
					this.mLevelIsFullStateControl.Key = this.sFullLevel;
					this.SetViceCardItemData();
				}
				else
				{
					this.mLevelIsFullStateControl.Key = this.sNoFullLevel;
				}
			}
			if (itemData.mPrecEnchantmentCard != null)
			{
				if (this.mCurrentArrt != null)
				{
					this.mCurrentArrt.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(itemData.mPrecEnchantmentCard.iEnchantmentCardID, itemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
				}
				if (this.mNextLevelArrt != null)
				{
					this.mNextLevelArrt.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(itemData.mPrecEnchantmentCard.iEnchantmentCardID, itemData.mPrecEnchantmentCard.iEnchantmentCardLevel + 1, false);
				}
			}
		}

		// Token: 0x06010F3D RID: 69437 RVA: 0x004D7CF0 File Offset: 0x004D60F0
		private void InitEnchantmentCardUIList()
		{
			if (this.mEnchantmentCardUIList != null)
			{
				this.mEnchantmentCardUIList.Initialize();
				ComUIListScript comUIListScript = this.mEnchantmentCardUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEnchantmentCardUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEnchantmentCardUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEnchantmentCardUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010F3E RID: 69438 RVA: 0x004D7DB8 File Offset: 0x004D61B8
		private void UnInitEnchantmentCardUIList()
		{
			if (this.mEnchantmentCardUIList != null)
			{
				ComUIListScript comUIListScript = this.mEnchantmentCardUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEnchantmentCardUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEnchantmentCardUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEnchantmentCardUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010F3F RID: 69439 RVA: 0x004D7E72 File Offset: 0x004D6272
		private EnchantmentCardItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EnchantmentCardItem>();
		}

		// Token: 0x06010F40 RID: 69440 RVA: 0x004D7E7C File Offset: 0x004D627C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EnchantmentCardItem enchantmentCardItem = item.gameObjectBindScript as EnchantmentCardItem;
			if (enchantmentCardItem != null && item.m_index >= 0 && item.m_index < this.mEnchantmentCardItems.Count)
			{
				enchantmentCardItem.OnItemVisiable(this.mEnchantmentCardItems[item.m_index], new OnEnchantmentCardItemClick(this.OnEnchantmentCardItemClick));
			}
		}

		// Token: 0x06010F41 RID: 69441 RVA: 0x004D7EE8 File Offset: 0x004D62E8
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EnchantmentCardItem enchantmentCardItem = item.gameObjectBindScript as EnchantmentCardItem;
			if (enchantmentCardItem != null)
			{
				enchantmentCardItem.OnSelectEnchantmentCardItemClick();
			}
		}

		// Token: 0x06010F42 RID: 69442 RVA: 0x004D7F14 File Offset: 0x004D6314
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			EnchantmentCardItem enchantmentCardItem = item.gameObjectBindScript as EnchantmentCardItem;
			if (enchantmentCardItem != null)
			{
				enchantmentCardItem.OnEnchantmentCardItemChageDisplay(bSelected);
			}
		}

		// Token: 0x06010F43 RID: 69443 RVA: 0x004D7F40 File Offset: 0x004D6340
		private void OnEnchantmentCardItemClick(EnchantmentCardItemDataModel enchantmentCardItemDataModel)
		{
			if (enchantmentCardItemDataModel == null || enchantmentCardItemDataModel.mEnchantmentCardItemData == null)
			{
				return;
			}
			if (this.mCurrentSelectEnchantmentCardItem != null && this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData != null)
			{
				if (this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted && enchantmentCardItemDataModel.mUpgradePrecType == UpgradePrecType.Mounted)
				{
					if (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.TableID != enchantmentCardItemDataModel.mEnchantmentCardItemData.TableID)
					{
						this.SetViceCardItemData();
					}
					else if (this.mCurrentSelectEnchantmentCardItem.mEquipItemData != null && enchantmentCardItemDataModel.mEquipItemData != null && this.mCurrentSelectEnchantmentCardItem.mEquipItemData.GUID != enchantmentCardItemDataModel.mEquipItemData.GUID)
					{
						this.SetViceCardItemData();
					}
				}
				else if (this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType == UpgradePrecType.UnMounted && enchantmentCardItemDataModel.mUpgradePrecType == UpgradePrecType.UnMounted)
				{
					if (this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.GUID != enchantmentCardItemDataModel.mEnchantmentCardItemData.GUID)
					{
						this.SetViceCardItemData();
					}
				}
				else if (this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType != enchantmentCardItemDataModel.mUpgradePrecType)
				{
					this.SetViceCardItemData();
				}
			}
			if (this.bIsRefreshViceCardInfo)
			{
				this.SetViceCardItemData();
				this.bIsRefreshViceCardInfo = false;
			}
			this.mCurrentSelectEnchantmentCardItem = enchantmentCardItemDataModel;
			this.SetIsOnlyUseSameCardStateContrl(this.mCurrentSelectEnchantmentCardItem);
			this.UpdateEnchantmentCardItem(this.mCurrentSelectEnchantmentCardItem);
			this.UpdateGoldCoinItemInfo(this.mCurrentSelectEnchantmentCardItem);
			this.UpdateViceCardItemInfo(this.mCureentSelectEnchantmentCardViceCardItem);
		}

		// Token: 0x06010F44 RID: 69444 RVA: 0x004D80B9 File Offset: 0x004D64B9
		private void SetViceCardItemData()
		{
			if (this.mCureentSelectEnchantmentCardViceCardItem != null)
			{
				this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData = null;
			}
		}

		// Token: 0x06010F45 RID: 69445 RVA: 0x004D80D4 File Offset: 0x004D64D4
		private void SetIsOnlyUseSameCardStateContrl(EnchantmentCardItemDataModel enchatmentCardItemData)
		{
			if (enchatmentCardItemData == null || enchatmentCardItemData.mEnchantmentCardItemData == null)
			{
				return;
			}
			bool flag = DataManager<EnchantmentsCardManager>.GetInstance().CheckMainEnchantmentCardIsOnlyUseSameCard(enchatmentCardItemData.mEnchantmentCardItemData);
			if (this.mIsOnlyUseSameCardStateContrl != null)
			{
				this.mIsOnlyUseSameCardStateContrl.Key = ((!flag) ? "Normal" : "SameNameCard");
			}
		}

		// Token: 0x06010F46 RID: 69446 RVA: 0x004D8138 File Offset: 0x004D6538
		public void LoadAllEnchantmentCardItems(bool isDefaultSelectCard = true, bool isRefreshViceCardInfo = false)
		{
			this.bIsDefaultSelectCard = isDefaultSelectCard;
			this.bIsRefreshViceCardInfo = isRefreshViceCardInfo;
			if (this.mEnchantmentCardItems != null)
			{
				this.mEnchantmentCardItems.Clear();
			}
			List<EnchantmentCardItemDataModel> collection = DataManager<EnchantmentsCardManager>.GetInstance().LoadEnchantmentCardItems();
			this.mEnchantmentCardItems.AddRange(collection);
			if (this.mEnchantmentCardUIList != null)
			{
				this.mEnchantmentCardUIList.SetElementAmount(this.mEnchantmentCardItems.Count);
			}
			if (this.mEnchantmentCardItems.Count <= 0 && this.mLevelIsFullStateControl != null)
			{
				this.mLevelIsFullStateControl.Key = this.sNoEnchantmentCard;
			}
			if (this.bIsDefaultSelectCard)
			{
				this.TryDefultSelectEnchantmentCardItem();
			}
		}

		// Token: 0x06010F47 RID: 69447 RVA: 0x004D81EC File Offset: 0x004D65EC
		private void TryDefultSelectEnchantmentCardItem()
		{
			int selectedItem = -1;
			bool flag = false;
			if (this.mLinkData != null)
			{
				if (this.mLinkData.itemData != null)
				{
					this.TrySelectedItem(this.mLinkData.itemData.GUID);
				}
				this.mLinkData = null;
				return;
			}
			if (this.mCurrentSelectEnchantmentCardItem != null && this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData != null)
			{
				for (int i = 0; i < this.mEnchantmentCardItems.Count; i++)
				{
					if (this.mCurrentSelectEnchantmentCardItem.mUpgradePrecType == UpgradePrecType.Mounted)
					{
						if (this.mCurrentSelectEnchantmentCardItem.mEquipItemData != null)
						{
							if (this.mEnchantmentCardItems[i].mEquipItemData != null)
							{
								if (this.mEnchantmentCardItems[i].mEquipItemData.GUID == this.mCurrentSelectEnchantmentCardItem.mEquipItemData.GUID)
								{
									selectedItem = i;
									flag = true;
									break;
								}
							}
						}
					}
					else if (this.mEnchantmentCardItems[i].mEnchantmentCardItemData.GUID == this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.GUID)
					{
						selectedItem = i;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					selectedItem = 0;
				}
			}
			else if (this.mEnchantmentCardItems.Count > 0)
			{
				selectedItem = 0;
			}
			this.SetSelectedItem(selectedItem);
		}

		// Token: 0x06010F48 RID: 69448 RVA: 0x004D8344 File Offset: 0x004D6744
		private void TrySelectedItem(ulong GUID)
		{
			int selectedItem = 0;
			for (int i = 0; i < this.mEnchantmentCardItems.Count; i++)
			{
				if (this.mEnchantmentCardItems[i].mEnchantmentCardItemData.GUID == GUID)
				{
					selectedItem = i;
					break;
				}
			}
			this.SetSelectedItem(selectedItem);
		}

		// Token: 0x06010F49 RID: 69449 RVA: 0x004D83A0 File Offset: 0x004D67A0
		private void SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex < 0 || this.mEnchantmentCardItems.Count < 0)
			{
				return;
			}
			if (iBindIndex >= 0 && iBindIndex < this.mEnchantmentCardItems.Count)
			{
				if (this.mEnchantmentCardUIList != null)
				{
					if (!this.mEnchantmentCardUIList.IsElementInScrollArea(iBindIndex))
					{
						this.mEnchantmentCardUIList.EnsureElementVisable(iBindIndex);
					}
					this.mEnchantmentCardUIList.SelectElement(iBindIndex, true);
					this.OnEnchantmentCardItemClick(this.mEnchantmentCardItems[iBindIndex]);
				}
			}
			else
			{
				this.mEnchantmentCardUIList.SelectElement(-1, true);
			}
		}

		// Token: 0x06010F4A RID: 69450 RVA: 0x004D8440 File Offset: 0x004D6840
		private void OnUpgradeEnchantmentCardClick()
		{
			if (this.mCureentSelectEnchantmentCardViceCardItem == null || this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请放入材料附魔卡", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			bool flag = DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Consumable);
			if (flag)
			{
				SystemNotifyManager.SysNotifyTextAnimation("背包已满，无法升级附魔卡", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.Quality >= ItemTable.eColor.PINK && !DataManager<EnchantmentsCardManager>.GetInstance().IsShowQualityTip)
			{
				this.OpenComMsgBoxOkCancelFrame(new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("enchantmentCard_QualityDesc"),
					IsShowNotify = true,
					OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateQualityIsShow),
					LeftButtonText = TR.Value("common_data_cancel"),
					RightButtonText = TR.Value("common_data_sure_2"),
					OnRightButtonClickCallBack = new Action(this.ExecuteUpgradeLogic)
				});
				return;
			}
			if (this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.mPrecEnchantmentCard.iEnchantmentCardLevel >= 1 && this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.Quality < ItemTable.eColor.PINK && !DataManager<EnchantmentsCardManager>.GetInstance().IsShowLevelTip)
			{
				this.OpenComMsgBoxOkCancelFrame(new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("enchantmentCard_LevelDesc"),
					IsShowNotify = true,
					OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateLevelIsShow),
					LeftButtonText = TR.Value("common_data_cancel"),
					RightButtonText = TR.Value("common_data_sure_2"),
					OnRightButtonClickCallBack = new Action(this.ExecuteUpgradeLogic)
				});
				return;
			}
			this.ExecuteUpgradeLogic();
		}

		// Token: 0x06010F4B RID: 69451 RVA: 0x004D85D0 File Offset: 0x004D69D0
		private void ExecuteUpgradeLogic()
		{
			if (this.mCurrentSelectEnchantmentCardItem.mConsumableMaterialData == null)
			{
				if (this.mCurrentSelectEnchantmentCardItem.mEquipItemData != null && this.mCurrentSelectEnchantmentCardItem.mEquipItemData.mPrecEnchantmentCard != null)
				{
					Logger.LogErrorFormat("EnchantmentCardUpgradeView [ExecuteUpgradeLogic] mCurrentSelectEnchantmentCardItem.mConsumableMaterialData = null, EnchantmentCardId = {0} EnchantmentCardLevel = {1}", new object[]
					{
						this.mCurrentSelectEnchantmentCardItem.mEquipItemData.mPrecEnchantmentCard.iEnchantmentCardID,
						this.mCurrentSelectEnchantmentCardItem.mEquipItemData.mPrecEnchantmentCard.iEnchantmentCardLevel
					});
				}
				return;
			}
			int count = this.mCurrentSelectEnchantmentCardItem.mConsumableMaterialData.Count;
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mCurrentSelectEnchantmentCardItem.mConsumableMaterialData.ItemID, true);
			if (ownedItemCount < count)
			{
				SystemNotifyManager.SysNotifyTextAnimation("绑定金币不足", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iGoldCoinID, false);
			int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iBindGoldCoinID, false);
			if (DataManager<EnchantmentsCardManager>.GetInstance().IsNotShowGoldCoinTip || ownedItemCount3 >= count)
			{
				this.OnEnchantmentCardUpgradeCheck();
			}
			else
			{
				this.OpenComMsgBoxOkCancelFrame(new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("enchantmentCard_goldCoinDesc", ownedItemCount3, count - ownedItemCount3),
					IsShowNotify = true,
					OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateGoldCoinTipIsShow),
					LeftButtonText = TR.Value("common_data_cancel"),
					RightButtonText = TR.Value("common_data_sure_2"),
					OnRightButtonClickCallBack = new Action(this.OnEnchantmentCardUpgradeCheck)
				});
			}
		}

		// Token: 0x06010F4C RID: 69452 RVA: 0x004D8760 File Offset: 0x004D6B60
		private void OnEnchantmentCardUpgradeCheck()
		{
			if (this.CheckEnchantmentCardBindType() && !DataManager<EnchantmentsCardManager>.GetInstance().IsShowBindTip)
			{
				this.OpenComMsgBoxOkCancelFrame(new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("enchantmentCard_UpgradeDesc", this.GetBindDesc(this.mCurrentSelectEnchantmentCardItem.mEnchantmentCardItemData.BindAttr), this.GetBindDesc(this.mCureentSelectEnchantmentCardViceCardItem.mViceCardItemData.BindAttr)),
					IsShowNotify = true,
					OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnUpdateBindTipIsShow),
					LeftButtonText = TR.Value("common_data_cancel"),
					RightButtonText = TR.Value("common_data_sure_2"),
					OnRightButtonClickCallBack = new Action(this.OnSceneMagicCardUpgradeReq)
				});
			}
			else
			{
				this.OnSceneMagicCardUpgradeReq();
			}
		}

		// Token: 0x06010F4D RID: 69453 RVA: 0x004D8826 File Offset: 0x004D6C26
		private void OnSceneMagicCardUpgradeReq()
		{
			DataManager<EnchantmentsCardManager>.GetInstance().OnSceneMagicCardUpgradeReq(this.mCurrentSelectEnchantmentCardItem, this.mCureentSelectEnchantmentCardViceCardItem);
		}

		// Token: 0x06010F4E RID: 69454 RVA: 0x004D883E File Offset: 0x004D6C3E
		private void OnUpdateGoldCoinTipIsShow(bool value)
		{
			DataManager<EnchantmentsCardManager>.GetInstance().IsNotShowGoldCoinTip = value;
		}

		// Token: 0x06010F4F RID: 69455 RVA: 0x004D884B File Offset: 0x004D6C4B
		private void OnUpdateBindTipIsShow(bool value)
		{
			DataManager<EnchantmentsCardManager>.GetInstance().IsShowBindTip = value;
		}

		// Token: 0x06010F50 RID: 69456 RVA: 0x004D8858 File Offset: 0x004D6C58
		private void OnUpdateQualityIsShow(bool value)
		{
			DataManager<EnchantmentsCardManager>.GetInstance().IsShowQualityTip = value;
		}

		// Token: 0x06010F51 RID: 69457 RVA: 0x004D8865 File Offset: 0x004D6C65
		private void OnUpdateLevelIsShow(bool value)
		{
			DataManager<EnchantmentsCardManager>.GetInstance().IsShowLevelTip = value;
		}

		// Token: 0x06010F52 RID: 69458 RVA: 0x004D8872 File Offset: 0x004D6C72
		private void OpenComMsgBoxOkCancelFrame(CommonMsgBoxOkCancelNewParamData paramData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMsgBoxOkCancelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewMsgBoxOkCancelFrame>(FrameLayer.High, paramData, string.Empty);
		}

		// Token: 0x0400AE3A RID: 44602
		[SerializeField]
		private ComUIListScript mEnchantmentCardUIList;

		// Token: 0x0400AE3B RID: 44603
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400AE3C RID: 44604
		[SerializeField]
		private GameObject mGoldCoinItemParent;

		// Token: 0x0400AE3D RID: 44605
		[SerializeField]
		private GameObject mGoConsumGoldCoinLink;

		// Token: 0x0400AE3E RID: 44606
		[SerializeField]
		private Image mEnchantmentCardBg;

		// Token: 0x0400AE3F RID: 44607
		[SerializeField]
		private Image mEnchantmentCardIcon;

		// Token: 0x0400AE40 RID: 44608
		[SerializeField]
		private Image mViceCardBg;

		// Token: 0x0400AE41 RID: 44609
		[SerializeField]
		private Image mViceCardIcon;

		// Token: 0x0400AE42 RID: 44610
		[SerializeField]
		private Button mEnchantmentCardBtn;

		// Token: 0x0400AE43 RID: 44611
		[SerializeField]
		private Button mViceCardBtn;

		// Token: 0x0400AE44 RID: 44612
		[SerializeField]
		private Button mBtnConsumGoldCoinLink;

		// Token: 0x0400AE45 RID: 44613
		[SerializeField]
		private Text mEnchantmentCardName;

		// Token: 0x0400AE46 RID: 44614
		[SerializeField]
		private Text mConsumGoldCoinNum;

		// Token: 0x0400AE47 RID: 44615
		[SerializeField]
		private Text mEnchantmentCardLevel;

		// Token: 0x0400AE48 RID: 44616
		[SerializeField]
		private Text mViceCardLevel;

		// Token: 0x0400AE49 RID: 44617
		[SerializeField]
		private Text mCurrentArrt;

		// Token: 0x0400AE4A RID: 44618
		[SerializeField]
		private Text mNextLevelArrt;

		// Token: 0x0400AE4B RID: 44619
		[SerializeField]
		private StateController mSelectViceCardStateControl;

		// Token: 0x0400AE4C RID: 44620
		[SerializeField]
		private StateController mLevelIsFullStateControl;

		// Token: 0x0400AE4D RID: 44621
		[SerializeField]
		private StateController mIsOnlyUseSameCardStateContrl;

		// Token: 0x0400AE4E RID: 44622
		[Header("ViceCard")]
		[SerializeField]
		private Button mOpenViceCardFrameBtn;

		// Token: 0x0400AE4F RID: 44623
		[SerializeField]
		private GameObject mViceCardParent;

		// Token: 0x0400AE50 RID: 44624
		[SerializeField]
		private Text mViceCardCount;

		// Token: 0x0400AE51 RID: 44625
		[SerializeField]
		private Text mSuccessRateDesc;

		// Token: 0x0400AE52 RID: 44626
		[SerializeField]
		private Button mUpgradeEnchantmentCardBtn;

		// Token: 0x0400AE53 RID: 44627
		[SerializeField]
		private UIGray mUpgradeEnchantmentCardGray;

		// Token: 0x0400AE54 RID: 44628
		[SerializeField]
		private string sUnSelected = "UnSelected";

		// Token: 0x0400AE55 RID: 44629
		[SerializeField]
		private string sSelected = "Selected";

		// Token: 0x0400AE56 RID: 44630
		[SerializeField]
		private string sNoFullLevel = "NoFullLevel";

		// Token: 0x0400AE57 RID: 44631
		[SerializeField]
		private string sFullLevel = "FullLevel";

		// Token: 0x0400AE58 RID: 44632
		[SerializeField]
		private string sNoEnchantmentCard = "NoEnchantmentCard";

		// Token: 0x0400AE59 RID: 44633
		[SerializeField]
		private string sLevelDesc = "+{0}";

		// Token: 0x0400AE5A RID: 44634
		[SerializeField]
		private int iGoldCoinID = 600000001;

		// Token: 0x0400AE5B RID: 44635
		[SerializeField]
		private int iBindGoldCoinID = 600000007;

		// Token: 0x0400AE5C RID: 44636
		[SerializeField]
		private string sSuccessRateDesc = "成功率:{0}";

		// Token: 0x0400AE5D RID: 44637
		private bool bIsDefaultSelectCard = true;

		// Token: 0x0400AE5E RID: 44638
		private bool bIsRefreshViceCardInfo;

		// Token: 0x0400AE5F RID: 44639
		private List<EnchantmentCardItemDataModel> mEnchantmentCardItems = new List<EnchantmentCardItemDataModel>();

		// Token: 0x0400AE60 RID: 44640
		private List<EnchantmentCardViceCardData> mEnchantmentCardViceCardItems = new List<EnchantmentCardViceCardData>();

		// Token: 0x0400AE61 RID: 44641
		private SmithShopNewLinkData mLinkData;

		// Token: 0x0400AE62 RID: 44642
		private EnchantmentCardItemDataModel mCurrentSelectEnchantmentCardItem;

		// Token: 0x0400AE63 RID: 44643
		private EnchantmentCardViceCardData mCureentSelectEnchantmentCardViceCardItem;

		// Token: 0x0400AE64 RID: 44644
		private ComItem mConsumGoldCoinItem;

		// Token: 0x0400AE65 RID: 44645
		private int iCurrentGoldCoinID;

		// Token: 0x0400AE66 RID: 44646
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

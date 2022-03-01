using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B6E RID: 7022
	internal class MagicView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06011344 RID: 70468 RVA: 0x004F3108 File Offset: 0x004F1508
		private void Awake()
		{
			this.RegisterUIEvent();
			if (this.mBtnAddMagic != null)
			{
				this.mBtnAddMagic.onClick.RemoveAllListeners();
				this.mBtnAddMagic.onClick.AddListener(new UnityAction(this.OnAddMagicClick));
			}
		}

		// Token: 0x06011345 RID: 70469 RVA: 0x004F3158 File Offset: 0x004F1558
		private void OnDestroy()
		{
			this.mPrecEnchantmentCard = null;
			this.mOnItemClick = null;
			this.mMCState = MagicCardState.None;
			this.mCanBeSetCardComItem = null;
			this.mHasBeenSetCardComItem = null;
			this.mReplaceNewCardComItem = null;
			this.mReplaceOldCardComItem = null;
			this.mComEnchantItem = null;
			this.mCurrentBeadCardItem = null;
			this.mToBeInlaidBeadItemData = null;
			this.m_kComEquipmentList.UnInitialize();
			this.m_kComMagicCardEnchantItemList.UnInitialize();
			this.data = null;
			this.UnRegisterUIEvent();
		}

		// Token: 0x06011346 RID: 70470 RVA: 0x004F31D0 File Offset: 0x004F15D0
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06011347 RID: 70471 RVA: 0x004F3250 File Offset: 0x004F1650
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06011348 RID: 70472 RVA: 0x004F32CF File Offset: 0x004F16CF
		private void RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAddMagicSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsEnchantChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEnchantCardSelected, new ClientEventSystem.UIEventHandler(this.OnEnchantCardSelected));
			this.RegisterDelegateHandler();
		}

		// Token: 0x06011349 RID: 70473 RVA: 0x004F330D File Offset: 0x004F170D
		private void UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAddMagicSuccess, new ClientEventSystem.UIEventHandler(this.OnSlotItemsEnchantChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEnchantCardSelected, new ClientEventSystem.UIEventHandler(this.OnEnchantCardSelected));
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x0601134A RID: 70474 RVA: 0x004F334C File Offset: 0x004F174C
		private void OnSlotItemsEnchantChanged(UIEvent uiEvent)
		{
			if (this.data.leftItem != null)
			{
				this.data.leftItem = null;
			}
			if (this.data.rightItem != null)
			{
				this.data.rightItem = DataManager<ItemDataManager>.GetInstance().GetItem(this.data.rightItem.GUID);
			}
			if (this.data.leftItem != null && this.data.rightItem != null && this.data.leftItem.GUID == this.data.rightItem.GUID && this.data.leftItem.Count < 2)
			{
				this.data.rightItem = null;
			}
			this.OnItemChanged(false, true);
			this.m_kComEquipmentList.RefreshAllEquipments();
		}

		// Token: 0x0601134B RID: 70475 RVA: 0x004F3424 File Offset: 0x004F1824
		private void OnEnchantCardSelected(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			this.OnEnchantCardChanged(itemData);
		}

		// Token: 0x0601134C RID: 70476 RVA: 0x004F3444 File Offset: 0x004F1844
		private void OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip))
					{
						flag = true;
					}
					if (!flag2 && this.m_kComMagicCardEnchantItemList.HasObject(item.GUID))
					{
						ItemData itemData = Utility._TryAddMagicCard(items[i].uid);
						if (itemData != null)
						{
							flag2 = true;
						}
					}
				}
			}
			if (flag)
			{
				this.m_kComEquipmentList.RefreshAllEquipments();
			}
			if (flag2)
			{
				this.m_kComMagicCardEnchantItemList.RefreshAllEquipments();
			}
		}

		// Token: 0x0601134D RID: 70477 RVA: 0x004F3518 File Offset: 0x004F1918
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			ComEquipment equipment = this.m_kComEquipmentList.GetEquipment(itemData.GUID);
			if (equipment != null)
			{
				this.m_kComEquipmentList.RefreshAllEquipments();
			}
			if (this.m_kComMagicCardEnchantItemList.HasObject(itemData.GUID))
			{
				this.m_kComMagicCardEnchantItemList.RefreshAllEquipments();
			}
		}

		// Token: 0x0601134E RID: 70478 RVA: 0x004F3578 File Offset: 0x004F1978
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] != null)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
					if (item != null && !flag && this.m_kComMagicCardEnchantItemList.HasObject(item.GUID))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				this.m_kComMagicCardEnchantItemList.RefreshAllEquipments();
			}
		}

		// Token: 0x0601134F RID: 70479 RVA: 0x004F3604 File Offset: 0x004F1A04
		public void InitView(SmithShopNewLinkData linkData)
		{
			if (this.m_kComMagicCardEnchantItemList != null)
			{
				this.m_kComMagicCardEnchantItemList.Initialize(this.mScrollView, new ComMagicCardEnchantItemList.OnItemSelected(this.OnEnchantCardChanged), linkData, this.data);
			}
			if (this.m_kComEquipmentList != null && !this.m_kComEquipmentList.Initilized)
			{
				this.m_kComEquipmentList.Initialize(this.mEquipScrollView, new EquipmentList.OnItemSelected(this.OnItemSelected), linkData);
			}
			this.SetDefaultAddMagicEquip();
		}

		// Token: 0x06011350 RID: 70480 RVA: 0x004F367F File Offset: 0x004F1A7F
		public void OnEnableView()
		{
			this.RegisterDelegateHandler();
			this.m_kComEquipmentList.RefreshAllEquipments();
		}

		// Token: 0x06011351 RID: 70481 RVA: 0x004F3692 File Offset: 0x004F1A92
		public void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x06011352 RID: 70482 RVA: 0x004F369C File Offset: 0x004F1A9C
		private void SetDefaultAddMagicEquip()
		{
			if (this.m_kComEquipmentList.Selected == null)
			{
				this.data.leftItem = null;
				this.data.rightItem = null;
			}
			else
			{
				this.data.rightItem = this.m_kComEquipmentList.Selected;
			}
			if (this.data.rightItem != null)
			{
				this.InitView(this.data.rightItem.mPrecEnchantmentCard, new Action(this.OnOpenEnchantCardsObjects));
				this.OnItemChanged(false, false);
			}
		}

		// Token: 0x06011353 RID: 70483 RVA: 0x004F3726 File Offset: 0x004F1B26
		private void OnOpenEnchantCardsObjects()
		{
			this.mEnchantCardsObjects.CustomActive(true);
		}

		// Token: 0x06011354 RID: 70484 RVA: 0x004F3734 File Offset: 0x004F1B34
		private void OnEnchantCardChanged(ItemData itemData)
		{
			this.data.leftItem = itemData;
			this.mEnchantCardsObjects.CustomActive(false);
			this.OnItemChanged(true, false);
		}

		// Token: 0x06011355 RID: 70485 RVA: 0x004F3756 File Offset: 0x004F1B56
		public void OnResetEnchantCard()
		{
			if (this.data.leftItem != null)
			{
				this.data.leftItem = null;
			}
		}

		// Token: 0x06011356 RID: 70486 RVA: 0x004F3774 File Offset: 0x004F1B74
		private void OnItemSelected(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.data.leftItem = null;
			this.data.rightItem = itemData;
			this.m_kComMagicCardEnchantItemList.ClearSelectedItem();
			this.m_kComMagicCardEnchantItemList.RefreshAllEquipments();
			this.OnItemChanged(false, false);
		}

		// Token: 0x06011357 RID: 70487 RVA: 0x004F37B4 File Offset: 0x004F1BB4
		private void OnItemChanged(bool isCheckHasBeenSet = false, bool isMagicSuccess = false)
		{
			if (this.data.leftItem != null && this.data.rightItem != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.data.leftItem.TableID, string.Empty, string.Empty);
				if (tableItem == null || !tableItem.Parts.Contains((int)this.data.rightItem.EquipWearSlotType))
				{
					this.data.leftItem = null;
				}
			}
			if (isCheckHasBeenSet && this.MagicStateIsHasBeenSet())
			{
				this.SetMagicState(MagicCardState.Replace, this.data.leftItem);
			}
			else if (isCheckHasBeenSet)
			{
				this.SetMagicState(MagicCardState.CanBeSet, this.data.leftItem);
			}
			else if (isMagicSuccess)
			{
				this.SetMagicState(MagicCardState.HasBeenSet, null);
			}
			else
			{
				this.RefreshMagicView(this.data.rightItem.mPrecEnchantmentCard);
			}
			this.m_kComMagicCardEnchantItemList.ClearSelectedItem();
			if (this.mComEnchantItem == null)
			{
				this.mComEnchantItem = ComItemManager.Create(this.mItemParent);
			}
			if (this.data.rightItem != null)
			{
				this.mComEnchantItem.Setup(this.data.rightItem, null);
			}
			else
			{
				this.mComEnchantItem.Setup(null, null);
			}
			this.CheckAddMagicLink();
		}

		// Token: 0x06011358 RID: 70488 RVA: 0x004F3912 File Offset: 0x004F1D12
		private void CheckAddMagicLink()
		{
			if (this.mAddMagicComeLink != null)
			{
				this.mAddMagicComeLink.CustomActive(!this.m_kComMagicCardEnchantItemList.HasEquipments());
			}
		}

		// Token: 0x06011359 RID: 70489 RVA: 0x004F3940 File Offset: 0x004F1D40
		public void InitView(PrecEnchantmentCard precEnchantmentCard, Action onClick)
		{
			if (precEnchantmentCard == null)
			{
				return;
			}
			this.mPrecEnchantmentCard = precEnchantmentCard;
			this.mOnItemClick = onClick;
			this.mCurrentBeadCardItem = ItemDataManager.CreateItemDataFromTable(this.mPrecEnchantmentCard.iEnchantmentCardID, 100, 0);
			if (this.mCurrentBeadCardItem != null)
			{
				this.mCurrentBeadCardItem.mPrecEnchantmentCard.iEnchantmentCardLevel = this.mPrecEnchantmentCard.iEnchantmentCardLevel;
			}
			if (this.mCurrentBeadCardItem != null)
			{
				this.SetMagicState(MagicCardState.HasBeenSet, null);
			}
			else
			{
				this.SetMagicState(MagicCardState.CanBeSet, null);
			}
		}

		// Token: 0x0601135A RID: 70490 RVA: 0x004F39C4 File Offset: 0x004F1DC4
		public void RefreshMagicView(PrecEnchantmentCard precEnchantmentCard)
		{
			if (precEnchantmentCard == null)
			{
				return;
			}
			this.mPrecEnchantmentCard = precEnchantmentCard;
			this.mCurrentBeadCardItem = ItemDataManager.CreateItemDataFromTable(this.mPrecEnchantmentCard.iEnchantmentCardID, 100, 0);
			if (this.mCurrentBeadCardItem != null)
			{
				this.mCurrentBeadCardItem.mPrecEnchantmentCard.iEnchantmentCardLevel = this.mPrecEnchantmentCard.iEnchantmentCardLevel;
			}
			if (this.mCurrentBeadCardItem != null)
			{
				this.SetMagicState(MagicCardState.HasBeenSet, null);
			}
			else
			{
				this.SetMagicState(MagicCardState.CanBeSet, null);
			}
		}

		// Token: 0x0601135B RID: 70491 RVA: 0x004F3A40 File Offset: 0x004F1E40
		public void UpdateMagicSteteControl()
		{
			switch (this.mMCState)
			{
			case MagicCardState.CanBeSet:
				this.mStateControl.Key = "CanBeSet";
				break;
			case MagicCardState.HasBeenSet:
				this.mStateControl.Key = "HasBeenSet";
				break;
			case MagicCardState.Replace:
				this.mStateControl.Key = "Replace";
				break;
			}
		}

		// Token: 0x0601135C RID: 70492 RVA: 0x004F3AB4 File Offset: 0x004F1EB4
		public void UpdateMagicInfo()
		{
			switch (this.mMCState)
			{
			case MagicCardState.CanBeSet:
				this.RefreshCanBeSetInfo();
				break;
			case MagicCardState.HasBeenSet:
				this.RefreshHasBeenSetInfo();
				break;
			case MagicCardState.Replace:
				this.RefreshReplaceInfo();
				break;
			}
		}

		// Token: 0x0601135D RID: 70493 RVA: 0x004F3B0C File Offset: 0x004F1F0C
		public void RefreshCanBeSetInfo()
		{
			this.mCanBeSetCardRoot.CustomActive(false);
			if (this.mCanBeSetCardComItem == null)
			{
				this.mCanBeSetCardComItem = ComItemManager.Create(this.mCanBeSetCardParent);
			}
			if (this.mToBeInlaidBeadItemData != null)
			{
				this.mCanBeSetCardRoot.CustomActive(true);
				this.mCanBeSetCardComItem.Setup(this.mToBeInlaidBeadItemData, new ComItem.OnItemClicked(this.OnMagicCardObjectItemClicked));
				this.mCanBeSetCardName.text = this.mToBeInlaidBeadItemData.GetColorName(string.Empty, false);
				this.mCanBeSetCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.mToBeInlaidBeadItemData.TableID, this.mToBeInlaidBeadItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
			else
			{
				this.mCanBeSetCardComItem.Setup(null, new ComItem.OnItemClicked(this.OnMagicCardObjectItemClicked));
			}
		}

		// Token: 0x0601135E RID: 70494 RVA: 0x004F3BE8 File Offset: 0x004F1FE8
		public void RefreshHasBeenSetInfo()
		{
			if (this.mCurrentBeadCardItem != null)
			{
				if (this.mHasBeenSetCardComItem == null)
				{
					this.mHasBeenSetCardComItem = ComItemManager.Create(this.mHasBeenSetCardParent);
				}
				this.mHasBeenSetCardComItem.Setup(this.mCurrentBeadCardItem, new ComItem.OnItemClicked(this.OnMagicCardObjectItemClicked));
				this.mHasBeenSetCardName.text = this.mCurrentBeadCardItem.GetColorName(string.Empty, false);
				this.mHasBeenSetCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.mCurrentBeadCardItem.TableID, this.mCurrentBeadCardItem.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
		}

		// Token: 0x0601135F RID: 70495 RVA: 0x004F3C8C File Offset: 0x004F208C
		public void RefreshReplaceInfo()
		{
			this.mReplaceCardRoot.CustomActive(true);
			if (this.mCurrentBeadCardItem != null && this.mCurrentBeadCardItem.mPrecEnchantmentCard != null)
			{
				if (this.mReplaceOldCardComItem == null)
				{
					this.mReplaceOldCardComItem = ComItemManager.Create(this.mReplaceRootOldCardCardParent);
				}
				ComItem comItem = this.mReplaceOldCardComItem;
				ItemData item = this.mCurrentBeadCardItem;
				if (MagicView.<>f__mg$cache0 == null)
				{
					MagicView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, MagicView.<>f__mg$cache0);
				this.mReplaceOldCardName.text = this.mCurrentBeadCardItem.GetColorName(string.Empty, false);
				this.mReplaceOldCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.mCurrentBeadCardItem.TableID, this.mCurrentBeadCardItem.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
			if (this.mToBeInlaidBeadItemData != null)
			{
				if (this.mReplaceNewCardComItem == null)
				{
					this.mReplaceNewCardComItem = ComItemManager.Create(this.mReplaceRootNewCardCardParnet);
				}
				this.mReplaceNewCardComItem.Setup(this.mToBeInlaidBeadItemData, new ComItem.OnItemClicked(this.OnMagicCardObjectItemClicked));
				this.mReplaceNewCardName.text = this.mToBeInlaidBeadItemData.GetColorName(string.Empty, false);
				this.mReplaceNewCardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.mToBeInlaidBeadItemData.TableID, this.mToBeInlaidBeadItemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			}
		}

		// Token: 0x06011360 RID: 70496 RVA: 0x004F3DF4 File Offset: 0x004F21F4
		public void SetMagicState(MagicCardState state, ItemData toBeInlaidBead = null)
		{
			this.mMCState = state;
			this.mToBeInlaidBeadItemData = toBeInlaidBead;
			this.UpdateMagicSteteControl();
			this.UpdateMagicInfo();
		}

		// Token: 0x06011361 RID: 70497 RVA: 0x004F3E10 File Offset: 0x004F2210
		private void OnMagicCardObjectItemClicked(GameObject obj, ItemData item)
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick();
			}
		}

		// Token: 0x06011362 RID: 70498 RVA: 0x004F3E28 File Offset: 0x004F2228
		public bool MagicStateIsHasBeenSet()
		{
			return this.mMCState == MagicCardState.HasBeenSet || this.mMCState == MagicCardState.Replace;
		}

		// Token: 0x06011363 RID: 70499 RVA: 0x004F3E44 File Offset: 0x004F2244
		private void OnAddMagicClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.data != null)
			{
				if (this.data.leftItem != null && this.data.rightItem != null && this.data.rightItem.mPrecEnchantmentCard != null)
				{
					MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.data.rightItem.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						AdjustResultFrame.AdjustResultFrameData adjustResultFrameData = new AdjustResultFrame.AdjustResultFrameData();
						AdjustResultFrame.AdjustResultFrameData adjustResultFrameData2 = adjustResultFrameData;
						adjustResultFrameData2.callback = (UnityAction)Delegate.Combine(adjustResultFrameData2.callback, new UnityAction(this.OnSendMosiacMagicCard));
						adjustResultFrameData.desc = string.Format("使用{0}\n替换\n{1}?", DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.data.leftItem.TableID, this.data.leftItem.mPrecEnchantmentCard.iEnchantmentCardLevel, false), DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(this.data.rightItem.mPrecEnchantmentCard.iEnchantmentCardID, this.data.rightItem.mPrecEnchantmentCard.iEnchantmentCardLevel, false));
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjustResultFrame>(FrameLayer.Middle, adjustResultFrameData, string.Empty);
					}
					else
					{
						this.OnSendMosiacMagicCard();
						if (this.mBtnAddMagic != null)
						{
							this.mBtnAddMagic.enabled = false;
							InvokeMethod.Invoke(this, 1f, delegate()
							{
								if (this.mBtnAddMagic != null)
								{
									this.mBtnAddMagic.enabled = true;
								}
							});
						}
					}
				}
				else if (this.data.rightItem == null)
				{
					SystemNotifyManager.SystemNotify(1069, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(1068, string.Empty);
				}
			}
		}

		// Token: 0x06011364 RID: 70500 RVA: 0x004F3FFC File Offset: 0x004F23FC
		private void OnSendMosiacMagicCard()
		{
			if (this.data == null)
			{
				return;
			}
			if (this.data.leftItem != null && this.data.rightItem != null)
			{
				DataManager<EnchantmentsCardManager>.GetInstance().SendAddMagic(this.data.leftItem.GUID, this.data.rightItem.GUID);
			}
			else
			{
				if (this.data.leftItem == null)
				{
					Logger.LogErrorFormat("SmithShopFrame [OnSendMosiacMagicCard] data.leftItem is Null", new object[0]);
				}
				if (this.data.rightItem == null)
				{
					Logger.LogErrorFormat("SmithShopFrame [OnSendMosiacMagicCard] data.rightItem is Null", new object[0]);
				}
			}
		}

		// Token: 0x0400B199 RID: 45465
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400B19A RID: 45466
		[SerializeField]
		private GameObject mCanBeSetCardRoot;

		// Token: 0x0400B19B RID: 45467
		[SerializeField]
		private GameObject mCanBeSetCardParent;

		// Token: 0x0400B19C RID: 45468
		[SerializeField]
		private GameObject mHasBeenSetCardParent;

		// Token: 0x0400B19D RID: 45469
		[SerializeField]
		private GameObject mReplaceCardRoot;

		// Token: 0x0400B19E RID: 45470
		[SerializeField]
		private GameObject mReplaceRootOldCardCardParent;

		// Token: 0x0400B19F RID: 45471
		[SerializeField]
		private GameObject mReplaceRootNewCardCardParnet;

		// Token: 0x0400B1A0 RID: 45472
		[SerializeField]
		private Text mCanBeSetCardName;

		// Token: 0x0400B1A1 RID: 45473
		[SerializeField]
		private Text mHasBeenSetCardName;

		// Token: 0x0400B1A2 RID: 45474
		[SerializeField]
		private Text mReplaceOldCardName;

		// Token: 0x0400B1A3 RID: 45475
		[SerializeField]
		private Text mReplaceNewCardName;

		// Token: 0x0400B1A4 RID: 45476
		[SerializeField]
		private Text mCanBeSetCardAttr;

		// Token: 0x0400B1A5 RID: 45477
		[SerializeField]
		private Text mHasBeenSetCardAttr;

		// Token: 0x0400B1A6 RID: 45478
		[SerializeField]
		private Text mReplaceOldCardAttr;

		// Token: 0x0400B1A7 RID: 45479
		[SerializeField]
		private Text mReplaceNewCardAttr;

		// Token: 0x0400B1A8 RID: 45480
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B1A9 RID: 45481
		[SerializeField]
		private GameObject mAddMagicComeLink;

		// Token: 0x0400B1AA RID: 45482
		[SerializeField]
		private GameObject mEnchantCardsObjects;

		// Token: 0x0400B1AB RID: 45483
		[SerializeField]
		private GameObject mScrollView;

		// Token: 0x0400B1AC RID: 45484
		[SerializeField]
		private GameObject mEquipScrollView;

		// Token: 0x0400B1AD RID: 45485
		[SerializeField]
		private Button mBtnAddMagic;

		// Token: 0x0400B1AE RID: 45486
		private ComMagicCardEnchantItemList m_kComMagicCardEnchantItemList = new ComMagicCardEnchantItemList();

		// Token: 0x0400B1AF RID: 45487
		private EquipmentList m_kComEquipmentList = new EquipmentList();

		// Token: 0x0400B1B0 RID: 45488
		private EnchantmentsFunctionData data = new EnchantmentsFunctionData();

		// Token: 0x0400B1B1 RID: 45489
		private PrecEnchantmentCard mPrecEnchantmentCard;

		// Token: 0x0400B1B2 RID: 45490
		private Action mOnItemClick;

		// Token: 0x0400B1B3 RID: 45491
		private MagicCardState mMCState;

		// Token: 0x0400B1B4 RID: 45492
		private ComItem mCanBeSetCardComItem;

		// Token: 0x0400B1B5 RID: 45493
		private ComItem mHasBeenSetCardComItem;

		// Token: 0x0400B1B6 RID: 45494
		private ComItem mReplaceNewCardComItem;

		// Token: 0x0400B1B7 RID: 45495
		private ComItem mReplaceOldCardComItem;

		// Token: 0x0400B1B8 RID: 45496
		private ComItem mComEnchantItem;

		// Token: 0x0400B1B9 RID: 45497
		private ItemData mCurrentBeadCardItem;

		// Token: 0x0400B1BA RID: 45498
		private ItemData mToBeInlaidBeadItemData;

		// Token: 0x0400B1BB RID: 45499
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

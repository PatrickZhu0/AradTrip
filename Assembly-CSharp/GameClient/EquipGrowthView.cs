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
	// Token: 0x02001B75 RID: 7029
	internal class EquipGrowthView : StrengthGrowthBaseView
	{
		// Token: 0x17001D9E RID: 7582
		// (get) Token: 0x06011387 RID: 70535 RVA: 0x004F470C File Offset: 0x004F2B0C
		public static ItemData CurrentSelectItemData
		{
			get
			{
				return EquipGrowthView.mCurrentSelectItemData;
			}
		}

		// Token: 0x06011388 RID: 70536 RVA: 0x004F4714 File Offset: 0x004F2B14
		public sealed override void IniteData(SmithShopNewLinkData linkData, StrengthenGrowthType type, StrengthenGrowthView strengthenGrowthView)
		{
			this.mLinkData = linkData;
			this.mStrengthenGrowthType = type;
			this.mStrengthenGrowthView = strengthenGrowthView;
			if (linkData != null && linkData.iDefaultFirstTabId == 1 && linkData.iDefaultSecondTabId == 0 && linkData.iSmithShopNewOpenTypeId == 1)
			{
				this.mFilter1.isOn = true;
			}
			else
			{
				this.mFilter0.isOn = true;
			}
			this.CreatComitem();
			this.InitGrowthProtectStampBGAndIcon();
			this.mSelectEquipStateContrl.Key = "NoEquip";
			if (this.mStrengthenDeviceItem != null)
			{
				this.mStrengthenDeviceItem.InitItem(StrengthenGrowthType.SGT_Gtowth, new OnStrengthenDeviceItem(this.OnStrengthenDeviceItem));
			}
		}

		// Token: 0x06011389 RID: 70537 RVA: 0x004F47C1 File Offset: 0x004F2BC1
		public sealed override void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x0601138A RID: 70538 RVA: 0x004F47C9 File Offset: 0x004F2BC9
		public sealed override void OnEnableView()
		{
			this.RegisterDelegateHandler();
		}

		// Token: 0x0601138B RID: 70539 RVA: 0x004F47D4 File Offset: 0x004F2BD4
		private void InitGrowthProtectStampBGAndIcon()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(300000207, 100, 0);
			if (itemData != null)
			{
				if (this.mGrowthProtectStampIconBg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mGrowthProtectStampIconBg, itemData.GetQualityInfo().Background, true);
				}
				if (this.mGrowthProtectStampIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mGrowthProtectStampIcon, itemData.Icon, true);
				}
			}
		}

		// Token: 0x0601138C RID: 70540 RVA: 0x004F4844 File Offset: 0x004F2C44
		private void CreatComitem()
		{
			if (this.mEquipItem == null)
			{
				this.mEquipItem = ComItemManager.Create(this.mEquipItemParent);
			}
			if (this.mGrowthStampComItem == null)
			{
				this.mGrowthStampComItem = ComItemManager.Create(this.mCouponParent);
			}
			this.mEquipItem.Setup(null, null);
			this.mGrowthStampComItem.Setup(null, null);
		}

		// Token: 0x0601138D RID: 70541 RVA: 0x004F48B0 File Offset: 0x004F2CB0
		private void ClearData()
		{
			this.mLinkData = null;
			this.mStrengthenGrowthType = StrengthenGrowthType.SGT_Strengthen;
			this.mStrengthenGrowthView = null;
			this.iMinGrowthLevel = 0;
			this.iGrowthNextLevel = 0;
			this.iLastGrowTargetLevel = 0;
			this.mEquipItem = null;
			this.mIsUseProtectStamp = false;
			if (this.mItemGrowthAttrA != null)
			{
				this.mItemGrowthAttrA.Clear();
			}
			if (this.mItemGrowthAttrB != null)
			{
				this.mItemGrowthAttrB.Clear();
			}
			if (this.mGrowthCosts != null)
			{
				this.mGrowthCosts.Clear();
			}
			if (this.m_akData != null)
			{
				this.m_akData.Clear();
			}
			if (this.mGrowthStampList != null)
			{
				this.mGrowthStampList.Clear();
			}
			EquipGrowthView.mCurrentSelectItemData = null;
			this.mGrowthStampItemData = null;
			this.mGrowthStampComItem = null;
			this.mGrowthDeviceItemData = null;
		}

		// Token: 0x0601138E RID: 70542 RVA: 0x004F4980 File Offset: 0x004F2D80
		private void Awake()
		{
			this.RegisterUIEventHandle();
			this.InitAttributesUIList();
			this.InitCostMaterialUIListScript();
			if (this.mFilter0 != null)
			{
				this.mFilter0.onValueChanged.RemoveAllListeners();
				this.mFilter0.onValueChanged.AddListener(delegate(bool value)
				{
					if (value)
					{
						this.iLastGrowTargetLevel = 0;
						if (this.mBottomRoot != null)
						{
							this.mBottomRoot.CustomActive(true);
						}
						if (this.mProtectedContentRoot != null)
						{
							this.mProtectedContentRoot.CustomActive(false);
						}
						this.OnStrengthenGrowthEquipItemClick(EquipGrowthView.mCurrentSelectItemData, this.mStrengthenGrowthType);
					}
				});
			}
			if (this.mFilter1 != null)
			{
				this.mFilter1.onValueChanged.RemoveAllListeners();
				this.mFilter1.onValueChanged.AddListener(delegate(bool value)
				{
					if (value)
					{
						if (this.mBottomRoot != null)
						{
							this.mBottomRoot.CustomActive(false);
						}
						if (this.mProtectedContentRoot != null)
						{
							this.mProtectedContentRoot.CustomActive(true);
						}
					}
				});
			}
			if (this.mProtectStampToggle != null)
			{
				this.mProtectStampToggle.onValueChanged.RemoveAllListeners();
				this.mProtectStampToggle.onValueChanged.AddListener(delegate(bool value)
				{
					this.mIsUseProtectStamp = value;
					if (value)
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000207, true);
						if (ownedItemCount <= 0)
						{
							ItemComeLink.OnLink(300000207, 0, false, null, false, false, false, null, string.Empty);
							this.mProtectStampToggle.isOn = false;
							this.mIsUseProtectStamp = false;
							return;
						}
						if (this.mGrowthProtectStateController != null)
						{
							this.mGrowthProtectStateController.Key = "UseProtected";
						}
					}
					else if (this.mGrowthProtectStateController != null)
					{
						this.mGrowthProtectStateController.Key = "UnUseProtected";
					}
				});
			}
			if (this.mGrowthImplementToggle != null)
			{
				this.mGrowthImplementToggle.onValueChanged.RemoveAllListeners();
				this.mGrowthImplementToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnGrowthImplementClick));
			}
			if (this.mInputGrowthLevelBtn != null)
			{
				this.mInputGrowthLevelBtn.onClick.RemoveAllListeners();
				this.mInputGrowthLevelBtn.onClick.AddListener(delegate()
				{
					CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(288f, -85f, 0f), 0UL, 10UL);
				});
			}
			if (this.mGrowthBtn != null)
			{
				this.mGrowthBtn.onClick.RemoveAllListeners();
				this.mGrowthBtn.onClick.AddListener(new UnityAction(this.OnGrowthClick));
			}
			if (this.mStopBtn != null)
			{
				this.mStopBtn.onClick.RemoveAllListeners();
				this.mStopBtn.onClick.AddListener(new UnityAction(this.OnClickStop));
			}
			if (this.mGrowthProtectedStampItemComLinkBtn != null)
			{
				this.mGrowthProtectedStampItemComLinkBtn.onClick.RemoveAllListeners();
				this.mGrowthProtectedStampItemComLinkBtn.onClick.AddListener(new UnityAction(this.OnGrowthProtectedStampItemComLinkClick));
			}
			if (this.mGrowthSpecialBtn != null)
			{
				this.mGrowthSpecialBtn.onClick.RemoveAllListeners();
				this.mGrowthSpecialBtn.onClick.AddListener(new UnityAction(this.OnGrowthSpecialBtnClick));
			}
			if (this.mGrowthProtectedStampItemBtn != null)
			{
				this.mGrowthProtectedStampItemBtn.onClick.RemoveAllListeners();
				this.mGrowthProtectedStampItemBtn.onClick.AddListener(delegate()
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(300000207, 100, 0);
					if (itemData != null)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					}
				});
			}
			if (this.mGrowthStampBtn != null)
			{
				this.mGrowthStampBtn.onClick.RemoveAllListeners();
				this.mGrowthStampBtn.onClick.AddListener(new UnityAction(this.OnOpenExpendFrameBtnClick));
			}
		}

		// Token: 0x0601138F RID: 70543 RVA: 0x004F4C60 File Offset: 0x004F3060
		private void OnOpenExpendFrameBtnClick()
		{
			List<ItemData> growthStampList = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthStampList(EquipGrowthView.mCurrentSelectItemData);
			if (growthStampList.Count > 0)
			{
				GrowthExpendData growthExpendData = new GrowthExpendData();
				growthExpendData.mStrengthenGrowthType = this.mStrengthenGrowthType;
				growthExpendData.mEquipItemData = EquipGrowthView.mCurrentSelectItemData;
				growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.OnGrowthStampItemClick);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GrowthExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
			}
			else
			{
				ItemComeLink.OnLink(245, 0, true, null, false, false, false, null, string.Empty);
			}
		}

		// Token: 0x06011390 RID: 70544 RVA: 0x004F4CE5 File Offset: 0x004F30E5
		private void OnGrowthStampItemClick(ItemData itemData)
		{
			this.OnGrowthStampClcik(itemData);
		}

		// Token: 0x06011391 RID: 70545 RVA: 0x004F4CF0 File Offset: 0x004F30F0
		private void OnGrowthSpecialBtnClick()
		{
			if (this.bOnStart)
			{
				return;
			}
			if (EquipGrowthView.mCurrentSelectItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("growth_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mGrowthStampItemData == null)
			{
				List<ItemData> growthStampList = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthStampList(EquipGrowthView.mCurrentSelectItemData);
				if (growthStampList != null)
				{
					if (growthStampList.Count > 0)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("growth_special_need_protected"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					else
					{
						this.mCouponLink.bNotEnough = false;
						this.mCouponLink.OnClickLink();
						this.mCouponLink.bNotEnough = false;
					}
				}
				return;
			}
			int num;
			bool flag;
			this.mGrowthStampItemData.GetLimitTimeLeft(out num, out flag);
			if (num <= 0 && flag)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			StrengthenSpecialConfirmFrameData userData = new StrengthenSpecialConfirmFrameData
			{
				equipData = EquipGrowthView.mCurrentSelectItemData,
				itemData = this.mGrowthStampItemData
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenSpecialConfirmFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x06011392 RID: 70546 RVA: 0x004F4DEC File Offset: 0x004F31EC
		private void OnDestroy()
		{
			this.ClearData();
			this.UnRegisterUIEventHandle();
			this.UnInitAttributesUIList();
			this.UnInitCostMaterialUIListScript();
		}

		// Token: 0x06011393 RID: 70547 RVA: 0x004F4E08 File Offset: 0x004F3208
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06011394 RID: 70548 RVA: 0x004F4E88 File Offset: 0x004F3288
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06011395 RID: 70549 RVA: 0x004F4F08 File Offset: 0x004F3308
		private void RegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BeginContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnStartContinueGrowth));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EndContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnEndContinueGrowth));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthChanged, new ClientEventSystem.UIEventHandler(this.OnGrowthChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StrengthenDelay, new ClientEventSystem.UIEventHandler(this.OnGrowthDelay));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.IntterruptContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnInterruptContinueGrowth));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StrengthenCanceled, new ClientEventSystem.UIEventHandler(this.GrowthCanceled));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemGrowthSuccess, new ClientEventSystem.UIEventHandler(this.OnItemGrowthSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemGrowthFail, new ClientEventSystem.UIEventHandler(this.OnItemGrowthFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailStrenghthenStart, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailStrenghthenCanceled, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthCanceled));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailGrowthFailed, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenError, new ClientEventSystem.UIEventHandler(this.OnGrowthError));
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Combine(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
			this.RegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06011396 RID: 70550 RVA: 0x004F50DC File Offset: 0x004F34DC
		private void UnRegisterUIEventHandle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BeginContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnStartContinueGrowth));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EndContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnEndContinueGrowth));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthChanged, new ClientEventSystem.UIEventHandler(this.OnGrowthChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StrengthenDelay, new ClientEventSystem.UIEventHandler(this.OnGrowthDelay));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.IntterruptContineStrengthen, new ClientEventSystem.UIEventHandler(this.OnInterruptContinueGrowth));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StrengthenCanceled, new ClientEventSystem.UIEventHandler(this.GrowthCanceled));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemGrowthSuccess, new ClientEventSystem.UIEventHandler(this.OnItemGrowthSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemGrowthFail, new ClientEventSystem.UIEventHandler(this.OnItemGrowthFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailStrenghthenStart, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailStrenghthenCanceled, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthCanceled));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailGrowthFailed, new ClientEventSystem.UIEventHandler(this.OnSpecailGrowthFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenError, new ClientEventSystem.UIEventHandler(this.OnGrowthError));
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Remove(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
			this.UnRegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06011397 RID: 70551 RVA: 0x004F52B0 File Offset: 0x004F36B0
		private void OnAddNewItem(List<Item> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip))
					{
						flag = true;
					}
					this.TryUpdateMaterial(item.TableID);
				}
			}
			if (flag)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x06011398 RID: 70552 RVA: 0x004F533C File Offset: 0x004F373C
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] != null)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
					if (item != null)
					{
						this.TryUpdateMaterial(item.TableID);
					}
				}
			}
		}

		// Token: 0x06011399 RID: 70553 RVA: 0x004F53A1 File Offset: 0x004F37A1
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateCostMaterial(EquipGrowthView.mCurrentSelectItemData);
		}

		// Token: 0x0601139A RID: 70554 RVA: 0x004F53B0 File Offset: 0x004F37B0
		private void OnRemoveItem(ItemData itemData)
		{
			if (EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.GUID == itemData.GUID && !this.bOnStart && !this.bContinueGrowth)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
			this.TryUpdateMaterial(itemData.TableID);
		}

		// Token: 0x0601139B RID: 70555 RVA: 0x004F540C File Offset: 0x004F380C
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			CommonKeyBoardInputType commonKeyBoardInputType = (CommonKeyBoardInputType)uiEvent.Param1;
			ulong num = (ulong)uiEvent.Param2;
			if (commonKeyBoardInputType == CommonKeyBoardInputType.ChangeNumber)
			{
				this.iLastGrowTargetLevel = (int)num;
				this.UpdateGrowthTargetLevel(this.iLastGrowTargetLevel);
			}
			else if (commonKeyBoardInputType == CommonKeyBoardInputType.Finished)
			{
				this.iLastGrowTargetLevel = Mathf.Clamp(this.iLastGrowTargetLevel, this.iMinGrowthLevel, 10);
				this.UpdateGrowthTargetLevel(this.iLastGrowTargetLevel);
				this.UpdateAttributes(EquipGrowthView.mCurrentSelectItemData, this.iLastGrowTargetLevel, false, 0);
			}
		}

		// Token: 0x0601139C RID: 70556 RVA: 0x004F54B0 File Offset: 0x004F38B0
		private void OnStartContinueGrowth(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			int strengthenLevel = EquipGrowthView.mCurrentSelectItemData.StrengthenLevel;
			this.bContinueGrowth = true;
			this.m_bNeedContinueGrowthGoldCostHint = true;
			this.iContinueTimes = 0;
			Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
			this.TryOpenNextContinueGrowth(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
			{
				this.OnStopContinueGrowth(eResult, this.m_akData, bStopByHand);
				this.m_akData.Clear();
			});
		}

		// Token: 0x0601139D RID: 70557 RVA: 0x004F5500 File Offset: 0x004F3900
		private void OnEndContinueGrowth(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.iContinueTimes = 0;
			this.bContinueGrowth = false;
			this.OnCloseGrowthEffect(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ContinueGrowthDelyInvoke));
		}

		// Token: 0x0601139E RID: 70558 RVA: 0x004F5534 File Offset: 0x004F3934
		private void OnGrowthChanged(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (this.mIsUseProtectStamp)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000207, true);
				if (ownedItemCount <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_coupon"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					this.bOnStart = false;
					this.mProtectStampToggle.isOn = false;
					return;
				}
			}
			if (this.mGrowthImplementToggle.isOn && this.mGrowthDeviceItemData == null)
			{
				this.bOnStart = false;
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mGrowthStateContrl != null)
			{
				this.mGrowthStateContrl.Key = "Start";
			}
			if (this.mStopBtn != null)
			{
				this.mStopBtn.CustomActive(this.bOnStart || this.bContinueGrowth);
			}
			if (this.m_kComStrengthenEffect != null)
			{
				this.m_kComStrengthenEffect.Play("NewStrengthenEffect");
			}
		}

		// Token: 0x0601139F RID: 70559 RVA: 0x004F563C File Offset: 0x004F3A3C
		private void OnGrowthDelay(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(452, string.Empty, string.Empty);
			float fDelyTime = (tableItem != null) ? ((float)tableItem.Value / 1000f) : 1.62f;
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.DelaySendGrowth));
			InvokeMethod.Invoke(fDelyTime, new UnityAction(this.DelaySendGrowth));
		}

		// Token: 0x060113A0 RID: 70560 RVA: 0x004F56B0 File Offset: 0x004F3AB0
		private void OnCloseGrowthEffect(UIEvent uiEvent)
		{
			if (this.m_kComStrengthenEffect != null)
			{
				this.m_kComStrengthenEffect.Stop("NewStrengthenEffect");
			}
			if (this.mGrowthStateContrl != null)
			{
				this.mGrowthStateContrl.Key = "NotStart";
			}
		}

		// Token: 0x060113A1 RID: 70561 RVA: 0x004F5700 File Offset: 0x004F3B00
		private void OnInterruptContinueGrowth(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (this.m_akData.Count > 0)
			{
				List<StrengthenResult> list = new List<StrengthenResult>();
				list.AddRange(this.m_akData);
				this.m_akData.Clear();
				StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData userData = new StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData
				{
					bStopByHandle = true,
					eLastOpResult = Utility.StrengthOperateResult.SOR_OK,
					iTarget = this.iLastGrowTargetLevel,
					results = list
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			this.bContinueGrowth = false;
			this.OnCloseGrowthEffect(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ContinueGrowthDelyInvoke));
		}

		// Token: 0x060113A2 RID: 70562 RVA: 0x004F57A1 File Offset: 0x004F3BA1
		private void GrowthCanceled(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.bOnStart = false;
		}

		// Token: 0x060113A3 RID: 70563 RVA: 0x004F57B8 File Offset: 0x004F3BB8
		private void OnItemGrowthSuccess(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.bOnStart = false;
			this.mGrowthStampItemData = null;
			StrengthenResult growthResult = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthResult();
			InvokeMethod.Invoke(0.5f, delegate()
			{
				this.OnCloseGrowthEffect(uiEvent);
			});
			if (this.bContinueGrowth)
			{
				this.m_akData.Add(growthResult);
				if (EquipGrowthView.mCurrentSelectItemData.StrengthenLevel >= this.iLastGrowTargetLevel)
				{
					StrengthenResultUserData userData = new StrengthenResultUserData
					{
						uiCode = growthResult.code,
						EquipData = growthResult.EquipData,
						BrokenItems = growthResult.BrokenItems,
						bContinue = this.bContinueGrowth
					};
					this.OnOpenStrengthenResultFrame(userData);
					InvokeMethod.Invoke(2f, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
						this.OnSucceedContinueGrowth(this.m_akData);
						this.m_akData.Clear();
					});
				}
				else
				{
					StrengthenResultUserData userData2 = new StrengthenResultUserData
					{
						uiCode = growthResult.code,
						EquipData = growthResult.EquipData,
						BrokenItems = growthResult.BrokenItems,
						bContinue = this.bContinueGrowth
					};
					this.OnOpenStrengthenResultFrame(userData2);
					InvokeMethod.Invoke(2f, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
						Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
						this.TryOpenNextContinueGrowth(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
						{
							this.OnStopContinueGrowth(eResult, this.m_akData, bStopByHand);
							this.m_akData.Clear();
						});
					});
				}
			}
			else
			{
				StrengthenResultUserData userData3 = new StrengthenResultUserData
				{
					uiCode = growthResult.code,
					EquipData = growthResult.EquipData,
					BrokenItems = growthResult.BrokenItems,
					bContinue = this.bContinueGrowth,
					NeedBeforeAnimation = this.bSpecialGrowth
				};
				this.bSpecialGrowth = false;
				this.iLastGrowTargetLevel = 0;
				this.OnOpenStrengthenResultFrame(userData3);
			}
		}

		// Token: 0x060113A4 RID: 70564 RVA: 0x004F5954 File Offset: 0x004F3D54
		private void OnItemGrowthFail(UIEvent uiEvent)
		{
			this.bOnStart = false;
			InvokeMethod.Invoke(0.5f, delegate()
			{
				this.OnCloseGrowthEffect(uiEvent);
			});
			StrengthenResult growthResult = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthResult();
			StrengthenResultUserData userData = new StrengthenResultUserData
			{
				uiCode = growthResult.code,
				EquipData = growthResult.EquipData,
				BrokenItems = growthResult.BrokenItems,
				bContinue = this.bContinueGrowth
			};
			if (growthResult.code == 1000019U)
			{
				DataManager<EquipGrowthDataManager>.GetInstance().IsEquipmentIntensifyBroken = true;
			}
			this.OnOpenStrengthenResultFrame(userData);
			if (this.bContinueGrowth)
			{
				this.m_akData.Add(growthResult);
				InvokeMethod.Invoke(1f, delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
					Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
					this.TryOpenNextContinueGrowth(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
					{
						this.OnStopContinueGrowth(eResult, this.m_akData, bStopByHand);
						this.m_akData.Clear();
					});
				});
			}
		}

		// Token: 0x060113A5 RID: 70565 RVA: 0x004F5A24 File Offset: 0x004F3E24
		private void OnSpecailGrowthStart(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (this.mGrowthStateContrl != null)
			{
				this.mGrowthStateContrl.Key = "Start";
			}
			this.mStopBtn.CustomActive(false);
			this.bOnStart = true;
			this.bSpecialGrowth = true;
			DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 0, this.mGrowthStampItemData.GUID);
		}

		// Token: 0x060113A6 RID: 70566 RVA: 0x004F5A93 File Offset: 0x004F3E93
		private void OnSpecailGrowthCanceled(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.OnCloseGrowthEffect(null);
			this.bOnStart = false;
		}

		// Token: 0x060113A7 RID: 70567 RVA: 0x004F5AB0 File Offset: 0x004F3EB0
		private void OnSpecailGrowthFailed(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.OnSpecailGrowthCanceled(null);
			this.mGrowthStampItemData = null;
			StrengthenResult growthResult = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthResult();
			StrengthenResultUserData userData = new StrengthenResultUserData
			{
				uiCode = growthResult.code,
				EquipData = growthResult.EquipData,
				BrokenItems = growthResult.BrokenItems,
				bContinue = this.bContinueGrowth,
				NeedBeforeAnimation = true
			};
			this.bContinueGrowth = false;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenResultFrame>(FrameLayer.Middle, userData, string.Empty);
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060113A8 RID: 70568 RVA: 0x004F5B45 File Offset: 0x004F3F45
		private void OnGrowthError(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.GrowthCanceled(uiEvent);
			this.OnSpecailGrowthCanceled(uiEvent);
		}

		// Token: 0x060113A9 RID: 70569 RVA: 0x004F5B64 File Offset: 0x004F3F64
		private void OnEquipmentListNoEquipment(UIEvent uiEvent)
		{
			EquipGrowthView.mCurrentSelectItemData = null;
			this.mGrowthStampItemData = null;
			this.CreatComitem();
			this.mGrowthStampComItem.Setup(null, null);
			if (this.mEquipName != null)
			{
				this.mEquipName.text = string.Empty;
			}
			if (this.mCurrentGrowthLevel != null)
			{
				this.mCurrentGrowthLevel.text = string.Empty;
			}
			if (this.mNextGrowthLevel != null)
			{
				this.mNextGrowthLevel.text = string.Empty;
			}
			if (this.mInputGrowthLevel != null)
			{
				this.mInputGrowthLevel.text = "1";
			}
			if (this.mAttributesComUIListScript != null)
			{
				this.mAttributesComUIListScript.SetElementAmount(0);
			}
			if (this.mCostMaterialComUIListScript != null)
			{
				this.mCostMaterialComUIListScript.SetElementAmount(0);
			}
			if (this.mSelectEquipStateContrl != null)
			{
				this.mSelectEquipStateContrl.Key = "NoEquip";
			}
			this.mGrowthImplementToggle.isOn = false;
			this.mGrowthImplementToggle.CustomActive(false);
		}

		// Token: 0x060113AA RID: 70570 RVA: 0x004F5C88 File Offset: 0x004F4088
		private void OnSucceedContinueGrowth(List<StrengthenResult> results)
		{
			if (results == null)
			{
				return;
			}
			List<StrengthenResult> list = new List<StrengthenResult>();
			list.AddRange(results);
			StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData userData = new StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData
			{
				bStopByHandle = false,
				eLastOpResult = Utility.StrengthOperateResult.SOR_OK,
				iTarget = this.iLastGrowTargetLevel,
				results = list
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			this.bContinueGrowth = false;
			if (this.mFrontGroundRoot != null)
			{
				this.mFrontGroundRoot.CustomActive(false);
			}
			if (this.mGrowthStateContrl != null)
			{
				this.mGrowthStateContrl.Key = "NotStart";
			}
			this.iLastGrowTargetLevel = 0;
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x060113AB RID: 70571 RVA: 0x004F5D4C File Offset: 0x004F414C
		private void OnOpenStrengthenResultFrame(object userData)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenResultFrame>(FrameLayer.Middle, userData, string.Empty);
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060113AC RID: 70572 RVA: 0x004F5D6B File Offset: 0x004F416B
		private bool BCheckIsUpdateFrame()
		{
			return EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.EquipType == EEquipType.ET_REDMARK;
		}

		// Token: 0x060113AD RID: 70573 RVA: 0x004F5D8C File Offset: 0x004F418C
		private void OnGrowthClick()
		{
			if (EquipGrowthView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法激化", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
			if (this.iLastGrowTargetLevel - EquipGrowthView.mCurrentSelectItemData.StrengthenLevel > 1)
			{
				this.OnGrowthContinueClick();
			}
			else
			{
				this.GrowthEx();
			}
		}

		// Token: 0x060113AE RID: 70574 RVA: 0x004F5E10 File Offset: 0x004F4210
		private bool CheckMaterial()
		{
			List<ItemSimpleData> growthCosts = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthCosts(EquipGrowthView.mCurrentSelectItemData);
			for (int i = 0; i < growthCosts.Count; i++)
			{
				ItemSimpleData itemSimpleData = growthCosts[i];
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemSimpleData.ItemID, true);
				int count = itemSimpleData.Count;
				if (ownedItemCount < count)
				{
					ItemComeLink.OnLink(itemSimpleData.ItemID, 0, true, null, false, false, false, null, string.Empty);
					return true;
				}
			}
			return false;
		}

		// Token: 0x060113AF RID: 70575 RVA: 0x004F5E88 File Offset: 0x004F4288
		private int GetGrowthNeedMonet(ItemData itemData)
		{
			int result = 0;
			List<ItemSimpleData> growthCosts = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthCosts(itemData);
			for (int i = 0; i < growthCosts.Count; i++)
			{
				ItemSimpleData itemSimpleData = growthCosts[i];
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemSimpleData.ItemID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SubType == ItemTable.eSubType.BindGOLD)
					{
						result = itemSimpleData.Count;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060113B0 RID: 70576 RVA: 0x004F5F0C File Offset: 0x004F430C
		private void GrowthEx()
		{
			if (this.bOnStart)
			{
				return;
			}
			if (!this.mGrowthImplementToggle.isOn && this.CheckMaterial())
			{
				return;
			}
			if (this.mIsUseProtectStamp)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000207, true);
				if (ownedItemCount <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_coupon"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					this.bOnStart = false;
					this.mProtectStampToggle.isOn = false;
					return;
				}
			}
			if (this.mGrowthImplementToggle.isOn && this.mGrowthDeviceItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("growth_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				this.bOnStart = false;
				return;
			}
			this.mGrowthHintText.text = TR.Value("growth_fixed_level");
			if (!this.mGrowthImplementToggle.isOn)
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				int growthNeedMonet = this.GetGrowthNeedMonet(EquipGrowthView.mCurrentSelectItemData);
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = moneyIDByType,
					nCount = growthNeedMonet
				}, new Action(this.ConfirmGrowth), "common_money_cost", null);
			}
			else
			{
				this.ConfirmGrowth();
			}
		}

		// Token: 0x060113B1 RID: 70577 RVA: 0x004F6038 File Offset: 0x004F4438
		private void ConfirmGrowth()
		{
			this.bOnStart = true;
			if (EquipGrowthView.mCurrentSelectItemData.StrengthenLevel < 10)
			{
				this.OnGrowthChanged(null);
				this.OnGrowthDelay(null);
			}
			else
			{
				StrengthenConfirmData strengthenConfirmData = new StrengthenConfirmData
				{
					ItemData = EquipGrowthView.mCurrentSelectItemData,
					UseProtect = this.mIsUseProtectStamp,
					UseStrengthenImplement = this.mGrowthImplementToggle.isOn,
					StrengthenImplementItem = this.mGrowthDeviceItemData
				};
				strengthenConfirmData.TargetStrengthenLevel = strengthenConfirmData.ItemData.StrengthenLevel;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenConfirm>(FrameLayer.Middle, strengthenConfirmData, string.Empty);
			}
		}

		// Token: 0x060113B2 RID: 70578 RVA: 0x004F60D0 File Offset: 0x004F44D0
		private void DelaySendGrowth()
		{
			if (this.bOnStart && EquipGrowthView.mCurrentSelectItemData != null)
			{
				if (this.mGrowthImplementToggle.isOn && this.mProtectStampToggle.isOn)
				{
					DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 3, this.mGrowthDeviceItemData.GUID);
				}
				else if (this.mGrowthImplementToggle.isOn)
				{
					DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 2, this.mGrowthDeviceItemData.GUID);
				}
				else if (this.mProtectStampToggle.isOn)
				{
					DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 1, 0UL);
				}
				else
				{
					DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 0, 0UL);
				}
			}
		}

		// Token: 0x060113B3 RID: 70579 RVA: 0x004F619C File Offset: 0x004F459C
		private void OnGrowthContinueClick()
		{
			if (this.bContinueGrowth)
			{
				return;
			}
			if (this.mGrowthImplementToggle.isOn && this.mGrowthDeviceItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!this.mGrowthImplementToggle.isOn && this.CheckMaterial())
			{
				return;
			}
			this.mFrontGroundRoot.CustomActive(true);
			this.mStopBtn.CustomActive(false);
			this.m_akData.Clear();
			StrengthenConfirmData userData = new StrengthenConfirmData
			{
				ItemData = EquipGrowthView.mCurrentSelectItemData,
				UseProtect = false,
				TargetStrengthenLevel = this.iLastGrowTargetLevel
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueConfirm>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x060113B4 RID: 70580 RVA: 0x004F6258 File Offset: 0x004F4658
		private bool TryOpenNextContinueGrowth(ref Utility.StrengthOperateResult eResult, UnityAction<Utility.StrengthOperateResult, bool> onCancel)
		{
			if (EquipGrowthView.mCurrentSelectItemData == null)
			{
				return false;
			}
			if (!this.bContinueGrowth)
			{
				return false;
			}
			this.bContinueGrowth = false;
			int strengthenLevel = EquipGrowthView.mCurrentSelectItemData.StrengthenLevel;
			if (strengthenLevel >= 10)
			{
				return false;
			}
			if (strengthenLevel >= this.iLastGrowTargetLevel)
			{
				return false;
			}
			if (this.mGrowthImplementToggle.isOn && this.mGrowthDeviceItemData == null)
			{
				eResult = Utility.StrengthOperateResult.SOR_Strengthen_Implement;
				if (eResult != Utility.StrengthOperateResult.SOR_OK)
				{
					if (onCancel != null)
					{
						onCancel.Invoke(eResult, false);
					}
					return false;
				}
			}
			if (!this.mGrowthImplementToggle.isOn)
			{
				eResult = Utility.CheckGrowthItem(EquipGrowthView.mCurrentSelectItemData, false);
				if (eResult != Utility.StrengthOperateResult.SOR_OK)
				{
					if (onCancel != null)
					{
						onCancel.Invoke(eResult, false);
					}
					return false;
				}
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				int growthNeedMonet = this.GetGrowthNeedMonet(EquipGrowthView.mCurrentSelectItemData);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, false);
				bool flag = growthNeedMonet <= ownedItemCount;
				if (!this.m_bNeedContinueGrowthGoldCostHint || flag)
				{
					this.ConfirmContinueGrowth();
				}
				else
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
					{
						nMoneyID = moneyIDByType,
						nCount = growthNeedMonet
					}, delegate
					{
						this.m_bNeedContinueGrowthGoldCostHint = false;
						this.ConfirmContinueGrowth();
					}, "common_money_cost", delegate
					{
						if (onCancel != null)
						{
							onCancel.Invoke(Utility.StrengthOperateResult.SOR_OK, true);
						}
					});
				}
			}
			else
			{
				this.ConfirmContinueGrowth();
			}
			return true;
		}

		// Token: 0x060113B5 RID: 70581 RVA: 0x004F63D8 File Offset: 0x004F47D8
		private void ConfirmContinueGrowth()
		{
			this.bContinueGrowth = true;
			this.iContinueTimes++;
			if (this.mGrowthHintText != null)
			{
				this.mGrowthHintText.text = TR.Value("growth_dynamic_level", this.iLastGrowTargetLevel, this.iContinueTimes);
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(453, string.Empty, string.Empty);
			float fDelyTime = (tableItem != null) ? ((float)tableItem.Value / 1000f) : 0.7f;
			this.OnGrowthChanged(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ContinueGrowthDelyInvoke));
			InvokeMethod.Invoke(fDelyTime, new UnityAction(this.ContinueGrowthDelyInvoke));
		}

		// Token: 0x060113B6 RID: 70582 RVA: 0x004F6498 File Offset: 0x004F4898
		private void ContinueGrowthDelyInvoke()
		{
			if (!this.bContinueGrowth)
			{
				return;
			}
			if (EquipGrowthView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (this.mGrowthImplementToggle.isOn && this.mProtectStampToggle.isOn)
			{
				DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 3, this.mGrowthDeviceItemData.GUID);
			}
			else if (this.mGrowthImplementToggle.isOn)
			{
				DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 2, this.mGrowthDeviceItemData.GUID);
			}
			else if (this.mProtectStampToggle.isOn)
			{
				DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 1, 0UL);
			}
			else
			{
				DataManager<EquipGrowthDataManager>.GetInstance().SceneEquipEnhanceUpgrade(EquipGrowthView.mCurrentSelectItemData, 0, 0UL);
			}
		}

		// Token: 0x060113B7 RID: 70583 RVA: 0x004F6568 File Offset: 0x004F4968
		private void OnStopContinueGrowth(Utility.StrengthOperateResult eResult, List<StrengthenResult> results, bool bStopByHand)
		{
			this.bContinueGrowth = false;
			this.iContinueTimes = 0;
			if (this.mGrowthStateContrl != null)
			{
				this.mGrowthStateContrl.Key = "NotStart";
			}
			List<StrengthenResult> list = new List<StrengthenResult>();
			list.AddRange(results);
			if (list.Count <= 0)
			{
				Utility.OnPopupStrengthenResultMsg(eResult);
			}
			else
			{
				StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData userData = new StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData
				{
					bStopByHandle = bStopByHand,
					eLastOpResult = eResult,
					iTarget = this.iLastGrowTargetLevel,
					results = list
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			this.iLastGrowTargetLevel = 0;
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x060113B8 RID: 70584 RVA: 0x004F6628 File Offset: 0x004F4A28
		private void OnClickStop()
		{
			if (this.bOnStart)
			{
				InvokeMethod.RemoveInvokeCall(new UnityAction(this.DelaySendGrowth));
				this.bOnStart = false;
				this.OnCloseGrowthEffect(null);
			}
			if (this.bContinueGrowth)
			{
				this.OnInterruptContinueGrowth(null);
			}
			this.iLastGrowTargetLevel = 0;
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060113B9 RID: 70585 RVA: 0x004F6684 File Offset: 0x004F4A84
		private void OnGrowthProtectedStampItemComLinkClick()
		{
			ItemComeLink.OnLink(300000207, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x060113BA RID: 70586 RVA: 0x004F66A8 File Offset: 0x004F4AA8
		private void OnStrengthenGrowthEquipItemClick(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			if (EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.GUID != itemData.GUID)
			{
				this.iLastGrowTargetLevel = 0;
			}
			EquipGrowthView.mCurrentSelectItemData = itemData;
			if (eStrengthenGrowthType == this.mStrengthenGrowthType)
			{
				this.mProtectStampToggle.isOn = false;
				if (itemData.StrengthenLevel >= 10)
				{
					this.mSelectEquipStateContrl.Key = "level>=10";
				}
				else
				{
					this.mSelectEquipStateContrl.Key = "level<10";
				}
				if (this.iLastGrowTargetLevel != 0)
				{
					this.iMinGrowthLevel = this.iLastGrowTargetLevel;
				}
				else
				{
					this.iMinGrowthLevel = itemData.StrengthenLevel + 1;
				}
				this.iGrowthNextLevel = this.iMinGrowthLevel;
				this.UpdateEquipItem(itemData);
				this.UpdateAttributes(itemData, this.iGrowthNextLevel, false, 0);
				this.UpdateCostMaterial(itemData);
				this.UpdateGrowthTargetLevel(this.iGrowthNextLevel);
				this.UpdateGrowthProtectedStamp();
				this.SetGrowthStampItem();
				this.UpdateStrengthDeviceItem();
				if (itemData.StrengthenLevel >= 20)
				{
					this.mGrowthImplementToggle.isOn = false;
					this.mGrowthImplementToggle.CustomActive(false);
				}
				else
				{
					this.mGrowthImplementToggle.CustomActive(true);
				}
			}
		}

		// Token: 0x060113BB RID: 70587 RVA: 0x004F67DC File Offset: 0x004F4BDC
		private void UpdateEquipItem(ItemData itemData)
		{
			if (this.mEquipItem == null)
			{
				this.mEquipItem = ComItemManager.Create(this.mEquipItemParent);
			}
			ComItem comItem = this.mEquipItem;
			if (EquipGrowthView.<>f__mg$cache0 == null)
			{
				EquipGrowthView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(itemData, EquipGrowthView.<>f__mg$cache0);
			if (this.mEquipName != null)
			{
				this.mEquipName.text = TR.Value("growth_strengthlevel_desc", itemData.StrengthenLevel);
			}
		}

		// Token: 0x060113BC RID: 70588 RVA: 0x004F6868 File Offset: 0x004F4C68
		private void UpdateAttributes(ItemData itemData, int iTargetLevel, bool bIsSpecialItem = false, int iMaxStrengthLevel = 0)
		{
			if (this.mItemGrowthAttrA == null)
			{
				this.mItemGrowthAttrA = new List<StrengthenAttributeItemData>();
			}
			else
			{
				this.mItemGrowthAttrA.Clear();
			}
			if (this.mItemGrowthAttrB == null)
			{
				this.mItemGrowthAttrB = new List<StrengthenAttributeItemData>();
			}
			else
			{
				this.mItemGrowthAttrB.Clear();
			}
			if (itemData != null)
			{
				if (this.mCurrentGrowthLevel != null)
				{
					this.mCurrentGrowthLevel.text = TR.Value("growth_strengthlevel_desc", itemData.StrengthenLevel.ToString());
				}
				if (bIsSpecialItem)
				{
					if (this.mNextGrowthLevel != null)
					{
						this.mNextGrowthLevel.text = TR.Value("growth_target_strengthlevel_desc2", iTargetLevel, iMaxStrengthLevel);
					}
				}
				else if (this.mNextGrowthLevel != null)
				{
					this.mNextGrowthLevel.text = TR.Value("growth_target_strengthlevel_desc", iTargetLevel.ToString());
				}
				StrengthenAttributeItemData strengthenAttributeItemData = new StrengthenAttributeItemData();
				strengthenAttributeItemData.kDesc = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(itemData.GrowthAttrType);
				strengthenAttributeItemData.iCurValue = (float)itemData.GrowthAttrNum;
				strengthenAttributeItemData.valueFormat = "{0}";
				this.mItemGrowthAttrA.Add(strengthenAttributeItemData);
				StrengthenAttributeItemData strengthenAttributeItemData2 = new StrengthenAttributeItemData();
				strengthenAttributeItemData2.kDesc = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttrDesc(itemData.GrowthAttrType);
				strengthenAttributeItemData2.iCurValue = (float)DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(itemData, iTargetLevel);
				if (bIsSpecialItem)
				{
					strengthenAttributeItemData2.iMaxValue = (float)DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(itemData, iMaxStrengthLevel);
					strengthenAttributeItemData2.bIsSpecialItem = true;
				}
				strengthenAttributeItemData2.valueFormat = "{0}";
				this.mItemGrowthAttrB.Add(strengthenAttributeItemData2);
				if (itemData.IsAssistEquip())
				{
					float assistEqStrengthAttrValue = DataManager<StrengthenDataManager>.GetInstance().GetAssistEqStrengthAttrValue(itemData, itemData.StrengthenLevel);
					float assistEqStrengthAttrValue2 = DataManager<StrengthenDataManager>.GetInstance().GetAssistEqStrengthAttrValue(itemData, itemData.StrengthenLevel + 1);
					for (int i = 4; i <= 7; i++)
					{
						StrengthenAttributeItemData strengthenAttributeItemData3 = new StrengthenAttributeItemData();
						StrengthenAttributeItemData strengthenAttributeItemData4 = new StrengthenAttributeItemData();
						if (i == 4)
						{
							strengthenAttributeItemData3.kDesc = (strengthenAttributeItemData4.kDesc = TR.Value("auxiliary_equipment_attr_strength"));
							strengthenAttributeItemData3.valueFormat = (strengthenAttributeItemData4.valueFormat = "{0}");
							strengthenAttributeItemData3.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData4.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 5)
						{
							strengthenAttributeItemData3.kDesc = (strengthenAttributeItemData4.kDesc = TR.Value("auxiliary_equipment_attr_intelligence"));
							strengthenAttributeItemData3.valueFormat = (strengthenAttributeItemData4.valueFormat = "{0}");
							strengthenAttributeItemData3.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData4.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 7)
						{
							strengthenAttributeItemData3.kDesc = (strengthenAttributeItemData4.kDesc = TR.Value("auxiliary_equipment_attr_stamina"));
							strengthenAttributeItemData3.valueFormat = (strengthenAttributeItemData4.valueFormat = "{0}");
							strengthenAttributeItemData3.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData4.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 6)
						{
							strengthenAttributeItemData3.kDesc = (strengthenAttributeItemData4.kDesc = TR.Value("auxiliary_equipment_attr_spirit"));
							strengthenAttributeItemData3.valueFormat = (strengthenAttributeItemData4.valueFormat = "{0}");
							strengthenAttributeItemData3.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData4.iCurValue = assistEqStrengthAttrValue2;
						}
						this.mItemGrowthAttrA.Add(strengthenAttributeItemData3);
						this.mItemGrowthAttrB.Add(strengthenAttributeItemData4);
					}
				}
				else
				{
					ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(itemData.TableID, false);
					ItemStrengthAttribute itemStrengthAttribute2 = ItemStrengthAttribute.Create(itemData.TableID, false);
					if (itemStrengthAttribute != null && itemStrengthAttribute2 != null)
					{
						itemStrengthAttribute.SetStrength(itemData.StrengthenLevel, false, 0);
						if (bIsSpecialItem)
						{
							itemStrengthAttribute2.SetStrength(iTargetLevel, bIsSpecialItem, iMaxStrengthLevel);
						}
						else
						{
							itemStrengthAttribute2.SetStrength(iTargetLevel, false, 0);
						}
						this.mItemGrowthAttrA.AddRange(itemStrengthAttribute.Attributes);
						this.mItemGrowthAttrB.AddRange(itemStrengthAttribute2.Attributes);
					}
				}
				if (this.mItemGrowthAttrA != null && this.mItemGrowthAttrB != null && this.mAttributesComUIListScript != null)
				{
					this.mAttributesComUIListScript.SetElementAmount(this.mItemGrowthAttrA.Count);
				}
			}
		}

		// Token: 0x060113BD RID: 70589 RVA: 0x004F6C90 File Offset: 0x004F5090
		private void UpdateCostMaterial(ItemData itemData)
		{
			if (this.mGrowthCosts != null)
			{
				this.mGrowthCosts.Clear();
			}
			else
			{
				this.mGrowthCosts = new List<ItemSimpleData>();
			}
			List<ItemSimpleData> growthCosts = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthCosts(itemData);
			this.mGrowthCosts.AddRange(growthCosts);
			if (this.mCostMaterialComUIListScript != null)
			{
				this.mCostMaterialComUIListScript.SetElementAmount(this.mGrowthCosts.Count);
			}
			this.UpdateGrowthProtectedStamp();
		}

		// Token: 0x060113BE RID: 70590 RVA: 0x004F6D08 File Offset: 0x004F5108
		private void UpdateGrowthTargetLevel(int level)
		{
			if (this.mInputGrowthLevel != null)
			{
				this.mInputGrowthLevel.text = level.ToString();
			}
		}

		// Token: 0x060113BF RID: 70591 RVA: 0x004F6D34 File Offset: 0x004F5134
		private void UpdateGrowthProtectedStamp()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000207, true);
			if (ownedItemCount >= 1)
			{
				this.mGrowthProtectedStampItemCount.text = string.Format(TR.Value("strength_protected_enough"), ownedItemCount);
			}
			else
			{
				this.mGrowthProtectedStampItemCount.text = string.Format(TR.Value("strength_protected_not_enough"), ownedItemCount);
			}
			this.mGrowthProtectedStampItemComLinkRoot.CustomActive(ownedItemCount < 1);
		}

		// Token: 0x060113C0 RID: 70592 RVA: 0x004F6DB0 File Offset: 0x004F51B0
		private void TryUpdateMaterial(int iTableID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == ItemTable.eSubType.GOLD || tableItem.SubType == ItemTable.eSubType.BindGOLD || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_PROTECT || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_MATERIAL || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_AMPLIFICATION)
				{
					this.UpdateCostMaterial(EquipGrowthView.mCurrentSelectItemData);
				}
				else if (tableItem.ThirdType == ItemTable.eThirdType.DisposableIncreaseItem)
				{
					this.UpdateStrengthDeviceItem();
				}
			}
		}

		// Token: 0x060113C1 RID: 70593 RVA: 0x004F6E40 File Offset: 0x004F5240
		private void InitAttributesUIList()
		{
			if (this.mAttributesComUIListScript != null)
			{
				this.mAttributesComUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mAttributesComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindAttrbutesItemDelegate));
				ComUIListScript comUIListScript2 = this.mAttributesComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnAttrbutesItemVisiableDelegate));
			}
		}

		// Token: 0x060113C2 RID: 70594 RVA: 0x004F6EB8 File Offset: 0x004F52B8
		private void UnInitAttributesUIList()
		{
			if (this.mAttributesComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mAttributesComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindAttrbutesItemDelegate));
				ComUIListScript comUIListScript2 = this.mAttributesComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnAttrbutesItemVisiableDelegate));
			}
		}

		// Token: 0x060113C3 RID: 70595 RVA: 0x004F6F24 File Offset: 0x004F5324
		private ComCommonBind OnBindAttrbutesItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x060113C4 RID: 70596 RVA: 0x004F6F2C File Offset: 0x004F532C
		private void OnAttrbutesItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mItemGrowthAttrA.Count && this.mItemGrowthAttrA.Count == this.mItemGrowthAttrB.Count)
			{
				Text com = comCommonBind.GetCom<Text>("Prefixed");
				Text com2 = comCommonBind.GetCom<Text>("Value1");
				Text com3 = comCommonBind.GetCom<Text>("Value2");
				StrengthenAttributeItemData strengthenAttributeItemData = this.mItemGrowthAttrA[item.m_index];
				if (com != null)
				{
					com.text = strengthenAttributeItemData.kDesc;
				}
				if (com2 != null)
				{
					com2.text = string.Format("+{0}", strengthenAttributeItemData.ToValueDesc());
				}
				StrengthenAttributeItemData strengthenAttributeItemData2 = this.mItemGrowthAttrB[item.m_index];
				if (com3 != null)
				{
					if (strengthenAttributeItemData2.bIsSpecialItem)
					{
						com3.text = string.Format("+{0}~{1}", strengthenAttributeItemData2.ToValueDesc(strengthenAttributeItemData2.valueFormat, strengthenAttributeItemData2.iCurValue), strengthenAttributeItemData2.ToValueDesc(strengthenAttributeItemData2.valueFormat, strengthenAttributeItemData2.iMaxValue));
					}
					else
					{
						com3.text = string.Format("+{0}", strengthenAttributeItemData2.ToValueDesc());
					}
				}
			}
		}

		// Token: 0x060113C5 RID: 70597 RVA: 0x004F7084 File Offset: 0x004F5484
		private void InitCostMaterialUIListScript()
		{
			if (this.mCostMaterialComUIListScript != null)
			{
				this.mCostMaterialComUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mCostMaterialComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnCostMaterialBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mCostMaterialComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnCostMaterialItemVisiableDelegate));
			}
		}

		// Token: 0x060113C6 RID: 70598 RVA: 0x004F70FC File Offset: 0x004F54FC
		private void UnInitCostMaterialUIListScript()
		{
			if (this.mCostMaterialComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mCostMaterialComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnCostMaterialBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mCostMaterialComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnCostMaterialItemVisiableDelegate));
			}
		}

		// Token: 0x060113C7 RID: 70599 RVA: 0x004F7168 File Offset: 0x004F5568
		private EquipUpgradeCostItem OnCostMaterialBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EquipUpgradeCostItem>();
		}

		// Token: 0x060113C8 RID: 70600 RVA: 0x004F7170 File Offset: 0x004F5570
		private void OnCostMaterialItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeCostItem equipUpgradeCostItem = item.gameObjectBindScript as EquipUpgradeCostItem;
			if (equipUpgradeCostItem != null && item.m_index >= 0 && item.m_index < this.mGrowthCosts.Count)
			{
				equipUpgradeCostItem.OnItemVisiable(this.mGrowthCosts[item.m_index]);
			}
		}

		// Token: 0x060113C9 RID: 70601 RVA: 0x004F71D0 File Offset: 0x004F55D0
		private void OnGrowthStampClcik(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mGrowthStampItemData = itemData;
			if (this.mGrowthStampComItem != null)
			{
				this.mGrowthStampComItem.Setup(this.mGrowthStampItemData, delegate(GameObject obj, ItemData item)
				{
					this.OnOpenExpendFrameBtnClick();
				});
				this.mGrowthStampComItem.CustomActive(true);
			}
			if (this.mCouponName != null)
			{
				this.mCouponName.text = this.mGrowthStampItemData.GetColorName(string.Empty, false);
			}
			if (this.mGrowthStampItemData.SubType == 146)
			{
				int iTargetLevel = 0;
				int iMaxStrengthLevel = 0;
				DataManager<EquipGrowthDataManager>.GetInstance().GetStrengthLevelIntervalValue(this.mGrowthStampItemData.TableID, ref iTargetLevel, ref iMaxStrengthLevel);
				this.UpdateAttributes(EquipGrowthView.mCurrentSelectItemData, iTargetLevel, true, iMaxStrengthLevel);
			}
			else
			{
				StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(this.mGrowthStampItemData.TableData.StrenTicketDataIndex, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.iLastGrowTargetLevel = tableItem.Level;
					this.UpdateGrowthTargetLevel(this.iLastGrowTargetLevel);
					this.UpdateAttributes(EquipGrowthView.mCurrentSelectItemData, this.iLastGrowTargetLevel, false, 0);
				}
			}
			if (this.mGrowthStampBtn != null)
			{
				this.mGrowthStampBtn.enabled = false;
			}
		}

		// Token: 0x060113CA RID: 70602 RVA: 0x004F730A File Offset: 0x004F570A
		private void SetGrowthStampInfo()
		{
			this.mGrowthStampItemData = null;
			this.mGrowthStampComItem.Setup(null, null);
			this.mGrowthStampComItem.CustomActive(false);
			this.mCouponName.text = "请选择激化券";
			this.mGrowthStampBtn.enabled = true;
		}

		// Token: 0x060113CB RID: 70603 RVA: 0x004F7348 File Offset: 0x004F5748
		private void SetGrowthStampItem()
		{
			if (this.mGrowthStampComItem == null)
			{
				this.mGrowthStampComItem = ComItemManager.Create(this.mCouponParent);
			}
			if (this.mGrowthStampItemData == null)
			{
				this.SetGrowthStampInfo();
			}
			else if (this.mGrowthStampItemData.SubType == 109)
			{
				StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(this.mGrowthStampItemData.TableData.StrenTicketDataIndex, string.Empty, string.Empty);
				if (tableItem != null && EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.StrengthenLevel >= tableItem.Level)
				{
					this.SetGrowthStampInfo();
				}
			}
			else if (this.mGrowthStampItemData.SubType == 146)
			{
				int num = 0;
				int num2 = 0;
				DataManager<EquipGrowthDataManager>.GetInstance().GetStrengthLevelIntervalValue(this.mGrowthStampItemData.TableID, ref num, ref num2);
				if (EquipGrowthView.mCurrentSelectItemData != null && EquipGrowthView.mCurrentSelectItemData.StrengthenLevel >= num)
				{
					this.SetGrowthStampInfo();
				}
			}
		}

		// Token: 0x060113CC RID: 70604 RVA: 0x004F7448 File Offset: 0x004F5848
		private void OnGrowthImplementClick(bool value)
		{
			if (value)
			{
				this.mGrowthDeviceStateControl.Key = "true";
				this.UpdateStrengthDeviceItem();
			}
			else
			{
				this.mGrowthDeviceStateControl.Key = "false";
				this.OnStrengthenGrowthEquipItemClick(EquipGrowthView.mCurrentSelectItemData, this.mStrengthenGrowthType);
			}
		}

		// Token: 0x060113CD RID: 70605 RVA: 0x004F7497 File Offset: 0x004F5897
		private void OnStrengthenDeviceItem(ItemData item)
		{
			if (item == null)
			{
				return;
			}
			this.mGrowthDeviceItemData = item;
		}

		// Token: 0x060113CE RID: 70606 RVA: 0x004F74A8 File Offset: 0x004F58A8
		private void UpdateStrengthDeviceItem()
		{
			this.mGrowthDeviceStateControl.Key = "false";
			if (this.mGrowthImplementToggle.isOn)
			{
				this.mGrowthDeviceStateControl.Key = "true";
			}
			if (this.mGrowthImplementToggle.isOn && this.mGrowthDeviceItemData != null)
			{
				bool flag = false;
				List<ItemData> disposableIncreaseItemList = DataManager<EquipGrowthDataManager>.GetInstance().GetDisposableIncreaseItemList(EquipGrowthView.mCurrentSelectItemData);
				for (int i = 0; i < disposableIncreaseItemList.Count; i++)
				{
					ItemData itemData = disposableIncreaseItemList[i];
					if (itemData != null)
					{
						if (itemData.GUID == this.mGrowthDeviceItemData.GUID)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.mGrowthDeviceItemData = null;
				}
				if (this.mStrengthenDeviceItem != null)
				{
					this.mStrengthenDeviceItem.SetItem(this.mGrowthDeviceItemData);
				}
			}
		}

		// Token: 0x0400B1D1 RID: 45521
		[SerializeField]
		private GameObject mBottomRoot;

		// Token: 0x0400B1D2 RID: 45522
		[SerializeField]
		private GameObject mProtectedContentRoot;

		// Token: 0x0400B1D3 RID: 45523
		[SerializeField]
		private GameObject mEquipItemParent;

		// Token: 0x0400B1D4 RID: 45524
		[SerializeField]
		private GameObject mCouponParent;

		// Token: 0x0400B1D5 RID: 45525
		[SerializeField]
		private GameObject mCouponLinkRoot;

		// Token: 0x0400B1D6 RID: 45526
		[SerializeField]
		private GameObject mFrontGroundRoot;

		// Token: 0x0400B1D7 RID: 45527
		[SerializeField]
		private GameObject mGrowthProtectedStampItemComLinkRoot;

		// Token: 0x0400B1D8 RID: 45528
		[SerializeField]
		private Text mCouponName;

		// Token: 0x0400B1D9 RID: 45529
		[SerializeField]
		private Text mEquipName;

		// Token: 0x0400B1DA RID: 45530
		[SerializeField]
		private Text mCurrentGrowthLevel;

		// Token: 0x0400B1DB RID: 45531
		[SerializeField]
		private Text mNextGrowthLevel;

		// Token: 0x0400B1DC RID: 45532
		[SerializeField]
		private Text mInputGrowthLevel;

		// Token: 0x0400B1DD RID: 45533
		[SerializeField]
		private Text mGrowthHintText;

		// Token: 0x0400B1DE RID: 45534
		[SerializeField]
		private Text mGrowthProtectedStampItemCount;

		// Token: 0x0400B1DF RID: 45535
		[SerializeField]
		private ComUIListScript mAttributesComUIListScript;

		// Token: 0x0400B1E0 RID: 45536
		[SerializeField]
		private ComUIListScript mCostMaterialComUIListScript;

		// Token: 0x0400B1E1 RID: 45537
		[SerializeField]
		private Toggle mProtectStampToggle;

		// Token: 0x0400B1E2 RID: 45538
		[SerializeField]
		private Toggle mFilter0;

		// Token: 0x0400B1E3 RID: 45539
		[SerializeField]
		private Toggle mFilter1;

		// Token: 0x0400B1E4 RID: 45540
		[SerializeField]
		private Toggle mGrowthImplementToggle;

		// Token: 0x0400B1E5 RID: 45541
		[SerializeField]
		private StateController mGrowthProtectStateController;

		// Token: 0x0400B1E6 RID: 45542
		[SerializeField]
		private StateController mSelectEquipStateContrl;

		// Token: 0x0400B1E7 RID: 45543
		[SerializeField]
		private StateController mGrowthStateContrl;

		// Token: 0x0400B1E8 RID: 45544
		[SerializeField]
		private Button mGrowthBtn;

		// Token: 0x0400B1E9 RID: 45545
		[SerializeField]
		private Button mInputGrowthLevelBtn;

		// Token: 0x0400B1EA RID: 45546
		[SerializeField]
		private Button mGrowthSpecialBtn;

		// Token: 0x0400B1EB RID: 45547
		[SerializeField]
		private Button mStopBtn;

		// Token: 0x0400B1EC RID: 45548
		[SerializeField]
		private Button mGrowthProtectedStampItemComLinkBtn;

		// Token: 0x0400B1ED RID: 45549
		[SerializeField]
		private Button mGrowthProtectedStampItemBtn;

		// Token: 0x0400B1EE RID: 45550
		[SerializeField]
		private Button mGrowthStampBtn;

		// Token: 0x0400B1EF RID: 45551
		[SerializeField]
		private ItemComeLink mCouponLink;

		// Token: 0x0400B1F0 RID: 45552
		[SerializeField]
		private RectTransform mCostMaterialScrollViewRect;

		// Token: 0x0400B1F1 RID: 45553
		[SerializeField]
		private Image mGrowthProtectStampIconBg;

		// Token: 0x0400B1F2 RID: 45554
		[SerializeField]
		private Image mGrowthProtectStampIcon;

		// Token: 0x0400B1F3 RID: 45555
		[SerializeField]
		private ComEffect m_kComStrengthenEffect;

		// Token: 0x0400B1F4 RID: 45556
		[SerializeField]
		private StrengthenDeviceItem mStrengthenDeviceItem;

		// Token: 0x0400B1F5 RID: 45557
		[SerializeField]
		private StateController mGrowthDeviceStateControl;

		// Token: 0x0400B1F6 RID: 45558
		private const int iMaxGrowthLevel = 10;

		// Token: 0x0400B1F7 RID: 45559
		private const float delaySendGrowth = 1.62f;

		// Token: 0x0400B1F8 RID: 45560
		private const float delaySendContinueGrowth = 0.7f;

		// Token: 0x0400B1F9 RID: 45561
		private SmithShopNewLinkData mLinkData;

		// Token: 0x0400B1FA RID: 45562
		private StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B1FB RID: 45563
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B1FC RID: 45564
		private int iMinGrowthLevel;

		// Token: 0x0400B1FD RID: 45565
		private int iGrowthNextLevel;

		// Token: 0x0400B1FE RID: 45566
		private int iLastGrowTargetLevel;

		// Token: 0x0400B1FF RID: 45567
		private int iContinueTimes;

		// Token: 0x0400B200 RID: 45568
		private ComItem mEquipItem;

		// Token: 0x0400B201 RID: 45569
		private bool mIsUseProtectStamp;

		// Token: 0x0400B202 RID: 45570
		private bool bOnStart;

		// Token: 0x0400B203 RID: 45571
		private bool bSpecialGrowth;

		// Token: 0x0400B204 RID: 45572
		private bool bContinueGrowth;

		// Token: 0x0400B205 RID: 45573
		private List<StrengthenAttributeItemData> mItemGrowthAttrA;

		// Token: 0x0400B206 RID: 45574
		private List<StrengthenAttributeItemData> mItemGrowthAttrB;

		// Token: 0x0400B207 RID: 45575
		private List<ItemSimpleData> mGrowthCosts;

		// Token: 0x0400B208 RID: 45576
		private static ItemData mCurrentSelectItemData;

		// Token: 0x0400B209 RID: 45577
		private List<StrengthenResult> m_akData = new List<StrengthenResult>();

		// Token: 0x0400B20A RID: 45578
		private List<ItemData> mGrowthStampList = new List<ItemData>();

		// Token: 0x0400B20B RID: 45579
		private ComItem mGrowthStampComItem;

		// Token: 0x0400B20C RID: 45580
		private ItemData mGrowthStampItemData;

		// Token: 0x0400B20D RID: 45581
		private bool m_bNeedContinueGrowthGoldCostHint;

		// Token: 0x0400B20E RID: 45582
		private ItemData mGrowthDeviceItemData;

		// Token: 0x0400B211 RID: 45585
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}

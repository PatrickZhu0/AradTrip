using System;
using System.Collections.Generic;
using System.ComponentModel;
using ActivityLimitTime;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B8B RID: 7051
	internal class StrengthenView : StrengthGrowthBaseView
	{
		// Token: 0x17001DA2 RID: 7586
		// (get) Token: 0x060114A0 RID: 70816 RVA: 0x004FCE71 File Offset: 0x004FB271
		// (set) Token: 0x0601149F RID: 70815 RVA: 0x004FCE5D File Offset: 0x004FB25D
		private bool m_bContinueStrengthen
		{
			get
			{
				return this.bContinueStrengthen;
			}
			set
			{
				this.bContinueStrengthen = value;
				DataManager<StrengthenDataManager>.GetInstance().IsStrengthenContinue = value;
			}
		}

		// Token: 0x17001DA3 RID: 7587
		// (get) Token: 0x060114A1 RID: 70817 RVA: 0x004FCE79 File Offset: 0x004FB279
		public static ItemData CurrentSelectItemData
		{
			get
			{
				return StrengthenView.mCurrentSelectItemData;
			}
		}

		// Token: 0x060114A2 RID: 70818 RVA: 0x004FCE80 File Offset: 0x004FB280
		private void Awake()
		{
			this.RegisterUIEvent();
		}

		// Token: 0x060114A3 RID: 70819 RVA: 0x004FCE88 File Offset: 0x004FB288
		private void OnDestroy()
		{
			this.UnRegisterUIEvent();
			this.ClearData();
		}

		// Token: 0x060114A4 RID: 70820 RVA: 0x004FCE98 File Offset: 0x004FB298
		private void ClearData()
		{
			this._UnInitStrengthenTabs();
			this._UnInitStrengthenAttribute();
			this.m_kProtectedItemData = null;
			this.m_akNeedCostMaterials.DestroyAllObjects();
			this.m_akNeedCostMaterials1.DestroyAllObjects();
			this.m_bContinueStrengthen = false;
			this.m_akData.Clear();
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._DelaySendStrengthen));
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._ContinueStrengthDelyInvoke));
			InvokeMethod.RemoveInvokeCall(this);
			this.m_kCurrent = null;
			this.linkData = null;
			this.mStrengthenGrowthView = null;
			StrengthenView.mCurrentSelectItemData = null;
			this.iLastStrengthenTargetLevel = 0;
			this.mStrengthenDeviceItemData = null;
		}

		// Token: 0x060114A5 RID: 70821 RVA: 0x004FCF31 File Offset: 0x004FB331
		public sealed override void IniteData(SmithShopNewLinkData linkData, StrengthenGrowthType type, StrengthenGrowthView strengthenGrowthView)
		{
			this.linkData = linkData;
			this.mType = type;
			this.mStrengthenGrowthView = strengthenGrowthView;
			this.InitBaseInfo();
		}

		// Token: 0x060114A6 RID: 70822 RVA: 0x004FCF4E File Offset: 0x004FB34E
		public sealed override void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x060114A7 RID: 70823 RVA: 0x004FCF56 File Offset: 0x004FB356
		public sealed override void OnEnableView()
		{
			this.RegisterDelegateHandler();
		}

		// Token: 0x060114A8 RID: 70824 RVA: 0x004FCF60 File Offset: 0x004FB360
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x060114A9 RID: 70825 RVA: 0x004FCFE0 File Offset: 0x004FB3E0
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x060114AA RID: 70826 RVA: 0x004FD060 File Offset: 0x004FB460
		private void RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthChanged, new ClientEventSystem.UIEventHandler(this._OnStrengthChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BeginContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnStartContinueStrengthen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EndContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnEndContinueStrengthen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.IntterruptContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnInterruptContinueStrengthen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StrengthenDelay, new ClientEventSystem.UIEventHandler(this._OnStrengthenDelay));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.StrengthenCanceled, new ClientEventSystem.UIEventHandler(this._StrengthenCanceled));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailStrenghthenStart, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailStrenghthenCanceled, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenCanceled));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSpecailStrenghthenFailed, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenError, new ClientEventSystem.UIEventHandler(this.OnStrengthenError));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Combine(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			this.RegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x060114AB RID: 70827 RVA: 0x004FD234 File Offset: 0x004FB634
		private void UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthChanged, new ClientEventSystem.UIEventHandler(this._OnStrengthChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnItemStrengthenFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BeginContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnStartContinueStrengthen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EndContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnEndContinueStrengthen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.IntterruptContineStrengthen, new ClientEventSystem.UIEventHandler(this._OnInterruptContinueStrengthen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StrengthenDelay, new ClientEventSystem.UIEventHandler(this._OnStrengthenDelay));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.StrengthenCanceled, new ClientEventSystem.UIEventHandler(this._StrengthenCanceled));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailStrenghthenStart, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailStrenghthenCanceled, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenCanceled));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSpecailStrenghthenFailed, new ClientEventSystem.UIEventHandler(this.OnSpecailStrenghthenFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenError, new ClientEventSystem.UIEventHandler(this.OnStrengthenError));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipmentListNoEquipment, new ClientEventSystem.UIEventHandler(this.OnEquipmentListNoEquipment));
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = (OnStrengthenGrowthEquipItemClick)Delegate.Remove(StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick, new OnStrengthenGrowthEquipItemClick(this.OnStrengthenGrowthEquipItemClick));
			this.UnRegisterDelegateHandler();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x060114AC RID: 70828 RVA: 0x004FD407 File Offset: 0x004FB807
		private bool BCheckIsUpdateFrame()
		{
			return StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.EquipType == EEquipType.ET_COMMON;
		}

		// Token: 0x060114AD RID: 70829 RVA: 0x004FD428 File Offset: 0x004FB828
		private void _OnStrengthChanged(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (this.toggleProtected.isOn)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
				if (ownedItemCount <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_coupon"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					this.m_bOnStart = false;
					this.toggleProtected.isOn = false;
					return;
				}
			}
			if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData == null)
			{
				this.m_bOnStart = false;
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			this.m_kGray.enabled = true;
			this.m_kBtnStrength.enabled = false;
			this.m_kFrontGround.CustomActive(true);
			this.m_kBtnStop.CustomActive(this.m_bOnStart || this.m_bContinueStrengthen);
			if (this.m_kComStrengthenEffect != null)
			{
				this.m_kComStrengthenEffect.Play("NewStrengthenEffect");
			}
		}

		// Token: 0x060114AE RID: 70830 RVA: 0x004FD524 File Offset: 0x004FB924
		private void _OnItemStrengthenSuccess(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.m_bOnStart = false;
			this.mCurrentSelectStrengthStampItemData = null;
			StrengthenResult strengthenResult = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenResult();
			InvokeMethod.Invoke(0.5f, delegate()
			{
				this._OnCloseStrengthEffect(uiEvent);
			});
			if (this.m_bContinueStrengthen)
			{
				this.m_akData.Add(strengthenResult);
				if (StrengthenView.mCurrentSelectItemData.StrengthenLevel >= this.iLastStrengthenTargetLevel)
				{
					StrengthenResultUserData userData = new StrengthenResultUserData
					{
						uiCode = strengthenResult.code,
						EquipData = strengthenResult.EquipData,
						BrokenItems = strengthenResult.BrokenItems,
						bContinue = this.m_bContinueStrengthen
					};
					this._OnOpenStrengthenResultFrame(userData);
					InvokeMethod.Invoke(2f, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
						this._OnSucceedContinueStrengthen(this.m_akData);
						this.m_akData.Clear();
					});
				}
				else
				{
					StrengthenResultUserData userData2 = new StrengthenResultUserData
					{
						uiCode = strengthenResult.code,
						EquipData = strengthenResult.EquipData,
						BrokenItems = strengthenResult.BrokenItems,
						bContinue = this.m_bContinueStrengthen
					};
					this._OnOpenStrengthenResultFrame(userData2);
					InvokeMethod.Invoke(2f, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
						Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
						this._TryOpenNextContinueStrength(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
						{
							this._OnStopContinueStrengthen(eResult, this.m_akData, bStopByHand);
							this.m_akData.Clear();
						});
					});
				}
			}
			else
			{
				StrengthenResultUserData userData3 = new StrengthenResultUserData
				{
					uiCode = strengthenResult.code,
					EquipData = strengthenResult.EquipData,
					BrokenItems = strengthenResult.BrokenItems,
					bContinue = this.m_bContinueStrengthen,
					NeedBeforeAnimation = this.bSpecialStrengthen
				};
				this.bSpecialStrengthen = false;
				this.iLastStrengthenTargetLevel = 0;
				this._OnOpenStrengthenResultFrame(userData3);
			}
		}

		// Token: 0x060114AF RID: 70831 RVA: 0x004FD6C0 File Offset: 0x004FBAC0
		private void _OnCloseStrengthEffect(UIEvent uiEvent)
		{
			if (this.m_kComStrengthenEffect != null)
			{
				this.m_kComStrengthenEffect.Stop("NewStrengthenEffect");
			}
			if (this.m_kGray != null)
			{
				this.m_kGray.enabled = this.m_bContinueStrengthen;
			}
			if (this.m_kBtnStrength != null)
			{
				this.m_kBtnStrength.enabled = !this.m_bContinueStrengthen;
			}
			if (!this.m_bContinueStrengthen)
			{
				this.m_kFrontGround.CustomActive(false);
			}
		}

		// Token: 0x060114B0 RID: 70832 RVA: 0x004FD74C File Offset: 0x004FBB4C
		private void _OnOpenStrengthenResultFrame(object userData)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenResultFrame>(FrameLayer.Middle, userData, string.Empty);
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060114B1 RID: 70833 RVA: 0x004FD76C File Offset: 0x004FBB6C
		private void _OnSucceedContinueStrengthen(List<StrengthenResult> results)
		{
			List<StrengthenResult> list = new List<StrengthenResult>();
			list.AddRange(results);
			StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData userData = new StrengthenContinueResultsFrame.StrengthenContinueResultsFrameData
			{
				bStopByHandle = false,
				eLastOpResult = Utility.StrengthOperateResult.SOR_OK,
				iTarget = this.iLastStrengthenTargetLevel,
				results = list
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			this.m_bContinueStrengthen = false;
			this.iLastStrengthenTargetLevel = 0;
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			this.m_kFrontGround.CustomActive(false);
		}

		// Token: 0x060114B2 RID: 70834 RVA: 0x004FD7F8 File Offset: 0x004FBBF8
		private bool _TryOpenNextContinueStrength(ref Utility.StrengthOperateResult eResult, UnityAction<Utility.StrengthOperateResult, bool> onCancel)
		{
			if (!this.m_bContinueStrengthen)
			{
				return false;
			}
			this.m_bContinueStrengthen = false;
			int strengthenLevel = StrengthenView.mCurrentSelectItemData.StrengthenLevel;
			if (strengthenLevel >= 10)
			{
				return false;
			}
			if (strengthenLevel >= this.iLastStrengthenTargetLevel)
			{
				return false;
			}
			if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData == null)
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
			if (!this.mStrengthenImplementToggle.isOn)
			{
				eResult = Utility.CheckStrengthenItem(StrengthenView.mCurrentSelectItemData, false);
				if (eResult != Utility.StrengthOperateResult.SOR_OK)
				{
					if (onCancel != null)
					{
						onCancel.Invoke(eResult, false);
					}
					return false;
				}
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				int num = this._GetStrengthNeedMoney(StrengthenView.mCurrentSelectItemData);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, false);
				bool flag = num <= ownedItemCount;
				if (!this.m_bNeedContinueStrengthGoldCostHint || flag)
				{
					this._ConfirmContinueStrength();
				}
				else
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
					{
						nMoneyID = moneyIDByType,
						nCount = num
					}, delegate
					{
						this.m_bNeedContinueStrengthGoldCostHint = false;
						this._ConfirmContinueStrength();
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
				this._ConfirmContinueStrength();
			}
			return true;
		}

		// Token: 0x060114B3 RID: 70835 RVA: 0x004FD96C File Offset: 0x004FBD6C
		private void _ConfirmContinueStrength()
		{
			this.m_bContinueStrengthen = true;
			this.m_iContinueTimes++;
			if (this.m_kTextStrengthHint != null)
			{
				this.m_kTextStrengthHint.text = string.Format(TR.Value("strengthen_dynamic_level"), this.iLastStrengthenTargetLevel, this.m_iContinueTimes);
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(453, string.Empty, string.Empty);
			float fDelyTime = (tableItem != null) ? ((float)tableItem.Value / 1000f) : 0.7f;
			this._OnStrengthChanged(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._ContinueStrengthDelyInvoke));
			InvokeMethod.Invoke(fDelyTime, new UnityAction(this._ContinueStrengthDelyInvoke));
		}

		// Token: 0x060114B4 RID: 70836 RVA: 0x004FDA34 File Offset: 0x004FBE34
		private void _ContinueStrengthDelyInvoke()
		{
			if (!this.m_bContinueStrengthen)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (this.mStrengthenImplementToggle.isOn && this.toggleProtected.isOn)
			{
				DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 3, this.mStrengthenDeviceItemData.GUID);
			}
			else if (this.mStrengthenImplementToggle.isOn)
			{
				DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 2, this.mStrengthenDeviceItemData.GUID);
			}
			else if (this.toggleProtected.isOn)
			{
				DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 1, 0UL);
			}
			else
			{
				DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 0, 0UL);
			}
		}

		// Token: 0x060114B5 RID: 70837 RVA: 0x004FDB04 File Offset: 0x004FBF04
		private void _OnStopContinueStrengthen(Utility.StrengthOperateResult eResult, List<StrengthenResult> results, bool bStopByHand)
		{
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
					iTarget = this.iLastStrengthenTargetLevel,
					results = list
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			this.iLastStrengthenTargetLevel = 0;
			this.m_kFrontGround.CustomActive(false);
			this.m_bContinueStrengthen = false;
			this.m_iContinueTimes = 0;
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
		}

		// Token: 0x060114B6 RID: 70838 RVA: 0x004FDBAC File Offset: 0x004FBFAC
		private void _OnItemStrengthenFail(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.m_bOnStart = false;
			InvokeMethod.Invoke(0.5f, delegate()
			{
				this._OnCloseStrengthEffect(uiEvent);
			});
			StrengthenResult strengthenResult = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenResult();
			StrengthenResultUserData userData = new StrengthenResultUserData
			{
				uiCode = strengthenResult.code,
				EquipData = strengthenResult.EquipData,
				BrokenItems = strengthenResult.BrokenItems,
				bContinue = this.m_bContinueStrengthen
			};
			if (strengthenResult.code == 1000019U)
			{
				DataManager<StrengthenDataManager>.GetInstance().IsEquipmentStrengthBroken = true;
			}
			this._OnOpenStrengthenResultFrame(userData);
			if (this.m_bContinueStrengthen)
			{
				this.m_akData.Add(strengthenResult);
				InvokeMethod.Invoke(1f, delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
					Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
					this._TryOpenNextContinueStrength(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
					{
						this._OnStopContinueStrengthen(eResult, this.m_akData, bStopByHand);
						this.m_akData.Clear();
					});
				});
			}
		}

		// Token: 0x060114B7 RID: 70839 RVA: 0x004FDC88 File Offset: 0x004FC088
		private void _OnStartContinueStrengthen(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData.StrengthenLevel >= 10)
			{
				return;
			}
			this.m_bNeedContinueStrengthGoldCostHint = true;
			this.m_bContinueStrengthen = true;
			this.m_bNeedContinueStrengthGoldCostHint = true;
			this.m_iContinueTimes = 0;
			Utility.StrengthOperateResult strengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
			this._TryOpenNextContinueStrength(ref strengthOperateResult, delegate(Utility.StrengthOperateResult eResult, bool bStopByHand)
			{
				this._OnStopContinueStrengthen(eResult, this.m_akData, bStopByHand);
				this.m_akData.Clear();
			});
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
		}

		// Token: 0x060114B8 RID: 70840 RVA: 0x004FDD0C File Offset: 0x004FC10C
		private void _OnEndContinueStrengthen(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.m_iContinueTimes = 0;
			this.m_bContinueStrengthen = false;
			this._OnCloseStrengthEffect(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._ContinueStrengthDelyInvoke));
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
		}

		// Token: 0x060114B9 RID: 70841 RVA: 0x004FDD68 File Offset: 0x004FC168
		private void _OnInterruptContinueStrengthen(UIEvent uiEvent)
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
					iTarget = this.iLastStrengthenTargetLevel,
					results = list
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueResultsFrame>(FrameLayer.Middle, userData, string.Empty);
			}
			this.m_bContinueStrengthen = false;
			this._OnCloseStrengthEffect(null);
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._ContinueStrengthDelyInvoke));
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			this.m_kFrontGround.CustomActive(false);
		}

		// Token: 0x060114BA RID: 70842 RVA: 0x004FDE30 File Offset: 0x004FC230
		private void _OnStrengthenDelay(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(452, string.Empty, string.Empty);
			float fDelyTime = (tableItem != null) ? ((float)tableItem.Value / 1000f) : 1.62f;
			InvokeMethod.RemoveInvokeCall(new UnityAction(this._DelaySendStrengthen));
			InvokeMethod.Invoke(fDelyTime, new UnityAction(this._DelaySendStrengthen));
		}

		// Token: 0x060114BB RID: 70843 RVA: 0x004FDEA4 File Offset: 0x004FC2A4
		private void _StrengthenCanceled(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.m_bOnStart = false;
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
		}

		// Token: 0x060114BC RID: 70844 RVA: 0x004FDED4 File Offset: 0x004FC2D4
		private void OnSpecailStrenghthenStart(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData == null || this.mCurrentSelectStrengthStampItemData == null)
			{
				return;
			}
			this.m_kGray.enabled = true;
			this.m_kBtnStrength.enabled = false;
			this.m_kFrontGround.CustomActive(true);
			this.m_kBtnStop.CustomActive(false);
			this.m_bOnStart = true;
			this.bSpecialStrengthen = true;
			DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 0, this.mCurrentSelectStrengthStampItemData.GUID);
		}

		// Token: 0x060114BD RID: 70845 RVA: 0x004FDF5C File Offset: 0x004FC35C
		private void OnSpecailStrenghthenCanceled(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this._OnCloseStrengthEffect(null);
			this.m_kFrontGround.CustomActive(false);
			this.m_bOnStart = false;
		}

		// Token: 0x060114BE RID: 70846 RVA: 0x004FDF84 File Offset: 0x004FC384
		private void OnSpecailStrenghthenFailed(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.OnSpecailStrenghthenCanceled(null);
			this.mCurrentSelectStrengthStampItemData = null;
			StrengthenResult strengthenResult = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenResult();
			StrengthenResultUserData userData = new StrengthenResultUserData
			{
				uiCode = strengthenResult.code,
				EquipData = strengthenResult.EquipData,
				BrokenItems = strengthenResult.BrokenItems,
				bContinue = this.m_bContinueStrengthen,
				NeedBeforeAnimation = true
			};
			this.bSpecialStrengthen = false;
			this._OnOpenStrengthenResultFrame(userData);
		}

		// Token: 0x060114BF RID: 70847 RVA: 0x004FE003 File Offset: 0x004FC403
		private void OnStrengthenError(UIEvent uiEvent)
		{
			if (!this.BCheckIsUpdateFrame())
			{
				return;
			}
			this.OnSpecailStrenghthenCanceled(uiEvent);
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060114C0 RID: 70848 RVA: 0x004FE024 File Offset: 0x004FC424
		private void OnEquipmentListNoEquipment(UIEvent uiEvent)
		{
			StrengthenView.mCurrentSelectItemData = null;
			this._UpdateStrengthenMaterials(null);
			if (this.mName != null)
			{
				this.mName.text = string.Empty;
			}
			if (this.mCurrentStrengthLevel != null)
			{
				this.mCurrentStrengthLevel.text = string.Empty;
			}
			if (this.mTargetStrengthLevel != null)
			{
				this.mTargetStrengthLevel.text = string.Empty;
			}
		}

		// Token: 0x060114C1 RID: 70849 RVA: 0x004FE0A4 File Offset: 0x004FC4A4
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
				this.iLastStrengthenTargetLevel = (int)num;
				this.UpdateStrengthenTargetLevel(this.iLastStrengthenTargetLevel);
			}
			else if (commonKeyBoardInputType == CommonKeyBoardInputType.Finished)
			{
				this.iLastStrengthenTargetLevel = Mathf.Clamp(this.iLastStrengthenTargetLevel, this.iMinStrengthenLevel, 10);
				this.UpdateStrengthenTargetLevel(this.iLastStrengthenTargetLevel);
				this._UpdateStrengthenAttribute(StrengthenView.mCurrentSelectItemData, this.iLastStrengthenTargetLevel);
			}
		}

		// Token: 0x060114C2 RID: 70850 RVA: 0x004FE144 File Offset: 0x004FC544
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
					this._TryUpdateMaterial(item.TableID);
				}
			}
			if (flag)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
		}

		// Token: 0x060114C3 RID: 70851 RVA: 0x004FE1D0 File Offset: 0x004FC5D0
		private void OnRemoveItem(ItemData itemData)
		{
			if (StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.GUID == itemData.GUID && !this.m_bOnStart && !this.m_bContinueStrengthen)
			{
				this.mStrengthenGrowthView.RefreshAllEquipments();
			}
			this._TryUpdateMaterial(itemData.TableID);
		}

		// Token: 0x060114C4 RID: 70852 RVA: 0x004FE22C File Offset: 0x004FC62C
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
						this._TryUpdateMaterial(item.TableID);
					}
				}
			}
		}

		// Token: 0x060114C5 RID: 70853 RVA: 0x004FE291 File Offset: 0x004FC691
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
		}

		// Token: 0x060114C6 RID: 70854 RVA: 0x004FE2B0 File Offset: 0x004FC6B0
		private void InitBaseInfo()
		{
			this.m_kCurrent = ComItemManager.Create(this.goItemParent);
			this.m_kCurrent.Setup(null, null);
			this.m_kBtnStop.CustomActive(false);
			if (this.toggleProtected != null)
			{
				this.toggleProtected.onValueChanged.RemoveAllListeners();
				this.toggleProtected.onValueChanged.AddListener(delegate(bool bValue)
				{
					this._OnUseProtected(bValue);
				});
			}
			if (this.mStrengthenImplementToggle != null)
			{
				this.mStrengthenImplementToggle.onValueChanged.RemoveAllListeners();
				this.mStrengthenImplementToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnStrengthenImplementClick));
			}
			this.imgProtectedIcon.color = this.colorGray;
			this.m_goMaterialPrefab.CustomActive(false);
			if (this.m_btnProtected != null)
			{
				this.m_btnProtected.onClick.RemoveAllListeners();
				this.m_btnProtected.onClick.AddListener(new UnityAction(this.OnClickProtected));
			}
			if (this.m_btnComLinkStrengthenProtected != null)
			{
				this.m_btnComLinkStrengthenProtected.onClick.RemoveAllListeners();
				this.m_btnComLinkStrengthenProtected.onClick.AddListener(new UnityAction(this._OnClickLinkToStrengthenProtected));
			}
			if (this.m_btnSpecialStrength != null)
			{
				this.m_btnSpecialStrength.onClick.RemoveAllListeners();
				this.m_btnSpecialStrength.onClick.AddListener(new UnityAction(this.OnClickSpecialStrength));
			}
			if (this.m_btnStrength != null)
			{
				this.m_btnStrength.onClick.RemoveAllListeners();
				this.m_btnStrength.onClick.AddListener(new UnityAction(this.OnClickStrength));
			}
			if (this.m_btnStrengthContinue != null)
			{
				this.m_btnStrengthContinue.onClick.RemoveAllListeners();
				this.m_btnStrengthContinue.onClick.AddListener(new UnityAction(this.OnClickStrengthContinue));
			}
			if (this.m_btnStop != null)
			{
				this.m_btnStop.onClick.RemoveAllListeners();
				this.m_btnStop.onClick.AddListener(new UnityAction(this.OnClickStop));
			}
			if (this.m_StrengthenStampBtn != null)
			{
				this.m_StrengthenStampBtn.onClick.RemoveAllListeners();
				this.m_StrengthenStampBtn.onClick.AddListener(new UnityAction(this.OnOpenExpendFrameBtnClick));
			}
			if (this.mInputStrengthenLevelBtn != null)
			{
				this.mInputStrengthenLevelBtn.onClick.RemoveAllListeners();
				this.mInputStrengthenLevelBtn.onClick.AddListener(delegate()
				{
					CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(288f, -85f, 0f), 0UL, 10UL);
				});
			}
			this._UpdateStrengthenMaterials(null);
			this._InitStrengthenTabs();
			this._InitStrengthenAttribute();
			if (this.mStrengthenDeviceItem != null)
			{
				this.mStrengthenDeviceItem.InitItem(StrengthenGrowthType.SGT_Strengthen, new OnStrengthenDeviceItem(this.OnStrengthenDeviceItem));
			}
		}

		// Token: 0x060114C7 RID: 70855 RVA: 0x004FE5B8 File Offset: 0x004FC9B8
		private void OnStrengthenImplementToggleClick(bool value)
		{
		}

		// Token: 0x060114C8 RID: 70856 RVA: 0x004FE5BC File Offset: 0x004FC9BC
		private void OnClickProtected()
		{
			if (this.m_kProtectedItemData == null)
			{
				this.m_kProtectedItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(200000310);
			}
			if (this.m_kProtectedItemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(this.m_kProtectedItemData, null, 4, true, false, true);
			}
		}

		// Token: 0x060114C9 RID: 70857 RVA: 0x004FE60C File Offset: 0x004FCA0C
		private void _OnClickLinkToStrengthenProtected()
		{
			ItemComeLink.OnLink(200000310, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x060114CA RID: 70858 RVA: 0x004FE630 File Offset: 0x004FCA30
		private void OnClickSpecialStrength()
		{
			if (this.m_bOnStart)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mCurrentSelectStrengthStampItemData == null)
			{
				List<ItemData> strengthenStampList = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenStampList(StrengthenView.mCurrentSelectItemData);
				if (strengthenStampList.Count > 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_special_need_protected"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					this.comConponLink.bNotEnough = false;
					this.comConponLink.OnClickLink();
					this.comConponLink.bNotEnough = false;
				}
				return;
			}
			int num;
			bool flag;
			this.mCurrentSelectStrengthStampItemData.GetLimitTimeLeft(out num, out flag);
			if (num <= 0 && flag)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			StrengthenSpecialConfirmFrameData userData = new StrengthenSpecialConfirmFrameData
			{
				equipData = StrengthenView.mCurrentSelectItemData,
				itemData = this.mCurrentSelectStrengthStampItemData
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenSpecialConfirmFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x060114CB RID: 70859 RVA: 0x004FE728 File Offset: 0x004FCB28
		private void OnClickStrength()
		{
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法强化", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.iLastStrengthenTargetLevel - StrengthenView.mCurrentSelectItemData.StrengthenLevel > 1)
			{
				this.OnClickStrengthContinue();
			}
			else
			{
				this._StrengthenEx();
			}
		}

		// Token: 0x060114CC RID: 70860 RVA: 0x004FE7A0 File Offset: 0x004FCBA0
		private void _StrengthenEx()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
			if (this.m_bOnStart)
			{
				return;
			}
			if (this.toggleProtected.isOn)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
				if (ownedItemCount <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_coupon"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					this.m_bOnStart = false;
					this.toggleProtected.isOn = false;
					return;
				}
			}
			if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				this.m_bOnStart = false;
				return;
			}
			this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			if (!this.mStrengthenImplementToggle.isOn)
			{
				if (this.m_eStrengthOperateResult != Utility.StrengthOperateResult.SOR_OK)
				{
					switch (this.m_eStrengthOperateResult)
					{
					case Utility.StrengthOperateResult.SOR_UNCOLOR:
					case Utility.StrengthOperateResult.SOR_COLOR:
					case Utility.StrengthOperateResult.SOR_GOLD:
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.STRENGEN_NO_RESOURCE, delegate
						{
							this._OnPopUpComeLink(this.m_eStrengthOperateResult);
						});
						break;
					default:
						this._OnPopUpComeLink(this.m_eStrengthOperateResult);
						break;
					}
					return;
				}
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
				int nCount = this._GetStrengthNeedMoney(StrengthenView.mCurrentSelectItemData);
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = moneyIDByType,
					nCount = nCount
				}, new Action(this._ConfirmStrength), "common_money_cost", null);
			}
			else
			{
				this._ConfirmStrength();
			}
		}

		// Token: 0x060114CD RID: 70861 RVA: 0x004FE928 File Offset: 0x004FCD28
		private void OnClickStrengthContinue()
		{
			if (StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.bLocked)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("已加锁的装备无法强化", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<StrengthenResultFrame>(null, true);
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				return;
			}
			if (this.m_bContinueStrengthen)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData.StrengthenLevel >= 10)
			{
				return;
			}
			if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_implement"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!this.mStrengthenImplementToggle.isOn)
			{
				Utility.StrengthOperateResult eResult = Utility.CheckStrengthenItem(StrengthenView.mCurrentSelectItemData, false);
				if (eResult != Utility.StrengthOperateResult.SOR_OK)
				{
					switch (eResult)
					{
					case Utility.StrengthOperateResult.SOR_UNCOLOR:
					case Utility.StrengthOperateResult.SOR_COLOR:
					case Utility.StrengthOperateResult.SOR_GOLD:
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.TryShowMallGift(MallGiftPackActivateCond.STRENGEN_NO_RESOURCE, delegate
						{
							this._OnPopUpComeLink(eResult);
						});
						break;
					default:
						this._OnPopUpComeLink(eResult);
						break;
					}
					return;
				}
			}
			this.m_kFrontGround.CustomActive(true);
			this.m_kBtnStop.CustomActive(false);
			this.m_akData.Clear();
			StrengthenConfirmData userData = new StrengthenConfirmData
			{
				ItemData = StrengthenView.mCurrentSelectItemData,
				UseProtect = false,
				TargetStrengthenLevel = this.iLastStrengthenTargetLevel
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenContinueConfirm>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x060114CE RID: 70862 RVA: 0x004FEAB4 File Offset: 0x004FCEB4
		private void OnClickStop()
		{
			if (this.m_bOnStart)
			{
				InvokeMethod.RemoveInvokeCall(new UnityAction(this._DelaySendStrengthen));
				this.m_bOnStart = false;
				this._OnCloseStrengthEffect(null);
				this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			}
			if (this.m_bContinueStrengthen)
			{
				this._OnInterruptContinueStrengthen(null);
			}
			this.iLastStrengthenTargetLevel = 0;
			this.mStrengthenGrowthView.RefreshAllEquipments();
		}

		// Token: 0x060114CF RID: 70863 RVA: 0x004FEB2C File Offset: 0x004FCF2C
		private void OnOpenExpendFrameBtnClick()
		{
			List<ItemData> strengthenStampList = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenStampList(StrengthenView.mCurrentSelectItemData);
			if (strengthenStampList.Count > 0)
			{
				GrowthExpendData growthExpendData = new GrowthExpendData();
				growthExpendData.mStrengthenGrowthType = this.mType;
				growthExpendData.mEquipItemData = StrengthenView.mCurrentSelectItemData;
				growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.OnStrengthenStampItemClick);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GrowthExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
			}
			else
			{
				ItemComeLink.OnLink(80, 0, true, null, false, false, false, null, string.Empty);
			}
		}

		// Token: 0x060114D0 RID: 70864 RVA: 0x004FEBB0 File Offset: 0x004FCFB0
		private void OnStrengthenStampItemClick(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mCurrentSelectStrengthStampItemData = itemData;
			if (this.mStrengthenStampComItem != null)
			{
				this.mStrengthenStampComItem.Setup(this.mCurrentSelectStrengthStampItemData, delegate(GameObject obj, ItemData item)
				{
					this.OnOpenExpendFrameBtnClick();
				});
				this.mStrengthenStampComItem.CustomActive(true);
			}
			if (this.mStrengthenStampName != null)
			{
				this.mStrengthenStampName.text = this.mCurrentSelectStrengthStampItemData.GetColorName(string.Empty, false);
			}
			StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(this.mCurrentSelectStrengthStampItemData.TableData.StrenTicketDataIndex, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.iLastStrengthenTargetLevel = tableItem.Level;
				this.UpdateStrengthenTargetLevel(this.iLastStrengthenTargetLevel);
				this._UpdateStrengthenAttribute(StrengthenView.mCurrentSelectItemData, this.iLastStrengthenTargetLevel);
			}
			if (this.m_StrengthenStampBtn != null)
			{
				this.m_StrengthenStampBtn.enabled = false;
			}
		}

		// Token: 0x060114D1 RID: 70865 RVA: 0x004FECA3 File Offset: 0x004FD0A3
		private int _GetStrengthNeedMoney(ItemData itemData)
		{
			if (this._GetCost(ref itemData, ref this.m_costNeed))
			{
				return this.m_costNeed.GoldCost;
			}
			return 0;
		}

		// Token: 0x060114D2 RID: 70866 RVA: 0x004FECC8 File Offset: 0x004FD0C8
		private bool _GetCost(ref ItemData data, ref StrengthenCost costNeed)
		{
			if (DataManager<StrengthenDataManager>.GetInstance().GetCost(data.StrengthenLevel, data.LevelLimit, data.Quality, ref costNeed))
			{
				if (data.SubType == 1)
				{
					float num = 1f;
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(21, string.Empty, string.Empty);
					if (tableItem != null)
					{
						num = (float)tableItem.Value / 10f;
					}
					costNeed.ColorCost = Utility.ceil((float)costNeed.ColorCost * num);
					costNeed.UnColorCost = Utility.ceil((float)costNeed.UnColorCost * num);
					costNeed.GoldCost = Utility.ceil((float)costNeed.GoldCost * num);
				}
				else if (data.SubType >= 2 && data.SubType <= 6)
				{
					float num2 = 1f;
					SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(22, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						num2 = (float)tableItem2.Value / 10f;
					}
					costNeed.ColorCost = Utility.ceil((float)costNeed.ColorCost * num2);
					costNeed.UnColorCost = Utility.ceil((float)costNeed.UnColorCost * num2);
					costNeed.GoldCost = Utility.ceil((float)costNeed.GoldCost * num2);
				}
				else if (data.SubType >= 7 && data.SubType <= 9)
				{
					float num3 = 1f;
					SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(23, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						num3 = (float)tableItem3.Value / 10f;
					}
					costNeed.ColorCost = Utility.ceil((float)costNeed.ColorCost * num3);
					costNeed.UnColorCost = Utility.ceil((float)costNeed.UnColorCost * num3);
					costNeed.GoldCost = Utility.ceil((float)costNeed.GoldCost * num3);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060114D3 RID: 70867 RVA: 0x004FEE98 File Offset: 0x004FD298
		private void _OnPopUpComeLink(Utility.StrengthOperateResult eResult)
		{
			switch (eResult)
			{
			case Utility.StrengthOperateResult.SOR_HAS_NO_ITEM:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_UNCOLOR:
				ItemComeLink.OnLink(this.m_id0, 0, true, new ComLinkFrame.OnClick(this.CloseSmithShopNewFrame), false, false, false, null, string.Empty);
				break;
			case Utility.StrengthOperateResult.SOR_COLOR:
				ItemComeLink.OnLink(this.m_id1, 0, true, new ComLinkFrame.OnClick(this.CloseSmithShopNewFrame), false, false, false, null, string.Empty);
				break;
			case Utility.StrengthOperateResult.SOR_GOLD:
				ItemComeLink.OnLink(this.m_id3, 0, true, new ComLinkFrame.OnClick(this.CloseSmithShopNewFrame), false, false, false, null, string.Empty);
				break;
			}
		}

		// Token: 0x060114D4 RID: 70868 RVA: 0x004FEF4A File Offset: 0x004FD34A
		private void CloseSmithShopNewFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
		}

		// Token: 0x060114D5 RID: 70869 RVA: 0x004FEF58 File Offset: 0x004FD358
		private void _OnUseProtected(bool bUse)
		{
			if (!bUse)
			{
				this.m_bUseProtected = bUse;
				this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
				this.imgProtectedIcon.color = this.colorGray;
				this.goUnuseProtectedHint.CustomActive(true);
				return;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
			if (ownedItemCount <= 0)
			{
				ItemComeLink.OnLink(200000310, 1, true, delegate
				{
					this.toggleProtected.isOn = true;
					this.imgProtectedIcon.color = Color.white;
					this.goUnuseProtectedHint.CustomActive(false);
					this._Ansy2();
				}, false, false, false, null, string.Empty);
				this.toggleProtected.isOn = false;
				this.imgProtectedIcon.color = this.colorGray;
				this.goUnuseProtectedHint.CustomActive(true);
				return;
			}
			this._Ansy2();
		}

		// Token: 0x060114D6 RID: 70870 RVA: 0x004FF020 File Offset: 0x004FD420
		private void _Ansy2()
		{
			if (StrengthenView.mCurrentSelectItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				this.toggleProtected.isOn = false;
				this.imgProtectedIcon.color = this.colorGray;
				this.goUnuseProtectedHint.CustomActive(true);
				return;
			}
			if (StrengthenView.mCurrentSelectItemData.StrengthenLevel < 10)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_lv_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				this.toggleProtected.isOn = false;
				this.imgProtectedIcon.color = this.colorGray;
				this.goUnuseProtectedHint.CustomActive(true);
				return;
			}
			this.m_bUseProtected = true;
			this.imgProtectedIcon.color = Color.white;
			this.goUnuseProtectedHint.CustomActive(false);
			this._UpdateStrengthenMaterials(StrengthenView.mCurrentSelectItemData);
		}

		// Token: 0x060114D7 RID: 70871 RVA: 0x004FF0F4 File Offset: 0x004FD4F4
		private void _InitStrengthenTabs()
		{
			GameObject goFilterGroup = this.m_goFilterGroup;
			GameObject[] array = new GameObject[]
			{
				this.m_goFilter0,
				this.m_goFilter1
			};
			GameObject[] array2 = new GameObject[]
			{
				this.m_goCostContent,
				this.m_goProtectedContent
			};
			for (int i = 0; i < 2; i++)
			{
				array[i].CustomActive(false);
				array2[i].CustomActive(false);
				this.m_akStrengthenTabs.Create((StrengthenView.StrengthenType)i, new object[]
				{
					goFilterGroup,
					array[i],
					i,
					array2[i],
					this
				});
			}
			if (this.linkData != null && this.linkData.iSmithShopNewOpenTypeId == 1)
			{
				this.m_akStrengthenTabs.GetObject(StrengthenView.StrengthenType.ST_PROTECTED_COUPON).toggle.isOn = true;
			}
			else
			{
				this.m_akStrengthenTabs.GetObject(StrengthenView.StrengthenType.ST_COST_METERIAL).toggle.isOn = true;
			}
		}

		// Token: 0x060114D8 RID: 70872 RVA: 0x004FF1DD File Offset: 0x004FD5DD
		private void OnStrengthenTabChanged(StrengthenView.StrengthenType eStrengthenType)
		{
			if (eStrengthenType == StrengthenView.StrengthenType.ST_COST_METERIAL)
			{
				this.iLastStrengthenTargetLevel = 0;
				this.mCurrentSelectStrengthStampItemData = null;
				this._UpdateStrengthenMaterials(StrengthenView.mCurrentSelectItemData);
			}
		}

		// Token: 0x060114D9 RID: 70873 RVA: 0x004FF1FE File Offset: 0x004FD5FE
		private void _UnInitStrengthenTabs()
		{
			StrengthenView.StrengthenTab.Clear();
			this.m_akStrengthenTabs.DestroyAllObjects();
		}

		// Token: 0x060114DA RID: 70874 RVA: 0x004FF210 File Offset: 0x004FD610
		private void OnStrengthenGrowthEquipItemClick(ItemData itemData, StrengthenGrowthType eStrengthenGrowthType)
		{
			if (itemData == null)
			{
				return;
			}
			if (StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.GUID != itemData.GUID)
			{
				this.iLastStrengthenTargetLevel = 0;
			}
			StrengthenView.mCurrentSelectItemData = itemData;
			if (eStrengthenGrowthType == this.mType)
			{
				this._UpdateStrengthenMaterials(itemData);
				this._OnSelectedChanged(itemData);
			}
		}

		// Token: 0x060114DB RID: 70875 RVA: 0x004FF26C File Offset: 0x004FD66C
		private void _TryUpdateMaterial(int iTableID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iTableID, string.Empty, string.Empty);
			if (tableItem != null && (tableItem.SubType == ItemTable.eSubType.GOLD || tableItem.SubType == ItemTable.eSubType.BindGOLD || iTableID == 200000310 || iTableID == 300000106 || iTableID == 300000105 || tableItem.Type == ItemTable.eType.MATERIAL))
			{
				this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			}
		}

		// Token: 0x060114DC RID: 70876 RVA: 0x004FF2F8 File Offset: 0x004FD6F8
		private void _OnSelectedChanged(ItemData selected)
		{
			StrengthenView.StrengthenTab @object = this.m_akStrengthenTabs.GetObject(StrengthenView.StrengthenType.ST_PROTECTED_COUPON);
			if (@object != null && @object.ComSmithFunctionBinder != null)
			{
				if (selected != null)
				{
					@object.ComSmithFunctionBinder.ClearCheckFunctions();
					@object.ComSmithFunctionBinder.SpecialItem = selected;
					@object.ComSmithFunctionBinder.AddCheckFunction(SmithFunctionRedBinder.SmithFunctionType.SFT_STRENGTH_SPECIAL);
				}
				else
				{
					@object.ComSmithFunctionBinder.SpecialItem = null;
					@object.ComSmithFunctionBinder.ClearCheckFunctions();
				}
			}
		}

		// Token: 0x060114DD RID: 70877 RVA: 0x004FF370 File Offset: 0x004FD770
		private bool StrengthenStampScopeofApplication(int equipLevel, int tableId)
		{
			bool result = false;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.LvAdaptation.Count >= 2)
				{
					int num = tableItem.LvAdaptation[0];
					int num2 = tableItem.LvAdaptation[1];
					if (equipLevel >= num && equipLevel <= num2)
					{
						result = true;
					}
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060114DE RID: 70878 RVA: 0x004FF3DE File Offset: 0x004FD7DE
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x060114DF RID: 70879 RVA: 0x004FF3F6 File Offset: 0x004FD7F6
		private void SetStrengthenStampInfo()
		{
			this.mCurrentSelectStrengthStampItemData = null;
			this.mStrengthenStampComItem.Setup(null, null);
			this.mStrengthenStampComItem.CustomActive(false);
			this.mStrengthenStampName.text = "请选择强化券";
			this.m_StrengthenStampBtn.enabled = true;
		}

		// Token: 0x060114E0 RID: 70880 RVA: 0x004FF434 File Offset: 0x004FD834
		private void SetStrengthenStampItem()
		{
			if (this.mStrengthenStampComItem == null)
			{
				this.mStrengthenStampComItem = ComItemManager.Create(this.m_goStrengthenStampParent);
			}
			if (this.mCurrentSelectStrengthStampItemData == null)
			{
				this.SetStrengthenStampInfo();
			}
			else if (this.mCurrentSelectStrengthStampItemData.SubType == 33)
			{
				StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(this.mCurrentSelectStrengthStampItemData.TableData.StrenTicketDataIndex, string.Empty, string.Empty);
				if (tableItem != null && StrengthenView.mCurrentSelectItemData != null && StrengthenView.mCurrentSelectItemData.StrengthenLevel >= tableItem.Level)
				{
					this.SetStrengthenStampInfo();
				}
			}
			else if (this.mCurrentSelectStrengthStampItemData.SubType == 147)
			{
				OneStrengEnhanceTicketTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<OneStrengEnhanceTicketTable>(this.mCurrentSelectStrengthStampItemData.TableID, string.Empty, string.Empty);
				if (tableItem2 != null && StrengthenView.mCurrentSelectItemData != null && (StrengthenView.mCurrentSelectItemData.StrengthenLevel < tableItem2.LvLimitBegin || StrengthenView.mCurrentSelectItemData.StrengthenLevel > tableItem2.LvLimitEnd))
				{
					this.SetStrengthenStampInfo();
				}
			}
		}

		// Token: 0x060114E1 RID: 70881 RVA: 0x004FF558 File Offset: 0x004FD958
		private void _UpdateStrengthenMaterials(ItemData itemData)
		{
			if (this.m_kCurrent == null)
			{
				return;
			}
			this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_HAS_NO_ITEM;
			this.SetStrengthenStampItem();
			if (itemData == null)
			{
				this.comStatus.Key = "null";
				this.m_kCurrent.Setup(null, null);
				this.m_akStrengthenAttributeItems.RecycleAllObject();
				this.mStrengthenImplementToggle.isOn = false;
				this.mStrengthenImplementToggle.CustomActive(false);
			}
			else
			{
				if (itemData.StrengthenLevel >= 20)
				{
					this.mStrengthenImplementToggle.isOn = false;
					this.mStrengthenImplementToggle.CustomActive(false);
				}
				else
				{
					this.mStrengthenImplementToggle.CustomActive(true);
				}
				if (this.iLastStrengthenTargetLevel != 0)
				{
					this.iMinStrengthenLevel = this.iLastStrengthenTargetLevel;
				}
				else
				{
					this.iMinStrengthenLevel = itemData.StrengthenLevel + 1;
				}
				this.iStrengthenNextLevel = this.iMinStrengthenLevel;
				this.UpdateStrengthenTargetLevel(this.iStrengthenNextLevel);
				this._UpdateStrengthenAttribute(itemData, this.iStrengthenNextLevel);
				this.m_kCurrent.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.mName.text = string.Format("强化+{0}", itemData.StrengthenLevel);
				if (!this.mStrengthenImplementToggle.isOn)
				{
					if (itemData.StrengthenLevel >= 10)
					{
						this.comStatus.Key = "level>=10";
					}
					else
					{
						this.comStatus.Key = "level<10";
					}
				}
				if (this.toggleProtected != null)
				{
					this.toggleProtected.CustomActive(itemData.StrengthenLevel >= 10);
				}
			}
			this.UpdateStrengthDeviceItem();
			if (this.m_bOnStart || this.m_bContinueStrengthen || itemData == null)
			{
				this.m_kBtnStrength.enabled = false;
				this.m_kGray.enabled = true;
			}
			else
			{
				this.m_kBtnStrength.enabled = true;
				this.m_kGray.enabled = false;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id0, true);
			int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id1, true);
			int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id3, true);
			int ownedItemCount4 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
			if (ownedItemCount4 >= 1)
			{
				this.m_kTextProtectedHint.text = string.Format(TR.Value("strength_protected_enough"), ownedItemCount4);
			}
			else
			{
				this.m_kTextProtectedHint.text = string.Format(TR.Value("strength_protected_not_enough"), ownedItemCount4);
				this.toggleProtected.isOn = false;
			}
			if (ownedItemCount4 >= 1 && itemData != null && itemData.StrengthenLevel < 10 && this.toggleProtected.isOn)
			{
				this.toggleProtected.isOn = false;
			}
			if (!this.m_bContinueStrengthen)
			{
				this.m_kTextStrengthHint.text = TR.Value("strengthen_fixed_level");
			}
			else
			{
				this.m_kTextStrengthHint.text = string.Format(TR.Value("strengthen_dynamic_level"), this.iLastStrengthenTargetLevel, this.m_iContinueTimes);
			}
			if (!this.mStrengthenImplementToggle.isOn)
			{
				this.m_akNeedCostMaterials.RecycleAllObject();
				this.m_akNeedCostMaterials1.RecycleAllObject();
				if (itemData == null)
				{
					int[] array = new int[]
					{
						this.m_id0,
						this.m_id1,
						this.m_id3
					};
					for (int i = 0; i < array.Length; i++)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(array[i]);
						if (commonItemTableDataByID != null)
						{
							if (this.m_akNeedCostMaterials.HasObject(array[i]))
							{
								this.m_akNeedCostMaterials.RefreshObject(array[i], new object[]
								{
									commonItemTableDataByID,
									true,
									0
								});
							}
							else
							{
								this.m_akNeedCostMaterials.Create(array[i], new object[]
								{
									this.m_goMaterialParent,
									this.m_goMaterialPrefab,
									commonItemTableDataByID,
									this,
									true,
									0
								});
							}
							if (this.m_akNeedCostMaterials1.HasObject(array[i]))
							{
								this.m_akNeedCostMaterials1.RefreshObject(array[i], new object[]
								{
									commonItemTableDataByID,
									true,
									0
								});
							}
							else
							{
								this.m_akNeedCostMaterials1.Create(array[i], new object[]
								{
									this.m_goMaterialParent1,
									this.m_goMaterialPrefab1,
									commonItemTableDataByID,
									this,
									true,
									0
								});
							}
						}
					}
					this.m_akNeedCostMaterials.Filter(null);
					this.m_akNeedCostMaterials1.Filter(null);
				}
				if (itemData != null)
				{
					this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_OK;
					if (this._GetCost(ref itemData, ref this.m_costNeed))
					{
						int[] array2 = new int[]
						{
							this.m_id0,
							this.m_id1,
							this.m_id3
						};
						int[] array3 = new int[]
						{
							this.m_costNeed.UnColorCost,
							this.m_costNeed.ColorCost,
							this.m_costNeed.GoldCost
						};
						for (int j = 0; j < array2.Length; j++)
						{
							ItemData commonItemTableDataByID2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(array2[j]);
							if (commonItemTableDataByID2 != null)
							{
								if (this.m_akNeedCostMaterials.HasObject(array2[j]))
								{
									this.m_akNeedCostMaterials.RefreshObject(array2[j], new object[]
									{
										commonItemTableDataByID2,
										false,
										array3[j]
									});
								}
								else
								{
									this.m_akNeedCostMaterials.Create(array2[j], new object[]
									{
										this.m_goMaterialParent,
										this.m_goMaterialPrefab,
										commonItemTableDataByID2,
										this,
										false,
										array3[j]
									});
								}
								if (this.m_akNeedCostMaterials1.HasObject(array2[j]))
								{
									this.m_akNeedCostMaterials1.RefreshObject(array2[j], new object[]
									{
										commonItemTableDataByID2,
										false,
										array3[j]
									});
								}
								else
								{
									this.m_akNeedCostMaterials1.Create(array2[j], new object[]
									{
										this.m_goMaterialParent1,
										this.m_goMaterialPrefab1,
										commonItemTableDataByID2,
										this,
										false,
										array3[j]
									});
								}
							}
						}
						this.m_akNeedCostMaterials.Filter(null);
						this.m_akNeedCostMaterials1.Filter(null);
						if (this.m_costNeed.UnColorCost > 0 && this.m_eStrengthOperateResult == Utility.StrengthOperateResult.SOR_OK)
						{
							int ownedItemCount5 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id0, true);
							if (ownedItemCount5 < this.m_costNeed.UnColorCost)
							{
								this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_UNCOLOR;
							}
						}
						if (this.m_costNeed.ColorCost > 0 && this.m_eStrengthOperateResult == Utility.StrengthOperateResult.SOR_OK)
						{
							int ownedItemCount6 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id1, true);
							if (ownedItemCount6 < this.m_costNeed.ColorCost)
							{
								this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_COLOR;
							}
						}
						if (this.m_costNeed.GoldCost > 0 && this.m_eStrengthOperateResult == Utility.StrengthOperateResult.SOR_OK)
						{
							int ownedItemCount7 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_id3, true);
							if (ownedItemCount7 < this.m_costNeed.GoldCost)
							{
								this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_GOLD;
							}
						}
					}
					else
					{
						this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_HAS_NO_ITEM;
					}
				}
				else
				{
					this.m_eStrengthOperateResult = Utility.StrengthOperateResult.SOR_HAS_NO_ITEM;
				}
			}
			int ownedItemCount8 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
			this.goProectedComeLink.CustomActive(ownedItemCount8 <= 0);
			this.comProtectedStatus.Key = ((!this.toggleProtected.isOn) ? "unuse" : "use");
			this.goUnuseProtectedHint.CustomActive(!this.toggleProtected.isOn);
		}

		// Token: 0x060114E2 RID: 70882 RVA: 0x004FFD70 File Offset: 0x004FE170
		private void _InitStrengthenAttribute()
		{
			this.m_goStrengthenAttributesPrefab.CustomActive(false);
		}

		// Token: 0x060114E3 RID: 70883 RVA: 0x004FFD80 File Offset: 0x004FE180
		private void _UpdateStrengthenAttribute(ItemData itemData, int nextStrengthenLevel)
		{
			if (this.m_akStrengthenAttributeItems != null)
			{
				this.m_akStrengthenAttributeItems.RecycleAllObject();
			}
			if (itemData != null)
			{
				if (this.mCurrentStrengthLevel != null)
				{
					this.mCurrentStrengthLevel.text = string.Format("当前强化:{0}级", itemData.StrengthenLevel);
				}
				if (this.mTargetStrengthLevel != null)
				{
					this.mTargetStrengthLevel.text = string.Format("目标强化:{0}级", nextStrengthenLevel);
				}
				if (itemData.IsAssistEquip())
				{
					List<StrengthenAttributeItemData> list = new List<StrengthenAttributeItemData>();
					List<StrengthenAttributeItemData> list2 = new List<StrengthenAttributeItemData>();
					float assistEqStrengthAttrValue = DataManager<StrengthenDataManager>.GetInstance().GetAssistEqStrengthAttrValue(itemData, itemData.StrengthenLevel);
					float assistEqStrengthAttrValue2 = DataManager<StrengthenDataManager>.GetInstance().GetAssistEqStrengthAttrValue(itemData, nextStrengthenLevel);
					for (int i = 4; i <= 7; i++)
					{
						StrengthenAttributeItemData strengthenAttributeItemData = new StrengthenAttributeItemData();
						StrengthenAttributeItemData strengthenAttributeItemData2 = new StrengthenAttributeItemData();
						if (i == 4)
						{
							strengthenAttributeItemData.kDesc = (strengthenAttributeItemData2.kDesc = TR.Value("auxiliary_equipment_attr_strength"));
							strengthenAttributeItemData.valueFormat = (strengthenAttributeItemData2.valueFormat = "{0}");
							strengthenAttributeItemData.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData2.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 5)
						{
							strengthenAttributeItemData.kDesc = (strengthenAttributeItemData2.kDesc = TR.Value("auxiliary_equipment_attr_intelligence"));
							strengthenAttributeItemData.valueFormat = (strengthenAttributeItemData2.valueFormat = "{0}");
							strengthenAttributeItemData.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData2.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 7)
						{
							strengthenAttributeItemData.kDesc = (strengthenAttributeItemData2.kDesc = TR.Value("auxiliary_equipment_attr_stamina"));
							strengthenAttributeItemData.valueFormat = (strengthenAttributeItemData2.valueFormat = "{0}");
							strengthenAttributeItemData.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData2.iCurValue = assistEqStrengthAttrValue2;
						}
						else if (i == 6)
						{
							strengthenAttributeItemData.kDesc = (strengthenAttributeItemData2.kDesc = TR.Value("auxiliary_equipment_attr_spirit"));
							strengthenAttributeItemData.valueFormat = (strengthenAttributeItemData2.valueFormat = "{0}");
							strengthenAttributeItemData.iCurValue = assistEqStrengthAttrValue;
							strengthenAttributeItemData2.iCurValue = assistEqStrengthAttrValue2;
						}
						list.Add(strengthenAttributeItemData);
						list2.Add(strengthenAttributeItemData2);
					}
					if (list.Count == list2.Count)
					{
						for (int j = 0; j < list.Count; j++)
						{
							this.m_akStrengthenAttributeItems.Create(new object[]
							{
								this.m_goStrengthenAttributesParent,
								this.m_goStrengthenAttributesPrefab,
								list[j],
								list2[j],
								this
							});
						}
					}
				}
				else
				{
					ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(itemData.TableID, false);
					ItemStrengthAttribute itemStrengthAttribute2 = ItemStrengthAttribute.Create(itemData.TableID, false);
					if (itemStrengthAttribute != null && itemStrengthAttribute2 != null)
					{
						itemStrengthAttribute.SetStrength(itemData.StrengthenLevel, false, 0);
						itemStrengthAttribute2.SetStrength(nextStrengthenLevel, false, 0);
						if (itemStrengthAttribute.Attributes.Count == itemStrengthAttribute2.Attributes.Count)
						{
							for (int k = 0; k < itemStrengthAttribute.Attributes.Count; k++)
							{
								this.m_akStrengthenAttributeItems.Create(new object[]
								{
									this.m_goStrengthenAttributesParent,
									this.m_goStrengthenAttributesPrefab,
									itemStrengthAttribute.Attributes[k],
									itemStrengthAttribute2.Attributes[k],
									this
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x060114E4 RID: 70884 RVA: 0x005000ED File Offset: 0x004FE4ED
		private void _UnInitStrengthenAttribute()
		{
			this.m_akStrengthenAttributeItems.DestroyAllObjects();
		}

		// Token: 0x060114E5 RID: 70885 RVA: 0x005000FC File Offset: 0x004FE4FC
		private void _ConfirmStrength()
		{
			this.m_bOnStart = true;
			if (StrengthenView.mCurrentSelectItemData.StrengthenLevel < 10)
			{
				this._OnStrengthChanged(null);
				this._OnStrengthenDelay(null);
			}
			else
			{
				StrengthenConfirmData strengthenConfirmData = new StrengthenConfirmData
				{
					ItemData = StrengthenView.mCurrentSelectItemData,
					UseProtect = this.toggleProtected.isOn,
					UseStrengthenImplement = this.mStrengthenImplementToggle.isOn,
					StrengthenImplementItem = this.mStrengthenDeviceItemData
				};
				strengthenConfirmData.TargetStrengthenLevel = strengthenConfirmData.ItemData.StrengthenLevel;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StrengthenConfirm>(FrameLayer.Middle, strengthenConfirmData, string.Empty);
			}
		}

		// Token: 0x060114E6 RID: 70886 RVA: 0x00500198 File Offset: 0x004FE598
		private void _DelaySendStrengthen()
		{
			if (this.m_bOnStart && StrengthenView.mCurrentSelectItemData != null && this.mStrengthenImplementToggle != null && this.toggleProtected != null)
			{
				if (this.mStrengthenImplementToggle.isOn && this.toggleProtected.isOn && this.mStrengthenDeviceItemData != null)
				{
					DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 3, this.mStrengthenDeviceItemData.GUID);
				}
				else if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData != null)
				{
					DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 2, this.mStrengthenDeviceItemData.GUID);
				}
				else if (this.toggleProtected.isOn)
				{
					DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 1, 0UL);
				}
				else
				{
					DataManager<StrengthenDataManager>.GetInstance().StrengthenItem(StrengthenView.mCurrentSelectItemData, 0, 0UL);
				}
			}
		}

		// Token: 0x060114E7 RID: 70887 RVA: 0x0050029B File Offset: 0x004FE69B
		private void UpdateStrengthenTargetLevel(int level)
		{
			if (this.mInputStrengthenLevel != null)
			{
				this.mInputStrengthenLevel.text = level.ToString();
			}
		}

		// Token: 0x060114E8 RID: 70888 RVA: 0x005002C8 File Offset: 0x004FE6C8
		private void OnStrengthenImplementClick(bool value)
		{
			if (value)
			{
				this.mStrengthenDeviceStateControl.Key = "true";
				this.UpdateStrengthDeviceItem();
			}
			else
			{
				this.mStrengthenDeviceStateControl.Key = "false";
				this._UpdateStrengthenMaterials((StrengthenView.mCurrentSelectItemData != null) ? StrengthenView.mCurrentSelectItemData : null);
			}
		}

		// Token: 0x060114E9 RID: 70889 RVA: 0x00500321 File Offset: 0x004FE721
		private void OnStrengthenDeviceItem(ItemData item)
		{
			if (item == null)
			{
				return;
			}
			this.mStrengthenDeviceItemData = item;
		}

		// Token: 0x060114EA RID: 70890 RVA: 0x00500334 File Offset: 0x004FE734
		private void UpdateStrengthDeviceItem()
		{
			this.mStrengthenDeviceStateControl.Key = "false";
			if (this.mStrengthenImplementToggle.isOn)
			{
				this.mStrengthenDeviceStateControl.Key = "true";
			}
			if (this.mStrengthenImplementToggle.isOn && this.mStrengthenDeviceItemData != null)
			{
				bool flag = false;
				List<ItemData> disposableStrengItemList = DataManager<StrengthenDataManager>.GetInstance().GetDisposableStrengItemList(StrengthenView.mCurrentSelectItemData);
				for (int i = 0; i < disposableStrengItemList.Count; i++)
				{
					ItemData itemData = disposableStrengItemList[i];
					if (itemData != null)
					{
						if (itemData.GUID == this.mStrengthenDeviceItemData.GUID)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.mStrengthenDeviceItemData = null;
				}
				if (this.mStrengthenDeviceItem != null)
				{
					this.mStrengthenDeviceItem.SetItem(this.mStrengthenDeviceItemData);
				}
			}
		}

		// Token: 0x0400B2B2 RID: 45746
		[SerializeField]
		private Text m_kTextProtectedHint;

		// Token: 0x0400B2B3 RID: 45747
		[SerializeField]
		private GameObject m_goMaterialParent;

		// Token: 0x0400B2B4 RID: 45748
		[SerializeField]
		private GameObject m_goMaterialPrefab;

		// Token: 0x0400B2B5 RID: 45749
		[SerializeField]
		private GameObject m_goMaterialParent1;

		// Token: 0x0400B2B6 RID: 45750
		[SerializeField]
		private GameObject m_goMaterialPrefab1;

		// Token: 0x0400B2B7 RID: 45751
		[SerializeField]
		private GameObject goUnuseProtectedHint;

		// Token: 0x0400B2B8 RID: 45752
		[SerializeField]
		private GameObject goProectedComeLink;

		// Token: 0x0400B2B9 RID: 45753
		[SerializeField]
		private Button m_kBtnStrength;

		// Token: 0x0400B2BA RID: 45754
		[SerializeField]
		private StateController comStatus;

		// Token: 0x0400B2BB RID: 45755
		[SerializeField]
		private StateController comProtectedStatus;

		// Token: 0x0400B2BC RID: 45756
		[SerializeField]
		private Button m_kBtnStrengthContinue;

		// Token: 0x0400B2BD RID: 45757
		[SerializeField]
		private UIGray m_kGray;

		// Token: 0x0400B2BE RID: 45758
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400B2BF RID: 45759
		[SerializeField]
		private Button m_kBtnStop;

		// Token: 0x0400B2C0 RID: 45760
		[SerializeField]
		private UIGray m_kStrengthContinueGray;

		// Token: 0x0400B2C1 RID: 45761
		[SerializeField]
		private Text m_kTextStrengthContinue;

		// Token: 0x0400B2C2 RID: 45762
		[SerializeField]
		private Text m_kTextStrengthHint;

		// Token: 0x0400B2C3 RID: 45763
		[SerializeField]
		private Image m_kFrontGround;

		// Token: 0x0400B2C4 RID: 45764
		[SerializeField]
		private Button m_btnConpon;

		// Token: 0x0400B2C5 RID: 45765
		[SerializeField]
		private UIGray m_grayConpon;

		// Token: 0x0400B2C6 RID: 45766
		[SerializeField]
		private Toggle toggleProtected;

		// Token: 0x0400B2C7 RID: 45767
		[SerializeField]
		private Toggle mStrengthenImplementToggle;

		// Token: 0x0400B2C8 RID: 45768
		[SerializeField]
		private Image imgProtectedIcon;

		// Token: 0x0400B2C9 RID: 45769
		[SerializeField]
		private GameObject goCouponParent;

		// Token: 0x0400B2CA RID: 45770
		[SerializeField]
		private GameObject goCouponPrefab;

		// Token: 0x0400B2CB RID: 45771
		[SerializeField]
		private GameObject goCouponItemParent;

		// Token: 0x0400B2CC RID: 45772
		[SerializeField]
		private GameObject goCouponItemPrefab;

		// Token: 0x0400B2CD RID: 45773
		[SerializeField]
		private GameObject goCouponLink;

		// Token: 0x0400B2CE RID: 45774
		[SerializeField]
		private ItemComeLink comConponLink;

		// Token: 0x0400B2CF RID: 45775
		[SerializeField]
		private Button m_btnProtected;

		// Token: 0x0400B2D0 RID: 45776
		[SerializeField]
		private Button m_btnComLinkStrengthenProtected;

		// Token: 0x0400B2D1 RID: 45777
		[SerializeField]
		private Button m_btnSpecialStrength;

		// Token: 0x0400B2D2 RID: 45778
		[SerializeField]
		private Button m_btnStrength;

		// Token: 0x0400B2D3 RID: 45779
		[SerializeField]
		private Button m_btnStrengthContinue;

		// Token: 0x0400B2D4 RID: 45780
		[SerializeField]
		private Button m_btnStop;

		// Token: 0x0400B2D5 RID: 45781
		[SerializeField]
		private Button m_StrengthenStampBtn;

		// Token: 0x0400B2D6 RID: 45782
		[SerializeField]
		private GameObject m_goStrengthenAttributesParent;

		// Token: 0x0400B2D7 RID: 45783
		[SerializeField]
		private GameObject m_goStrengthenAttributesPrefab;

		// Token: 0x0400B2D8 RID: 45784
		[SerializeField]
		private GameObject m_goFilterGroup;

		// Token: 0x0400B2D9 RID: 45785
		[SerializeField]
		private GameObject m_goFilter0;

		// Token: 0x0400B2DA RID: 45786
		[SerializeField]
		private GameObject m_goFilter1;

		// Token: 0x0400B2DB RID: 45787
		[SerializeField]
		private GameObject m_goCostContent;

		// Token: 0x0400B2DC RID: 45788
		[SerializeField]
		private GameObject m_goProtectedContent;

		// Token: 0x0400B2DD RID: 45789
		[SerializeField]
		private GameObject m_goStrengthenStampParent;

		// Token: 0x0400B2DE RID: 45790
		[SerializeField]
		private Text mName;

		// Token: 0x0400B2DF RID: 45791
		[SerializeField]
		private Text mCurrentStrengthLevel;

		// Token: 0x0400B2E0 RID: 45792
		[SerializeField]
		private Text mTargetStrengthLevel;

		// Token: 0x0400B2E1 RID: 45793
		[SerializeField]
		private Text mStrengthenStampName;

		// Token: 0x0400B2E2 RID: 45794
		[SerializeField]
		private Text mInputStrengthenLevel;

		// Token: 0x0400B2E3 RID: 45795
		[SerializeField]
		private Button mInputStrengthenLevelBtn;

		// Token: 0x0400B2E4 RID: 45796
		[SerializeField]
		private ComEffect m_kComStrengthenEffect;

		// Token: 0x0400B2E5 RID: 45797
		[SerializeField]
		private StrengthenDeviceItem mStrengthenDeviceItem;

		// Token: 0x0400B2E6 RID: 45798
		[SerializeField]
		private StateController mStrengthenDeviceStateControl;

		// Token: 0x0400B2E7 RID: 45799
		private ComItem m_kCurrent;

		// Token: 0x0400B2E8 RID: 45800
		private Color32 colorGray = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x0400B2E9 RID: 45801
		private ItemData m_kProtectedItemData;

		// Token: 0x0400B2EA RID: 45802
		private bool m_bOnStart;

		// Token: 0x0400B2EB RID: 45803
		private Utility.StrengthOperateResult m_eStrengthOperateResult;

		// Token: 0x0400B2EC RID: 45804
		private int m_id0 = 300000106;

		// Token: 0x0400B2ED RID: 45805
		private int m_id1 = 300000105;

		// Token: 0x0400B2EE RID: 45806
		private int m_id3 = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);

		// Token: 0x0400B2EF RID: 45807
		private StrengthenCost m_costNeed;

		// Token: 0x0400B2F0 RID: 45808
		private int m_iTarget;

		// Token: 0x0400B2F1 RID: 45809
		private int m_iContinueTimes;

		// Token: 0x0400B2F2 RID: 45810
		private const float delaySendContinueStrengthen = 0.7f;

		// Token: 0x0400B2F3 RID: 45811
		private const float delaySendStrengthen = 1.62f;

		// Token: 0x0400B2F4 RID: 45812
		private bool m_bUseProtected;

		// Token: 0x0400B2F5 RID: 45813
		private bool bSpecialStrengthen;

		// Token: 0x0400B2F6 RID: 45814
		private bool m_bNeedContinueStrengthGoldCostHint;

		// Token: 0x0400B2F7 RID: 45815
		private bool bContinueStrengthen;

		// Token: 0x0400B2F8 RID: 45816
		private ComItem mStrengthenStampComItem;

		// Token: 0x0400B2F9 RID: 45817
		private int iLastStrengthenTargetLevel;

		// Token: 0x0400B2FA RID: 45818
		private const int iMaxStrengthenLevel = 10;

		// Token: 0x0400B2FB RID: 45819
		private int iMinStrengthenLevel;

		// Token: 0x0400B2FC RID: 45820
		private int iStrengthenNextLevel;

		// Token: 0x0400B2FD RID: 45821
		private CachedObjectDicManager<int, StrengthenView.CostMaterialItem> m_akNeedCostMaterials = new CachedObjectDicManager<int, StrengthenView.CostMaterialItem>();

		// Token: 0x0400B2FE RID: 45822
		private CachedObjectDicManager<int, StrengthenView.CostMaterialItem> m_akNeedCostMaterials1 = new CachedObjectDicManager<int, StrengthenView.CostMaterialItem>();

		// Token: 0x0400B2FF RID: 45823
		private List<StrengthenResult> m_akData = new List<StrengthenResult>();

		// Token: 0x0400B300 RID: 45824
		private SmithShopNewLinkData linkData;

		// Token: 0x0400B301 RID: 45825
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B302 RID: 45826
		private StrengthenGrowthType mType;

		// Token: 0x0400B303 RID: 45827
		private static ItemData mCurrentSelectItemData;

		// Token: 0x0400B304 RID: 45828
		private ItemData mCurrentSelectStrengthStampItemData;

		// Token: 0x0400B305 RID: 45829
		private ItemData mStrengthenDeviceItemData;

		// Token: 0x0400B306 RID: 45830
		private CachedObjectDicManager<StrengthenView.StrengthenType, StrengthenView.StrengthenTab> m_akStrengthenTabs = new CachedObjectDicManager<StrengthenView.StrengthenType, StrengthenView.StrengthenTab>();

		// Token: 0x0400B307 RID: 45831
		private CachedObjectListManager<StrengthenView.StrengthenAttributeItem> m_akStrengthenAttributeItems = new CachedObjectListManager<StrengthenView.StrengthenAttributeItem>();

		// Token: 0x02001B8C RID: 7052
		private enum StrengthenType
		{
			// Token: 0x0400B30A RID: 45834
			[Description("使用材料")]
			ST_COST_METERIAL,
			// Token: 0x0400B30B RID: 45835
			[Description("使用强化券")]
			ST_PROTECTED_COUPON,
			// Token: 0x0400B30C RID: 45836
			ST_COUNT
		}

		// Token: 0x02001B8D RID: 7053
		private sealed class StrengthenTab : CachedObject
		{
			// Token: 0x060114F2 RID: 70898 RVA: 0x005004AB File Offset: 0x004FE8AB
			public static void Clear()
			{
				if (StrengthenView.StrengthenTab.selected != null)
				{
					StrengthenView.StrengthenTab.selected.SetSelected(false);
				}
				StrengthenView.StrengthenTab.selected = null;
			}

			// Token: 0x17001DA4 RID: 7588
			// (get) Token: 0x060114F3 RID: 70899 RVA: 0x005004C8 File Offset: 0x004FE8C8
			public StrengthenView.StrengthenType StrengthenType
			{
				get
				{
					return this.eStrengthenType;
				}
			}

			// Token: 0x17001DA5 RID: 7589
			// (get) Token: 0x060114F4 RID: 70900 RVA: 0x005004D0 File Offset: 0x004FE8D0
			public SmithFunctionRedBinder ComSmithFunctionBinder
			{
				get
				{
					return this.comSmithFunctionBinder;
				}
			}

			// Token: 0x060114F5 RID: 70901 RVA: 0x005004D8 File Offset: 0x004FE8D8
			public override void OnDestroy()
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle = null;
			}

			// Token: 0x060114F6 RID: 70902 RVA: 0x005004F4 File Offset: 0x004FE8F4
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eStrengthenType = (StrengthenView.StrengthenType)param[2];
				this.goControl = (param[3] as GameObject);
				this.frame = (StrengthenView)param[4];
				if (this.goPrefab == null)
				{
					return;
				}
				if (this.goLocal == null)
				{
					this.goLocal = this.goPrefab;
					string enumDescription = Utility.GetEnumDescription<StrengthenView.StrengthenType>(this.StrengthenType);
					this.labelMark = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.labelMark.text = enumDescription;
					this.labelCheckMark = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
					this.labelCheckMark.text = enumDescription;
					this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle.isOn = false;
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this._OnSelected();
						}
					});
					this.comSmithFunctionBinder = this.goLocal.GetComponent<SmithFunctionRedBinder>();
					if (this.comSmithFunctionBinder != null)
					{
						this.comSmithFunctionBinder.ClearCheckFunctions();
					}
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x060114F7 RID: 70903 RVA: 0x00500660 File Offset: 0x004FEA60
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060114F8 RID: 70904 RVA: 0x0050067F File Offset: 0x004FEA7F
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060114F9 RID: 70905 RVA: 0x00500688 File Offset: 0x004FEA88
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x060114FA RID: 70906 RVA: 0x00500690 File Offset: 0x004FEA90
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060114FB RID: 70907 RVA: 0x005006AF File Offset: 0x004FEAAF
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060114FC RID: 70908 RVA: 0x005006CE File Offset: 0x004FEACE
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x060114FD RID: 70909 RVA: 0x005006D1 File Offset: 0x004FEAD1
			private void _Update()
			{
				this.goLocal.name = this.eStrengthenType.ToString();
			}

			// Token: 0x060114FE RID: 70910 RVA: 0x005006EF File Offset: 0x004FEAEF
			private void _OnSelected()
			{
				if (StrengthenView.StrengthenTab.selected != this)
				{
					if (StrengthenView.StrengthenTab.selected != null)
					{
						StrengthenView.StrengthenTab.selected.SetSelected(false);
					}
					StrengthenView.StrengthenTab.selected = this;
					this.SetSelected(true);
				}
				this.frame.OnStrengthenTabChanged(this.eStrengthenType);
			}

			// Token: 0x060114FF RID: 70911 RVA: 0x0050072F File Offset: 0x004FEB2F
			private void SetSelected(bool bSelected)
			{
				this.goCheckMark.CustomActive(bSelected);
				this.goControl.CustomActive(bSelected);
				if (this.toggle.isOn != bSelected)
				{
					this.toggle.isOn = bSelected;
				}
			}

			// Token: 0x0400B30D RID: 45837
			private static StrengthenView.StrengthenTab selected;

			// Token: 0x0400B30E RID: 45838
			private GameObject goLocal;

			// Token: 0x0400B30F RID: 45839
			private GameObject goPrefab;

			// Token: 0x0400B310 RID: 45840
			private GameObject goParent;

			// Token: 0x0400B311 RID: 45841
			private GameObject goControl;

			// Token: 0x0400B312 RID: 45842
			private StrengthenView.StrengthenType eStrengthenType;

			// Token: 0x0400B313 RID: 45843
			private StrengthenView frame;

			// Token: 0x0400B314 RID: 45844
			public Toggle toggle;

			// Token: 0x0400B315 RID: 45845
			private Text labelMark;

			// Token: 0x0400B316 RID: 45846
			private Text labelCheckMark;

			// Token: 0x0400B317 RID: 45847
			private GameObject goCheckMark;

			// Token: 0x0400B318 RID: 45848
			private SmithFunctionRedBinder comSmithFunctionBinder;
		}

		// Token: 0x02001B8E RID: 7054
		public sealed class CostMaterialItem : CachedObject
		{
			// Token: 0x17001DA6 RID: 7590
			// (get) Token: 0x06011503 RID: 70915 RVA: 0x0050077E File Offset: 0x004FEB7E
			public ItemData ItemData
			{
				get
				{
					return this.itemData;
				}
			}

			// Token: 0x06011504 RID: 70916 RVA: 0x00500786 File Offset: 0x004FEB86
			public override void OnDestroy()
			{
				this.comItem.Setup(null, null);
				this.comItem = null;
				this.itemData = null;
			}

			// Token: 0x06011505 RID: 70917 RVA: 0x005007A4 File Offset: 0x004FEBA4
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.itemData = (param[2] as ItemData);
				this.frame = (param[3] as StrengthenView);
				this.bForceShow = (bool)param[4];
				this.iNeedCount = (int)param[5];
				if (this.goPrefab == null)
				{
					return;
				}
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
					this.comItem = ComItemManager.Create(this.goLocal);
					this.comItem.gameObject.transform.SetAsFirstSibling();
					this.count = Utility.FindComponent<Text>(this.goLocal, "Count", true);
					this.goAcquired = Utility.FindChild(this.goLocal, "ItemComLink");
					this.btnAcquired = Utility.FindComponent<Button>(this.goLocal, "ItemComLink", true);
					this.btnAcquired.onClick.RemoveAllListeners();
					this.btnAcquired.onClick.AddListener(delegate()
					{
						if (this.itemData != null)
						{
							ItemComeLink.OnLink(this.itemData.TableID, 0, true, delegate
							{
								Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
							}, false, false, false, null, string.Empty);
						}
					});
				}
				this.Enable();
				this.SetAsLastSibling();
				this._Update();
			}

			// Token: 0x06011506 RID: 70918 RVA: 0x0050090A File Offset: 0x004FED0A
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06011507 RID: 70919 RVA: 0x0050092D File Offset: 0x004FED2D
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06011508 RID: 70920 RVA: 0x0050094C File Offset: 0x004FED4C
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06011509 RID: 70921 RVA: 0x00500955 File Offset: 0x004FED55
			public override void OnRefresh(object[] param)
			{
				this.itemData = (param[0] as ItemData);
				this.bForceShow = (bool)param[1];
				this.iNeedCount = (int)param[2];
				this._Update();
			}

			// Token: 0x0601150A RID: 70922 RVA: 0x00500987 File Offset: 0x004FED87
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0601150B RID: 70923 RVA: 0x005009A6 File Offset: 0x004FEDA6
			public void SetAsFirstSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsFirstSibling();
				}
			}

			// Token: 0x0601150C RID: 70924 RVA: 0x005009C9 File Offset: 0x004FEDC9
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601150D RID: 70925 RVA: 0x005009E8 File Offset: 0x004FEDE8
			public override bool NeedFilter(object[] param)
			{
				return !this.bForceShow && this.iNeedCount <= 0;
			}

			// Token: 0x0601150E RID: 70926 RVA: 0x00500A03 File Offset: 0x004FEE03
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
			}

			// Token: 0x0601150F RID: 70927 RVA: 0x00500A1C File Offset: 0x004FEE1C
			private void _Update()
			{
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.name.text = this.itemData.GetColorName(string.Empty, false);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemData.TableID, true);
				if (this.itemData.Type == ItemTable.eType.INCOME)
				{
					this.count.text = string.Format("{0}", this.iNeedCount);
				}
				else
				{
					this.count.text = string.Format("{0}/{1}", ownedItemCount, this.iNeedCount);
				}
				if (ownedItemCount < this.iNeedCount && this.iNeedCount > 0)
				{
					this.count.color = Color.red;
				}
				else
				{
					this.count.color = Color.white;
				}
				if (this.itemData != null)
				{
					this.itemData.Count = 1;
				}
				this.goLocal.name = this.itemData.TableID.ToString();
				this.goAcquired.CustomActive(ownedItemCount < this.iNeedCount && this.iNeedCount > 0);
				this.comItem.SetShowNotEnoughState(this.goAcquired.activeSelf);
			}

			// Token: 0x0400B319 RID: 45849
			private GameObject goLocal;

			// Token: 0x0400B31A RID: 45850
			private GameObject goPrefab;

			// Token: 0x0400B31B RID: 45851
			private GameObject goParent;

			// Token: 0x0400B31C RID: 45852
			private GameObject goAcquired;

			// Token: 0x0400B31D RID: 45853
			private Button btnAcquired;

			// Token: 0x0400B31E RID: 45854
			private int iNeedCount;

			// Token: 0x0400B31F RID: 45855
			private bool bForceShow;

			// Token: 0x0400B320 RID: 45856
			private ItemData itemData;

			// Token: 0x0400B321 RID: 45857
			private StrengthenView frame;

			// Token: 0x0400B322 RID: 45858
			private Text name;

			// Token: 0x0400B323 RID: 45859
			private Text count;

			// Token: 0x0400B324 RID: 45860
			private ComItem comItem;
		}

		// Token: 0x02001B8F RID: 7055
		private sealed class StrengthenAttributeItem : CachedObject
		{
			// Token: 0x06011513 RID: 70931 RVA: 0x00500BEE File Offset: 0x004FEFEE
			public override void OnDestroy()
			{
			}

			// Token: 0x06011514 RID: 70932 RVA: 0x00500BF0 File Offset: 0x004FEFF0
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.dataA = (param[2] as StrengthenAttributeItemData);
				this.dataB = (param[3] as StrengthenAttributeItemData);
				this.frame = (param[4] as StrengthenView);
				if (this.goPrefab == null)
				{
					return;
				}
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.fixedDesc = Utility.FindComponent<Text>(this.goLocal, "Prefixed", true);
					this.curValue = Utility.FindComponent<Text>(this.goLocal, "Value1", true);
					this.nextValue = Utility.FindComponent<Text>(this.goLocal, "Value2", true);
				}
				this.Enable();
				this.SetAsLastSibling();
				this._Update();
			}

			// Token: 0x06011515 RID: 70933 RVA: 0x00500CE0 File Offset: 0x004FF0E0
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06011516 RID: 70934 RVA: 0x00500D03 File Offset: 0x004FF103
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06011517 RID: 70935 RVA: 0x00500D22 File Offset: 0x004FF122
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06011518 RID: 70936 RVA: 0x00500D2B File Offset: 0x004FF12B
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length == 2)
				{
					this.dataA = (param[0] as StrengthenAttributeItemData);
					this.dataB = (param[1] as StrengthenAttributeItemData);
				}
				this._Update();
			}

			// Token: 0x06011519 RID: 70937 RVA: 0x00500D5E File Offset: 0x004FF15E
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0601151A RID: 70938 RVA: 0x00500D7D File Offset: 0x004FF17D
			public void SetAsFirstSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsFirstSibling();
				}
			}

			// Token: 0x0601151B RID: 70939 RVA: 0x00500DA0 File Offset: 0x004FF1A0
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601151C RID: 70940 RVA: 0x00500DBF File Offset: 0x004FF1BF
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0601151D RID: 70941 RVA: 0x00500DC4 File Offset: 0x004FF1C4
			private void _Update()
			{
				if (this.dataA != null && this.dataB != null)
				{
					this.fixedDesc.text = this.dataA.kDesc;
					this.curValue.text = string.Format("+{0}", this.dataA.ToValueDesc());
					this.nextValue.text = string.Format("+{0}", this.dataB.ToValueDesc());
				}
			}

			// Token: 0x0400B326 RID: 45862
			private GameObject goLocal;

			// Token: 0x0400B327 RID: 45863
			private GameObject goPrefab;

			// Token: 0x0400B328 RID: 45864
			private GameObject goParent;

			// Token: 0x0400B329 RID: 45865
			private StrengthenView frame;

			// Token: 0x0400B32A RID: 45866
			private StrengthenAttributeItemData dataA;

			// Token: 0x0400B32B RID: 45867
			private StrengthenAttributeItemData dataB;

			// Token: 0x0400B32C RID: 45868
			private Text fixedDesc;

			// Token: 0x0400B32D RID: 45869
			private Text curValue;

			// Token: 0x0400B32E RID: 45870
			private Text nextValue;
		}
	}
}

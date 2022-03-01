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
	// Token: 0x02001981 RID: 6529
	internal class PetPacketFrame : ClientFrame
	{
		// Token: 0x0600FDB7 RID: 64951 RVA: 0x00460A84 File Offset: 0x0045EE84
		private void _OpenTipsFrame()
		{
			if (!(base._GetChildFrame(this.m_iTipsFrameID) is PetTotalTipsFrame))
			{
				PetTotalTipsFrame petTotalTipsFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<PetTotalTipsFrame>(this.tipsParent, null, string.Empty) as PetTotalTipsFrame;
				if (petTotalTipsFrame != null)
				{
					base._AddChildFrame(this.m_iTipsFrameID, petTotalTipsFrame);
				}
			}
		}

		// Token: 0x0600FDB8 RID: 64952 RVA: 0x00460AD8 File Offset: 0x0045EED8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/PetPacket";
		}

		// Token: 0x0600FDB9 RID: 64953 RVA: 0x00460ADF File Offset: 0x0045EEDF
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			base._AddButton("DetailRoot/BtnPetInfo1", new UnityAction(this._OpenTipsFrame));
		}

		// Token: 0x0600FDBA RID: 64954 RVA: 0x00460B04 File Offset: 0x0045EF04
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
			if (DataManager<PetDataManager>.GetInstance().GetIsActiveFeed())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayActiveFeedPetAction, null, null, null, null);
				DataManager<PetDataManager>.GetInstance().SetActiveFeed(false);
			}
		}

		// Token: 0x0600FDBB RID: 64955 RVA: 0x00460B3F File Offset: 0x0045EF3F
		private void ClearData()
		{
			this.CurSelSortType = PetItemSortType.QualitySort;
			this.MaxPetItemNum = 0;
			this.MaxSatietyNum = 0;
			this.packageTab = PetPackageTab.PetItemTab;
			this.mAvatarRenderer.ClearAvatar();
			this.PetInfoList.Clear();
			this.CurSelPetIndex = 0;
		}

		// Token: 0x0600FDBC RID: 64956 RVA: 0x00460B7C File Offset: 0x0045EF7C
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetInfoInited, new ClientEventSystem.UIEventHandler(this._updateGroupUpRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetSlotChanged, new ClientEventSystem.UIEventHandler(this.OnPetSlotChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdatePetList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EatPetSuccess, new ClientEventSystem.UIEventHandler(this.OnEatPetSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnItemCountChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
		}

		// Token: 0x0600FDBD RID: 64957 RVA: 0x00460C98 File Offset: 0x0045F098
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetInfoInited, new ClientEventSystem.UIEventHandler(this._updateGroupUpRedPoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetSlotChanged, new ClientEventSystem.UIEventHandler(this.OnPetSlotChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdatePetList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EatPetSuccess, new ClientEventSystem.UIEventHandler(this.OnEatPetSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this.OnItemCountChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
		}

		// Token: 0x0600FDBE RID: 64958 RVA: 0x00460DB4 File Offset: 0x0045F1B4
		private void OnPetSlotChanged(UIEvent iEvent)
		{
			int num = (int)iEvent.Param1;
			bool flag = (bool)iEvent.Param2;
			if (this.IsCurSelPetRemove())
			{
				DataManager<PetDataManager>.GetInstance().SetPetData(this.CurSelPetInfo, new PetInfo());
				this._setNonePetEquiped(false);
			}
			this.UpdatePetListData();
			this.RefreshPetItemListCount();
			this.UpdateOnUsePet();
			this.SelectSuitableShowPet(false, num, flag);
			if (flag)
			{
				this.PlayEquipEffect(num);
			}
			this._updatePetEggRedPoint(null);
			this._updateGroupUpRedPoint(null);
			this._updatePetRedPoint(null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshPackageProperty, null, null, null, null);
		}

		// Token: 0x0600FDBF RID: 64959 RVA: 0x00460E50 File Offset: 0x0045F250
		private void OnUpdatePetList(UIEvent iEvent)
		{
			this.UpdatePetListData();
			this.RefreshPetItemListCount();
			this.UpdateCurSelOnUsePet();
			this.UpdateOnUsePet();
			this.UpdateSelPetInfo();
		}

		// Token: 0x0600FDC0 RID: 64960 RVA: 0x00460E70 File Offset: 0x0045F270
		private void OnEatPetSuccess(UIEvent iEvent)
		{
			this.UpdateCurSelOnUsePet();
			this.UpdateOnUsePet();
			this.SelectSuitableShowPet(false, -1, false);
		}

		// Token: 0x0600FDC1 RID: 64961 RVA: 0x00460E88 File Offset: 0x0045F288
		private void OnItemCountChanged(UIEvent iEvent)
		{
			if (this.packageTab == PetPackageTab.PetItemTab)
			{
				return;
			}
			int id = (int)iEvent.Param1;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null || tableItem.Type != ItemTable.eType.PET)
			{
				return;
			}
			this.RefreshNormalItemListCount();
		}

		// Token: 0x0600FDC2 RID: 64962 RVA: 0x00460EE0 File Offset: 0x0045F2E0
		[UIEventHandle("PacketTab/Func{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void OnSwitchPackageType(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.packageTab = (PetPackageTab)iIndex;
			this.UpdatePackageType();
			if (this.packageTab == PetPackageTab.PetItemTab)
			{
				this.RefreshPetItemListCount();
				this.mSortRoot.CustomActive(true);
				DataManager<PetDataManager>.GetInstance().IsUseClickPetTab = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetTabClick, null, null, null, null);
				this._updatePetRedPoint(null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
			}
			else if (this.packageTab == PetPackageTab.PetFoodTab)
			{
				this.InitNormalItemScrollListBind();
				this.RefreshNormalItemListCount();
			}
			else if (this.packageTab == PetPackageTab.PetEggTab)
			{
				this.InitNormalItemScrollListBind();
				this.RefreshNormalItemListCount();
				this._updatePetEggRedPoint(null);
			}
		}

		// Token: 0x0600FDC3 RID: 64963 RVA: 0x00460FA1 File Offset: 0x0045F3A1
		private void _setNonePetEquiped(bool isEquiped)
		{
			this.mActorShowRoot.CustomActive(isEquiped);
			this.mNoneEquipRoot.CustomActive(!isEquiped);
		}

		// Token: 0x0600FDC4 RID: 64964 RVA: 0x00460FC0 File Offset: 0x0045F3C0
		[UIEventHandle("OnUsePet/UsePet{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnChooseUsePet(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.CurSelPetIndex = iIndex;
			this.CurSelPetInfo = this.GetSelPetInfo(iIndex);
			if (this.CurSelPetInfo != null)
			{
				DataManager<PetDataManager>.GetInstance().SelectPetId = this.CurSelPetInfo.id;
				this._updateGroupUpRedPoint(null);
			}
			if (this.CurSelPetInfo.dataId <= 0U)
			{
				this._setNonePetEquiped(false);
				this.mSelectTips.text = string.Format("请选择[{0}]宠物装备该栏位", DataManager<PetDataManager>.GetInstance().GetPetTypeDesc(iIndex + PetTable.ePetType.PT_ATTACK));
				this.InitPetItemScrollListBind(true);
			}
			else
			{
				this._setNonePetEquiped(true);
				this.UpdateSelPetInfo();
				this.UpdateActor((int)this.CurSelPetInfo.dataId);
				this.InitPetItemScrollListBind(false);
			}
			this.RefreshPetItemListCount();
		}

		// Token: 0x0600FDC5 RID: 64965 RVA: 0x00461088 File Offset: 0x0045F488
		private void OnShowNormalItemTip(int iIndex)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Pet);
			if (iIndex >= itemsByPackageType.Count)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[iIndex]);
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600FDC6 RID: 64966 RVA: 0x004610D4 File Offset: 0x0045F4D4
		[UIEventHandle("PacketNavigation/SortTypeSelect/SortTypeList/SortType{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void OnChooseSortType(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.CurSelSortType = (PetItemSortType)iIndex;
			this.mShowSortType.text = this.SortTypeTexts[iIndex].text;
			this.mSortTypeListRoot.CustomActive(false);
			this.UpdatePetListData();
			this.RefreshPetItemListCount();
		}

		// Token: 0x0600FDC7 RID: 64967 RVA: 0x00461128 File Offset: 0x0045F528
		public void SetPetToggle()
		{
			if (this.mBind == null)
			{
				return;
			}
			Toggle com = this.mBind.GetCom<Toggle>("PetToggle");
			if (com == null)
			{
				return;
			}
			com.isOn = true;
		}

		// Token: 0x0600FDC8 RID: 64968 RVA: 0x0046116C File Offset: 0x0045F56C
		private void InitInterface()
		{
			this.InitData();
			this.InitPetItemScrollListBind(false);
			this.RefreshPetItemListCount();
			this.UpdateOnUsePet();
			int num = this._getDefaultShowIndex();
			if (num != -1)
			{
				this.SelectSuitableShowPet(false, num, true);
			}
			else
			{
				this.SelectSuitableShowPet(true, -1, false);
			}
			this._updateGroupUpRedPoint(null);
			this._updatePetEggRedPoint(null);
			this._updatePetRedPoint(null);
		}

		// Token: 0x0600FDC9 RID: 64969 RVA: 0x004611CC File Offset: 0x0045F5CC
		private int _getDefaultShowIndex()
		{
			if (DataManager<PetDataManager>.GetInstance().IsUserClickFeedCount)
			{
				return -1;
			}
			return DataManager<PetDataManager>.GetInstance().GetPetsContainGoldFeedCountTypeIndex();
		}

		// Token: 0x0600FDCA RID: 64970 RVA: 0x004611E9 File Offset: 0x0045F5E9
		private void _updatePetRedPoint(UIEvent ui)
		{
			this.mPetRedPoint.CustomActive(DataManager<PetDataManager>.GetInstance().IsNeedShowPetRedPoint());
		}

		// Token: 0x0600FDCB RID: 64971 RVA: 0x00461200 File Offset: 0x0045F600
		private void _updatePetEggRedPoint(UIEvent ui)
		{
			this.mPetEggRedPoint.CustomActive(DataManager<PetDataManager>.GetInstance().IsNeedShowPetEggRedPoint());
		}

		// Token: 0x0600FDCC RID: 64972 RVA: 0x00461218 File Offset: 0x0045F618
		private void _updateGroupUpRedPoint(UIEvent ui)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				return;
			}
			this.mGroupUpRedPoint.CustomActive(DataManager<PetDataManager>.GetInstance().SelectPetsNeedShowRedPoint());
		}

		// Token: 0x0600FDCD RID: 64973 RVA: 0x00461254 File Offset: 0x0045F654
		private void InitData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(220, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.MaxPetItemNum = tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(221, string.Empty, string.Empty);
			this.MaxSatietyNum = tableItem2.Value;
			this.UpdatePetListData();
		}

		// Token: 0x0600FDCE RID: 64974 RVA: 0x004612BC File Offset: 0x0045F6BC
		private void InitPetItemScrollListBind(bool bCheckCover = false)
		{
			if (this.packageTab != PetPackageTab.PetItemTab)
			{
				return;
			}
			this.mItemUIScrollList[0].Initialize();
			this.mItemUIScrollList[0].onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdatePetItemScrollListBind(item, bCheckCover);
				}
			};
			this.mItemUIScrollList[0].OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("btPetItem");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600FDCF RID: 64975 RVA: 0x0046133C File Offset: 0x0045F73C
		private void InitPetEggScrollList()
		{
			this.mItemUIScrollList[1].Initialize();
			this.mItemUIScrollList[1].onBindItem = ((GameObject obj) => base.CreateComItem(obj));
			this.mItemUIScrollList[1].onItemVisiable = delegate(ComUIListElementScript item)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Pet);
				int num = (itemsByPackageType.Count <= this.MaxShowPetItemNum) ? this.MaxShowPetItemNum : this.MaxPetItemNum;
				if (item.m_index >= 0 && item.m_index < num)
				{
					ComItem comItem = item.gameObjectBindScript as ComItem;
					if (item.m_index < itemsByPackageType.Count)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[item.m_index]);
						if (item2 != null)
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							int idx = item.m_index;
							comItem.Setup(item2, delegate(GameObject obj, ItemData tipitem)
							{
								this.OnShowNormalItemTip(idx);
							});
							comItem.SetEnable(true);
							comItem.SetShowUnusableState(true);
						}
						else
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(null, null);
							comItem.SetEnable(true);
							comItem.SetShowBetterState(false);
							comItem.SetShowSelectState(false);
							comItem.SetShowUnusableState(false);
						}
					}
					else
					{
						comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem.Setup(null, null);
						comItem.SetEnable(true);
						comItem.SetShowBetterState(false);
						comItem.SetShowSelectState(false);
					}
				}
			};
		}

		// Token: 0x0600FDD0 RID: 64976 RVA: 0x00461388 File Offset: 0x0045F788
		private void OnNormalItemClick(int index)
		{
			if (this.packageTab == PetPackageTab.PetFoodTab)
			{
				this.OnShowNormalItemTip(index);
			}
			else if (this.packageTab == PetPackageTab.PetEggTab)
			{
				this._OnPackageItemClicked(index);
			}
		}

		// Token: 0x0600FDD1 RID: 64977 RVA: 0x004613B8 File Offset: 0x0045F7B8
		private void _OnUpdateItemList(UIEvent a_event)
		{
			if (a_event.EventID == EUIEventID.ItemUseSuccess)
			{
				ItemData itemData = (ItemData)a_event.Param1;
				if (itemData.PackageType == EPackageType.Consumable)
				{
					Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
					Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
					bool flag = DataManager<PetDataManager>.GetInstance().IsPetEggItem(itemData.TableID);
					if (flag)
					{
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenPetEggFrame>(null))
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenPetEggFrame>(null, false);
						}
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenPetEggFrame>(FrameLayer.Middle, itemData, string.Empty);
					}
				}
			}
			this.RefreshNormalItemListCount();
			this._updatePetEggRedPoint(null);
			this._updatePetRedPoint(null);
		}

		// Token: 0x0600FDD2 RID: 64978 RVA: 0x00461458 File Offset: 0x0045F858
		private void _OnShareClicked(ItemData item, object data)
		{
			DataManager<ChatManager>.GetInstance().ShareEquipment(item, ChatType.CT_WORLD);
		}

		// Token: 0x0600FDD3 RID: 64979 RVA: 0x00461468 File Offset: 0x0045F868
		private void _OnUseItem(ItemData item, object data)
		{
			if (item != null)
			{
				if (item.PackID > 0)
				{
					GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(item.PackID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.FilterType == GiftPackTable.eFilterType.Custom || tableItem.FilterType == GiftPackTable.eFilterType.CustomWithJob)
						{
							if (tableItem.FilterCount > 0)
							{
								Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrame>(FrameLayer.Middle, item, string.Empty);
							}
							else
							{
								Logger.LogErrorFormat("礼包{0}的FilterCount小于等于0", new object[]
								{
									item.PackID
								});
							}
						}
						else
						{
							DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
							if (item.Count <= 1 || item.CD > 0)
							{
								DataManager<ItemTipManager>.GetInstance().CloseAll();
							}
						}
					}
					else
					{
						Logger.LogErrorFormat("道具{0}的礼包ID{1}不存在", new object[]
						{
							item.TableID,
							item.PackID
						});
					}
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
					if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Fashion)
					{
						MonoSingleton<AudioManager>.instance.PlaySound(102);
					}
					if (item.Count <= 1 || item.CD > 0)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}
				}
			}
		}

		// Token: 0x0600FDD4 RID: 64980 RVA: 0x004615C4 File Offset: 0x0045F9C4
		private void _OnPackageItemClicked(int idx)
		{
			List<ulong> petEggList = this.GetPetEggList(false);
			if (idx < 0 || idx >= petEggList.Count)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(petEggList[idx]);
			List<TipFuncButon> list = new List<TipFuncButon>();
			if (item != null && (item.UseType == ItemTable.eCanUse.UseOne || item.UseType == ItemTable.eCanUse.UseTotal) && !item.IsCooling())
			{
				list.Add(new TipFuncButonSpecial
				{
					text = TR.Value("tip_use"),
					callback = new OnTipFuncClicked(this._OnUseItem)
				});
			}
			if (item != null && item.Quality > ItemTable.eColor.PURPLE)
			{
				list.Add(new TipFuncButon
				{
					text = TR.Value("tip_share"),
					name = "Share",
					callback = new OnTipFuncClicked(this._OnShareClicked)
				});
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 3, true, false, true);
		}

		// Token: 0x0600FDD5 RID: 64981 RVA: 0x004616BC File Offset: 0x0045FABC
		private void InitNormalItemScrollListBind()
		{
			if (this.packageTab == PetPackageTab.PetItemTab)
			{
				return;
			}
			ComUIListScript comUIListScript = this.mItemUIScrollList[1];
			if (comUIListScript == null)
			{
				return;
			}
			if (comUIListScript.IsInitialised())
			{
				return;
			}
			comUIListScript.Initialize();
			comUIListScript.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
			comUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				EPackageType type;
				if (this.packageTab == PetPackageTab.PetFoodTab)
				{
					type = EPackageType.Pet;
				}
				else
				{
					if (this.packageTab != PetPackageTab.PetEggTab)
					{
						Logger.LogError("UnSupport PetPackageTab" + this.packageTab);
						return;
					}
					type = EPackageType.Consumable;
				}
				List<ulong> list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
				int num = (list.Count <= this.MaxShowPetItemNum) ? this.MaxShowPetItemNum : this.MaxPetItemNum;
				if (this.packageTab == PetPackageTab.PetEggTab)
				{
					list = this.GetPetEggList(false);
					num = this.mPetEggMaxCount;
				}
				if (item.m_index >= 0 && item.m_index < num)
				{
					ComItem comItem = item.gameObjectBindScript as ComItem;
					if (item.m_index < list.Count)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(list[item.m_index]);
						if (item2 != null)
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							int idx = item.m_index;
							comItem.Setup(item2, delegate(GameObject obj, ItemData tipitem)
							{
								this.OnNormalItemClick(idx);
							});
							comItem.SetEnable(true);
							comItem.SetShowUnusableState(true);
						}
						else
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(null, null);
							comItem.SetEnable(true);
							comItem.SetShowBetterState(false);
							comItem.SetShowSelectState(false);
							comItem.SetShowUnusableState(false);
						}
					}
					else
					{
						comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem.Setup(null, null);
						comItem.SetEnable(true);
						comItem.SetShowBetterState(false);
						comItem.SetShowSelectState(false);
					}
				}
			};
		}

		// Token: 0x0600FDD6 RID: 64982 RVA: 0x00461724 File Offset: 0x0045FB24
		private void UpdatePetItemScrollListBind(ComUIListElementScript item, bool bCheckCover)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.PetInfoList.Count)
			{
				return;
			}
			Image com = component.GetCom<Image>("IconRoot");
			if (this.PetInfoList[item.m_index].dataId > 0U)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.PetInfoList[item.m_index].dataId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					com.gameObject.CustomActive(false);
					return;
				}
				bool bIsCoverState = false;
				if (bCheckCover && tableItem.PetType != this.CurSelPetIndex + PetTable.ePetType.PT_ATTACK)
				{
					bIsCoverState = true;
				}
				DataManager<PetDataManager>.GetInstance().SetPetItemData(item.gameObject, this.PetInfoList[item.m_index], DataManager<PlayerBaseData>.GetInstance().JobTableID, PetTipsType.PetItemTip, bIsCoverState);
			}
			else
			{
				com.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600FDD7 RID: 64983 RVA: 0x0046182C File Offset: 0x0045FC2C
		private void RefreshPetItemListCount()
		{
			this.mItemUIScrollList[0].SetElementAmount(this.PetInfoList.Count);
			this.mGridNum.text = TR.Value("grid_info", DataManager<PetDataManager>.GetInstance().GetPetList().Count + DataManager<PetDataManager>.GetInstance().GetOnUsePetList().Count, this.MaxPetItemNum);
		}

		// Token: 0x0600FDD8 RID: 64984 RVA: 0x00461898 File Offset: 0x0045FC98
		private int GetPetEggMaxCount(int realCount)
		{
			int num = realCount / 4;
			int num2 = realCount % 4;
			if (num2 != 0)
			{
				num++;
			}
			int num3 = num * 4;
			return Mathf.Max(num3, 20);
		}

		// Token: 0x0600FDD9 RID: 64985 RVA: 0x004618C8 File Offset: 0x0045FCC8
		private List<ulong> GetPetEggList(bool bForceRefresh = false)
		{
			if (this.mPetEggList == null || bForceRefresh)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
				List<ulong> list = new List<ulong>();
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ulong num = itemsByPackageType[i];
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null)
					{
						if (DataManager<PetDataManager>.GetInstance().IsPetEggItem(item.TableID))
						{
							list.Add(num);
						}
					}
				}
				this.mPetEggList = list;
				this.mPetEggMaxCount = this.GetPetEggMaxCount(this.mPetEggList.Count);
			}
			return this.mPetEggList;
		}

		// Token: 0x0600FDDA RID: 64986 RVA: 0x00461974 File Offset: 0x0045FD74
		private void RefreshNormalItemListCount()
		{
			if (this.packageTab == PetPackageTab.PetFoodTab)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Pet);
				int addedGridNum = this.GetAddedGridNum(itemsByPackageType.Count);
				this.mItemUIScrollList[1].SetElementAmount(itemsByPackageType.Count + addedGridNum);
				this.mGridNum.text = TR.Value("grid_info", itemsByPackageType.Count, this.MaxPetItemNum);
				this.mSortRoot.CustomActive(false);
			}
			else
			{
				if (this.packageTab != PetPackageTab.PetEggTab)
				{
					return;
				}
				this.GetPetEggList(true);
				this.mItemUIScrollList[1].SetElementAmount(this.mPetEggMaxCount);
				this.mGridNum.text = TR.Value("grid_info", this.mPetEggList.Count, this.mPetEggMaxCount);
				this.mSortRoot.CustomActive(false);
			}
		}

		// Token: 0x0600FDDB RID: 64987 RVA: 0x00461A64 File Offset: 0x0045FE64
		private void UpdateOnUsePet()
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < this.UsePetBind.Length; i++)
			{
				bool flag = false;
				for (int j = 0; j < onUsePetList.Count; j++)
				{
					PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)onUsePetList[j].dataId, string.Empty, string.Empty);
					if (tableItem == null)
					{
						this.UsePetBind[i].gameObject.CustomActive(false);
					}
					else if (tableItem.PetType == i + PetTable.ePetType.PT_ATTACK)
					{
						DataManager<PetDataManager>.GetInstance().SetPetItemData(this.UsePetBind[i].gameObject, onUsePetList[j], DataManager<PlayerBaseData>.GetInstance().JobTableID, PetTipsType.OnUsePetTip, false);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.UsePetBind[i].gameObject.CustomActive(true);
				}
				else
				{
					this.UsePetBind[i].gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600FDDC RID: 64988 RVA: 0x00461B60 File Offset: 0x0045FF60
		private void SelectSuitableShowPet(bool bInit = false, int iSlotIndex = -1, bool bIsWear = false)
		{
			int num = -1;
			PetInfo followPet = DataManager<PetDataManager>.GetInstance().GetFollowPet();
			if (bInit && followPet.dataId != 0U)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)followPet.dataId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.PetType > PetTable.ePetType.PT_NONE)
				{
					num = tableItem.PetType - PetTable.ePetType.PT_ATTACK;
				}
			}
			else
			{
				List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
				bool flag = false;
				if (bIsWear)
				{
					for (int i = 0; i < onUsePetList.Count; i++)
					{
						PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							if (iSlotIndex + PetTable.ePetType.PT_ATTACK == tableItem2.PetType)
							{
								num = iSlotIndex;
								break;
							}
						}
					}
				}
				else
				{
					int num2 = 2;
					for (int j = 0; j < onUsePetList.Count; j++)
					{
						PetTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)onUsePetList[j].dataId, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							if (num2 + PetTable.ePetType.PT_ATTACK > tableItem3.PetType)
							{
								num2 = tableItem3.PetType - PetTable.ePetType.PT_ATTACK;
							}
							flag = true;
						}
					}
					if (flag)
					{
						num = num2;
					}
				}
			}
			if (num == -1)
			{
				this._setNonePetEquiped(false);
				return;
			}
			for (int k = 0; k < this.UsePet.Length; k++)
			{
				this.UsePet[k].isOn = false;
				if (k == num)
				{
					this.UsePet[k].isOn = true;
				}
			}
		}

		// Token: 0x0600FDDD RID: 64989 RVA: 0x00461D0C File Offset: 0x0046010C
		private void UpdatePackageType()
		{
			for (int i = 0; i < this.mItemUIScrollList.Length; i++)
			{
				if (i == (int)this.packageTab)
				{
					this.mItemUIScrollList[i].gameObject.CustomActive(true);
				}
				else
				{
					this.mItemUIScrollList[i].gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600FDDE RID: 64990 RVA: 0x00461D6C File Offset: 0x0046016C
		private void UpdateSelPetInfo()
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.SelPetIsFollowPet())
			{
				this.mShowInTown.isOn = true;
			}
			else
			{
				this.mShowInTown.isOn = false;
			}
			this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, tableItem.Quality);
			this.mLevel.text = string.Format("Lv.{0}/{1}", this.CurSelPetInfo.level, tableItem.MaxLv);
			this.mSatiety.text = string.Format("{0}/{1}", this.CurSelPetInfo.hunger, this.MaxSatietyNum);
			this.UpdateActor((int)this.CurSelPetInfo.dataId);
			DataManager<PetDataManager>.GetInstance().UpdateStarsShow(tableItem, this.CurSelPetInfo, 0, ref this.starsGray, ref this.HalfStars, ref this.HalfShadowStars, false, -1);
			this.DrawPetExpBar((int)this.CurSelPetInfo.level, (ulong)this.CurSelPetInfo.exp, tableItem.Quality, true);
		}

		// Token: 0x0600FDDF RID: 64991 RVA: 0x00461EA4 File Offset: 0x004602A4
		private void UpdateActor(int iPetID)
		{
			PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>(iPetID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
				{
					iPetID
				});
			}
			else if (Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ModeID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.ModeID
				});
			}
			else
			{
				PlayerUtility.LoadPetAvatarRenderEx(iPetID, this.mAvatarRenderer, true);
				Vector3 avatarPos = this.mAvatarRenderer.avatarPos;
				avatarPos.y = (float)tableItem.ChangedHeight / 1000f;
				this.mAvatarRenderer.avatarPos = avatarPos;
				Quaternion avatarRoation = this.mAvatarRenderer.avatarRoation;
				this.mAvatarRenderer.avatarRoation = Quaternion.Euler(avatarRoation.x, (float)tableItem.ModelOrientation / 1000f, avatarRoation.z);
				Vector3 avatarScale = this.mAvatarRenderer.avatarScale;
				Vector3 avatarScale2 = this.mAvatarRenderer.avatarScale;
				avatarScale2.y = (avatarScale2.x = (avatarScale2.z = (float)tableItem.PetModelSize / 1000f));
				this.mAvatarRenderer.avatarScale = avatarScale2;
			}
		}

		// Token: 0x0600FDE0 RID: 64992 RVA: 0x00461FF4 File Offset: 0x004603F4
		private void DrawPetExpBar(int iLevel, ulong PetExp, PetTable.eQuality ePetQuality, bool force)
		{
			this.mExp.SetExp(PetExp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurPetExpBar(iLevel, exp, ePetQuality));
		}

		// Token: 0x0600FDE1 RID: 64993 RVA: 0x00462030 File Offset: 0x00460430
		private void UpdatePetListData()
		{
			this.PetInfoList.Clear();
			List<PetInfo> petList = DataManager<PetDataManager>.GetInstance().GetPetList();
			int num = 0;
			this.PetInfoList = DataManager<PetDataManager>.GetInstance().GetPetSortListBySortType(petList, ref num, this.CurSelSortType, this.MaxPetItemNum);
			int addedGridNum = this.GetAddedGridNum(num);
			for (int i = 0; i < addedGridNum; i++)
			{
				this.PetInfoList.Add(new PetInfo());
			}
			this.mGridNum.text = TR.Value("grid_info", num, this.MaxPetItemNum);
		}

		// Token: 0x0600FDE2 RID: 64994 RVA: 0x004620C4 File Offset: 0x004604C4
		private void UpdateCurSelOnUsePet()
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				if (onUsePetList[i].id == this.CurSelPetInfo.id)
				{
					DataManager<PetDataManager>.GetInstance().SetPetData(this.CurSelPetInfo, onUsePetList[i]);
					break;
				}
			}
		}

		// Token: 0x0600FDE3 RID: 64995 RVA: 0x0046212C File Offset: 0x0046052C
		private PetInfo GetSelPetInfo(int iIdex)
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			PetInfo petInfo = new PetInfo();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)onUsePetList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.PetType == iIdex + PetTable.ePetType.PT_ATTACK)
				{
					DataManager<PetDataManager>.GetInstance().SetPetData(petInfo, onUsePetList[i]);
					break;
				}
			}
			return petInfo;
		}

		// Token: 0x0600FDE4 RID: 64996 RVA: 0x004621B0 File Offset: 0x004605B0
		private bool IsCurSelPetRemove()
		{
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				if (onUsePetList[i].id == this.CurSelPetInfo.id)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600FDE5 RID: 64997 RVA: 0x00462200 File Offset: 0x00460600
		private bool SelPetIsFollowPet()
		{
			PetInfo followPet = DataManager<PetDataManager>.GetInstance().GetFollowPet();
			return followPet.id > 0UL && followPet.id == this.CurSelPetInfo.id;
		}

		// Token: 0x0600FDE6 RID: 64998 RVA: 0x00462240 File Offset: 0x00460640
		private int GetAddedGridNum(int RealCount)
		{
			int result = 0;
			if (this.MaxShowPetItemNum >= RealCount)
			{
				result = this.MaxShowPetItemNum - RealCount;
			}
			else if (RealCount % 5 > 0)
			{
				result = 5 - RealCount % 5;
			}
			return result;
		}

		// Token: 0x0600FDE7 RID: 64999 RVA: 0x0046227C File Offset: 0x0046067C
		private void PlayEquipEffect(int iIndex)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.EquipEffectPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.UsePet[iIndex].gameObject, false);
		}

		// Token: 0x0600FDE8 RID: 65000 RVA: 0x004622BD File Offset: 0x004606BD
		private void OnClickOKRemove()
		{
			this.SendRemovePetReq();
		}

		// Token: 0x0600FDE9 RID: 65001 RVA: 0x004622C8 File Offset: 0x004606C8
		private void SendRemovePetReq()
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SceneSetPetSoltReq sceneSetPetSoltReq = new SceneSetPetSoltReq();
			sceneSetPetSoltReq.petType = (byte)tableItem.PetType;
			sceneSetPetSoltReq.petId = 0UL;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSetPetSoltReq>(ServerType.GATE_SERVER, sceneSetPetSoltReq);
		}

		// Token: 0x0600FDEA RID: 65002 RVA: 0x00462328 File Offset: 0x00460728
		private void SendFollowPetReq(bool bFollow)
		{
			SceneSetPetFollowReq sceneSetPetFollowReq = new SceneSetPetFollowReq();
			if (bFollow)
			{
				sceneSetPetFollowReq.id = this.CurSelPetInfo.id;
			}
			else
			{
				sceneSetPetFollowReq.id = 0UL;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSetPetFollowReq>(ServerType.GATE_SERVER, sceneSetPetFollowReq);
		}

		// Token: 0x0600FDEB RID: 65003 RVA: 0x0046236E File Offset: 0x0046076E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FDEC RID: 65004 RVA: 0x00462374 File Offset: 0x00460774
		protected override void _OnUpdate(float timeElapsed)
		{
			if (null != this.mAvatarRenderer)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.mAvatarRenderer.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x0600FDED RID: 65005 RVA: 0x00462500 File Offset: 0x00460900
		protected override void _bindExUI()
		{
			this.mAvatarRenderer = this.mBind.GetCom<GeAvatarRendererEx>("AvatarRenderer");
			this.mActorShowRoot = this.mBind.GetGameObject("ActorShowRoot");
			this.mGroupUp = this.mBind.GetCom<Button>("GroupUp");
			if (null != this.mGroupUp)
			{
				this.mGroupUp.onClick.AddListener(new UnityAction(this._onGroupUpButtonClick));
			}
			this.mInfo = this.mBind.GetCom<Button>("Info");
			if (null != this.mInfo)
			{
				this.mInfo.onClick.AddListener(new UnityAction(this._onInfoButtonClick));
			}
			this.mRemove = this.mBind.GetCom<Button>("Remove");
			if (null != this.mRemove)
			{
				this.mRemove.onClick.AddListener(new UnityAction(this._onRemoveButtonClick));
			}
			this.mShowInTown = this.mBind.GetCom<Toggle>("ShowInTown");
			if (null != this.mShowInTown)
			{
				this.mShowInTown.onValueChanged.AddListener(new UnityAction<bool>(this._onShowInTownToggleValueChange));
			}
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mExp = this.mBind.GetCom<ComExpBar>("Exp");
			this.mGridNum = this.mBind.GetCom<Text>("GridNum");
			this.mBtSelSortType = this.mBind.GetCom<Button>("btSelSortType");
			if (null != this.mBtSelSortType)
			{
				this.mBtSelSortType.onClick.AddListener(new UnityAction(this._onBtSelSortTypeButtonClick));
			}
			this.mShowSortType = this.mBind.GetCom<Text>("ShowSortType");
			this.mSortTypeListRoot = this.mBind.GetGameObject("SortTypeListRoot");
			this.mSatiety = this.mBind.GetCom<Text>("Satiety");
			this.mSortRoot = this.mBind.GetGameObject("SortRoot");
			this.mProperty = this.mBind.GetCom<Button>("Property");
			if (null != this.mProperty)
			{
				this.mProperty.onClick.AddListener(new UnityAction(this._onPropertyButtonClick));
			}
			this.mSelectTips = this.mBind.GetCom<Text>("SelectTips");
			this.mLook = this.mBind.GetCom<Button>("Look");
			if (null != this.mLook)
			{
				this.mLook.onClick.AddListener(new UnityAction(this._onLookButtonClick));
			}
			this.mGetPath = this.mBind.GetCom<Button>("GetPath");
			if (null != this.mGetPath)
			{
				this.mGetPath.onClick.AddListener(new UnityAction(this._onGetPathButtonClick));
			}
			this.mNoneEquipRoot = this.mBind.GetGameObject("NoneEquipRoot");
			this.mPetEggRedPoint = this.mBind.GetGameObject("petEggRedPoint");
			this.mPetRedPoint = this.mBind.GetGameObject("petRedPoint");
			this.mGroupUpRedPoint = this.mBind.GetGameObject("groupUpRedPoint");
			this.mPetToggle = this.mBind.GetCom<Toggle>("PetToggle");
			if (null != this.mPetToggle)
			{
			}
		}

		// Token: 0x0600FDEE RID: 65006 RVA: 0x00462898 File Offset: 0x00460C98
		protected override void _unbindExUI()
		{
			this.mAvatarRenderer = null;
			this.mActorShowRoot = null;
			if (null != this.mGroupUp)
			{
				this.mGroupUp.onClick.RemoveListener(new UnityAction(this._onGroupUpButtonClick));
			}
			this.mGroupUp = null;
			if (null != this.mInfo)
			{
				this.mInfo.onClick.RemoveListener(new UnityAction(this._onInfoButtonClick));
			}
			this.mInfo = null;
			if (null != this.mRemove)
			{
				this.mRemove.onClick.RemoveListener(new UnityAction(this._onRemoveButtonClick));
			}
			this.mRemove = null;
			if (null != this.mShowInTown)
			{
				this.mShowInTown.onValueChanged.RemoveListener(new UnityAction<bool>(this._onShowInTownToggleValueChange));
			}
			this.mShowInTown = null;
			this.mName = null;
			this.mLevel = null;
			this.mExp = null;
			this.mGridNum = null;
			if (null != this.mBtSelSortType)
			{
				this.mBtSelSortType.onClick.RemoveListener(new UnityAction(this._onBtSelSortTypeButtonClick));
			}
			this.mBtSelSortType = null;
			this.mShowSortType = null;
			this.mSortTypeListRoot = null;
			this.mSatiety = null;
			this.mSortRoot = null;
			if (null != this.mProperty)
			{
				this.mProperty.onClick.RemoveListener(new UnityAction(this._onPropertyButtonClick));
			}
			this.mProperty = null;
			this.mSelectTips = null;
			if (null != this.mLook)
			{
				this.mLook.onClick.RemoveListener(new UnityAction(this._onLookButtonClick));
			}
			this.mLook = null;
			if (null != this.mGetPath)
			{
				this.mGetPath.onClick.RemoveListener(new UnityAction(this._onGetPathButtonClick));
			}
			this.mGetPath = null;
			this.mNoneEquipRoot = null;
			this.mPetEggRedPoint = null;
			this.mPetRedPoint = null;
			this.mGroupUpRedPoint = null;
			if (null != this.mPetToggle)
			{
			}
			this.mPetToggle = null;
		}

		// Token: 0x0600FDEF RID: 65007 RVA: 0x00462AC6 File Offset: 0x00460EC6
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<PetPacketFrame>(this, false);
		}

		// Token: 0x0600FDF0 RID: 65008 RVA: 0x00462AD8 File Offset: 0x00460ED8
		private void _onGroupUpButtonClick()
		{
			if (DataManager<ChijiDataManager>.GetInstance().CheckCurrentSystemIsClientSystemGameBattle())
			{
				return;
			}
			DataManager<PetDataManager>.GetInstance().OpenPetInfoFrame(PetInfoTabType.Pet_UpLevel, this.CurSelPetInfo);
			if (this._isCurrentSelectedPetContainFeedCounts())
			{
				DataManager<PetDataManager>.GetInstance().IsUserClickFeedCount = true;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PetGoldFeedClick, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
			this._updateGroupUpRedPoint(null);
		}

		// Token: 0x0600FDF1 RID: 65009 RVA: 0x00462B4C File Offset: 0x00460F4C
		private bool _isCurrentSelectedPetContainFeedCounts()
		{
			return DataManager<PetDataManager>.GetInstance().IsSelectPetsContainGoldFeedCount();
		}

		// Token: 0x0600FDF2 RID: 65010 RVA: 0x00462B58 File Offset: 0x00460F58
		private void _onInfoButtonClick()
		{
			if (DataManager<ChijiDataManager>.GetInstance().CheckCurrentSystemIsClientSystemGameBattle())
			{
				return;
			}
			DataManager<PetDataManager>.GetInstance().OpenPetInfoFrame(PetInfoTabType.Pet_Feed, this.CurSelPetInfo);
		}

		// Token: 0x0600FDF3 RID: 65011 RVA: 0x00462B7B File Offset: 0x00460F7B
		private void _onRemoveButtonClick()
		{
			SystemNotifyManager.SystemNotify(8509, new UnityAction(this.OnClickOKRemove));
		}

		// Token: 0x0600FDF4 RID: 65012 RVA: 0x00462B94 File Offset: 0x00460F94
		private void _onShowInTownToggleValueChange(bool changed)
		{
			PetInfo followPet = DataManager<PetDataManager>.GetInstance().GetFollowPet();
			if (changed)
			{
				if (followPet.id == this.CurSelPetInfo.id)
				{
					return;
				}
			}
			else if (followPet.id != this.CurSelPetInfo.id)
			{
				return;
			}
			this.SendFollowPetReq(changed);
		}

		// Token: 0x0600FDF5 RID: 65013 RVA: 0x00462BEC File Offset: 0x00460FEC
		private void _onBtSelSortTypeButtonClick()
		{
			this.mSortTypeListRoot.CustomActive(!this.mSortTypeListRoot.activeSelf);
		}

		// Token: 0x0600FDF6 RID: 65014 RVA: 0x00462C07 File Offset: 0x00461007
		private void _onPropertyButtonClick()
		{
			DataManager<PetDataManager>.GetInstance().OpenPetInfoFrame(PetInfoTabType.Pet_Property, this.CurSelPetInfo);
		}

		// Token: 0x0600FDF7 RID: 65015 RVA: 0x00462C1A File Offset: 0x0046101A
		private void _onLookButtonClick()
		{
			DataManager<PetDataManager>.GetInstance().OnShowPetTips(this.CurSelPetInfo, DataManager<PlayerBaseData>.GetInstance().JobTableID, PetTipsType.OnUsePetTip);
		}

		// Token: 0x0600FDF8 RID: 65016 RVA: 0x00462C38 File Offset: 0x00461038
		private void _onGetPathButtonClick()
		{
			if (DataManager<ChijiDataManager>.GetInstance().CheckCurrentSystemIsClientSystemGameBattle())
			{
				return;
			}
			ItemComeLink.OnLink(102, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x04009FC5 RID: 40901
		private string EquipEffectPath = "Effects/Scene_effects/EffectUI/EffUI_cwkl_zhuangbei";

		// Token: 0x04009FC6 RID: 40902
		private const int MaxPackageTypeNum = 2;

		// Token: 0x04009FC7 RID: 40903
		private const int MaxOnUsePetNum = 3;

		// Token: 0x04009FC8 RID: 40904
		private const int MaxStarNum = 5;

		// Token: 0x04009FC9 RID: 40905
		private const int SortTypeNum = 2;

		// Token: 0x04009FCA RID: 40906
		private int MaxPetItemNum;

		// Token: 0x04009FCB RID: 40907
		private int MaxShowPetItemNum = 20;

		// Token: 0x04009FCC RID: 40908
		private int MaxSatietyNum;

		// Token: 0x04009FCD RID: 40909
		private PetPackageTab packageTab;

		// Token: 0x04009FCE RID: 40910
		private PetItemSortType CurSelSortType;

		// Token: 0x04009FCF RID: 40911
		private List<PetInfo> PetInfoList = new List<PetInfo>();

		// Token: 0x04009FD0 RID: 40912
		private PetInfo CurSelPetInfo = new PetInfo();

		// Token: 0x04009FD1 RID: 40913
		private int CurSelPetIndex;

		// Token: 0x04009FD2 RID: 40914
		[UIObject("TipsRoot/TipsParent")]
		private GameObject tipsParent;

		// Token: 0x04009FD3 RID: 40915
		private int m_iTipsFrameID = 9527;

		// Token: 0x04009FD4 RID: 40916
		private List<ulong> mPetEggList;

		// Token: 0x04009FD5 RID: 40917
		private int mPetEggMaxCount;

		// Token: 0x04009FD6 RID: 40918
		private const int kMaxRowCount = 4;

		// Token: 0x04009FD7 RID: 40919
		[UIControl("OnUsePet/UsePet{0}", typeof(Toggle), 1)]
		private Toggle[] UsePet = new Toggle[3];

		// Token: 0x04009FD8 RID: 40920
		[UIControl("OnUsePet/UsePet{0}/pos/PetItem", typeof(ComCommonBind), 1)]
		private ComCommonBind[] UsePetBind = new ComCommonBind[3];

		// Token: 0x04009FD9 RID: 40921
		[UIControl("Packet/Scroll View{0}", typeof(ComUIListScript), 1)]
		private ComUIListScript[] mItemUIScrollList = new ComUIListScript[2];

		// Token: 0x04009FDA RID: 40922
		[UIControl("PetShowArea/actorInfo/ShowInfo/stars/star{0}", typeof(UIGray), 1)]
		private UIGray[] starsGray = new UIGray[5];

		// Token: 0x04009FDB RID: 40923
		[UIControl("PetShowArea/actorInfo/ShowInfo/stars/starroot/star{0}", typeof(Image), 1)]
		private Image[] HalfStars = new Image[10];

		// Token: 0x04009FDC RID: 40924
		private Image[] HalfShadowStars = new Image[0];

		// Token: 0x04009FDD RID: 40925
		[UIControl("PacketNavigation/SortTypeSelect/SortTypeList/SortType{0}/Text", typeof(Text), 1)]
		private Text[] SortTypeTexts = new Text[2];

		// Token: 0x04009FDE RID: 40926
		private GeAvatarRendererEx mAvatarRenderer;

		// Token: 0x04009FDF RID: 40927
		private GameObject mActorShowRoot;

		// Token: 0x04009FE0 RID: 40928
		private Button mGroupUp;

		// Token: 0x04009FE1 RID: 40929
		private Button mInfo;

		// Token: 0x04009FE2 RID: 40930
		private Button mRemove;

		// Token: 0x04009FE3 RID: 40931
		private Toggle mShowInTown;

		// Token: 0x04009FE4 RID: 40932
		private Text mName;

		// Token: 0x04009FE5 RID: 40933
		private Text mLevel;

		// Token: 0x04009FE6 RID: 40934
		private ComExpBar mExp;

		// Token: 0x04009FE7 RID: 40935
		private Text mGridNum;

		// Token: 0x04009FE8 RID: 40936
		private Button mBtSelSortType;

		// Token: 0x04009FE9 RID: 40937
		private Text mShowSortType;

		// Token: 0x04009FEA RID: 40938
		private GameObject mSortTypeListRoot;

		// Token: 0x04009FEB RID: 40939
		private Text mSatiety;

		// Token: 0x04009FEC RID: 40940
		private GameObject mSortRoot;

		// Token: 0x04009FED RID: 40941
		private Button mProperty;

		// Token: 0x04009FEE RID: 40942
		private Text mSelectTips;

		// Token: 0x04009FEF RID: 40943
		private Button mLook;

		// Token: 0x04009FF0 RID: 40944
		private Button mGetPath;

		// Token: 0x04009FF1 RID: 40945
		private GameObject mNoneEquipRoot;

		// Token: 0x04009FF2 RID: 40946
		private GameObject mPetEggRedPoint;

		// Token: 0x04009FF3 RID: 40947
		private GameObject mPetRedPoint;

		// Token: 0x04009FF4 RID: 40948
		private GameObject mGroupUpRedPoint;

		// Token: 0x04009FF5 RID: 40949
		private Toggle mPetToggle;
	}
}

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
	// Token: 0x0200170A RID: 5898
	internal class StoragePackageFrame : ClientFrame
	{
		// Token: 0x0600E7B0 RID: 59312 RVA: 0x003D1A68 File Offset: 0x003CFE68
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/StoragePackageFrame";
		}

		// Token: 0x0600E7B1 RID: 59313 RVA: 0x003D1A70 File Offset: 0x003CFE70
		protected override void _OnOpenFrame()
		{
			EPackageType a_type = EPackageType.Equip;
			if (this.userData != null)
			{
				a_type = (EPackageType)this.userData;
			}
			this._Initialize(a_type);
		}

		// Token: 0x0600E7B2 RID: 59314 RVA: 0x003D1A9D File Offset: 0x003CFE9D
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x0600E7B3 RID: 59315 RVA: 0x003D1AA8 File Offset: 0x003CFEA8
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._OnItemSellSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemQualityChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DecomposeFinished, new ClientEventSystem.UIEventHandler(this._OnItemDecomposeFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
		}

		// Token: 0x0600E7B4 RID: 59316 RVA: 0x003D1BC4 File Offset: 0x003CFFC4
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStoreSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._OnItemSellSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemQualityChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DecomposeFinished, new ClientEventSystem.UIEventHandler(this._OnItemDecomposeFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemStrengthenFail, new ClientEventSystem.UIEventHandler(this._OnUpdateItemList));
		}

		// Token: 0x0600E7B5 RID: 59317 RVA: 0x003D1CDF File Offset: 0x003D00DF
		private void _Initialize(EPackageType a_type)
		{
			this._InitQuickDecompose();
			this._InitItemList();
			this._SetupTabTitle(a_type);
			this._RegisterUIEvent();
		}

		// Token: 0x0600E7B6 RID: 59318 RVA: 0x003D1CFC File Offset: 0x003D00FC
		private void _Clear()
		{
			this._ClearQuickDecompose();
			this._UnRegisterUIEvent();
			this.m_currentItemType = EPackageType.Invalid;
			this.m_eShowMode = StoragePackageFrame.EItemsShowMode.Normal;
			this.m_bToggleBlockSignal = false;
			for (int i = 0; i < this.m_arrPackageInfos.Length; i++)
			{
				this.m_arrPackageInfos[i].objRedPoint = null;
				this.m_arrPackageInfos[i].toggle = null;
			}
		}

		// Token: 0x0600E7B7 RID: 59319 RVA: 0x003D1D5F File Offset: 0x003D015F
		private void _InitItemList()
		{
			this.m_comItemListEx.Initialize();
			this.m_comItemListEx.onBindItem = ((GameObject obj) => base.CreateComItem(obj));
			this.m_comItemListEx.onItemVisiable = delegate(ComUIListElementScript item)
			{
				ComGridBindItem component = item.GetComponent<ComGridBindItem>();
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
				int num = DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType];
				if (item.m_index >= 0 && item.m_index < 100)
				{
					if (item.m_index < itemsByPackageType.Count)
					{
						ComItem comItem = item.gameObjectBindScript as ComItem;
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[item.m_index]);
						if (item2 != null)
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(item2, new ComItem.OnItemClicked(this._OnItemClicked));
							if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Store)
							{
								comItem.SetEnable(item2.CanStore());
							}
							else if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Decompose)
							{
								comItem.SetEnable(item2.CanDecompose && item2.StrengthenLevel < 10);
							}
							else
							{
								comItem.SetEnable(true);
							}
							comItem.SetShowSelectState(this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Decompose);
							comItem.SetShowBetterState(this.m_currentItemType == EPackageType.Equip);
							comItem.SetShowUnusableState(true);
							if (component != null)
							{
								component.param1 = item.gameObject.name;
								component.param2 = item2.GUID;
							}
						}
						else
						{
							comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
							comItem.Setup(null, null);
							comItem.SetEnable(true);
							comItem.SetShowBetterState(false);
							comItem.SetShowSelectState(false);
							comItem.SetShowUnusableState(false);
							if (component != null)
							{
								component.param1 = null;
								component.param2 = 0;
							}
						}
					}
					else if (item.m_index < num)
					{
						ComItem comItem2 = item.gameObjectBindScript as ComItem;
						comItem2.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem2.Setup(null, null);
						comItem2.SetEnable(true);
						comItem2.SetShowBetterState(false);
						comItem2.SetShowSelectState(false);
						comItem2.SetShowUnusableState(false);
						if (component != null)
						{
							component.param1 = null;
							component.param2 = 0;
						}
					}
					else
					{
						ComItem comItem3 = item.gameObjectBindScript as ComItem;
						comItem3.SetupSlot(ComItem.ESlotType.Locked, string.Empty, delegate(GameObject var)
						{
							this._UpgradePackageSize();
						}, string.Empty);
						comItem3.Setup(null, null);
						comItem3.SetEnable(true);
						comItem3.SetShowBetterState(false);
						comItem3.SetShowSelectState(false);
						comItem3.SetShowUnusableState(false);
						if (component != null)
						{
							component.param1 = null;
							component.param2 = 0;
						}
					}
				}
			};
		}

		// Token: 0x0600E7B8 RID: 59320 RVA: 0x003D1D9C File Offset: 0x003D019C
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Decompose)
			{
				if (item.CanDecompose)
				{
					item.IsSelected = !item.IsSelected;
					if (item.bLocked)
					{
						item.IsSelected = false;
					}
					obj.GetComponent<ComItem>().MarkDirty();
				}
				return;
			}
			if (this.frameMgr.IsFrameOpen<StorageFrame>(null))
			{
				List<TipFuncButon> list = new List<TipFuncButon>();
				if (item.CanStore() || DataManager<StorageDataManager>.GetInstance().CurrentStorageType == StorageType.RoleStorage)
				{
					list.Add(new TipFuncButonSpecial
					{
						text = TR.Value("tip_store"),
						callback = new OnTipFuncClicked(this._OnStoreItem)
					});
				}
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 3, true, false, true);
			}
		}

		// Token: 0x0600E7B9 RID: 59321 RVA: 0x003D1E60 File Offset: 0x003D0260
		private ItemData _GetCompareItem(ItemData item)
		{
			ItemData result = null;
			if (item != null && item.WillCanEquip())
			{
				List<ulong> list = null;
				if (item.PackageType == EPackageType.Equip)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				}
				else if (item.PackageType == EPackageType.Fashion)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
				}
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
						if (item2 != null && item2.GUID != item.GUID && item2.IsWearSoltEqual(item))
						{
							result = item2;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600E7BA RID: 59322 RVA: 0x003D1F14 File Offset: 0x003D0314
		private void _TryOnUseItem(ItemData item, object data)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnUseItem(item, data);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this._OnUseItem(item, data);
		}

		// Token: 0x0600E7BB RID: 59323 RVA: 0x003D1FB8 File Offset: 0x003D03B8
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

		// Token: 0x0600E7BC RID: 59324 RVA: 0x003D2111 File Offset: 0x003D0511
		private void _OnUseTotalItem(ItemData item, object data)
		{
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, true, 0, 0);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7BD RID: 59325 RVA: 0x003D2134 File Offset: 0x003D0534
		private void _OnTryGetItem(ItemData item, object data)
		{
			if (item != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				ItemComeLink.OnLink(item.TableID, 0, false, null, false, tableItem.bNeedJump > 0, false, null, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7BE RID: 59326 RVA: 0x003D218C File Offset: 0x003D058C
		private void _OnForgeItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
				smithShopNewLinkData.itemData = a_item;
				if (a_item.SubType == 25)
				{
					smithShopNewLinkData.iDefaultFirstTabId = 2;
					smithShopNewLinkData.iDefaultSecondTabId = 0;
				}
				else
				{
					smithShopNewLinkData.iDefaultFirstTabId = 0;
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7BF RID: 59327 RVA: 0x003D21FB File Offset: 0x003D05FB
		private void _OnFashionAttrSelItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				FashionSmithShopFrame.OpenLinkFrame(string.Format("0_{0}", a_item.GUID));
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7C0 RID: 59328 RVA: 0x003D2227 File Offset: 0x003D0627
		private void _OnSellItem(ItemData item, object data)
		{
			if (item != null)
			{
				this.frameMgr.OpenFrame<SellItemFrame>(FrameLayer.Middle, item, string.Empty);
			}
		}

		// Token: 0x0600E7C1 RID: 59329 RVA: 0x003D2244 File Offset: 0x003D0644
		private void _OnStoreItem(ItemData item, object data)
		{
			if (item != null)
			{
				if (item.Count > 1)
				{
					StoreItemFrame storeItemFrame = this.frameMgr.OpenFrame<StoreItemFrame>(FrameLayer.Middle, null, string.Empty) as StoreItemFrame;
					if (storeItemFrame != null)
					{
						storeItemFrame.StoreItem(item);
					}
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
				else
				{
					if (item.Type == ItemTable.eType.EQUIP && DataManager<StorageDataManager>.GetInstance().CurrentStorageType == StorageType.AccountStorage && !item.CheckEquipmentIsCanPutAccountWarehouse())
					{
						SystemNotifyManager.SystemNotify(1000125, string.Empty);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						return;
					}
					if (DataManager<StorageDataManager>.GetInstance().CurrentStorageType == StorageType.RoleStorage && item.IsItemInUnUsedEquipPlan)
					{
						string msgContent = TR.Value("Equip_Plan_Item_CanNot_Store_Format", DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanId);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					DataManager<StorageDataManager>.GetInstance().OnSendStoreItemReq(item, item.Count);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
			}
		}

		// Token: 0x0600E7C2 RID: 59330 RVA: 0x003D2330 File Offset: 0x003D0730
		private void _OnUnWear(ItemData item, object data)
		{
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7C3 RID: 59331 RVA: 0x003D2350 File Offset: 0x003D0750
		private void _OnShareClicked(ItemData item, object data)
		{
			DataManager<ChatManager>.GetInstance().ShareEquipment(item, ChatType.CT_WORLD);
		}

		// Token: 0x0600E7C4 RID: 59332 RVA: 0x003D2360 File Offset: 0x003D0760
		private void _TryDeTransferClicked(ItemData item, object data)
		{
			if (item == null)
			{
				return;
			}
			SystemNotifyManager.SystemNotify(2006, delegate()
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
				MonoSingleton<AudioManager>.instance.PlaySound(102);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}, null, new object[]
			{
				item.GetColorName(string.Empty, false)
			});
		}

		// Token: 0x0600E7C5 RID: 59333 RVA: 0x003D23B8 File Offset: 0x003D07B8
		private void _TryDeSealClicked(ItemData item, object data)
		{
			if (item.Type == ItemTable.eType.EQUIP)
			{
				int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
				if (masterPriority == 2)
				{
					SystemNotifyManager.SystemNotifyOkCancel(7019, delegate
					{
						this._OnDeSealClicked(item, data);
					}, null, FrameLayer.High, false);
					return;
				}
			}
			this._OnDeSealClicked(item, data);
		}

		// Token: 0x0600E7C6 RID: 59334 RVA: 0x003D245C File Offset: 0x003D085C
		private void _OnDeSealClicked(ItemData item, object data)
		{
			if (item != null && item.Packing)
			{
				if (item.CanEquip())
				{
					SystemNotifyManager.SystemNotify(2006, delegate()
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
						MonoSingleton<AudioManager>.instance.PlaySound(102);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}, null, new object[]
					{
						item.GetColorName(string.Empty, false)
					});
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
				}
			}
		}

		// Token: 0x0600E7C7 RID: 59335 RVA: 0x003D24FE File Offset: 0x003D08FE
		private void _OnDecomposeClicked(ItemData item, object data)
		{
			if (item != null && item.CanDecompose)
			{
				this._DecomposeEquips(delegate
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}, new ItemData[]
				{
					item
				});
			}
		}

		// Token: 0x0600E7C8 RID: 59336 RVA: 0x003D253E File Offset: 0x003D093E
		private void _OnItemRenewal(ItemData item, object data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RenewalItemFrame>(FrameLayer.Middle, item, string.Empty);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600E7C9 RID: 59337 RVA: 0x003D255C File Offset: 0x003D095C
		private void _OnItemLink(ItemData item, object data)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null && !string.IsNullOrEmpty(tableItem.LinkInfo))
			{
				FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem.FunctionID, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.FinishLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SystemNotify(tableItem2.CommDescID, string.Empty);
					return;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600E7CA RID: 59338 RVA: 0x003D2600 File Offset: 0x003D0A00
		private void _SetupTabTitle(EPackageType a_type)
		{
			this.m_bToggleBlockSignal = true;
			for (int i = 0; i < this.m_arrPackageInfos.Length; i++)
			{
				StoragePackageFrame.PackageInfo info = this.m_arrPackageInfos[i];
				info.toggle = Utility.GetComponetInChild<Toggle>(this.frame, string.Format("Tabs/Title{0}", i + 1));
				info.toggle.onValueChanged.RemoveAllListeners();
				info.toggle.onValueChanged.AddListener(delegate(bool a_bChecked)
				{
					if (!this.m_bToggleBlockSignal)
					{
						if (a_bChecked)
						{
							EPackageType ePackageType = info.ePackageType;
							if (this.m_currentItemType != ePackageType)
							{
								this.m_currentItemType = ePackageType;
								DataManager<ItemDataManager>.GetInstance().ArrangeItemsInPackageFrame(this.m_currentItemType);
								this._SetupCurrentPage(true);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PackageTypeChanged, this.m_currentItemType, null, null, null);
							}
							this._updateFunctionButtonShowHidden();
						}
						else
						{
							info.objRedPoint.SetActive(DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(info.ePackageType));
						}
					}
				});
				info.objRedPoint = Utility.FindGameObject(this.frame, string.Format("Tabs/Title{0}/RedPoint", i + 1), true);
				info.objRedPoint.SetActive(DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(info.ePackageType));
			}
			for (int j = 0; j < this.m_arrPackageInfos.Length; j++)
			{
				StoragePackageFrame.PackageInfo packageInfo = this.m_arrPackageInfos[j];
				if (packageInfo.ePackageType == a_type)
				{
					packageInfo.toggle.isOn = false;
				}
				else
				{
					packageInfo.toggle.isOn = true;
				}
			}
			this.m_bToggleBlockSignal = false;
			StoragePackageFrame.PackageInfo packageInfo2 = this._GetPackageInfo(a_type);
			if (packageInfo2 != null)
			{
				packageInfo2.toggle.isOn = true;
			}
		}

		// Token: 0x0600E7CB RID: 59339 RVA: 0x003D2763 File Offset: 0x003D0B63
		private void _updateFunctionButtonShowHidden()
		{
			this.m_comBtnChapterPotionSet.gameObject.SetActive(this.m_currentItemType == EPackageType.Consumable);
			this.m_comBtnQuickDecompose.gameObject.SetActive(this.m_currentItemType != EPackageType.Consumable);
		}

		// Token: 0x0600E7CC RID: 59340 RVA: 0x003D279C File Offset: 0x003D0B9C
		private StoragePackageFrame.PackageInfo _GetPackageInfo(EPackageType a_type)
		{
			for (int i = 0; i < this.m_arrPackageInfos.Length; i++)
			{
				if (this.m_arrPackageInfos[i].ePackageType == a_type)
				{
					return this.m_arrPackageInfos[i];
				}
			}
			return null;
		}

		// Token: 0x0600E7CD RID: 59341 RVA: 0x003D27E0 File Offset: 0x003D0BE0
		private void _UpdateTabs()
		{
			if (this.m_arrPackageInfos != null)
			{
				for (int i = 0; i < this.m_arrPackageInfos.Length; i++)
				{
					StoragePackageFrame.PackageInfo packageInfo = this.m_arrPackageInfos[i];
					if (packageInfo != null && packageInfo.objRedPoint != null)
					{
						packageInfo.objRedPoint.SetActive(DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(packageInfo.ePackageType));
					}
				}
			}
		}

		// Token: 0x0600E7CE RID: 59342 RVA: 0x003D284C File Offset: 0x003D0C4C
		private void _SetupCurrentPage(bool resetScrollPos = false)
		{
			this._UpdateTabs();
			this._UpdateItemList();
			if (resetScrollPos && this.m_scrollRect)
			{
				this.m_scrollRect.verticalNormalizedPosition = 1f;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			this.m_gridCount.text = string.Format("{0}/{1}", itemsByPackageType.Count, DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)this.m_currentItemType]);
			this.m_comBtnQuickDecompose.SetEnable(this.m_currentItemType == EPackageType.Equip);
			this._CloseQuickDecompose();
		}

		// Token: 0x0600E7CF RID: 59343 RVA: 0x003D28F0 File Offset: 0x003D0CF0
		private void _UpdateItemList()
		{
			this.m_comItemListEx.SetElementAmount(100);
		}

		// Token: 0x0600E7D0 RID: 59344 RVA: 0x003D2900 File Offset: 0x003D0D00
		private void _UpgradePackageSize()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().PackBaseSize + 10;
			if (num <= 100)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num, string.Empty, string.Empty);
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num + 1, string.Empty, string.Empty);
				if (tableItem != null && tableItem2 != null)
				{
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					costInfo.nMoneyID = tableItem2.Value;
					costInfo.nCount = tableItem.Value;
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("package_unlock_grids", DataManager<CostItemManager>.GetInstance().GetCostMoneiesDesc(new CostItemManager.CostInfo[]
					{
						costInfo
					})), delegate()
					{
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							SceneEnlargePackage cmd = new SceneEnlargePackage();
							NetManager.Instance().SendCommand<SceneEnlargePackage>(ServerType.GATE_SERVER, cmd);
							DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEnlargePackageRet>(delegate(SceneEnlargePackageRet msgRet)
							{
								if (msgRet == null)
								{
									return;
								}
								if (msgRet.code != 0U)
								{
									SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
								}
								else
								{
									this._SetupCurrentPage(false);
								}
							}, true, 15f, null);
						}, "common_money_cost", null);
					}, null, 0f, false);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("package_unlock_max"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600E7D1 RID: 59345 RVA: 0x003D29E8 File Offset: 0x003D0DE8
		private void _DecomposeEquips(Action a_okCallback, params ItemData[] a_arrItems)
		{
			if (a_arrItems == null || a_arrItems.Length == 0)
			{
				return;
			}
			ulong[] arrGuids = new ulong[a_arrItems.Length];
			for (int i = 0; i < a_arrItems.Length; i++)
			{
				arrGuids[i] = a_arrItems[i].GUID;
			}
			string msgContent = string.Empty;
			if (a_arrItems.Length == 1)
			{
				ItemData itemData = a_arrItems[0];
				if (itemData.StrengthenLevel >= 5)
				{
					msgContent = TR.Value("equip_single_decompose_ask_01", itemData.GetColorName("[{0}]", true), itemData.StrengthenLevel);
				}
				else if (itemData.Quality > ItemTable.eColor.BLUE)
				{
					msgContent = TR.Value("equip_single_decompose_ask_03", itemData.GetQualityDesc(), itemData.GetColorName("[{0}]", true));
				}
				else
				{
					msgContent = TR.Value("equip_single_decompose_ask_02", itemData.GetColorName("[{0}]", true));
				}
			}
			else
			{
				List<ItemData> list = new List<ItemData>();
				foreach (ItemData itemData2 in a_arrItems)
				{
					if (itemData2.StrengthenLevel >= 5 || itemData2.Quality > ItemTable.eColor.BLUE)
					{
						list.Add(itemData2);
					}
				}
				int num = a_arrItems.Length - list.Count;
				if (list.Count > 0)
				{
					list.Sort(delegate(ItemData var1, ItemData var2)
					{
						ulong basePriceByItemData = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var1);
						ulong basePriceByItemData2 = DataManager<AuctionDataManager>.GetInstance().GetBasePriceByItemData(var2);
						if (basePriceByItemData > basePriceByItemData2)
						{
							return -1;
						}
						if (basePriceByItemData < basePriceByItemData2)
						{
							return 1;
						}
						return var2.StrengthenLevel - var1.StrengthenLevel;
					});
					string text = string.Empty;
					for (int k = 0; k < list.Count; k++)
					{
						if (k > 5)
						{
							break;
						}
						text += list[k].GetColorName(" [{0}]", true);
					}
					text += " ";
					if (list.Count <= 5)
					{
						if (num > 0)
						{
							msgContent = TR.Value("equip_multi_decompose_ask_01", text, list.Count, num);
						}
						else
						{
							msgContent = TR.Value("equip_multi_decompose_ask_02", text, list.Count);
						}
					}
					else if (num > 0)
					{
						msgContent = TR.Value("equip_multi_decompose_ask_03", text, list.Count, num);
					}
					else
					{
						msgContent = TR.Value("equip_multi_decompose_ask_04", text, list.Count);
					}
				}
				else
				{
					msgContent = TR.Value("equip_multi_decompose_ask_05", num);
				}
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<ItemDataManager>.GetInstance().SendDecomposeItem(arrGuids, false);
				if (a_okCallback != null)
				{
					a_okCallback();
				}
			}, null, 0f, false);
		}

		// Token: 0x0600E7D2 RID: 59346 RVA: 0x003D2C87 File Offset: 0x003D1087
		private void _OnItemDecomposeFinished(UIEvent a_event)
		{
			this._ClearSelectState();
			this._SetupCurrentPage(false);
		}

		// Token: 0x0600E7D3 RID: 59347 RVA: 0x003D2C96 File Offset: 0x003D1096
		private void _OnItemSellSuccess(UIEvent a_event)
		{
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("package_sell_item_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			this._SetupCurrentPage(false);
		}

		// Token: 0x0600E7D4 RID: 59348 RVA: 0x003D2CB0 File Offset: 0x003D10B0
		private void _OnUpdateItemList(UIEvent a_event)
		{
			this._SetupCurrentPage(false);
			if (a_event.EventID == EUIEventID.ItemUseSuccess)
			{
				ItemData itemData = (ItemData)a_event.Param1;
				if (itemData.PackageType == EPackageType.Consumable)
				{
					Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
					Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
					bool flag = false;
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, object> keyValuePair = enumerator.Current;
						PetTable petTable = keyValuePair.Value as PetTable;
						if (petTable != null)
						{
							if (petTable.PetEggID == itemData.TableID)
							{
								flag = true;
								break;
							}
						}
					}
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
		}

		// Token: 0x0600E7D5 RID: 59349 RVA: 0x003D2D84 File Offset: 0x003D1184
		[UIEventHandle("Bottom/Arrange")]
		private void _OnArrangePackage()
		{
			SceneTrimItem sceneTrimItem = new SceneTrimItem();
			sceneTrimItem.pack = (byte)this.m_currentItemType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneTrimItem>(ServerType.GATE_SERVER, sceneTrimItem);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneTrimItemRet>(delegate(SceneTrimItemRet msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.code != 0U)
				{
					CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)msgRet.code, string.Empty, string.Empty);
					if (tableItem != null)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(Utility.ProtocolErrorString(msgRet.code), null, string.Empty, false);
					}
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().ArrangeItemsInPackageFrame(this.m_currentItemType);
					this._SetupCurrentPage(false);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600E7D6 RID: 59350 RVA: 0x003D2DD1 File Offset: 0x003D11D1
		[UIEventHandle("Bottom/GridCount/LevelUp")]
		private void _OnLevelupGridCountClicked()
		{
			this._UpgradePackageSize();
		}

		// Token: 0x0600E7D7 RID: 59351 RVA: 0x003D2DDC File Offset: 0x003D11DC
		private void _InitQuickDecompose()
		{
			if (this.m_objQuickDecomposeMask == null && MonoSingleton<LeanTween>.instance.frameBlackMask != null)
			{
				this.m_objQuickDecomposeMask = Object.Instantiate<GameObject>(MonoSingleton<LeanTween>.instance.frameBlackMask);
				this.m_objQuickDecomposeMask.transform.SetParent(Singleton<ClientSystemManager>.GetInstance().GetLayer(FrameLayer.Middle).transform, false);
				this.m_objQuickDecomposeMask.transform.SetParent(this.m_objQuickDecomposeRoot.transform, true);
				this.m_objQuickDecomposeMask.transform.SetAsFirstSibling();
			}
			for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
			{
				this.m_arrQualityToggles[i].isOn = false;
			}
			this._ClearSelectState();
			this.m_objQuickDecomposeRoot.SetActive(false);
		}

		// Token: 0x0600E7D8 RID: 59352 RVA: 0x003D2EAA File Offset: 0x003D12AA
		private void _ClearQuickDecompose()
		{
			this.m_objQuickDecomposeMask = null;
			this._CloseQuickDecompose();
		}

		// Token: 0x0600E7D9 RID: 59353 RVA: 0x003D2EB9 File Offset: 0x003D12B9
		private void _OpenQuickDecompose()
		{
			if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Normal)
			{
				this.m_eShowMode = StoragePackageFrame.EItemsShowMode.Decompose;
				this._UpdateItemList();
				this._ClearSelectState();
				this.m_objQuickDecomposeRoot.SetActive(true);
			}
		}

		// Token: 0x0600E7DA RID: 59354 RVA: 0x003D2EE8 File Offset: 0x003D12E8
		private void _CloseQuickDecompose()
		{
			if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Decompose)
			{
				this.m_eShowMode = StoragePackageFrame.EItemsShowMode.Normal;
				this._UpdateItemList();
				this._ClearSelectState();
				this.m_objQuickDecomposeRoot.SetActive(false);
				for (int i = 0; i < this.m_arrQualityToggles.Length; i++)
				{
					this.m_arrQualityToggles[i].isOn = false;
				}
			}
		}

		// Token: 0x0600E7DB RID: 59355 RVA: 0x003D2F48 File Offset: 0x003D1348
		private List<ItemData> _GetItemsByQuality(ItemTable.eColor a_quality)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item.Quality == a_quality && item.CanDecompose)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0600E7DC RID: 59356 RVA: 0x003D2FBC File Offset: 0x003D13BC
		private void _ClearSelectState()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					item.IsSelected = false;
				}
			}
		}

		// Token: 0x0600E7DD RID: 59357 RVA: 0x003D3010 File Offset: 0x003D1410
		[UIEventHandle("Bottom/ChapterPotionSet")]
		private void _OnOpenChapterPotionSetClicked()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ChapterBattlePotionSetFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E7DE RID: 59358 RVA: 0x003D3024 File Offset: 0x003D1424
		[UIEventHandle("Bottom/QuickDecompose")]
		private void _OnOpenQuickDecomposeClicked()
		{
			this._OpenQuickDecompose();
		}

		// Token: 0x0600E7DF RID: 59359 RVA: 0x003D302C File Offset: 0x003D142C
		[UIEventHandle("DecomposeGroup/Cancel")]
		private void _OnReturnClicked()
		{
			this._CloseQuickDecompose();
		}

		// Token: 0x0600E7E0 RID: 59360 RVA: 0x003D3034 File Offset: 0x003D1434
		[UIEventHandle("DecomposeGroup/Confirm")]
		private void _OnQuickDecomposeClicked()
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && item.IsSelected)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				this._DecomposeEquips(delegate
				{
					this._CloseQuickDecompose();
				}, list.ToArray());
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("package_quick_decompose_no_select"), null, string.Empty, false);
			}
		}

		// Token: 0x0600E7E1 RID: 59361 RVA: 0x003D30D8 File Offset: 0x003D14D8
		[UIEventHandle("DecomposeGroup/SelectGroup/Toggle{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void _OnSelectQualityChanged(int index, bool isChecked)
		{
			if (this.m_eShowMode == StoragePackageFrame.EItemsShowMode.Decompose)
			{
				List<ItemData> list;
				if (index == 0)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.WHITE);
				}
				else if (index == 1)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.BLUE);
				}
				else if (index == 2)
				{
					list = this._GetItemsByQuality(ItemTable.eColor.PURPLE);
				}
				else
				{
					list = new List<ItemData>();
				}
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(this.m_currentItemType);
				for (int i = 0; i < list.Count; i++)
				{
					list[i].IsSelected = (isChecked && list[i].StrengthenLevel < 10 && !list[i].bLocked);
				}
				if (list.Count > 0)
				{
					ulong guid = list[0].GUID;
					for (int j = 0; j < itemsByPackageType.Count; j++)
					{
						if (guid == itemsByPackageType[j])
						{
							this.m_comItemListEx.EnsureElementVisable(j);
						}
					}
				}
				this.m_comItemListEx.SetElementAmount(100);
			}
		}

		// Token: 0x0600E7E2 RID: 59362 RVA: 0x003D31ED File Offset: 0x003D15ED
		public void OpenQuickDecompose()
		{
			this._OpenQuickDecompose();
		}

		// Token: 0x04008C88 RID: 35976
		[UIControl("DecomposeGroup/SelectGroup/Toggle{0}", typeof(Toggle), 1)]
		private Toggle[] m_arrQualityToggles = new Toggle[3];

		// Token: 0x04008C89 RID: 35977
		[UIControl("ItemListView", typeof(ScrollRect), 0)]
		private ScrollRect m_scrollRect;

		// Token: 0x04008C8A RID: 35978
		[UIControl("ItemListView", typeof(ComUIListScriptEx), 0)]
		private ComUIListScriptEx m_comItemListEx;

		// Token: 0x04008C8B RID: 35979
		[UIControl("Bottom/GridCount/Text", null, 0)]
		private Text m_gridCount;

		// Token: 0x04008C8C RID: 35980
		[UIObject("DecomposeGroup")]
		private GameObject m_objQuickDecomposeRoot;

		// Token: 0x04008C8D RID: 35981
		[UIControl("Bottom/QuickDecompose", null, 0)]
		private ComButtonEnbale m_comBtnQuickDecompose;

		// Token: 0x04008C8E RID: 35982
		[UIControl("Bottom/ChapterPotionSet", null, 0)]
		private ComButtonEnbale m_comBtnChapterPotionSet;

		// Token: 0x04008C8F RID: 35983
		private StoragePackageFrame.EItemsShowMode m_eShowMode;

		// Token: 0x04008C90 RID: 35984
		private EPackageType m_currentItemType;

		// Token: 0x04008C91 RID: 35985
		private GameObject m_objQuickDecomposeMask;

		// Token: 0x04008C92 RID: 35986
		private bool m_bToggleBlockSignal;

		// Token: 0x04008C93 RID: 35987
		private StoragePackageFrame.PackageInfo[] m_arrPackageInfos = new StoragePackageFrame.PackageInfo[]
		{
			new StoragePackageFrame.PackageInfo
			{
				ePackageType = EPackageType.Equip
			},
			new StoragePackageFrame.PackageInfo
			{
				ePackageType = EPackageType.Material
			},
			new StoragePackageFrame.PackageInfo
			{
				ePackageType = EPackageType.Consumable
			},
			new StoragePackageFrame.PackageInfo
			{
				ePackageType = EPackageType.Title
			}
		};

		// Token: 0x0200170B RID: 5899
		private class PackageInfo
		{
			// Token: 0x04008C96 RID: 35990
			public EPackageType ePackageType;

			// Token: 0x04008C97 RID: 35991
			public Toggle toggle;

			// Token: 0x04008C98 RID: 35992
			public GameObject objRedPoint;
		}

		// Token: 0x0200170C RID: 5900
		private enum EItemsShowMode
		{
			// Token: 0x04008C9A RID: 35994
			Normal,
			// Token: 0x04008C9B RID: 35995
			Decompose,
			// Token: 0x04008C9C RID: 35996
			Store
		}
	}
}

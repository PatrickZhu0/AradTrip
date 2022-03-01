using System;
using System.Collections.Generic;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200165A RID: 5722
	internal class GuildStoreHouseClearFrame : ClientFrame
	{
		// Token: 0x0600E11E RID: 57630 RVA: 0x0039A4B9 File Offset: 0x003988B9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStoreHouseClearFrame";
		}

		// Token: 0x0600E11F RID: 57631 RVA: 0x0039A4C0 File Offset: 0x003988C0
		[UIEventHandle("Close")]
		private void _OnClickCloseFrame()
		{
			this.frameMgr.CloseFrame<GuildStoreHouseClearFrame>(this, false);
		}

		// Token: 0x0600E120 RID: 57632 RVA: 0x0039A4D0 File Offset: 0x003988D0
		public static GuildStoreHouseClearFrameData ReadyStoreRemoveData()
		{
			GuildStoreHouseClearFrameData guildStoreHouseClearFrameData = new GuildStoreHouseClearFrameData();
			guildStoreHouseClearFrameData.name = TR.Value("guild_store_house_clear_name_0");
			guildStoreHouseClearFrameData.hint = TR.Value("guild_store_house_hint_name_0");
			guildStoreHouseClearFrameData.btnName = TR.Value("guild_store_house_ok_name_0");
			guildStoreHouseClearFrameData.bClear = true;
			guildStoreHouseClearFrameData.onOK = delegate()
			{
				if (ComGuildItem.PoolItems.Count <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_clear_need_selected_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				EGuildDuty eGuildDuty = DataManager<PlayerBaseData>.GetInstance().eGuildDuty;
				GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(eGuildDuty);
				if (serverDuty < DataManager<GuildDataManager>.GetInstance().clearPower)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_clear_need_power"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				SystemNotifyManager.SystemNotify(7018, delegate()
				{
				}, delegate()
				{
					List<GuildStorageDelItemInfo> list = new List<GuildStorageDelItemInfo>();
					for (int i = 0; i < ComGuildItem.PoolItems.Count; i++)
					{
						if (null != ComGuildItem.PoolItems[i])
						{
							ComGuildItemData value = ComGuildItem.PoolItems[i].Value;
							if (value != null && value.itemData != null && value.iSelectedCount > 0)
							{
								list.Add(new GuildStorageDelItemInfo
								{
									uid = value.itemData.GUID,
									num = (ushort)value.iSelectedCount
								});
							}
						}
					}
					if (list.Count > 0)
					{
						DataManager<GuildDataManager>.GetInstance().SendDeleteStorageItems(list.ToArray());
					}
				});
			};
			return guildStoreHouseClearFrameData;
		}

		// Token: 0x0600E121 RID: 57633 RVA: 0x0039A540 File Offset: 0x00398940
		public static GuildStoreHouseClearFrameData ReadyStoreAddData()
		{
			GuildStoreHouseClearFrameData guildStoreHouseClearFrameData = new GuildStoreHouseClearFrameData();
			guildStoreHouseClearFrameData.name = TR.Value("guild_store_house_clear_name_1");
			guildStoreHouseClearFrameData.hint = TR.Value("guild_store_house_hint_name_1");
			guildStoreHouseClearFrameData.btnName = TR.Value("guild_store_house_ok_name_1");
			guildStoreHouseClearFrameData.bClear = false;
			guildStoreHouseClearFrameData.onOK = delegate()
			{
				if (ComGuildItem.PoolItems.Count <= 0)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_store_need_selected_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				EGuildDuty eGuildDuty = DataManager<PlayerBaseData>.GetInstance().eGuildDuty;
				GuildPost serverDuty = (GuildPost)DataManager<GuildDataManager>.GetInstance().GetServerDuty(eGuildDuty);
				if (serverDuty < DataManager<GuildDataManager>.GetInstance().contributePower)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_store_need_power"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int num = ComGuildItem.PoolItems.Count + DataManager<GuildDataManager>.GetInstance().storeDatas.Count;
				int storeageCapacity = DataManager<GuildDataManager>.GetInstance().storeageCapacity;
				if (num > storeageCapacity)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_store_has_no_space"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				List<GuildStorageItemInfo> list = new List<GuildStorageItemInfo>();
				for (int i = 0; i < ComGuildItem.PoolItems.Count; i++)
				{
					if (null != ComGuildItem.PoolItems[i])
					{
						ComGuildItemData value = ComGuildItem.PoolItems[i].Value;
						if (value != null && value.itemData != null && value.iSelectedCount > 0)
						{
							list.Add(new GuildStorageItemInfo
							{
								uid = value.itemData.GUID,
								dataId = (uint)value.itemData.TableID,
								num = (ushort)value.iSelectedCount
							});
						}
					}
				}
				if (list.Count > 0)
				{
					DataManager<GuildDataManager>.GetInstance().SendStoreItems(list.ToArray());
				}
			};
			return guildStoreHouseClearFrameData;
		}

		// Token: 0x0600E122 RID: 57634 RVA: 0x0039A5AE File Offset: 0x003989AE
		public static void CommandOpen(object argv = null)
		{
			if (argv == null)
			{
				argv = GuildStoreHouseClearFrame.ReadyStoreAddData();
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildStoreHouseClearFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreHouseClearFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600E123 RID: 57635 RVA: 0x0039A5DC File Offset: 0x003989DC
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as GuildStoreHouseClearFrameData);
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemAdd, new ClientEventSystem.UIEventHandler(this._OnStorageItemAdd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemRemoved, new ClientEventSystem.UIEventHandler(this._OnStorageRemoved));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemUpdate, new ClientEventSystem.UIEventHandler(this._OnStorageItemUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemStoreRet, new ClientEventSystem.UIEventHandler(this._OnGuildHouseItemStoreRet));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildHouseItemDeleteRet, new ClientEventSystem.UIEventHandler(this._OnGuildHouseItemDeleteRet));
			this.goMask.CustomActive(false);
			this._RefreshStoreHouseClearItems();
			this._UpdateStatus();
		}

		// Token: 0x0600E124 RID: 57636 RVA: 0x0039A70C File Offset: 0x00398B0C
		private void _OnAddNewItem(List<Item> items)
		{
			if (this.data.bClear)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (itemData != null)
				{
					if (!itemData.IsItemInUnUsedEquipPlan)
					{
						if (this.m_akItemDatas.Find((GuildStoreHouseClearItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID) == null)
						{
							this.m_akItemDatas.Create(new object[]
							{
								this.goParent,
								this.goPrefab,
								new GuildStoreHouseClearItemData
								{
									itemData = itemData,
									bClear = this.data.bClear
								},
								false
							});
						}
					}
				}
			}
			this._UpdateStatus();
		}

		// Token: 0x0600E125 RID: 57637 RVA: 0x0039A800 File Offset: 0x00398C00
		private void _OnUpdateItem(List<Item> items)
		{
			if (this.data.bClear)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (itemData != null)
				{
					GuildStoreHouseClearItem guildStoreHouseClearItem = this.m_akItemDatas.Find((GuildStoreHouseClearItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
					if (guildStoreHouseClearItem != null)
					{
						guildStoreHouseClearItem.OnRefresh(new object[]
						{
							new GuildStoreHouseClearItemData
							{
								itemData = itemData,
								bClear = this.data.bClear
							}
						});
					}
				}
			}
			this._UpdateStatus();
		}

		// Token: 0x0600E126 RID: 57638 RVA: 0x0039A8BC File Offset: 0x00398CBC
		private void _OnRemoveItem(ItemData itemData)
		{
			if (this.data.bClear)
			{
				return;
			}
			if (itemData != null)
			{
				this.m_akItemDatas.Recycle((GuildStoreHouseClearItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
			}
			this._UpdateStatus();
		}

		// Token: 0x0600E127 RID: 57639 RVA: 0x0039A910 File Offset: 0x00398D10
		private void _OnStorageItemAdd(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (this.data.bClear && itemData != null)
			{
				if (!itemData.IsItemInUnUsedEquipPlan)
				{
					this.m_akItemDatas.Create(new object[]
					{
						this.goParent,
						this.goPrefab,
						new GuildStoreHouseClearItemData
						{
							itemData = itemData,
							bClear = this.data.bClear
						},
						false
					});
				}
			}
			this._UpdateStatus();
			this._UpdateSpace();
		}

		// Token: 0x0600E128 RID: 57640 RVA: 0x0039A9AC File Offset: 0x00398DAC
		private void _OnStorageRemoved(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (this.data.bClear && itemData != null)
			{
				this.m_akItemDatas.Recycle((GuildStoreHouseClearItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
			}
			this._UpdateStatus();
			this._UpdateSpace();
		}

		// Token: 0x0600E129 RID: 57641 RVA: 0x0039AA10 File Offset: 0x00398E10
		private void _OnStorageItemUpdate(UIEvent uiEvent)
		{
			ItemData itemData = uiEvent.Param1 as ItemData;
			if (this.data.bClear && itemData != null)
			{
				GuildStoreHouseClearItem guildStoreHouseClearItem = this.m_akItemDatas.Find((GuildStoreHouseClearItem x) => x != null && x.Value != null && x.Value.itemData != null && itemData.GUID == x.Value.itemData.GUID);
				if (guildStoreHouseClearItem != null)
				{
					guildStoreHouseClearItem.OnRefresh(new object[]
					{
						new GuildStoreHouseClearItemData
						{
							itemData = itemData,
							bClear = this.data.bClear
						}
					});
				}
			}
			this._UpdateStatus();
			this._UpdateSpace();
		}

		// Token: 0x0600E12A RID: 57642 RVA: 0x0039AAAC File Offset: 0x00398EAC
		private void _OnGuildHouseItemStoreRet(UIEvent uiEvent)
		{
			if (!this.data.bClear)
			{
				ComGuildItem.CancelSelectedItems();
				ComGuildItem.ClearPools();
				this.goMask.CustomActive(false);
			}
		}

		// Token: 0x0600E12B RID: 57643 RVA: 0x0039AAD4 File Offset: 0x00398ED4
		private void _OnGuildHouseItemDeleteRet(UIEvent uiEvent)
		{
			if (this.data.bClear)
			{
				ComGuildItem.CancelSelectedItems();
				ComGuildItem.ClearPools();
				this.goMask.CustomActive(false);
			}
		}

		// Token: 0x0600E12C RID: 57644 RVA: 0x0039AAFC File Offset: 0x00398EFC
		protected override void _OnCloseFrame()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemAdd, new ClientEventSystem.UIEventHandler(this._OnStorageItemAdd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemRemoved, new ClientEventSystem.UIEventHandler(this._OnStorageRemoved));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemUpdate, new ClientEventSystem.UIEventHandler(this._OnStorageItemUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemStoreRet, new ClientEventSystem.UIEventHandler(this._OnGuildHouseItemStoreRet));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildHouseItemDeleteRet, new ClientEventSystem.UIEventHandler(this._OnGuildHouseItemDeleteRet));
			this.data.onCancel = null;
			this.data.onOK = null;
			this.data = null;
			ComGuildItem.ClearPools();
			this.m_akItemDatas.DestroyAllObjects();
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x0600E12D RID: 57645 RVA: 0x0039AC38 File Offset: 0x00399038
		private void _UpdateStatus()
		{
			if (null != this.comState)
			{
				if (this.m_akItemDatas.ActiveObjects.Count > 0)
				{
					this.comState.Key = "normal";
				}
				else if (this.data.bClear)
				{
					this.comState.Key = "no_clear";
				}
				else
				{
					this.comState.Key = "no_items";
				}
			}
		}

		// Token: 0x0600E12E RID: 57646 RVA: 0x0039ACB8 File Offset: 0x003990B8
		private void _RefreshStoreHouseClearItems()
		{
			this.m_akItemDatas.RecycleAllObject();
			if (this.data.bClear)
			{
				List<ItemData> storeDatas = DataManager<GuildDataManager>.GetInstance().storeDatas;
				for (int i = 0; i < storeDatas.Count; i++)
				{
					ItemData itemData = storeDatas[i];
					if (itemData != null)
					{
						if (!itemData.IsItemInUnUsedEquipPlan)
						{
							this.m_akItemDatas.Create(new object[]
							{
								this.goParent,
								this.goPrefab,
								new GuildStoreHouseClearItemData
								{
									itemData = itemData,
									bClear = this.data.bClear
								},
								false
							});
						}
					}
				}
			}
			else
			{
				List<object> list = ListPool<object>.Get();
				foreach (KeyValuePair<ulong, ItemData> keyValuePair in DataManager<ItemDataManager>.GetInstance().GetAllPackageItems())
				{
					ItemData value = keyValuePair.Value;
					if (value != null)
					{
						if (value.EquipType != EEquipType.ET_REDMARK)
						{
							if (value.StrengthenLevel < 11)
							{
								if (value.Quality <= ItemTable.eColor.PURPLE)
								{
									if (value.PackageType == EPackageType.Equip || value.PackageType == EPackageType.Material || value.PackageType == EPackageType.Consumable)
									{
										if (value.Type != ItemTable.eType.EQUIP || !value.BEquipIsInsetBead)
										{
											if (value.Type != ItemTable.eType.EXPENDABLE || value.SubType != 54 || value.Quality < ItemTable.eColor.PURPLE)
											{
												if (value.Type == ItemTable.eType.EQUIP)
												{
													if (value.BindAttr == ItemTable.eOwner.NOTBIND)
													{
														list.Add(value);
													}
													else if (value.Packing)
													{
														list.Add(value);
													}
												}
												else if (value.Type == ItemTable.eType.EXPENDABLE)
												{
													if (value.BindAttr == ItemTable.eOwner.NOTBIND)
													{
														list.Add(value);
													}
													else if (value.Packing)
													{
														list.Add(value);
													}
												}
												else if (value.Type == ItemTable.eType.MATERIAL)
												{
													if (value.BindAttr == ItemTable.eOwner.NOTBIND)
													{
														list.Add(value);
													}
													else if (value.Packing)
													{
														list.Add(value);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					ItemData itemData2 = list[j] as ItemData;
					if (itemData2 != null)
					{
						if (!itemData2.IsItemInUnUsedEquipPlan)
						{
							this.m_akItemDatas.Create(new object[]
							{
								this.goParent,
								this.goPrefab,
								new GuildStoreHouseClearItemData
								{
									itemData = itemData2,
									bClear = this.data.bClear
								},
								false
							});
						}
					}
				}
				ListPool<object>.Release(list);
			}
			if (this.data != null)
			{
				if (this.Name.text != null)
				{
					this.Name.text = this.data.name;
				}
				if (null != this.Hint)
				{
					this.Hint.text = this.data.hint;
				}
				if (null != this.okText)
				{
					this.okText.text = this.data.btnName;
				}
			}
			this._UpdateSpace();
		}

		// Token: 0x0600E12F RID: 57647 RVA: 0x0039B05C File Offset: 0x0039945C
		private void _UpdateSpace()
		{
			if (this.data != null && null != this.Space)
			{
				this.Space.CustomActive(!this.data.bClear);
				int count = DataManager<GuildDataManager>.GetInstance().storeDatas.Count;
				int storeageCapacity = DataManager<GuildDataManager>.GetInstance().storeageCapacity;
				this.Space.text = TR.Value("guild_store_house_space_desc", count, storeageCapacity);
			}
		}

		// Token: 0x0600E130 RID: 57648 RVA: 0x0039B0DC File Offset: 0x003994DC
		[UIEventHandle("middleback/BtnOK")]
		private void _OnClickOK()
		{
			if (this.data != null && this.data.onOK != null)
			{
				InvokeMethod.RemoveInvokeCall(this);
				this.goMask.CustomActive(true);
				this.data.onOK.Invoke();
				InvokeMethod.Invoke(this, 2f, delegate()
				{
					this.goMask.CustomActive(false);
				});
			}
		}

		// Token: 0x040085F1 RID: 34289
		[UIObject("middleback/Goods/ScrollView/Viewport/Content")]
		private GameObject goParent;

		// Token: 0x040085F2 RID: 34290
		[UIObject("middleback/Goods/ScrollView/Viewport/Content/Prefab")]
		private GameObject goPrefab;

		// Token: 0x040085F3 RID: 34291
		[UIControl("Name", typeof(Text), 0)]
		private Text Name;

		// Token: 0x040085F4 RID: 34292
		[UIControl("Hint", typeof(Text), 0)]
		private Text Hint;

		// Token: 0x040085F5 RID: 34293
		[UIControl("Space", typeof(Text), 0)]
		private Text Space;

		// Token: 0x040085F6 RID: 34294
		[UIControl("middleback/BtnOK/Text", typeof(Text), 0)]
		private Text okText;

		// Token: 0x040085F7 RID: 34295
		[UIObject("Mask")]
		private GameObject goMask;

		// Token: 0x040085F8 RID: 34296
		[UIControl("middleback", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x040085F9 RID: 34297
		private CachedObjectListManager<GuildStoreHouseClearItem> m_akItemDatas = new CachedObjectListManager<GuildStoreHouseClearItem>();

		// Token: 0x040085FA RID: 34298
		private GuildStoreHouseClearFrameData data;
	}
}

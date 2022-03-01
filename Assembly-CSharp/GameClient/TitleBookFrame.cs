using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CB6 RID: 7350
	internal class TitleBookFrame : ClientFrame
	{
		// Token: 0x06012066 RID: 73830 RVA: 0x00544D92 File Offset: 0x00543192
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TitleBookFrame/TitleBookFrame";
		}

		// Token: 0x06012067 RID: 73831 RVA: 0x00544D99 File Offset: 0x00543199
		public static void CommandOpen(object argv)
		{
			if (argv == null)
			{
				argv = new TitleBookFrameData();
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleBookFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x06012068 RID: 73832 RVA: 0x00544DBC File Offset: 0x005431BC
		private void _InitTitleBookList()
		{
			if (this.m_bInitialize)
			{
				return;
			}
			this.m_bInitialize = true;
			if (null != this.comUIListScript)
			{
				this.comUIListScript.Initialize();
				this.comUIListScript.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComTitleItem>();
					}
					return null;
				};
				this.comUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (null != item && item.m_index >= 0 && item.m_index < this.mDatas.Count)
					{
						ComTitleItem comTitleItem = item.gameObjectBindScript as ComTitleItem;
						if (null != comTitleItem)
						{
							comTitleItem.OnItemVisible(this.mDatas[item.m_index]);
						}
					}
				};
				this.comUIListScript.onItemChageDisplay = delegate(ComUIListElementScript item, bool bSelected)
				{
					ComTitleItem comTitleItem = item.gameObjectBindScript as ComTitleItem;
					if (null != comTitleItem)
					{
						comTitleItem.OnItemChangeDisplay(bSelected);
					}
				};
				this.comUIListScript.onItemSelected = delegate(ComUIListElementScript item)
				{
					if (null != item && item.m_index >= 0 && item.m_index < this.mDatas.Count)
					{
						this._OnSetTarget(this.mDatas[item.m_index]);
					}
				};
			}
		}

		// Token: 0x06012069 RID: 73833 RVA: 0x00544E78 File Offset: 0x00543278
		private void _OnSetTarget(ComTitleItemData data)
		{
			if (data.itemTable == null)
			{
				this.mDataBinder.goTitles.CustomActive(false);
				this.mDataBinder.goFunction.CustomActive(false);
				this.mDataBinder.goLookUp.CustomActive(false);
				this.mDataBinder.goEquip.CustomActive(false);
				this.mDataBinder.btnTrade.CustomActive(false);
				return;
			}
			this.mDataBinder.goTitles.CustomActive(true);
			this.mDataBinder.goFunction.CustomActive(true);
			this.mDataBinder.goLookUp.CustomActive(data.itemTable != null);
			this.mDataBinder.goEquip.CustomActive(data.itemTable != null && data.itemData != null && (!DataManager<TittleBookManager>.GetInstance().CanTrade(data.itemData) || (DataManager<TittleBookManager>.GetInstance().CanTrade(data.itemData) && !DataManager<TittleBookManager>.GetInstance().HasBindedTitle(data.itemData.TableID))));
			this.mDataBinder.btnTrade.CustomActive(data.itemData != null && DataManager<TittleBookManager>.GetInstance().CanTrade(data.itemData));
			if (data.itemData != null && null != this.mDataBinder.textEquipt)
			{
				this.mDataBinder.textEquipt.text = ((data.itemData.PackageType != EPackageType.WearEquip) ? "穿戴" : "卸下");
			}
			if (null != this.mDataBinder.tittleDesc)
			{
				if (data.itemTable != null)
				{
					this.mDataBinder.tittleDesc.text = data.itemTable.ComeDesc;
				}
				else
				{
					this.mDataBinder.tittleDesc.text = string.Empty;
				}
			}
			ItemData itemData = data.itemData;
			if (itemData == null && data.itemTable != null)
			{
				itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(data.itemTable.ID);
			}
			this._UpdateTitleDesc(itemData);
		}

		// Token: 0x0601206A RID: 73834 RVA: 0x005450B0 File Offset: 0x005434B0
		private void _UpdateTitleDesc(ItemData itemData)
		{
			if (itemData != null)
			{
				if (null != this.mDataBinder.tittleName)
				{
					this.mDataBinder.tittleName.text = itemData.GetColorName(string.Empty, false);
				}
				if (null != this.mDataBinder.goTitleAttrParent)
				{
					for (int i = 0; i < this.mDataBinder.goTitleAttrParent.transform.childCount; i++)
					{
						Transform child = this.mDataBinder.goTitleAttrParent.transform.GetChild(i);
						if (child.gameObject.activeSelf)
						{
							List<GameObject> list = null;
							if (!this.m_akRecycleObject.TryGetValue(child.name, out list))
							{
								list = new List<GameObject>();
								this.m_akRecycleObject.Add(child.name, list);
							}
							list.Add(child.gameObject);
							child.gameObject.CustomActive(false);
						}
					}
				}
				List<Utility.TipContent> titleTipItemList = Utility.GetTitleTipItemList(itemData);
				for (int j = 0; j < titleTipItemList.Count; j++)
				{
					Utility.TipContent tipContent = titleTipItemList[j];
					List<GameObject> list2 = null;
					GameObject gameObject;
					if (this.m_akRecycleObject.TryGetValue(tipContent.Prefabpath, out list2) && list2.Count > 0)
					{
						gameObject = list2[0];
						list2.RemoveAt(0);
						gameObject.CustomActive(true);
					}
					else
					{
						gameObject = (Singleton<AssetLoader>.instance.LoadRes(tipContent.Prefabpath, typeof(GameObject), true, 0U).obj as GameObject);
						gameObject.name = tipContent.Prefabpath;
					}
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.mDataBinder.goTitleAttrParent, false);
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.SetAsLastSibling();
						if (tipContent.ETipContentType == Utility.TipContent.TipContentType.TCT_BLANK_DESC)
						{
							LayoutElement component = gameObject.GetComponent<LayoutElement>();
							component.preferredHeight = (float)tipContent.iParam0;
						}
						else
						{
							SmartTipContent component2 = gameObject.GetComponent<SmartTipContent>();
							if (component2 != null)
							{
								if (tipContent != null && !tipContent.IsNull)
								{
									component2.SetText(tipContent.left, tipContent.right);
								}
								else
								{
									component2.SetText(string.Empty, string.Empty);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0601206B RID: 73835 RVA: 0x00545314 File Offset: 0x00543714
		private void _UpdateTitleBookListData(TittleComeType v)
		{
			this.mDatas.Clear();
			List<ulong> list = null;
			if (DataManager<TittleBookManager>.GetInstance().GetTittle(v, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
					if (item != null)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							this.mDatas.Add(new ComTitleItemData
							{
								itemData = item,
								itemTable = tableItem,
								eType = v
							});
						}
					}
				}
			}
			List<ulong> list2 = null;
			if (DataManager<TittleBookManager>.GetInstance().GetTableTittle(v, out list2))
			{
				for (int j = 0; j < list2.Count; j++)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)list2[j], string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.OldTitle != 1)
					{
						this.mDatas.Add(new ComTitleItemData
						{
							itemTable = tableItem2,
							eType = v
						});
					}
				}
			}
			this.mDatas.Sort(delegate(ComTitleItemData x, ComTitleItemData y)
			{
				if (x.itemTable.IdSequence != y.itemTable.IdSequence)
				{
					return x.itemTable.IdSequence - y.itemTable.IdSequence;
				}
				if (x.itemData != null && y.itemData != null)
				{
					return (x.itemData.GUID >= y.itemData.GUID) ? ((x.itemData.GUID != y.itemData.GUID) ? 1 : 0) : -1;
				}
				return 0;
			});
		}

		// Token: 0x0601206C RID: 73836 RVA: 0x00545470 File Offset: 0x00543870
		private void _UpdateTitleBookList()
		{
			if (this.m_eType != TittleComeType.TCT_MERGE && this.m_bInitialize)
			{
				this._UpdateTitleBookListData(this.m_eType);
				if (null != this.comUIListScript)
				{
					this.comUIListScript.SetElementAmount(this.mDatas.Count);
				}
				if (this.mDatas.Count > 0)
				{
					int num = this.comUIListScript.GetSelectedIndex();
					if (num < 0 || num >= this.mDatas.Count)
					{
						num = 0;
					}
					if (this.m_eLastType != this.m_eType)
					{
						num = 0;
						this.m_eLastType = this.m_eType;
					}
					this.comUIListScript.SelectElement(-1, true);
					if (!this.comUIListScript.IsElementInScrollArea(num))
					{
						this.comUIListScript.EnsureElementVisable(num);
					}
					this.comUIListScript.SelectElement(num, true);
					ComUIListElementScript elemenet = this.comUIListScript.GetElemenet(num);
					if (null == elemenet)
					{
						this._OnSetTarget(this.mDatas[num]);
					}
				}
				else
				{
					this.comUIListScript.SelectElement(-1, true);
					if (this.m_eLastType != this.m_eType)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("title_un_acquired"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						this.m_eLastType = this.m_eType;
					}
					this._OnSetTarget(this.mDefault);
				}
			}
		}

		// Token: 0x0601206D RID: 73837 RVA: 0x005455CC File Offset: 0x005439CC
		private void _UnInitTitleBookList()
		{
			if (this.m_bInitialize)
			{
				if (null != this.comUIListScript)
				{
					this.comUIListScript.onBindItem = null;
					this.comUIListScript.onItemChageDisplay = null;
					this.comUIListScript.onItemVisiable = null;
					this.comUIListScript.onItemSelected = null;
				}
				this.m_bInitialize = false;
			}
			this.comUIListScript = null;
		}

		// Token: 0x0601206E RID: 73838 RVA: 0x00545634 File Offset: 0x00543A34
		private void _InitMergeItems()
		{
			if (null != this.comMergeTitles)
			{
				this.comMergeTitles.Initialize();
				this.comMergeTitles.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComMergeTitle>();
					}
					return null;
				};
				this.comMergeTitles.onItemSelected = delegate(ComUIListElementScript item)
				{
					if (null != item)
					{
						ComMergeTitle comMergeTitle = item.gameObjectBindScript as ComMergeTitle;
						if (null != comMergeTitle)
						{
							ComMergeTitle.Selected = comMergeTitle.Value;
							this._SetMergeTitleData(comMergeTitle.Value);
						}
					}
				};
				this.comMergeTitles.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (null != item && item.m_index >= 0 && item.m_index < DataManager<TittleBookManager>.GetInstance().MergeTitles.Count)
					{
						ComMergeTitle comMergeTitle = item.gameObjectBindScript as ComMergeTitle;
						TitleMergeData titleMergeData = DataManager<TittleBookManager>.GetInstance().MergeTitles[item.m_index];
						if (null != comMergeTitle && titleMergeData != null)
						{
							comMergeTitle.OnItemVisible(titleMergeData);
						}
					}
				};
			}
		}

		// Token: 0x0601206F RID: 73839 RVA: 0x005456C4 File Offset: 0x00543AC4
		private void _InitMergeMaterials()
		{
			if (null != this.comCache)
			{
				this.comCache.onItemCreate = delegate(GameObject go)
				{
					if (null != go)
					{
						ComItemSetting component = go.GetComponent<ComItemSetting>();
						go.CustomActive(true);
						return component;
					}
					return null;
				};
				this.comCache.onItemVisible = delegate(object script, object data)
				{
					if (script != null && data != null)
					{
						ComItemSetting comItemSetting = script as ComItemSetting;
						ComItemSettingData comItemSettingData = data as ComItemSettingData;
						if (null != comItemSetting && comItemSettingData != null)
						{
							comItemSetting.SetValueByTableData(comItemSettingData.iId, comItemSettingData.count, comItemSettingData.cost);
						}
					}
				};
				this.comCache.onItemRecycled = delegate(object script)
				{
					ComItemSetting comItemSetting = script as ComItemSetting;
					if (null != comItemSetting)
					{
						comItemSetting.gameObject.CustomActive(false);
					}
				};
			}
		}

		// Token: 0x06012070 RID: 73840 RVA: 0x0054575C File Offset: 0x00543B5C
		private void _SetMergeTitleData(TitleMergeData data)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(data.item.ID, 100, 0);
			this._UpdateTitleDesc(itemData);
			this._UpdateMergeMoney();
			this._UpdateMergeMaterials();
		}

		// Token: 0x06012071 RID: 73841 RVA: 0x00545790 File Offset: 0x00543B90
		private void _UpdateMergeMoney()
		{
			if (this.m_eType != TittleComeType.TCT_MERGE)
			{
				return;
			}
			if (ComMergeTitle.Selected == null)
			{
				this.moneyIcon.CustomActive(false);
				this.moneyCount.text = "合成";
			}
			else if (ComMergeTitle.Selected.getMoneyCount() <= 0)
			{
				this.moneyIcon.CustomActive(false);
				this.moneyCount.text = "合成";
			}
			else
			{
				this.moneyIcon.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.moneyIcon, ComMergeTitle.Selected.getMoneyIcon(), true);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(ComMergeTitle.Selected.getMoneyId(), true);
				if (ownedItemCount >= ComMergeTitle.Selected.getMoneyCount())
				{
					this.moneyCount.text = string.Format("{0}合成", ComMergeTitle.Selected.getMoneyCount());
				}
				else
				{
					this.moneyCount.text = string.Format("<color=#ff0000>{0}</color>合成", ComMergeTitle.Selected.getMoneyCount());
				}
			}
		}

		// Token: 0x06012072 RID: 73842 RVA: 0x005458A0 File Offset: 0x00543CA0
		private void _UpdateMergeItems()
		{
			if (this.m_eType == TittleComeType.TCT_MERGE)
			{
				if (null != this.comMergeTitles && this.m_bMergeTitlesInit)
				{
					this.comMergeTitles.SetElementAmount(DataManager<TittleBookManager>.GetInstance().MergeTitles.Count);
				}
				this._TrySelectedDefaultMergeItem();
			}
		}

		// Token: 0x06012073 RID: 73843 RVA: 0x005458F8 File Offset: 0x00543CF8
		private void _UpdateMergeMaterials()
		{
			if (this.m_eType == TittleComeType.TCT_MERGE && null != this.comCache)
			{
				if (ComMergeTitle.Selected != null)
				{
					List<TitleMergeMaterialData> materials = ComMergeTitle.Selected.materials;
					List<object> list = new List<object>();
					for (int i = 0; i < materials.Count; i++)
					{
						list.Add(new ComItemSettingData
						{
							iId = materials[i].id,
							count = 1,
							cost = materials[i].count
						});
					}
					this.comCache.SetItems(list);
				}
				else
				{
					this.comCache.SetItems(null);
				}
			}
		}

		// Token: 0x06012074 RID: 73844 RVA: 0x005459AC File Offset: 0x00543DAC
		private void _TrySelectedDefaultMergeItem()
		{
			List<TitleMergeData> mergeTitles = DataManager<TittleBookManager>.GetInstance().MergeTitles;
			if (mergeTitles != null && mergeTitles.Count > 0)
			{
				if (ComMergeTitle.Selected == null)
				{
					ComMergeTitle.Selected = mergeTitles[0];
					this._SetMergeTitleData(ComMergeTitle.Selected);
				}
				else if (null != this.comMergeTitles)
				{
					bool flag = false;
					for (int i = 0; i < mergeTitles.Count; i++)
					{
						if (mergeTitles[i] != null && mergeTitles[i].forgeItem == ComMergeTitle.Selected.forgeItem)
						{
							ComMergeTitle.Selected = mergeTitles[i];
							this._SetMergeTitleData(ComMergeTitle.Selected);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						ComMergeTitle.Selected = mergeTitles[0];
						this._SetMergeTitleData(ComMergeTitle.Selected);
					}
				}
			}
		}

		// Token: 0x06012075 RID: 73845 RVA: 0x00545A88 File Offset: 0x00543E88
		private void _OnClickMerge()
		{
			if (ComMergeTitle.Selected == null)
			{
				Logger.LogErrorFormat("has no selected mergetitle!!", new object[0]);
				return;
			}
			if (!ComMergeTitle.checkMaterialEnough(ComMergeTitle.Selected, true))
			{
				return;
			}
			if (!ComMergeTitle.checkMoneyEnough(ComMergeTitle.Selected))
			{
				ItemComeLink.OnLink(ComMergeTitle.Selected.getMoneyId(), ComMergeTitle.Selected.getMoneyCount() - ComMergeTitle.Selected.getOwnedMoneyCount(), true, null, false, false, false, null, string.Empty);
				return;
			}
			this._OnConfirmToMerge();
		}

		// Token: 0x06012076 RID: 73846 RVA: 0x00545B08 File Offset: 0x00543F08
		private void _OnConfirmToMerge()
		{
			if (ComMergeTitle.Selected != null)
			{
				List<CostItemManager.CostInfo> list = new List<CostItemManager.CostInfo>();
				for (int i = 0; i < ComMergeTitle.Selected.materials.Count; i++)
				{
					list.Add(new CostItemManager.CostInfo
					{
						nMoneyID = ComMergeTitle.Selected.materials[i].id,
						nCount = ComMergeTitle.Selected.materials[i].count
					});
				}
				for (int j = 0; j < ComMergeTitle.Selected.moneys.Count; j++)
				{
					list.Add(new CostItemManager.CostInfo
					{
						nMoneyID = ComMergeTitle.Selected.moneys[j].id,
						nCount = ComMergeTitle.Selected.moneys[j].count
					});
				}
				TitleMergeMaterialNeedType titleMergeMaterialNeedType = this.CheckOwnerMaterialItem(list);
				if (titleMergeMaterialNeedType == TitleMergeMaterialNeedType.BeEquip)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("title_merge_failed_for_equipted"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (titleMergeMaterialNeedType == TitleMergeMaterialNeedType.BeInUnSelectedEquipPlan)
				{
					string msgContent = TR.Value("Equip_Plan_Item_CanNot_Merge_Format", DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanId);
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(list, delegate
				{
					this.frameMgr.OpenFrame<EquipForgeResultFrame>(FrameLayer.Middle, ComMergeTitle.Selected.item.ID, string.Empty);
				}, null, "common_money_cost");
			}
		}

		// Token: 0x06012077 RID: 73847 RVA: 0x00545C5C File Offset: 0x0054405C
		private TitleMergeMaterialNeedType CheckOwnerMaterialItem(List<CostItemManager.CostInfo> infos)
		{
			if (infos == null || infos.Count <= 0)
			{
				return TitleMergeMaterialNeedType.Enough;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			List<int> list = new List<int>();
			if (itemsByPackageType != null && itemsByPackageType.Count > 0)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ulong num = itemsByPackageType[i];
					if (num > 0UL)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
						if (item != null && item.TableID > 0)
						{
							list.Add(item.TableID);
						}
					}
				}
			}
			List<ulong> unSelectedEquipPlanItemGuidList = EquipPlanUtility.GetUnSelectedEquipPlanItemGuidList();
			List<int> list2 = new List<int>();
			if (unSelectedEquipPlanItemGuidList != null && unSelectedEquipPlanItemGuidList.Count > 0)
			{
				for (int j = 0; j < unSelectedEquipPlanItemGuidList.Count; j++)
				{
					ulong num2 = unSelectedEquipPlanItemGuidList[j];
					if (num2 > 0UL)
					{
						if (itemsByPackageType == null || itemsByPackageType.Count <= 0 || !itemsByPackageType.Contains(num2))
						{
							ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(num2);
							if (item2 != null)
							{
								list2.Add(item2.TableID);
							}
						}
					}
				}
			}
			for (int k = 0; k < infos.Count; k++)
			{
				CostItemManager.CostInfo costInfo = infos[k];
				if (costInfo != null)
				{
					if (costInfo.nCount > 0)
					{
						int nMoneyID = costInfo.nMoneyID;
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(nMoneyID, true);
						if (ownedItemCount == costInfo.nCount)
						{
							if (list.Contains(nMoneyID))
							{
								return TitleMergeMaterialNeedType.BeEquip;
							}
							if (list2.Contains(nMoneyID))
							{
								return TitleMergeMaterialNeedType.BeInUnSelectedEquipPlan;
							}
						}
						else if (ownedItemCount == costInfo.nCount + 1 && list.Contains(nMoneyID) && list2.Contains(nMoneyID))
						{
							return TitleMergeMaterialNeedType.BeEquip;
						}
					}
				}
			}
			return TitleMergeMaterialNeedType.Enough;
		}

		// Token: 0x06012078 RID: 73848 RVA: 0x00545E54 File Offset: 0x00544254
		private void _InitTabs()
		{
			if (null != this.mDataBinder)
			{
				for (int i = 0; i < 6; i++)
				{
					if (null != this.mDataBinder.goTabPrefab)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.mDataBinder.goTabPrefab);
						if (!(null == gameObject))
						{
							Utility.AttachTo(gameObject, this.mDataBinder.goTabPrefab.transform.parent.gameObject, false);
							Object @object = gameObject;
							TittleComeType tittleComeType = (TittleComeType)i;
							@object.name = tittleComeType.ToString();
							Text text = Utility.FindComponent<Text>(gameObject, "Label", true);
							if (null != text)
							{
								text.text = this.mTabNames[i];
							}
							text = Utility.FindComponent<Text>(gameObject, "Checkmark/Label", true);
							if (null != text)
							{
								text.text = this.mTabNames[i];
							}
							if (this.mTabs[i] == null)
							{
								this.mTabs[i] = new TitleBookFrame.TabItem();
							}
							this.mTabs[i].toggle = gameObject.GetComponent<Toggle>();
							this.mTabs[i].goCheckMark = Utility.FindChild(gameObject, "Checkmark");
							this.mTabs[i].goRedPoint = Utility.FindChild(gameObject, "tabMark");
							this.mTabs[i].goRedPoint.CustomActive(false);
							TittleComeType v = (TittleComeType)i;
							this.mTabs[i].toggle.onValueChanged.AddListener(delegate(bool bValue)
							{
								this._OnTabChanged(v, bValue);
							});
						}
					}
				}
				this.mDataBinder.goTabPrefab.CustomActive(false);
			}
		}

		// Token: 0x06012079 RID: 73849 RVA: 0x00546000 File Offset: 0x00544400
		private void _UnInitTabs()
		{
			for (int i = 0; i < this.mTabs.Length; i++)
			{
				if (this.mTabs[i] != null)
				{
					this.mTabs[i].Clear();
				}
			}
		}

		// Token: 0x0601207A RID: 73850 RVA: 0x00546040 File Offset: 0x00544440
		private void _SetTab(TittleComeType e)
		{
			if (e >= TittleComeType.TCT_SHOP && e < (TittleComeType)this.mTabs.Length)
			{
				TitleBookFrame.TabItem tabItem = this.mTabs[(int)e];
				if (tabItem != null)
				{
					for (int i = 0; i < this.mTabs.Length; i++)
					{
						if (this.mTabs[i] != null && null != this.mTabs[i].toggle)
						{
							this.mTabs[i].toggle.onValueChanged.RemoveAllListeners();
						}
					}
					tabItem.toggle.isOn = true;
					for (int j = 0; j < this.mTabs.Length; j++)
					{
						this._OnTabChanged((TittleComeType)j, e == (TittleComeType)j);
					}
					for (int k = 0; k < this.mTabs.Length; k++)
					{
						if (this.mTabs[k] != null && null != this.mTabs[k].toggle)
						{
							TittleComeType v = (TittleComeType)k;
							this.mTabs[k].toggle.onValueChanged.AddListener(delegate(bool bValue)
							{
								this._OnTabChanged(v, bValue);
							});
						}
					}
				}
			}
		}

		// Token: 0x0601207B RID: 73851 RVA: 0x00546170 File Offset: 0x00544570
		private void _OnTabChanged(TittleComeType v, bool bValue)
		{
			if (v < TittleComeType.TCT_SHOP || v >= (TittleComeType)this.mTabs.Length)
			{
				return;
			}
			TitleBookFrame.TabItem tabItem = this.mTabs[(int)v];
			if (tabItem != null)
			{
				tabItem.goCheckMark.CustomActive(bValue);
			}
			if (bValue)
			{
				this.m_eLastType = this.m_eType;
				this.m_eType = v;
				switch (v)
				{
				case TittleComeType.TCT_SHOP:
				case TittleComeType.TCT_MISSION:
				case TittleComeType.TCT_ACTIVE:
				case TittleComeType.TCT_TIMELIMITED:
				case TittleComeType.TCT_TRADE:
					if (null != this.comState)
					{
						this.comState.Key = this.mStatusNormal;
					}
					this._InitTitleBookList();
					this._UpdateTitleBookList();
					break;
				case TittleComeType.TCT_MERGE:
					if (null != this.comState)
					{
						this.comState.Key = this.mStatusMerge;
					}
					this.mDataBinder.goTitles.CustomActive(true);
					if (!this.m_bMergeTitlesInit)
					{
						this._InitMergeItems();
						this._InitMergeMaterials();
						this.m_bMergeTitlesInit = true;
					}
					this._UpdateMergeMoney();
					this._UpdateMergeItems();
					this._UpdateMergeMaterials();
					break;
				}
			}
		}

		// Token: 0x0601207C RID: 73852 RVA: 0x00546288 File Offset: 0x00544688
		protected override void _OnOpenFrame()
		{
			this.mData = (this.userData as TitleBookFrameData);
			if (this.mData == null)
			{
				this.mData = new TitleBookFrameData();
			}
			base._AddButton("tittle/close", delegate
			{
				this.frameMgr.CloseFrame<TitleBookFrame>(this, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TitleBookCloseFrame, null, null, null, null);
			});
			base._AddButton("merge/btnMerge", new UnityAction(this._OnClickMerge));
			this._InitTabs();
			this._UpdateTabRedPoint();
			this._SetTab(this.mData.eTittleComeType);
			this._RegisterEvent();
		}

		// Token: 0x0601207D RID: 73853 RVA: 0x00546310 File Offset: 0x00544710
		[UIEventHandle("FuncControls/Equipt")]
		private void OnClickEquip()
		{
			ItemData selectedItem = this._GetSelectedItemData(true);
			if (selectedItem != null)
			{
				if (selectedItem.PackageType == EPackageType.Storage || selectedItem.PackageType == EPackageType.RoleStorage)
				{
					SystemNotifyManager.SystemNotify(10002, string.Empty);
					return;
				}
				if (selectedItem.Packing)
				{
					SystemNotifyManager.SystemNotify(2006, delegate()
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(selectedItem, false, 0, 0);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}, null, new object[]
					{
						selectedItem.GetColorName(string.Empty, false)
					});
				}
				else
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(selectedItem, false, 0, 0);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}
			}
		}

		// Token: 0x0601207E RID: 73854 RVA: 0x005463D4 File Offset: 0x005447D4
		[UIEventHandle("FuncControls/Trade")]
		private void OnClickTrade()
		{
			ItemData itemData = this._GetSelectedItemData(true);
			if (itemData != null)
			{
				if (itemData.PackageType == EPackageType.Storage || itemData.PackageType == EPackageType.RoleStorage)
				{
					SystemNotifyManager.SystemNotify(10002, string.Empty);
					return;
				}
				this._OnAuction(itemData, null);
			}
		}

		// Token: 0x0601207F RID: 73855 RVA: 0x00546420 File Offset: 0x00544820
		private ItemData _GetSelectedItemData(bool bReal)
		{
			if (null != this.comUIListScript && this.m_bInitialize)
			{
				int selectedIndex = this.comUIListScript.GetSelectedIndex();
				if (selectedIndex >= 0 && selectedIndex < this.mDatas.Count)
				{
					if (this.mDatas[selectedIndex].itemData != null)
					{
						return this.mDatas[selectedIndex].itemData;
					}
					if (this.mDatas[selectedIndex].itemTable != null && !bReal)
					{
						return DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mDatas[selectedIndex].itemTable.ID);
					}
				}
			}
			return null;
		}

		// Token: 0x06012080 RID: 73856 RVA: 0x005464E0 File Offset: 0x005448E0
		[UIEventHandle("FuncControls/LookUp")]
		private void OnClickLookUp()
		{
			ItemData itemData = this._GetSelectedItemData(false);
			if (itemData != null)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemData.GUID);
				List<TipFuncButon> list = new List<TipFuncButon>();
				if (item != null)
				{
					if (item.PackageType == EPackageType.Title)
					{
						list.Add(new TipFuncButon
						{
							text = TR.Value("tip_wear"),
							callback = new OnTipFuncClicked(this._OnUnWear)
						});
					}
					if (item.PackageType == EPackageType.WearEquip)
					{
						list.Add(new TipFuncButon
						{
							text = TR.Value("tip_takeoff"),
							callback = new OnTipFuncClicked(this._OnUnWear)
						});
					}
					if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Forge) && !item.isInSidePack && !item.bLocked && !item.IsLease && item.Type == ItemTable.eType.FUCKTITTLE && item.SubType == 10 && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Bead) && item.DeadTimestamp == 0)
					{
						TipFuncButon item2 = new TipFuncButon
						{
							text = TR.Value("tip_BeadMosaic"),
							name = "BeadMosaic",
							callback = new OnTipFuncClicked(this._OnForgeItem)
						};
						list.Add(item2);
					}
					list.Add(new TipFuncButon
					{
						text = TR.Value("tip_share"),
						callback = new OnTipFuncClicked(this._OnShareClicked)
					});
					if (DataManager<TittleBookManager>.GetInstance().CanTrade(item))
					{
						list.Add(new TipFuncButon
						{
							text = TR.Value("tip_auction"),
							callback = new OnTipFuncClicked(this._OnAuction)
						});
					}
				}
				ItemData itemData2 = this._GetCompareItem(itemData);
				if (itemData2 != null)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTipWithCompareItem(itemData, itemData2, list, true);
				}
				else
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, list, 4, true, false, true);
				}
			}
		}

		// Token: 0x06012081 RID: 73857 RVA: 0x005466DC File Offset: 0x00544ADC
		private ItemData _GetCompareItem(ItemData item)
		{
			ItemData result = null;
			if (item != null && item.WillCanEquip())
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
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

		// Token: 0x06012082 RID: 73858 RVA: 0x00546762 File Offset: 0x00544B62
		protected void _OnUnWear(ItemData item, object data)
		{
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
			}
		}

		// Token: 0x06012083 RID: 73859 RVA: 0x00546778 File Offset: 0x00544B78
		private void _OnForgeItem(ItemData a_item, object a_data)
		{
			if (a_item != null)
			{
				SmithShopNewLinkData userData = new SmithShopNewLinkData
				{
					itemData = a_item,
					iDefaultFirstTabId = 3
				};
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, userData, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x06012084 RID: 73860 RVA: 0x005467C9 File Offset: 0x00544BC9
		private void _OnShareClicked(ItemData item, object data)
		{
			DataManager<ChatManager>.GetInstance().ShareEquipment(item, ChatType.CT_WORLD);
		}

		// Token: 0x06012085 RID: 73861 RVA: 0x005467D7 File Offset: 0x00544BD7
		private void _OnAuction(ItemData item, object data)
		{
			AuctionNewUtility.OpenAuctionNewFrame(item);
		}

		// Token: 0x06012086 RID: 73862 RVA: 0x005467DF File Offset: 0x00544BDF
		private void _OnAddTittle(ulong uid)
		{
			this._UpdateTitleBookList();
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x06012087 RID: 73863 RVA: 0x005467F3 File Offset: 0x00544BF3
		private void _OnUpdateTittle(ulong uid)
		{
			this._UpdateTitleBookList();
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x06012088 RID: 73864 RVA: 0x00546807 File Offset: 0x00544C07
		private void _OnRemoveTittle(ulong uid)
		{
			this._UpdateTitleBookList();
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x06012089 RID: 73865 RVA: 0x0054681B File Offset: 0x00544C1B
		private void _OnRemoveTableTittle(ulong uid)
		{
			this._UpdateTitleBookList();
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x0601208A RID: 73866 RVA: 0x0054682F File Offset: 0x00544C2F
		private void _OnAddTableTittle(ulong uid)
		{
			this._UpdateTitleBookList();
		}

		// Token: 0x0601208B RID: 73867 RVA: 0x00546837 File Offset: 0x00544C37
		private void _OnAddNewItem(List<Item> items)
		{
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x0601208C RID: 73868 RVA: 0x00546845 File Offset: 0x00544C45
		private void _OnRemoveItem(ItemData data)
		{
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x0601208D RID: 73869 RVA: 0x00546853 File Offset: 0x00544C53
		private void _OnUpdateItem(List<Item> items)
		{
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
		}

		// Token: 0x0601208E RID: 73870 RVA: 0x00546861 File Offset: 0x00544C61
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._UpdateMergeItems();
			this._UpdateMergeMaterials();
			this._UpdateMergeMoney();
		}

		// Token: 0x0601208F RID: 73871 RVA: 0x00546875 File Offset: 0x00544C75
		private void OnRedPointChanged(UIEvent uiEvent)
		{
			this._UpdateTabRedPoint();
		}

		// Token: 0x06012090 RID: 73872 RVA: 0x00546880 File Offset: 0x00544C80
		private void _UpdateTabRedPoint()
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.mTabs[i] != null)
				{
					bool bActive = DataManager<TittleBookManager>.GetInstance().IsTittleTabMark((TittleComeType)i);
					this.mTabs[i].goRedPoint.CustomActive(bActive);
				}
			}
		}

		// Token: 0x06012091 RID: 73873 RVA: 0x005468CC File Offset: 0x00544CCC
		private void _RegisterEvent()
		{
			TittleBookManager instance = DataManager<TittleBookManager>.GetInstance();
			instance.onAddTittle = (TittleBookManager.OnAddTittle)Delegate.Combine(instance.onAddTittle, new TittleBookManager.OnAddTittle(this._OnAddTittle));
			TittleBookManager instance2 = DataManager<TittleBookManager>.GetInstance();
			instance2.onUpdateTittle = (TittleBookManager.OnUpdateTittle)Delegate.Combine(instance2.onUpdateTittle, new TittleBookManager.OnUpdateTittle(this._OnUpdateTittle));
			TittleBookManager instance3 = DataManager<TittleBookManager>.GetInstance();
			instance3.onRemoveTittle = (TittleBookManager.OnRemoveTittle)Delegate.Combine(instance3.onRemoveTittle, new TittleBookManager.OnRemoveTittle(this._OnRemoveTittle));
			TittleBookManager instance4 = DataManager<TittleBookManager>.GetInstance();
			instance4.onRemoveTableTittle = (TittleBookManager.OnRemoveTableTittle)Delegate.Combine(instance4.onRemoveTableTittle, new TittleBookManager.OnRemoveTableTittle(this._OnRemoveTableTittle));
			TittleBookManager instance5 = DataManager<TittleBookManager>.GetInstance();
			instance5.onAddTableTittle = (TittleBookManager.OnAddTableTittle)Delegate.Combine(instance5.onAddTableTittle, new TittleBookManager.OnAddTableTittle(this._OnAddTableTittle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			ItemDataManager instance6 = DataManager<ItemDataManager>.GetInstance();
			instance6.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance6.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance7 = DataManager<ItemDataManager>.GetInstance();
			instance7.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance7.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance8 = DataManager<ItemDataManager>.GetInstance();
			instance8.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance8.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance9 = DataManager<PlayerBaseData>.GetInstance();
			instance9.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance9.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
		}

		// Token: 0x06012092 RID: 73874 RVA: 0x00546A48 File Offset: 0x00544E48
		private void _UnRegisterEvent()
		{
			TittleBookManager instance = DataManager<TittleBookManager>.GetInstance();
			instance.onAddTittle = (TittleBookManager.OnAddTittle)Delegate.Remove(instance.onAddTittle, new TittleBookManager.OnAddTittle(this._OnAddTittle));
			TittleBookManager instance2 = DataManager<TittleBookManager>.GetInstance();
			instance2.onUpdateTittle = (TittleBookManager.OnUpdateTittle)Delegate.Remove(instance2.onUpdateTittle, new TittleBookManager.OnUpdateTittle(this._OnUpdateTittle));
			TittleBookManager instance3 = DataManager<TittleBookManager>.GetInstance();
			instance3.onRemoveTittle = (TittleBookManager.OnRemoveTittle)Delegate.Remove(instance3.onRemoveTittle, new TittleBookManager.OnRemoveTittle(this._OnRemoveTittle));
			TittleBookManager instance4 = DataManager<TittleBookManager>.GetInstance();
			instance4.onRemoveTableTittle = (TittleBookManager.OnRemoveTableTittle)Delegate.Remove(instance4.onRemoveTableTittle, new TittleBookManager.OnRemoveTableTittle(this._OnRemoveTableTittle));
			TittleBookManager instance5 = DataManager<TittleBookManager>.GetInstance();
			instance5.onAddTableTittle = (TittleBookManager.OnAddTableTittle)Delegate.Remove(instance5.onAddTableTittle, new TittleBookManager.OnAddTableTittle(this._OnAddTableTittle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			ItemDataManager instance6 = DataManager<ItemDataManager>.GetInstance();
			instance6.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance6.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance7 = DataManager<ItemDataManager>.GetInstance();
			instance7.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance7.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance8 = DataManager<ItemDataManager>.GetInstance();
			instance8.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance8.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance9 = DataManager<PlayerBaseData>.GetInstance();
			instance9.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance9.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
		}

		// Token: 0x06012093 RID: 73875 RVA: 0x00546BC4 File Offset: 0x00544FC4
		protected override void _OnCloseFrame()
		{
			this._UnRegisterEvent();
			this._UnInitTitleBookList();
			this._UnInitTabs();
			this.mData = null;
			this.m_akRecycleObject.Clear();
			if (this.m_bMergeTitlesInit)
			{
				if (null != this.comMergeTitles)
				{
					this.comMergeTitles.onBindItem = null;
					this.comMergeTitles.onItemSelected = null;
					this.comMergeTitles.onItemVisiable = null;
					this.comMergeTitles = null;
				}
				if (null != this.comCache)
				{
					this.comCache.onItemVisible = null;
					this.comCache.onItemCreate = null;
					this.comCache.onItemRecycled = null;
					this.comCache = null;
				}
				this.m_bMergeTitlesInit = false;
			}
			this.m_eType = TittleComeType.TCT_COUNT;
			this.m_eLastType = TittleComeType.TCT_COUNT;
		}

		// Token: 0x0400BBFC RID: 48124
		[UIControl("tittles", typeof(ComUIListScript), 0)]
		private ComUIListScript comUIListScript;

		// Token: 0x0400BBFD RID: 48125
		private bool m_bInitialize;

		// Token: 0x0400BBFE RID: 48126
		private ComTitleItemData mDefault = new ComTitleItemData
		{
			itemTable = null,
			itemData = null
		};

		// Token: 0x0400BBFF RID: 48127
		private Dictionary<string, List<GameObject>> m_akRecycleObject = new Dictionary<string, List<GameObject>>();

		// Token: 0x0400BC00 RID: 48128
		[UIControl("merge", typeof(ComUIListScript), 0)]
		private ComUIListScript comMergeTitles;

		// Token: 0x0400BC01 RID: 48129
		[UIControl("merge/Horizen", typeof(ComCache), 0)]
		private ComCache comCache;

		// Token: 0x0400BC02 RID: 48130
		private bool m_bMergeTitlesInit;

		// Token: 0x0400BC03 RID: 48131
		[UIControl("merge/btnMerge/horizen/Icon", typeof(Image), 0)]
		private Image moneyIcon;

		// Token: 0x0400BC04 RID: 48132
		[UIControl("merge/btnMerge/horizen/Text", typeof(Text), 0)]
		private Text moneyCount;

		// Token: 0x0400BC05 RID: 48133
		[UIControl("", typeof(ComTitleBookDataBinder), 0)]
		private ComTitleBookDataBinder mDataBinder;

		// Token: 0x0400BC06 RID: 48134
		private TitleBookFrame.TabItem[] mTabs = new TitleBookFrame.TabItem[6];

		// Token: 0x0400BC07 RID: 48135
		private string[] mTabNames = new string[]
		{
			"商城",
			"任务",
			"活动",
			"时限",
			"可交易",
			"称号合成"
		};

		// Token: 0x0400BC08 RID: 48136
		private TittleComeType m_eType = TittleComeType.TCT_COUNT;

		// Token: 0x0400BC09 RID: 48137
		private TittleComeType m_eLastType = TittleComeType.TCT_COUNT;

		// Token: 0x0400BC0A RID: 48138
		private List<ComTitleItemData> mDatas = new List<ComTitleItemData>(32);

		// Token: 0x0400BC0B RID: 48139
		private TitleBookFrameData mData;

		// Token: 0x0400BC0C RID: 48140
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x0400BC0D RID: 48141
		private string mStatusNormal = "normal";

		// Token: 0x0400BC0E RID: 48142
		private string mStatusMerge = "merge";

		// Token: 0x02001CB7 RID: 7351
		private class TabItem
		{
			// Token: 0x060120A2 RID: 73890 RVA: 0x0054700E File Offset: 0x0054540E
			public void Clear()
			{
				if (null != this.toggle)
				{
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle = null;
				}
				this.goCheckMark = null;
				this.goRedPoint = null;
			}

			// Token: 0x0400BC17 RID: 48151
			public Toggle toggle;

			// Token: 0x0400BC18 RID: 48152
			public GameObject goCheckMark;

			// Token: 0x0400BC19 RID: 48153
			public GameObject goRedPoint;
		}
	}
}

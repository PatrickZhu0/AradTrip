using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015BB RID: 5563
	internal class EquipForgeFrame : ClientFrame
	{
		// Token: 0x0600D964 RID: 55652 RVA: 0x00367978 File Offset: 0x00365D78
		public static void CommandOpen(object argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipForgeFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600D965 RID: 55653 RVA: 0x0036798C File Offset: 0x00365D8C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipForge/EquipForge";
		}

		// Token: 0x0600D966 RID: 55654 RVA: 0x00367993 File Offset: 0x00365D93
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600D967 RID: 55655 RVA: 0x003679A1 File Offset: 0x00365DA1
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600D968 RID: 55656 RVA: 0x003679AF File Offset: 0x00365DAF
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._OnItemCountChanged));
		}

		// Token: 0x0600D969 RID: 55657 RVA: 0x003679CC File Offset: 0x00365DCC
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._OnItemCountChanged));
		}

		// Token: 0x0600D96A RID: 55658 RVA: 0x003679EC File Offset: 0x00365DEC
		private void _InitUI()
		{
			DataManager<EquipForgeDataManager>.GetInstance().UpdateSuitable();
			DataManager<EquipForgeDataManager>.GetInstance().UpdateCanForge();
			this.m_objMainTypeTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objMainTypeTemplate.SetActive(false);
			this.m_objSubTypeTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objSubTypeTemplate.SetActive(false);
			this.m_objForgeTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objForgeTemplate.SetActive(false);
			this.m_groupPrefab.transform.SetParent(this.frame.transform, false);
			this.m_groupPrefab.SetActive(false);
			this.m_hTwoLabelsPrefab.transform.SetParent(this.frame.transform, false);
			this.m_hTwoLabelsPrefab.SetActive(false);
			this.m_leftLabelPrefab.transform.SetParent(this.frame.transform, false);
			this.m_leftLabelPrefab.SetActive(false);
			this.m_rightLabelPrefab.transform.SetParent(this.frame.transform, false);
			this.m_rightLabelPrefab.SetActive(false);
			this.m_imagePrefab.transform.SetParent(this.frame.transform, false);
			this.m_imagePrefab.SetActive(false);
			this.m_toggleOnlySuitable.onValueChanged.RemoveAllListeners();
			this.m_toggleOnlySuitable.onValueChanged.AddListener(delegate(bool var)
			{
				this.m_bResetSelectIdx = true;
				this._InitJobSelect();
			});
			this.m_toggleOnlySuitable.onValueChanged.Invoke(true);
		}

		// Token: 0x0600D96B RID: 55659 RVA: 0x00367B8A File Offset: 0x00365F8A
		private void _ClearUI()
		{
			this.m_currForgeInfo = null;
			this.m_nSelectJobIdx = 0;
			this.m_nSelectMainTypeIdx = 0;
			this.m_nSelectSubTypeIdx = 0;
			this.m_nSelectForgeIdx = 0;
		}

		// Token: 0x0600D96C RID: 55660 RVA: 0x00367BB0 File Offset: 0x00365FB0
		private void _InitJobSelect()
		{
			if (this.m_bResetSelectIdx)
			{
				this.m_nSelectJobIdx = this._GetBestMatchedJobForgeInfo();
			}
			this._ClearJobSelect();
			this.m_dropJobSelect.onValueChanged.RemoveAllListeners();
			this.m_dropJobSelect.ClearOptions();
			List<string> list = new List<string>();
			List<EquipForgeDataManager.TreeForgeInfo> infos = this._GetJobMatchedForgeInfos();
			for (int i = 0; i < infos.Count; i++)
			{
				list.Add(infos[i].strKey);
			}
			this.m_dropJobSelect.AddOptions(list);
			this.m_dropJobSelect.value = this.m_nSelectJobIdx;
			this.m_dropJobSelect.onValueChanged.AddListener(delegate(int var)
			{
				if (var >= 0 && var < infos.Count)
				{
					this.m_nSelectJobIdx = var;
					this._InitMainTypeList(infos[var]);
				}
			});
			this.m_dropJobSelect.onValueChanged.Invoke(this.m_nSelectJobIdx);
		}

		// Token: 0x0600D96D RID: 55661 RVA: 0x00367C96 File Offset: 0x00366096
		private void _ClearJobSelect()
		{
			this._ClearMainTypeList();
			this._ClearSubTypeList();
			this._ClearForge();
			this.m_currForgeInfo = null;
		}

		// Token: 0x0600D96E RID: 55662 RVA: 0x00367CB4 File Offset: 0x003660B4
		private int _GetBestMatchedJobForgeInfo()
		{
			List<int> list = new List<int>();
			list.Add(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			list.AddRange(DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs);
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(list[0], string.Empty, string.Empty);
			list.AddRange(tableItem.ToJob);
			List<EquipForgeDataManager.TreeForgeInfo> list2 = this._GetJobMatchedForgeInfos();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != 0)
				{
					for (int j = 0; j < list2.Count; j++)
					{
						if ((int)list2[j].param == list[i])
						{
							return j;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600D96F RID: 55663 RVA: 0x00367D7C File Offset: 0x0036617C
		private List<EquipForgeDataManager.TreeForgeInfo> _GetJobMatchedForgeInfos()
		{
			List<EquipForgeDataManager.TreeForgeInfo> list = new List<EquipForgeDataManager.TreeForgeInfo>();
			int jobType = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty).JobType;
			List<EquipForgeDataManager.TreeForgeInfo> arrInfos = DataManager<EquipForgeDataManager>.GetInstance().GetTreeForgeInfo().arrInfos;
			for (int i = 0; i < arrInfos.Count; i++)
			{
				int jobType2 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)arrInfos[i].param, string.Empty, string.Empty).JobType;
				if (jobType2 == jobType)
				{
					list.Add(arrInfos[i]);
				}
			}
			return list;
		}

		// Token: 0x0600D970 RID: 55664 RVA: 0x00367E1C File Offset: 0x0036621C
		private void _InitMainTypeList(EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			this._ClearMainTypeList();
			List<Toggle> list = new List<Toggle>();
			bool isToggleInited = false;
			int num = 0;
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgetInfo = a_treeForgeInfo.arrInfos[i];
				if (!this.m_toggleOnlySuitable.isOn || treeForgetInfo.bSuitable)
				{
					GameObject gameObject;
					if (num < this.m_objMainTypeRoot.transform.childCount)
					{
						gameObject = this.m_objMainTypeRoot.transform.GetChild(num).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objMainTypeTemplate);
						gameObject.transform.SetParent(this.m_objMainTypeRoot.transform, false);
					}
					int nToggleIdx = num;
					num++;
					gameObject.SetActive(true);
					Toggle component = gameObject.GetComponent<Toggle>();
					component.onValueChanged.RemoveAllListeners();
					component.onValueChanged.AddListener(delegate(bool var)
					{
						if (isToggleInited && var)
						{
							this.m_nSelectMainTypeIdx = nToggleIdx;
							this._InitSubTypeList(treeForgetInfo);
						}
					});
					list.Add(component);
					Utility.GetComponetInChild<Text>(gameObject, "Label").text = treeForgetInfo.strKey;
					Utility.FindGameObject(gameObject, "RedPoint", true).SetActive(treeForgetInfo.bCanForge);
					gameObject.name = i.ToString();
				}
			}
			this._InitToggleSelect(list, this.m_nSelectMainTypeIdx, ref isToggleInited);
		}

		// Token: 0x0600D971 RID: 55665 RVA: 0x00367FB4 File Offset: 0x003663B4
		private void _ClearMainTypeList()
		{
			for (int i = 0; i < this.m_objMainTypeRoot.transform.childCount; i++)
			{
				this.m_objMainTypeRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
		}

		// Token: 0x0600D972 RID: 55666 RVA: 0x00368000 File Offset: 0x00366400
		private void _InitSubTypeList(EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			this._ClearSubTypeList();
			List<Toggle> list = new List<Toggle>();
			bool isToggleInited = false;
			int num = 0;
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgetInfo = a_treeForgeInfo.arrInfos[i];
				if (!this.m_toggleOnlySuitable.isOn || treeForgetInfo.bSuitable)
				{
					GameObject obj;
					if (num < this.m_objSubTypeRoot.transform.childCount)
					{
						obj = this.m_objSubTypeRoot.transform.GetChild(num).gameObject;
					}
					else
					{
						obj = Object.Instantiate<GameObject>(this.m_objSubTypeTemplate);
						obj.transform.SetParent(this.m_objSubTypeRoot.transform, false);
					}
					int nToggleIndex = num;
					num++;
					obj.SetActive(true);
					Toggle component = obj.GetComponent<Toggle>();
					component.onValueChanged.RemoveAllListeners();
					component.onValueChanged.AddListener(delegate(bool var)
					{
						if (isToggleInited)
						{
							if (var)
							{
								this.m_nSelectSubTypeIdx = nToggleIndex;
								this._InitForgeList(Utility.FindGameObject(obj, "SubTypes", true), treeForgetInfo);
							}
							else
							{
								this._ClearForgeList(Utility.FindGameObject(obj, "SubTypes", true));
							}
						}
					});
					list.Add(component);
					Utility.GetComponetInChild<Text>(obj, "MainType/Label").text = treeForgetInfo.strKey;
					Utility.FindGameObject(obj, "MainType/RedPoint", true).SetActive(treeForgetInfo.bCanForge);
				}
			}
			if (this.m_bResetSelectIdx)
			{
				this.m_nSelectSubTypeIdx = 0;
			}
			this._InitToggleSelect(list, this.m_nSelectSubTypeIdx, ref isToggleInited);
		}

		// Token: 0x0600D973 RID: 55667 RVA: 0x003681B8 File Offset: 0x003665B8
		private void _ClearSubTypeList()
		{
			for (int i = 0; i < this.m_objSubTypeRoot.transform.childCount; i++)
			{
				this.m_objSubTypeRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
		}

		// Token: 0x0600D974 RID: 55668 RVA: 0x00368204 File Offset: 0x00366604
		private void _InitForgeList(GameObject a_objRoot, EquipForgeDataManager.TreeForgeInfo a_treeForgeInfo)
		{
			this._ClearForgeList(a_objRoot);
			List<Toggle> list = new List<Toggle>();
			bool isToggleInited = false;
			int num = 0;
			for (int i = 0; i < a_treeForgeInfo.arrInfos.Count; i++)
			{
				EquipForgeDataManager.TreeForgeInfo treeForgeInfo = a_treeForgeInfo.arrInfos[i];
				if (!this.m_toggleOnlySuitable.isOn || treeForgeInfo.bSuitable)
				{
					EquipForgeDataManager.ForgeInfo forgeInfo = treeForgeInfo.param as EquipForgeDataManager.ForgeInfo;
					GameObject gameObject;
					if (num < a_objRoot.transform.childCount)
					{
						gameObject = a_objRoot.transform.GetChild(num).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objForgeTemplate);
						gameObject.transform.SetParent(a_objRoot.transform, false);
					}
					int nToggleIndex = num;
					num++;
					gameObject.SetActive(true);
					Toggle component = gameObject.GetComponent<Toggle>();
					component.onValueChanged.RemoveAllListeners();
					component.onValueChanged.AddListener(delegate(bool var)
					{
						if (isToggleInited && var)
						{
							this.m_nSelectForgeIdx = nToggleIndex;
							this._InitForge(forgeInfo);
						}
					});
					list.Add(component);
					Image componetInChild = Utility.GetComponetInChild<Image>(gameObject, "Background");
					ETCImageLoader.LoadSprite(ref componetInChild, forgeInfo.itemData.GetQualityInfo().TitleBG2, true);
					Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Icon");
					ETCImageLoader.LoadSprite(ref componetInChild2, forgeInfo.itemData.Icon, true);
					Utility.GetComponetInChild<Text>(gameObject, "Name").text = forgeInfo.itemData.Name;
					Utility.FindGameObject(gameObject, "Owned", true).SetActive(DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(forgeInfo.itemData.TableID, true) > 0);
					if (forgeInfo.itemData.LevelLimit > 0)
					{
						Utility.GetComponetInChild<Text>(gameObject, "Level/Text").text = string.Format("Lv.{0}", forgeInfo.itemData.LevelLimit);
					}
					else
					{
						Utility.GetComponetInChild<Text>(gameObject, "Level/Text").text = string.Empty;
					}
					Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "State");
					EquipForgeDataManager.CheckForgeResult checkForgeResult = DataManager<EquipForgeDataManager>.GetInstance().CheckEquipCanForge(forgeInfo);
					if (checkForgeResult.eType == EquipForgeDataManager.CheckForgeResult.EType.CanForge)
					{
						componetInChild3.text = TR.Value("color_green", TR.Value("equipforge_can_forge"));
					}
					else if (checkForgeResult.eType == EquipForgeDataManager.CheckForgeResult.EType.LessMaterial)
					{
						componetInChild3.text = TR.Value("equipforge_less_material");
					}
					else if (checkForgeResult.eType == EquipForgeDataManager.CheckForgeResult.EType.LessPrice)
					{
						ItemData itemData = checkForgeResult.userData as ItemData;
						componetInChild3.text = TR.Value("equipforge_less_price", itemData.Name);
					}
					Utility.FindGameObject(gameObject, "RedPoint", true).SetActive(false);
					gameObject.name = i.ToString();
				}
			}
			if (this.m_bResetSelectIdx)
			{
				this.m_nSelectForgeIdx = 0;
			}
			this._InitToggleSelect(list, this.m_nSelectForgeIdx, ref isToggleInited);
		}

		// Token: 0x0600D975 RID: 55669 RVA: 0x00368530 File Offset: 0x00366930
		private void _ClearForgeList(GameObject a_objRoot)
		{
			for (int i = 0; i < a_objRoot.transform.childCount; i++)
			{
				a_objRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
		}

		// Token: 0x0600D976 RID: 55670 RVA: 0x00368570 File Offset: 0x00366970
		private void _InitForge(EquipForgeDataManager.ForgeInfo a_forgeInfo)
		{
			this._ClearForge();
			this.m_currForgeInfo = a_forgeInfo;
			ComItem comItem = this.m_objEquipRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.m_objEquipRoot);
			}
			comItem.Setup(a_forgeInfo.itemData, delegate(GameObject var1, ItemData var2)
			{
				ItemData itemData2 = this._GetCompareEquip(var2);
				if (itemData2 != null)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTipWithCompareItem(var2, itemData2, null, true);
				}
				else
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				}
			});
			for (int i = 0; i < a_forgeInfo.arrMaterials.Count; i++)
			{
				ItemData itemData = a_forgeInfo.arrMaterials[i];
				GameObject gameObject;
				if (i < this.m_objMaterialRoot.transform.childCount)
				{
					gameObject = this.m_objMaterialRoot.transform.GetChild(i).gameObject;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objMaterialTemplate);
					gameObject.transform.SetParent(this.m_objMaterialRoot.transform, false);
				}
				gameObject.SetActive(true);
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "Item", true);
				ComItem comItem2 = gameObject2.GetComponentInChildren<ComItem>();
				if (comItem2 == null)
				{
					comItem2 = base.CreateComItem(gameObject2);
				}
				comItem2.Setup(itemData, delegate(GameObject var1, ItemData var2)
				{
					if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(var2.TableID, true) >= var2.Count)
					{
						ItemComeLink.OnLink(var2.TableID, 0, false, null, false, false, false, null, string.Empty);
					}
					else
					{
						ItemComeLink.OnLink(var2.TableID, var2.Count, true, null, false, false, false, null, string.Empty);
					}
				});
				comItem2.SetCountFormatter((ComItem var) => string.Empty);
				Utility.GetComponetInChild<Text>(gameObject, "Name").text = itemData.GetColorName(string.Empty, false);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemData.TableID, true);
				int count = itemData.Count;
				if (ownedItemCount >= count)
				{
					Utility.GetComponetInChild<Text>(gameObject, "Count").text = string.Format("{0}/{1}", TR.Value("color_green", ownedItemCount), count);
				}
				else
				{
					Utility.GetComponetInChild<Text>(gameObject, "Count").text = string.Format("{0}/{1}", TR.Value("color_red", ownedItemCount), count);
				}
			}
			if (a_forgeInfo.arrPrices.Count > 0)
			{
				this.m_imgPriceIcon.gameObject.SetActive(true);
				this.m_labPriceCount.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref this.m_imgPriceIcon, a_forgeInfo.arrPrices[0].Icon, true);
				int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(a_forgeInfo.arrPrices[0].TableID, true);
				int count2 = a_forgeInfo.arrPrices[0].Count;
				if (ownedItemCount2 >= count2)
				{
					this.m_labPriceCount.text = TR.Value("color_green", count2);
				}
				else
				{
					this.m_labPriceCount.text = TR.Value("color_red", count2);
				}
			}
			this.m_objEquipDetail.SetActive(true);
			this._SetupTipContent(this._GetEquipTipItemList(a_forgeInfo), this.m_objTipRoot);
			this.m_labOwnedCount.text = TR.Value("equipforge_equip_owned_count", DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(a_forgeInfo.itemData.TableID, true));
		}

		// Token: 0x0600D977 RID: 55671 RVA: 0x00368888 File Offset: 0x00366C88
		private void _ClearForge()
		{
			ComItem comItem = this.m_objEquipRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.m_objEquipRoot);
			}
			comItem.Setup(null, null);
			for (int i = 0; i < 3; i++)
			{
				GameObject gameObject;
				if (i < this.m_objMaterialRoot.transform.childCount)
				{
					gameObject = this.m_objMaterialRoot.transform.GetChild(i).gameObject;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objMaterialTemplate);
					gameObject.transform.SetParent(this.m_objMaterialRoot.transform, false);
				}
				gameObject.SetActive(true);
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "Item", true);
				ComItem comItem2 = gameObject2.GetComponentInChildren<ComItem>();
				if (comItem2 == null)
				{
					comItem2 = base.CreateComItem(gameObject2);
				}
				comItem2.Setup(null, null);
				Utility.GetComponetInChild<Text>(gameObject, "Name").text = string.Empty;
				Utility.GetComponetInChild<Text>(gameObject, "Count").text = string.Empty;
			}
			this.m_imgPriceIcon.gameObject.SetActive(false);
			this.m_labPriceCount.gameObject.SetActive(false);
			this.m_objEquipDetail.SetActive(false);
		}

		// Token: 0x0600D978 RID: 55672 RVA: 0x003689C0 File Offset: 0x00366DC0
		private ItemData _GetCompareEquip(ItemData item)
		{
			ItemData result = null;
			if (item != null && item.IsOccupationFit())
			{
				List<ulong> list = null;
				if (item.Type == ItemTable.eType.EQUIP || item.Type == ItemTable.eType.FUCKTITTLE)
				{
					list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				}
				else if (item.Type == ItemTable.eType.FASHION)
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

		// Token: 0x0600D979 RID: 55673 RVA: 0x00368A80 File Offset: 0x00366E80
		private void _SetupTipContent(List<TipItem> tipItems, GameObject parentObj)
		{
			if (parentObj == null || tipItems == null || tipItems.Count <= 0)
			{
				return;
			}
			this._ClearTipContent(parentObj);
			int i = 0;
			while (i < tipItems.Count)
			{
				TipItem tipItem = tipItems[i];
				switch (tipItem.Type)
				{
				case ETipItemType.ItemTitle:
				{
					TipItemItemTitle tipItemItemTitle = tipItem as TipItemItemTitle;
					this.m_labTipTitleName.text = tipItemItemTitle.itemData.Name;
					ETCImageLoader.LoadSprite(ref this.m_imgTipTitleBG, tipItemItemTitle.itemData.GetQualityInfo().TitleBG, true);
					break;
				}
				case ETipItemType.HTwoLabels:
				{
					TipItemTwoLabels tipItemTwoLabels = tipItem as TipItemTwoLabels;
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_hTwoLabelsPrefab);
					Text component = Utility.FindGameObject(gameObject, "LeftLabel", true).GetComponent<Text>();
					component.text = tipItemTwoLabels.LeftContent;
					Text component2 = Utility.FindGameObject(gameObject, "RightLabel", true).GetComponent<Text>();
					component2.text = tipItemTwoLabels.RightContent;
					gameObject.transform.SetParent(parentObj.transform, false);
					gameObject.SetActive(true);
					break;
				}
				case ETipItemType.LeftLabel:
				{
					TipItemLeftLabel tipItemLeftLabel = tipItem as TipItemLeftLabel;
					GameObject gameObject2 = Object.Instantiate<GameObject>(this.m_leftLabelPrefab);
					Text component3 = gameObject2.GetComponent<Text>();
					component3.text = tipItemLeftLabel.Content;
					gameObject2.transform.SetParent(parentObj.transform, false);
					gameObject2.SetActive(true);
					break;
				}
				case ETipItemType.RightLabel:
				{
					TipItemRightLabel tipItemRightLabel = tipItem as TipItemRightLabel;
					GameObject gameObject3 = Object.Instantiate<GameObject>(this.m_rightLabelPrefab);
					Text component4 = gameObject3.GetComponent<Text>();
					component4.text = tipItemRightLabel.Content;
					gameObject3.transform.SetParent(parentObj.transform, false);
					gameObject3.SetActive(true);
					break;
				}
				case ETipItemType.Image:
				{
					GameObject gameObject4 = Object.Instantiate<GameObject>(this.m_imagePrefab);
					gameObject4.transform.SetParent(parentObj.transform, false);
					gameObject4.SetActive(true);
					break;
				}
				case ETipItemType.Group:
				{
					TipItemGroup tipItemGroup = tipItem as TipItemGroup;
					GameObject gameObject5 = Object.Instantiate<GameObject>(this.m_groupPrefab);
					gameObject5.transform.SetParent(parentObj.transform, false);
					gameObject5.SetActive(true);
					this._SetupTipContent(tipItemGroup.itemList, gameObject5);
					break;
				}
				}
				IL_22D:
				i++;
				continue;
				goto IL_22D;
			}
		}

		// Token: 0x0600D97A RID: 55674 RVA: 0x00368CCC File Offset: 0x003670CC
		private void _ClearTipContent(GameObject parentObj)
		{
			if (parentObj == null)
			{
				return;
			}
			for (int i = 0; i < parentObj.transform.childCount; i++)
			{
				GameObject gameObject = parentObj.transform.GetChild(i).gameObject;
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600D97B RID: 55675 RVA: 0x00368D1C File Offset: 0x0036711C
		private List<TipItem> _GetEquipTipItemList(EquipForgeDataManager.ForgeInfo a_forgeInfo)
		{
			List<TipItem> list = new List<TipItem>();
			list.Add(new TipItemItemTitle(a_forgeInfo.itemData, string.Empty));
			List<string> a_descs = new List<string>();
			this._TryAddDesc(a_descs, this._GetLevelLimitDesc(a_forgeInfo.itemData));
			this._TryAddDesc(a_descs, TR.Value("equipforge_tip_equip_type", a_forgeInfo.itemData.GetSubTypeDesc()));
			if (a_forgeInfo.itemData.SubType == 1)
			{
				this._TryAddDesc(a_descs, TR.Value("equipforge_tip_weapon_type", a_forgeInfo.itemData.GetThirdTypeDesc()));
			}
			else
			{
				this._TryAddDesc(a_descs, TR.Value("equipforge_tip_armor_type", a_forgeInfo.itemData.GetThirdTypeDesc()));
			}
			this._TryAddDesc(a_descs, this._GetOccupationLimitDesc(a_forgeInfo));
			this._TryShowDescsOnLeftSide(list, a_descs);
			List<string> a_descs2 = new List<string>();
			if (a_forgeInfo.itemData.SubType == 1)
			{
				this._TryAddDesc(a_descs2, a_forgeInfo.itemData.BaseProp.GetPropFormatStr(EEquipProp.PhysicsAttack, -1));
				this._TryAddDesc(a_descs2, a_forgeInfo.itemData.BaseProp.GetPropFormatStr(EEquipProp.MagicAttack, -1));
			}
			else if (a_forgeInfo.itemData.SubType == 2 || a_forgeInfo.itemData.SubType == 3 || a_forgeInfo.itemData.SubType == 4 || a_forgeInfo.itemData.SubType == 5 || a_forgeInfo.itemData.SubType == 6)
			{
				this._TryAddDesc(a_descs2, a_forgeInfo.itemData.BaseProp.GetPropFormatStr(EEquipProp.PhysicsDefense, -1));
			}
			else if (a_forgeInfo.itemData.SubType == 7 || a_forgeInfo.itemData.SubType == 8 || a_forgeInfo.itemData.SubType == 9)
			{
				this._TryAddDesc(a_descs2, a_forgeInfo.itemData.BaseProp.GetPropFormatStr(EEquipProp.MagicDefense, -1));
			}
			this._TryShowDescsOnLeftSide(list, a_descs2);
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetStrengthenDescs());
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetFourAttrDescs());
			List<string> list2 = new List<string>();
			this._TryAddDesc(list2, a_forgeInfo.itemData.GetWeaponAttackSpeedDesc());
			this._TryAddDescs(list2, a_forgeInfo.itemData.GetSkillMPAndCDDescs());
			this._TryShowDescsOnLeftSide(list, list2);
			this._TryShowDescOnLeftSide(list, a_forgeInfo.itemData.GetMagicDescs(), true);
			this._TryShowDescOnLeftSide(list, a_forgeInfo.itemData.GetBeadDescs(), true);
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetRandomAttrDescs());
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetAttachAttrDescs());
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetComplexAttrDescs());
			this._TryShowDescsOnLeftSide(list, a_forgeInfo.itemData.GetMasterAttrDescs(true));
			List<TipItem> list3 = this._GetTipSuitItemList(a_forgeInfo.itemData, DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(a_forgeInfo.itemData.SuitID));
			if (list3 != null)
			{
				list.AddRange(list3);
			}
			this._TryShowDescOnLeftSide(list, a_forgeInfo.itemData.GetDeadTimestampDesc(), true);
			this._TryShowDescOnLeftSide(list, a_forgeInfo.itemData.GetDescription(), true);
			this._TryShowDescOnLeftSide(list, a_forgeInfo.itemData.GetSourceDescription(), true);
			return list;
		}

		// Token: 0x0600D97C RID: 55676 RVA: 0x00369028 File Offset: 0x00367428
		private string _GetLevelLimitDesc(ItemData a_itemData)
		{
			if (a_itemData.LevelLimit > 0)
			{
				string key = (a_itemData.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level) ? "tip_color_bad" : "tip_color_good";
				return TR.Value("equipforge_tip_level_limit", TR.Value(key, a_itemData.LevelLimit));
			}
			return TR.Value("equipforge_tip_level_limit", 0);
		}

		// Token: 0x0600D97D RID: 55677 RVA: 0x00369094 File Offset: 0x00367494
		private string _GetOccupationLimitDesc(EquipForgeDataManager.ForgeInfo a_info)
		{
			string text = string.Empty;
			if (a_info.arrRecommendJobs.Count > 0)
			{
				bool flag = false;
				for (int i = 0; i < a_info.arrRecommendJobs.Count; i++)
				{
					int num = a_info.arrRecommendJobs[i];
					if (DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(num))
					{
						flag = true;
					}
					JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(num, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += "、";
						}
						text += tableItem.Name;
					}
				}
				string key = (!flag) ? "tip_color_bad" : "tip_color_good";
				text = TR.Value("equipforge_tip_job_limit", TR.Value(key, text));
			}
			else
			{
				text = TR.Value("equipforge_tip_job_limit", TR.Value("tip_color_good", TR.Value("equipforge_tip_all_job")));
			}
			return text;
		}

		// Token: 0x0600D97E RID: 55678 RVA: 0x0036918C File Offset: 0x0036758C
		private void _TryAddDesc(List<string> a_descs, string a_desc)
		{
			if (!string.IsNullOrEmpty(a_desc))
			{
				a_descs.Add(a_desc);
			}
		}

		// Token: 0x0600D97F RID: 55679 RVA: 0x003691A0 File Offset: 0x003675A0
		private void _TryAddDescs(List<string> a_targetDescs, List<string> a_sourceDescs)
		{
			if (a_sourceDescs != null && a_sourceDescs.Count > 0)
			{
				a_targetDescs.AddRange(a_sourceDescs);
			}
		}

		// Token: 0x0600D980 RID: 55680 RVA: 0x003691BC File Offset: 0x003675BC
		private void _TryShowDescOnLeftSide(List<TipItem> a_tipItems, string a_desc, bool a_bNeedLine = true)
		{
			if (a_tipItems != null && !string.IsNullOrEmpty(a_desc))
			{
				if (a_tipItems.Count > 0 && a_bNeedLine)
				{
					a_tipItems.Add(new TipItemImage());
				}
				a_tipItems.Add(new TipItemGroup
				{
					itemList = 
					{
						new TipItemLeftLabel(a_desc)
					}
				});
			}
		}

		// Token: 0x0600D981 RID: 55681 RVA: 0x00369218 File Offset: 0x00367618
		private void _TryShowDescsOnLeftSide(List<TipItem> a_tipItems, List<string> a_descs)
		{
			if (a_tipItems != null && a_descs != null && a_descs.Count > 0)
			{
				if (a_tipItems.Count > 0)
				{
					a_tipItems.Add(new TipItemImage());
				}
				TipItemGroup tipItemGroup = new TipItemGroup();
				for (int i = 0; i < a_descs.Count; i++)
				{
					tipItemGroup.itemList.Add(new TipItemLeftLabel(a_descs[i]));
				}
				a_tipItems.Add(tipItemGroup);
			}
		}

		// Token: 0x0600D982 RID: 55682 RVA: 0x00369290 File Offset: 0x00367690
		private List<TipItem> _GetTipSuitItemList(ItemData item, EquipSuitObj suitObj)
		{
			if (item == null)
			{
				return null;
			}
			if (suitObj == null)
			{
				return null;
			}
			List<TipItem> list = new List<TipItem>();
			list.Add(new TipItemImage());
			TipItemGroup tipItemGroup = new TipItemGroup();
			string text = TR.Value("color_green", string.Format("[{0}]", suitObj.equipSuitRes.name));
			if (!string.IsNullOrEmpty(text))
			{
				tipItemGroup.itemList.Add(new TipItemLeftLabel(text));
			}
			list.Add(tipItemGroup);
			TipItemGroup tipItemGroup2 = new TipItemGroup();
			string content = string.Empty;
			for (int i = 0; i < suitObj.equipSuitRes.equips.Count; i++)
			{
				int a_nTableID = suitObj.equipSuitRes.equips[i];
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nTableID);
				if (suitObj.IsEquipActive(commonItemTableDataByID))
				{
					content = TR.Value("color_green", commonItemTableDataByID.Name);
				}
				else
				{
					content = TR.Value("color_grey", commonItemTableDataByID.Name);
				}
				tipItemGroup2.itemList.Add(new TipItemLeftLabel(content));
			}
			list.Add(tipItemGroup2);
			TipItemGroup tipItemGroup3 = new TipItemGroup();
			string empty = string.Empty;
			Dictionary<int, EquipProp>.Enumerator enumerator = suitObj.equipSuitRes.props.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = string.Empty;
				int count = suitObj.wearedEquipIDs.Count;
				KeyValuePair<int, EquipProp> keyValuePair = enumerator.Current;
				bool flag = count >= keyValuePair.Key;
				string text3 = (!flag) ? "color_half_grey" : "color_green";
				string key = text3;
				string key2 = "tip_suit_effect";
				KeyValuePair<int, EquipProp> keyValuePair2 = enumerator.Current;
				text2 = TR.Value(key, TR.Value(key2, keyValuePair2.Key));
				KeyValuePair<int, EquipProp> keyValuePair3 = enumerator.Current;
				List<string> propsFormatStr = keyValuePair3.Value.GetPropsFormatStr();
				if (propsFormatStr != null)
				{
					string key3 = (!flag) ? "color_half_grey" : "color_blue";
					for (int j = 0; j < propsFormatStr.Count; j++)
					{
						text2 += "\n";
						text2 += TR.Value(key3, propsFormatStr[j]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair4 = enumerator.Current;
				List<EquipProp.BuffSkillInfo> buffSkillInfos = keyValuePair4.Value.GetBuffSkillInfos();
				if (buffSkillInfos != null)
				{
					for (int k = 0; k < buffSkillInfos.Count; k++)
					{
						EquipProp.BuffSkillInfo buffSkillInfo = buffSkillInfos[k];
						string key4;
						if (this._IsJobMatch(buffSkillInfo.jobID))
						{
							if (flag)
							{
								key4 = "color_orange";
							}
							else
							{
								key4 = "color_half_grey";
							}
						}
						else
						{
							key4 = "color_grey";
						}
						text2 += "\n";
						text2 += TR.Value(key4, string.Format("[{0}]", buffSkillInfo.jobName));
						string key5;
						if (this._IsJobMatch(buffSkillInfo.jobID))
						{
							if (flag)
							{
								key5 = "color_blue";
							}
							else
							{
								key5 = "color_half_grey";
							}
						}
						else
						{
							key5 = "color_grey";
						}
						for (int l = 0; l < buffSkillInfo.skillDescs.Count; l++)
						{
							text2 += "\n";
							text2 += TR.Value(key5, buffSkillInfo.skillDescs[l]);
						}
					}
				}
				string text4 = (!flag) ? "color_half_grey" : "color_blue";
				KeyValuePair<int, EquipProp> keyValuePair5 = enumerator.Current;
				List<string> buffCommonDescs = keyValuePair5.Value.GetBuffCommonDescs();
				if (buffCommonDescs != null)
				{
					for (int m = 0; m < buffCommonDescs.Count; m++)
					{
						text2 += "\n";
						text2 += TR.Value(text4, buffCommonDescs[m]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair6 = enumerator.Current;
				if (!string.IsNullOrEmpty(keyValuePair6.Value.attachBuffDesc))
				{
					text2 += "\n";
					string str = text2;
					string key6 = text4;
					KeyValuePair<int, EquipProp> keyValuePair7 = enumerator.Current;
					text2 = str + TR.Value(key6, keyValuePair7.Value.attachBuffDesc);
				}
				string text5 = (!flag) ? "color_half_grey" : "color_blue";
				KeyValuePair<int, EquipProp> keyValuePair8 = enumerator.Current;
				List<string> mechanismDescs = keyValuePair8.Value.GetMechanismDescs();
				if (mechanismDescs != null)
				{
					for (int n = 0; n < mechanismDescs.Count; n++)
					{
						text2 += "\n";
						text2 += TR.Value(text5, mechanismDescs[n]);
					}
				}
				KeyValuePair<int, EquipProp> keyValuePair9 = enumerator.Current;
				if (!string.IsNullOrEmpty(keyValuePair9.Value.attachMechanismDesc))
				{
					text2 += "\n";
					string str2 = text2;
					string key7 = text5;
					KeyValuePair<int, EquipProp> keyValuePair10 = enumerator.Current;
					text2 = str2 + TR.Value(key7, keyValuePair10.Value.attachMechanismDesc);
				}
				tipItemGroup3.itemList.Add(new TipItemLeftLabel(text2));
			}
			list.Add(tipItemGroup3);
			return list;
		}

		// Token: 0x0600D983 RID: 55683 RVA: 0x003697A2 File Offset: 0x00367BA2
		private bool _IsJobMatch(int jobID)
		{
			return DataManager<PlayerBaseData>.GetInstance().ActiveJobTableIDs.Contains(jobID);
		}

		// Token: 0x0600D984 RID: 55684 RVA: 0x003697B4 File Offset: 0x00367BB4
		private void _InitToggleSelect(List<Toggle> a_arrToggles, int a_nSelectToggleIdx, ref bool a_bBlockSignal)
		{
			if (a_arrToggles == null)
			{
				return;
			}
			if (a_nSelectToggleIdx < 0 || a_nSelectToggleIdx >= a_arrToggles.Count)
			{
				a_nSelectToggleIdx = 0;
			}
			for (int i = 0; i < a_arrToggles.Count; i++)
			{
				if (i == a_nSelectToggleIdx)
				{
					a_arrToggles[i].isOn = true;
				}
				else
				{
					a_arrToggles[i].isOn = false;
				}
			}
			a_bBlockSignal = true;
			for (int j = 0; j < a_arrToggles.Count; j++)
			{
				if (j == a_nSelectToggleIdx)
				{
					a_arrToggles[j].onValueChanged.Invoke(true);
				}
				else
				{
					a_arrToggles[j].onValueChanged.Invoke(false);
				}
			}
		}

		// Token: 0x0600D985 RID: 55685 RVA: 0x00369865 File Offset: 0x00367C65
		private void _OnItemCountChanged(UIEvent a_event)
		{
			DataManager<EquipForgeDataManager>.GetInstance().UpdateCanForge();
			this.m_bResetSelectIdx = false;
			this._InitJobSelect();
			this.m_bResetSelectIdx = true;
		}

		// Token: 0x0600D986 RID: 55686 RVA: 0x00369888 File Offset: 0x00367C88
		[UIEventHandle("TabGroup/Page/ForgeGroup/Forge")]
		private void _OnForgeClicked()
		{
			if (this.m_currForgeInfo != null)
			{
				List<CostItemManager.CostInfo> list = new List<CostItemManager.CostInfo>();
				for (int i = 0; i < this.m_currForgeInfo.arrMaterials.Count; i++)
				{
					list.Add(new CostItemManager.CostInfo
					{
						nMoneyID = this.m_currForgeInfo.arrMaterials[i].TableID,
						nCount = this.m_currForgeInfo.arrMaterials[i].Count
					});
				}
				for (int j = 0; j < this.m_currForgeInfo.arrPrices.Count; j++)
				{
					list.Add(new CostItemManager.CostInfo
					{
						nMoneyID = this.m_currForgeInfo.arrPrices[j].TableID,
						nCount = this.m_currForgeInfo.arrPrices[j].Count
					});
				}
				DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(list, delegate
				{
					this.frameMgr.OpenFrame<EquipForgeResultFrame>(FrameLayer.Middle, this.m_currForgeInfo.itemData.TableID, string.Empty);
				}, null, "common_money_cost");
			}
		}

		// Token: 0x0600D987 RID: 55687 RVA: 0x00369993 File Offset: 0x00367D93
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseCliecked()
		{
			this.frameMgr.CloseFrame<EquipForgeFrame>(this, false);
		}

		// Token: 0x04007FDE RID: 32734
		[UIControl("Dropdown", null, 0)]
		private Dropdown m_dropJobSelect;

		// Token: 0x04007FDF RID: 32735
		[UIObject("TabGroup/Tabs")]
		private GameObject m_objMainTypeRoot;

		// Token: 0x04007FE0 RID: 32736
		[UIObject("TabGroup/Tabs/Tab")]
		private GameObject m_objMainTypeTemplate;

		// Token: 0x04007FE1 RID: 32737
		[UIObject("TabGroup/Page/TreeList/Viewport/Content")]
		private GameObject m_objSubTypeRoot;

		// Token: 0x04007FE2 RID: 32738
		[UIObject("TabGroup/Page/TreeList/Viewport/Content/Group")]
		private GameObject m_objSubTypeTemplate;

		// Token: 0x04007FE3 RID: 32739
		[UIObject("TabGroup/Page/TreeList/Viewport/Content/Group/SubTypes/SubType")]
		private GameObject m_objForgeTemplate;

		// Token: 0x04007FE4 RID: 32740
		[UIObject("TabGroup/Page/ForgeGroup/Materials/EquipRoot")]
		private GameObject m_objEquipRoot;

		// Token: 0x04007FE5 RID: 32741
		[UIObject("TabGroup/Page/ForgeGroup/Materials/RequireGroup")]
		private GameObject m_objMaterialRoot;

		// Token: 0x04007FE6 RID: 32742
		[UIObject("TabGroup/Page/ForgeGroup/Materials/RequireGroup/Template")]
		private GameObject m_objMaterialTemplate;

		// Token: 0x04007FE7 RID: 32743
		[UIControl("TabGroup/Page/ForgeGroup/Forge/Price/Icon", null, 0)]
		private Image m_imgPriceIcon;

		// Token: 0x04007FE8 RID: 32744
		[UIControl("TabGroup/Page/ForgeGroup/Forge/Price/Count", null, 0)]
		private Text m_labPriceCount;

		// Token: 0x04007FE9 RID: 32745
		[UIControl("OnlySuitable", null, 0)]
		private Toggle m_toggleOnlySuitable;

		// Token: 0x04007FEA RID: 32746
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content")]
		private GameObject m_objTipRoot;

		// Token: 0x04007FEB RID: 32747
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content/Group")]
		private GameObject m_groupPrefab;

		// Token: 0x04007FEC RID: 32748
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content/Group/HTwoLabels")]
		private GameObject m_hTwoLabelsPrefab;

		// Token: 0x04007FED RID: 32749
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content/Group/LeftLabel")]
		private GameObject m_leftLabelPrefab;

		// Token: 0x04007FEE RID: 32750
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content/Group/RightLabel")]
		private GameObject m_rightLabelPrefab;

		// Token: 0x04007FEF RID: 32751
		[UIObject("TabGroup/Page/ForgeGroup/Detail/InfoView/Viewport/Content/Line")]
		private GameObject m_imagePrefab;

		// Token: 0x04007FF0 RID: 32752
		[UIControl("TabGroup/Page/ForgeGroup/Detail/Title", null, 0)]
		private Image m_imgTipTitleBG;

		// Token: 0x04007FF1 RID: 32753
		[UIControl("TabGroup/Page/ForgeGroup/Detail/Title/Text", null, 0)]
		private Text m_labTipTitleName;

		// Token: 0x04007FF2 RID: 32754
		[UIControl("TabGroup/Page/ForgeGroup/Detail/OwnedCount", null, 0)]
		private Text m_labOwnedCount;

		// Token: 0x04007FF3 RID: 32755
		[UIObject("TabGroup/Page/ForgeGroup/Detail")]
		private GameObject m_objEquipDetail;

		// Token: 0x04007FF4 RID: 32756
		private int m_nSelectJobIdx;

		// Token: 0x04007FF5 RID: 32757
		private int m_nSelectMainTypeIdx;

		// Token: 0x04007FF6 RID: 32758
		private int m_nSelectSubTypeIdx;

		// Token: 0x04007FF7 RID: 32759
		private int m_nSelectForgeIdx;

		// Token: 0x04007FF8 RID: 32760
		private bool m_bResetSelectIdx = true;

		// Token: 0x04007FF9 RID: 32761
		private EquipForgeDataManager.ForgeInfo m_currForgeInfo;
	}
}

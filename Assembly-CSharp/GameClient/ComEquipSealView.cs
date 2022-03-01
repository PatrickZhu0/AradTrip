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
	// Token: 0x02001ADA RID: 6874
	internal class ComEquipSealView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010DE9 RID: 69097 RVA: 0x004D05A4 File Offset: 0x004CE9A4
		private void Awake()
		{
			this.RegisterEventHander();
			this.InitEquipmentUIList();
			if (this.mBtnItemComLink != null)
			{
				this.mBtnItemComLink.onClick.RemoveAllListeners();
				this.mBtnItemComLink.onClick.AddListener(new UnityAction(this.OnSealItemComeLink));
			}
			if (this.mBtnSeal != null)
			{
				this.mBtnSeal.onClick.RemoveAllListeners();
				this.mBtnSeal.onClick.AddListener(new UnityAction(this.OnSealClicked));
			}
		}

		// Token: 0x06010DEA RID: 69098 RVA: 0x004D0638 File Offset: 0x004CEA38
		private void OnDestroy()
		{
			this.UnRegisterEventHander();
			this.UnInitEquipmentUIList();
			this.equipments.Clear();
			this.linkData = null;
			this.m_kComSeal = null;
			this.costSealItem = null;
			this.m_uiLastSelectedId = 0UL;
			this.m_keep_item = null;
			this.m_kEquipSealData = null;
		}

		// Token: 0x06010DEB RID: 69099 RVA: 0x004D0687 File Offset: 0x004CEA87
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.linkData = linkData;
			this.InitInterface();
			this.OnAdjustSealChanged(null);
			this._LoadAllEquipments();
			this._BindLinkData();
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010DEC RID: 69100 RVA: 0x004D06AF File Offset: 0x004CEAAF
		public void OnEnableView()
		{
			this.RegisterEventHander();
			this.RefreshAllEquipments();
		}

		// Token: 0x06010DED RID: 69101 RVA: 0x004D06BD File Offset: 0x004CEABD
		public void OnDisableView()
		{
			this.UnRegisterEventHander();
		}

		// Token: 0x06010DEE RID: 69102 RVA: 0x004D06C8 File Offset: 0x004CEAC8
		private void RegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010DEF RID: 69103 RVA: 0x004D0748 File Offset: 0x004CEB48
		private void UnRegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x06010DF0 RID: 69104 RVA: 0x004D07C8 File Offset: 0x004CEBC8
		private void OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP && (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.WearEquip))
					{
						this._LoadAllEquipments();
					}
					if (this.m_iCostSealID == item.TableID)
					{
						this.OnAdjustSealChanged(this.m_kEquipSealData);
					}
				}
			}
		}

		// Token: 0x06010DF1 RID: 69105 RVA: 0x004D085C File Offset: 0x004CEC5C
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this._LoadAllEquipments();
			if (this.m_iCostSealID == itemData.TableID)
			{
				this.OnAdjustSealChanged(this.m_kEquipSealData);
			}
		}

		// Token: 0x06010DF2 RID: 69106 RVA: 0x004D0888 File Offset: 0x004CEC88
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					this._LoadAllEquipments();
					if (this.m_kEquipSealData != null && this.m_kEquipSealData.item != null && this.m_kEquipSealData.item.GUID == item.GUID)
					{
						this.m_kEquipSealData.item = item;
						this.OnAdjustSealChanged(this.m_kEquipSealData);
					}
					if (this.m_iCostSealID == item.TableID)
					{
						this.OnAdjustSealChanged(this.m_kEquipSealData);
					}
				}
			}
		}

		// Token: 0x06010DF3 RID: 69107 RVA: 0x004D0948 File Offset: 0x004CED48
		private void InitInterface()
		{
			if (this.m_kComSeal == null)
			{
				this.m_kComSeal = ComItemManager.Create(this.goItemParent);
			}
			this.m_kComSeal.Setup(null, null);
			if (this.costSealItem == null)
			{
				this.costSealItem = ComItemManager.Create(this.goCostItemParent);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_iCostSealID, 100, 0);
			this.costSealItem.Setup(itemData, new ComItem.OnItemClicked(this.OnCommonItemClicked));
			this.costSealItem.transform.SetAsFirstSibling();
			if (this.m_kSealName != null)
			{
				this.m_kSealName.text = itemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06010DF4 RID: 69108 RVA: 0x004D0A08 File Offset: 0x004CEE08
		private void OnEquipmentItemSelected(ItemData itemData)
		{
			if (itemData != null && ComSealEquipment.CheckCanSeal(itemData))
			{
				if (this.m_uiLastSelectedId != itemData.GUID)
				{
					this.m_uiLastSelectedId = itemData.GUID;
					this.SendSealMaterialInfo(itemData);
				}
			}
			else
			{
				this.OnAdjustSealChanged(null);
			}
		}

		// Token: 0x06010DF5 RID: 69109 RVA: 0x004D0A56 File Offset: 0x004CEE56
		public void RefreshAllEquipments()
		{
			this._LoadAllEquipments();
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010DF6 RID: 69110 RVA: 0x004D0A64 File Offset: 0x004CEE64
		private void InitEquipmentUIList()
		{
			if (this.mEquipmentUIList != null)
			{
				this.mEquipmentUIList.Initialize();
				ComUIListScript comUIListScript = this.mEquipmentUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010DF7 RID: 69111 RVA: 0x004D0B2C File Offset: 0x004CEF2C
		private void UnInitEquipmentUIList()
		{
			if (this.mEquipmentUIList != null)
			{
				ComUIListScript comUIListScript = this.mEquipmentUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010DF8 RID: 69112 RVA: 0x004D0BE8 File Offset: 0x004CEFE8
		private ComSealEquipment _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComSealEquipment>();
		}

		// Token: 0x06010DF9 RID: 69113 RVA: 0x004D0C00 File Offset: 0x004CF000
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			if (comSealEquipment != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comSealEquipment.OnItemVisible(this.equipments[item.m_index], SmithShopNewTabType.SSNTT_EQUIPMENTSEAL, true);
			}
		}

		// Token: 0x06010DFA RID: 69114 RVA: 0x004D0C60 File Offset: 0x004CF060
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			ComSealEquipment.ms_selected = ((!(comSealEquipment == null)) ? comSealEquipment.ItemData : null);
			this.OnEquipmentItemSelected(ComSealEquipment.ms_selected);
		}

		// Token: 0x06010DFB RID: 69115 RVA: 0x004D0CA4 File Offset: 0x004CF0A4
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			if (comSealEquipment != null)
			{
				comSealEquipment.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010DFC RID: 69116 RVA: 0x004D0CD0 File Offset: 0x004CF0D0
		public void _LoadAllEquipments()
		{
			this.equipments.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (!item.IsLease)
					{
						if (!item.IsItemInUnUsedEquipPlan)
						{
							this.equipments.Add(item);
						}
					}
				}
			}
			itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType.Count; j++)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
				if (item2 != null && !item2.IsLease && item2.Type != ItemTable.eType.FUCKTITTLE)
				{
					this.equipments.Add(item2);
				}
			}
			this.equipments.RemoveAll((ItemData x) => x.EquipType == EEquipType.ET_BREATH || x.isInSidePack || x.PackageType != EPackageType.Equip || !ComSealEquipment.CheckCanSeal(x));
			this.equipments.Sort(new Comparison<ItemData>(this._SortEquipments));
			this.mEquipmentUIList.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010DFD RID: 69117 RVA: 0x004D0E0D File Offset: 0x004CF20D
		private void _BindLinkData()
		{
			if (this.linkData != null)
			{
				if (this.linkData.itemData != null)
				{
					this._TrySelectedItem(this.linkData.itemData.GUID);
				}
				this.linkData = null;
			}
		}

		// Token: 0x06010DFE RID: 69118 RVA: 0x004D0E48 File Offset: 0x004CF248
		private void _TrySelectedItem(ulong guid)
		{
			int iBindIndex = -1;
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i].GUID == guid)
				{
					iBindIndex = i;
					break;
				}
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010DFF RID: 69119 RVA: 0x004D0E98 File Offset: 0x004CF298
		private void _SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				ComSealEquipment.ms_selected = this.equipments[iBindIndex];
				if (!this.mEquipmentUIList.IsElementInScrollArea(iBindIndex))
				{
					this.mEquipmentUIList.EnsureElementVisable(iBindIndex);
				}
				this.mEquipmentUIList.SelectElement(iBindIndex, true);
			}
			else
			{
				ComSealEquipment.ms_selected = null;
				this.mEquipmentUIList.SelectElement(-1, true);
			}
			this.OnEquipmentItemSelected(ComSealEquipment.ms_selected);
		}

		// Token: 0x06010E00 RID: 69120 RVA: 0x004D0F1C File Offset: 0x004CF31C
		private void _TrySetDefaultEquipment()
		{
			if (ComSealEquipment.ms_selected != null)
			{
				ComSealEquipment.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(ComSealEquipment.ms_selected.GUID);
				if (ComSealEquipment.ms_selected != null && !this.HasObject(ComSealEquipment.ms_selected.GUID))
				{
					ComSealEquipment.ms_selected = null;
				}
			}
			int iBindIndex = -1;
			if (ComSealEquipment.ms_selected != null)
			{
				for (int i = 0; i < this.equipments.Count; i++)
				{
					if (this.equipments[i].GUID == ComSealEquipment.ms_selected.GUID)
					{
						iBindIndex = i;
						break;
					}
				}
			}
			else if (this.equipments.Count > 0)
			{
				iBindIndex = 0;
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010E01 RID: 69121 RVA: 0x004D0FE0 File Offset: 0x004CF3E0
		public bool HasObject(ulong guid)
		{
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i] != null && this.equipments[i].GUID == guid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010E02 RID: 69122 RVA: 0x004D1034 File Offset: 0x004CF434
		private int _SortEquipments(ItemData left, ItemData right)
		{
			if (left.PackageType != right.PackageType)
			{
				return right.PackageType - left.PackageType;
			}
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			if (left.SubType != right.SubType)
			{
				return left.SubType - right.SubType;
			}
			if (left.StrengthenLevel != right.StrengthenLevel)
			{
				return right.StrengthenLevel - left.StrengthenLevel;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x06010E03 RID: 69123 RVA: 0x004D10CC File Offset: 0x004CF4CC
		public void SendSealMaterialInfo(ItemData a_item)
		{
			SceneCheckSealEquipReq cmd = new SceneCheckSealEquipReq
			{
				uid = a_item.GUID
			};
			this.m_keep_item = a_item;
			NetManager.Instance().SendCommand<SceneCheckSealEquipReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneCheckSealEquipRet>(delegate(SceneCheckSealEquipRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else if (msgRet.needNum <= 0)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_seal_data_error"), null, string.Empty, false);
				}
				else
				{
					EquipSealData equipSealData = new EquipSealData
					{
						item = this.m_keep_item,
						material = ItemDataManager.CreateItemDataFromTable((int)msgRet.matID, 100, 0)
					};
					equipSealData.material.Count = (int)msgRet.needNum;
					this.OnAdjustSealChanged(equipSealData);
				}
			}, true, 15f, null);
		}

		// Token: 0x06010E04 RID: 69124 RVA: 0x004D1120 File Offset: 0x004CF520
		private void OnAdjustSealChanged(EquipSealData equipSealData)
		{
			this.m_kEquipSealData = equipSealData;
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_iCostSealID, true);
			int num = (equipSealData != null && equipSealData.material != null) ? equipSealData.material.Count : 1;
			if (equipSealData == null)
			{
				if (null != this.m_kComSeal)
				{
					this.m_kComSeal.Setup(null, null);
				}
				if (null != this.m_kSealTimes)
				{
					this.m_kSealTimes.text = string.Format("{0}次", 0);
				}
			}
			else
			{
				if (null != this.m_kComSeal)
				{
					this.m_kComSeal.Setup(equipSealData.item, new ComItem.OnItemClicked(this.OnCommonItemClicked));
				}
				if (equipSealData.item != null)
				{
					if (null != this.m_kSealTimes)
					{
						this.m_kSealTimes.text = string.Format("{0}次", equipSealData.item.RePackTime);
					}
				}
				else if (null != this.m_kSealTimes)
				{
					this.m_kSealTimes.text = string.Format("{0}次", 0);
				}
			}
			if (null != this.m_kCostSealCount)
			{
				this.m_kCostSealCount.enabled = (equipSealData != null);
				this.m_kCostSealCount.text = string.Format("{0}/{1}", ownedItemCount, num);
				this.m_kCostSealCount.color = ((ownedItemCount < num) ? Color.red : Color.white);
			}
			this.goSealComeItemLink.CustomActive(ownedItemCount < num);
			if (null != this.m_kCostSealCount && null != this.goHint)
			{
				this.goHint.CustomActive(this.m_kCostSealCount.enabled);
			}
			if (null != this.goSealComeItemLink && null != this.costSealItem)
			{
				this.costSealItem.SetShowNotEnoughState(this.goSealComeItemLink.activeSelf);
			}
		}

		// Token: 0x06010E05 RID: 69125 RVA: 0x004D1342 File Offset: 0x004CF742
		private void OnCommonItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010E06 RID: 69126 RVA: 0x004D135C File Offset: 0x004CF75C
		private void OnSealItemComeLink()
		{
			ItemComeLink.OnLink(this.m_iCostSealID, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x06010E07 RID: 69127 RVA: 0x004D1380 File Offset: 0x004CF780
		private void OnSealClicked()
		{
			if (this.m_kEquipSealData == null || this.m_kEquipSealData.item == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("请先选择一件装备!", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_kEquipSealData.material != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_kEquipSealData.material.TableID, true);
				int count = this.m_kEquipSealData.material.Count;
				if (ownedItemCount < count)
				{
					ItemComeLink.OnLink(200110001, count - ownedItemCount, true, delegate
					{
						this.OnSceneSealEquipReq();
					}, false, false, false, null, string.Empty);
					return;
				}
				this.OnSceneSealEquipReq();
			}
		}

		// Token: 0x06010E08 RID: 69128 RVA: 0x004D1424 File Offset: 0x004CF824
		private void OnSceneSealEquipReq()
		{
			string msgContent = string.Empty;
			bool flag = DataManager<InscriptionMosaicDataManager>.GetInstance().CheckEquipmentMosaicInscriptionQualityFollowingFive(this.m_kEquipSealData.item);
			if (flag)
			{
				msgContent = TR.Value("Inscription_EquipSeal_Desc");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnSealClicked2(this.m_kEquipSealData.item);
				}, null, 0f, false);
				return;
			}
			List<ItemData> list = new List<ItemData>();
			bool flag2 = DataManager<InscriptionMosaicDataManager>.GetInstance().CheckEquipmentMosaicInscriptionQualityFive(ref list, this.m_kEquipSealData.item, true);
			if (flag2)
			{
				string text = string.Empty;
				if (list != null && list.Count > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						text += string.Format("[{0}] ", list[i].GetColorName(string.Empty, false));
					}
				}
				msgContent = TR.Value("Inscription_EquipSeal_PickHightQuality_Desc", text);
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnSealClicked2(this.m_kEquipSealData.item);
				}, null, 0f, false);
				return;
			}
			bool flag3 = DataManager<InscriptionMosaicDataManager>.GetInstance().CheckEquipmentMosaicInscriptionQualityFive(ref list, this.m_kEquipSealData.item, false);
			if (flag3)
			{
				string text2 = string.Empty;
				if (list != null && list.Count > 0)
				{
					for (int j = 0; j < list.Count; j++)
					{
						text2 += string.Format("[{0}] ", list[j].GetColorName(string.Empty, false));
					}
				}
				msgContent = TR.Value("Inscription_EquipSeal_PickHightQuality_LowQuailty_Desc", text2);
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnSealClicked2(this.m_kEquipSealData.item);
				}, null, 0f, false);
				return;
			}
			this.OnSealClicked2(this.m_kEquipSealData.item);
		}

		// Token: 0x06010E09 RID: 69129 RVA: 0x004D15D4 File Offset: 0x004CF9D4
		private void OnSealClicked2(ItemData itemData)
		{
			SceneSealEquipReq cmd = new SceneSealEquipReq
			{
				uid = itemData.GUID
			};
			NetManager.Instance().SendCommand<SceneSealEquipReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneSealEquipRet>(delegate(SceneSealEquipRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					List<ResultItemData> list = new List<ResultItemData>();
					list.Add(new ResultItemData
					{
						itemData = itemData,
						desc = itemData.GetColorName(string.Empty, false) + "\n" + TR.Value("equip_seal_time_left", itemData.RePackTime)
					});
					for (int i = 0; i < msgRet.inscriptionIds.Length; i++)
					{
						ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)msgRet.inscriptionIds[i], 100, 0);
						if (itemData2 != null)
						{
							list.Add(new ResultItemData
							{
								itemData = itemData2,
								desc = itemData2.GetColorName(string.Empty, false)
							});
						}
					}
					CommonGetItemData userData = new CommonGetItemData
					{
						title = TR.Value("ItemSealOk"),
						itemDatas = list,
						itemClickCallback = null
					};
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjustResultFrameEx>(FrameLayer.Middle, userData, string.Empty);
					this.RefreshAllEquipments();
				}
			}, true, 15f, null);
		}

		// Token: 0x0400AD3D RID: 44349
		[SerializeField]
		private ComUIListScript mEquipmentUIList;

		// Token: 0x0400AD3E RID: 44350
		[SerializeField]
		private GameObject goSealComeItemLink;

		// Token: 0x0400AD3F RID: 44351
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400AD40 RID: 44352
		[SerializeField]
		private GameObject goCostItemParent;

		// Token: 0x0400AD41 RID: 44353
		[SerializeField]
		private GameObject goHint;

		// Token: 0x0400AD42 RID: 44354
		[SerializeField]
		private Text m_kSealTimes;

		// Token: 0x0400AD43 RID: 44355
		[SerializeField]
		private Text m_kCostSealCount;

		// Token: 0x0400AD44 RID: 44356
		[SerializeField]
		private Text m_kSealName;

		// Token: 0x0400AD45 RID: 44357
		[SerializeField]
		private Button mBtnItemComLink;

		// Token: 0x0400AD46 RID: 44358
		[SerializeField]
		private Button mBtnSeal;

		// Token: 0x0400AD47 RID: 44359
		[SerializeField]
		private int m_iCostSealID = 200110001;

		// Token: 0x0400AD48 RID: 44360
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400AD49 RID: 44361
		private SmithShopNewLinkData linkData;

		// Token: 0x0400AD4A RID: 44362
		private ComItem m_kComSeal;

		// Token: 0x0400AD4B RID: 44363
		private ComItem costSealItem;

		// Token: 0x0400AD4C RID: 44364
		private ulong m_uiLastSelectedId;

		// Token: 0x0400AD4D RID: 44365
		private ItemData m_keep_item;

		// Token: 0x0400AD4E RID: 44366
		private EquipSealData m_kEquipSealData;
	}
}

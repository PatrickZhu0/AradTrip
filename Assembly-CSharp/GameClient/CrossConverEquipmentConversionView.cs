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
	// Token: 0x02001B06 RID: 6918
	public class CrossConverEquipmentConversionView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010FAE RID: 69550 RVA: 0x004DACE5 File Offset: 0x004D90E5
		private void Awake()
		{
			this.RegisterEventHandle();
			this.InitEquipmentComUIListScript();
			this.InitMaterailExpendItemComUIListScript();
			this.AddListener();
		}

		// Token: 0x06010FAF RID: 69551 RVA: 0x004DACFF File Offset: 0x004D90FF
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06010FB0 RID: 69552 RVA: 0x004DAD08 File Offset: 0x004D9108
		private void ClearData()
		{
			this.UnRegisterEventHandle();
			this.UnInitEquipmentComUIListScript();
			this.UnInitMaterailExpendItemComUIListScript();
			this.RemoveListener();
			this.mAllEquipmentList.Clear();
			this.mMaterailExpendItems.Clear();
			this.mTargetEquipmentList.Clear();
			this.mConverterItemDataList.Clear();
			this.bIsCheckConverter = false;
			this.mCurrentEquipmentItemData = null;
			this.mTargetEquipmentItemData = null;
			this.mConverterItemData = null;
			this.mCurrentEquipmentComItem = null;
			this.mTargetEquipmentComItem = null;
			this.mConverterComItem = null;
		}

		// Token: 0x06010FB1 RID: 69553 RVA: 0x004DAD8A File Offset: 0x004D918A
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.LoadAllEquipmemnt();
		}

		// Token: 0x06010FB2 RID: 69554 RVA: 0x004DAD92 File Offset: 0x004D9192
		public void OnDisableView()
		{
			this.UnRegisterEventHandle();
		}

		// Token: 0x06010FB3 RID: 69555 RVA: 0x004DAD9A File Offset: 0x004D919A
		public void OnEnableView()
		{
			this.RegisterEventHandle();
			this.LoadAllEquipmemnt();
		}

		// Token: 0x06010FB4 RID: 69556 RVA: 0x004DADA8 File Offset: 0x004D91A8
		private void AddListener()
		{
			if (this.mSelectedTargetEquipmentBtn != null)
			{
				this.mSelectedTargetEquipmentBtn.onClick.RemoveAllListeners();
				this.mSelectedTargetEquipmentBtn.onClick.AddListener(new UnityAction(this.OnTargetEquipmentBtnClick));
			}
			if (this.mConverterBtn != null)
			{
				this.mConverterBtn.onClick.RemoveAllListeners();
				this.mConverterBtn.onClick.AddListener(new UnityAction(this.OnConverterBtnClick));
			}
			if (this.mConverterReplacePropTog != null)
			{
				this.mConverterReplacePropTog.onValueChanged.RemoveAllListeners();
				this.mConverterReplacePropTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnConverterReplacePropTogClick));
			}
			if (this.mConversionBtn != null)
			{
				this.mConversionBtn.onClick.RemoveAllListeners();
				this.mConversionBtn.onClick.AddListener(new UnityAction(this.OnConversionBtnClick));
			}
		}

		// Token: 0x06010FB5 RID: 69557 RVA: 0x004DAEAC File Offset: 0x004D92AC
		private void RemoveListener()
		{
			if (this.mSelectedTargetEquipmentBtn != null)
			{
				this.mSelectedTargetEquipmentBtn.onClick.RemoveListener(new UnityAction(this.OnTargetEquipmentBtnClick));
			}
			if (this.mConverterBtn != null)
			{
				this.mConverterBtn.onClick.RemoveListener(new UnityAction(this.OnConverterBtnClick));
			}
			if (this.mConverterReplacePropTog != null)
			{
				this.mConverterReplacePropTog.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnConverterReplacePropTogClick));
			}
			if (this.mConversionBtn != null)
			{
				this.mConversionBtn.onClick.RemoveListener(new UnityAction(this.OnConversionBtnClick));
			}
		}

		// Token: 0x06010FB6 RID: 69558 RVA: 0x004DAF70 File Offset: 0x004D9370
		private void OnTargetEquipmentBtnClick()
		{
			EpicEquipmentTransformationTargetDataModle epicEquipmentTransformationTargetDataModle = new EpicEquipmentTransformationTargetDataModle();
			epicEquipmentTransformationTargetDataModle.equipmentItem = this.mCurrentEquipmentItemData;
			epicEquipmentTransformationTargetDataModle.type = EpicEquipmentTransformationType.AcrossaSetOfConversion;
			EpicEquipmentTransformationTargetDataModle epicEquipmentTransformationTargetDataModle2 = epicEquipmentTransformationTargetDataModle;
			epicEquipmentTransformationTargetDataModle2.onTargetEquipmentClick = (Action<ItemData>)Delegate.Combine(epicEquipmentTransformationTargetDataModle2.onTargetEquipmentClick, new Action<ItemData>(this.RefreshTargetEquipmentInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EpicTransformationTargetEquipmentFrame>(FrameLayer.Middle, epicEquipmentTransformationTargetDataModle, string.Empty);
		}

		// Token: 0x06010FB7 RID: 69559 RVA: 0x004DAFCC File Offset: 0x004D93CC
		private void OnConverterBtnClick()
		{
			this.mConverterItemDataList.Clear();
			for (int i = 0; i < this.mConverterItems.Count; i++)
			{
				ItemSimpleData itemSimpleData = this.mConverterItems[i];
				if (itemSimpleData != null)
				{
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
					for (int j = 0; j < itemsByPackageType.Count; j++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
						if (item != null)
						{
							if (item.ThirdType == (ItemTable.eThirdType)itemSimpleData.ItemID)
							{
								if (item.useLimitType == ItemTable.eUseLimiteType.SUITLV)
								{
									if (item.useLimitValue == itemSimpleData.level)
									{
										if (item.Count > 0)
										{
											int num = 0;
											bool flag = false;
											item.GetLimitTimeLeft(out num, out flag);
											if (num > 0 || !flag)
											{
												this.mConverterItemDataList.Add(item);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (this.mConverterItemDataList.Count <= 0)
			{
				ItemComeLink.OnLink(311, 0, true, null, false, false, false, null, string.Empty);
				return;
			}
			EpicTransformationConverterDataModel epicTransformationConverterDataModel = new EpicTransformationConverterDataModel();
			epicTransformationConverterDataModel.converterList = this.mConverterItemDataList;
			EpicTransformationConverterDataModel epicTransformationConverterDataModel2 = epicTransformationConverterDataModel;
			epicTransformationConverterDataModel2.onConverterClick = (Action<ItemData>)Delegate.Combine(epicTransformationConverterDataModel2.onConverterClick, new Action<ItemData>(this.RefreshConverterItemInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EpicTransformationConverterFrame>(FrameLayer.Middle, epicTransformationConverterDataModel, string.Empty);
		}

		// Token: 0x06010FB8 RID: 69560 RVA: 0x004DB150 File Offset: 0x004D9550
		private void OnConverterReplacePropTogClick(bool value)
		{
			this.bIsCheckConverter = value;
			this.mMaterailExpendItemRoot.CustomActive(!this.bIsCheckConverter);
			this.mConverterItemRoot.CustomActive(this.bIsCheckConverter);
			if (!this.bIsCheckConverter)
			{
				this.RefreshExpendMaterail();
			}
		}

		// Token: 0x06010FB9 RID: 69561 RVA: 0x004DB190 File Offset: 0x004D9590
		private void OnConversionBtnClick()
		{
			if (this.mCurrentEquipmentItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipmentConversion_PutEquipment"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mCurrentEquipmentItemData.PackageType == EPackageType.WearEquip || this.mCurrentEquipmentItemData.IsItemInUnUsedEquipPlan)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipmentConversion_WearEquipDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.mTargetEquipmentItemData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipConversion_TargetEquipmentDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.bIsCheckConverter)
			{
				if (this.mConverterItemData == null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipConversion_ConverterDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int num;
				bool flag;
				this.mConverterItemData.GetLimitTimeLeft(out num, out flag);
				if (num <= 0 && flag)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("failure_item"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
			}
			else
			{
				bool flag2 = true;
				for (int i = 0; i < this.mMaterailExpendItems.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.mMaterailExpendItems[i];
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(itemSimpleData.ItemID);
					if (commonItemTableDataByID != null)
					{
						int num2;
						if (commonItemTableDataByID.Type == ItemTable.eType.MATERIAL)
						{
							num2 = DataManager<ItemDataManager>.GetInstance().GetItemCount(commonItemTableDataByID.TableID);
						}
						else
						{
							num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(commonItemTableDataByID.TableID, true);
						}
						if (num2 < itemSimpleData.Count)
						{
							flag2 = false;
							break;
						}
					}
				}
				if (!flag2)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipConversion_LackOfMaterial"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				int nMoneyID = 0;
				int num3 = 0;
				int num4 = 0;
				for (int j = 0; j < this.mMaterailExpendItems.Count; j++)
				{
					ItemSimpleData itemSimpleData2 = this.mMaterailExpendItems[j];
					ItemData commonItemTableDataByID2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(itemSimpleData2.ItemID);
					if (commonItemTableDataByID2 != null)
					{
						if (commonItemTableDataByID2.Type != ItemTable.eType.MATERIAL)
						{
							nMoneyID = commonItemTableDataByID2.TableID;
							num4 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(commonItemTableDataByID2.TableID, false);
							num3 = itemSimpleData2.Count;
							break;
						}
					}
				}
				if (num4 < num3)
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
					{
						nMoneyID = nMoneyID,
						nCount = num3
					}, new Action(this.OnSceneEquipConvertReq), "common_money_cost", null);
					return;
				}
			}
			this.OnSceneEquipConvertReq();
		}

		// Token: 0x06010FBA RID: 69562 RVA: 0x004DB3F0 File Offset: 0x004D97F0
		private void OnSceneEquipConvertReq()
		{
			string msgContent = string.Empty;
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= this.mTargetEquipmentItemData.LevelLimit)
			{
				msgContent = TR.Value("EquipConversion_ConformLevel", this.mCurrentEquipmentItemData.GetColorName(string.Empty, false), this.mTargetEquipmentItemData.GetColorName(string.Empty, false));
			}
			else
			{
				msgContent = TR.Value("EquipConversion_NoConformLevel", this.mCurrentEquipmentItemData.GetColorName(string.Empty, false), this.mTargetEquipmentItemData.GetColorName(string.Empty, false));
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				ulong converterGuid = (!this.bIsCheckConverter) ? 0UL : this.mConverterItemData.GUID;
				DataManager<EpicEquipmentTransformationDataManager>.GetInstance().OnSceneEquipConvertReq(2, this.mCurrentEquipmentItemData.GUID, (uint)this.mTargetEquipmentItemData.TableID, converterGuid);
			}, null, 0f, false);
		}

		// Token: 0x06010FBB RID: 69563 RVA: 0x004DB498 File Offset: 0x004D9898
		private void RegisterEventHandle()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEpicEquipmentConversionSuccessed, new ClientEventSystem.UIEventHandler(this.OnEpicEquipmentConversionSuccessed));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
			PlayerBaseData instance3 = DataManager<PlayerBaseData>.GetInstance();
			instance3.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance3.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010FBC RID: 69564 RVA: 0x004DB534 File Offset: 0x004D9934
		private void UnRegisterEventHandle()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEpicEquipmentConversionSuccessed, new ClientEventSystem.UIEventHandler(this.OnEpicEquipmentConversionSuccessed));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
			PlayerBaseData instance3 = DataManager<PlayerBaseData>.GetInstance();
			instance3.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance3.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010FBD RID: 69565 RVA: 0x004DB5CE File Offset: 0x004D99CE
		private void OnEpicEquipmentConversionSuccessed(UIEvent uiEvent)
		{
			this.LoadAllEquipmemnt();
		}

		// Token: 0x06010FBE RID: 69566 RVA: 0x004DB5D8 File Offset: 0x004D99D8
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
					if (item.Type == ItemTable.eType.MATERIAL)
					{
						this.RefreshExpendMaterail();
					}
					if (item.Type == ItemTable.eType.EQUIP && item.Quality == ItemTable.eColor.YELLOW)
					{
						this.LoadAllEquipmemnt();
					}
				}
			}
		}

		// Token: 0x06010FBF RID: 69567 RVA: 0x004DB655 File Offset: 0x004D9A55
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD || eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_GOLD)
			{
				this.RefreshExpendMaterail();
			}
		}

		// Token: 0x06010FC0 RID: 69568 RVA: 0x004DB66C File Offset: 0x004D9A6C
		private void LoadAllEquipmemnt()
		{
			if (this.mAllEquipmentList != null)
			{
				this.mAllEquipmentList.Clear();
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			this.FiltraterEquipment(itemsByPackageType);
			this.FiltraterEquipment(itemsByPackageType2);
			List<ItemData> list = this.mAllEquipmentList;
			if (CrossConverEquipmentConversionView.<>f__mg$cache0 == null)
			{
				CrossConverEquipmentConversionView.<>f__mg$cache0 = new Comparison<ItemData>(EquipmentConversionUtility.SoreEquipments);
			}
			list.Sort(CrossConverEquipmentConversionView.<>f__mg$cache0);
			if (this.mEquipmentComUIList != null)
			{
				this.mEquipmentComUIList.SetElementAmount(this.mAllEquipmentList.Count);
			}
			if (this.mAllEquipmentList.Count <= 0)
			{
				this.ClearInfo();
				this.mSelectedTargetEquipmentBtn.CustomActive(false);
			}
			this.TrySetDefaultEquipment();
		}

		// Token: 0x06010FC1 RID: 69569 RVA: 0x004DB734 File Offset: 0x004D9B34
		private void FiltraterEquipment(List<ulong> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i]);
				if (item != null)
				{
					if (item.Quality == ItemTable.eColor.YELLOW)
					{
						if (item.EquipType != EEquipType.ET_BREATH)
						{
							if (!item.HasTransfered)
							{
								if (DataManager<EpicEquipmentTransformationDataManager>.GetInstance().CheckCrossEpicEquipmentCanbeDisplayedInTheEquipmentList(item))
								{
									this.mAllEquipmentList.Add(item);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06010FC2 RID: 69570 RVA: 0x004DB7C8 File Offset: 0x004D9BC8
		private void TrySetDefaultEquipment()
		{
			int selectItem = -1;
			if (EquipUpgradeItem.ms_selected != null)
			{
				ItemData itemData = this.mAllEquipmentList.Find((ItemData x) => x.GUID == EquipUpgradeItem.ms_selected.GUID);
				if (itemData != null)
				{
					EquipUpgradeItem.ms_selected = itemData;
				}
				else
				{
					EquipUpgradeItem.ms_selected = null;
				}
			}
			if (EquipUpgradeItem.ms_selected != null)
			{
				for (int i = 0; i < this.mAllEquipmentList.Count; i++)
				{
					ulong guid = this.mAllEquipmentList[i].GUID;
					if (guid == EquipUpgradeItem.ms_selected.GUID)
					{
						selectItem = i;
					}
				}
			}
			else if (this.mAllEquipmentList.Count > 0)
			{
				selectItem = 0;
			}
			this.SetSelectItem(selectItem);
		}

		// Token: 0x06010FC3 RID: 69571 RVA: 0x004DB890 File Offset: 0x004D9C90
		private void SetSelectItem(int index)
		{
			if (index >= 0 && index < this.mAllEquipmentList.Count)
			{
				EquipUpgradeItem.ms_selected = this.mAllEquipmentList[index];
				if (!this.mEquipmentComUIList.IsElementInScrollArea(index))
				{
					this.mEquipmentComUIList.EnsureElementVisable(index);
				}
				this.mEquipmentComUIList.SelectElement(index, true);
			}
			else
			{
				this.mEquipmentComUIList.SelectElement(-1, true);
				EquipUpgradeItem.ms_selected = null;
			}
			this.OnEquipmentItemClick(EquipUpgradeItem.ms_selected);
		}

		// Token: 0x06010FC4 RID: 69572 RVA: 0x004DB914 File Offset: 0x004D9D14
		private void InitEquipmentComUIListScript()
		{
			if (this.mEquipmentComUIList != null)
			{
				this.mEquipmentComUIList.Initialize();
				ComUIListScript comUIListScript = this.mEquipmentComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentComUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentComUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010FC5 RID: 69573 RVA: 0x004DB9DC File Offset: 0x004D9DDC
		private void UnInitEquipmentComUIListScript()
		{
			if (this.mEquipmentComUIList != null)
			{
				ComUIListScript comUIListScript = this.mEquipmentComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipmentComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipmentComUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipmentComUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06010FC6 RID: 69574 RVA: 0x004DBA96 File Offset: 0x004D9E96
		private EquipUpgradeItem OnBindItemDelegate(GameObject itemObjcet)
		{
			return itemObjcet.GetComponent<EquipUpgradeItem>();
		}

		// Token: 0x06010FC7 RID: 69575 RVA: 0x004DBAA0 File Offset: 0x004D9EA0
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null && item.m_index >= 0 && item.m_index < this.mAllEquipmentList.Count)
			{
				equipUpgradeItem.OnItemVisiable(this.mAllEquipmentList[item.m_index]);
			}
		}

		// Token: 0x06010FC8 RID: 69576 RVA: 0x004DBB00 File Offset: 0x004D9F00
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				EquipUpgradeItem.ms_selected = equipUpgradeItem.ItemData;
				this.OnEquipmentItemClick(equipUpgradeItem.ItemData);
			}
		}

		// Token: 0x06010FC9 RID: 69577 RVA: 0x004DBB3C File Offset: 0x004D9F3C
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				equipUpgradeItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010FCA RID: 69578 RVA: 0x004DBB68 File Offset: 0x004D9F68
		private void InitMaterailExpendItemComUIListScript()
		{
			if (this.mMaterailExpendItemComUIListScript != null)
			{
				this.mMaterailExpendItemComUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mMaterailExpendItemComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMaterailExpendBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMaterailExpendItemComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMaterailExpendItemVisiableDelegate));
			}
		}

		// Token: 0x06010FCB RID: 69579 RVA: 0x004DBBE0 File Offset: 0x004D9FE0
		private void UnInitMaterailExpendItemComUIListScript()
		{
			if (this.mMaterailExpendItemComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mMaterailExpendItemComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMaterailExpendBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMaterailExpendItemComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMaterailExpendItemVisiableDelegate));
			}
		}

		// Token: 0x06010FCC RID: 69580 RVA: 0x004DBC4C File Offset: 0x004DA04C
		private EquipUpgradeCostItem OnMaterailExpendBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EquipUpgradeCostItem>();
		}

		// Token: 0x06010FCD RID: 69581 RVA: 0x004DBC54 File Offset: 0x004DA054
		private void OnMaterailExpendItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeCostItem equipUpgradeCostItem = item.gameObjectBindScript as EquipUpgradeCostItem;
			if (equipUpgradeCostItem != null && item.m_index >= 0 && item.m_index < this.mMaterailExpendItems.Count)
			{
				equipUpgradeCostItem.OnItemVisiable(this.mMaterailExpendItems[item.m_index]);
			}
		}

		// Token: 0x06010FCE RID: 69582 RVA: 0x004DBCB4 File Offset: 0x004DA0B4
		private void ClearInfo()
		{
			this.mConverterItemRoot.CustomActive(false);
			this.mConverterReplacePropTog.CustomActive(false);
			this.mTargetEquipmentItemParent.CustomActive(false);
			this.mConverterItemParent.CustomActive(false);
			this.mConverterItemName.text = this.selectedConverterDes;
			this.mTargetEquipmentName.text = string.Empty;
			this.mCurrentEquipmentName.text = string.Empty;
			this.mCurrentEquipmentItemData = null;
			this.mTargetEquipmentItemData = null;
			this.mConverterItemData = null;
			this.mCurrentEquipmentItemParent.CustomActive(false);
			this.mTargetEquipmentItemParent.CustomActive(false);
			this.mMaterailExpendItems.Clear();
			this.mMaterailExpendItemComUIListScript.SetElementAmount(0);
		}

		// Token: 0x06010FCF RID: 69583 RVA: 0x004DBD66 File Offset: 0x004DA166
		private void OnEquipmentItemClick(ItemData itemData)
		{
			this.ClearInfo();
			this.RefreshCurrentEquipmentInfo(itemData);
		}

		// Token: 0x06010FD0 RID: 69584 RVA: 0x004DBD78 File Offset: 0x004DA178
		private void RefreshCurrentEquipmentInfo(ItemData itemData)
		{
			this.mCurrentEquipmentItemData = itemData;
			if (this.mCurrentEquipmentItemData == null)
			{
				return;
			}
			this.mCurrentEquipmentItemParent.CustomActive(true);
			if (this.mCurrentEquipmentComItem == null)
			{
				this.mCurrentEquipmentComItem = ComItemManager.Create(this.mCurrentEquipmentItemParent);
			}
			ComItem comItem = this.mCurrentEquipmentComItem;
			ItemData item = this.mCurrentEquipmentItemData;
			if (CrossConverEquipmentConversionView.<>f__mg$cache1 == null)
			{
				CrossConverEquipmentConversionView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, CrossConverEquipmentConversionView.<>f__mg$cache1);
			if (this.mCurrentEquipmentName != null)
			{
				this.mCurrentEquipmentName.text = this.mCurrentEquipmentItemData.GetColorName(string.Empty, false);
			}
			this.mTargetEquipmentList = DataManager<EpicEquipmentTransformationDataManager>.GetInstance().GetCrossTargetEquipmentList(this.mCurrentEquipmentItemData);
			if (this.mTargetEquipmentList.Count > 1)
			{
				this.mSelectedTargetEquipmentBtn.CustomActive(true);
			}
			else if (this.mTargetEquipmentList.Count == 1)
			{
				this.mSelectedTargetEquipmentBtn.CustomActive(false);
				this.RefreshTargetEquipmentInfo(this.mTargetEquipmentList[0]);
			}
		}

		// Token: 0x06010FD1 RID: 69585 RVA: 0x004DBE88 File Offset: 0x004DA288
		private void RefreshTargetEquipmentInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mTargetEquipmentItemData = itemData;
			this.mConverterItemRoot.CustomActive(this.bIsCheckConverter);
			this.mConverterReplacePropTog.CustomActive(true);
			this.mTargetEquipmentItemParent.CustomActive(true);
			if (this.mTargetEquipmentComItem == null)
			{
				this.mTargetEquipmentComItem = ComItemManager.Create(this.mTargetEquipmentItemParent);
			}
			ComItem comItem = this.mTargetEquipmentComItem;
			ItemData item = this.mTargetEquipmentItemData;
			if (CrossConverEquipmentConversionView.<>f__mg$cache2 == null)
			{
				CrossConverEquipmentConversionView.<>f__mg$cache2 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, CrossConverEquipmentConversionView.<>f__mg$cache2);
			if (this.mTargetEquipmentName != null)
			{
				this.mTargetEquipmentName.text = this.mTargetEquipmentItemData.GetColorName(string.Empty, false);
			}
			this.mMaterailExpendItems.Clear();
			this.mConverterItems.Clear();
			DataManager<EpicEquipmentTransformationDataManager>.GetInstance().GetConvertedTargetEquipmentMaterial(EpicEquipmentTransformationType.AcrossaSetOfConversion, this.mTargetEquipmentItemData, ref this.mMaterailExpendItems, ref this.mConverterItems);
			if (this.mMaterailExpendItems.Count > 0 && this.mConverterItems.Count > 0)
			{
				this.mMaterailExpendItemRoot.CustomActive(true);
				this.mConverterReplacePropTog.CustomActive(true);
				if (this.bIsCheckConverter)
				{
					this.mMaterailExpendItemRoot.CustomActive(false);
					if (this.mConverterItemData != null)
					{
						bool flag = false;
						for (int i = 0; i < this.mConverterItemDataList.Count; i++)
						{
							if (this.mConverterItemDataList[i].TableID == this.mConverterItemData.TableID)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							this.mConverterItemData = null;
							this.mConverterItemParent.CustomActive(false);
						}
						else
						{
							this.RefreshConverterItemInfo(this.mConverterItemData);
						}
					}
				}
				else
				{
					this.RefreshExpendMaterail();
				}
			}
			else if (this.mMaterailExpendItems.Count > 0 && this.mConverterItems.Count <= 0)
			{
				if (this.mConverterReplacePropTog.isOn)
				{
					this.mConverterReplacePropTog.isOn = false;
				}
				this.mMaterailExpendItemRoot.CustomActive(true);
				this.mConverterReplacePropTog.CustomActive(false);
				this.RefreshExpendMaterail();
			}
			else if (this.mMaterailExpendItems.Count <= 0 && this.mConverterItems.Count > 0)
			{
				this.mConverterReplacePropTog.isOn = true;
				this.mMaterailExpendItemRoot.CustomActive(false);
				this.mConverterReplacePropTog.CustomActive(false);
			}
		}

		// Token: 0x06010FD2 RID: 69586 RVA: 0x004DC104 File Offset: 0x004DA504
		private void RefreshExpendMaterail()
		{
			if (this.mMaterailExpendItemComUIListScript != null)
			{
				this.mMaterailExpendItemComUIListScript.SetElementAmount(this.mMaterailExpendItems.Count);
			}
		}

		// Token: 0x06010FD3 RID: 69587 RVA: 0x004DC130 File Offset: 0x004DA530
		private void RefreshConverterItemInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				this.mConverterItemParent.CustomActive(false);
				return;
			}
			this.mConverterItemParent.CustomActive(true);
			this.mConverterItemData = itemData;
			if (this.mConverterItemBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.mConverterItemBackground, this.mConverterItemData.GetQualityInfo().Background, true);
			}
			if (this.mConverterItemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mConverterItemIcon, this.mConverterItemData.Icon, true);
			}
			if (this.mConverterItemName != null)
			{
				this.mConverterItemName.text = this.mConverterItemData.GetColorName(string.Empty, false);
			}
			if (this.mConverterItemCount != null)
			{
				this.mConverterItemCount.text = string.Format("{0}/1", this.mConverterItemData.Count);
			}
		}

		// Token: 0x0400AEB5 RID: 44725
		[SerializeField]
		private ComUIListScript mEquipmentComUIList;

		// Token: 0x0400AEB6 RID: 44726
		[SerializeField]
		private ComUIListScript mMaterailExpendItemComUIListScript;

		// Token: 0x0400AEB7 RID: 44727
		[SerializeField]
		private GameObject mCurrentEquipmentItemParent;

		// Token: 0x0400AEB8 RID: 44728
		[SerializeField]
		private GameObject mTargetEquipmentItemParent;

		// Token: 0x0400AEB9 RID: 44729
		[SerializeField]
		private GameObject mConverterItemParent;

		// Token: 0x0400AEBA RID: 44730
		[SerializeField]
		private GameObject mMaterailExpendItemRoot;

		// Token: 0x0400AEBB RID: 44731
		[SerializeField]
		private GameObject mConverterItemRoot;

		// Token: 0x0400AEBC RID: 44732
		[SerializeField]
		private Text mCurrentEquipmentName;

		// Token: 0x0400AEBD RID: 44733
		[SerializeField]
		private Text mTargetEquipmentName;

		// Token: 0x0400AEBE RID: 44734
		[SerializeField]
		private Text mConverterItemName;

		// Token: 0x0400AEBF RID: 44735
		[SerializeField]
		private Text mConverterItemCount;

		// Token: 0x0400AEC0 RID: 44736
		[SerializeField]
		private Image mConverterItemBackground;

		// Token: 0x0400AEC1 RID: 44737
		[SerializeField]
		private Image mConverterItemIcon;

		// Token: 0x0400AEC2 RID: 44738
		[SerializeField]
		private Button mSelectedTargetEquipmentBtn;

		// Token: 0x0400AEC3 RID: 44739
		[SerializeField]
		private Button mConverterBtn;

		// Token: 0x0400AEC4 RID: 44740
		[SerializeField]
		private Button mConversionBtn;

		// Token: 0x0400AEC5 RID: 44741
		[SerializeField]
		private Toggle mConverterReplacePropTog;

		// Token: 0x0400AEC6 RID: 44742
		private string selectedConverterDes = "选择转化器";

		// Token: 0x0400AEC7 RID: 44743
		private List<ItemData> mAllEquipmentList = new List<ItemData>();

		// Token: 0x0400AEC8 RID: 44744
		private List<ItemData> mTargetEquipmentList = new List<ItemData>();

		// Token: 0x0400AEC9 RID: 44745
		private List<ItemData> mConverterItemDataList = new List<ItemData>();

		// Token: 0x0400AECA RID: 44746
		private List<ItemSimpleData> mMaterailExpendItems = new List<ItemSimpleData>();

		// Token: 0x0400AECB RID: 44747
		private List<ItemSimpleData> mConverterItems = new List<ItemSimpleData>();

		// Token: 0x0400AECC RID: 44748
		private ItemData mCurrentEquipmentItemData;

		// Token: 0x0400AECD RID: 44749
		private ItemData mTargetEquipmentItemData;

		// Token: 0x0400AECE RID: 44750
		private ItemData mConverterItemData;

		// Token: 0x0400AECF RID: 44751
		private bool bIsCheckConverter;

		// Token: 0x0400AED0 RID: 44752
		private ComItem mCurrentEquipmentComItem;

		// Token: 0x0400AED1 RID: 44753
		private ComItem mTargetEquipmentComItem;

		// Token: 0x0400AED2 RID: 44754
		private ComItem mConverterComItem;

		// Token: 0x0400AED3 RID: 44755
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x0400AED5 RID: 44757
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;

		// Token: 0x0400AED6 RID: 44758
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache2;
	}
}

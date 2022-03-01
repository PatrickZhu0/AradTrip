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
	// Token: 0x02001B11 RID: 6929
	public class SameSetOfEquipmentConversionView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x0601102E RID: 69678 RVA: 0x004DE328 File Offset: 0x004DC728
		private void Awake()
		{
			this.RegisterEventHandle();
			this.InitEquipmentComUIListScript();
			this.InitMaterailExpendItemComUIListScript();
			this.AddListener();
		}

		// Token: 0x0601102F RID: 69679 RVA: 0x004DE342 File Offset: 0x004DC742
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011030 RID: 69680 RVA: 0x004DE34C File Offset: 0x004DC74C
		private void ClearData()
		{
			this.UnRegisterEventHandle();
			this.UnInitEquipmentComUIListScript();
			this.UnInitMaterailExpendItemComUIListScript();
			this.RemoveListener();
			this.mAllEquipmentList.Clear();
			this.mMaterailExpendItems.Clear();
			this.mConverterItemDataList.Clear();
			this.bIsCheckConverter = false;
			this.mCurrentEquipmentItemData = null;
			this.mTargetEquipmentItemData = null;
			this.mConverterItemData = null;
			this.mCurrentEquipmentComItem = null;
			this.mTargetEquipmentComItem = null;
		}

		// Token: 0x06011031 RID: 69681 RVA: 0x004DE3BC File Offset: 0x004DC7BC
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.LoadAllEquipmemnt();
		}

		// Token: 0x06011032 RID: 69682 RVA: 0x004DE3C4 File Offset: 0x004DC7C4
		public void OnDisableView()
		{
			this.UnRegisterEventHandle();
		}

		// Token: 0x06011033 RID: 69683 RVA: 0x004DE3CC File Offset: 0x004DC7CC
		public void OnEnableView()
		{
			this.RegisterEventHandle();
			this.LoadAllEquipmemnt();
		}

		// Token: 0x06011034 RID: 69684 RVA: 0x004DE3DC File Offset: 0x004DC7DC
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

		// Token: 0x06011035 RID: 69685 RVA: 0x004DE4E0 File Offset: 0x004DC8E0
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

		// Token: 0x06011036 RID: 69686 RVA: 0x004DE5A4 File Offset: 0x004DC9A4
		private void OnTargetEquipmentBtnClick()
		{
			EpicEquipmentTransformationTargetDataModle epicEquipmentTransformationTargetDataModle = new EpicEquipmentTransformationTargetDataModle();
			epicEquipmentTransformationTargetDataModle.equipmentItem = this.mCurrentEquipmentItemData;
			epicEquipmentTransformationTargetDataModle.type = EpicEquipmentTransformationType.SetOfConversion;
			EpicEquipmentTransformationTargetDataModle epicEquipmentTransformationTargetDataModle2 = epicEquipmentTransformationTargetDataModle;
			epicEquipmentTransformationTargetDataModle2.onTargetEquipmentClick = (Action<ItemData>)Delegate.Combine(epicEquipmentTransformationTargetDataModle2.onTargetEquipmentClick, new Action<ItemData>(this.RefreshTargetEquipmentInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EpicTransformationTargetEquipmentFrame>(FrameLayer.Middle, epicEquipmentTransformationTargetDataModle, string.Empty);
		}

		// Token: 0x06011037 RID: 69687 RVA: 0x004DE600 File Offset: 0x004DCA00
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
				ItemComeLink.OnLink(310, 0, true, null, false, false, false, null, string.Empty);
				return;
			}
			EpicTransformationConverterDataModel epicTransformationConverterDataModel = new EpicTransformationConverterDataModel();
			epicTransformationConverterDataModel.converterList = this.mConverterItemDataList;
			EpicTransformationConverterDataModel epicTransformationConverterDataModel2 = epicTransformationConverterDataModel;
			epicTransformationConverterDataModel2.onConverterClick = (Action<ItemData>)Delegate.Combine(epicTransformationConverterDataModel2.onConverterClick, new Action<ItemData>(this.RefreshConverterItemInfo));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EpicTransformationConverterFrame>(FrameLayer.Middle, epicTransformationConverterDataModel, string.Empty);
		}

		// Token: 0x06011038 RID: 69688 RVA: 0x004DE784 File Offset: 0x004DCB84
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

		// Token: 0x06011039 RID: 69689 RVA: 0x004DE7C4 File Offset: 0x004DCBC4
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

		// Token: 0x0601103A RID: 69690 RVA: 0x004DEA24 File Offset: 0x004DCE24
		private void OnSceneEquipConvertReq()
		{
			string msgContent = string.Empty;
			if (this.mCurrentEquipmentItemData != null && this.mTargetEquipmentItemData != null)
			{
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
					ulong converterGuid = 0UL;
					if (this.mConverterItemData != null)
					{
						converterGuid = ((!this.bIsCheckConverter) ? 0UL : this.mConverterItemData.GUID);
					}
					DataManager<EpicEquipmentTransformationDataManager>.GetInstance().OnSceneEquipConvertReq(1, this.mCurrentEquipmentItemData.GUID, (uint)this.mTargetEquipmentItemData.TableID, converterGuid);
				}, null, 0f, false);
			}
		}

		// Token: 0x0601103B RID: 69691 RVA: 0x004DEAE0 File Offset: 0x004DCEE0
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

		// Token: 0x0601103C RID: 69692 RVA: 0x004DEB7C File Offset: 0x004DCF7C
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

		// Token: 0x0601103D RID: 69693 RVA: 0x004DEC16 File Offset: 0x004DD016
		private void OnEpicEquipmentConversionSuccessed(UIEvent uiEvent)
		{
			this.LoadAllEquipmemnt();
		}

		// Token: 0x0601103E RID: 69694 RVA: 0x004DEC20 File Offset: 0x004DD020
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

		// Token: 0x0601103F RID: 69695 RVA: 0x004DEC9D File Offset: 0x004DD09D
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if (eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD || eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_GOLD)
			{
				this.RefreshExpendMaterail();
			}
		}

		// Token: 0x06011040 RID: 69696 RVA: 0x004DECB4 File Offset: 0x004DD0B4
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
			if (SameSetOfEquipmentConversionView.<>f__mg$cache0 == null)
			{
				SameSetOfEquipmentConversionView.<>f__mg$cache0 = new Comparison<ItemData>(EquipmentConversionUtility.SoreEquipments);
			}
			list.Sort(SameSetOfEquipmentConversionView.<>f__mg$cache0);
			if (this.mEquipmentComUIList != null)
			{
				this.mEquipmentComUIList.SetElementAmount(this.mAllEquipmentList.Count);
			}
			if (this.mAllEquipmentList.Count <= 0)
			{
				this.mSelectedTargetEquipmentBtn.CustomActive(false);
			}
			this.TrySetDefaultEquipment();
		}

		// Token: 0x06011041 RID: 69697 RVA: 0x004DED74 File Offset: 0x004DD174
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
								if (item.SubType != 99)
								{
									if (DataManager<EpicEquipmentTransformationDataManager>.GetInstance().CheckEpicEquipmentCanbeDisplayedInTheEquipmentList(item))
									{
										this.mAllEquipmentList.Add(item);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06011042 RID: 69698 RVA: 0x004DEE1C File Offset: 0x004DD21C
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

		// Token: 0x06011043 RID: 69699 RVA: 0x004DEEE4 File Offset: 0x004DD2E4
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

		// Token: 0x06011044 RID: 69700 RVA: 0x004DEF68 File Offset: 0x004DD368
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

		// Token: 0x06011045 RID: 69701 RVA: 0x004DF030 File Offset: 0x004DD430
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

		// Token: 0x06011046 RID: 69702 RVA: 0x004DF0EA File Offset: 0x004DD4EA
		private EquipUpgradeItem OnBindItemDelegate(GameObject itemObjcet)
		{
			return itemObjcet.GetComponent<EquipUpgradeItem>();
		}

		// Token: 0x06011047 RID: 69703 RVA: 0x004DF0F4 File Offset: 0x004DD4F4
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null && item.m_index >= 0 && item.m_index < this.mAllEquipmentList.Count)
			{
				equipUpgradeItem.OnItemVisiable(this.mAllEquipmentList[item.m_index]);
			}
		}

		// Token: 0x06011048 RID: 69704 RVA: 0x004DF154 File Offset: 0x004DD554
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				EquipUpgradeItem.ms_selected = equipUpgradeItem.ItemData;
				this.OnEquipmentItemClick(equipUpgradeItem.ItemData);
			}
		}

		// Token: 0x06011049 RID: 69705 RVA: 0x004DF190 File Offset: 0x004DD590
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				equipUpgradeItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0601104A RID: 69706 RVA: 0x004DF1BC File Offset: 0x004DD5BC
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

		// Token: 0x0601104B RID: 69707 RVA: 0x004DF234 File Offset: 0x004DD634
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

		// Token: 0x0601104C RID: 69708 RVA: 0x004DF2A0 File Offset: 0x004DD6A0
		private EquipUpgradeCostItem OnMaterailExpendBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EquipUpgradeCostItem>();
		}

		// Token: 0x0601104D RID: 69709 RVA: 0x004DF2A8 File Offset: 0x004DD6A8
		private void OnMaterailExpendItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeCostItem equipUpgradeCostItem = item.gameObjectBindScript as EquipUpgradeCostItem;
			if (equipUpgradeCostItem != null && item.m_index >= 0 && item.m_index < this.mMaterailExpendItems.Count)
			{
				equipUpgradeCostItem.OnItemVisiable(this.mMaterailExpendItems[item.m_index]);
			}
		}

		// Token: 0x0601104E RID: 69710 RVA: 0x004DF306 File Offset: 0x004DD706
		public void OnSetMaterailExpendElementAmount()
		{
			if (this.mMaterailExpendItemComUIListScript != null)
			{
				this.mMaterailExpendItemComUIListScript.SetElementAmount(this.mMaterailExpendItems.Count);
			}
		}

		// Token: 0x0601104F RID: 69711 RVA: 0x004DF330 File Offset: 0x004DD730
		private void ClearInfo()
		{
			this.mConverterItemRoot.CustomActive(false);
			this.mConverterReplacePropTog.CustomActive(false);
			this.mTargetEquipmentItemParent.CustomActive(false);
			this.mConverterItemParent.CustomActive(false);
			this.mTargetEquipmentName.text = string.Empty;
			this.mConverterItemName.text = this.selectedConverterDes;
			this.mCurrentEquipmentItemData = null;
			this.mTargetEquipmentItemData = null;
			this.mConverterItemData = null;
			this.mMaterailExpendItemComUIListScript.SetElementAmount(0);
		}

		// Token: 0x06011050 RID: 69712 RVA: 0x004DF3AF File Offset: 0x004DD7AF
		private void OnEquipmentItemClick(ItemData itemData)
		{
			this.ClearInfo();
			this.RefreshCurrentEquipmentInfo(itemData);
		}

		// Token: 0x06011051 RID: 69713 RVA: 0x004DF3C0 File Offset: 0x004DD7C0
		private void RefreshCurrentEquipmentInfo(ItemData itemData)
		{
			this.mCurrentEquipmentItemData = itemData;
			if (this.mCurrentEquipmentItemData == null)
			{
				return;
			}
			if (this.mCurrentEquipmentComItem == null)
			{
				this.mCurrentEquipmentComItem = ComItemManager.Create(this.mCurrentEquipmentItemParent);
			}
			ComItem comItem = this.mCurrentEquipmentComItem;
			ItemData item = this.mCurrentEquipmentItemData;
			if (SameSetOfEquipmentConversionView.<>f__mg$cache1 == null)
			{
				SameSetOfEquipmentConversionView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, SameSetOfEquipmentConversionView.<>f__mg$cache1);
			if (this.mCurrentEquipmentName != null)
			{
				this.mCurrentEquipmentName.text = this.mCurrentEquipmentItemData.GetColorName(string.Empty, false);
			}
			this.mSelectedTargetEquipmentBtn.CustomActive(true);
		}

		// Token: 0x06011052 RID: 69714 RVA: 0x004DF46C File Offset: 0x004DD86C
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
			if (SameSetOfEquipmentConversionView.<>f__mg$cache2 == null)
			{
				SameSetOfEquipmentConversionView.<>f__mg$cache2 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, SameSetOfEquipmentConversionView.<>f__mg$cache2);
			if (this.mTargetEquipmentName != null)
			{
				this.mTargetEquipmentName.text = this.mTargetEquipmentItemData.GetColorName(string.Empty, false);
			}
			this.mMaterailExpendItems.Clear();
			this.mConverterItems.Clear();
			DataManager<EpicEquipmentTransformationDataManager>.GetInstance().GetConvertedTargetEquipmentMaterial(EpicEquipmentTransformationType.SetOfConversion, this.mTargetEquipmentItemData, ref this.mMaterailExpendItems, ref this.mConverterItems);
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

		// Token: 0x06011053 RID: 69715 RVA: 0x004DF6E8 File Offset: 0x004DDAE8
		private void RefreshExpendMaterail()
		{
			if (this.mMaterailExpendItemComUIListScript != null)
			{
				this.mMaterailExpendItemComUIListScript.SetElementAmount(this.mMaterailExpendItems.Count);
			}
		}

		// Token: 0x06011054 RID: 69716 RVA: 0x004DF714 File Offset: 0x004DDB14
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

		// Token: 0x0400AF15 RID: 44821
		[SerializeField]
		private ComUIListScript mEquipmentComUIList;

		// Token: 0x0400AF16 RID: 44822
		[SerializeField]
		private ComUIListScript mMaterailExpendItemComUIListScript;

		// Token: 0x0400AF17 RID: 44823
		[SerializeField]
		private GameObject mCurrentEquipmentItemParent;

		// Token: 0x0400AF18 RID: 44824
		[SerializeField]
		private GameObject mTargetEquipmentItemParent;

		// Token: 0x0400AF19 RID: 44825
		[SerializeField]
		private GameObject mConverterItemParent;

		// Token: 0x0400AF1A RID: 44826
		[SerializeField]
		private GameObject mMaterailExpendItemRoot;

		// Token: 0x0400AF1B RID: 44827
		[SerializeField]
		private GameObject mConverterItemRoot;

		// Token: 0x0400AF1C RID: 44828
		[SerializeField]
		private Text mCurrentEquipmentName;

		// Token: 0x0400AF1D RID: 44829
		[SerializeField]
		private Text mTargetEquipmentName;

		// Token: 0x0400AF1E RID: 44830
		[SerializeField]
		private Text mConverterItemName;

		// Token: 0x0400AF1F RID: 44831
		[SerializeField]
		private Text mConverterItemCount;

		// Token: 0x0400AF20 RID: 44832
		[SerializeField]
		private Image mConverterItemBackground;

		// Token: 0x0400AF21 RID: 44833
		[SerializeField]
		private Image mConverterItemIcon;

		// Token: 0x0400AF22 RID: 44834
		[SerializeField]
		private Button mSelectedTargetEquipmentBtn;

		// Token: 0x0400AF23 RID: 44835
		[SerializeField]
		private Button mConverterBtn;

		// Token: 0x0400AF24 RID: 44836
		[SerializeField]
		private Button mConversionBtn;

		// Token: 0x0400AF25 RID: 44837
		[SerializeField]
		private Toggle mConverterReplacePropTog;

		// Token: 0x0400AF26 RID: 44838
		private string selectedConverterDes = "选择转化器";

		// Token: 0x0400AF27 RID: 44839
		private List<ItemData> mAllEquipmentList = new List<ItemData>();

		// Token: 0x0400AF28 RID: 44840
		private List<ItemSimpleData> mMaterailExpendItems = new List<ItemSimpleData>();

		// Token: 0x0400AF29 RID: 44841
		private List<ItemData> mConverterItemDataList = new List<ItemData>();

		// Token: 0x0400AF2A RID: 44842
		private List<ItemSimpleData> mConverterItems = new List<ItemSimpleData>();

		// Token: 0x0400AF2B RID: 44843
		private ItemData mCurrentEquipmentItemData;

		// Token: 0x0400AF2C RID: 44844
		private ItemData mTargetEquipmentItemData;

		// Token: 0x0400AF2D RID: 44845
		private ItemData mConverterItemData;

		// Token: 0x0400AF2E RID: 44846
		private bool bIsCheckConverter;

		// Token: 0x0400AF2F RID: 44847
		private ComItem mCurrentEquipmentComItem;

		// Token: 0x0400AF30 RID: 44848
		private ComItem mTargetEquipmentComItem;

		// Token: 0x0400AF31 RID: 44849
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x0400AF33 RID: 44851
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;

		// Token: 0x0400AF34 RID: 44852
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache2;
	}
}

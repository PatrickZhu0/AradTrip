using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200124A RID: 4682
	public static class EquipPlanUtility
	{
		// Token: 0x0600B3DF RID: 46047 RVA: 0x00282B60 File Offset: 0x00280F60
		public static bool IsEquipPlanOpenedByServer()
		{
			return DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_EQUIP_SCHEME);
		}

		// Token: 0x0600B3E0 RID: 46048 RVA: 0x00282B7E File Offset: 0x00280F7E
		public static bool IsShowEquipPlanFunction()
		{
			return DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId > 0 && (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<EquipPlanDataManager>.GetInstance().GetEquipPlanUnLockLevel();
		}

		// Token: 0x0600B3E1 RID: 46049 RVA: 0x00282BB0 File Offset: 0x00280FB0
		public static void UpdateEquipPlanDataModel(EquipPlanDataModel equipPlanDataModel, EquipSchemeInfo equipSchemeInfo)
		{
			if (equipPlanDataModel == null || equipSchemeInfo == null)
			{
				return;
			}
			equipPlanDataModel.Guid = equipSchemeInfo.guid;
			equipPlanDataModel.EquipPlanType = (EquipSchemeType)equipSchemeInfo.type;
			equipPlanDataModel.EquipPlanId = equipSchemeInfo.id;
			equipPlanDataModel.IsWear = (equipSchemeInfo.weared == 1);
			equipPlanDataModel.EquipItemGuidList.Clear();
			if (equipSchemeInfo.equips != null && equipSchemeInfo.equips.Length > 0)
			{
				equipPlanDataModel.EquipItemGuidList = equipSchemeInfo.equips.ToList<ulong>();
			}
			if (equipPlanDataModel.EquipItemGuidList != null && equipPlanDataModel.EquipItemGuidList.Count > 0)
			{
				equipPlanDataModel.EquipItemGuidList.Sort();
			}
		}

		// Token: 0x0600B3E2 RID: 46050 RVA: 0x00282C64 File Offset: 0x00281064
		public static EquipPlanDataModel CreateEquipPlanDataModel(EquipSchemeInfo schemeInfo)
		{
			if (schemeInfo == null)
			{
				return null;
			}
			EquipPlanDataModel equipPlanDataModel = new EquipPlanDataModel();
			EquipPlanUtility.UpdateEquipPlanDataModel(equipPlanDataModel, schemeInfo);
			return equipPlanDataModel;
		}

		// Token: 0x0600B3E3 RID: 46051 RVA: 0x00282C88 File Offset: 0x00281088
		public static bool IsNeedShowUnUsedEquipPlanFlag(ItemData itemData, ref int equipPlanId)
		{
			if (itemData == null)
			{
				return false;
			}
			if (itemData.GUID == 0UL)
			{
				return false;
			}
			if (itemData.TableData == null)
			{
				return false;
			}
			bool isItemInUnUsedEquipPlan = itemData.IsItemInUnUsedEquipPlan;
			if (isItemInUnUsedEquipPlan)
			{
				equipPlanId = DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanId;
			}
			return isItemInUnUsedEquipPlan;
		}

		// Token: 0x0600B3E4 RID: 46052 RVA: 0x00282CD3 File Offset: 0x002810D3
		public static bool IsEquipPlanOwnerItemType(ItemTable itemTable)
		{
			return itemTable != null && (itemTable.Type != ItemTable.eType.EQUIP || itemTable.SubType != ItemTable.eSubType.WEAPON) && (itemTable.Type == ItemTable.eType.EQUIP || itemTable.SubType == ItemTable.eSubType.TITLE);
		}

		// Token: 0x0600B3E5 RID: 46053 RVA: 0x00282D14 File Offset: 0x00281114
		public static bool IsItemInUnUsedEquipPlanByItemData(ItemData itemData)
		{
			return itemData != null && itemData.GUID > 0UL && itemData.TableData != null && itemData.PackageType != EPackageType.WearEquip && EquipPlanUtility.IsEquipPlanOwnerItemType(itemData.TableData) && EquipPlanUtility.IsItemInUnUsedEquipPlanByItemGuid(itemData.GUID);
		}

		// Token: 0x0600B3E6 RID: 46054 RVA: 0x00282D74 File Offset: 0x00281174
		private static bool IsItemInUnUsedEquipPlanByItemGuid(ulong guid)
		{
			if (guid == 0UL)
			{
				return false;
			}
			if (!EquipPlanUtility.IsShowEquipPlanFunction())
			{
				return false;
			}
			List<ulong> unSelectedEquipPlanItemGuidList = DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanItemGuidList;
			return unSelectedEquipPlanItemGuidList != null && unSelectedEquipPlanItemGuidList.Count > 0 && CommonUtility.FindInListByBinarySearch(unSelectedEquipPlanItemGuidList, guid);
		}

		// Token: 0x0600B3E7 RID: 46055 RVA: 0x00282DC0 File Offset: 0x002811C0
		public static bool IsAllEquipInPackageByEquipPlanId(int equipPlanId)
		{
			List<ulong> equipItemGuidListByEquipPlanId = EquipPlanUtility.GetEquipItemGuidListByEquipPlanId(equipPlanId);
			if (equipItemGuidListByEquipPlanId == null || equipItemGuidListByEquipPlanId.Count <= 0)
			{
				return true;
			}
			for (int i = 0; i < equipItemGuidListByEquipPlanId.Count; i++)
			{
				ulong num = equipItemGuidListByEquipPlanId[i];
				if (num > 0UL)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item == null)
					{
						return false;
					}
					if (item.PackageType != EPackageType.WearEquip && item.PackageType != EPackageType.Equip && item.PackageType != EPackageType.Title)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600B3E8 RID: 46056 RVA: 0x00282E50 File Offset: 0x00281250
		public static List<ulong> GetEquipItemGuidListByEquipPlanId(int equipPlanId)
		{
			List<EquipPlanDataModel> equipPlanDataModelList = DataManager<EquipPlanDataManager>.GetInstance().EquipPlanDataModelList;
			if (equipPlanDataModelList == null || equipPlanDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < equipPlanDataModelList.Count; i++)
			{
				EquipPlanDataModel equipPlanDataModel = equipPlanDataModelList[i];
				if (equipPlanDataModel != null)
				{
					if ((ulong)equipPlanDataModel.EquipPlanId == (ulong)((long)equipPlanId))
					{
						return equipPlanDataModel.EquipItemGuidList;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B3E9 RID: 46057 RVA: 0x00282EBC File Offset: 0x002812BC
		public static void OnSwitchEquipPlanAction()
		{
			if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Equip_Plan_Is_Already_Closed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId == 1 && !DataManager<EquipPlanDataManager>.GetInstance().IsAlreadySwitchEquipPlan)
			{
				EquipPlanUtility.OpenSwitchEquipPlanTipFrameByFirstTime();
				return;
			}
			int switchToEquipPlanId = EquipPlanUtility.GetSwitchToEquipPlanId();
			bool isAllEquipItemInPackage = EquipPlanUtility.IsAllEquipInPackageByEquipPlanId(switchToEquipPlanId);
			EquipPlanUtility.OpenSwitchEquipPlanTipFrameByCommonState(DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId, switchToEquipPlanId, isAllEquipItemInPackage);
		}

		// Token: 0x0600B3EA RID: 46058 RVA: 0x00282F28 File Offset: 0x00281328
		private static void OpenSwitchEquipPlanTipFrameByFirstTime()
		{
			int currentSelectedEquipPlanId = DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId;
			int switchToEquipPlanId = EquipPlanUtility.GetSwitchToEquipPlanId();
			string equipPlanIdStr = EquipPlanUtility.GetEquipPlanIdStr(currentSelectedEquipPlanId);
			string equipPlanIdStr2 = EquipPlanUtility.GetEquipPlanIdStr(switchToEquipPlanId);
			string contentLabel = TR.Value("Equip_Plan_First_Use_Plan_Two_Content", equipPlanIdStr2, equipPlanIdStr);
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = false,
				LeftButtonText = TR.Value("Equip_Plan_Not_Sync_Text"),
				RightButtonText = TR.Value("Equip_Plan_Sync_Text"),
				OnLeftButtonClickCallBack = new Action(DataManager<EquipPlanDataManager>.GetInstance().OnSwitchEquipPlanByCommonAction),
				OnRightButtonClickCallBack = new Action(DataManager<EquipPlanDataManager>.GetInstance().OnSwitchEquipPlanWithSyncFirstEquipPlan)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B3EB RID: 46059 RVA: 0x00282FD8 File Offset: 0x002813D8
		private static void OpenSwitchEquipPlanTipFrameByCommonState(int currentEquipPlanId, int switchToEquipPlanId, bool isAllEquipItemInPackage)
		{
			string contentLabel = string.Empty;
			string equipPlanIdStr = EquipPlanUtility.GetEquipPlanIdStr(currentEquipPlanId);
			string equipPlanIdStr2 = EquipPlanUtility.GetEquipPlanIdStr(switchToEquipPlanId);
			if (!isAllEquipItemInPackage)
			{
				contentLabel = TR.Value("Equip_Plan_Change_Equip_Plan_WithSpecial_Item_Content", equipPlanIdStr, equipPlanIdStr2, equipPlanIdStr2);
			}
			else
			{
				contentLabel = TR.Value("Equip_Plan_Change_Equip_Plan_Common_Content", equipPlanIdStr, equipPlanIdStr2);
			}
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure_2"),
				OnRightButtonClickCallBack = new Action(DataManager<EquipPlanDataManager>.GetInstance().OnSwitchEquipPlanByCommonAction)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B3EC RID: 46060 RVA: 0x00283078 File Offset: 0x00281478
		public static string GetEquipPlanIdStr(int equipPlanId)
		{
			if (equipPlanId == 2)
			{
				return TR.Value("Equip_Plan_Format_Two_Text");
			}
			return TR.Value("Equip_Plan_Format_One_Text");
		}

		// Token: 0x0600B3ED RID: 46061 RVA: 0x00283096 File Offset: 0x00281496
		public static int GetSwitchToEquipPlanId()
		{
			if (DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId == 1)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x0600B3EE RID: 46062 RVA: 0x002830AC File Offset: 0x002814AC
		public static List<ulong> OnlyGetEquipItemGuidListInEquipPlanByEquipPlanId(int equipPlanId)
		{
			if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
			{
				return null;
			}
			List<ulong> equipItemGuidListByEquipPlanId = EquipPlanUtility.GetEquipItemGuidListByEquipPlanId(equipPlanId);
			if (equipItemGuidListByEquipPlanId == null || equipItemGuidListByEquipPlanId.Count <= 0)
			{
				return null;
			}
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < equipItemGuidListByEquipPlanId.Count; i++)
			{
				ulong num = equipItemGuidListByEquipPlanId[i];
				if (num > 0UL)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null)
					{
						if (item.TableData != null)
						{
							if (item.TableData.SubType != ItemTable.eSubType.TITLE)
							{
								list.Add(num);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B3EF RID: 46063 RVA: 0x0028315C File Offset: 0x0028155C
		public static ulong OnlyGetTitleItemGuidInEquipPlanByEquipPlanId(int equipPlanId)
		{
			if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
			{
				return 0UL;
			}
			List<ulong> equipItemGuidListByEquipPlanId = EquipPlanUtility.GetEquipItemGuidListByEquipPlanId(equipPlanId);
			if (equipItemGuidListByEquipPlanId == null || equipItemGuidListByEquipPlanId.Count <= 0)
			{
				return 0UL;
			}
			for (int i = 0; i < equipItemGuidListByEquipPlanId.Count; i++)
			{
				ulong num = equipItemGuidListByEquipPlanId[i];
				if (num > 0UL)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null)
					{
						if (item.TableData != null)
						{
							if (item.TableData.SubType == ItemTable.eSubType.TITLE)
							{
								return num;
							}
						}
					}
				}
			}
			return 0UL;
		}

		// Token: 0x0600B3F0 RID: 46064 RVA: 0x002831FC File Offset: 0x002815FC
		public static bool IsEquipPlanOwnerDifferentItem()
		{
			List<ulong> unSelectedEquipPlanItemGuidList = DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanItemGuidList;
			List<ulong> currentSelectedEquipPlanItemGuidList = DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanItemGuidList;
			if (unSelectedEquipPlanItemGuidList == null || unSelectedEquipPlanItemGuidList.Count <= 0)
			{
				return currentSelectedEquipPlanItemGuidList != null && currentSelectedEquipPlanItemGuidList.Count > 0;
			}
			if (currentSelectedEquipPlanItemGuidList == null || currentSelectedEquipPlanItemGuidList.Count <= 0)
			{
				return true;
			}
			int count = unSelectedEquipPlanItemGuidList.Count;
			int count2 = currentSelectedEquipPlanItemGuidList.Count;
			if (count == 0 && count2 == 0)
			{
				return false;
			}
			if ((count == 0 && count2 != 0) || (count != 0 && count2 == 0))
			{
				return true;
			}
			if (count != count2)
			{
				return true;
			}
			bool result = false;
			for (int i = 0; i < count; i++)
			{
				if (i >= count2)
				{
					break;
				}
				if (unSelectedEquipPlanItemGuidList[i] != currentSelectedEquipPlanItemGuidList[i])
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600B3F1 RID: 46065 RVA: 0x002832E1 File Offset: 0x002816E1
		public static List<ulong> GetUnSelectedEquipPlanItemGuidList()
		{
			if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
			{
				return null;
			}
			return DataManager<EquipPlanDataManager>.GetInstance().UnSelectedEquipPlanItemGuidList;
		}
	}
}

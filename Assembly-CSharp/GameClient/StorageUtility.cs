using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012F5 RID: 4853
	public static class StorageUtility
	{
		// Token: 0x0600BC40 RID: 48192 RVA: 0x002BE38C File Offset: 0x002BC78C
		public static void OnOpenStorageUnLockTipFrame(StorageUnLockCostDataModel storageUnLockCostDataModel)
		{
			int costItemId = storageUnLockCostDataModel.CostItemId;
			int costItemNumber = storageUnLockCostDataModel.CostItemNumber;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(costItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string tipContent = TR.Value("storage_unlock_cost_format", costItemNumber, tableItem.Name);
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo
			{
				nMoneyID = costItemId,
				nCount = costItemNumber
			};
			CommonUtility.OnShowCommonMsgBox(tipContent, delegate
			{
				StorageUtility.OnCheckMoneyIsEnough(costInfo);
			}, TR.Value("common_data_sure_2"));
		}

		// Token: 0x0600BC41 RID: 48193 RVA: 0x002BE41E File Offset: 0x002BC81E
		public static void OnCheckMoneyIsEnough(CostItemManager.CostInfo costInfo)
		{
			if (costInfo == null)
			{
				return;
			}
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				DataManager<StorageDataManager>.GetInstance().OnSendSceneUnlockRoleStorageReq();
			}, "common_money_cost", null);
		}

		// Token: 0x0600BC42 RID: 48194 RVA: 0x002BE458 File Offset: 0x002BC858
		public static StorageUnLockCostDataModel GetStorageUnLockCostDataModel(int totalOwnerNumber)
		{
			int num = totalOwnerNumber + 1;
			if (num > 9)
			{
				return null;
			}
			SystemValueTable.eType3 id = SystemValueTable.eType3.SVT_WAREHOUSE_2_COSTITEMID;
			SystemValueTable.eType3 id2 = SystemValueTable.eType3.SVT_WAREHOUSE_2_COSTNUM;
			if (num == 2)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_2_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_2_COSTNUM;
			}
			else if (num == 3)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_3_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_3_COSTNUM;
			}
			else if (num == 4)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_4_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_4_COSTNUM;
			}
			else if (num == 5)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_5_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_5_COSTNUM;
			}
			else if (num == 6)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_6_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_6_COSTNUM;
			}
			else if (num == 7)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_7_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_7_COSTNUM;
			}
			else if (num == 8)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_8_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_8_COSTNUM;
			}
			else if (num == 9)
			{
				id = SystemValueTable.eType3.SVT_WAREHOUSE_9_COSTITEMID;
				id2 = SystemValueTable.eType3.SVT_WAREHOUSE_9_COSTNUM;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>((int)id, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>((int)id2, string.Empty, string.Empty);
			if (tableItem == null || tableItem2 == null)
			{
				return null;
			}
			return new StorageUnLockCostDataModel
			{
				CostItemId = tableItem.Value,
				CostItemNumber = tableItem2.Value
			};
		}

		// Token: 0x0600BC43 RID: 48195 RVA: 0x002BE5A0 File Offset: 0x002BC9A0
		public static string GetRoleStorageNameByStorageIndex(int index)
		{
			string roleStorageSetNameByRoleStorageIndex = DataManager<StorageDataManager>.GetInstance().GetRoleStorageSetNameByRoleStorageIndex(index);
			if (!string.IsNullOrEmpty(roleStorageSetNameByRoleStorageIndex))
			{
				return roleStorageSetNameByRoleStorageIndex;
			}
			return StorageUtility.GetRoleStorageDefaultNameByStorageIndex(index);
		}

		// Token: 0x0600BC44 RID: 48196 RVA: 0x002BE5D0 File Offset: 0x002BC9D0
		public static string GetRoleStorageDefaultNameByStorageIndex(int index)
		{
			if (index == 1)
			{
				return TR.Value("storage_free_store");
			}
			return TR.Value("storage_store_format", index);
		}

		// Token: 0x0600BC45 RID: 48197 RVA: 0x002BE604 File Offset: 0x002BCA04
		public static string GetEnlargeStorageSizeCostDesc(CostItemManager.CostInfo costInfo)
		{
			string costMoneiesDesc = DataManager<CostItemManager>.GetInstance().GetCostMoneiesDesc(new CostItemManager.CostInfo[]
			{
				costInfo
			});
			if (!string.IsNullOrEmpty(costMoneiesDesc))
			{
				return TR.Value("storage_unlock_grids", costMoneiesDesc);
			}
			return string.Empty;
		}

		// Token: 0x0600BC46 RID: 48198 RVA: 0x002BE644 File Offset: 0x002BCA44
		private static List<ulong> GetRoleStorageItemGuidListByStorageIndex(int storageIndex)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.RoleStorage);
			List<ulong> list = new List<ulong>();
			int num = storageIndex;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > 9)
			{
				num = 9;
			}
			int roleStorageItemGridMinGridIndex = StorageUtility.GetRoleStorageItemGridMinGridIndex(num);
			int roleStorageItemGridMaxGridIndex = StorageUtility.GetRoleStorageItemGridMaxGridIndex(num);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong num2 = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num2);
				if (item != null)
				{
					if (item.GridIndex >= roleStorageItemGridMinGridIndex)
					{
						if (item.GridIndex <= roleStorageItemGridMaxGridIndex)
						{
							list.Add(num2);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BC47 RID: 48199 RVA: 0x002BE6FC File Offset: 0x002BCAFC
		public static List<StorageItemDataModel> GetStorageItemDataModelList(StorageType storageType, int storageIndex = 0)
		{
			List<StorageItemDataModel> list = new List<StorageItemDataModel>();
			int num = 0;
			List<ulong> list2 = null;
			if (storageType == StorageType.AccountStorage)
			{
				num = DataManager<PlayerBaseData>.GetInstance().AccountStorageSize;
				list2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Storage);
			}
			else if (storageType == StorageType.RoleStorage)
			{
				num = DataManager<PlayerBaseData>.GetInstance().RoleStorageSize;
				list2 = StorageUtility.GetRoleStorageItemGuidListByStorageIndex(storageIndex);
			}
			for (int i = 0; i < num; i++)
			{
				StorageItemDataModel storageItemDataModel = new StorageItemDataModel();
				list.Add(storageItemDataModel);
				if (list2 != null)
				{
					if (list2.Count > 0)
					{
						if (i >= 0 && i < list2.Count)
						{
							ulong itemGuid = list2[i];
							storageItemDataModel.ItemGuid = itemGuid;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BC48 RID: 48200 RVA: 0x002BE7B1 File Offset: 0x002BCBB1
		public static int GetNeedShowItemNumber(int totalNumber)
		{
			if (totalNumber < 3)
			{
				return 3;
			}
			if (totalNumber < 6)
			{
				return 6;
			}
			return 9;
		}

		// Token: 0x0600BC49 RID: 48201 RVA: 0x002BE7C7 File Offset: 0x002BCBC7
		public static int GetNeedShowLineNumber(int totalNumber)
		{
			if (totalNumber < 3)
			{
				return 1;
			}
			if (totalNumber < 6)
			{
				return 2;
			}
			return 3;
		}

		// Token: 0x0600BC4A RID: 48202 RVA: 0x002BE7DC File Offset: 0x002BCBDC
		public static int GetStorageItemCount(int tableId, EPackageType packageType)
		{
			if (packageType != EPackageType.Storage && packageType != EPackageType.RoleStorage)
			{
				return 0;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(packageType);
			if (itemsByPackageType == null || itemsByPackageType.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong id = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item != null)
				{
					if (item.TableID == tableId)
					{
						num += item.Count;
					}
				}
			}
			return num;
		}

		// Token: 0x0600BC4B RID: 48203 RVA: 0x002BE874 File Offset: 0x002BCC74
		public static int GetRoleStorageItemGridMinGridIndex(int pageIndex)
		{
			return (pageIndex - 1) * 30;
		}

		// Token: 0x0600BC4C RID: 48204 RVA: 0x002BE88C File Offset: 0x002BCC8C
		public static int GetRoleStorageItemGridMaxGridIndex(int pageIndex)
		{
			return pageIndex * 30 - 1;
		}

		// Token: 0x0600BC4D RID: 48205 RVA: 0x002BE8A4 File Offset: 0x002BCCA4
		public static void ResortRoleStorageItemGuidByGridIndex(int minGridIndex, int maxGridIndex)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.RoleStorage);
			if (itemsByPackageType == null || itemsByPackageType.Count <= 1)
			{
				return;
			}
			List<ulong> list = new List<ulong>();
			List<ulong> list2 = new List<ulong>();
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong num = itemsByPackageType[i];
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
				if (item != null)
				{
					if (item.GridIndex < minGridIndex || item.GridIndex > maxGridIndex)
					{
						list.Add(num);
					}
					else
					{
						list2.Add(num);
					}
				}
			}
			ItemDataUtility.ArrangeItemGuidList(list2);
			list.AddRange(list2);
			DataManager<ItemDataManager>.GetInstance().UpdateItemGuidListByPackageType(EPackageType.RoleStorage, list);
		}
	}
}

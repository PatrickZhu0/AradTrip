using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011E5 RID: 4581
	public class AuctionDataManager : DataManager<AuctionDataManager>
	{
		// Token: 0x0600B04E RID: 45134 RVA: 0x0026BF62 File Offset: 0x0026A362
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x17001AC0 RID: 6848
		// (get) Token: 0x0600B04F RID: 45135 RVA: 0x0026BF66 File Offset: 0x0026A366
		// (set) Token: 0x0600B050 RID: 45136 RVA: 0x0026BF6E File Offset: 0x0026A36E
		public bool BIsUpdateCurPage
		{
			get
			{
				return this.m_bIsUpdateCurPage;
			}
			set
			{
				this.m_bIsUpdateCurPage = value;
			}
		}

		// Token: 0x0600B051 RID: 45137 RVA: 0x0026BF77 File Offset: 0x0026A377
		public override void Initialize()
		{
			this.m_bIsUpdateCurPage = false;
			this.Clear();
			NetProcess.AddMsgHandler(503905U, new Action<MsgDATA>(this.SceneNotifyAbnormalTransactionRet));
			NetProcess.AddMsgHandler(503907U, new Action<MsgDATA>(this.SceneAbnormalTransactionRecordRet));
		}

		// Token: 0x0600B052 RID: 45138 RVA: 0x0026BFB2 File Offset: 0x0026A3B2
		public override void Clear()
		{
			this.m_bIsUpdateCurPage = false;
			NetProcess.RemoveMsgHandler(503905U, new Action<MsgDATA>(this.SceneNotifyAbnormalTransactionRet));
			NetProcess.RemoveMsgHandler(503907U, new Action<MsgDATA>(this.SceneAbnormalTransactionRecordRet));
		}

		// Token: 0x0600B053 RID: 45139 RVA: 0x0026BFE7 File Offset: 0x0026A3E7
		public ItemTable.eType GetItemTableTypeByAuctionType(AuctionMainItemType eBaseType)
		{
			if (eBaseType == AuctionMainItemType.AMIT_COST)
			{
				return ItemTable.eType.EXPENDABLE;
			}
			if (eBaseType == AuctionMainItemType.AMIT_MATERIAL)
			{
				return ItemTable.eType.MATERIAL;
			}
			return ItemTable.eType.EQUIP;
		}

		// Token: 0x0600B054 RID: 45140 RVA: 0x0026BFFC File Offset: 0x0026A3FC
		public List<ItemTable.eSubType> GetItemTableSubType(AuctionMainItemType eBaseType, int iFirstMenuIndex, int iSecMenuIndex, AuctionClassify.eJob JobType, ref ItemTable.eThirdType eItemThirdType)
		{
			List<int> list = null;
			if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				list = Singleton<TableManager>.GetInstance().GetAuctionWeaponList(JobType);
			}
			else if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
			{
				list = Singleton<TableManager>.GetInstance().GetAuctionDefenceList();
			}
			else if (eBaseType == AuctionMainItemType.AMIT_JEWELRY)
			{
				list = Singleton<TableManager>.GetInstance().GetAuctionJewelryList();
			}
			else if (eBaseType == AuctionMainItemType.AMIT_COST)
			{
				list = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			}
			else if (eBaseType == AuctionMainItemType.AMIT_MATERIAL)
			{
				list = Singleton<TableManager>.GetInstance().GetAuctionMaterialsList();
			}
			if (list == null || list.Count <= 0 || iFirstMenuIndex < 0 || iFirstMenuIndex > list.Count)
			{
				return null;
			}
			List<ItemTable.eSubType> list2 = new List<ItemTable.eSubType>();
			if (iFirstMenuIndex == 0 && eBaseType != AuctionMainItemType.AMIT_WEAPON)
			{
				if (eBaseType == AuctionMainItemType.AMIT_MATERIAL)
				{
					AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[iFirstMenuIndex], string.Empty, string.Empty);
					if (tableItem == null)
					{
						return null;
					}
					list2.Add((ItemTable.eSubType)tableItem.SubType);
				}
				else if (eBaseType == AuctionMainItemType.AMIT_COST)
				{
					for (int i = 1; i < list.Count; i++)
					{
						AuctionClassify tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[i], string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							if (tableItem2.ChildrenIDs[0] != 0)
							{
								for (int j = 0; j < tableItem2.ChildrenIDs.Count - 1; j++)
								{
									AuctionClassify tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(tableItem2.ChildrenIDs[j + 1], string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										list2.Add((ItemTable.eSubType)tableItem3.SubType);
									}
								}
							}
							else
							{
								list2.Add((ItemTable.eSubType)tableItem2.SubType);
							}
						}
					}
				}
				else if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
				{
					for (int k = 0; k < list.Count; k++)
					{
						AuctionClassify tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[k], string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							list2.Add((ItemTable.eSubType)tableItem4.SubType);
						}
					}
				}
				else
				{
					for (int l = 1; l < list.Count; l++)
					{
						AuctionClassify tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[l], string.Empty, string.Empty);
						if (tableItem5 != null)
						{
							list2.Add((ItemTable.eSubType)tableItem5.SubType);
						}
					}
				}
			}
			else if (DataManager<AuctionDataManager>.GetInstance().BConsumableIsHasSecendTab(iFirstMenuIndex) && eBaseType == AuctionMainItemType.AMIT_COST)
			{
				AuctionClassify tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[iFirstMenuIndex], string.Empty, string.Empty);
				if (tableItem6 == null)
				{
					return null;
				}
				if (iSecMenuIndex > 0)
				{
					AuctionClassify tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(tableItem6.ChildrenIDs[iSecMenuIndex], string.Empty, string.Empty);
					if (tableItem7 == null)
					{
						return null;
					}
					list2.Add((ItemTable.eSubType)tableItem7.SubType);
				}
				else
				{
					for (int m = 0; m < tableItem6.ChildrenIDs.Count - 1; m++)
					{
						AuctionClassify tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(tableItem6.ChildrenIDs[m + 1], string.Empty, string.Empty);
						if (tableItem8 != null)
						{
							list2.Add((ItemTable.eSubType)tableItem8.SubType);
						}
					}
				}
			}
			else if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
			{
				if (iSecMenuIndex > 0)
				{
					AuctionClassify tableItem9 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[iSecMenuIndex], string.Empty, string.Empty);
					if (tableItem9 == null)
					{
						return null;
					}
					list2.Add((ItemTable.eSubType)tableItem9.SubType);
				}
				else
				{
					for (int n = 0; n < list.Count; n++)
					{
						AuctionClassify tableItem10 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[n], string.Empty, string.Empty);
						if (tableItem10 != null)
						{
							list2.Add((ItemTable.eSubType)tableItem10.SubType);
						}
					}
				}
				List<int> auctionArmorList = Singleton<TableManager>.GetInstance().GetAuctionArmorList();
				if (auctionArmorList == null || auctionArmorList.Count <= 0 || iFirstMenuIndex < 0 || iFirstMenuIndex > auctionArmorList.Count)
				{
					return null;
				}
				AuctionClassify tableItem11 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionArmorList[iFirstMenuIndex], string.Empty, string.Empty);
				if (tableItem11 == null)
				{
					return null;
				}
				eItemThirdType = (ItemTable.eThirdType)tableItem11.ThirdType;
			}
			else
			{
				int index = iFirstMenuIndex;
				if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
				{
					index = iSecMenuIndex;
				}
				AuctionClassify tableItem12 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[index], string.Empty, string.Empty);
				if (tableItem12 == null)
				{
					return null;
				}
				list2.Add((ItemTable.eSubType)tableItem12.SubType);
				if (iSecMenuIndex > 0)
				{
					int index2 = iSecMenuIndex;
					if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
					{
						index2 = 0;
					}
					eItemThirdType = (ItemTable.eThirdType)tableItem12.ChildrenIDs[index2];
				}
			}
			return list2;
		}

		// Token: 0x0600B055 RID: 45141 RVA: 0x0026C4D8 File Offset: 0x0026A8D8
		public AuctionMainItemType GetBaseTypeByTableID(int TypeID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(TypeID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("物品表找不到 ID = {0}", new object[]
				{
					TypeID
				});
				return AuctionMainItemType.AMIT_INVALID;
			}
			if (tableItem.SubType == ItemTable.eSubType.WEAPON)
			{
				return AuctionMainItemType.AMIT_WEAPON;
			}
			if (tableItem.SubType == ItemTable.eSubType.HEAD || tableItem.SubType == ItemTable.eSubType.CHEST || tableItem.SubType == ItemTable.eSubType.BELT || tableItem.SubType == ItemTable.eSubType.LEG || tableItem.SubType == ItemTable.eSubType.BOOT)
			{
				return AuctionMainItemType.AMIT_ARMOR;
			}
			if (tableItem.SubType == ItemTable.eSubType.RING || tableItem.SubType == ItemTable.eSubType.NECKLASE || tableItem.SubType == ItemTable.eSubType.BRACELET || tableItem.SubType == ItemTable.eSubType.TITLE)
			{
				return AuctionMainItemType.AMIT_JEWELRY;
			}
			if (tableItem.Type == ItemTable.eType.EXPENDABLE)
			{
				return AuctionMainItemType.AMIT_COST;
			}
			if (tableItem.Type == ItemTable.eType.MATERIAL)
			{
				return AuctionMainItemType.AMIT_MATERIAL;
			}
			return AuctionMainItemType.AMIT_INVALID;
		}

		// Token: 0x0600B056 RID: 45142 RVA: 0x0026C5BC File Offset: 0x0026A9BC
		public string GetAuctionSubTypeName(AuctionMainItemType eBaseType, int SubTypeIndex, AuctionClassify.eJob Job = AuctionClassify.eJob.AC_JOB_ALL)
		{
			if (SubTypeIndex < 0)
			{
				return "-";
			}
			if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				return this.GetStrOfAuctionWeaponType(Job, SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
			{
				return this.GetStrOfAuctionArmorType(SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_JEWELRY)
			{
				return this.GetStrOfAuctionJewelryType(SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_COST)
			{
				return this.GetStrOfAuctionConsumablesType(SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_MATERIAL)
			{
				return this.GetStrOfAuctionMaterialsType(SubTypeIndex);
			}
			return "-";
		}

		// Token: 0x0600B057 RID: 45143 RVA: 0x0026C628 File Offset: 0x0026AA28
		public bool IsSelAuctionSum(AuctionMainItemType eBaseType, int iIndex, AuctionClassify.eJob CurSelJobType = AuctionClassify.eJob.AC_JOB_ALL)
		{
			if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				if (CurSelJobType == AuctionClassify.eJob.AC_JIANSHI)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionJianshiWeaponSum(iIndex);
				}
				if (CurSelJobType == AuctionClassify.eJob.AC_QIANGSHOU)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionQiangshouWeaponSum(iIndex);
				}
				if (CurSelJobType == AuctionClassify.eJob.AC_FASHI)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionFashiWeaponSum(iIndex);
				}
				return CurSelJobType == AuctionClassify.eJob.AC_GEDOU && Singleton<TableManager>.GetInstance().IsAuctionGeDouJiaWeaponSum(iIndex);
			}
			else
			{
				if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionDefenceSum(iIndex);
				}
				if (eBaseType == AuctionMainItemType.AMIT_JEWELRY)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionJewelrySum(iIndex);
				}
				if (eBaseType == AuctionMainItemType.AMIT_COST)
				{
					return Singleton<TableManager>.GetInstance().IsAuctionConsumablesSum(iIndex);
				}
				return eBaseType == AuctionMainItemType.AMIT_MATERIAL && Singleton<TableManager>.GetInstance().IsAuctionMaterialsSum(iIndex);
			}
		}

		// Token: 0x0600B058 RID: 45144 RVA: 0x0026C6D8 File Offset: 0x0026AAD8
		public int GetItemTableType(AuctionMainItemType eBaseType, int SubTypeIndex, AuctionClassify.eJob Job = AuctionClassify.eJob.AC_JOB_ALL, int eArmorTypeIndex = -1)
		{
			if (SubTypeIndex < 0)
			{
				return -1;
			}
			if (eBaseType == AuctionMainItemType.AMIT_WEAPON)
			{
				return this.SwitchWeaponSubType(Job, SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_ARMOR)
			{
				return this.SwitchDefenceSubType(SubTypeIndex, eArmorTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_JEWELRY)
			{
				return this.SwitchJewelrySubType(SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_COST)
			{
				return this.SwitchConsumablesSubType(SubTypeIndex);
			}
			if (eBaseType == AuctionMainItemType.AMIT_MATERIAL)
			{
				return this.SwitchMaterialsSubType(SubTypeIndex);
			}
			return -1;
		}

		// Token: 0x0600B059 RID: 45145 RVA: 0x0026C740 File Offset: 0x0026AB40
		public int GetConditionNumByLimitType(AuctionSearchLimitType eType)
		{
			if (eType == AuctionSearchLimitType.ItemTypeLimit)
			{
				return 5;
			}
			if (eType == AuctionSearchLimitType.JobTypeLimit)
			{
				return 4;
			}
			if (eType == AuctionSearchLimitType.ArmorTypeLimit)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionDefenceList().Count - 1;
			}
			if (eType == AuctionSearchLimitType.ItemLevelLimit)
			{
				return 12;
			}
			if (eType == AuctionSearchLimitType.StrengthLevelLimit)
			{
				return 6;
			}
			if (eType == AuctionSearchLimitType.QualityTypeLimit)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionQualityList().Count - 1;
			}
			return 0;
		}

		// Token: 0x0600B05A RID: 45146 RVA: 0x0026C7A4 File Offset: 0x0026ABA4
		public int GetSubTypeNumByMainType(AuctionMainItemType eMainType)
		{
			if (eMainType == AuctionMainItemType.AMIT_WEAPON)
			{
				return AuctionDataManager.GetMaxWeaponNumOfDiffBaseJob();
			}
			if (eMainType == AuctionMainItemType.AMIT_ARMOR)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionArmorList().Count;
			}
			if (eMainType == AuctionMainItemType.AMIT_JEWELRY)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionJewelryList().Count;
			}
			if (eMainType == AuctionMainItemType.AMIT_COST)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionConsumablesList().Count;
			}
			if (eMainType == AuctionMainItemType.AMIT_MATERIAL)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionMaterialsList().Count;
			}
			return 0;
		}

		// Token: 0x0600B05B RID: 45147 RVA: 0x0026C81C File Offset: 0x0026AC1C
		public int GetWeaponSubTypeNumOfDiffJob(AuctionClassify.eJob JobType)
		{
			if (JobType == AuctionClassify.eJob.AC_JIANSHI)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_JIANSHI).Count;
			}
			if (JobType == AuctionClassify.eJob.AC_QIANGSHOU)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_QIANGSHOU).Count;
			}
			if (JobType == AuctionClassify.eJob.AC_FASHI)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_FASHI).Count;
			}
			if (JobType == AuctionClassify.eJob.AC_GEDOU)
			{
				return Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_GEDOU).Count;
			}
			return 0;
		}

		// Token: 0x0600B05C RID: 45148 RVA: 0x0026C88C File Offset: 0x0026AC8C
		public ulong GetBasePriceByItemData(ItemData itemData)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0UL;
			}
			return this.GetBasePrice((ulong)((long)tableItem.RecommendPrice), this.GetEquipStrengthLvAdditionalPriceRate(itemData.StrengthenLevel));
		}

		// Token: 0x0600B05D RID: 45149 RVA: 0x0026C8D6 File Offset: 0x0026ACD6
		public ulong GetBasePrice(ulong iRecommondprice, int iStrengthRate)
		{
			return (ulong)(iRecommondprice * (ulong)((long)(100 + iStrengthRate)) / 100f);
		}

		// Token: 0x0600B05E RID: 45150 RVA: 0x0026C8E8 File Offset: 0x0026ACE8
		public int GetItemNumByGUID(ulong uGUID, bool bCheckAuctionCanSell = false)
		{
			int num = 0;
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				return num;
			}
			foreach (ulong id in allPackageItems.Keys)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item != null)
				{
					if (!bCheckAuctionCanSell || item.IsItemInAuctionPackage())
					{
						if (item.GUID == uGUID)
						{
							num += item.Count;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600B05F RID: 45151 RVA: 0x0026C9A0 File Offset: 0x0026ADA0
		public int GetEquipStrengthLvAdditionalPriceRate(int iStrengthLv)
		{
			if (iStrengthLv < 10)
			{
				return 0;
			}
			if (iStrengthLv == 10)
			{
				return 10;
			}
			if (iStrengthLv == 11)
			{
				return 30;
			}
			if (iStrengthLv == 12)
			{
				return 60;
			}
			if (iStrengthLv == 13)
			{
				return 100;
			}
			if (iStrengthLv == 14)
			{
				return 150;
			}
			if (iStrengthLv == 15)
			{
				return 200;
			}
			if (iStrengthLv == 16)
			{
				return 300;
			}
			if (iStrengthLv == 17)
			{
				return 400;
			}
			if (iStrengthLv == 18)
			{
				return 500;
			}
			if (iStrengthLv == 19)
			{
				return 600;
			}
			if (iStrengthLv == 20)
			{
				return 700;
			}
			return 800;
		}

		// Token: 0x0600B060 RID: 45152 RVA: 0x0026CA4C File Offset: 0x0026AE4C
		public static int GetMaxWeaponNumOfDiffBaseJob()
		{
			int num = 0;
			List<int> list = new List<int>();
			list.Add(Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_JIANSHI).Count);
			list.Add(Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_QIANGSHOU).Count);
			list.Add(Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_FASHI).Count);
			list.Add(Singleton<TableManager>.GetInstance().GetAuctionWeaponList(AuctionClassify.eJob.AC_GEDOU).Count);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] > num)
				{
					num = list[i];
				}
			}
			return num;
		}

		// Token: 0x0600B061 RID: 45153 RVA: 0x0026CAE8 File Offset: 0x0026AEE8
		public int SwichConsumablesDrugType(int iFirstIndex, int iSecendIndex)
		{
			int num = 1000;
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iFirstIndex < 0 || iFirstIndex >= auctionConsumablesList.Count)
			{
				return 0;
			}
			IList<int> list = null;
			if (auctionConsumablesList != null)
			{
				AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iFirstIndex], string.Empty, string.Empty);
				if (tableItem != null)
				{
					list = tableItem.ChildrenIDs;
				}
			}
			if (list == null || list.Count <= 0 || iSecendIndex < 0 || iSecendIndex >= list.Count)
			{
				return 0;
			}
			AuctionClassify tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[iSecendIndex], string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			return (int)(tableItem2.SubType * (AuctionClassify.eSubType)num + (int)tableItem2.ThirdType);
		}

		// Token: 0x0600B062 RID: 45154 RVA: 0x0026CBBC File Offset: 0x0026AFBC
		public bool BConsumableIsHasSecendTab(int iIndex)
		{
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iIndex < 0 || iIndex >= auctionConsumablesList.Count)
			{
				return false;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iIndex], string.Empty, string.Empty);
			return tableItem != null && tableItem.ChildrenIDs[0] != 0;
		}

		// Token: 0x0600B063 RID: 45155 RVA: 0x0026CC34 File Offset: 0x0026B034
		public int GetIntDrugNodeCount(int iIndex)
		{
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iIndex < 0 || iIndex >= auctionConsumablesList.Count)
			{
				return 0;
			}
			IList<int> list = null;
			if (auctionConsumablesList != null)
			{
				AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iIndex], string.Empty, string.Empty);
				if (tableItem != null)
				{
					list = tableItem.ChildrenIDs;
				}
			}
			return list.Count - 1;
		}

		// Token: 0x0600B064 RID: 45156 RVA: 0x0026CCAC File Offset: 0x0026B0AC
		public string GetStrOfAuctionConsumables(int iIndex)
		{
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iIndex < 0 || iIndex >= auctionConsumablesList.Count)
			{
				return "-";
			}
			IList<int> list = null;
			for (int i = 0; i < auctionConsumablesList.Count; i++)
			{
				AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.ChildrenIDs.Count >= 0 && tableItem.ChildrenIDs[0] != 0)
					{
						list = tableItem.ChildrenIDs;
					}
				}
			}
			AuctionClassify tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(list[iIndex], string.Empty, string.Empty);
			if (auctionConsumablesList == null)
			{
				return "-";
			}
			return tableItem2.Name;
		}

		// Token: 0x0600B065 RID: 45157 RVA: 0x0026CD88 File Offset: 0x0026B188
		public string GetStrOfAuctionArmorType(int iIndex)
		{
			List<int> auctionArmorList = Singleton<TableManager>.GetInstance().GetAuctionArmorList();
			if (auctionArmorList == null || auctionArmorList.Count <= 0 || iIndex < 0 || iIndex >= auctionArmorList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionArmorList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B066 RID: 45158 RVA: 0x0026CDFC File Offset: 0x0026B1FC
		public int SwitchWeaponSubType(AuctionClassify.eJob eJobType, int iIndex)
		{
			int num = 1000;
			List<int> auctionWeaponList = Singleton<TableManager>.GetInstance().GetAuctionWeaponList(eJobType);
			if (auctionWeaponList == null || auctionWeaponList.Count <= 0 || iIndex < 0 || iIndex >= auctionWeaponList.Count)
			{
				return 0;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionWeaponList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return (int)(num + tableItem.ThirdType);
		}

		// Token: 0x0600B067 RID: 45159 RVA: 0x0026CE70 File Offset: 0x0026B270
		public int SwitchDefenceSubType(int iDefenceIndex, int iArmorIndex)
		{
			int num = 1000;
			List<int> auctionDefenceList = Singleton<TableManager>.GetInstance().GetAuctionDefenceList();
			List<int> auctionArmorList = Singleton<TableManager>.GetInstance().GetAuctionArmorList();
			if (auctionDefenceList == null || auctionDefenceList.Count <= 0 || iArmorIndex < 0 || iArmorIndex >= auctionDefenceList.Count)
			{
				return 0;
			}
			if (auctionArmorList == null || auctionArmorList.Count <= 0 || iDefenceIndex < 0 || iDefenceIndex >= auctionArmorList.Count)
			{
				return 0;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionDefenceList[iArmorIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			AuctionClassify tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionArmorList[iDefenceIndex], string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			return (int)(tableItem.SubType * (AuctionClassify.eSubType)num + (int)tableItem2.ThirdType);
		}

		// Token: 0x0600B068 RID: 45160 RVA: 0x0026CF44 File Offset: 0x0026B344
		public int SwitchJewelrySubType(int iIndex)
		{
			int num = 1000;
			List<int> auctionJewelryList = Singleton<TableManager>.GetInstance().GetAuctionJewelryList();
			if (auctionJewelryList == null || auctionJewelryList.Count <= 0 || iIndex < 0 || iIndex >= auctionJewelryList.Count)
			{
				return 0;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionJewelryList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return (int)(tableItem.SubType * (AuctionClassify.eSubType)num + (int)tableItem.ThirdType);
		}

		// Token: 0x0600B069 RID: 45161 RVA: 0x0026CFBC File Offset: 0x0026B3BC
		public int SwitchConsumablesSubType(int iIndex)
		{
			int num = 1000;
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iIndex < 0 || iIndex >= auctionConsumablesList.Count)
			{
				return 0;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return (int)(tableItem.SubType * (AuctionClassify.eSubType)num + (int)tableItem.ThirdType);
		}

		// Token: 0x0600B06A RID: 45162 RVA: 0x0026D034 File Offset: 0x0026B434
		public int SwitchMaterialsSubType(int iIndex)
		{
			int num = 1000;
			List<int> auctionMaterialsList = Singleton<TableManager>.GetInstance().GetAuctionMaterialsList();
			if (auctionMaterialsList == null || auctionMaterialsList.Count <= 0 || iIndex < 0 || iIndex >= auctionMaterialsList.Count)
			{
				return 0;
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionMaterialsList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return (int)(tableItem.SubType * (AuctionClassify.eSubType)num + (int)tableItem.ThirdType);
		}

		// Token: 0x0600B06B RID: 45163 RVA: 0x0026D0AC File Offset: 0x0026B4AC
		public string GetStrOfAuctionWeaponType(AuctionClassify.eJob eJobType, int iIndex)
		{
			List<int> auctionWeaponList = Singleton<TableManager>.GetInstance().GetAuctionWeaponList(eJobType);
			if (auctionWeaponList == null || auctionWeaponList.Count <= 0 || iIndex < 0 || iIndex >= auctionWeaponList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionWeaponList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B06C RID: 45164 RVA: 0x0026D120 File Offset: 0x0026B520
		public string GetStrOfAuctionDefenceType(int iIndex)
		{
			List<int> auctionDefenceList = Singleton<TableManager>.GetInstance().GetAuctionDefenceList();
			if (auctionDefenceList == null || auctionDefenceList.Count <= 0 || iIndex < 0 || iIndex >= auctionDefenceList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionDefenceList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B06D RID: 45165 RVA: 0x0026D194 File Offset: 0x0026B594
		public string GetStrOfAuctionJewelryType(int iIndex)
		{
			List<int> auctionJewelryList = Singleton<TableManager>.GetInstance().GetAuctionJewelryList();
			if (auctionJewelryList == null || auctionJewelryList.Count <= 0 || iIndex < 0 || iIndex >= auctionJewelryList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionJewelryList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B06E RID: 45166 RVA: 0x0026D208 File Offset: 0x0026B608
		public string GetStrOfAuctionConsumablesType(int iIndex)
		{
			List<int> auctionConsumablesList = Singleton<TableManager>.GetInstance().GetAuctionConsumablesList();
			if (auctionConsumablesList == null || auctionConsumablesList.Count <= 0 || iIndex < 0 || iIndex >= auctionConsumablesList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionConsumablesList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B06F RID: 45167 RVA: 0x0026D27C File Offset: 0x0026B67C
		public string GetStrOfAuctionMaterialsType(int iIndex)
		{
			List<int> auctionMaterialsList = Singleton<TableManager>.GetInstance().GetAuctionMaterialsList();
			if (auctionMaterialsList == null || auctionMaterialsList.Count <= 0 || iIndex < 0 || iIndex >= auctionMaterialsList.Count)
			{
				return "-";
			}
			AuctionClassify tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionClassify>(auctionMaterialsList[iIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "-";
			}
			return tableItem.Name;
		}

		// Token: 0x0600B070 RID: 45168 RVA: 0x0026D2F0 File Offset: 0x0026B6F0
		public string GetStrOfAuctionJobType(AuctionClassify.eJob eJobType)
		{
			if (eJobType == AuctionClassify.eJob.AC_JIANSHI)
			{
				return TR.Value("Auction_ghost_warrior");
			}
			if (eJobType == AuctionClassify.eJob.AC_QIANGSHOU)
			{
				return TR.Value("Auction_man_gunners");
			}
			if (eJobType == AuctionClassify.eJob.AC_FASHI)
			{
				return TR.Value("Auction_sorceress");
			}
			if (eJobType == AuctionClassify.eJob.AC_GEDOU)
			{
				return TR.Value("Auction_female_fighting");
			}
			if (eJobType == AuctionClassify.eJob.AC_JOB_ALL)
			{
				return TR.Value("team_target_diff_all");
			}
			return "-";
		}

		// Token: 0x0600B071 RID: 45169 RVA: 0x0026D35C File Offset: 0x0026B75C
		public void SceneNotifyAbnormalTransactionRet(MsgDATA msg)
		{
			SceneNotifyAbnormalTransaction sceneNotifyAbnormalTransaction = new SceneNotifyAbnormalTransaction();
			sceneNotifyAbnormalTransaction.decode(msg.bytes);
			bool flag = sceneNotifyAbnormalTransaction.bNotify >= 1;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AuctionFreezeRemind, flag, null, null, null);
		}

		// Token: 0x0600B072 RID: 45170 RVA: 0x0026D3A0 File Offset: 0x0026B7A0
		public void SendSceneAbnormalTransactionRecordReq()
		{
			NetManager netManager = NetManager.Instance();
			SceneAbnormalTransactionRecordReq cmd = new SceneAbnormalTransactionRecordReq();
			netManager.SendCommand<SceneAbnormalTransactionRecordReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B073 RID: 45171 RVA: 0x0026D3C4 File Offset: 0x0026B7C4
		private void SceneAbnormalTransactionRecordRet(MsgDATA msg)
		{
			SceneAbnormalTransactionRecordRes sceneAbnormalTransactionRecordRes = new SceneAbnormalTransactionRecordRes();
			sceneAbnormalTransactionRecordRes.decode(msg.bytes);
			AuctionFreezeRemindData auctionFreezeRemindData = new AuctionFreezeRemindData();
			auctionFreezeRemindData.frozenMoneyType = sceneAbnormalTransactionRecordRes.frozenMoneyType;
			auctionFreezeRemindData.frozenAmount = sceneAbnormalTransactionRecordRes.frozenAmount;
			auctionFreezeRemindData.abnormalTransactionTime = sceneAbnormalTransactionRecordRes.abnormalTransactionTime;
			auctionFreezeRemindData.terminationOfBail = sceneAbnormalTransactionRecordRes.backDeadline;
			auctionFreezeRemindData.remainingBailPeriod = sceneAbnormalTransactionRecordRes.backDeadline - DataManager<TimeManager>.GetInstance().GetServerTime();
			auctionFreezeRemindData.backAmount = sceneAbnormalTransactionRecordRes.backAmount;
			auctionFreezeRemindData.backDays = sceneAbnormalTransactionRecordRes.backDays;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionFreezeRemindFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionFreezeRemindFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionFreezeRemindFrame>(FrameLayer.Middle, auctionFreezeRemindData, string.Empty);
		}

		// Token: 0x0600B074 RID: 45172 RVA: 0x0026D478 File Offset: 0x0026B878
		public string GetDateTime(int time)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time).ToString("yyyy-MM-dd");
		}

		// Token: 0x0600B075 RID: 45173 RVA: 0x0026D4B2 File Offset: 0x0026B8B2
		public string GetDataDay(int time)
		{
			return string.Format("{0}", time / 86400);
		}

		// Token: 0x0600B076 RID: 45174 RVA: 0x0026D4CA File Offset: 0x0026B8CA
		public void OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x04006297 RID: 25239
		private bool m_bIsUpdateCurPage;
	}
}

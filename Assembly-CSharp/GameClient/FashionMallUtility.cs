using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012AA RID: 4778
	public static class FashionMallUtility
	{
		// Token: 0x0600B809 RID: 47113 RVA: 0x002A16E4 File Offset: 0x0029FAE4
		public static List<FashionMallClothTabData> GetClothTabDataModelList()
		{
			return new List<FashionMallClothTabData>
			{
				new FashionMallClothTabData
				{
					Index = 0,
					MallTableId = 11,
					Name = TR.Value("Fashion_mall_cloth_tab_suit"),
					ClothTabType = FashionMallClothTabType.Suit
				},
				new FashionMallClothTabData
				{
					Index = 1,
					MallTableId = 4,
					Name = TR.Value("Fashion_mall_cloth_tab_single"),
					ClothTabType = FashionMallClothTabType.Single
				},
				new FashionMallClothTabData
				{
					Index = 2,
					MallTableId = 21,
					Name = TR.Value("Fashion_mall_cloth_tab_weapon"),
					ClothTabType = FashionMallClothTabType.Weapon
				}
			};
		}

		// Token: 0x0600B80A RID: 47114 RVA: 0x002A1790 File Offset: 0x0029FB90
		public static List<ComControlData> GetProfessionTabDataModelList()
		{
			List<ComControlData> list = new List<ComControlData>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("Data Error JobTable is null", new object[0]);
				return list;
			}
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				JobTable jobTable = keyValuePair.Value as JobTable;
				if (jobTable != null && jobTable.prejob == 0 && jobTable.Open == 1)
				{
					FashionMallProfessionTabData item = new FashionMallProfessionTabData(++num, jobTable.ID, jobTable.Name, false);
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				list.Sort((ComControlData x, ComControlData y) => x.Id.CompareTo(y.Id));
			}
			return list;
		}

		// Token: 0x0600B80B RID: 47115 RVA: 0x002A186C File Offset: 0x0029FC6C
		public static List<FashionMallPositionTabData> GetPositionTabDataModelList()
		{
			return new List<FashionMallPositionTabData>
			{
				new FashionMallPositionTabData
				{
					Index = 0,
					PositionTabType = FashionMallPositionTabType.Head
				},
				new FashionMallPositionTabData
				{
					Index = 1,
					PositionTabType = FashionMallPositionTabType.Clothes
				},
				new FashionMallPositionTabData
				{
					Index = 2,
					PositionTabType = FashionMallPositionTabType.Plastron
				},
				new FashionMallPositionTabData
				{
					Index = 3,
					PositionTabType = FashionMallPositionTabType.Trousers
				},
				new FashionMallPositionTabData
				{
					Index = 4,
					PositionTabType = FashionMallPositionTabType.Waist
				}
			};
		}

		// Token: 0x0600B80C RID: 47116 RVA: 0x002A1908 File Offset: 0x0029FD08
		public static int GetMallType(int mallTableId)
		{
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(mallTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("MallTypeTable is null and mallTableId is {0}", new object[]
				{
					mallTableId
				});
				return 0;
			}
			return (int)tableItem.MallType;
		}

		// Token: 0x0600B80D RID: 47117 RVA: 0x002A1954 File Offset: 0x0029FD54
		public static bool IsSameSlotType(EFashionWearSlotType fashionWearSlotType, FashionMallPositionTabType positionTabType)
		{
			return (fashionWearSlotType == EFashionWearSlotType.Head && positionTabType == FashionMallPositionTabType.Head) || (fashionWearSlotType == EFashionWearSlotType.UpperBody && positionTabType == FashionMallPositionTabType.Clothes) || (fashionWearSlotType == EFashionWearSlotType.Chest && positionTabType == FashionMallPositionTabType.Plastron) || (fashionWearSlotType == EFashionWearSlotType.LowerBody && positionTabType == FashionMallPositionTabType.Trousers) || (fashionWearSlotType == EFashionWearSlotType.Waist && positionTabType == FashionMallPositionTabType.Waist) || (fashionWearSlotType == EFashionWearSlotType.Weapon && positionTabType == FashionMallPositionTabType.Weapon);
		}

		// Token: 0x0600B80E RID: 47118 RVA: 0x002A19C4 File Offset: 0x0029FDC4
		public static EFashionWearSlotType GetEquipSlotType(ItemTable itemTable)
		{
			if (itemTable.SubType == ItemTable.eSubType.FASHION_HEAD)
			{
				return EFashionWearSlotType.Head;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_CHEST)
			{
				return EFashionWearSlotType.UpperBody;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_EPAULET)
			{
				return EFashionWearSlotType.Chest;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_LEG)
			{
				return EFashionWearSlotType.LowerBody;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_SASH)
			{
				return EFashionWearSlotType.Waist;
			}
			if (itemTable.SubType == ItemTable.eSubType.FASHION_WEAPON)
			{
				return EFashionWearSlotType.Weapon;
			}
			return EFashionWearSlotType.Invalid;
		}

		// Token: 0x0600B80F RID: 47119 RVA: 0x002A1A2C File Offset: 0x0029FE2C
		public static int GetSelfBaseJobId()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return num;
			}
			if (tableItem.JobType == 1)
			{
				num = tableItem.prejob;
			}
			return num;
		}

		// Token: 0x0600B810 RID: 47120 RVA: 0x002A1A76 File Offset: 0x0029FE76
		public static int GetMallTableSubTypeIndex(FashionMallClothTabType clothTabType, FashionMallPositionTabType positionTabType)
		{
			if (clothTabType == FashionMallClothTabType.Suit)
			{
				return 6;
			}
			if (clothTabType == FashionMallClothTabType.Weapon)
			{
				return 7;
			}
			switch (positionTabType)
			{
			case FashionMallPositionTabType.Head:
				return 1;
			case FashionMallPositionTabType.Clothes:
				return 2;
			case FashionMallPositionTabType.Plastron:
				return 3;
			case FashionMallPositionTabType.Trousers:
				return 4;
			case FashionMallPositionTabType.Waist:
				return 5;
			default:
				return 1;
			}
		}

		// Token: 0x0600B811 RID: 47121 RVA: 0x002A1AB3 File Offset: 0x0029FEB3
		public static void CloseFashionLimitTimeBuyFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FashionLimitTimeBuyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionLimitTimeBuyFrame>(null, false);
			}
		}

		// Token: 0x0600B812 RID: 47122 RVA: 0x002A1AD1 File Offset: 0x0029FED1
		public static void CloseFashionMallBuyFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallBuyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallBuyFrame>(null, false);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B03 RID: 6915
	public class EquipTransferUtility
	{
		// Token: 0x06010F85 RID: 69509 RVA: 0x004D9BF0 File Offset: 0x004D7FF0
		public static List<ItemData> GetTransferStones(ItemData data)
		{
			List<ItemData> list = new List<ItemData>();
			if (data != null)
			{
				for (int i = 0; i < EquipTransferUtility.mapNodes.Count; i++)
				{
					if (EquipTransferUtility.mapNodes[i].IsFitLevel(data.LevelLimit) && EquipTransferUtility.mapNodes[i].IsFitSubType(data.SubType))
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(EquipTransferUtility.mapNodes[i].itemData.TableID, true);
						if (ownedItemCount > 0)
						{
							list.Add(EquipTransferUtility.mapNodes[i].itemData);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06010F86 RID: 69510 RVA: 0x004D9C99 File Offset: 0x004D8099
		private static ItemData GetTransferStoneId(ItemData data)
		{
			if (data == null)
			{
				return EquipTransferUtility.GetTransferStoneId(1, -1);
			}
			return EquipTransferUtility.GetTransferStoneId(data.LevelLimit, data.SubType);
		}

		// Token: 0x06010F87 RID: 69511 RVA: 0x004D9CBC File Offset: 0x004D80BC
		public static ItemData GetTransferStoneId(int levelLimit = 1, int subType = -1)
		{
			for (int i = 0; i < EquipTransferUtility.mapNodes.Count; i++)
			{
				if (EquipTransferUtility.mapNodes[i].IsFitLevel(levelLimit) && EquipTransferUtility.mapNodes[i].IsFitSubType(subType))
				{
					return EquipTransferUtility.mapNodes[i].itemData;
				}
			}
			return null;
		}

		// Token: 0x06010F88 RID: 69512 RVA: 0x004D9D24 File Offset: 0x004D8124
		public static bool IsTransferStone(int itemId)
		{
			for (int i = 0; i < EquipTransferUtility.mapNodes.Count; i++)
			{
				if (EquipTransferUtility.mapNodes[i].itemData.TableID == itemId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010F89 RID: 69513 RVA: 0x004D9D6C File Offset: 0x004D816C
		public static bool IsMatch(ItemData item, ItemData stoneItem)
		{
			if (stoneItem == null)
			{
				return false;
			}
			List<ItemData> transferStones = EquipTransferUtility.GetTransferStones(item);
			for (int i = 0; i < transferStones.Count; i++)
			{
				if (transferStones[i].TableID == stoneItem.TableID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17001D83 RID: 7555
		// (get) Token: 0x06010F8A RID: 69514 RVA: 0x004D9DBC File Offset: 0x004D81BC
		private static List<EquipTransferUtility.MapNode> mapNodes
		{
			get
			{
				if (EquipTransferUtility.mMapNodes == null)
				{
					EquipTransferUtility.mMapNodes = new List<EquipTransferUtility.MapNode>();
					Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<EquipTransMapTable>();
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						EquipTransMapTable equipTransMapTable = keyValuePair.Value as EquipTransMapTable;
						EquipTransferUtility.mMapNodes.Add(new EquipTransferUtility.MapNode(equipTransMapTable.ItemId, 1, equipTransMapTable.Level.ToArray<int>(), equipTransMapTable.SubTypes.ToArray<int>()));
					}
					EquipTransferUtility.mMapNodes.Sort();
				}
				return EquipTransferUtility.mMapNodes;
			}
		}

		// Token: 0x0400AE98 RID: 44696
		private static List<EquipTransferUtility.MapNode> mMapNodes;

		// Token: 0x02001B04 RID: 6916
		private class MapNode : IComparable<EquipTransferUtility.MapNode>
		{
			// Token: 0x06010F8C RID: 69516 RVA: 0x004D9E54 File Offset: 0x004D8254
			public MapNode(int id, int count, int[] levels, int[] subTypes)
			{
				this.itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
				if (this.itemData == null)
				{
					Logger.LogErrorFormat("itemId {0} is nil", new object[]
					{
						id
					});
				}
				this.itemData.Count = count;
				if (levels.Length > 0)
				{
					this.minLevel = levels[0];
					this.maxLevel = levels[0];
				}
				for (int i = 0; i < levels.Length; i++)
				{
					this.minLevel = Mathf.Min(levels[i], this.minLevel);
					this.maxLevel = Mathf.Max(levels[i], this.maxLevel);
				}
				this.subTypes = subTypes;
				if (this.subTypes == null)
				{
					this.subTypes = new int[0];
				}
			}

			// Token: 0x17001D84 RID: 7556
			// (get) Token: 0x06010F8D RID: 69517 RVA: 0x004D9F1C File Offset: 0x004D831C
			// (set) Token: 0x06010F8E RID: 69518 RVA: 0x004D9F24 File Offset: 0x004D8324
			private int minLevel { get; set; }

			// Token: 0x17001D85 RID: 7557
			// (get) Token: 0x06010F8F RID: 69519 RVA: 0x004D9F2D File Offset: 0x004D832D
			// (set) Token: 0x06010F90 RID: 69520 RVA: 0x004D9F35 File Offset: 0x004D8335
			private int maxLevel { get; set; }

			// Token: 0x17001D86 RID: 7558
			// (get) Token: 0x06010F91 RID: 69521 RVA: 0x004D9F3E File Offset: 0x004D833E
			// (set) Token: 0x06010F92 RID: 69522 RVA: 0x004D9F46 File Offset: 0x004D8346
			private int[] subTypes { get; set; }

			// Token: 0x17001D87 RID: 7559
			// (get) Token: 0x06010F93 RID: 69523 RVA: 0x004D9F4F File Offset: 0x004D834F
			// (set) Token: 0x06010F94 RID: 69524 RVA: 0x004D9F57 File Offset: 0x004D8357
			public ItemData itemData { get; private set; }

			// Token: 0x06010F95 RID: 69525 RVA: 0x004D9F60 File Offset: 0x004D8360
			public int CompareTo(EquipTransferUtility.MapNode other)
			{
				if (this.minLevel != other.minLevel)
				{
					return this.minLevel - other.minLevel;
				}
				if (this.maxLevel != other.maxLevel)
				{
					return this.maxLevel - other.maxLevel;
				}
				return this.subTypes.Length - other.subTypes.Length;
			}

			// Token: 0x06010F96 RID: 69526 RVA: 0x004D9FBC File Offset: 0x004D83BC
			public bool IsFitLevel(int level)
			{
				return this.minLevel <= level && this.maxLevel >= level;
			}

			// Token: 0x06010F97 RID: 69527 RVA: 0x004D9FDC File Offset: 0x004D83DC
			public bool IsFitSubType(int subType)
			{
				if (subType == -1)
				{
					return true;
				}
				for (int i = 0; i < this.subTypes.Length; i++)
				{
					if (this.subTypes[i] == subType)
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020015C4 RID: 5572
	public class EquipHandbookTabCollectionData : IComparable<EquipHandbookTabCollectionData>
	{
		// Token: 0x0600DA24 RID: 55844 RVA: 0x0036D698 File Offset: 0x0036BA98
		protected EquipHandbookTabCollectionData(EquipHandbookTabCollectionData data)
		{
			if (data == null)
			{
				Logger.LogErrorFormat("[EquipHandbook] 初始化参数为空", new object[0]);
				return;
			}
			this.partScreenType = data.partScreenType;
			this.id = data.id;
			this.level = data.level;
			this.name = data.name;
			this.order = data.order;
			this.occopationLimitType = data.occopationLimitType;
			this.fitOccupations.AddRange(data.fitOccupations);
		}

		// Token: 0x0600DA25 RID: 55845 RVA: 0x0036D73C File Offset: 0x0036BB3C
		public EquipHandbookTabCollectionData(EquipHandbookCollectionTable data)
		{
			if (data == null)
			{
				Logger.LogErrorFormat("[EquipHandbook] 初始化参数为空", new object[0]);
				return;
			}
			this.partScreenType = data.ScreenType;
			this.id = data.ID;
			this.level = data.Level;
			this.name = data.Name;
			this.order = data.SortOrder;
			this.occopationLimitType = data.OccopationLimitType;
			EquipHandbookCollectionTable.eOccopationLimitType occopationLimitType = this.occopationLimitType;
			if (occopationLimitType != EquipHandbookCollectionTable.eOccopationLimitType.eAccordingAttachedItem)
			{
				if (occopationLimitType == EquipHandbookCollectionTable.eOccopationLimitType.eAccordingOccuptionLimit)
				{
					this.fitOccupations.AddRange(data.OccopationLimit);
				}
			}
			EquipHandbookCollectionTable.eType type = data.Type;
			if (type != EquipHandbookCollectionTable.eType.eCustom)
			{
				if (type == EquipHandbookCollectionTable.eType.eEquipSuit)
				{
					EquipSuitTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipSuitTable>(data.EquipSuitID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						for (int i = 0; i < tableItem.EquipIDs.Count; i++)
						{
							EquipHandbookEquipItemData equipHandbookEquipItemData = new EquipHandbookEquipItemData(tableItem.EquipIDs[i]);
							equipHandbookEquipItemData.CalculateBaseScore();
							this.mItemIDs.Add(equipHandbookEquipItemData);
						}
						this.name = tableItem.Name;
					}
					else
					{
						Logger.LogErrorFormat("[EquipHandbook] 装备图鉴集合表格 ID为{0}，找不到{1}的套装", new object[]
						{
							data.ID,
							data.EquipSuitID
						});
					}
				}
			}
			else
			{
				for (int j = 0; j < data.CustomEquipIDs.Count; j++)
				{
					EquipHandbookEquipItemData equipHandbookEquipItemData2 = new EquipHandbookEquipItemData(data.CustomEquipIDs[j]);
					equipHandbookEquipItemData2.CalculateBaseScore();
					this.mItemIDs.Add(equipHandbookEquipItemData2);
				}
			}
		}

		// Token: 0x0600DA26 RID: 55846 RVA: 0x0036D918 File Offset: 0x0036BD18
		public IEnumerator GetWeaponSplitIterator()
		{
			if (this.partScreenType != EquipHandbookCollectionTable.eScreenType.eWeapon)
			{
				yield break;
			}
			for (int i = 0; i < this.mItemIDs.Count; i++)
			{
				if (this.mItemIDs[i].id != 0)
				{
					EquipHandbookTabCollectionData iterData = new EquipHandbookTabCollectionData(this);
					iterData.mItemIDs.Clear();
					iterData.mItemIDs.Add(this.mItemIDs[i]);
					yield return iterData;
				}
			}
			yield break;
		}

		// Token: 0x17001C46 RID: 7238
		// (get) Token: 0x0600DA27 RID: 55847 RVA: 0x0036D933 File Offset: 0x0036BD33
		// (set) Token: 0x0600DA28 RID: 55848 RVA: 0x0036D93B File Offset: 0x0036BD3B
		public EquipHandbookCollectionTable.eScreenType partScreenType { get; private set; }

		// Token: 0x17001C47 RID: 7239
		// (get) Token: 0x0600DA29 RID: 55849 RVA: 0x0036D944 File Offset: 0x0036BD44
		// (set) Token: 0x0600DA2A RID: 55850 RVA: 0x0036D94C File Offset: 0x0036BD4C
		public int id { get; private set; }

		// Token: 0x17001C48 RID: 7240
		// (get) Token: 0x0600DA2B RID: 55851 RVA: 0x0036D955 File Offset: 0x0036BD55
		// (set) Token: 0x0600DA2C RID: 55852 RVA: 0x0036D95D File Offset: 0x0036BD5D
		public int level { get; private set; }

		// Token: 0x17001C49 RID: 7241
		// (get) Token: 0x0600DA2D RID: 55853 RVA: 0x0036D966 File Offset: 0x0036BD66
		// (set) Token: 0x0600DA2E RID: 55854 RVA: 0x0036D96E File Offset: 0x0036BD6E
		public string name { get; private set; }

		// Token: 0x17001C4A RID: 7242
		// (get) Token: 0x0600DA2F RID: 55855 RVA: 0x0036D977 File Offset: 0x0036BD77
		// (set) Token: 0x0600DA30 RID: 55856 RVA: 0x0036D97F File Offset: 0x0036BD7F
		public int order { get; private set; }

		// Token: 0x17001C4B RID: 7243
		// (get) Token: 0x0600DA32 RID: 55858 RVA: 0x0036D991 File Offset: 0x0036BD91
		// (set) Token: 0x0600DA31 RID: 55857 RVA: 0x0036D988 File Offset: 0x0036BD88
		public EquipHandbookCollectionTable.eOccopationLimitType occopationLimitType { get; private set; }

		// Token: 0x17001C4C RID: 7244
		// (get) Token: 0x0600DA33 RID: 55859 RVA: 0x0036D999 File Offset: 0x0036BD99
		public List<EquipHandbookEquipItemData> itemIDs
		{
			get
			{
				if (this.occopationLimitType == EquipHandbookCollectionTable.eOccopationLimitType.eAccordingOccuptionLimit)
				{
					return this.mItemIDs;
				}
				return this.mFilterItemIDs;
			}
		}

		// Token: 0x0600DA34 RID: 55860 RVA: 0x0036D9B4 File Offset: 0x0036BDB4
		public EquipHandbookEquipItemData pickOne(int score)
		{
			for (int i = 0; i < this.itemIDs.Count; i++)
			{
				if (this.itemIDs[i].baseScore > score)
				{
					return this.itemIDs[i];
				}
			}
			return this.itemIDs[this.itemIDs.Count - 1];
		}

		// Token: 0x0600DA35 RID: 55861 RVA: 0x0036DA1C File Offset: 0x0036BE1C
		public List<EquipHandbookEquipItemData> FilterWithOccupation()
		{
			if (this.occopationLimitType == EquipHandbookCollectionTable.eOccopationLimitType.eAccordingOccuptionLimit)
			{
				return this.mItemIDs;
			}
			this.mFilterItemIDs.Clear();
			this.mFilterItemIDs.AddRange(this.mItemIDs);
			this.mFilterItemIDs.RemoveAll(new Predicate<EquipHandbookEquipItemData>(this._filterCondition));
			return this.mFilterItemIDs;
		}

		// Token: 0x0600DA36 RID: 55862 RVA: 0x0036DA76 File Offset: 0x0036BE76
		private bool _filterCondition(EquipHandbookEquipItemData item)
		{
			return !item.isFitOccupation;
		}

		// Token: 0x17001C4D RID: 7245
		// (get) Token: 0x0600DA37 RID: 55863 RVA: 0x0036DA81 File Offset: 0x0036BE81
		public bool isFitOccupation
		{
			get
			{
				return EquipHandbookUtility.IsFitOccupation(this.fitOccupations);
			}
		}

		// Token: 0x17001C4E RID: 7246
		// (get) Token: 0x0600DA38 RID: 55864 RVA: 0x0036DA8E File Offset: 0x0036BE8E
		public bool isFitLevel
		{
			get
			{
				return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.level;
			}
		}

		// Token: 0x17001C4F RID: 7247
		// (get) Token: 0x0600DA39 RID: 55865 RVA: 0x0036DAA8 File Offset: 0x0036BEA8
		public int sumEquipCollectScore
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.itemIDs.Count; i++)
				{
					num += this.itemIDs[i].baseScore;
				}
				return num;
			}
		}

		// Token: 0x0600DA3A RID: 55866 RVA: 0x0036DAE8 File Offset: 0x0036BEE8
		public int CompareTo(EquipHandbookTabCollectionData other)
		{
			if (this.partScreenType != other.partScreenType)
			{
				return this.partScreenType - other.partScreenType;
			}
			if (this.partScreenType != EquipHandbookCollectionTable.eScreenType.eNull && this.sumEquipCollectScore != other.sumEquipCollectScore)
			{
				return this.sumEquipCollectScore - other.sumEquipCollectScore;
			}
			if (this.level != other.level)
			{
				return this.level - other.level;
			}
			return this.order - other.order;
		}

		// Token: 0x0400805C RID: 32860
		public List<int> fitOccupations = new List<int>();

		// Token: 0x0400805E RID: 32862
		private List<EquipHandbookEquipItemData> mItemIDs = new List<EquipHandbookEquipItemData>();

		// Token: 0x0400805F RID: 32863
		private List<EquipHandbookEquipItemData> mFilterItemIDs = new List<EquipHandbookEquipItemData>();
	}
}

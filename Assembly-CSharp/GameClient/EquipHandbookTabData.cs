using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020015C3 RID: 5571
	public class EquipHandbookTabData : IComparable<EquipHandbookTabData>
	{
		// Token: 0x0600DA03 RID: 55811 RVA: 0x0036D108 File Offset: 0x0036B508
		public EquipHandbookTabData(EquipHandbookContentTable data)
		{
			if (data == null)
			{
				return;
			}
			this.id = data.ID;
			this.sortOrder = data.SortOrder;
			this.type = data.Type;
			this.name = data.Name;
			this.isDefaultTab = data.IsDefaultTab;
			this.isShowEquipScore = data.IsShowEquipScore;
			this.isFilterWithLevel = data.IsFilterWithLevel;
			this.isFilterWithEquipScore = data.IsFilterWithEquipScore;
		}

		// Token: 0x17001C3C RID: 7228
		// (get) Token: 0x0600DA04 RID: 55812 RVA: 0x0036D198 File Offset: 0x0036B598
		// (set) Token: 0x0600DA05 RID: 55813 RVA: 0x0036D1A0 File Offset: 0x0036B5A0
		public int id { get; private set; }

		// Token: 0x17001C3D RID: 7229
		// (get) Token: 0x0600DA06 RID: 55814 RVA: 0x0036D1A9 File Offset: 0x0036B5A9
		// (set) Token: 0x0600DA07 RID: 55815 RVA: 0x0036D1B1 File Offset: 0x0036B5B1
		public int sortOrder { get; private set; }

		// Token: 0x17001C3E RID: 7230
		// (get) Token: 0x0600DA08 RID: 55816 RVA: 0x0036D1BA File Offset: 0x0036B5BA
		// (set) Token: 0x0600DA09 RID: 55817 RVA: 0x0036D1C2 File Offset: 0x0036B5C2
		public string name { get; private set; }

		// Token: 0x17001C3F RID: 7231
		// (get) Token: 0x0600DA0A RID: 55818 RVA: 0x0036D1CB File Offset: 0x0036B5CB
		// (set) Token: 0x0600DA0B RID: 55819 RVA: 0x0036D1D3 File Offset: 0x0036B5D3
		public EquipHandbookContentTable.eType type { get; private set; }

		// Token: 0x17001C40 RID: 7232
		// (get) Token: 0x0600DA0C RID: 55820 RVA: 0x0036D1DC File Offset: 0x0036B5DC
		// (set) Token: 0x0600DA0D RID: 55821 RVA: 0x0036D1E4 File Offset: 0x0036B5E4
		public bool isDefaultTab { get; private set; }

		// Token: 0x17001C41 RID: 7233
		// (get) Token: 0x0600DA0E RID: 55822 RVA: 0x0036D1ED File Offset: 0x0036B5ED
		// (set) Token: 0x0600DA0F RID: 55823 RVA: 0x0036D1F5 File Offset: 0x0036B5F5
		public bool isShowEquipScore { get; private set; }

		// Token: 0x17001C42 RID: 7234
		// (get) Token: 0x0600DA10 RID: 55824 RVA: 0x0036D1FE File Offset: 0x0036B5FE
		// (set) Token: 0x0600DA11 RID: 55825 RVA: 0x0036D206 File Offset: 0x0036B606
		public bool isFilterWithLevel { get; private set; }

		// Token: 0x17001C43 RID: 7235
		// (get) Token: 0x0600DA12 RID: 55826 RVA: 0x0036D20F File Offset: 0x0036B60F
		// (set) Token: 0x0600DA13 RID: 55827 RVA: 0x0036D217 File Offset: 0x0036B617
		public bool isFilterWithEquipScore { get; private set; }

		// Token: 0x17001C44 RID: 7236
		// (get) Token: 0x0600DA14 RID: 55828 RVA: 0x0036D220 File Offset: 0x0036B620
		public List<EquipHandbookTabCollectionData> collectIDs
		{
			get
			{
				return this.mFilterIDs;
			}
		}

		// Token: 0x0600DA15 RID: 55829 RVA: 0x0036D228 File Offset: 0x0036B628
		public List<EquipHandbookEquipItemData> GetRecommendedCollect(int weaponPartScore, int armorPartScore, int jewelryPartScore, ref bool isBest)
		{
			List<EquipHandbookEquipItemData> list = new List<EquipHandbookEquipItemData>();
			bool flag = false;
			EquipHandbookTabCollectionData equipHandbookTabCollectionData = this._findFirstHighScore(EquipHandbookCollectionTable.eScreenType.eWeapon, weaponPartScore, ref flag);
			if (equipHandbookTabCollectionData != null)
			{
				list.Add(equipHandbookTabCollectionData.pickOne(weaponPartScore));
			}
			bool flag2 = false;
			EquipHandbookTabCollectionData equipHandbookTabCollectionData2 = this._findFirstHighScore(EquipHandbookCollectionTable.eScreenType.eArmor, armorPartScore, ref flag2);
			if (equipHandbookTabCollectionData2 != null)
			{
				list.AddRange(equipHandbookTabCollectionData2.itemIDs);
			}
			bool flag3 = false;
			EquipHandbookTabCollectionData equipHandbookTabCollectionData3 = this._findFirstHighScore(EquipHandbookCollectionTable.eScreenType.eJewelry, jewelryPartScore, ref flag3);
			if (equipHandbookTabCollectionData3 != null)
			{
				list.AddRange(equipHandbookTabCollectionData3.itemIDs);
			}
			isBest = (flag2 && flag3 && flag);
			return list;
		}

		// Token: 0x0600DA16 RID: 55830 RVA: 0x0036D2B8 File Offset: 0x0036B6B8
		private EquipHandbookTabCollectionData _findFirstHighScore(EquipHandbookCollectionTable.eScreenType partType, int score, ref bool isBest)
		{
			isBest = false;
			int splitLevel = DataManager<EquipHandbookDataManager>.GetInstance().GetSplitLevel(this.mFilterIDs, partType);
			int index = 0;
			int num = 0;
			for (int i = 0; i < this.mFilterIDs.Count; i++)
			{
				if (this.mFilterIDs[i].partScreenType == partType)
				{
					if (this.mFilterIDs[i].sumEquipCollectScore > num)
					{
						index = i;
						num = this.mFilterIDs[i].sumEquipCollectScore;
					}
					if (this.mFilterIDs[i].sumEquipCollectScore > score && splitLevel == this.mFilterIDs[i].level)
					{
						return this.mFilterIDs[i];
					}
				}
			}
			isBest = true;
			return this.mFilterIDs[index];
		}

		// Token: 0x0600DA17 RID: 55831 RVA: 0x0036D38C File Offset: 0x0036B78C
		public List<EquipHandbookEquipItemData> GetLowestScoreItemList()
		{
			List<EquipHandbookEquipItemData> list = new List<EquipHandbookEquipItemData>();
			EquipHandbookTabCollectionData equipHandbookTabCollectionData = this._findLowestScore(EquipHandbookCollectionTable.eScreenType.eWeapon);
			if (equipHandbookTabCollectionData != null)
			{
				list.Add(equipHandbookTabCollectionData.itemIDs[0]);
			}
			EquipHandbookTabCollectionData equipHandbookTabCollectionData2 = this._findLowestScore(EquipHandbookCollectionTable.eScreenType.eArmor);
			if (equipHandbookTabCollectionData2 != null)
			{
				list.AddRange(equipHandbookTabCollectionData2.itemIDs);
			}
			EquipHandbookTabCollectionData equipHandbookTabCollectionData3 = this._findLowestScore(EquipHandbookCollectionTable.eScreenType.eJewelry);
			if (equipHandbookTabCollectionData3 != null)
			{
				list.AddRange(equipHandbookTabCollectionData3.itemIDs);
			}
			return list;
		}

		// Token: 0x0600DA18 RID: 55832 RVA: 0x0036D3F4 File Offset: 0x0036B7F4
		private EquipHandbookTabCollectionData _findLowestScore(EquipHandbookCollectionTable.eScreenType part)
		{
			int splitLevel = DataManager<EquipHandbookDataManager>.GetInstance().GetSplitLevel(this.mFilterIDs, part);
			for (int i = 0; i < this.mFilterIDs.Count; i++)
			{
				if (this.mFilterIDs[i].partScreenType == part && splitLevel == this.mFilterIDs[i].level)
				{
					return this.mFilterIDs[i];
				}
			}
			return null;
		}

		// Token: 0x0600DA19 RID: 55833 RVA: 0x0036D46B File Offset: 0x0036B86B
		public void AddTabCollectionData(EquipHandbookTabCollectionData data)
		{
			if (data == null)
			{
				return;
			}
			this.mCollectIDs.Add(data);
		}

		// Token: 0x0600DA1A RID: 55834 RVA: 0x0036D480 File Offset: 0x0036B880
		public void SortTabCollectionDatas()
		{
			this.mCollectIDs.Sort();
		}

		// Token: 0x0600DA1B RID: 55835 RVA: 0x0036D490 File Offset: 0x0036B890
		public void CalculateEquipScore()
		{
			if (!this.isShowEquipScore)
			{
				return;
			}
			for (int i = 0; i < this.mFilterIDs.Count; i++)
			{
				EquipHandbookTabCollectionData equipHandbookTabCollectionData = this.mFilterIDs[i];
				if (equipHandbookTabCollectionData != null)
				{
					List<EquipHandbookEquipItemData> itemIDs = equipHandbookTabCollectionData.itemIDs;
					for (int j = 0; j < itemIDs.Count; j++)
					{
						itemIDs[j].CalculateBaseScore();
					}
				}
			}
		}

		// Token: 0x0600DA1C RID: 55836 RVA: 0x0036D502 File Offset: 0x0036B902
		public List<EquipHandbookTabCollectionData> FilterWithCondition()
		{
			this.mFilterIDs.Clear();
			this.mFilterIDs.AddRange(this.mCollectIDs);
			this.mFilterIDs.RemoveAll(new Predicate<EquipHandbookTabCollectionData>(this._filterCondition));
			return this.mFilterIDs;
		}

		// Token: 0x0600DA1D RID: 55837 RVA: 0x0036D53E File Offset: 0x0036B93E
		private bool _filterCondition(EquipHandbookTabCollectionData data)
		{
			return !data.isFitOccupation || (this.isFilterWithLevel && !data.isFitLevel);
		}

		// Token: 0x0600DA1E RID: 55838 RVA: 0x0036D566 File Offset: 0x0036B966
		public List<EquipHandbookTabCollectionData> FilterItemWithCondition()
		{
			this.mFilterIDs.RemoveAll(new Predicate<EquipHandbookTabCollectionData>(this._filterItemCondition));
			return this.mFilterIDs;
		}

		// Token: 0x0600DA1F RID: 55839 RVA: 0x0036D586 File Offset: 0x0036B986
		private bool _filterItemCondition(EquipHandbookTabCollectionData data)
		{
			return data.itemIDs.Count <= 0;
		}

		// Token: 0x17001C45 RID: 7237
		// (get) Token: 0x0600DA20 RID: 55840 RVA: 0x0036D59C File Offset: 0x0036B99C
		// (set) Token: 0x0600DA21 RID: 55841 RVA: 0x0036D5A4 File Offset: 0x0036B9A4
		public ComCommonBind bind { get; set; }

		// Token: 0x0600DA22 RID: 55842 RVA: 0x0036D5AD File Offset: 0x0036B9AD
		public int CompareTo(EquipHandbookTabData other)
		{
			if (this.sortOrder == other.sortOrder)
			{
				return this.id - other.id;
			}
			return this.sortOrder - other.sortOrder;
		}

		// Token: 0x0600DA23 RID: 55843 RVA: 0x0036D5DC File Offset: 0x0036B9DC
		public bool IsContainItem(int itemTableId)
		{
			if (this.mCollectIDs == null || this.mCollectIDs.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.mCollectIDs.Count; i++)
			{
				EquipHandbookTabCollectionData equipHandbookTabCollectionData = this.mCollectIDs[i];
				if (equipHandbookTabCollectionData != null)
				{
					List<EquipHandbookEquipItemData> itemIDs = equipHandbookTabCollectionData.itemIDs;
					if (itemIDs != null && itemIDs.Count > 0)
					{
						for (int j = 0; j < itemIDs.Count; j++)
						{
							EquipHandbookEquipItemData equipHandbookEquipItemData = itemIDs[j];
							if (equipHandbookEquipItemData != null)
							{
								if (equipHandbookEquipItemData.id == itemTableId)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x04008054 RID: 32852
		private List<EquipHandbookTabCollectionData> mFilterIDs = new List<EquipHandbookTabCollectionData>();

		// Token: 0x04008055 RID: 32853
		private List<EquipHandbookTabCollectionData> mCollectIDs = new List<EquipHandbookTabCollectionData>();
	}
}

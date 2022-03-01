using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001944 RID: 6468
	public class MonthCardRewardLockersItem : IComparable<MonthCardRewardLockersItem>
	{
		// Token: 0x0600FB81 RID: 64385 RVA: 0x0044F10B File Offset: 0x0044D50B
		public MonthCardRewardLockersItem(int itemTableId, int subQualityLv, int strengthenLv)
		{
			this.itemdata = ItemDataManager.CreateItemDataFromTable(itemTableId, subQualityLv, strengthenLv);
		}

		// Token: 0x0600FB82 RID: 64386 RVA: 0x0044F124 File Offset: 0x0044D524
		public MonthCardRewardLockersItem(depositItem ritem)
		{
			if (ritem == null)
			{
				return;
			}
			this.createTime = ritem.createTime;
			ItemReward itemReward = ritem.itemReward;
			if (itemReward != null)
			{
				this.itemdata = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, (int)itemReward.qualityLv, (int)itemReward.strength);
				if (this.itemdata != null)
				{
					this.itemdata.GUID = ritem.guid;
					this.itemdata.Count = (int)itemReward.num;
					this.itemdata.EquipType = (EEquipType)itemReward.equipType;
					this.isHignestGradeItem = MonthCardRewardLockersDataManager.IsHighestGradeItem(this.itemdata);
				}
			}
		}

		// Token: 0x0600FB83 RID: 64387 RVA: 0x0044F1C3 File Offset: 0x0044D5C3
		public void Clear()
		{
			this.itemdata = null;
			this.createTime = 0U;
			this.isHignestGradeItem = false;
		}

		// Token: 0x0600FB84 RID: 64388 RVA: 0x0044F1DA File Offset: 0x0044D5DA
		public ulong GetItemGUID()
		{
			if (this.itemdata == null)
			{
				return 0UL;
			}
			return this.itemdata.GUID;
		}

		// Token: 0x0600FB85 RID: 64389 RVA: 0x0044F1F5 File Offset: 0x0044D5F5
		public int GetItemTableId()
		{
			if (this.itemdata == null)
			{
				return 0;
			}
			return this.itemdata.TableID;
		}

		// Token: 0x0600FB86 RID: 64390 RVA: 0x0044F210 File Offset: 0x0044D610
		public void UpdateItem(depositItem ritem)
		{
			ItemReward itemReward = ritem.itemReward;
			if (this.itemdata == null || ritem == null || itemReward == null)
			{
				return;
			}
			if (ritem.guid != this.itemdata.GUID)
			{
				Logger.LogErrorFormat("[MonthCardRewardLockersItem] - UpdateItem guid diff !", new object[0]);
				return;
			}
			if ((ulong)itemReward.id != (ulong)((long)this.itemdata.TableID))
			{
				Logger.LogErrorFormat("[MonthCardRewardLockersItem] - UpdateItem tableid diff !", new object[0]);
				return;
			}
			this.createTime = ritem.createTime;
			this.itemdata.SubQuality = (int)itemReward.qualityLv;
			this.itemdata.StrengthenLevel = (int)itemReward.strength;
			this.itemdata.Count = (int)itemReward.num;
			this.itemdata.EquipType = (EEquipType)itemReward.equipType;
			this.isHignestGradeItem = MonthCardRewardLockersDataManager.IsHighestGradeItem(this.itemdata);
		}

		// Token: 0x0600FB87 RID: 64391 RVA: 0x0044F2F0 File Offset: 0x0044D6F0
		public int CompareTo(MonthCardRewardLockersItem other)
		{
			if (other == null || other.itemdata == null)
			{
				return 1;
			}
			if (this.itemdata == null)
			{
				return 1;
			}
			return other.itemdata.Quality.CompareTo(this.itemdata.Quality) * 2 + other.createTime.CompareTo(this.createTime);
		}

		// Token: 0x04009D2F RID: 40239
		public ItemData itemdata;

		// Token: 0x04009D30 RID: 40240
		public uint createTime;

		// Token: 0x04009D31 RID: 40241
		public bool isHignestGradeItem;
	}
}

using System;

namespace Battle
{
	// Token: 0x0200107D RID: 4221
	public class DungeonItem : IComparable<DungeonItem>
	{
		// Token: 0x17001990 RID: 6544
		// (get) Token: 0x06009F91 RID: 40849 RVA: 0x001FF6E9 File Offset: 0x001FDAE9
		// (set) Token: 0x06009F92 RID: 40850 RVA: 0x001FF6F4 File Offset: 0x001FDAF4
		public int id
		{
			get
			{
				return this.mId;
			}
			set
			{
				this.mId = value;
				this.type = DungeonItem.eType.Invalid;
				try
				{
					this.type = (DungeonItem.eType)Singleton<TableManager>.instance.GetItemConfigID(this.mId);
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
				}
			}
		}

		// Token: 0x17001991 RID: 6545
		// (get) Token: 0x06009F93 RID: 40851 RVA: 0x001FF74C File Offset: 0x001FDB4C
		// (set) Token: 0x06009F94 RID: 40852 RVA: 0x001FF754 File Offset: 0x001FDB54
		public DungeonItem.eType type { get; private set; }

		// Token: 0x06009F95 RID: 40853 RVA: 0x001FF75D File Offset: 0x001FDB5D
		public int CompareTo(DungeonItem item)
		{
			return this.id - item.id;
		}

		// Token: 0x04005805 RID: 22533
		private int mId;

		// Token: 0x04005806 RID: 22534
		public int num;

		// Token: 0x0200107E RID: 4222
		public enum eType
		{
			// Token: 0x04005809 RID: 22537
			Invalid,
			// Token: 0x0400580A RID: 22538
			SmallDrug = 100,
			// Token: 0x0400580B RID: 22539
			MediumDrug,
			// Token: 0x0400580C RID: 22540
			BigDrug,
			// Token: 0x0400580D RID: 22541
			LeiMiDrug,
			// Token: 0x0400580E RID: 22542
			SmallColorlessCrystals = 200,
			// Token: 0x0400580F RID: 22543
			Glod = 300,
			// Token: 0x04005810 RID: 22544
			Ticket,
			// Token: 0x04005811 RID: 22545
			Exp,
			// Token: 0x04005812 RID: 22546
			DeadCoin,
			// Token: 0x04005813 RID: 22547
			MonsterCoin,
			// Token: 0x04005814 RID: 22548
			RebornCoin,
			// Token: 0x04005815 RID: 22549
			Lvl1HPDrug = 400,
			// Token: 0x04005816 RID: 22550
			Lvl2HPDrug,
			// Token: 0x04005817 RID: 22551
			Lvl3HPDrug,
			// Token: 0x04005818 RID: 22552
			Lvl4HPDrug,
			// Token: 0x04005819 RID: 22553
			Lvl5HPDrug,
			// Token: 0x0400581A RID: 22554
			Lvl6HPDrug,
			// Token: 0x0400581B RID: 22555
			Lvl1MPDrug = 500,
			// Token: 0x0400581C RID: 22556
			Lvl2MPDrug,
			// Token: 0x0400581D RID: 22557
			Lvl3MPDrug,
			// Token: 0x0400581E RID: 22558
			Lvl4MPDrug,
			// Token: 0x0400581F RID: 22559
			Lvl5MPDrug,
			// Token: 0x04005820 RID: 22560
			Lvl6MPDrug
		}
	}
}

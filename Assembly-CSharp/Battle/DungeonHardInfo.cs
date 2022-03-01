using System;

namespace Battle
{
	// Token: 0x0200108B RID: 4235
	public class DungeonHardInfo : IComparable<DungeonHardInfo>
	{
		// Token: 0x06009FAC RID: 40876 RVA: 0x001FFB0F File Offset: 0x001FDF0F
		public int CompareTo(DungeonHardInfo other)
		{
			return this.id - other.id;
		}

		// Token: 0x0400586C RID: 22636
		public int id;

		// Token: 0x0400586D RID: 22637
		public int unlockedHardType;
	}
}

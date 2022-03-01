using System;

namespace Battle
{
	// Token: 0x0200108C RID: 4236
	public class DungeonOpenInfo : IComparable<DungeonOpenInfo>
	{
		// Token: 0x06009FAE RID: 40878 RVA: 0x001FFB26 File Offset: 0x001FDF26
		public int CompareTo(DungeonOpenInfo other)
		{
			return this.id - other.id;
		}

		// Token: 0x0400586E RID: 22638
		public int id;

		// Token: 0x0400586F RID: 22639
		public bool isHell;
	}
}

using System;

namespace Battle
{
	// Token: 0x0200108A RID: 4234
	public class DungeonInfo : IComparable<DungeonInfo>
	{
		// Token: 0x06009FAA RID: 40874 RVA: 0x001FFAF8 File Offset: 0x001FDEF8
		public int CompareTo(DungeonInfo other)
		{
			return this.id - other.id;
		}

		// Token: 0x04005869 RID: 22633
		public int id;

		// Token: 0x0400586A RID: 22634
		public int bestScore;

		// Token: 0x0400586B RID: 22635
		public int bestRecordTime;
	}
}

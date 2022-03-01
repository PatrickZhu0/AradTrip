using System;
using GameClient;

namespace Battle
{
	// Token: 0x02001081 RID: 4225
	public class DungeonDropItem : IComparable<DungeonDropItem>
	{
		// Token: 0x06009F99 RID: 40857 RVA: 0x001FF80F File Offset: 0x001FDC0F
		public int CompareTo(DungeonDropItem other)
		{
			return this.id - other.id;
		}

		// Token: 0x0400582D RID: 22573
		public int id = -1;

		// Token: 0x0400582E RID: 22574
		public int typeId = -1;

		// Token: 0x0400582F RID: 22575
		public int num = -1;

		// Token: 0x04005830 RID: 22576
		public bool isDouble;

		// Token: 0x04005831 RID: 22577
		public int strenthLevel = -1;

		// Token: 0x04005832 RID: 22578
		public EEquipType equipType;
	}
}

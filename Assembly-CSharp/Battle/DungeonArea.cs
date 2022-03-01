using System;
using System.Collections.Generic;

namespace Battle
{
	// Token: 0x02001086 RID: 4230
	public class DungeonArea : IComparable<DungeonArea>
	{
		// Token: 0x06009FA2 RID: 40866 RVA: 0x001FF96E File Offset: 0x001FDD6E
		public int CompareTo(DungeonArea other)
		{
			return this.id - other.id;
		}

		// Token: 0x06009FA3 RID: 40867 RVA: 0x001FF980 File Offset: 0x001FDD80
		public DungeonArea Duplicate()
		{
			return new DungeonArea
			{
				id = this.id,
				monsters = new List<DungeonMonster>(this.monsters),
				destructs = new List<DungeonMonster>(this.destructs),
				regions = new List<int>(this.regions)
			};
		}

		// Token: 0x0400584C RID: 22604
		public int id = -1;

		// Token: 0x0400584D RID: 22605
		public List<DungeonMonster> monsters = new List<DungeonMonster>();

		// Token: 0x0400584E RID: 22606
		public List<DungeonMonster> destructs = new List<DungeonMonster>();

		// Token: 0x0400584F RID: 22607
		public List<int> regions = new List<int>();
	}
}

using System;
using System.Collections.Generic;

namespace Battle
{
	// Token: 0x02001082 RID: 4226
	public class DungeonMonster : IComparable<DungeonMonster>
	{
		// Token: 0x06009F9B RID: 40859 RVA: 0x001FF871 File Offset: 0x001FDC71
		public int CompareTo(DungeonMonster other)
		{
			return this.id - other.id;
		}

		// Token: 0x04005833 RID: 22579
		public int id = -1;

		// Token: 0x04005834 RID: 22580
		public int pointId = -1;

		// Token: 0x04005835 RID: 22581
		public CrypticInt32 typeId = -1;

		// Token: 0x04005836 RID: 22582
		public List<DungeonDropItem> dropItems = new List<DungeonDropItem>();

		// Token: 0x04005837 RID: 22583
		public List<int> prefixes = new List<int>();

		// Token: 0x04005838 RID: 22584
		public int summonerId = -1;

		// Token: 0x04005839 RID: 22585
		public List<DungeonMonster> summonerMonsters;

		// Token: 0x0400583A RID: 22586
		public bool removed;

		// Token: 0x0400583B RID: 22587
		public DEntityType monsterType = DEntityType.MONSTER;
	}
}

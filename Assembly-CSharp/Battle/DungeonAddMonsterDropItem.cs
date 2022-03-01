using System;
using System.Collections.Generic;

namespace Battle
{
	// Token: 0x02001087 RID: 4231
	public class DungeonAddMonsterDropItem : IComparable<DungeonAddMonsterDropItem>
	{
		// Token: 0x06009FA5 RID: 40869 RVA: 0x001FF9ED File Offset: 0x001FDDED
		public int CompareTo(DungeonAddMonsterDropItem other)
		{
			return this.monsterId - other.monsterId;
		}

		// Token: 0x04005850 RID: 22608
		public int monsterId = -1;

		// Token: 0x04005851 RID: 22609
		public List<DungeonDropItem> dropItems = new List<DungeonDropItem>();
	}
}

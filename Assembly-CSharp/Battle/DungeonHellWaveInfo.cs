using System;
using System.Collections.Generic;

namespace Battle
{
	// Token: 0x02001083 RID: 4227
	public class DungeonHellWaveInfo : IComparable<DungeonHellWaveInfo>
	{
		// Token: 0x06009F9D RID: 40861 RVA: 0x001FF893 File Offset: 0x001FDC93
		public int CompareTo(DungeonHellWaveInfo other)
		{
			return this.wave - other.wave;
		}

		// Token: 0x06009F9E RID: 40862 RVA: 0x001FF8A4 File Offset: 0x001FDCA4
		public DungeonHellWaveInfo Duplicate()
		{
			return new DungeonHellWaveInfo();
		}

		// Token: 0x0400583C RID: 22588
		public int wave;

		// Token: 0x0400583D RID: 22589
		public List<DungeonMonster> monsters = new List<DungeonMonster>();
	}
}

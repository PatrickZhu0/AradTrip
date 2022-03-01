using System;
using System.Collections.Generic;
using Protocol;

namespace Battle
{
	// Token: 0x02001085 RID: 4229
	public class DungeonHellInfo
	{
		// Token: 0x06009FA0 RID: 40864 RVA: 0x001FF8D8 File Offset: 0x001FDCD8
		public DungeonHellInfo Duplicate()
		{
			return new DungeonHellInfo
			{
				mode = this.mode,
				areaId = this.areaId,
				waveInfos = new List<DungeonHellWaveInfo>(this.waveInfos),
				dropItems = new List<DungeonDropItem>(this.dropItems),
				isFinish = this.isFinish,
				state = this.state
			};
		}

		// Token: 0x04005846 RID: 22598
		public DungeonHellMode mode;

		// Token: 0x04005847 RID: 22599
		public int areaId;

		// Token: 0x04005848 RID: 22600
		public List<DungeonHellWaveInfo> waveInfos = new List<DungeonHellWaveInfo>();

		// Token: 0x04005849 RID: 22601
		public List<DungeonDropItem> dropItems = new List<DungeonDropItem>();

		// Token: 0x0400584A RID: 22602
		public bool isFinish;

		// Token: 0x0400584B RID: 22603
		public eDungeonHellState state;
	}
}

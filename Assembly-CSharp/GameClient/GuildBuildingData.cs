using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001264 RID: 4708
	internal class GuildBuildingData
	{
		// Token: 0x04006602 RID: 26114
		public GuildBuildingType eType;

		// Token: 0x04006603 RID: 26115
		public int nLevel;

		// Token: 0x04006604 RID: 26116
		public int nMaxLevel;

		// Token: 0x04006605 RID: 26117
		public int nUnlockMaincityLevel;

		// Token: 0x04006606 RID: 26118
		public int nUpgradeCost;

		// Token: 0x02001265 RID: 4709
		// (Invoke) Token: 0x0600B46E RID: 46190
		public delegate bool CheckRedPoint();
	}
}

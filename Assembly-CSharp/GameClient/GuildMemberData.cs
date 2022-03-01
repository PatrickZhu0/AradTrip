using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001261 RID: 4705
	internal class GuildMemberData
	{
		// Token: 0x040065EF RID: 26095
		public ulong uGUID;

		// Token: 0x040065F0 RID: 26096
		public int nJobID;

		// Token: 0x040065F1 RID: 26097
		public string strName;

		// Token: 0x040065F2 RID: 26098
		public int nLevel;

		// Token: 0x040065F3 RID: 26099
		public EGuildDuty eGuildDuty;

		// Token: 0x040065F4 RID: 26100
		public int nContribution;

		// Token: 0x040065F5 RID: 26101
		public uint uOffLineTime;

		// Token: 0x040065F6 RID: 26102
		public uint uActiveDegree;

		// Token: 0x040065F7 RID: 26103
		public string remark;

		// Token: 0x040065F8 RID: 26104
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();

		// Token: 0x040065F9 RID: 26105
		public uint vipLevel;

		// Token: 0x040065FA RID: 26106
		public uint seasonLevel;
	}
}

using System;
using Protocol;

namespace _Settings
{
	// Token: 0x02001A27 RID: 6695
	public class RoleInfoSettingsData
	{
		// Token: 0x06010701 RID: 67329 RVA: 0x004A01E0 File Offset: 0x0049E5E0
		public bool HasGuild()
		{
			return this.guildName != null && this.guildName.Length > 1;
		}

		// Token: 0x0400A71E RID: 42782
		public PkStatisticInfo m_pkInfo;

		// Token: 0x0400A71F RID: 42783
		public uint pkValue;

		// Token: 0x0400A720 RID: 42784
		public uint matchScore;

		// Token: 0x0400A721 RID: 42785
		public string guildName;

		// Token: 0x0400A722 RID: 42786
		public int guildJob;
	}
}

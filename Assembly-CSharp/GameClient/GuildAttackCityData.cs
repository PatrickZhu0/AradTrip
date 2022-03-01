using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001269 RID: 4713
	public class GuildAttackCityData
	{
		// Token: 0x0600B475 RID: 46197 RVA: 0x002858F4 File Offset: 0x00283CF4
		public void ClearData()
		{
			this.info.terrId = 0;
			this.info.guildName = string.Empty;
			this.info.enrollSize = 0U;
			this.enrollGuildId = 0UL;
			this.enrollGuildName = string.Empty;
			this.enrollGuildLevel = 0;
			this.enrollGuildleaderName = string.Empty;
			this.itemId = 0U;
			this.itemNum = 0U;
		}

		// Token: 0x04006638 RID: 26168
		public GuildTerritoryBaseInfo info = new GuildTerritoryBaseInfo();

		// Token: 0x04006639 RID: 26169
		public ulong enrollGuildId;

		// Token: 0x0400663A RID: 26170
		public string enrollGuildName;

		// Token: 0x0400663B RID: 26171
		public byte enrollGuildLevel;

		// Token: 0x0400663C RID: 26172
		public string enrollGuildleaderName;

		// Token: 0x0400663D RID: 26173
		public uint itemId;

		// Token: 0x0400663E RID: 26174
		public uint itemNum;
	}
}

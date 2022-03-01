using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001306 RID: 4870
	internal class TeamMember
	{
		// Token: 0x0600BD2A RID: 48426 RVA: 0x002C4014 File Offset: 0x002C2414
		public void ClearPlayerInfo()
		{
			this.id = 0UL;
			this.guildid = 0UL;
			this.name = string.Empty;
			this.level = 0;
			this.viplevel = 0;
			this.dungeonLeftCount = 0;
			this.occu = 0;
			this.isOnline = false;
			this.isPrepared = false;
			this.isAssist = false;
			this.isBuzy = false;
			this.avatarInfo = null;
			this.resistMagicValue = 0U;
		}

		// Token: 0x0600BD2B RID: 48427 RVA: 0x002C4082 File Offset: 0x002C2482
		public void Debug()
		{
		}

		// Token: 0x04006A50 RID: 27216
		public ulong id;

		// Token: 0x04006A51 RID: 27217
		public ulong guildid;

		// Token: 0x04006A52 RID: 27218
		public string name;

		// Token: 0x04006A53 RID: 27219
		public ushort level;

		// Token: 0x04006A54 RID: 27220
		public ushort viplevel;

		// Token: 0x04006A55 RID: 27221
		public byte occu;

		// Token: 0x04006A56 RID: 27222
		public bool isOnline;

		// Token: 0x04006A57 RID: 27223
		public bool isPrepared;

		// Token: 0x04006A58 RID: 27224
		public bool isBuzy;

		// Token: 0x04006A59 RID: 27225
		public bool isAssist;

		// Token: 0x04006A5A RID: 27226
		public int dungeonLeftCount;

		// Token: 0x04006A5B RID: 27227
		public PlayerAvatar avatarInfo;

		// Token: 0x04006A5C RID: 27228
		public uint resistMagicValue;

		// Token: 0x04006A5D RID: 27229
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}

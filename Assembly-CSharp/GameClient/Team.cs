using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001307 RID: 4871
	internal class Team
	{
		// Token: 0x0600BD2D RID: 48429 RVA: 0x002C4098 File Offset: 0x002C2498
		public void Debug()
		{
			for (int i = 0; i < this.members.Length; i++)
			{
				TeamMember teamMember = this.members[i];
				if (teamMember != null)
				{
					teamMember.Debug();
				}
			}
		}

		// Token: 0x04006A5E RID: 27230
		public uint teamID;

		// Token: 0x04006A5F RID: 27231
		public TeammemberBaseInfo leaderInfo;

		// Token: 0x04006A60 RID: 27232
		public byte currentMemberCount;

		// Token: 0x04006A61 RID: 27233
		public byte maxMemberCount;

		// Token: 0x04006A62 RID: 27234
		public uint autoAgree;

		// Token: 0x04006A63 RID: 27235
		public uint teamDungeonID;

		// Token: 0x04006A64 RID: 27236
		public TeamMember[] members = new TeamMember[3];
	}
}

using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013F8 RID: 5112
	internal class MenuData
	{
		// Token: 0x0600C61F RID: 50719 RVA: 0x002FCFB6 File Offset: 0x002FB3B6
		public bool HasGuild()
		{
			return this.guildName != null && this.guildName.Length > 0;
		}

		// Token: 0x0600C620 RID: 50720 RVA: 0x002FCFD4 File Offset: 0x002FB3D4
		public bool HasVip()
		{
			return this.vip > 0;
		}

		// Token: 0x0600C621 RID: 50721 RVA: 0x002FCFDF File Offset: 0x002FB3DF
		public bool HasAdventureTeam()
		{
			return this.adventureTeamName != null && this.adventureTeamName.Length > 0;
		}

		// Token: 0x04007191 RID: 29073
		public Vector3 kWorldPos;

		// Token: 0x04007192 RID: 29074
		public string name;

		// Token: 0x04007193 RID: 29075
		public int level;

		// Token: 0x04007194 RID: 29076
		public int vip;

		// Token: 0x04007195 RID: 29077
		public string guildName;

		// Token: 0x04007196 RID: 29078
		public int jobID;

		// Token: 0x04007197 RID: 29079
		public int pkLevel;

		// Token: 0x04007198 RID: 29080
		public List<MenuItem> items;

		// Token: 0x04007199 RID: 29081
		public int ZoneID;

		// Token: 0x0400719A RID: 29082
		public string adventureTeamName;

		// Token: 0x0400719B RID: 29083
		public PlayerWearedTitleInfo WearedTitleInfo;

		// Token: 0x0400719C RID: 29084
		public int guildLv;
	}
}

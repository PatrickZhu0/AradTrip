using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020011D2 RID: 4562
	public class ExpeditionMapModel
	{
		// Token: 0x0600AEFE RID: 44798 RVA: 0x00263F84 File Offset: 0x00262384
		public ExpeditionMapModel(byte id, string name, int playerLevel, int teamLevel, int rolesNum, string time, string map, string minimap)
		{
			this.mapName = name;
			this.playerLevelLimit = playerLevel;
			this.adventureTeamLevelLimit = teamLevel;
			this.rolesCapacity = rolesNum;
			this.expeditionTime = time;
			this.mapImagePath = map;
			this.miniMapImagePath = minimap;
			this.rewardList = new List<ExpeditionReward>();
			this.mapNetInfo = new ExpeditionMapNetInfo(id);
		}

		// Token: 0x0600AEFF RID: 44799 RVA: 0x00263FE4 File Offset: 0x002623E4
		public void Clear()
		{
			if (this.rewardList != null)
			{
				this.rewardList.Clear();
			}
			if (this.mapNetInfo != null)
			{
				this.mapNetInfo.Clear();
			}
		}

		// Token: 0x040061F5 RID: 25077
		public string mapName;

		// Token: 0x040061F6 RID: 25078
		public int playerLevelLimit;

		// Token: 0x040061F7 RID: 25079
		public int adventureTeamLevelLimit;

		// Token: 0x040061F8 RID: 25080
		public int rolesCapacity;

		// Token: 0x040061F9 RID: 25081
		public string expeditionTime;

		// Token: 0x040061FA RID: 25082
		public string mapImagePath;

		// Token: 0x040061FB RID: 25083
		public string miniMapImagePath;

		// Token: 0x040061FC RID: 25084
		public List<ExpeditionReward> rewardList;

		// Token: 0x040061FD RID: 25085
		public ExpeditionMapNetInfo mapNetInfo;
	}
}

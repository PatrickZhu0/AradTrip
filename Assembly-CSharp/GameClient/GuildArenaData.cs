using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020015EC RID: 5612
	public class GuildArenaData
	{
		// Token: 0x0600DBA5 RID: 56229 RVA: 0x0037594D File Offset: 0x00373D4D
		public void Clear()
		{
			this.SceneSubType = CitySceneTable.eSceneSubType.NULL;
			this.CurrentSceneID = 0;
			this.TargetTownSceneID = 0;
		}

		// Token: 0x0400816A RID: 33130
		public CitySceneTable.eSceneSubType SceneSubType;

		// Token: 0x0400816B RID: 33131
		public int CurrentSceneID;

		// Token: 0x0400816C RID: 33132
		public int TargetTownSceneID;
	}
}

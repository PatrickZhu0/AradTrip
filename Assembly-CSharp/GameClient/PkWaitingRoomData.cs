using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020019A0 RID: 6560
	public class PkWaitingRoomData
	{
		// Token: 0x0600FF60 RID: 65376 RVA: 0x0046BCAD File Offset: 0x0046A0AD
		public void Clear()
		{
			this.SceneSubType = CitySceneTable.eSceneSubType.NULL;
			this.CurrentSceneID = 0;
			this.TargetTownSceneID = 0;
		}

		// Token: 0x0400A116 RID: 41238
		public CitySceneTable.eSceneSubType SceneSubType;

		// Token: 0x0400A117 RID: 41239
		public int CurrentSceneID;

		// Token: 0x0400A118 RID: 41240
		public int TargetTownSceneID;
	}
}

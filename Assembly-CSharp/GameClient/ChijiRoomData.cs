using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001125 RID: 4389
	public class ChijiRoomData
	{
		// Token: 0x0600A6AA RID: 42666 RVA: 0x0022A604 File Offset: 0x00228A04
		public void Clear()
		{
			this.SceneSubType = CitySceneTable.eSceneSubType.NULL;
			this.CurrentSceneID = 0;
			this.TargetTownSceneID = 0;
		}

		// Token: 0x04005D3D RID: 23869
		public CitySceneTable.eSceneSubType SceneSubType;

		// Token: 0x04005D3E RID: 23870
		public int CurrentSceneID;

		// Token: 0x04005D3F RID: 23871
		public int TargetTownSceneID;
	}
}

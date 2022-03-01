using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001363 RID: 4963
	public class FairDueliRoomData
	{
		// Token: 0x0600C0BF RID: 49343 RVA: 0x002DAD55 File Offset: 0x002D9155
		public void Clear()
		{
			this.SceneSubType = CitySceneTable.eSceneSubType.NULL;
			this.CurrentSceneID = 0;
			this.TargetTownSceneID = 0;
		}

		// Token: 0x04006CE7 RID: 27879
		public CitySceneTable.eSceneSubType SceneSubType;

		// Token: 0x04006CE8 RID: 27880
		public int CurrentSceneID;

		// Token: 0x04006CE9 RID: 27881
		public int TargetTownSceneID;
	}
}

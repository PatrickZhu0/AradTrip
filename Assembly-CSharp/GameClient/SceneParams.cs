using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011A0 RID: 4512
	public class SceneParams
	{
		// Token: 0x0600AC9D RID: 44189 RVA: 0x0025329B File Offset: 0x0025169B
		public SceneParams()
		{
		}

		// Token: 0x0600AC9E RID: 44190 RVA: 0x002532A3 File Offset: 0x002516A3
		public SceneParams(int currentSceneId, int currentDoorId, int targetSceneId, int targetDoorId)
		{
			this.currSceneID = currentSceneId;
			this.currDoorID = currentDoorId;
			this.targetSceneID = targetSceneId;
			this.targetDoorID = targetDoorId;
		}

		// Token: 0x040060D3 RID: 24787
		public int currSceneID;

		// Token: 0x040060D4 RID: 24788
		public int currDoorID;

		// Token: 0x040060D5 RID: 24789
		public int targetSceneID;

		// Token: 0x040060D6 RID: 24790
		public int targetDoorID;

		// Token: 0x040060D7 RID: 24791
		public SceneParams.OnSceneLoadFinish onSceneLoadFinish;

		// Token: 0x040060D8 RID: 24792
		public eSceneChangeType type;

		// Token: 0x040060D9 RID: 24793
		public Vector3 birthPostion;

		// Token: 0x040060DA RID: 24794
		public int iParam0;

		// Token: 0x040060DB RID: 24795
		public int iParam1;

		// Token: 0x020011A1 RID: 4513
		// (Invoke) Token: 0x0600ACA0 RID: 44192
		public delegate void OnSceneLoadFinish();
	}
}

using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015DE RID: 5598
	public struct UnlockData
	{
		// Token: 0x0600DB46 RID: 56134 RVA: 0x00374425 File Offset: 0x00372825
		public void ClearData()
		{
			this.FuncUnlockID = 0;
			this.pos = new Vector3(0f, 0f, 0f);
		}

		// Token: 0x04008131 RID: 33073
		public int FuncUnlockID;

		// Token: 0x04008132 RID: 33074
		public Vector3 pos;
	}
}

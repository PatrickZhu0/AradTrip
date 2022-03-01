using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001138 RID: 4408
	public class PoisonRingInfo
	{
		// Token: 0x0600A765 RID: 42853 RVA: 0x0022E918 File Offset: 0x0022CD18
		public void Reset()
		{
			this.center = Vector2.zero;
			this.radius = 0f;
			this.durTime = 0f;
			this.shrinkTime = 0f;
			this.lastRadius = 0f;
			this.lastCenter = Vector2.zero;
			this.nextStageCenter = Vector2.zero;
			this.nextStageRadius = 0f;
		}

		// Token: 0x04005DB8 RID: 23992
		public Vector2 center = Vector2.zero;

		// Token: 0x04005DB9 RID: 23993
		public float radius;

		// Token: 0x04005DBA RID: 23994
		public float durTime;

		// Token: 0x04005DBB RID: 23995
		public float shrinkTime;

		// Token: 0x04005DBC RID: 23996
		public float lastRadius;

		// Token: 0x04005DBD RID: 23997
		public Vector2 lastCenter = Vector2.zero;

		// Token: 0x04005DBE RID: 23998
		public Vector2 nextStageCenter = Vector2.zero;

		// Token: 0x04005DBF RID: 23999
		public float nextStageRadius;
	}
}

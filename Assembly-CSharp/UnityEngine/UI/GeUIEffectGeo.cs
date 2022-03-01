using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D3E RID: 3390
	public class GeUIEffectGeo
	{
		// Token: 0x06008A14 RID: 35348 RVA: 0x0019411C File Offset: 0x0019251C
		public GeUIEffectGeo(int vertices)
		{
			if (vertices < 4)
			{
				vertices = 4;
			}
			this.VertexNum = vertices;
			this.Pos = new Vector2[vertices];
			this.UV = new Vector2[vertices];
			this.Color = Color.white;
			this.UnderUsed = false;
		}

		// Token: 0x040043FA RID: 17402
		public Vector2[] Pos;

		// Token: 0x040043FB RID: 17403
		public Vector2[] UV;

		// Token: 0x040043FC RID: 17404
		public Color Color;

		// Token: 0x040043FD RID: 17405
		public int VertexNum;

		// Token: 0x040043FE RID: 17406
		public bool UnderUsed;
	}
}

using System;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02000F97 RID: 3991
	[ExecuteInEditMode]
	public class TriangleGraph : Graphic
	{
		// Token: 0x06009A53 RID: 39507 RVA: 0x001DCF18 File Offset: 0x001DB318
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			Color32 color = this.color;
			vh.AddVert(this.p0.anchoredPosition3D, color, new Vector2(0f, 0f));
			vh.AddVert(this.p1.anchoredPosition3D, color, new Vector2(0f, 1f));
			vh.AddVert(this.p2.anchoredPosition3D, color, new Vector2(1f, 1f));
			vh.AddTriangle(0, 1, 2);
		}

		// Token: 0x04004FD9 RID: 20441
		public RectTransform p0;

		// Token: 0x04004FDA RID: 20442
		public RectTransform p1;

		// Token: 0x04004FDB RID: 20443
		public RectTransform p2;
	}
}

using System;
using System.Collections.Generic;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AEB RID: 19179
	[AddComponentMenu("UI/Effects/Extensions/Gradient")]
	public class Gradient : BaseMeshEffect
	{
		// Token: 0x0601BE6D RID: 114285 RVA: 0x00889792 File Offset: 0x00887B92
		protected override void Start()
		{
			this.targetGraphic = base.GetComponent<Graphic>();
			if (this.targetGraphic)
			{
				this.color = this.targetGraphic.color;
			}
		}

		// Token: 0x0601BE6E RID: 114286 RVA: 0x008897C4 File Offset: 0x00887BC4
		public override void ModifyMesh(VertexHelper vh)
		{
			int currentVertCount = vh.currentVertCount;
			if (!this.IsActive() || currentVertCount == 0)
			{
				return;
			}
			if (this.targetGraphic == null)
			{
				this.targetGraphic = base.GetComponent<Graphic>();
			}
			if (this.targetGraphic)
			{
				this.color = this.targetGraphic.color;
			}
			List<UIVertex> list = new List<UIVertex>();
			vh.GetUIVertexStream(list);
			UIVertex uivertex = default(UIVertex);
			if (this.gradientMode == GradientMode.Global)
			{
				if (this.gradientDir == GradientDir.DiagonalLeftToRight || this.gradientDir == GradientDir.DiagonalRightToLeft)
				{
					this.gradientDir = GradientDir.Vertical;
				}
				float num = (this.gradientDir != GradientDir.Vertical) ? list[list.Count - 1].position.x : list[list.Count - 1].position.y;
				float num2 = (this.gradientDir != GradientDir.Vertical) ? list[0].position.x : list[0].position.y;
				float num3 = num2 - num;
				try
				{
					for (int i = 0; i < currentVertCount; i++)
					{
						vh.PopulateUIVertex(ref uivertex, i);
						if (this.overwriteAllColor || !(uivertex.color != this.color))
						{
							uivertex.color *= Color.Lerp(this.vertex2, this.vertex1, (((this.gradientDir != GradientDir.Vertical) ? uivertex.position.x : uivertex.position.y) - num) / num3);
							vh.SetUIVertex(uivertex, i);
						}
					}
				}
				catch (Exception ex)
				{
				}
			}
			else
			{
				try
				{
					for (int j = 0; j < currentVertCount; j++)
					{
						vh.PopulateUIVertex(ref uivertex, j);
						if (this.overwriteAllColor || this.CompareCarefully(uivertex.color, this.color))
						{
							switch (this.gradientDir)
							{
							case GradientDir.Vertical:
								uivertex.color *= ((j % 4 != 0 && (j - 1) % 4 != 0) ? this.vertex2 : this.vertex1);
								break;
							case GradientDir.Horizontal:
								uivertex.color *= ((j % 4 != 0 && (j - 3) % 4 != 0) ? this.vertex2 : this.vertex1);
								break;
							case GradientDir.DiagonalLeftToRight:
								uivertex.color *= ((j % 4 != 0) ? (((j - 2) % 4 != 0) ? Color.Lerp(this.vertex2, this.vertex1, 0.5f) : this.vertex2) : this.vertex1);
								break;
							case GradientDir.DiagonalRightToLeft:
								uivertex.color *= (((j - 1) % 4 != 0) ? (((j - 3) % 4 != 0) ? Color.Lerp(this.vertex2, this.vertex1, 0.5f) : this.vertex2) : this.vertex1);
								break;
							}
							vh.SetUIVertex(uivertex, j);
						}
					}
				}
				catch (Exception ex2)
				{
				}
			}
		}

		// Token: 0x0601BE6F RID: 114287 RVA: 0x00889BBC File Offset: 0x00887FBC
		private bool CompareCarefully(Color col1, Color col2)
		{
			return Mathf.Abs(col1.r - col2.r) < 0.003f && Mathf.Abs(col1.g - col2.g) < 0.003f && Mathf.Abs(col1.b - col2.b) < 0.003f && Mathf.Abs(col1.a - col2.a) < 0.003f;
		}

		// Token: 0x04013733 RID: 79667
		public GradientMode gradientMode;

		// Token: 0x04013734 RID: 79668
		public GradientDir gradientDir;

		// Token: 0x04013735 RID: 79669
		public bool overwriteAllColor;

		// Token: 0x04013736 RID: 79670
		public Color vertex1 = Color.white;

		// Token: 0x04013737 RID: 79671
		public Color vertex2 = Color.black;

		// Token: 0x04013738 RID: 79672
		private Graphic targetGraphic;

		// Token: 0x04013739 RID: 79673
		private Color color;
	}
}

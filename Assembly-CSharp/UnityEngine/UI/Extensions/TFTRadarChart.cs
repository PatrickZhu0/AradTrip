using System;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02000D9D RID: 3485
	[AddComponentMenu("UI/Extensions/Test")]
	public class TFTRadarChart : MaskableGraphic
	{
		// Token: 0x06008D2C RID: 36140 RVA: 0x001A393C File Offset: 0x001A1D3C
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			Vector2 size = base.GetComponent<RectTransform>().rect.size / 2f;
			vh.Clear();
			int num = this.values.Length;
			for (int i = 0; i < num; i++)
			{
				Vector2 vector = this.GetPoint(size, i) * this.values[i];
				Vector2 vector2 = (!this.isFill) ? (vector * this.fillPercent) : Vector2.zero;
				Vector2 vector3 = (i + 1 < num) ? (this.GetPoint(size, i + 1) * this.values[i + 1]) : (this.GetPoint(size, 0) * this.values[0]);
				Vector2 vector4 = (!this.isFill) ? (vector3 * this.fillPercent) : Vector2.zero;
				vh.AddUIVertexQuad(this.GetQuad(new Vector2[]
				{
					vector,
					vector2,
					vector4,
					vector3
				}));
				if (this.useStateLine)
				{
					if (i != 0)
					{
						Vector2 end = this.GetPoint(size, i) * this.lineLength;
						Vector2 zero = Vector2.zero;
						vh.AddUIVertexQuad(this.GetLine(zero, end));
					}
					if (i + 1 == num)
					{
						Vector2 end2 = this.GetPoint(size, 0) * this.lineLength;
						Vector2 zero2 = Vector2.zero;
						vh.AddUIVertexQuad(this.GetLine(zero2, end2));
					}
				}
			}
		}

		// Token: 0x06008D2D RID: 36141 RVA: 0x001A3AE4 File Offset: 0x001A1EE4
		private UIVertex[] GetLine(Vector2 start, Vector2 end)
		{
			UIVertex[] array = new UIVertex[4];
			Vector2[] array2 = new Vector2[]
			{
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f)
			};
			Vector2 vector = end - start;
			Vector2 vector2 = (vector.y != 0f) ? new Vector2(1f, -vector.x / vector.y) : new Vector2(0f, 1f);
			vector2.Normalize();
			vector2 *= this.lineWidth / 2f;
			Vector2[] array3 = new Vector2[]
			{
				start + vector2,
				end + vector2,
				end - vector2,
				start - vector2
			};
			for (int i = 0; i < 4; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = this.lineColor;
				simpleVert.position = array3[i];
				simpleVert.uv0 = array2[i];
				array[i] = simpleVert;
			}
			return array;
		}

		// Token: 0x06008D2E RID: 36142 RVA: 0x001A3C94 File Offset: 0x001A2094
		private Vector2 GetPoint(Vector2 size, int i)
		{
			int num = this.values.Length;
			float num2 = 360f / (float)num * (float)i + this.angleOffset;
			float num3 = Mathf.Sin(num2 * 0.017453292f);
			float num4 = Mathf.Cos(num2 * 0.017453292f);
			return new Vector2(size.x * num4, size.y * num3);
		}

		// Token: 0x06008D2F RID: 36143 RVA: 0x001A3CF0 File Offset: 0x001A20F0
		private UIVertex[] GetQuad(params Vector2[] vertPos)
		{
			UIVertex[] array = new UIVertex[4];
			Vector2[] array2 = new Vector2[]
			{
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f)
			};
			for (int i = 0; i < 4; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = this.color;
				simpleVert.position = vertPos[i];
				simpleVert.uv0 = array2[i];
				array[i] = simpleVert;
			}
			return array;
		}

		// Token: 0x040045EE RID: 17902
		public bool isFill = true;

		// Token: 0x040045EF RID: 17903
		[Range(0f, 0.99f)]
		public float fillPercent = 0.8f;

		// Token: 0x040045F0 RID: 17904
		[Range(0f, 1f)]
		public float[] values;

		// Token: 0x040045F1 RID: 17905
		[Range(0f, 360f)]
		public float angleOffset;

		// Token: 0x040045F2 RID: 17906
		public bool useStateLine = true;

		// Token: 0x040045F3 RID: 17907
		public Color lineColor = Color.white;

		// Token: 0x040045F4 RID: 17908
		public float lineWidth = 0.5f;

		// Token: 0x040045F5 RID: 17909
		[Range(0f, 1f)]
		public float lineLength = 0.8f;
	}
}

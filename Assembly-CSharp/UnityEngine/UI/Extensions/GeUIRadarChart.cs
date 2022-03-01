using System;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02000D98 RID: 3480
	[AddComponentMenu("UI/RadarChart")]
	public class GeUIRadarChart : MaskableGraphic
	{
		// Token: 0x06008CED RID: 36077 RVA: 0x001A2790 File Offset: 0x001A0B90
		public void Refresh()
		{
			this.SetVerticesDirty();
		}

		// Token: 0x06008CEE RID: 36078 RVA: 0x001A2798 File Offset: 0x001A0B98
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

		// Token: 0x06008CEF RID: 36079 RVA: 0x001A2940 File Offset: 0x001A0D40
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

		// Token: 0x06008CF0 RID: 36080 RVA: 0x001A2AF0 File Offset: 0x001A0EF0
		private Vector2 GetPoint(Vector2 size, int i)
		{
			int num = this.values.Length;
			float num2 = 360f / (float)num * (float)i + this.angleOffset;
			float num3 = Mathf.Sin(num2 * 0.017453292f);
			float num4 = Mathf.Cos(num2 * 0.017453292f);
			return new Vector2(size.x * num4, size.y * num3);
		}

		// Token: 0x06008CF1 RID: 36081 RVA: 0x001A2B4C File Offset: 0x001A0F4C
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
			array[1].color = this.centerColor;
			array[2].color = this.centerColor;
			return array;
		}

		// Token: 0x06008CF2 RID: 36082 RVA: 0x001A2C64 File Offset: 0x001A1064
		protected void _GenLine(Vector2 begin, Vector2 end, float width, ref UIVertex[] vertData)
		{
			if (vertData.Length == 8)
			{
				Vector2 normalized = new Vector3(end.x - begin.x, end.y - begin.y).normalized;
				float num = Vector2.Distance(begin, end);
				Vector3 vector = Vector3.Cross(new Vector3(normalized.x, normalized.y, 0f), Vector3.forward);
				Vector2 vector2;
				vector2..ctor(vector.x, vector.y);
				float num2 = width * 0.5f;
				vertData[0].position = begin;
				vertData[1].position = begin + num2 * vector2;
				vertData[2].position = begin + num2 * vector2 + num * normalized;
				vertData[3].position = begin + num * normalized;
				vertData[4].position = begin;
				vertData[5].position = begin - num2 * vector2;
				vertData[6].position = begin - num2 * vector2 + num * normalized;
				vertData[7].position = begin + num * normalized;
			}
		}

		// Token: 0x040045C7 RID: 17863
		public Color centerColor = Color.white;

		// Token: 0x040045C8 RID: 17864
		public bool isFill = true;

		// Token: 0x040045C9 RID: 17865
		[Range(0f, 0.99f)]
		public float fillPercent = 0.8f;

		// Token: 0x040045CA RID: 17866
		[Range(0f, 1f)]
		public float[] values;

		// Token: 0x040045CB RID: 17867
		[Range(0f, 360f)]
		public float angleOffset;

		// Token: 0x040045CC RID: 17868
		public bool useStateLine = true;

		// Token: 0x040045CD RID: 17869
		public Color lineColor = Color.white;

		// Token: 0x040045CE RID: 17870
		public float lineWidth = 0.5f;

		// Token: 0x040045CF RID: 17871
		[Range(0f, 1f)]
		public float lineLength = 0.8f;
	}
}

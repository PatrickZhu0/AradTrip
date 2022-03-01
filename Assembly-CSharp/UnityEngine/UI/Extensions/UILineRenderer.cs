using System;
using System.Collections.Generic;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AF2 RID: 19186
	[AddComponentMenu("UI/Extensions/Primitives/UILineRenderer")]
	public class UILineRenderer : MaskableGraphic
	{
		// Token: 0x170025EC RID: 9708
		// (get) Token: 0x0601BE92 RID: 114322 RVA: 0x0088B680 File Offset: 0x00889A80
		public override Texture mainTexture
		{
			get
			{
				return (!(this.m_Texture == null)) ? this.m_Texture : Graphic.s_WhiteTexture;
			}
		}

		// Token: 0x170025ED RID: 9709
		// (get) Token: 0x0601BE93 RID: 114323 RVA: 0x0088B6A3 File Offset: 0x00889AA3
		// (set) Token: 0x0601BE94 RID: 114324 RVA: 0x0088B6AB File Offset: 0x00889AAB
		public Texture texture
		{
			get
			{
				return this.m_Texture;
			}
			set
			{
				if (this.m_Texture == value)
				{
					return;
				}
				this.m_Texture = value;
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170025EE RID: 9710
		// (get) Token: 0x0601BE95 RID: 114325 RVA: 0x0088B6D2 File Offset: 0x00889AD2
		// (set) Token: 0x0601BE96 RID: 114326 RVA: 0x0088B6DA File Offset: 0x00889ADA
		public Rect uvRect
		{
			get
			{
				return this.m_UVRect;
			}
			set
			{
				if (this.m_UVRect == value)
				{
					return;
				}
				this.m_UVRect = value;
				this.SetVerticesDirty();
			}
		}

		// Token: 0x0601BE97 RID: 114327 RVA: 0x0088B6FC File Offset: 0x00889AFC
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (this.Points == null || this.Points.Length < 2)
			{
				this.Points = new Vector2[]
				{
					new Vector2(0f, 0f),
					new Vector2(1f, 1f)
				};
			}
			int num = 24;
			float num2 = base.rectTransform.rect.width;
			float num3 = base.rectTransform.rect.height;
			float num4 = -base.rectTransform.pivot.x * base.rectTransform.rect.width;
			float num5 = -base.rectTransform.pivot.y * base.rectTransform.rect.height;
			if (!this.relativeSize)
			{
				num2 = 1f;
				num3 = 1f;
			}
			List<Vector2> list = new List<Vector2>();
			list.Add(this.Points[0]);
			Vector2 item = this.Points[0] + (this.Points[1] - this.Points[0]).normalized * (float)num;
			list.Add(item);
			for (int i = 1; i < this.Points.Length - 1; i++)
			{
				list.Add(this.Points[i]);
			}
			item = this.Points[this.Points.Length - 1] - (this.Points[this.Points.Length - 1] - this.Points[this.Points.Length - 2]).normalized * (float)num;
			list.Add(item);
			list.Add(this.Points[this.Points.Length - 1]);
			Vector2[] array = list.ToArray();
			if (this.UseMargins)
			{
				num2 -= this.Margin.x;
				num3 -= this.Margin.y;
				num4 += this.Margin.x / 2f;
				num5 += this.Margin.y / 2f;
			}
			vh.Clear();
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			for (int j = 1; j < array.Length; j++)
			{
				Vector2 vector3 = array[j - 1];
				Vector2 vector4 = array[j];
				vector3..ctor(vector3.x * num2 + num4, vector3.y * num3 + num5);
				vector4..ctor(vector4.x * num2 + num4, vector4.y * num3 + num5);
				float num6 = Mathf.Atan2(vector4.y - vector3.y, vector4.x - vector3.x) * 180f / 3.1415927f;
				Vector2 vector5 = vector3 + new Vector2(0f, -this.LineThickness / 2f);
				Vector2 vector6 = vector3 + new Vector2(0f, this.LineThickness / 2f);
				Vector2 vector7 = vector4 + new Vector2(0f, this.LineThickness / 2f);
				Vector2 vector8 = vector4 + new Vector2(0f, -this.LineThickness / 2f);
				vector5 = this.RotatePointAroundPivot(vector5, vector3, new Vector3(0f, 0f, num6));
				vector6 = this.RotatePointAroundPivot(vector6, vector3, new Vector3(0f, 0f, num6));
				vector7 = this.RotatePointAroundPivot(vector7, vector4, new Vector3(0f, 0f, num6));
				vector8 = this.RotatePointAroundPivot(vector8, vector4, new Vector3(0f, 0f, num6));
				Vector2 zero = Vector2.zero;
				Vector2 vector9;
				vector9..ctor(0f, 1f);
				Vector2 vector10;
				vector10..ctor(0.5f, 0f);
				Vector2 vector11;
				vector11..ctor(0.5f, 1f);
				Vector2 vector12;
				vector12..ctor(1f, 0f);
				Vector2 vector13;
				vector13..ctor(1f, 1f);
				Vector2[] uvs = new Vector2[]
				{
					vector10,
					vector11,
					vector11,
					vector10
				};
				if (j > 1)
				{
					vh.AddUIVertexQuad(this.SetVbo(new Vector2[]
					{
						vector,
						vector2,
						vector5,
						vector6
					}, uvs));
				}
				if (j == 1)
				{
					uvs = new Vector2[]
					{
						zero,
						vector9,
						vector11,
						vector10
					};
				}
				else if (j == array.Length - 1)
				{
					uvs = new Vector2[]
					{
						vector10,
						vector11,
						vector13,
						vector12
					};
				}
				vh.AddUIVertexQuad(this.SetVbo(new Vector2[]
				{
					vector5,
					vector6,
					vector7,
					vector8
				}, uvs));
				vector = vector7;
				vector2 = vector8;
			}
		}

		// Token: 0x0601BE98 RID: 114328 RVA: 0x0088BD68 File Offset: 0x0088A168
		protected UIVertex[] SetVbo(Vector2[] vertices, Vector2[] uvs)
		{
			UIVertex[] array = new UIVertex[4];
			for (int i = 0; i < vertices.Length; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = this.color;
				simpleVert.position = vertices[i];
				simpleVert.uv0 = uvs[i];
				array[i] = simpleVert;
			}
			return array;
		}

		// Token: 0x0601BE99 RID: 114329 RVA: 0x0088BDE4 File Offset: 0x0088A1E4
		public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
		{
			Vector3 vector = point - pivot;
			vector = Quaternion.Euler(angles) * vector;
			point = vector + pivot;
			return point;
		}

		// Token: 0x0401375F RID: 79711
		[SerializeField]
		private Texture m_Texture;

		// Token: 0x04013760 RID: 79712
		[SerializeField]
		private Rect m_UVRect = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x04013761 RID: 79713
		public float LineThickness = 2f;

		// Token: 0x04013762 RID: 79714
		public bool UseMargins;

		// Token: 0x04013763 RID: 79715
		public Vector2 Margin;

		// Token: 0x04013764 RID: 79716
		public Vector2[] Points;

		// Token: 0x04013765 RID: 79717
		public bool relativeSize;
	}
}

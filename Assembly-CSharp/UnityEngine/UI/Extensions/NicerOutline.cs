using System;
using System.Collections.Generic;
using GamePool;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AEF RID: 19183
	[AddComponentMenu("UI/Effects/Extensions/Nicer Outline")]
	public class NicerOutline : BaseMeshEffect
	{
		// Token: 0x0601BE76 RID: 114294 RVA: 0x0088A0AE File Offset: 0x008884AE
		protected override void OnEnable()
		{
			base.OnEnable();
			this.m_FoundText = base.GetComponent<Text>();
		}

		// Token: 0x170025E7 RID: 9703
		// (get) Token: 0x0601BE77 RID: 114295 RVA: 0x0088A0C2 File Offset: 0x008884C2
		// (set) Token: 0x0601BE78 RID: 114296 RVA: 0x0088A0CA File Offset: 0x008884CA
		public Color effectColor
		{
			get
			{
				return this.m_EffectColor;
			}
			set
			{
				this.m_EffectColor = value;
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x170025E8 RID: 9704
		// (get) Token: 0x0601BE79 RID: 114297 RVA: 0x0088A0EF File Offset: 0x008884EF
		// (set) Token: 0x0601BE7A RID: 114298 RVA: 0x0088A0F8 File Offset: 0x008884F8
		public Vector2 effectDistance
		{
			get
			{
				return this.m_EffectDistance;
			}
			set
			{
				if (value.x > 600f)
				{
					value.x = 600f;
				}
				if (value.x < -600f)
				{
					value.x = -600f;
				}
				if (value.y > 600f)
				{
					value.y = 600f;
				}
				if (value.y < -600f)
				{
					value.y = -600f;
				}
				if (this.m_EffectDistance == value)
				{
					return;
				}
				this.m_EffectDistance = value;
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x170025E9 RID: 9705
		// (get) Token: 0x0601BE7B RID: 114299 RVA: 0x0088A1AE File Offset: 0x008885AE
		// (set) Token: 0x0601BE7C RID: 114300 RVA: 0x0088A1B6 File Offset: 0x008885B6
		public bool useGraphicAlpha
		{
			get
			{
				return this.m_UseGraphicAlpha;
			}
			set
			{
				this.m_UseGraphicAlpha = value;
				if (base.graphic != null)
				{
					base.graphic.SetVerticesDirty();
				}
			}
		}

		// Token: 0x0601BE7D RID: 114301 RVA: 0x0088A1DC File Offset: 0x008885DC
		protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
			int num = verts.Count * 2;
			if (verts.Capacity < num)
			{
				verts.Capacity = num;
			}
			for (int i = start; i < end; i++)
			{
				UIVertex uivertex = verts[i];
				verts.Add(uivertex);
				Vector3 position = uivertex.position;
				position.x += x;
				position.y += y;
				uivertex.position = position;
				Color32 color2 = color;
				if (this.m_UseGraphicAlpha)
				{
					color2.a = color2.a * verts[i].color.a / byte.MaxValue;
				}
				uivertex.color = color2;
				verts[i] = uivertex;
			}
		}

		// Token: 0x0601BE7E RID: 114302 RVA: 0x0088A2A4 File Offset: 0x008886A4
		protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
			int num = verts.Count * 2;
			if (verts.Capacity < num)
			{
				verts.Capacity = num;
			}
			this.ApplyShadowZeroAlloc(verts, color, start, end, x, y);
		}

		// Token: 0x0601BE7F RID: 114303 RVA: 0x0088A2DC File Offset: 0x008886DC
		protected void ApplyShaderEx(List<UIVertex> verts, int num, Color32 color, float xOffset, float yOffset)
		{
			int num2 = verts.Count * 9;
			if (verts.Capacity < num2)
			{
				verts.Capacity = num2;
			}
			UIVertex[] array = Singleton<ArrayPool<UIVertex>>.instance.AllocateArray(num2);
			if (this.m_UseGraphicAlpha)
			{
				for (int i = 0; i < num; i++)
				{
					UIVertex uivertex = verts[i];
					array[i + num * 0] = uivertex;
					UIVertex[] array2 = array;
					int num3 = i + num * 0;
					array2[num3].position = array2[num3].position + new Vector3(xOffset, yOffset, 0f);
					array[i + num * 0].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 0].color.a * color.a) * NicerOutline.factor));
					array[i + num] = uivertex;
					UIVertex[] array3 = array;
					int num4 = i + num;
					array3[num4].position = array3[num4].position + new Vector3(xOffset, -yOffset, 0f);
					array[i + num].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num].color.a * color.a) * NicerOutline.factor));
					array[i + num * 2] = uivertex;
					UIVertex[] array4 = array;
					int num5 = i + num * 2;
					array4[num5].position = array4[num5].position + new Vector3(-xOffset, yOffset, 0f);
					array[i + num * 2].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 2].color.a * color.a) * NicerOutline.factor));
					array[i + num * 3] = uivertex;
					UIVertex[] array5 = array;
					int num6 = i + num * 3;
					array5[num6].position = array5[num6].position + new Vector3(-xOffset, -yOffset, 0f);
					array[i + num * 3].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 3].color.a * color.a) * NicerOutline.factor));
					array[i + num * 4] = uivertex;
					UIVertex[] array6 = array;
					int num7 = i + num * 4;
					array6[num7].position = array6[num7].position + new Vector3(xOffset, 0f, 0f);
					array[i + num * 4].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 4].color.a * color.a) * NicerOutline.factor));
					array[i + num * 5] = uivertex;
					UIVertex[] array7 = array;
					int num8 = i + num * 5;
					array7[num8].position = array7[num8].position + new Vector3(-xOffset, 0f, 0f);
					array[i + num * 5].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 5].color.a * color.a) * NicerOutline.factor));
					array[i + num * 6] = uivertex;
					UIVertex[] array8 = array;
					int num9 = i + num * 6;
					array8[num9].position = array8[num9].position + new Vector3(0f, yOffset, 0f);
					array[i + num * 6].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 6].color.a * color.a) * NicerOutline.factor));
					array[i + num * 7] = uivertex;
					UIVertex[] array9 = array;
					int num10 = i + num * 7;
					array9[num10].position = array9[num10].position + new Vector3(0f, -yOffset, 0f);
					array[i + num * 7].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 7].color.a * color.a) * NicerOutline.factor));
					array[i + num * 8] = uivertex;
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					UIVertex uivertex = verts[j];
					array[j + num * 0] = uivertex;
					UIVertex[] array10 = array;
					int num11 = j + num * 0;
					array10[num11].position = array10[num11].position + new Vector3(xOffset, yOffset, 0f);
					array[j + num * 0].color = color;
					array[j + num] = uivertex;
					UIVertex[] array11 = array;
					int num12 = j + num;
					array11[num12].position = array11[num12].position + new Vector3(xOffset, -yOffset, 0f);
					array[j + num].color = color;
					array[j + num * 2] = uivertex;
					UIVertex[] array12 = array;
					int num13 = j + num * 2;
					array12[num13].position = array12[num13].position + new Vector3(-xOffset, yOffset, 0f);
					array[j + num * 2].color = color;
					array[j + num * 3] = uivertex;
					UIVertex[] array13 = array;
					int num14 = j + num * 3;
					array13[num14].position = array13[num14].position + new Vector3(-xOffset, -yOffset, 0f);
					array[j + num * 3].color = color;
					array[j + num * 4] = uivertex;
					UIVertex[] array14 = array;
					int num15 = j + num * 4;
					array14[num15].position = array14[num15].position + new Vector3(xOffset, 0f, 0f);
					array[j + num * 4].color = color;
					array[j + num * 5] = uivertex;
					UIVertex[] array15 = array;
					int num16 = j + num * 5;
					array15[num16].position = array15[num16].position + new Vector3(-xOffset, 0f, 0f);
					array[j + num * 5].color = color;
					array[j + num * 6] = uivertex;
					UIVertex[] array16 = array;
					int num17 = j + num * 6;
					array16[num17].position = array16[num17].position + new Vector3(0f, yOffset, 0f);
					array[j + num * 6].color = color;
					array[j + num * 7] = uivertex;
					UIVertex[] array17 = array;
					int num18 = j + num * 7;
					array17[num18].position = array17[num18].position + new Vector3(0f, -yOffset, 0f);
					array[j + num * 7].color = color;
					array[j + num * 8] = uivertex;
				}
			}
			verts.Clear();
			verts.AddRange(array);
			Singleton<ArrayPool<UIVertex>>.instance.ReleaseArray(array);
		}

		// Token: 0x0601BE80 RID: 114304 RVA: 0x0088AA6C File Offset: 0x00888E6C
		protected void ApplyShaderFast(List<UIVertex> verts, int num, Color32 color, float xOffset, float yOffset)
		{
			int num2 = verts.Count * 5;
			if (verts.Capacity < num2)
			{
				verts.Capacity = num2;
			}
			UIVertex[] array = Singleton<ArrayPool<UIVertex>>.instance.AllocateArray(num2);
			if (this.m_UseGraphicAlpha)
			{
				for (int i = 0; i < num; i++)
				{
					UIVertex uivertex = verts[i];
					array[i + num * 0] = uivertex;
					UIVertex[] array2 = array;
					int num3 = i + num * 0;
					array2[num3].position = array2[num3].position + new Vector3(xOffset, yOffset, 0f);
					array[i + num * 0].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 0].color.a * color.a) * NicerOutline.factor));
					array[i + num] = uivertex;
					UIVertex[] array3 = array;
					int num4 = i + num;
					array3[num4].position = array3[num4].position + new Vector3(xOffset, -yOffset, 0f);
					array[i + num].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num].color.a * color.a) * NicerOutline.factor));
					array[i + num * 2] = uivertex;
					UIVertex[] array4 = array;
					int num5 = i + num * 2;
					array4[num5].position = array4[num5].position + new Vector3(-xOffset, yOffset, 0f);
					array[i + num * 2].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 2].color.a * color.a) * NicerOutline.factor));
					array[i + num * 3] = uivertex;
					UIVertex[] array5 = array;
					int num6 = i + num * 3;
					array5[num6].position = array5[num6].position + new Vector3(-xOffset, -yOffset, 0f);
					array[i + num * 3].color = new Color32(color.r, color.g, color.b, (byte)((float)(array[i + num * 3].color.a * color.a) * NicerOutline.factor));
					array[i + num * 4] = uivertex;
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					UIVertex uivertex = verts[j];
					array[j + num * 0] = uivertex;
					UIVertex[] array6 = array;
					int num7 = j + num * 0;
					array6[num7].position = array6[num7].position + new Vector3(xOffset, yOffset, 0f);
					array[j + num * 0].color = color;
					array[j + num] = uivertex;
					UIVertex[] array7 = array;
					int num8 = j + num;
					array7[num8].position = array7[num8].position + new Vector3(xOffset, -yOffset, 0f);
					array[j + num].color = color;
					array[j + num * 2] = uivertex;
					UIVertex[] array8 = array;
					int num9 = j + num * 2;
					array8[num9].position = array8[num9].position + new Vector3(-xOffset, yOffset, 0f);
					array[j + num * 2].color = color;
					array[j + num * 3] = uivertex;
					UIVertex[] array9 = array;
					int num10 = j + num * 3;
					array9[num10].position = array9[num10].position + new Vector3(-xOffset, -yOffset, 0f);
					array[j + num * 3].color = color;
					array[j + num * 4] = uivertex;
				}
			}
			verts.Clear();
			verts.AddRange(array);
			Singleton<ArrayPool<UIVertex>>.instance.ReleaseArray(array);
		}

		// Token: 0x0601BE81 RID: 114305 RVA: 0x0088AE84 File Offset: 0x00889284
		public override void ModifyMesh(VertexHelper vh)
		{
			if (!this.IsActive())
			{
				return;
			}
			List<UIVertex> list = ListPool<UIVertex>.Get();
			vh.GetUIVertexStream(list);
			if (null == this.m_FoundText)
			{
				this.m_FoundText = base.GetComponent<Text>();
			}
			float num = 1f;
			if (this.m_FoundText && this.m_FoundText.resizeTextForBestFit)
			{
				num = (float)this.m_FoundText.cachedTextGenerator.fontSizeUsedForBestFit / (float)(this.m_FoundText.resizeTextMaxSize - 1);
			}
			float xOffset = this.effectDistance.x * num;
			float yOffset = this.effectDistance.y * num;
			this.ApplyShaderEx(list, list.Count, this.effectColor, xOffset, yOffset);
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
			ListPool<UIVertex>.Release(list);
		}

		// Token: 0x04013745 RID: 79685
		[SerializeField]
		private Color m_EffectColor = new Color(0f, 0f, 0f, 0.5f);

		// Token: 0x04013746 RID: 79686
		[SerializeField]
		private Vector2 m_EffectDistance = new Vector2(1f, -1f);

		// Token: 0x04013747 RID: 79687
		[SerializeField]
		private bool m_UseGraphicAlpha = true;

		// Token: 0x04013748 RID: 79688
		private Text m_FoundText;

		// Token: 0x04013749 RID: 79689
		private static readonly float factor = 0.003921569f;
	}
}

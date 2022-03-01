using System;
using System.Reflection;
using UnityEngine;

// Token: 0x02000141 RID: 321
public static class DrawingHandle
{
	// Token: 0x06000965 RID: 2405 RVA: 0x0003152E File Offset: 0x0002F92E
	static DrawingHandle()
	{
		DrawingHandle.Initialize();
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x0003156C File Offset: 0x0002F96C
	public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width, bool antiAlias = true)
	{
		float num = pointB.x - pointA.x;
		float num2 = pointB.y - pointA.y;
		float num3 = Mathf.Sqrt(num * num + num2 * num2);
		if (num3 >= 0.001f)
		{
			Texture2D texture2D;
			Material material;
			if (antiAlias)
			{
				width *= 3f;
				texture2D = DrawingHandle.aaLineTex;
				material = DrawingHandle.blendMaterial;
			}
			else
			{
				texture2D = DrawingHandle.lineTex;
				material = DrawingHandle.blitMaterial;
			}
			float num4 = width * num2 / num3;
			float num5 = width * num / num3;
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = num;
			identity.m01 = -num4;
			identity.m03 = pointA.x + 0.5f * num4;
			identity.m10 = num2;
			identity.m11 = num5;
			identity.m13 = pointA.y - 0.5f * num5;
			GL.PushMatrix();
			GL.MultMatrix(identity);
			Graphics.DrawTexture(DrawingHandle.lineRect, texture2D, DrawingHandle.lineRect, 0, 0, 0, 0, color, material);
			GL.PopMatrix();
		}
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00031670 File Offset: 0x0002FA70
	private static void Initialize()
	{
		if (DrawingHandle.lineTex == null)
		{
			DrawingHandle.lineTex = new Texture2D(1, 1, 5, false);
			DrawingHandle.lineTex.SetPixel(0, 1, Color.white);
			DrawingHandle.lineTex.Apply();
		}
		if (DrawingHandle.aaLineTex == null)
		{
			DrawingHandle.aaLineTex = new Texture2D(1, 3, 5, false);
			DrawingHandle.aaLineTex.SetPixel(0, 0, new Color(1f, 1f, 1f, 0f));
			DrawingHandle.aaLineTex.SetPixel(0, 1, Color.white);
			DrawingHandle.aaLineTex.SetPixel(0, 2, new Color(1f, 1f, 1f, 0f));
			DrawingHandle.aaLineTex.Apply();
		}
		DrawingHandle.blitMaterial = (Material)typeof(GUI).GetMethod("get_blitMaterial", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
		DrawingHandle.blendMaterial = (Material)typeof(GUI).GetMethod("get_blendMaterial", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
	}

	// Token: 0x0400070B RID: 1803
	private static Texture2D aaLineTex = null;

	// Token: 0x0400070C RID: 1804
	private static Material blendMaterial = null;

	// Token: 0x0400070D RID: 1805
	private static Material blitMaterial = null;

	// Token: 0x0400070E RID: 1806
	private static Rect lineRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x0400070F RID: 1807
	private static Texture2D lineTex = null;
}

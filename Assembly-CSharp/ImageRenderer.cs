using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

// Token: 0x02000D30 RID: 3376
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ImageRenderer : MonoBehaviour
{
	// Token: 0x060089DF RID: 35295 RVA: 0x00190AA8 File Offset: 0x0018EEA8
	public void Init()
	{
		this.m_Mesh = new Mesh();
		this.m_MeshFilter = base.GetComponent<MeshFilter>();
		this.m_MeshRenderer = base.GetComponent<MeshRenderer>();
		this.m_RectTransform = base.GetComponent<RectTransform>();
		this.m_MeshFilter.mesh = this.m_Mesh;
		this.m_MeshRenderer.material = this.material;
		this.m_MeshRenderer.material.mainTexture = this.sprite.texture;
		this.m_Images = new List<MyImage>(ImageRenderer.m_DefaultCapacity);
		this.m_Vertices = new List<Vector3>(ImageRenderer.m_DefaultCapacity * 4);
		this.m_OriginVertices = new List<Vector3>(ImageRenderer.m_DefaultCapacity * 4);
		this.m_UVs = new List<Vector2>(ImageRenderer.m_DefaultCapacity * 4);
		this.m_Triangles = new List<int>(ImageRenderer.m_DefaultCapacity * 6);
		this.m_Colors = new List<Color>(ImageRenderer.m_DefaultCapacity * 4);
		this.GenerateSimpleSprite(true);
		this.m_CurrentImageNum = 0;
	}

	// Token: 0x060089E0 RID: 35296 RVA: 0x00190B9C File Offset: 0x0018EF9C
	public void AddImage(Vec3 position, int actorID, int hitEffectType, int animCurveIndex)
	{
		this.m_Images.Add(new MyImage(position, 0f, actorID, hitEffectType, animCurveIndex));
		for (int i = 0; i < this.m_SpriteVertices.Length; i++)
		{
			this.m_Vertices.Add(this.m_SpriteVertices[i]);
			this.m_OriginVertices.Add(this.m_SpriteVertices[i]);
			this.m_UVs.Add(this.m_SpriteUVs[i]);
			this.m_Colors.Add(new Color(1f, 1f, 1f, 1f));
		}
		for (int j = 0; j < this.m_SpriteTriangles.Length; j++)
		{
			this.m_Triangles.Add((int)this.m_SpriteTriangles[j] + this.m_CurrentImageNum * this.m_SpriteVertices.Length);
		}
		this.m_CurrentImageNum++;
	}

	// Token: 0x060089E1 RID: 35297 RVA: 0x00190CA8 File Offset: 0x0018F0A8
	public void MoveUpAll(int actorID, int animType)
	{
		for (int i = 0; i < this.m_Images.Count; i++)
		{
			MyImage myImage = this.m_Images[i];
			if (myImage.actorID == actorID && myImage.hitEffectType == animType)
			{
				this.m_Images[i] = new MyImage(new Vec3(myImage.position.x, myImage.position.y + this.moveUpOffset, myImage.position.z), myImage.passedTime, myImage.actorID, myImage.hitEffectType, myImage.animCurveIndex);
			}
		}
	}

	// Token: 0x060089E2 RID: 35298 RVA: 0x00190D58 File Offset: 0x0018F158
	public void UpdateMesh()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.m_Images.Count; i++)
		{
			if (this.m_Images[i].passedTime >= this.lifeTime)
			{
				num++;
			}
		}
		int num3 = this.m_Images.Count - this.Max_Num;
		if (this.Max_Num != 0 && num3 > 0)
		{
			int num4 = num;
			for (int j = num4; j < num4 + num3; j++)
			{
				num++;
			}
		}
		if (num != 0)
		{
			this.m_CurrentImageNum -= num;
			this.m_Vertices.RemoveRange(num2 * 4, num * 4);
			this.m_OriginVertices.RemoveRange(num2 * 4, num * 4);
			this.m_UVs.RemoveRange(num2 * 4, num * 4);
			this.m_Colors.RemoveRange(num2 * 4, num * 4);
			this.m_Images.RemoveRange(num2, num);
			int count = this.m_Triangles.Count;
			this.m_Triangles.RemoveRange(count - num * 6, num * 6);
		}
		for (int k = 0; k < this.m_Images.Count; k++)
		{
			MyImage myImage = this.m_Images[k];
			float num5 = this.moveXCurves[myImage.animCurveIndex].Evaluate(myImage.passedTime);
			float num6 = this.moveYCurves[myImage.animCurveIndex].Evaluate(myImage.passedTime);
			float num7 = this.scaleCurves[myImage.animCurveIndex].Evaluate(myImage.passedTime);
			float num8 = this.fadeCurves[myImage.animCurveIndex].Evaluate(myImage.passedTime);
			for (int l = k * 4; l < k * 4 + this.m_SpriteVertices.Length; l++)
			{
				Vector3 vector = this.m_OriginVertices[l];
				this.m_Vertices[l] = new Vector3(vector.x * num7 + myImage.position.x + num5 + this.imageXOffset, vector.y * num7 + myImage.position.y + num6 + this.imageYOffset, myImage.position.z);
				this.m_Colors[l] = new Color(1f, 1f, 1f, 1f * num8);
			}
			this.m_Images[k] = new MyImage(myImage.position, myImage.passedTime + Time.deltaTime, myImage.actorID, myImage.hitEffectType, myImage.animCurveIndex);
		}
		if (this.m_Vertices.Count > 0)
		{
			this.m_Mesh.Clear();
			this.m_Mesh.SetVertices(this.m_Vertices);
			this.m_Mesh.SetUVs(0, this.m_UVs);
			this.m_Mesh.SetColors(this.m_Colors);
			this.m_Mesh.SetTriangles(this.m_Triangles, 0);
		}
		else
		{
			this.m_Mesh.Clear();
		}
	}

	// Token: 0x060089E3 RID: 35299 RVA: 0x00191080 File Offset: 0x0018F480
	private void GenerateSimpleSprite(bool lPreserveAspect)
	{
		Vector4 drawingDimensions = this.GetDrawingDimensions(lPreserveAspect);
		Vector4 vector = (!(this.sprite != null)) ? Vector4.zero : DataUtility.GetOuterUV(this.sprite);
		this.m_SpriteVertices = new Vector2[]
		{
			new Vector2(drawingDimensions.x, drawingDimensions.y),
			new Vector2(drawingDimensions.x, drawingDimensions.w),
			new Vector2(drawingDimensions.z, drawingDimensions.w),
			new Vector2(drawingDimensions.z, drawingDimensions.y)
		};
		this.m_SpriteUVs = new Vector2[]
		{
			new Vector2(vector.x, vector.y),
			new Vector2(vector.x, vector.w),
			new Vector2(vector.z, vector.w),
			new Vector2(vector.z, vector.y)
		};
		this.m_SpriteTriangles = new ushort[]
		{
			0,
			1,
			2,
			2,
			3,
			0
		};
	}

	// Token: 0x060089E4 RID: 35300 RVA: 0x001911E4 File Offset: 0x0018F5E4
	private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
	{
		Vector4 vector = (!(this.sprite == null)) ? DataUtility.GetPadding(this.sprite) : Vector4.zero;
		Vector2 vector2 = (!(this.sprite == null)) ? new Vector2(this.sprite.rect.width, this.sprite.rect.height) : Vector2.zero;
		Rect rect = this.m_RectTransform.rect;
		int num = Mathf.RoundToInt(vector2.x);
		int num2 = Mathf.RoundToInt(vector2.y);
		Vector4 result;
		result..ctor(vector.x / (float)num, vector.y / (float)num2, ((float)num - vector.z) / (float)num, ((float)num2 - vector.w) / (float)num2);
		if (shouldPreserveAspect && vector2.sqrMagnitude > 0f)
		{
			float num3 = vector2.x / vector2.y;
			float num4 = rect.width / rect.height;
			if (num3 > num4)
			{
				float height = rect.height;
				rect.height = rect.width * (1f / num3);
				rect.y += (height - rect.height) * this.m_RectTransform.pivot.y;
			}
			else
			{
				float width = rect.width;
				rect.width = rect.height * num3;
				rect.x += (width - rect.width) * this.m_RectTransform.pivot.x;
			}
		}
		result..ctor(rect.x + rect.width * result.x, rect.y + rect.height * result.y, rect.x + rect.width * result.z, rect.y + rect.height * result.w);
		return result;
	}

	// Token: 0x04004357 RID: 17239
	public Sprite sprite;

	// Token: 0x04004358 RID: 17240
	public Material material;

	// Token: 0x04004359 RID: 17241
	public float imageXOffset;

	// Token: 0x0400435A RID: 17242
	public float imageYOffset;

	// Token: 0x0400435B RID: 17243
	public AnimationCurve[] moveXCurves;

	// Token: 0x0400435C RID: 17244
	public AnimationCurve[] moveYCurves;

	// Token: 0x0400435D RID: 17245
	public AnimationCurve[] fadeCurves;

	// Token: 0x0400435E RID: 17246
	public AnimationCurve[] scaleCurves;

	// Token: 0x0400435F RID: 17247
	public float lifeTime;

	// Token: 0x04004360 RID: 17248
	public int Max_Num;

	// Token: 0x04004361 RID: 17249
	private float moveUpOffset = 15f;

	// Token: 0x04004362 RID: 17250
	private Mesh m_Mesh;

	// Token: 0x04004363 RID: 17251
	private MeshFilter m_MeshFilter;

	// Token: 0x04004364 RID: 17252
	private MeshRenderer m_MeshRenderer;

	// Token: 0x04004365 RID: 17253
	private List<MyImage> m_Images;

	// Token: 0x04004366 RID: 17254
	private Vector2[] m_SpriteVertices;

	// Token: 0x04004367 RID: 17255
	private Vector2[] m_SpriteUVs;

	// Token: 0x04004368 RID: 17256
	private ushort[] m_SpriteTriangles;

	// Token: 0x04004369 RID: 17257
	private List<Vector3> m_Vertices;

	// Token: 0x0400436A RID: 17258
	private List<Vector3> m_OriginVertices;

	// Token: 0x0400436B RID: 17259
	private List<Vector2> m_UVs;

	// Token: 0x0400436C RID: 17260
	private List<int> m_Triangles;

	// Token: 0x0400436D RID: 17261
	private List<Color> m_Colors;

	// Token: 0x0400436E RID: 17262
	private RectTransform m_RectTransform;

	// Token: 0x0400436F RID: 17263
	private int m_CurrentImageNum;

	// Token: 0x04004370 RID: 17264
	private static int m_DefaultCapacity = 12;
}

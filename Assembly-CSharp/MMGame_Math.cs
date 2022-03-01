using System;
using UnityEngine;

// Token: 0x02000D82 RID: 3458
public static class MMGame_Math
{
	// Token: 0x06008C22 RID: 35874 RVA: 0x0019F148 File Offset: 0x0019D548
	public static float Dot3(this Vector3 a, Vector3 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x06008C23 RID: 35875 RVA: 0x0019F179 File Offset: 0x0019D579
	public static float Dot3(this Vector3 a, Vector4 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x06008C24 RID: 35876 RVA: 0x0019F1AA File Offset: 0x0019D5AA
	public static float Dot3(this Vector3 a, ref Vector3 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x06008C25 RID: 35877 RVA: 0x0019F1D8 File Offset: 0x0019D5D8
	public static float Dot3(this Vector3 a, ref Vector4 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x06008C26 RID: 35878 RVA: 0x0019F206 File Offset: 0x0019D606
	public static float DotXZ(this Vector3 a, Vector3 b)
	{
		return a.x * b.x + a.z * b.z;
	}

	// Token: 0x06008C27 RID: 35879 RVA: 0x0019F227 File Offset: 0x0019D627
	public static float DotXZ(this Vector3 a, ref Vector3 b)
	{
		return a.x * b.x + a.z * b.z;
	}

	// Token: 0x06008C28 RID: 35880 RVA: 0x0019F248 File Offset: 0x0019D648
	public static MeshRenderer GetMeshRendererInChildren(this GameObject go)
	{
		MeshRenderer meshRenderer = go.GetComponent<Renderer>() as MeshRenderer;
		if (meshRenderer != null)
		{
			return meshRenderer;
		}
		int childCount = go.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = go.transform.GetChild(i);
			if (child != null && child.gameObject != null)
			{
				meshRenderer = child.gameObject.GetMeshRendererInChildren();
				if (meshRenderer != null)
				{
					return meshRenderer;
				}
			}
		}
		return null;
	}

	// Token: 0x06008C29 RID: 35881 RVA: 0x0019F2D4 File Offset: 0x0019D6D4
	public static Renderer GetRendererInChildren(this GameObject go)
	{
		if (go.GetComponent<Renderer>() != null)
		{
			return go.GetComponent<Renderer>();
		}
		int childCount = go.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = go.transform.GetChild(i);
			if (child != null && child.gameObject != null)
			{
				Renderer rendererInChildren = child.gameObject.GetRendererInChildren();
				if (rendererInChildren != null)
				{
					return rendererInChildren;
				}
			}
		}
		return null;
	}

	// Token: 0x06008C2A RID: 35882 RVA: 0x0019F35C File Offset: 0x0019D75C
	public static SkinnedMeshRenderer GetSkinnedMeshRendererInChildren(this GameObject go)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = go.GetComponent<Renderer>() as SkinnedMeshRenderer;
		if (skinnedMeshRenderer != null)
		{
			return skinnedMeshRenderer;
		}
		int childCount = go.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = go.transform.GetChild(i);
			if (child != null && child.gameObject != null)
			{
				skinnedMeshRenderer = child.gameObject.GetSkinnedMeshRendererInChildren();
				if (skinnedMeshRenderer != null)
				{
					return skinnedMeshRenderer;
				}
			}
		}
		return null;
	}

	// Token: 0x06008C2B RID: 35883 RVA: 0x0019F3E8 File Offset: 0x0019D7E8
	public static bool isMirror(Matrix4x4 m)
	{
		Vector3 vector = m.GetColumn(0).toVec3();
		Vector3 vector2 = m.GetColumn(1).toVec3();
		Vector3 a = m.GetColumn(2).toVec3();
		Vector3 vector3 = Vector3.Cross(vector, vector2);
		a.Normalize();
		vector3.Normalize();
		return a.Dot3(ref vector3) < 0f;
	}

	// Token: 0x06008C2C RID: 35884 RVA: 0x0019F444 File Offset: 0x0019D844
	public static Vector2 Lerp(this Vector2 left, Vector2 right, float lerp)
	{
		return new Vector2(Mathf.Lerp(left.x, right.x, lerp), Mathf.Lerp(left.y, right.y, lerp));
	}

	// Token: 0x06008C2D RID: 35885 RVA: 0x0019F474 File Offset: 0x0019D874
	public static Vector3 Lerp(this Vector3 left, Vector3 right, float lerp)
	{
		return new Vector3(Mathf.Lerp(left.x, right.x, lerp), Mathf.Lerp(left.y, right.y, lerp), Mathf.Lerp(left.z, right.z, lerp));
	}

	// Token: 0x06008C2E RID: 35886 RVA: 0x0019F4C4 File Offset: 0x0019D8C4
	public static Vector4 Lerp(this Vector4 left, Vector4 right, float lerp)
	{
		return new Vector4(Mathf.Lerp(left.x, right.x, lerp), Mathf.Lerp(left.y, right.y, lerp), Mathf.Lerp(left.z, right.z, lerp), Mathf.Lerp(left.w, right.w, lerp));
	}

	// Token: 0x06008C2F RID: 35887 RVA: 0x0019F526 File Offset: 0x0019D926
	public static Vector3 Mul(this Vector3 a, Vector3 b)
	{
		return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

	// Token: 0x06008C30 RID: 35888 RVA: 0x0019F55A File Offset: 0x0019D95A
	public static Vector3 Mul(this Vector3 a, ref Vector3 b)
	{
		return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

	// Token: 0x06008C31 RID: 35889 RVA: 0x0019F58B File Offset: 0x0019D98B
	public static Vector3 Mul(this Vector3 a, Vector3 b, float f)
	{
		return new Vector3(a.x * b.x * f, a.y * b.y * f, a.z * b.z * f);
	}

	// Token: 0x06008C32 RID: 35890 RVA: 0x0019F5C5 File Offset: 0x0019D9C5
	public static Vector3 Mul(this Vector3 a, ref Vector3 b, float f)
	{
		return new Vector3(a.x * b.x * f, a.y * b.y * f, a.z * b.z * f);
	}

	// Token: 0x06008C33 RID: 35891 RVA: 0x0019F5FC File Offset: 0x0019D9FC
	public static void SetLayer(this GameObject go, int layer)
	{
		MMGame_Math.SetLayerRecursively(go, layer);
	}

	// Token: 0x06008C34 RID: 35892 RVA: 0x0019F608 File Offset: 0x0019DA08
	public static void SetLayer(this GameObject go, string layerName)
	{
		int layer = LayerMask.NameToLayer(layerName);
		MMGame_Math.SetLayerRecursively(go, layer);
	}

	// Token: 0x06008C35 RID: 35893 RVA: 0x0019F623 File Offset: 0x0019DA23
	public static void SetLayer(this GameObject go, int layer, int layerParticles)
	{
		MMGame_Math.SetLayerRecursively(go, layer, layerParticles);
	}

	// Token: 0x06008C36 RID: 35894 RVA: 0x0019F630 File Offset: 0x0019DA30
	public static void SetLayer(this GameObject go, string layerName, string layerNameParticles)
	{
		int layer = LayerMask.NameToLayer(layerName);
		int layerParticles = LayerMask.NameToLayer(layerNameParticles);
		MMGame_Math.SetLayerRecursively(go, layer, layerParticles);
	}

	// Token: 0x06008C37 RID: 35895 RVA: 0x0019F654 File Offset: 0x0019DA54
	public static void SetLayerRecursively(GameObject go, int layer)
	{
		go.layer = layer;
		int childCount = go.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			MMGame_Math.SetLayerRecursively(go.transform.GetChild(i).gameObject, layer);
		}
	}

	// Token: 0x06008C38 RID: 35896 RVA: 0x0019F6A0 File Offset: 0x0019DAA0
	public static void SetLayerRecursively(GameObject go, int layer, int layerParticles)
	{
		if (go.GetComponent<ParticleSystem>() != null)
		{
			go.layer = layerParticles;
		}
		else
		{
			go.layer = layer;
		}
		int childCount = go.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			MMGame_Math.SetLayerRecursively(go.transform.GetChild(i).gameObject, layer);
		}
	}

	// Token: 0x06008C39 RID: 35897 RVA: 0x0019F708 File Offset: 0x0019DB08
	public static void SetOffsetX(this Camera camera, float offsetX)
	{
		float num = 2f * Mathf.Tan(0.01745329f * camera.fieldOfView * 0.5f) * camera.nearClipPlane;
		float num2 = num * camera.aspect;
		float num3 = -Mathf.Clamp(offsetX, -1f, 1f) * num2;
		float num4 = (num2 + num3) * 0.5f;
		float left = num4 - num2;
		camera.SetPerspectiveOffCenter(left, num4, -num * 0.5f, num * 0.5f, camera.nearClipPlane, camera.farClipPlane);
	}

	// Token: 0x06008C3A RID: 35898 RVA: 0x0019F78C File Offset: 0x0019DB8C
	public static void SetPerspectiveOffCenter(this Camera camera, float left, float right, float bottom, float top, float near, float far)
	{
		float num = 1f / (right - left);
		float num2 = 1f / (top - bottom);
		float num3 = 1f / (near - far);
		Matrix4x4 matrix4x = default(Matrix4x4);
		matrix4x.m00 = 2f * near * num;
		matrix4x.m10 = 0f;
		matrix4x.m20 = 0f;
		matrix4x.m30 = 0f;
		matrix4x.m01 = 0f;
		matrix4x.m11 = 2f * near * num2;
		matrix4x.m21 = 0f;
		matrix4x.m31 = 0f;
		matrix4x.m02 = (right + left) * num;
		matrix4x.m12 = (top + bottom) * num2;
		matrix4x.m22 = far * num3;
		matrix4x.m32 = -1f;
		matrix4x.m03 = 0f;
		matrix4x.m13 = 0f;
		matrix4x.m23 = 2f * far * near * num3;
		matrix4x.m33 = 0f;
		Matrix4x4 projectionMatrix = matrix4x;
		camera.projectionMatrix = projectionMatrix;
	}

	// Token: 0x06008C3B RID: 35899 RVA: 0x0019F89E File Offset: 0x0019DC9E
	public static string ToString2(this Vector3 a)
	{
		return string.Format("({0},{1},{2})", a.x, a.y, a.z);
	}

	// Token: 0x06008C3C RID: 35900 RVA: 0x0019F8CE File Offset: 0x0019DCCE
	public static Vector3 toVec3(this Vector4 a)
	{
		return new Vector3(a.x, a.y, a.z);
	}

	// Token: 0x06008C3D RID: 35901 RVA: 0x0019F8EA File Offset: 0x0019DCEA
	public static Vector4 toVec4(this Vector3 v, float a)
	{
		return new Vector4(v.x, v.y, v.z, a);
	}

	// Token: 0x06008C3E RID: 35902 RVA: 0x0019F907 File Offset: 0x0019DD07
	public static Vector2 xz(this Vector3 a)
	{
		return new Vector2(a.x, a.z);
	}

	// Token: 0x06008C3F RID: 35903 RVA: 0x0019F91C File Offset: 0x0019DD1C
	public static float XZSqrMagnitude(this Vector3 a, Vector3 b)
	{
		float num = a.x - b.x;
		float num2 = a.z - b.z;
		return num * num + num2 * num2;
	}

	// Token: 0x06008C40 RID: 35904 RVA: 0x0019F950 File Offset: 0x0019DD50
	public static float XZSqrMagnitude(this Vector3 a, ref Vector3 b)
	{
		float num = a.x - b.x;
		float num2 = a.z - b.z;
		return num * num + num2 * num2;
	}
}

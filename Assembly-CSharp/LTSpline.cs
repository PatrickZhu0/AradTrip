using System;
using UnityEngine;

// Token: 0x0200019F RID: 415
[Serializable]
public class LTSpline
{
	// Token: 0x06000CFD RID: 3325 RVA: 0x00040AB0 File Offset: 0x0003EEB0
	public LTSpline(params Vector3[] pts)
	{
		this.pts = new Vector3[pts.Length];
		Array.Copy(pts, this.pts, pts.Length);
		this.numSections = pts.Length - 3;
		int num = 20;
		this.lengthRatio = new float[num];
		this.lengths = new float[num];
		Vector3 vector;
		vector..ctor(float.PositiveInfinity, 0f, 0f);
		this.totalLength = 0f;
		for (int i = 0; i < num; i++)
		{
			float t = (float)i * 1f / (float)num;
			Vector3 vector2 = this.interp(t);
			if (i >= 1)
			{
				Vector3 vector3 = vector2 - vector;
				this.lengths[i] = vector3.magnitude;
			}
			this.totalLength += this.lengths[i];
			vector = vector2;
		}
		float num2 = 0f;
		for (int j = 0; j < this.lengths.Length; j++)
		{
			float num3 = (float)j * 1f / (float)(this.lengths.Length - 1);
			this.currPt = Mathf.Min(Mathf.FloorToInt(num3 * (float)this.numSections), this.numSections - 1);
			float num4 = this.lengths[j] / this.totalLength;
			this.lengthRatio[j] = num2 + num4;
		}
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00040C04 File Offset: 0x0003F004
	public void gizmoDraw(float t = -1f)
	{
		if (this.lengthRatio != null && this.lengthRatio.Length > 0)
		{
			Vector3 vector = this.point(0f);
			for (int i = 1; i <= 120; i++)
			{
				float ratio = (float)i / 120f;
				Vector3 vector2 = this.point(ratio);
				Gizmos.DrawLine(vector2, vector);
				vector = vector2;
			}
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x00040C64 File Offset: 0x0003F064
	public Vector3 interp(float t)
	{
		this.currPt = Mathf.Min(Mathf.FloorToInt(t * (float)this.numSections), this.numSections - 1);
		float num = t * (float)this.numSections - (float)this.currPt;
		Vector3 vector = this.pts[this.currPt];
		Vector3 vector2 = this.pts[this.currPt + 1];
		Vector3 vector3 = this.pts[this.currPt + 2];
		Vector3 vector4 = this.pts[this.currPt + 3];
		return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num * num * num) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num * num) + (-vector + vector3) * num + 2f * vector2);
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x00040DB0 File Offset: 0x0003F1B0
	public float map(float t)
	{
		for (int i = 0; i < this.lengthRatio.Length; i++)
		{
			if (this.lengthRatio[i] >= t)
			{
				return this.lengthRatio[i] + (t - this.lengthRatio[i]);
			}
		}
		return 1f;
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00040DFD File Offset: 0x0003F1FD
	public void place(Transform transform, float ratio)
	{
		this.place(transform, ratio, Vector3.up);
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x00040E0C File Offset: 0x0003F20C
	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
		transform.position = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(this.point(ratio), worldUp);
		}
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x00040E40 File Offset: 0x0003F240
	public void place2d(Transform transform, float ratio)
	{
		transform.position = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			Vector3 vector = this.point(ratio) - transform.position;
			float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			transform.eulerAngles = new Vector3(0f, 0f, num);
		}
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x00040EB1 File Offset: 0x0003F2B1
	public void placeLocal(Transform transform, float ratio)
	{
		this.placeLocal(transform, ratio, Vector3.up);
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00040EC0 File Offset: 0x0003F2C0
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
		transform.localPosition = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(transform.parent.TransformPoint(this.point(ratio)), worldUp);
		}
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x00040EFC File Offset: 0x0003F2FC
	public void placeLocal2d(Transform transform, float ratio)
	{
		transform.localPosition = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			Vector3 vector = transform.parent.TransformPoint(this.point(ratio)) - transform.localPosition;
			float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			transform.eulerAngles = new Vector3(0f, 0f, num);
		}
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00040F78 File Offset: 0x0003F378
	public Vector3 point(float ratio)
	{
		float t = this.map(ratio);
		return this.interp(t);
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00040F94 File Offset: 0x0003F394
	public Vector3 Velocity(float t)
	{
		t = this.map(t);
		int num = this.pts.Length - 3;
		int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
		float num3 = t * (float)num - (float)num2;
		Vector3 vector = this.pts[num2];
		Vector3 vector2 = this.pts[num2 + 1];
		Vector3 vector3 = this.pts[num2 + 2];
		Vector3 vector4 = this.pts[num2 + 3];
		return 1.5f * (-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * num3 + 0.5f * vector3 - 0.5f * vector;
	}

	// Token: 0x04000900 RID: 2304
	private int currPt;

	// Token: 0x04000901 RID: 2305
	private float[] lengthRatio;

	// Token: 0x04000902 RID: 2306
	private float[] lengths;

	// Token: 0x04000903 RID: 2307
	private int numSections;

	// Token: 0x04000904 RID: 2308
	public bool orientToPath;

	// Token: 0x04000905 RID: 2309
	public bool orientToPath2d;

	// Token: 0x04000906 RID: 2310
	public Vector3[] pts;

	// Token: 0x04000907 RID: 2311
	private float totalLength;
}

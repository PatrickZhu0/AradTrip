using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
public class LTBezierPath
{
	// Token: 0x06000C89 RID: 3209 RVA: 0x0003E395 File Offset: 0x0003C795
	public LTBezierPath()
	{
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x0003E39D File Offset: 0x0003C79D
	public LTBezierPath(Vector3[] pts_)
	{
		this.setPoints(pts_);
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x0003E3AC File Offset: 0x0003C7AC
	public void place(Transform transform, float ratio)
	{
		this.place(transform, ratio, Vector3.up);
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x0003E3BB File Offset: 0x0003C7BB
	public void place(Transform transform, float ratio, Vector3 worldUp)
	{
		transform.position = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(this.point(ratio), worldUp);
		}
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x0003E3EC File Offset: 0x0003C7EC
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

	// Token: 0x06000C8E RID: 3214 RVA: 0x0003E45D File Offset: 0x0003C85D
	public void placeLocal(Transform transform, float ratio)
	{
		this.placeLocal(transform, ratio, Vector3.up);
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x0003E46C File Offset: 0x0003C86C
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp)
	{
		transform.localPosition = this.point(ratio);
		ratio += 0.001f;
		if (ratio <= 1f)
		{
			transform.LookAt(transform.parent.TransformPoint(this.point(ratio)), worldUp);
		}
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x0003E4A8 File Offset: 0x0003C8A8
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

	// Token: 0x06000C91 RID: 3217 RVA: 0x0003E524 File Offset: 0x0003C924
	public Vector3 point(float ratio)
	{
		float num = 0f;
		for (int i = 0; i < this.lengthRatio.Length; i++)
		{
			num += this.lengthRatio[i];
			if (num >= ratio)
			{
				return this.beziers[i].point((ratio - (num - this.lengthRatio[i])) / this.lengthRatio[i]);
			}
		}
		return this.beziers[this.lengthRatio.Length - 1].point(1f);
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x0003E5A0 File Offset: 0x0003C9A0
	public void setPoints(Vector3[] pts_)
	{
		if (pts_.Length < 4)
		{
			LeanTween.logError("LeanTween - When passing values for a vector path, you must pass four or more values!");
		}
		if (pts_.Length % 4 != 0)
		{
			LeanTween.logError("LeanTween - When passing values for a vector path, they must be in sets of four: controlPoint1, controlPoint2, endPoint2, controlPoint2, controlPoint2...");
		}
		this.pts = pts_;
		int num = 0;
		this.beziers = new LTBezier[this.pts.Length / 4];
		this.lengthRatio = new float[this.beziers.Length];
		this.length = 0f;
		for (int i = 0; i < this.pts.Length; i += 4)
		{
			this.beziers[num] = new LTBezier(this.pts[i], this.pts[i + 2], this.pts[i + 1], this.pts[i + 3], 0.05f);
			this.length += this.beziers[num].length;
			num++;
		}
		for (int i = 0; i < this.beziers.Length; i++)
		{
			this.lengthRatio[i] = this.beziers[i].length / this.length;
		}
	}

	// Token: 0x040008A4 RID: 2212
	private LTBezier[] beziers;

	// Token: 0x040008A5 RID: 2213
	public float length;

	// Token: 0x040008A6 RID: 2214
	private float[] lengthRatio;

	// Token: 0x040008A7 RID: 2215
	public bool orientToPath;

	// Token: 0x040008A8 RID: 2216
	public bool orientToPath2d;

	// Token: 0x040008A9 RID: 2217
	public Vector3[] pts;
}

using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
public class LTBezier
{
	// Token: 0x06000C85 RID: 3205 RVA: 0x0003E1A8 File Offset: 0x0003C5A8
	public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision)
	{
		this.a = a;
		this.aa = -a + 3f * (b - c) + d;
		this.bb = 3f * (a + c) - 6f * b;
		this.cc = 3f * (b - a);
		this.len = 1f / precision;
		this.arcLengths = new float[(int)this.len + 1];
		this.arcLengths[0] = 0f;
		Vector3 vector = a;
		float num = 0f;
		int num2 = 1;
		while ((float)num2 <= this.len)
		{
			Vector3 vector2 = this.bezierPoint((float)num2 * precision);
			num += (vector - vector2).magnitude;
			this.arcLengths[num2] = num;
			vector = vector2;
			num2++;
		}
		this.length = num;
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x0003E2A9 File Offset: 0x0003C6A9
	private Vector3 bezierPoint(float t)
	{
		return ((this.aa * t + this.bb) * t + this.cc) * t + this.a;
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x0003E2E4 File Offset: 0x0003C6E4
	private float map(float u)
	{
		float num = u * this.arcLengths[(int)this.len];
		int i = 0;
		int num2 = (int)this.len;
		int num3 = 0;
		while (i < num2)
		{
			num3 = i + ((int)((float)(num2 - i) / 2f) | 0);
			if (this.arcLengths[num3] < num)
			{
				i = num3 + 1;
			}
			else
			{
				num2 = num3;
			}
		}
		if (this.arcLengths[num3] > num)
		{
			num3--;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		return ((float)num3 + (num - this.arcLengths[num3]) / (this.arcLengths[num3 + 1] - this.arcLengths[num3])) / this.len;
	}

	// Token: 0x06000C88 RID: 3208 RVA: 0x0003E386 File Offset: 0x0003C786
	public Vector3 point(float t)
	{
		return this.bezierPoint(this.map(t));
	}

	// Token: 0x0400089D RID: 2205
	private Vector3 a;

	// Token: 0x0400089E RID: 2206
	private Vector3 aa;

	// Token: 0x0400089F RID: 2207
	private float[] arcLengths;

	// Token: 0x040008A0 RID: 2208
	private Vector3 bb;

	// Token: 0x040008A1 RID: 2209
	private Vector3 cc;

	// Token: 0x040008A2 RID: 2210
	private float len;

	// Token: 0x040008A3 RID: 2211
	public float length;
}

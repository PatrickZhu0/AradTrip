using System;

// Token: 0x02000193 RID: 403
[Serializable]
public struct VPercent
{
	// Token: 0x06000C0B RID: 3083 RVA: 0x0003D189 File Offset: 0x0003B589
	public VPercent(int i)
	{
		this.i = i;
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x0003D192 File Offset: 0x0003B592
	public VPercent(float f)
	{
		this.i = IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000C0D RID: 3085 RVA: 0x0003D1AA File Offset: 0x0003B5AA
	public float f
	{
		get
		{
			return (float)this.i * 0.001f;
		}
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x0003D1BC File Offset: 0x0003B5BC
	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		VPercent vpercent = (VPercent)o;
		return this.i == vpercent.i;
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0003D1E7 File Offset: 0x0003B5E7
	public override int GetHashCode()
	{
		return this.i.GetHashCode();
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x0003D1FA File Offset: 0x0003B5FA
	public static VPercent Min(VPercent a, VPercent b)
	{
		return new VPercent(Math.Min(a.i, b.i));
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0003D214 File Offset: 0x0003B614
	public static VPercent Max(VPercent a, VPercent b)
	{
		return new VPercent(Math.Max(a.i, b.i));
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0003D230 File Offset: 0x0003B630
	public static VPercent Conver2VInt(long n, long d)
	{
		return new VPercent
		{
			i = (int)(n * 1000L / d)
		};
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x0003D258 File Offset: 0x0003B658
	public override string ToString()
	{
		return this.scalar.ToString();
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0003D279 File Offset: 0x0003B679
	public float scalar
	{
		get
		{
			return (float)this.i * 0.001f;
		}
	}

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06000C15 RID: 3093 RVA: 0x0003D288 File Offset: 0x0003B688
	public VFactor factor
	{
		get
		{
			return new VFactor((long)this.i, 1000L);
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0003D29C File Offset: 0x0003B69C
	public VFactor precent
	{
		get
		{
			return new VFactor((long)this.i, 100000L);
		}
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x0003D2B0 File Offset: 0x0003B6B0
	public static int interPercent2VPercent(int interPercent)
	{
		return interPercent * 1000;
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x0003D2B9 File Offset: 0x0003B6B9
	public static int Conver(float f)
	{
		return IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x0003D2CB File Offset: 0x0003B6CB
	public static int Conver(float n, int d)
	{
		return IntMath.Float2IntWithFixed((double)n * (double)d, 1L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x0003D2DD File Offset: 0x0003B6DD
	public static int ConverFloor(float n, int d)
	{
		return (int)Math.Floor((double)(n * (float)d));
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x0003D2EA File Offset: 0x0003B6EA
	public static explicit operator VPercent(float f)
	{
		return new VPercent(IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven));
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x0003D301 File Offset: 0x0003B701
	public static implicit operator VPercent(int i)
	{
		return new VPercent(i);
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x0003D309 File Offset: 0x0003B709
	public static explicit operator float(VPercent ob)
	{
		return (float)ob.i * 1000f;
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x0003D319 File Offset: 0x0003B719
	public static explicit operator long(VPercent ob)
	{
		return (long)ob.i;
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x0003D323 File Offset: 0x0003B723
	public static VPercent operator +(VPercent a, VPercent b)
	{
		return new VPercent(a.i + b.i);
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x0003D339 File Offset: 0x0003B739
	public static VPercent operator -(VPercent a, VPercent b)
	{
		return new VPercent(a.i - b.i);
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x0003D34F File Offset: 0x0003B74F
	public static bool operator ==(VPercent a, VPercent b)
	{
		return a.i == b.i;
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x0003D361 File Offset: 0x0003B761
	public static bool operator !=(VPercent a, VPercent b)
	{
		return a.i != b.i;
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x0003D376 File Offset: 0x0003B776
	public static bool operator >=(VPercent a, VPercent b)
	{
		return a.i >= b.i;
	}

	// Token: 0x06000C24 RID: 3108 RVA: 0x0003D38B File Offset: 0x0003B78B
	public static bool operator <=(VPercent a, VPercent b)
	{
		return a.i <= b.i;
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x0003D3A0 File Offset: 0x0003B7A0
	public static bool operator >(VPercent a, VPercent b)
	{
		return a.i > b.i;
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x0003D3B2 File Offset: 0x0003B7B2
	public static bool operator <(VPercent a, VPercent b)
	{
		return a.i < b.i;
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x0003D3C4 File Offset: 0x0003B7C4
	public static bool operator ==(VPercent a, int b)
	{
		return a.i == b;
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x0003D3D0 File Offset: 0x0003B7D0
	public static bool operator !=(VPercent a, int b)
	{
		return a.i != b;
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x0003D3DF File Offset: 0x0003B7DF
	public static bool operator >=(VPercent a, int b)
	{
		return a.i >= b;
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x0003D3EE File Offset: 0x0003B7EE
	public static bool operator <=(VPercent a, int b)
	{
		return a.i <= b;
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x0003D3FD File Offset: 0x0003B7FD
	public static bool operator >(VPercent a, int b)
	{
		return a.i > b;
	}

	// Token: 0x06000C2C RID: 3116 RVA: 0x0003D409 File Offset: 0x0003B809
	public static bool operator <(VPercent a, int b)
	{
		return a.i < b;
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x0003D415 File Offset: 0x0003B815
	public static VPercent operator -(VPercent a)
	{
		a.i = -a.i;
		return a;
	}

	// Token: 0x04000888 RID: 2184
	public int i;

	// Token: 0x04000889 RID: 2185
	public static readonly VPercent zero = new VPercent(0);

	// Token: 0x0400088A RID: 2186
	public static readonly VPercent one = new VPercent(1f);

	// Token: 0x0400088B RID: 2187
	public static readonly VPercent half = new VPercent(0.5f);

	// Token: 0x0400088C RID: 2188
	private const long kValidBit = 1000L;

	// Token: 0x0400088D RID: 2189
	private const long kFloatBit = 100L;
}

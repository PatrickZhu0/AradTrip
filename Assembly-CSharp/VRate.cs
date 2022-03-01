using System;

// Token: 0x02000194 RID: 404
[Serializable]
public struct VRate
{
	// Token: 0x06000C2F RID: 3119 RVA: 0x0003D452 File Offset: 0x0003B852
	public VRate(int i)
	{
		this.i = i;
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x0003D45B File Offset: 0x0003B85B
	public VRate(float f)
	{
		this.i = IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06000C31 RID: 3121 RVA: 0x0003D473 File Offset: 0x0003B873
	public float f
	{
		get
		{
			return (float)this.i * 0.001f;
		}
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x0003D484 File Offset: 0x0003B884
	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		VRate vrate = (VRate)o;
		return this.i == vrate.i;
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x0003D4AF File Offset: 0x0003B8AF
	public override int GetHashCode()
	{
		return this.i.GetHashCode();
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x0003D4C2 File Offset: 0x0003B8C2
	public static VRate Min(VRate a, VRate b)
	{
		return new VRate(Math.Min(a.i, b.i));
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x0003D4DC File Offset: 0x0003B8DC
	public static VRate Max(VRate a, VRate b)
	{
		return new VRate(Math.Max(a.i, b.i));
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x0003D4F8 File Offset: 0x0003B8F8
	public static VRate Conver2VInt(long n, long d)
	{
		return new VRate
		{
			i = (int)(n * 1000L / d)
		};
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x0003D520 File Offset: 0x0003B920
	public override string ToString()
	{
		return this.scalar.ToString();
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06000C38 RID: 3128 RVA: 0x0003D541 File Offset: 0x0003B941
	public float scalar
	{
		get
		{
			return (float)this.i * 0.001f;
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06000C39 RID: 3129 RVA: 0x0003D550 File Offset: 0x0003B950
	public VFactor factor
	{
		get
		{
			return new VFactor((long)this.i, 1000L);
		}
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x0003D564 File Offset: 0x0003B964
	public static VFactor Factor(int v)
	{
		return new VFactor((long)v, 1000L);
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x0003D573 File Offset: 0x0003B973
	public static int Conver(float f)
	{
		return IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x0003D585 File Offset: 0x0003B985
	public static int Conver(float n, int d)
	{
		return IntMath.Float2IntWithFixed(n * (float)d, 1L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x0003D596 File Offset: 0x0003B996
	public static int ConverFloor(float n, int d)
	{
		return (int)Math.Floor((double)(n * (float)d));
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x0003D5A3 File Offset: 0x0003B9A3
	public static explicit operator VRate(float f)
	{
		return new VRate(IntMath.Float2IntWithFixed(f, 1000L, 100L, MidpointRounding.ToEven));
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x0003D5BA File Offset: 0x0003B9BA
	public static implicit operator VRate(int i)
	{
		return new VRate(i);
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x0003D5C2 File Offset: 0x0003B9C2
	public static explicit operator float(VRate ob)
	{
		return (float)ob.i * 1000f;
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x0003D5D2 File Offset: 0x0003B9D2
	public static explicit operator long(VRate ob)
	{
		return (long)ob.i;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x0003D5DC File Offset: 0x0003B9DC
	public static VRate operator +(VRate a, VRate b)
	{
		return new VRate(a.i + b.i);
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x0003D5F2 File Offset: 0x0003B9F2
	public static VRate operator -(VRate a, VRate b)
	{
		return new VRate(a.i - b.i);
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x0003D608 File Offset: 0x0003BA08
	public static bool operator ==(VRate a, VRate b)
	{
		return a.i == b.i;
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0003D61A File Offset: 0x0003BA1A
	public static bool operator !=(VRate a, VRate b)
	{
		return a.i != b.i;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x0003D62F File Offset: 0x0003BA2F
	public static bool operator >=(VRate a, VRate b)
	{
		return a.i >= b.i;
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x0003D644 File Offset: 0x0003BA44
	public static bool operator <=(VRate a, VRate b)
	{
		return a.i <= b.i;
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x0003D659 File Offset: 0x0003BA59
	public static bool operator >(VRate a, VRate b)
	{
		return a.i > b.i;
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x0003D66B File Offset: 0x0003BA6B
	public static bool operator <(VRate a, VRate b)
	{
		return a.i < b.i;
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x0003D67D File Offset: 0x0003BA7D
	public static bool operator ==(VRate a, int b)
	{
		return a.i == b;
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x0003D689 File Offset: 0x0003BA89
	public static bool operator !=(VRate a, int b)
	{
		return a.i != b;
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x0003D698 File Offset: 0x0003BA98
	public static bool operator >=(VRate a, int b)
	{
		return a.i >= b;
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x0003D6A7 File Offset: 0x0003BAA7
	public static bool operator <=(VRate a, int b)
	{
		return a.i <= b;
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x0003D6B6 File Offset: 0x0003BAB6
	public static bool operator >(VRate a, int b)
	{
		return a.i > b;
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x0003D6C2 File Offset: 0x0003BAC2
	public static bool operator <(VRate a, int b)
	{
		return a.i < b;
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x0003D6CE File Offset: 0x0003BACE
	public static VRate operator -(VRate a)
	{
		a.i = -a.i;
		return a;
	}

	// Token: 0x0400088E RID: 2190
	public int i;

	// Token: 0x0400088F RID: 2191
	public static readonly VRate zero = new VRate(0);

	// Token: 0x04000890 RID: 2192
	public static readonly VRate one = new VRate(1f);

	// Token: 0x04000891 RID: 2193
	public static readonly VRate half = new VRate(0.5f);

	// Token: 0x04000892 RID: 2194
	private const long kValidBit = 1000L;

	// Token: 0x04000893 RID: 2195
	private const long kFloatBit = 100L;
}

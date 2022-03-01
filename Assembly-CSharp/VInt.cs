using System;

// Token: 0x0200018F RID: 399
[Serializable]
public struct VInt
{
	// Token: 0x06000B84 RID: 2948 RVA: 0x0003B68C File Offset: 0x00039A8C
	static VInt()
	{
		VInt.quarter = new VInt(0.25f);
	}

	// Token: 0x06000B85 RID: 2949 RVA: 0x0003B6EF File Offset: 0x00039AEF
	public VInt(int i)
	{
		this.i = i;
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x0003B6F8 File Offset: 0x00039AF8
	public VInt(float f)
	{
		this.i = IntMath.Float2IntWithFixed(f, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0003B710 File Offset: 0x00039B10
	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		VInt vint = (VInt)o;
		return this.i == vint.i;
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0003B73B File Offset: 0x00039B3B
	public override int GetHashCode()
	{
		return this.i.GetHashCode();
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x0003B74E File Offset: 0x00039B4E
	public static VInt Min(VInt a, VInt b)
	{
		return new VInt(Math.Min(a.i, b.i));
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x0003B768 File Offset: 0x00039B68
	public static VInt Max(VInt a, VInt b)
	{
		return new VInt(Math.Max(a.i, b.i));
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x0003B782 File Offset: 0x00039B82
	public override string ToString()
	{
		return this.i.ToString();
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0003B795 File Offset: 0x00039B95
	public float scalar
	{
		get
		{
			return (float)this.i * 0.0001f;
		}
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0003B7A4 File Offset: 0x00039BA4
	public VFactor factor
	{
		get
		{
			return new VFactor((long)this.i, 10000L);
		}
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x0003B7B8 File Offset: 0x00039BB8
	public static int Float2VIntValue(float f)
	{
		return IntMath.Float2IntWithFixed(f, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x0003B7CA File Offset: 0x00039BCA
	public static VInt NewVInt(int n, int d)
	{
		return IntMath.Float2IntWithFixed((double)n / (double)d, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x0003B7E8 File Offset: 0x00039BE8
	public static VInt NewVInt(long n, long d)
	{
		return new VInt
		{
			i = (int)(n * 10000L / d)
		};
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x0003B810 File Offset: 0x00039C10
	public static explicit operator VInt(float f)
	{
		return new VInt(IntMath.Float2IntWithFixed(f, 10000L, 100L, MidpointRounding.ToEven));
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x0003B827 File Offset: 0x00039C27
	public static implicit operator VInt(int i)
	{
		return new VInt(i);
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x0003B82F File Offset: 0x00039C2F
	public static explicit operator float(VInt ob)
	{
		return (float)ob.i * 0.0001f;
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x0003B83F File Offset: 0x00039C3F
	public static explicit operator long(VInt ob)
	{
		return (long)ob.i;
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x0003B849 File Offset: 0x00039C49
	public static VInt operator +(VInt a, VInt b)
	{
		return new VInt(a.i + b.i);
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x0003B85F File Offset: 0x00039C5F
	public static VInt operator -(VInt a, VInt b)
	{
		return new VInt(a.i - b.i);
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0003B875 File Offset: 0x00039C75
	public static bool operator ==(VInt a, VInt b)
	{
		return a.i == b.i;
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0003B887 File Offset: 0x00039C87
	public static bool operator !=(VInt a, VInt b)
	{
		return a.i != b.i;
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0003B89C File Offset: 0x00039C9C
	public static bool operator >=(VInt a, VInt b)
	{
		return a.i >= b.i;
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x0003B8B1 File Offset: 0x00039CB1
	public static bool operator <=(VInt a, VInt b)
	{
		return a.i <= b.i;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x0003B8C6 File Offset: 0x00039CC6
	public static bool operator >(VInt a, VInt b)
	{
		return a.i > b.i;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x0003B8D8 File Offset: 0x00039CD8
	public static bool operator <(VInt a, VInt b)
	{
		return a.i < b.i;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0003B8EA File Offset: 0x00039CEA
	public static bool operator ==(VInt a, int b)
	{
		return a.i == b;
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0003B8F6 File Offset: 0x00039CF6
	public static bool operator !=(VInt a, int b)
	{
		return a.i != b;
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0003B905 File Offset: 0x00039D05
	public static bool operator >=(VInt a, int b)
	{
		return a.i >= b;
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0003B914 File Offset: 0x00039D14
	public static bool operator <=(VInt a, int b)
	{
		return a.i <= b;
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0003B923 File Offset: 0x00039D23
	public static bool operator >(VInt a, int b)
	{
		return a.i > b;
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x0003B92F File Offset: 0x00039D2F
	public static bool operator <(VInt a, int b)
	{
		return a.i < b;
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x0003B93B File Offset: 0x00039D3B
	public static VInt operator -(VInt a)
	{
		a.i = -a.i;
		return a;
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0003B94D File Offset: 0x00039D4D
	public static VInt Clamp(VInt a, VInt min, VInt max)
	{
		if (a < min)
		{
			return min;
		}
		if (a > max)
		{
			return max;
		}
		return a;
	}

	// Token: 0x0400086D RID: 2157
	public int i;

	// Token: 0x0400086E RID: 2158
	public static readonly VInt zero = new VInt(0);

	// Token: 0x0400086F RID: 2159
	public static readonly VInt one = new VInt(1f);

	// Token: 0x04000870 RID: 2160
	public static readonly VInt half = new VInt(0.5f);

	// Token: 0x04000871 RID: 2161
	public static readonly VInt onehalf = new VInt(1.5f);

	// Token: 0x04000872 RID: 2162
	public static readonly VInt quarter;

	// Token: 0x04000873 RID: 2163
	public static readonly VInt zeroDotOne = new VInt(0.1f);
}

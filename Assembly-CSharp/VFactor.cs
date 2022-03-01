using System;

// Token: 0x0200018E RID: 398
[Serializable]
public struct VFactor
{
	// Token: 0x06000B58 RID: 2904 RVA: 0x0003AF05 File Offset: 0x00039305
	public VFactor(long n, long d)
	{
		this.nom = n;
		this.den = d;
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x0003AF15 File Offset: 0x00039315
	public VFactor(long n)
	{
		this.nom = n;
		this.den = 1000L;
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0003AF9A File Offset: 0x0003939A
	public int roundInt
	{
		get
		{
			return (int)IntMath.Divide(this.nom, this.den);
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0003AFAE File Offset: 0x000393AE
	public int integer
	{
		get
		{
			return (int)(this.nom / this.den);
		}
	}

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0003AFC0 File Offset: 0x000393C0
	public float single
	{
		get
		{
			double num = (double)this.nom / (double)this.den;
			return (float)num;
		}
	}

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0003AFE0 File Offset: 0x000393E0
	public VInt vint
	{
		get
		{
			return new VInt
			{
				i = (int)(this.nom * 10000L / this.den)
			};
		}
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x0003B014 File Offset: 0x00039414
	public static VFactor NewVFactorF(float value, int d)
	{
		return new VFactor
		{
			nom = (long)IntMath.Float2Int(value, d),
			den = (long)d
		};
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x0003B042 File Offset: 0x00039442
	public static VFactor NewVFactor(int n, int d)
	{
		return new VFactor((long)n, (long)d);
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x0003B04D File Offset: 0x0003944D
	public static VFactor NewVFactor(long n, long d)
	{
		return new VFactor(n, d);
	}

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0003B058 File Offset: 0x00039458
	public bool IsPositive
	{
		get
		{
			DebugHelper.Assert(this.den != 0L, "VFactor: denominator is zero !");
			if (this.nom == 0L)
			{
				return false;
			}
			bool flag = this.nom > 0L;
			bool flag2 = this.den > 0L;
			return !(flag ^ flag2);
		}
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0003B0A8 File Offset: 0x000394A8
	public bool IsNegative
	{
		get
		{
			DebugHelper.Assert(this.den != 0L, "VFactor: denominator is zero !");
			if (this.nom == 0L)
			{
				return false;
			}
			bool flag = this.nom > 0L;
			bool flag2 = this.den > 0L;
			return flag ^ flag2;
		}
	}

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0003B0F4 File Offset: 0x000394F4
	public bool IsZero
	{
		get
		{
			return this.nom == 0L;
		}
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x0003B100 File Offset: 0x00039500
	public override bool Equals(object obj)
	{
		return obj != null && base.GetType() == obj.GetType() && this == (VFactor)obj;
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x0003B137 File Offset: 0x00039537
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0003B149 File Offset: 0x00039549
	public VFactor Inverse
	{
		get
		{
			return new VFactor(this.den, this.nom);
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x0003B15C File Offset: 0x0003955C
	public override string ToString()
	{
		return this.single.ToString();
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x0003B180 File Offset: 0x00039580
	public void strip()
	{
		while ((this.nom & VFactor.mask_) > VFactor.upper_ && (this.den & VFactor.mask_) > VFactor.upper_)
		{
			this.nom >>= 1;
			this.den >>= 1;
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x0003B1DC File Offset: 0x000395DC
	public static bool operator <(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		return (b.den > 0L ^ a.den > 0L) ? (num > num2) : (num < num2);
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x0003B234 File Offset: 0x00039634
	public static bool operator >(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		return (b.den > 0L ^ a.den > 0L) ? (num < num2) : (num > num2);
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x0003B28C File Offset: 0x0003968C
	public static bool operator <=(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		return (b.den > 0L ^ a.den > 0L) ? (num >= num2) : (num <= num2);
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x0003B2E8 File Offset: 0x000396E8
	public static bool operator >=(VFactor a, VFactor b)
	{
		long num = a.nom * b.den;
		long num2 = b.nom * a.den;
		return (b.den > 0L ^ a.den > 0L) ? (num <= num2) : (num >= num2);
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0003B344 File Offset: 0x00039744
	public static bool operator ==(VFactor a, VFactor b)
	{
		return a.nom * b.den == b.nom * a.den;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0003B366 File Offset: 0x00039766
	public static bool operator !=(VFactor a, VFactor b)
	{
		return a.nom * b.den != b.nom * a.den;
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x0003B38C File Offset: 0x0003978C
	public static bool operator <(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den > 0L) ? (num < num2) : (num > num2);
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x0003B3C8 File Offset: 0x000397C8
	public static bool operator >(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den > 0L) ? (num > num2) : (num < num2);
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x0003B404 File Offset: 0x00039804
	public static bool operator <=(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den > 0L) ? (num <= num2) : (num >= num2);
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x0003B444 File Offset: 0x00039844
	public static bool operator >=(VFactor a, long b)
	{
		long num = a.nom;
		long num2 = b * a.den;
		return (a.den > 0L) ? (num >= num2) : (num <= num2);
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x0003B484 File Offset: 0x00039884
	public static bool operator ==(VFactor a, long b)
	{
		return a.nom == b * a.den;
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0003B498 File Offset: 0x00039898
	public static bool operator !=(VFactor a, long b)
	{
		return a.nom != b * a.den;
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0003B4B0 File Offset: 0x000398B0
	public static VFactor operator +(VFactor a, VFactor b)
	{
		return new VFactor
		{
			nom = a.nom * b.den + b.nom * a.den,
			den = a.den * b.den
		};
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x0003B502 File Offset: 0x00039902
	public static VFactor operator +(VFactor a, long b)
	{
		a.nom += b * a.den;
		return a;
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0003B51C File Offset: 0x0003991C
	public static VFactor operator -(VFactor a, VFactor b)
	{
		return new VFactor
		{
			nom = a.nom * b.den - b.nom * a.den,
			den = a.den * b.den
		};
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0003B56E File Offset: 0x0003996E
	public static VFactor operator -(VFactor a, long b)
	{
		a.nom -= b * a.den;
		return a;
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0003B588 File Offset: 0x00039988
	public static VFactor operator *(VFactor a, long b)
	{
		a.nom *= b;
		return a;
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x0003B59A File Offset: 0x0003999A
	public static VFactor operator *(VFactor a, VFactor b)
	{
		a.nom *= b.nom;
		a.den *= b.den;
		return a;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0003B5C7 File Offset: 0x000399C7
	public static VFactor operator /(VFactor a, VFactor b)
	{
		a.nom *= b.den;
		a.den *= b.nom;
		return a;
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x0003B5F4 File Offset: 0x000399F4
	public static VFactor operator /(VFactor a, long b)
	{
		a.den *= b;
		return a;
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0003B606 File Offset: 0x00039A06
	public static VInt3 operator *(VInt3 v, VFactor f)
	{
		return IntMath.Divide(v, f.nom, f.den);
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0003B61C File Offset: 0x00039A1C
	public static VInt2 operator *(VInt2 v, VFactor f)
	{
		return IntMath.Divide(v, f.nom, f.den);
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0003B632 File Offset: 0x00039A32
	public static VInt3 operator /(VInt3 v, VFactor f)
	{
		return IntMath.Divide(v, f.den, f.nom);
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x0003B648 File Offset: 0x00039A48
	public static VInt2 operator /(VInt2 v, VFactor f)
	{
		return IntMath.Divide(v, f.den, f.nom);
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x0003B65E File Offset: 0x00039A5E
	public static int operator *(int i, VFactor f)
	{
		return (int)IntMath.Divide((long)i * f.nom, f.den);
	}

	// Token: 0x06000B83 RID: 2947 RVA: 0x0003B677 File Offset: 0x00039A77
	public static VFactor operator -(VFactor a)
	{
		a.nom = -a.nom;
		return a;
	}

	// Token: 0x04000865 RID: 2149
	public long nom;

	// Token: 0x04000866 RID: 2150
	public long den;

	// Token: 0x04000867 RID: 2151
	[NonSerialized]
	public static VFactor zero = new VFactor(0L, 1L);

	// Token: 0x04000868 RID: 2152
	[NonSerialized]
	public static VFactor one = new VFactor(1L, 1L);

	// Token: 0x04000869 RID: 2153
	[NonSerialized]
	public static VFactor pi = new VFactor(31416L, 10000L);

	// Token: 0x0400086A RID: 2154
	[NonSerialized]
	public static VFactor twoPi = new VFactor(62832L, 10000L);

	// Token: 0x0400086B RID: 2155
	private static long mask_ = long.MaxValue;

	// Token: 0x0400086C RID: 2156
	private static long upper_ = 16777215L;
}

using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
public class IntMath
{
	// Token: 0x06000B28 RID: 2856 RVA: 0x0003A060 File Offset: 0x00038460
	public static int Float2IntWithFixed(float x, long validBit = 10000L, long floatBit = 100L, MidpointRounding rounding = MidpointRounding.ToEven)
	{
		return IntMath.Float2IntWithFixed((double)x, validBit, floatBit, rounding);
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x0003A06C File Offset: 0x0003846C
	public static int Float2IntWithFixed(double x, long validBit = 10000L, long floatBit = 100L, MidpointRounding rounding = MidpointRounding.ToEven)
	{
		long num = (long)Math.Round(x * (double)(validBit * floatBit), rounding);
		bool flag = num < 0L;
		num = Math.Abs(num);
		long num2 = num / floatBit;
		long num3 = num % floatBit;
		if (num3 >= floatBit / 2L)
		{
			num2 += 1L;
		}
		return (int)((!flag) ? num2 : (-(int)num2));
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x0003A0BA File Offset: 0x000384BA
	public static int Float2Int(float f, int d)
	{
		return IntMath.Float2IntWithFixed(f * (float)d, (long)GlobalLogic.VALUE_1, 10000L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x0003A0D2 File Offset: 0x000384D2
	public static int Float2Int(float f)
	{
		return IntMath.Float2IntWithFixed(f, (long)GlobalLogic.VALUE_1, 10000L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x0003A0E7 File Offset: 0x000384E7
	public static int Double2Int(double d)
	{
		return IntMath.Float2IntWithFixed(d, (long)GlobalLogic.VALUE_1, 10000L, MidpointRounding.ToEven);
	}

	// Token: 0x06000B2D RID: 2861 RVA: 0x0003A0FC File Offset: 0x000384FC
	public static VFactor acos(long nom, long den)
	{
		int num = (int)IntMath.Divide(nom * (long)AcosLookupTable.HALF_COUNT, den) + AcosLookupTable.HALF_COUNT;
		num = Mathf.Clamp(num, 0, AcosLookupTable.COUNT);
		return new VFactor
		{
			nom = (long)AcosLookupTable.table[num],
			den = 10000L
		};
	}

	// Token: 0x06000B2E RID: 2862 RVA: 0x0003A154 File Offset: 0x00038554
	public static VFactor atan2(int y, int x)
	{
		int num;
		int num2;
		if (x < 0)
		{
			if (y < 0)
			{
				x = -x;
				y = -y;
				num = 1;
			}
			else
			{
				x = -x;
				num = -1;
			}
			num2 = -31416;
		}
		else
		{
			if (y < 0)
			{
				y = -y;
				num = -1;
			}
			else
			{
				num = 1;
			}
			num2 = 0;
		}
		int dim = Atan2LookupTable.DIM;
		long num3 = (long)(dim - 1);
		long b = (x < y) ? ((long)y) : ((long)x);
		int num4 = (int)IntMath.Divide((long)x * num3, b);
		int num5 = (int)IntMath.Divide((long)y * num3, b);
		int num6 = Atan2LookupTable.table[num5 * dim + num4];
		return new VFactor
		{
			nom = (long)((num6 + num2) * num),
			den = 10000L
		};
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x0003A212 File Offset: 0x00038612
	public static int CeilPowerOfTwo(int x)
	{
		x--;
		x |= x >> 1;
		x |= x >> 2;
		x |= x >> 4;
		x |= x >> 8;
		x |= x >> 16;
		x++;
		return x;
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x0003A243 File Offset: 0x00038643
	public static long Clamp(long a, long min, long max)
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

	// Token: 0x06000B31 RID: 2865 RVA: 0x0003A258 File Offset: 0x00038658
	public static VFactor cos(long nom, long den)
	{
		int index = SinCosLookupTable.getIndex(nom, den);
		return new VFactor((long)SinCosLookupTable.cos_table[index], (long)SinCosLookupTable.FACTOR);
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x0003A280 File Offset: 0x00038680
	public static int Divide(int a, int b)
	{
		int num = ((a ^ b) & int.MinValue) >> 31;
		int num2 = num * -2 + 1;
		return (a + b / 2 * num2) / b;
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x0003A2AC File Offset: 0x000386AC
	public static long Divide(long a, long b)
	{
		long num = ((a ^ b) & long.MinValue) >> 63;
		long num2 = num * -2L + 1L;
		return (a + b / 2L * num2) / b;
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x0003A2DD File Offset: 0x000386DD
	public static VInt2 Divide(VInt2 a, long b)
	{
		a.x = (int)IntMath.Divide((long)a.x, b);
		a.y = (int)IntMath.Divide((long)a.y, b);
		return a;
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x0003A30C File Offset: 0x0003870C
	public static VInt3 Divide(VInt3 a, int b)
	{
		a.x = IntMath.Divide(a.x, b);
		a.y = IntMath.Divide(a.y, b);
		a.z = IntMath.Divide(a.z, b);
		return a;
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x0003A34C File Offset: 0x0003874C
	public static VInt3 Divide(VInt3 a, long b)
	{
		a.x = (int)IntMath.Divide((long)a.x, b);
		a.y = (int)IntMath.Divide((long)a.y, b);
		a.z = (int)IntMath.Divide((long)a.z, b);
		return a;
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x0003A39C File Offset: 0x0003879C
	public static VInt2 Divide(VInt2 a, long m, long b)
	{
		a.x = (int)IntMath.Divide((long)a.x * m, b);
		a.y = (int)IntMath.Divide((long)a.y * m, b);
		return a;
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x0003A3D0 File Offset: 0x000387D0
	public static VInt3 Divide(VInt3 a, long m, long b)
	{
		a.x = (int)IntMath.Divide((long)a.x * m, b);
		a.y = (int)IntMath.Divide((long)a.y * m, b);
		a.z = (int)IntMath.Divide((long)a.z * m, b);
		return a;
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x0003A428 File Offset: 0x00038828
	public static VInt Mutiple(VInt a, VInt b)
	{
		long num = (long)a.i;
		long num2 = (long)b.i;
		long num3 = num * num2 / 10000L;
		a.i = (int)num3;
		return a;
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x0003A45C File Offset: 0x0003885C
	public static VInt Divide(VInt a, VInt b)
	{
		long num = (long)a.i;
		long num2 = (long)b.i;
		if (num2 == 0L)
		{
			a.i = 0;
			return a;
		}
		long num3 = num / num2 * 10000L;
		a.i = (int)num3;
		return a;
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x0003A4A4 File Offset: 0x000388A4
	public static bool IntersectSegment(ref VInt2 seg1Src, ref VInt2 seg1Vec, ref VInt2 seg2Src, ref VInt2 seg2Vec, out VInt2 interPoint)
	{
		long num;
		long num2;
		long num3;
		IntMath.SegvecToLinegen(ref seg1Src, ref seg1Vec, out num, out num2, out num3);
		long num4;
		long num5;
		long num6;
		IntMath.SegvecToLinegen(ref seg2Src, ref seg2Vec, out num4, out num5, out num6);
		long num7 = num * num5 - num4 * num2;
		if (num7 != 0L)
		{
			long num8 = IntMath.Divide(num2 * num6 - num5 * num3, num7);
			long num9 = IntMath.Divide(num4 * num3 - num * num6, num7);
			bool result = IntMath.IsPointOnSegment(ref seg1Src, ref seg1Vec, num8, num9) && IntMath.IsPointOnSegment(ref seg2Src, ref seg2Vec, num8, num9);
			interPoint.x = (int)num8;
			interPoint.y = (int)num9;
			return result;
		}
		interPoint = VInt2.zero;
		return false;
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x0003A548 File Offset: 0x00038948
	private static bool IsPointOnSegment(ref VInt2 segSrc, ref VInt2 segVec, long x, long y)
	{
		long num = x - (long)segSrc.x;
		long num2 = y - (long)segSrc.y;
		return (long)segVec.x * num + (long)segVec.y * num2 >= 0L && num * num + num2 * num2 <= segVec.sqrMagnitudeLong;
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x0003A598 File Offset: 0x00038998
	public static bool IsPowerOfTwo(int x)
	{
		return (x & x - 1) == 0;
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x0003A5A2 File Offset: 0x000389A2
	public static int Lerp(int src, int dest, int nom, int den)
	{
		return IntMath.Divide(src * den + (dest - src) * nom, den);
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x0003A5B3 File Offset: 0x000389B3
	public static long Lerp(long src, long dest, long nom, long den)
	{
		return IntMath.Divide(src * den + (dest - src) * nom, den);
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x0003A5C4 File Offset: 0x000389C4
	public static long Max(long a, long b)
	{
		return (a > b) ? a : b;
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x0003A5D4 File Offset: 0x000389D4
	public static long Min(long a, long b)
	{
		return (b >= a) ? a : b;
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x0003A5E4 File Offset: 0x000389E4
	public static int Max(int a, int b)
	{
		return (a > b) ? a : b;
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x0003A5F4 File Offset: 0x000389F4
	public static int Min(int a, int b)
	{
		return (b >= a) ? a : b;
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x0003A604 File Offset: 0x00038A04
	public static bool PointInPolygon(ref VInt2 pnt, VInt2[] plg)
	{
		if (plg == null || plg.Length < 3)
		{
			return false;
		}
		bool flag = false;
		int i = 0;
		int num = plg.Length - 1;
		while (i < plg.Length)
		{
			VInt2 vint = plg[i];
			VInt2 vint2 = plg[num];
			if ((vint.y <= pnt.y && pnt.y < vint2.y) || (vint2.y <= pnt.y && pnt.y < vint.y))
			{
				int num2 = vint2.y - vint.y;
				long num3 = (long)((pnt.y - vint.y) * (vint2.x - vint.x) - (pnt.x - vint.x) * num2);
				if (num2 > 0)
				{
					if (num3 > 0L)
					{
						flag = !flag;
					}
				}
				else if (num3 < 0L)
				{
					flag = !flag;
				}
			}
			num = i++;
		}
		return flag;
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x0003A714 File Offset: 0x00038B14
	public static bool SegIntersectPlg(ref VInt2 segSrc, ref VInt2 segVec, VInt2[] plg, out VInt2 nearPoint, out VInt2 projectVec)
	{
		nearPoint = VInt2.zero;
		projectVec = VInt2.zero;
		if (plg == null || plg.Length < 2)
		{
			return false;
		}
		bool result = false;
		long num = -1L;
		int num2 = -1;
		for (int i = 0; i < plg.Length; i++)
		{
			VInt2 vint = plg[(i + 1) % plg.Length] - plg[i];
			VInt2 vint2;
			if (IntMath.IntersectSegment(ref segSrc, ref segVec, ref plg[i], ref vint, out vint2))
			{
				long sqrMagnitudeLong = (vint2 - segSrc).sqrMagnitudeLong;
				if (num < 0L || sqrMagnitudeLong < num)
				{
					nearPoint = vint2;
					num = sqrMagnitudeLong;
					num2 = i;
					result = true;
				}
			}
		}
		if (num2 >= 0)
		{
			VInt2 lhs = plg[(num2 + 1) % plg.Length] - plg[num2];
			VInt2 vint3 = segSrc + segVec - nearPoint;
			long num3 = (long)(vint3.x * lhs.x + vint3.y * lhs.y);
			if (num3 < 0L)
			{
				num3 = -num3;
				lhs = -lhs;
			}
			long sqrMagnitudeLong2 = lhs.sqrMagnitudeLong;
			projectVec.x = (int)IntMath.Divide((long)lhs.x * num3, sqrMagnitudeLong2);
			projectVec.y = (int)IntMath.Divide((long)lhs.y * num3, sqrMagnitudeLong2);
		}
		return result;
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x0003A898 File Offset: 0x00038C98
	public static void SegvecToLinegen(ref VInt2 segSrc, ref VInt2 segVec, out long a, out long b, out long c)
	{
		a = (long)segVec.y;
		b = (long)(-(long)segVec.x);
		c = (long)(segVec.x * segSrc.y - segSrc.x * segVec.y);
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x0003A8CC File Offset: 0x00038CCC
	public static VFactor sin(long nom, long den)
	{
		int index = SinCosLookupTable.getIndex(nom, den);
		return new VFactor((long)SinCosLookupTable.sin_table[index], (long)SinCosLookupTable.FACTOR);
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x0003A8F4 File Offset: 0x00038CF4
	public static void sincos(out VFactor s, out VFactor c, VFactor angle)
	{
		int index = SinCosLookupTable.getIndex(angle.nom, angle.den);
		s = new VFactor((long)SinCosLookupTable.sin_table[index], (long)SinCosLookupTable.FACTOR);
		c = new VFactor((long)SinCosLookupTable.cos_table[index], (long)SinCosLookupTable.FACTOR);
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x0003A940 File Offset: 0x00038D40
	public static void sincos(out VFactor s, out VFactor c, long nom, long den)
	{
		int index = SinCosLookupTable.getIndex(nom, den);
		s = new VFactor((long)SinCosLookupTable.sin_table[index], (long)SinCosLookupTable.FACTOR);
		c = new VFactor((long)SinCosLookupTable.cos_table[index], (long)SinCosLookupTable.FACTOR);
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x0003A97D File Offset: 0x00038D7D
	public static int Sqrt(long a)
	{
		if (a <= 0L)
		{
			return 0;
		}
		if (a <= (long)((ulong)-1))
		{
			return (int)IntMath.Sqrt32((uint)a);
		}
		return (int)IntMath.Sqrt64((ulong)a);
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x0003A9A0 File Offset: 0x00038DA0
	public static uint Sqrt32(uint a)
	{
		uint num = 0U;
		uint num2 = 0U;
		for (int i = 0; i < 16; i++)
		{
			num2 <<= 1;
			num <<= 2;
			num += a >> 30;
			a <<= 2;
			if (num2 < num)
			{
				num2 += 1U;
				num -= num2;
				num2 += 1U;
			}
		}
		return num2 >> 1 & 65535U;
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x0003A9F4 File Offset: 0x00038DF4
	public static ulong Sqrt64(ulong a)
	{
		ulong num = 0UL;
		ulong num2 = 0UL;
		for (int i = 0; i < 32; i++)
		{
			num2 <<= 1;
			num <<= 2;
			num += a >> 62;
			a <<= 2;
			if (num2 < num)
			{
				num2 += 1UL;
				num -= num2;
				num2 += 1UL;
			}
		}
		return num2 >> 1 & (ulong)-1;
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x0003AA49 File Offset: 0x00038E49
	public static long SqrtLong(long a)
	{
		if (a <= 0L)
		{
			return 0L;
		}
		if (a <= (long)((ulong)-1))
		{
			return (long)((ulong)IntMath.Sqrt32((uint)a));
		}
		return (long)IntMath.Sqrt64((ulong)a);
	}

	// Token: 0x06000B4E RID: 2894 RVA: 0x0003AA70 File Offset: 0x00038E70
	public static VInt3 Transform(ref VInt3 point, ref VInt3 forward, ref VInt3 trans)
	{
		VInt3 up = VInt3.up;
		VInt3 vint = VInt3.Cross(VInt3.up, forward);
		return IntMath.Transform(ref point, ref vint, ref up, ref forward, ref trans);
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x0003AAA0 File Offset: 0x00038EA0
	public static VInt3 Transform(VInt3 point, VInt3 forward, VInt3 trans)
	{
		VInt3 up = VInt3.up;
		VInt3 vint = VInt3.Cross(VInt3.up, forward);
		return IntMath.Transform(ref point, ref vint, ref up, ref forward, ref trans);
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x0003AAD0 File Offset: 0x00038ED0
	public static VInt3 Transform(VInt3 point, VInt3 forward, VInt3 trans, VInt3 scale)
	{
		VInt3 up = VInt3.up;
		VInt3 vint = VInt3.Cross(VInt3.up, forward);
		return IntMath.Transform(ref point, ref vint, ref up, ref forward, ref trans, ref scale);
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x0003AB00 File Offset: 0x00038F00
	public static VInt3 Transform(ref VInt3 point, ref VInt3 axis_x, ref VInt3 axis_y, ref VInt3 axis_z, ref VInt3 trans)
	{
		return new VInt3(IntMath.Divide(axis_x.x * point.x + axis_y.x * point.y + axis_z.x * point.z, 1000) + trans.x, IntMath.Divide(axis_x.y * point.x + axis_y.y * point.y + axis_z.y * point.z, 1000) + trans.y, IntMath.Divide(axis_x.z * point.x + axis_y.z * point.y + axis_z.z * point.z, 1000) + trans.z);
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x0003ABC4 File Offset: 0x00038FC4
	public static VInt3 Transform(VInt3 point, ref VInt3 axis_x, ref VInt3 axis_y, ref VInt3 axis_z, ref VInt3 trans)
	{
		return new VInt3(IntMath.Divide(axis_x.x * point.x + axis_y.x * point.y + axis_z.x * point.z, 1000) + trans.x, IntMath.Divide(axis_x.y * point.x + axis_y.y * point.y + axis_z.y * point.z, 1000) + trans.y, IntMath.Divide(axis_x.z * point.x + axis_y.z * point.y + axis_z.z * point.z, 1000) + trans.z);
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x0003AC90 File Offset: 0x00039090
	public static VInt3 Transform(ref VInt3 point, ref VInt3 axis_x, ref VInt3 axis_y, ref VInt3 axis_z, ref VInt3 trans, ref VInt3 scale)
	{
		long num = (long)(point.x * scale.x);
		long num2 = (long)(point.y * scale.x);
		long num3 = (long)(point.z * scale.x);
		return new VInt3((int)IntMath.Divide((long)axis_x.x * num + (long)axis_y.x * num2 + (long)axis_z.x * num3, 1000000L) + trans.x, (int)IntMath.Divide((long)axis_x.y * num + (long)axis_y.y * num2 + (long)axis_z.y * num3, 1000000L) + trans.y, (int)IntMath.Divide((long)axis_x.z * num + (long)axis_y.z * num2 + (long)axis_z.z * num3, 1000000L) + trans.z);
	}

	// Token: 0x04000850 RID: 2128
	public const long kFactorDen = 10000L;

	// Token: 0x04000851 RID: 2129
	public const long kIntDen = 10000L;

	// Token: 0x04000852 RID: 2130
	public const float fIntDen = 10000f;

	// Token: 0x04000853 RID: 2131
	public const float fInvIntDen = 0.0001f;

	// Token: 0x04000854 RID: 2132
	private const long kFloatBit = 100L;
}

using System;
using UnityEngine;

// Token: 0x02000190 RID: 400
[Serializable]
public struct VInt2
{
	// Token: 0x06000BA5 RID: 2981 RVA: 0x0003B96C File Offset: 0x00039D6C
	public VInt2(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0003B97C File Offset: 0x00039D7C
	public VInt2(float x, float y)
	{
		this.x = IntMath.Float2IntWithFixed(x, 10000L, 100L, MidpointRounding.ToEven);
		this.y = IntMath.Float2IntWithFixed(y, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0003B9AA File Offset: 0x00039DAA
	public VInt2(Vector2 position)
	{
		this.x = IntMath.Float2IntWithFixed(position.x, 10000L, 100L, MidpointRounding.ToEven);
		this.y = IntMath.Float2IntWithFixed(position.y, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x0003BA16 File Offset: 0x00039E16
	public float fx
	{
		get
		{
			return (float)this.x * 0.0001f;
		}
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x06000BAA RID: 2986 RVA: 0x0003BA25 File Offset: 0x00039E25
	public float fy
	{
		get
		{
			return (float)this.y * 0.0001f;
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06000BAB RID: 2987 RVA: 0x0003BA34 File Offset: 0x00039E34
	public int sqrMagnitude
	{
		get
		{
			return this.x * this.x + this.y * this.y;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x06000BAC RID: 2988 RVA: 0x0003BA54 File Offset: 0x00039E54
	public long sqrMagnitudeLong
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.y;
			return num * num + num2 * num2;
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0003BA78 File Offset: 0x00039E78
	public int magnitude
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.y;
			return IntMath.Sqrt(num * num + num2 * num2);
		}
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0003BAA1 File Offset: 0x00039EA1
	public static int Dot(ref VInt2 a, ref VInt2 b)
	{
		return a.x * b.x + a.y * b.y;
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0003BAC0 File Offset: 0x00039EC0
	public static VFactor AngleInt(VInt2 lhs, VInt2 rhs)
	{
		long den = (long)(lhs.magnitude * rhs.magnitude);
		return IntMath.acos(VInt2.DotLong(ref lhs, ref rhs), den);
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0003BAED File Offset: 0x00039EED
	public static long DotLong(ref VInt2 a, ref VInt2 b)
	{
		return (long)(a.x * b.x + a.y * b.y);
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0003BB0B File Offset: 0x00039F0B
	public static long DotLong(VInt2 a, VInt2 b)
	{
		return (long)(a.x * b.x + a.y * b.y);
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0003BB2D File Offset: 0x00039F2D
	public static long DetLong(ref VInt2 a, ref VInt2 b)
	{
		return (long)(a.x * b.y - a.y * b.x);
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0003BB4B File Offset: 0x00039F4B
	public static long DetLong(VInt2 a, VInt2 b)
	{
		return (long)(a.x * b.y - a.y * b.x);
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0003BB70 File Offset: 0x00039F70
	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		VInt2 vint = (VInt2)o;
		return this.x == vint.x && this.y == vint.y;
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0003BBB0 File Offset: 0x00039FB0
	public override int GetHashCode()
	{
		return this.x * 49157 + this.y * 98317;
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0003BBCC File Offset: 0x00039FCC
	public static VInt2 Rotate(VInt2 v, int r)
	{
		r %= 4;
		return new VInt2(v.x * VInt2.Rotations[r * 4] + v.y * VInt2.Rotations[r * 4 + 1], v.x * VInt2.Rotations[r * 4 + 2] + v.y * VInt2.Rotations[r * 4 + 3]);
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0003BC2F File Offset: 0x0003A02F
	public static VInt2 Min(VInt2 a, VInt2 b)
	{
		return new VInt2(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0003BC5C File Offset: 0x0003A05C
	public static VInt2 Max(VInt2 a, VInt2 b)
	{
		return new VInt2(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0003BC89 File Offset: 0x0003A089
	public static VInt2 FromInt3XZ(VInt3 o)
	{
		return new VInt2(o.x, o.z);
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0003BC9E File Offset: 0x0003A09E
	public static VInt3 ToInt3XZ(VInt2 o)
	{
		return new VInt3(o.x, 0, o.y);
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0003BCB4 File Offset: 0x0003A0B4
	public override string ToString()
	{
		object[] args = new object[]
		{
			"(",
			this.x,
			", ",
			this.y,
			")"
		};
		return string.Concat(args);
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0003BD02 File Offset: 0x0003A102
	public void Min(ref VInt2 r)
	{
		this.x = Mathf.Min(this.x, r.x);
		this.y = Mathf.Min(this.y, r.y);
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0003BD32 File Offset: 0x0003A132
	public void Max(ref VInt2 r)
	{
		this.x = Mathf.Max(this.x, r.x);
		this.y = Mathf.Max(this.y, r.y);
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0003BD64 File Offset: 0x0003A164
	public void Normalize()
	{
		long num = (long)(this.x * 100);
		long num2 = (long)(this.y * 100);
		long num3 = num * num + num2 * num2;
		if (num3 != 0L)
		{
			long b = (long)IntMath.Sqrt(num3);
			this.x = (int)IntMath.Divide(num * 1000L, b);
			this.y = (int)IntMath.Divide(num2 * 1000L, b);
		}
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0003BDCC File Offset: 0x0003A1CC
	public VInt2 NormalizeTo(int newMagn)
	{
		long num = (long)(this.x * 100);
		long num2 = (long)(this.y * 100);
		long num3 = num * num + num2 * num2;
		if (num3 != 0L)
		{
			long b = (long)IntMath.Sqrt(num3);
			long num4 = (long)newMagn;
			this.x = (int)IntMath.Divide(num * num4, b);
			this.y = (int)IntMath.Divide(num2 * num4, b);
		}
		return this;
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0003BE34 File Offset: 0x0003A234
	public VInt2 normalized
	{
		get
		{
			VInt2 result = new VInt2(this.x, this.y);
			result.Normalize();
			return result;
		}
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0003BE5C File Offset: 0x0003A25C
	public static VInt2 ClampMagnitude(VInt2 v, int maxLength)
	{
		long sqrMagnitudeLong = v.sqrMagnitudeLong;
		long num = (long)maxLength;
		if (sqrMagnitudeLong > num * num)
		{
			long b = (long)IntMath.Sqrt(sqrMagnitudeLong);
			int num2 = (int)IntMath.Divide((long)(v.x * maxLength), b);
			return new VInt2(num2, (int)IntMath.Divide((long)(v.x * maxLength), b));
		}
		return v;
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0003BEB0 File Offset: 0x0003A2B0
	public static explicit operator Vector2(VInt2 ob)
	{
		return new Vector2((float)ob.x * 0.0001f, (float)ob.y * 0.0001f);
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x0003BED3 File Offset: 0x0003A2D3
	public static explicit operator VInt2(Vector2 ob)
	{
		return new VInt2(IntMath.Float2IntWithFixed(ob.x, 10000L, 100L, MidpointRounding.ToEven), IntMath.Float2IntWithFixed(ob.y, 10000L, 100L, MidpointRounding.ToEven));
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0003BF06 File Offset: 0x0003A306
	public static VInt2 operator +(VInt2 a, VInt2 b)
	{
		return new VInt2(a.x + b.x, a.y + b.y);
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0003BF2B File Offset: 0x0003A32B
	public static VInt2 operator -(VInt2 a, VInt2 b)
	{
		return new VInt2(a.x - b.x, a.y - b.y);
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0003BF50 File Offset: 0x0003A350
	public static bool operator ==(VInt2 a, VInt2 b)
	{
		return a.x == b.x && a.y == b.y;
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0003BF78 File Offset: 0x0003A378
	public static bool operator !=(VInt2 a, VInt2 b)
	{
		return a.x != b.x || a.y != b.y;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0003BFA3 File Offset: 0x0003A3A3
	public static VInt2 operator -(VInt2 lhs)
	{
		lhs.x = -lhs.x;
		lhs.y = -lhs.y;
		return lhs;
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0003BFC4 File Offset: 0x0003A3C4
	public static VInt2 operator *(VInt2 lhs, int rhs)
	{
		lhs.x *= rhs;
		lhs.y *= rhs;
		return lhs;
	}

	// Token: 0x04000874 RID: 2164
	public int x;

	// Token: 0x04000875 RID: 2165
	public int y;

	// Token: 0x04000876 RID: 2166
	public static VInt2 zero = default(VInt2);

	// Token: 0x04000877 RID: 2167
	private static readonly int[] Rotations = new int[]
	{
		1,
		0,
		0,
		1,
		0,
		1,
		-1,
		0,
		-1,
		0,
		0,
		-1,
		0,
		-1,
		1,
		0
	};
}

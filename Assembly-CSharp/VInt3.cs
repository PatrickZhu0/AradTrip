using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[Serializable]
public struct VInt3
{
	// Token: 0x06000BCA RID: 3018 RVA: 0x0003BFE8 File Offset: 0x0003A3E8
	public VInt3(Vector3 position)
	{
		this.x = IntMath.Float2IntWithFixed(position.x, 10000L, 100L, MidpointRounding.ToEven);
		this.y = IntMath.Float2IntWithFixed(position.z, 10000L, 100L, MidpointRounding.ToEven);
		this.z = IntMath.Float2IntWithFixed(position.y, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x0003C04C File Offset: 0x0003A44C
	public VInt3(Vec3 position)
	{
		this.x = IntMath.Float2IntWithFixed(position.x, 10000L, 100L, MidpointRounding.ToEven);
		this.y = IntMath.Float2IntWithFixed(position.y, 10000L, 100L, MidpointRounding.ToEven);
		this.z = IntMath.Float2IntWithFixed(position.z, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x0003C0B0 File Offset: 0x0003A4B0
	public VInt3(float x, float y, float z)
	{
		this.x = IntMath.Float2IntWithFixed(x, 10000L, 100L, MidpointRounding.ToEven);
		this.y = IntMath.Float2IntWithFixed(y, 10000L, 100L, MidpointRounding.ToEven);
		this.z = IntMath.Float2IntWithFixed(z, 10000L, 100L, MidpointRounding.ToEven);
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0003C0FF File Offset: 0x0003A4FF
	public VInt3(int _x, int _y, int _z)
	{
		this.x = _x;
		this.y = _y;
		this.z = _z;
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0003C1AF File Offset: 0x0003A5AF
	public float fx
	{
		get
		{
			return (float)this.x * 0.0001f;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0003C1BE File Offset: 0x0003A5BE
	public float fy
	{
		get
		{
			return (float)this.y * 0.0001f;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0003C1CD File Offset: 0x0003A5CD
	public float fz
	{
		get
		{
			return (float)this.z * 0.0001f;
		}
	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x0003C1DC File Offset: 0x0003A5DC
	public VInt3 DivBy2()
	{
		this.x >>= 1;
		this.y >>= 1;
		this.z >>= 1;
		return this;
	}

	// Token: 0x170001B7 RID: 439
	public int this[int i]
	{
		get
		{
			return (i == 0) ? this.x : ((i == 1) ? this.y : this.z);
		}
		set
		{
			if (i == 0)
			{
				this.x = value;
			}
			else if (i == 1)
			{
				this.y = value;
			}
			else
			{
				this.z = value;
			}
		}
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x0003C268 File Offset: 0x0003A668
	public static float Angle(VInt3 lhs, VInt3 rhs)
	{
		double num = (double)VInt3.Dot(lhs, rhs) / (double)(lhs.magnitude * rhs.magnitude);
		num = ((num < -1.0) ? -1.0 : ((num > 1.0) ? 1.0 : num));
		return (float)Math.Acos(num);
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x0003C2D4 File Offset: 0x0003A6D4
	public static VFactor AngleInt(VInt3 lhs, VInt3 rhs)
	{
		long den = (long)(lhs.magnitude * rhs.magnitude);
		return IntMath.acos((long)VInt3.Dot(ref lhs, ref rhs), den);
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x0003C302 File Offset: 0x0003A702
	public static int Dot(ref VInt3 lhs, ref VInt3 rhs)
	{
		return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x0003C32D File Offset: 0x0003A72D
	public static int Dot(VInt3 lhs, VInt3 rhs)
	{
		return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0003C35E File Offset: 0x0003A75E
	public static long DotLong(VInt3 lhs, VInt3 rhs)
	{
		return (long)(lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z);
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x0003C390 File Offset: 0x0003A790
	public static long DotLong(ref VInt3 lhs, ref VInt3 rhs)
	{
		return (long)(lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z);
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0003C3BC File Offset: 0x0003A7BC
	public static long DotXZLong(ref VInt3 lhs, ref VInt3 rhs)
	{
		return (long)(lhs.x * rhs.x + lhs.z * rhs.z);
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0003C3DA File Offset: 0x0003A7DA
	public static long DotXZLong(VInt3 lhs, VInt3 rhs)
	{
		return (long)(lhs.x * rhs.x + lhs.z * rhs.z);
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0003C3FC File Offset: 0x0003A7FC
	public static VInt3 Cross(ref VInt3 lhs, ref VInt3 rhs)
	{
		return new VInt3((float)IntMath.Divide((long)(lhs.y * rhs.z - lhs.z * rhs.y), 10000L), (float)IntMath.Divide((long)(lhs.z * rhs.x - lhs.x * rhs.z), 10000L), (float)IntMath.Divide((long)(lhs.x * rhs.y - lhs.y * rhs.x), 10000L));
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0003C488 File Offset: 0x0003A888
	public static VInt3 Cross(VInt3 lhs, VInt3 rhs)
	{
		return new VInt3((float)IntMath.Divide((long)(lhs.y * rhs.z - lhs.z * rhs.y), 10000L), (float)IntMath.Divide((long)(lhs.z * rhs.x - lhs.x * rhs.z), 10000L), (float)IntMath.Divide((long)(lhs.x * rhs.y - lhs.y * rhs.x), 10000L));
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x0003C520 File Offset: 0x0003A920
	public static VInt3 MoveTowards(VInt3 from, VInt3 to, int dt)
	{
		if ((to - from).sqrMagnitudeLong <= (long)(dt * dt))
		{
			return to;
		}
		return from + (to - from).NormalizeTo(dt);
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0003C55D File Offset: 0x0003A95D
	public VInt3 Normal2D()
	{
		return new VInt3(this.z, this.y, -this.x);
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x0003C578 File Offset: 0x0003A978
	public VInt3 NormalizeTo(int newMagn)
	{
		long num = (long)(this.x * 100);
		long num2 = (long)(this.y * 100);
		long num3 = (long)(this.z * 100);
		long num4 = num * num + num2 * num2 + num3 * num3;
		if (num4 != 0L)
		{
			long b = (long)IntMath.Sqrt(num4);
			long num5 = (long)newMagn;
			this.x = (int)IntMath.Divide(num * num5, b);
			this.y = (int)IntMath.Divide(num2 * num5, b);
			this.z = (int)IntMath.Divide(num3 * num5, b);
		}
		return this;
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x0003C603 File Offset: 0x0003AA03
	public Vec3 vec3
	{
		get
		{
			return new Vec3((float)this.x * 0.0001f, (float)this.y * 0.0001f, (float)this.z * 0.0001f);
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x0003C631 File Offset: 0x0003AA31
	public Vector3 vector3
	{
		get
		{
			return new Vector3((float)this.x * 0.0001f, (float)this.z * 0.0001f, (float)this.y * 0.0001f);
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0003C65F File Offset: 0x0003AA5F
	public VInt2 xz
	{
		get
		{
			return new VInt2(this.x, this.z);
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x0003C674 File Offset: 0x0003AA74
	public int magnitude
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.y;
			long num3 = (long)this.z;
			return IntMath.Sqrt(num * num + num2 * num2 + num3 * num3);
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0003C6AC File Offset: 0x0003AAAC
	public int magnitude2D
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.z;
			return IntMath.Sqrt(num * num + num2 * num2);
		}
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0003C6D8 File Offset: 0x0003AAD8
	public VInt3 RotateY(ref VFactor radians)
	{
		VFactor vfactor;
		VFactor vfactor2;
		IntMath.sincos(out vfactor, out vfactor2, radians.nom, radians.den);
		long num = vfactor2.nom * vfactor.den;
		long num2 = vfactor2.den * vfactor.nom;
		long b = vfactor2.den * vfactor.den;
		VInt3 vint;
		vint.x = (int)IntMath.Divide((long)this.x * num + (long)this.z * num2, b);
		vint.z = (int)IntMath.Divide((long)(-(long)this.x) * num2 + (long)this.z * num, b);
		vint.y = 0;
		return vint.NormalizeTo(10000);
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0003C788 File Offset: 0x0003AB88
	public VInt3 RotateZ(ref VFactor radians)
	{
		VFactor vfactor;
		VFactor vfactor2;
		IntMath.sincos(out vfactor, out vfactor2, radians.nom, radians.den);
		long num = vfactor2.nom * vfactor.den;
		long num2 = vfactor2.den * vfactor.nom;
		long b = vfactor2.den * vfactor.den;
		VInt3 vint;
		vint.x = (int)IntMath.Divide((long)this.x * num - (long)this.y * num2, b);
		vint.y = (int)IntMath.Divide((long)this.x * num2 + (long)this.y * num, b);
		vint.z = 0;
		return vint.NormalizeTo(10000);
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0003C838 File Offset: 0x0003AC38
	public VInt3 RotateY(int degree)
	{
		VFactor vfactor;
		VFactor vfactor2;
		IntMath.sincos(out vfactor, out vfactor2, VFactor.pi.nom * (long)degree, 1800000L);
		long num = vfactor2.nom * vfactor.den;
		long num2 = vfactor2.den * vfactor.nom;
		long b = vfactor2.den * vfactor.den;
		VInt3 vint;
		vint.x = (int)IntMath.Divide((long)this.x * num + (long)this.z * num2, b);
		vint.z = (int)IntMath.Divide((long)(-(long)this.x) * num2 + (long)this.z * num, b);
		vint.y = 0;
		return vint.NormalizeTo(10000);
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000BEA RID: 3050 RVA: 0x0003C8EE File Offset: 0x0003ACEE
	public int costMagnitude
	{
		get
		{
			return this.magnitude;
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0003C8F8 File Offset: 0x0003ACF8
	public float worldMagnitude
	{
		get
		{
			double num = (double)this.x;
			double num2 = (double)this.y;
			double num3 = (double)this.z;
			return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3) * 0.0001f;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06000BEC RID: 3052 RVA: 0x0003C934 File Offset: 0x0003AD34
	public double sqrMagnitude
	{
		get
		{
			double num = (double)this.x;
			double num2 = (double)this.y;
			double num3 = (double)this.z;
			return num * num + num2 * num2 + num3 * num3;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06000BED RID: 3053 RVA: 0x0003C964 File Offset: 0x0003AD64
	public long sqrMagnitudeLong
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.y;
			long num3 = (long)this.z;
			return num * num + num2 * num2 + num3 * num3;
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06000BEE RID: 3054 RVA: 0x0003C994 File Offset: 0x0003AD94
	public long sqrMagnitudeLong2D
	{
		get
		{
			long num = (long)this.x;
			long num2 = (long)this.z;
			return num * num + num2 * num2;
		}
	}

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0003C9B8 File Offset: 0x0003ADB8
	public int unsafeSqrMagnitude
	{
		get
		{
			return this.x * this.x + this.y * this.y + this.z * this.z;
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0003C9E3 File Offset: 0x0003ADE3
	public VInt3 abs
	{
		get
		{
			return new VInt3(Math.Abs(this.x), Math.Abs(this.y), Math.Abs(this.z));
		}
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x0003CA0C File Offset: 0x0003AE0C
	[Obsolete("Same implementation as .magnitude")]
	public float safeMagnitude
	{
		get
		{
			double num = (double)this.x;
			double num2 = (double)this.y;
			double num3 = (double)this.z;
			return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0003CA44 File Offset: 0x0003AE44
	[Obsolete(".sqrMagnitude is now per default safe (.unsafeSqrMagnitude can be used for unsafe operations)")]
	public float safeSqrMagnitude
	{
		get
		{
			float num = (float)this.x * 0.0001f;
			float num2 = (float)this.y * 0.0001f;
			float num3 = (float)this.z * 0.0001f;
			return num * num + num2 * num2 + num3 * num3;
		}
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0003CA88 File Offset: 0x0003AE88
	public override string ToString()
	{
		object[] args = new object[]
		{
			"( ",
			this.x,
			", ",
			this.y,
			", ",
			this.z,
			")"
		};
		return string.Concat(args);
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0003CAEC File Offset: 0x0003AEEC
	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		VInt3 vint = (VInt3)o;
		return this.x == vint.x && this.y == vint.y && this.z == vint.z;
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0003CB3E File Offset: 0x0003AF3E
	public override int GetHashCode()
	{
		return this.x * 73856093 ^ this.y * 19349663 ^ this.z * 83492791;
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0003CB68 File Offset: 0x0003AF68
	public static VInt3 Lerp(VInt3 a, VInt3 b, float f)
	{
		return new VInt3(Mathf.RoundToInt((float)a.x * (1f - f)) + Mathf.RoundToInt((float)b.x * f), Mathf.RoundToInt((float)a.y * (1f - f)) + Mathf.RoundToInt((float)b.y * f), Mathf.RoundToInt((float)a.z * (1f - f)) + Mathf.RoundToInt((float)b.z * f));
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x0003CBEC File Offset: 0x0003AFEC
	public static VInt3 Lerp(VInt3 a, VInt3 b, VFactor f)
	{
		return new VInt3((int)IntMath.Divide((long)(b.x - a.x) * f.nom, f.den) + a.x, (int)IntMath.Divide((long)(b.y - a.y) * f.nom, f.den) + a.y, (int)IntMath.Divide((long)(b.z - a.z) * f.nom, f.den) + a.z);
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x0003CC88 File Offset: 0x0003B088
	public long XZSqrMagnitude(VInt3 rhs)
	{
		long num = (long)(this.x - rhs.x);
		long num2 = (long)(this.z - rhs.z);
		return num * num + num2 * num2;
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x0003CCBC File Offset: 0x0003B0BC
	public long XZSqrMagnitude(ref VInt3 rhs)
	{
		long num = (long)(this.x - rhs.x);
		long num2 = (long)(this.z - rhs.z);
		return num * num + num2 * num2;
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x0003CCEE File Offset: 0x0003B0EE
	public bool IsEqualXZ(VInt3 rhs)
	{
		return this.x == rhs.x && this.z == rhs.z;
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x0003CD14 File Offset: 0x0003B114
	public bool IsEqualXZ(ref VInt3 rhs)
	{
		return this.x == rhs.x && this.z == rhs.z;
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x0003CD38 File Offset: 0x0003B138
	public static bool operator ==(VInt3 lhs, VInt3 rhs)
	{
		return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x0003CD73 File Offset: 0x0003B173
	public static bool operator !=(VInt3 lhs, VInt3 rhs)
	{
		return lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z;
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x0003CDB4 File Offset: 0x0003B1B4
	public static explicit operator VInt3(Vector3 ob)
	{
		return new VInt3(IntMath.Float2IntWithFixed(ob.x, 10000L, 100L, MidpointRounding.ToEven), IntMath.Float2IntWithFixed(ob.y, 10000L, 100L, MidpointRounding.ToEven), IntMath.Float2IntWithFixed(ob.z, 10000L, 100L, MidpointRounding.ToEven));
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x0003CE08 File Offset: 0x0003B208
	public static explicit operator Vector3(VInt3 ob)
	{
		return new Vector3((float)ob.x * 0.0001f, (float)ob.y * 0.0001f, (float)ob.z * 0.0001f);
	}

	// Token: 0x06000C00 RID: 3072 RVA: 0x0003CE3C File Offset: 0x0003B23C
	public static VInt3 operator -(VInt3 lhs, VInt3 rhs)
	{
		lhs.x -= rhs.x;
		lhs.y -= rhs.y;
		lhs.z -= rhs.z;
		return lhs;
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x0003CE89 File Offset: 0x0003B289
	public static VInt3 operator -(VInt3 lhs)
	{
		lhs.x = -lhs.x;
		lhs.y = -lhs.y;
		lhs.z = -lhs.z;
		return lhs;
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x0003CEBC File Offset: 0x0003B2BC
	public static VInt3 operator +(VInt3 lhs, VInt3 rhs)
	{
		lhs.x += rhs.x;
		lhs.y += rhs.y;
		lhs.z += rhs.z;
		return lhs;
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x0003CF09 File Offset: 0x0003B309
	public static VInt3 operator *(VInt3 lhs, int rhs)
	{
		lhs.x *= rhs;
		lhs.y *= rhs;
		lhs.z *= rhs;
		return lhs;
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0003CF3C File Offset: 0x0003B33C
	public static VInt3 operator *(VInt3 lhs, float rhs)
	{
		lhs.x = IntMath.Float2IntWithFixed((float)lhs.x * rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.y = IntMath.Float2IntWithFixed((float)lhs.y * rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.z = IntMath.Float2IntWithFixed((float)lhs.z * rhs, 1L, 1000L, MidpointRounding.ToEven);
		return lhs;
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x0003CFA8 File Offset: 0x0003B3A8
	public static VInt3 operator *(VInt3 lhs, double rhs)
	{
		lhs.x = IntMath.Float2IntWithFixed((double)lhs.x * rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.y = IntMath.Float2IntWithFixed((double)lhs.y * rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.z = IntMath.Float2IntWithFixed((double)lhs.z * rhs, 1L, 1000L, MidpointRounding.ToEven);
		return lhs;
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x0003D014 File Offset: 0x0003B414
	public static VInt3 operator *(VInt3 lhs, Vector3 rhs)
	{
		lhs.x = IntMath.Float2IntWithFixed((float)lhs.x * rhs.x, 1L, 1000L, MidpointRounding.ToEven);
		lhs.y = IntMath.Float2IntWithFixed((float)lhs.y * rhs.y, 1L, 1000L, MidpointRounding.ToEven);
		lhs.z = IntMath.Float2IntWithFixed((float)lhs.z * rhs.z, 1L, 1000L, MidpointRounding.ToEven);
		return lhs;
	}

	// Token: 0x06000C07 RID: 3079 RVA: 0x0003D094 File Offset: 0x0003B494
	public static VInt3 operator *(VInt3 lhs, VInt3 rhs)
	{
		lhs.x *= rhs.x;
		lhs.y *= rhs.y;
		lhs.z *= rhs.z;
		return lhs;
	}

	// Token: 0x06000C08 RID: 3080 RVA: 0x0003D0E4 File Offset: 0x0003B4E4
	public static VInt3 operator /(VInt3 lhs, float rhs)
	{
		lhs.x = IntMath.Float2IntWithFixed((float)lhs.x / rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.y = IntMath.Float2IntWithFixed((float)lhs.y / rhs, 1L, 1000L, MidpointRounding.ToEven);
		lhs.z = IntMath.Float2IntWithFixed((float)lhs.z / rhs, 1L, 1000L, MidpointRounding.ToEven);
		return lhs;
	}

	// Token: 0x06000C09 RID: 3081 RVA: 0x0003D14F File Offset: 0x0003B54F
	public static implicit operator string(VInt3 ob)
	{
		return ob.ToString();
	}

	// Token: 0x04000878 RID: 2168
	public const int Precision = 1000;

	// Token: 0x04000879 RID: 2169
	public const float FloatPrecision = 10000f;

	// Token: 0x0400087A RID: 2170
	public const float PrecisionFactor = 0.0001f;

	// Token: 0x0400087B RID: 2171
	public int x;

	// Token: 0x0400087C RID: 2172
	public int y;

	// Token: 0x0400087D RID: 2173
	public int z;

	// Token: 0x0400087E RID: 2174
	public static readonly VInt3 zero = new VInt3(0, 0, 0);

	// Token: 0x0400087F RID: 2175
	public static readonly VInt3 one = new VInt3(1f, 1f, 1f);

	// Token: 0x04000880 RID: 2176
	public static readonly VInt3 half = new VInt3(0.5f, 0.5f, 0.5f);

	// Token: 0x04000881 RID: 2177
	public static readonly VInt3 forward = new VInt3(0f, 0f, 1f);

	// Token: 0x04000882 RID: 2178
	public static readonly VInt3 up = new VInt3(0f, 1f, 0f);

	// Token: 0x04000883 RID: 2179
	public static readonly VInt3 right = new VInt3(1f, 0f, 0f);

	// Token: 0x04000884 RID: 2180
	private const int kValidBit = 1;

	// Token: 0x04000885 RID: 2181
	private const int kFloatBit = 1000;
}

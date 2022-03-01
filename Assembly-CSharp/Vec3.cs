using System;
using UnityEngine;

// Token: 0x020041D3 RID: 16851
[Serializable]
public struct Vec3
{
	// Token: 0x060173F8 RID: 95224 RVA: 0x007262B8 File Offset: 0x007246B8
	public Vec3(float x, float y, float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	// Token: 0x060173F9 RID: 95225 RVA: 0x007262CF File Offset: 0x007246CF
	public Vec3(Vector3 v)
	{
		this.x = v.x;
		this.y = v.z;
		this.z = v.y;
	}

	// Token: 0x17001FAB RID: 8107
	// (get) Token: 0x060173FA RID: 95226 RVA: 0x007262F8 File Offset: 0x007246F8
	public static Vec3 zero
	{
		get
		{
			return new Vec3(0f, 0f, 0f);
		}
	}

	// Token: 0x060173FB RID: 95227 RVA: 0x0072630E File Offset: 0x0072470E
	public Vector3 vector3()
	{
		return new Vector3(this.x, this.z, this.y);
	}

	// Token: 0x060173FC RID: 95228 RVA: 0x00726327 File Offset: 0x00724727
	public static bool operator ==(Vec3 v1, Vec3 v2)
	{
		return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
	}

	// Token: 0x060173FD RID: 95229 RVA: 0x00726362 File Offset: 0x00724762
	public static bool operator !=(Vec3 v1, Vec3 v2)
	{
		return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
	}

	// Token: 0x060173FE RID: 95230 RVA: 0x007263A0 File Offset: 0x007247A0
	public static Vec3 operator +(Vec3 v1, Vec3 v2)
	{
		return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
	}

	// Token: 0x060173FF RID: 95231 RVA: 0x007263D4 File Offset: 0x007247D4
	public static Vec3 operator -(Vec3 v1, Vec3 v2)
	{
		return new Vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
	}

	// Token: 0x06017400 RID: 95232 RVA: 0x00726408 File Offset: 0x00724808
	public static Vec3 operator *(Vec3 v1, int v)
	{
		return new Vec3(v1.x * (float)v, v1.y * (float)v, v1.z * (float)v);
	}

	// Token: 0x06017401 RID: 95233 RVA: 0x0072642D File Offset: 0x0072482D
	public static Vec3 operator *(Vec3 v1, float v)
	{
		return new Vec3(v1.x * v, v1.y * v, v1.z * v);
	}

	// Token: 0x06017402 RID: 95234 RVA: 0x00726450 File Offset: 0x00724850
	public static float Distance(Vec3 v1, Vec3 v2)
	{
		Vec3 vec = v1 - v2;
		return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
	}

	// Token: 0x04010BBA RID: 68538
	public float x;

	// Token: 0x04010BBB RID: 68539
	public float y;

	// Token: 0x04010BBC RID: 68540
	public float z;
}

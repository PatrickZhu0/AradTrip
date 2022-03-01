using System;

// Token: 0x020041D5 RID: 16853
public struct DBox3
{
	// Token: 0x06017412 RID: 95250 RVA: 0x007269D0 File Offset: 0x00724DD0
	public DBox3(DBox box, float zDim)
	{
		this._min = new VInt3((float)box._min.x, (float)box._min.y, -zDim);
		this._max = new VInt3((float)box._max.x, (float)box._max.y, zDim);
	}

	// Token: 0x06017413 RID: 95251 RVA: 0x00726A2A File Offset: 0x00724E2A
	public void Print()
	{
	}

	// Token: 0x06017414 RID: 95252 RVA: 0x00726A2C File Offset: 0x00724E2C
	public static int MAX(int f1, int f2)
	{
		return (f1 <= f2) ? f2 : f1;
	}

	// Token: 0x06017415 RID: 95253 RVA: 0x00726A3C File Offset: 0x00724E3C
	public static int MIN(int f1, int f2)
	{
		return (f1 >= f2) ? f2 : f1;
	}

	// Token: 0x06017416 RID: 95254 RVA: 0x00726A4C File Offset: 0x00724E4C
	public bool IsValide()
	{
		return this._min.x != 0 || this._min.y != 0 || this._max.x != 0 || this._max.y != 0 || this._min.z != 0 || this._max.z != 0;
	}

	// Token: 0x06017417 RID: 95255 RVA: 0x00726AC0 File Offset: 0x00724EC0
	public VInt3 getCenter()
	{
		return new VInt3
		{
			x = (this._min.x + this._max.x) / 2,
			y = (this._min.y + this._max.y) / 2,
			z = (this._min.z + this._max.z) / 2
		};
	}

	// Token: 0x06017418 RID: 95256 RVA: 0x00726B38 File Offset: 0x00724F38
	public bool intersects(DBox3 aabb)
	{
		return this._min.x <= aabb._max.x && this._max.x >= aabb._min.x && this._min.y <= aabb._max.y && this._max.y >= aabb._min.y && this._min.z <= aabb._max.z && this._max.z >= aabb._min.z;
	}

	// Token: 0x06017419 RID: 95257 RVA: 0x00726BF0 File Offset: 0x00724FF0
	public void getIntersects(DBox3 aabb, ref DBox3 rkOut)
	{
		rkOut._min.x = DBox3.MAX(this._min.x, aabb._min.x);
		rkOut._min.y = DBox3.MAX(this._min.y, aabb._min.y);
		rkOut._min.z = DBox3.MAX(this._min.z, aabb._min.z);
		rkOut._max.x = DBox3.MIN(this._max.x, aabb._max.x);
		rkOut._max.y = DBox3.MIN(this._max.y, aabb._max.y);
		rkOut._max.z = DBox3.MIN(this._max.z, aabb._max.z);
	}

	// Token: 0x0601741A RID: 95258 RVA: 0x00726CE8 File Offset: 0x007250E8
	public bool containPoint(ref VInt3 point)
	{
		return point.x >= this._min.x && point.y >= this._min.y && point.z >= this._min.z && point.x <= this._max.x && point.y <= this._max.y && point.z <= this._max.z;
	}

	// Token: 0x0601741B RID: 95259 RVA: 0x00726D88 File Offset: 0x00725188
	public void merge(DBox3 box)
	{
		this._min.x = DBox3.MIN(this._min.x, box._min.x);
		this._min.y = DBox3.MIN(this._min.y, box._min.y);
		this._min.z = DBox3.MIN(this._min.z, box._min.z);
		this._max.x = DBox3.MAX(this._max.x, box._max.x);
		this._max.y = DBox3.MAX(this._max.y, box._max.y);
		this._max.z = DBox3.MAX(this._max.z, box._max.z);
	}

	// Token: 0x0601741C RID: 95260 RVA: 0x00726E7F File Offset: 0x0072527F
	public void set(VInt3 min, VInt3 max)
	{
		this._min = min;
		this._max = max;
	}

	// Token: 0x0601741D RID: 95261 RVA: 0x00726E90 File Offset: 0x00725290
	public void offset(DBox3 rkBox, VInt x, VInt y, VInt z, VFactor scale, bool bNegX)
	{
		if (bNegX)
		{
			this._min.x = -rkBox._max.x * scale + x.i;
			this._max.x = -rkBox._min.x * scale + x.i;
			this._min.y = rkBox._min.y * scale + y.i;
			this._max.y = rkBox._max.y * scale + y.i;
			this._min.z = rkBox._min.z * scale + z.i;
			this._max.z = rkBox._max.z * scale + z.i;
		}
		else
		{
			this._min.x = rkBox._min.x * scale + x.i;
			this._max.x = rkBox._max.x * scale + x.i;
			this._min.y = rkBox._min.y * scale + y.i;
			this._max.y = rkBox._max.y * scale + y.i;
			this._min.z = rkBox._min.z * scale + z.i;
			this._max.z = rkBox._max.z * scale + z.i;
		}
	}

	// Token: 0x0601741E RID: 95262 RVA: 0x00727073 File Offset: 0x00725473
	public void reset()
	{
		this._min = new VInt3(99999, 99999, 99999);
		this._max = new VInt3(-99999, -99999, -99999);
	}

	// Token: 0x0601741F RID: 95263 RVA: 0x007270AC File Offset: 0x007254AC
	public bool isEmpty()
	{
		return this._min.x > this._max.x || this._min.y > this._max.y || this._min.z > this._max.z;
	}

	// Token: 0x06017420 RID: 95264 RVA: 0x0072710A File Offset: 0x0072550A
	public void updateMinMax(VInt2 point, int num)
	{
	}

	// Token: 0x04010BBF RID: 68543
	public VInt3 _min;

	// Token: 0x04010BC0 RID: 68544
	public VInt3 _max;
}

using System;

// Token: 0x020041D4 RID: 16852
public struct DBox
{
	// Token: 0x06017403 RID: 95235 RVA: 0x00726489 File Offset: 0x00724889
	public void Print()
	{
	}

	// Token: 0x06017404 RID: 95236 RVA: 0x0072648B File Offset: 0x0072488B
	public static int MAX(int f1, int f2)
	{
		return (f1 <= f2) ? f2 : f1;
	}

	// Token: 0x06017405 RID: 95237 RVA: 0x0072649B File Offset: 0x0072489B
	public static int MIN(int f1, int f2)
	{
		return (f1 >= f2) ? f2 : f1;
	}

	// Token: 0x06017406 RID: 95238 RVA: 0x007264AC File Offset: 0x007248AC
	public bool IsValide()
	{
		return this._min.x != 0 || this._min.y != 0 || this._max.x != 0 || this._max.y != 0;
	}

	// Token: 0x06017407 RID: 95239 RVA: 0x00726500 File Offset: 0x00724900
	public VInt2 getCenter()
	{
		return new VInt2
		{
			x = (this._min.x + this._max.x) / 2,
			y = (this._min.y + this._max.y) / 2
		};
	}

	// Token: 0x06017408 RID: 95240 RVA: 0x00726558 File Offset: 0x00724958
	public bool intersects(DBox aabb)
	{
		return this._min.x <= aabb._max.x && this._max.x >= aabb._min.x && this._min.y <= aabb._max.y && this._max.y >= aabb._min.y;
	}

	// Token: 0x06017409 RID: 95241 RVA: 0x007265D8 File Offset: 0x007249D8
	public void getIntersects(DBox aabb, ref DBox rkOut)
	{
		rkOut._min.x = DBox.MAX(this._min.x, aabb._min.x);
		rkOut._min.y = DBox.MAX(this._min.y, aabb._min.y);
		rkOut._max.x = DBox.MIN(this._max.x, aabb._max.x);
		rkOut._max.y = DBox.MIN(this._max.y, aabb._max.y);
	}

	// Token: 0x0601740A RID: 95242 RVA: 0x00726684 File Offset: 0x00724A84
	public bool containPoint(ref VInt2 point)
	{
		return point.x >= this._min.x && point.y >= this._min.y && point.x <= this._max.x && point.y <= this._max.y;
	}

	// Token: 0x0601740B RID: 95243 RVA: 0x007266F4 File Offset: 0x00724AF4
	public void merge(DBox box)
	{
		this._min.x = DBox.MIN(this._min.x, box._min.x);
		this._min.y = DBox.MIN(this._min.y, box._min.y);
		this._max.x = DBox.MAX(this._max.x, box._max.x);
		this._max.y = DBox.MAX(this._max.y, box._max.y);
	}

	// Token: 0x0601740C RID: 95244 RVA: 0x0072679D File Offset: 0x00724B9D
	public void set(VInt2 min, VInt2 max)
	{
		this._min = min;
		this._max = max;
	}

	// Token: 0x0601740D RID: 95245 RVA: 0x007267B0 File Offset: 0x00724BB0
	public void offset(DBox rkBox, VInt x, VInt y, VFactor scale, bool bNegX)
	{
		if (bNegX)
		{
			this._min.x = -rkBox._max.x * scale + x.i;
			this._max.x = -rkBox._min.x * scale + x.i;
			this._min.y = rkBox._min.y * scale + y.i;
			this._max.y = rkBox._max.y * scale + y.i;
		}
		else
		{
			this._min.x = rkBox._min.x * scale + x.i;
			this._max.x = rkBox._max.x * scale + x.i;
			this._min.y = rkBox._min.y * scale + y.i;
			this._max.y = rkBox._max.y * scale + y.i;
		}
	}

	// Token: 0x0601740E RID: 95246 RVA: 0x007268FB File Offset: 0x00724CFB
	public void reset()
	{
		this._min = new VInt2(99999, 99999);
		this._max = new VInt2(-99999, -99999);
	}

	// Token: 0x0601740F RID: 95247 RVA: 0x00726927 File Offset: 0x00724D27
	public bool isEmpty()
	{
		return this._min.x > this._max.x || this._min.y > this._max.y;
	}

	// Token: 0x06017410 RID: 95248 RVA: 0x0072695F File Offset: 0x00724D5F
	public void updateMinMax(VInt2 point, int num)
	{
	}

	// Token: 0x06017411 RID: 95249 RVA: 0x00726964 File Offset: 0x00724D64
	public override string ToString()
	{
		return string.Format("({0},{1}) ({2},{3})", new object[]
		{
			this._min.x,
			this._min.y,
			this._max.x,
			this._max.y
		});
	}

	// Token: 0x04010BBD RID: 68541
	public VInt2 _min;

	// Token: 0x04010BBE RID: 68542
	public VInt2 _max;
}

using System;

// Token: 0x02004BD5 RID: 19413
[Serializable]
public struct TilePos : IEquatable<TilePos>
{
	// Token: 0x0601C77D RID: 116605 RVA: 0x0089F767 File Offset: 0x0089DB67
	public TilePos(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}

	// Token: 0x0601C77E RID: 116606 RVA: 0x0089F777 File Offset: 0x0089DB77
	public override bool Equals(object obj)
	{
		return obj is TilePos && this.Equals((TilePos)obj);
	}

	// Token: 0x0601C77F RID: 116607 RVA: 0x0089F792 File Offset: 0x0089DB92
	public bool Equals(TilePos other)
	{
		return this.X == other.X && this.Y == other.Y;
	}

	// Token: 0x0601C780 RID: 116608 RVA: 0x0089F7B8 File Offset: 0x0089DBB8
	public override int GetHashCode()
	{
		int num = 1861411795;
		num = num * -1521134295 + this.X.GetHashCode();
		return num * -1521134295 + this.Y.GetHashCode();
	}

	// Token: 0x0601C781 RID: 116609 RVA: 0x0089F800 File Offset: 0x0089DC00
	public static bool operator ==(TilePos left, TilePos right)
	{
		return left.Equals(right);
	}

	// Token: 0x0601C782 RID: 116610 RVA: 0x0089F80A File Offset: 0x0089DC0A
	public static bool operator !=(TilePos left, TilePos right)
	{
		return !(left == right);
	}

	// Token: 0x04013AD4 RID: 80596
	public int X;

	// Token: 0x04013AD5 RID: 80597
	public int Y;
}

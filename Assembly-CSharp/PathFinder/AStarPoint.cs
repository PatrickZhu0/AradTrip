using System;

namespace PathFinder
{
	// Token: 0x020001DC RID: 476
	public class AStarPoint : IComparable<AStarPoint>
	{
		// Token: 0x06000F1D RID: 3869 RVA: 0x0004D121 File Offset: 0x0004B521
		public AStarPoint(int x = 0, int y = 0)
		{
			this.ResetState(x, y);
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x0004D131 File Offset: 0x0004B531
		public void Set(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0004D141 File Offset: 0x0004B541
		public void ResetState(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.f = 0;
			this.g = 0;
			this.open = false;
			this.close = false;
			this.parent = null;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x0004D174 File Offset: 0x0004B574
		public void ResetState()
		{
			this.f = 0;
			this.g = 0;
			this.open = false;
			this.close = false;
			this.parent = null;
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x0004D199 File Offset: 0x0004B599
		public int CompareTo(AStarPoint other)
		{
			return other.f * 5 - other.g - (this.f * 5 - this.g);
		}

		// Token: 0x04000A6F RID: 2671
		public int x;

		// Token: 0x04000A70 RID: 2672
		public int y;

		// Token: 0x04000A71 RID: 2673
		public int f;

		// Token: 0x04000A72 RID: 2674
		public int g;

		// Token: 0x04000A73 RID: 2675
		public bool open;

		// Token: 0x04000A74 RID: 2676
		public bool close;

		// Token: 0x04000A75 RID: 2677
		public AStarPoint parent;
	}
}

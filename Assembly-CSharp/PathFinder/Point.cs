using System;

namespace PathFinder
{
	// Token: 0x020001E3 RID: 483
	public class Point
	{
		// Token: 0x06000F4B RID: 3915 RVA: 0x0004E29C File Offset: 0x0004C69C
		public Point(int px = 0, int py = 0)
		{
			this.x = px;
			this.y = py;
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x0004E2B2 File Offset: 0x0004C6B2
		public void Set(int px = 0, int py = 0)
		{
			this.x = px;
			this.y = py;
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0004E2C2 File Offset: 0x0004C6C2
		public bool IsIn(int w, int h)
		{
			return this.x >= 0 && this.x < w && this.y >= 0 && this.y < h;
		}

		// Token: 0x04000A92 RID: 2706
		public int x;

		// Token: 0x04000A93 RID: 2707
		public int y;
	}
}

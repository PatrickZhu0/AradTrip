using System;
using System.Collections.Generic;

namespace PathFinder
{
	// Token: 0x020001E0 RID: 480
	public interface IPathFinder
	{
		// Token: 0x06000F45 RID: 3909
		bool Do(int[] obstacle, int width, int height, Point pstart, Point pend, List<int> steps);

		// Token: 0x06000F46 RID: 3910
		bool Do(int[] obstacle, int width, int height, Point pstart, Point pend, List<Point> steps);

		// Token: 0x06000F47 RID: 3911
		bool Do(byte[] obstacle, int width, int height, Point pstart, Point pend, List<int> steps);

		// Token: 0x06000F48 RID: 3912
		bool Do(byte[] obstacle, int width, int height, Point pstart, Point pend, List<Point> steps);
	}
}

using System;
using System.Collections.Generic;

namespace PathFinder
{
	// Token: 0x020001E1 RID: 481
	public class PathHelper
	{
		// Token: 0x04000A83 RID: 2691
		public static int[,] DIR_VALUE2 = new int[,]
		{
			{
				1,
				0
			},
			{
				-1,
				0
			},
			{
				0,
				1
			},
			{
				0,
				-1
			},
			{
				1,
				1
			},
			{
				-1,
				1
			},
			{
				1,
				-1
			},
			{
				-1,
				-1
			}
		};

		// Token: 0x04000A84 RID: 2692
		public static List<int> _list = new List<int>();

		// Token: 0x04000A85 RID: 2693
		public static Point _start = new Point(0, 0);

		// Token: 0x04000A86 RID: 2694
		public static Point _end = new Point(0, 0);

		// Token: 0x04000A87 RID: 2695
		public static AStar _astar = new AStar();

		// Token: 0x020001E2 RID: 482
		public enum MoveDir
		{
			// Token: 0x04000A89 RID: 2697
			RIGHT,
			// Token: 0x04000A8A RID: 2698
			LEFT,
			// Token: 0x04000A8B RID: 2699
			TOP,
			// Token: 0x04000A8C RID: 2700
			DOWN,
			// Token: 0x04000A8D RID: 2701
			RIGHT_TOP,
			// Token: 0x04000A8E RID: 2702
			LEFT_TOP,
			// Token: 0x04000A8F RID: 2703
			RIGHT_DOWN,
			// Token: 0x04000A90 RID: 2704
			LEFT_DOWN,
			// Token: 0x04000A91 RID: 2705
			COUNT
		}
	}
}

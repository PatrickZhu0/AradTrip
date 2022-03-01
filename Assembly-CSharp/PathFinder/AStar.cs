using System;
using System.Collections.Generic;

namespace PathFinder
{
	// Token: 0x020001DD RID: 477
	public class AStar : IPathFinder
	{
		// Token: 0x06000F22 RID: 3874 RVA: 0x0004D1BC File Offset: 0x0004B5BC
		public AStar()
		{
			this._f = new Func<AStarPoint, AStarPoint, int>(this.DefaultF);
			this._g = new Func<AStarPoint, AStarPoint, int>(this.DefaultG);
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x0004D234 File Offset: 0x0004B634
		private int DefaultF(AStarPoint left, AStarPoint right)
		{
			int val = Math.Abs(left.x - right.x);
			int val2 = Math.Abs(left.y - right.y);
			int num = Math.Max(val, val2);
			int num2 = Math.Min(val, val2);
			return num * 10 + num2 * 4;
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x0004D27F File Offset: 0x0004B67F
		private int DefaultG(AStarPoint left, AStarPoint right)
		{
			if (left.x == right.x)
			{
				return 10;
			}
			if (left.y == right.y)
			{
				return 10;
			}
			return 14;
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x0004D2AB File Offset: 0x0004B6AB
		public void SetF(Func<AStarPoint, AStarPoint, int> f)
		{
			this._f = f;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x0004D2B4 File Offset: 0x0004B6B4
		public void SetG(Func<AStarPoint, AStarPoint, int> g)
		{
			this._g = g;
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x0004D2C0 File Offset: 0x0004B6C0
		private void Reset(int width, int height)
		{
			if (this._helper == null || height > this._helperHeight || width > this._helperwidth)
			{
				this._helperwidth = Math.Max(width, this._helperwidth);
				this._helperHeight = Math.Max(height, this._helperHeight);
				this._helper = new AStarPoint[this._helperHeight, this._helperwidth];
			}
			this._currentwidth = width;
			this._currentheight = height;
			for (int i = this._usedleft; i < this._usedright; i++)
			{
				AStarPoint astarPoint = this._used[i];
				this._helper[astarPoint.y, astarPoint.x] = null;
			}
			this._usedleft = this._usedright;
			this._openlist.Clear();
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x0004D390 File Offset: 0x0004B790
		private int Direct(AStarPoint start, AStarPoint end)
		{
			int num = end.x - start.x;
			int num2 = end.y - start.y;
			for (int i = 0; i < 8; i++)
			{
				if (num == PathHelper.DIR_VALUE2[i, 0] && num2 == PathHelper.DIR_VALUE2[i, 1])
				{
					return i;
				}
			}
			throw new Exception("can not get here");
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x0004D3FC File Offset: 0x0004B7FC
		private bool BackTraceDirection(AStarPoint start, List<int> steps)
		{
			AStarPoint astarPoint = start;
			while (astarPoint.parent != null)
			{
				AStarPoint parent = astarPoint.parent;
				steps.Add(this.Direct(astarPoint, parent));
				astarPoint = astarPoint.parent;
			}
			return true;
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x0004D438 File Offset: 0x0004B838
		private bool BackTracePoint(AStarPoint start, List<Point> steps)
		{
			AStarPoint astarPoint = start;
			while (astarPoint.parent != null)
			{
				AStarPoint parent = astarPoint.parent;
				steps.Add(new Point(parent.x, parent.y));
				astarPoint = astarPoint.parent;
			}
			return true;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x0004D480 File Offset: 0x0004B880
		private AStarPoint GetPoint(int x, int y)
		{
			if (x >= this._currentwidth || y >= this._currentheight)
			{
				return null;
			}
			AStarPoint astarPoint = this._helper[y, x];
			if (astarPoint == null)
			{
				if (this._usedleft == 0)
				{
					if (this._usedright >= this._used.Length)
					{
						return null;
					}
					AStarPoint astarPoint2 = new AStarPoint(x, y);
					this._used[this._usedright++] = astarPoint2;
					astarPoint = astarPoint2;
				}
				else
				{
					astarPoint = this._used[--this._usedleft];
					astarPoint.ResetState(x, y);
				}
				this._helper[y, x] = astarPoint;
			}
			return astarPoint;
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0004D538 File Offset: 0x0004B938
		private bool IsCloseInObstacle(Point point, int[] obstacle, int width, int height)
		{
			if (obstacle[width * point.y + point.x] != 0)
			{
				return true;
			}
			for (int i = 0; i < 8; i++)
			{
				int num = point.x + PathHelper.DIR_VALUE2[i, 0];
				int num2 = point.y + PathHelper.DIR_VALUE2[i, 1];
				if (num >= 0 && num < width)
				{
					if (num2 >= 0 && num2 < height)
					{
						if (obstacle[width * num2 + num] == 0)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0004D5D0 File Offset: 0x0004B9D0
		private bool SearchPath(int[] obstacle, int width, int height, Point pstart, Point pend)
		{
			if (pstart.x < 0 || pstart.y < 0 || pend.x < 0 || pend.y < 0)
			{
				return false;
			}
			if (pstart.x >= width || pstart.y >= height || pend.x >= width || pend.y >= height)
			{
				return false;
			}
			if (this.IsCloseInObstacle(pstart, obstacle, width, height))
			{
				return false;
			}
			if (this.IsCloseInObstacle(pend, obstacle, width, height))
			{
				return false;
			}
			this.Reset(width, height);
			AStarPoint point = this.GetPoint(pend.x, pend.y);
			AStarPoint point2 = this.GetPoint(pstart.x, pstart.y);
			if (point == null || point2 == null)
			{
				return false;
			}
			this._openlist.Add(point);
			while (this._openlist.Count > 0)
			{
				AStarPoint astarPoint = this._openlist.Pop();
				astarPoint.close = true;
				for (int i = 0; i < 8; i++)
				{
					int num = astarPoint.x + PathHelper.DIR_VALUE2[i, 0];
					int num2 = astarPoint.y + PathHelper.DIR_VALUE2[i, 1];
					if (num >= 0 && num < width)
					{
						if (num2 >= 0 && num2 < height)
						{
							if (obstacle[width * num2 + num] == 0 || (num == point2.x && num2 == point2.y))
							{
								AStarPoint point3 = this.GetPoint(num, num2);
								if (point3 != null && !point3.close)
								{
									if (num == point2.x && num2 == point2.y)
									{
										point3.parent = astarPoint;
										return true;
									}
									int num3 = astarPoint.g + this._g(astarPoint, point3);
									if (!point3.open)
									{
										point3.open = true;
										point3.parent = astarPoint;
										point3.g = num3;
										point3.f = num3 + this._f(point2, point3);
										this._openlist.Add(point3);
									}
									else if (point3.g > num3)
									{
										point3.f = point3.f - point3.g + num3;
										point3.g = num3;
										point3.parent = astarPoint;
										this._openlist.RebuildElement(point3);
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0004D86C File Offset: 0x0004BC6C
		public bool Do(int[] obstacle, int width, int height, Point pstart, Point pend, List<int> steps)
		{
			steps.Clear();
			if (pstart.x == pend.x && pstart.y == pend.y)
			{
				return true;
			}
			if (this.SearchPath(obstacle, width, height, pstart, pend))
			{
				AStarPoint point = this.GetPoint(pstart.x, pstart.y);
				return this.BackTraceDirection(point, steps);
			}
			return false;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x0004D8DC File Offset: 0x0004BCDC
		public bool Do(int[] obstacle, int width, int height, Point pstart, Point pend, List<Point> steps)
		{
			steps.Clear();
			if (pstart.x == pend.x && pstart.y == pend.y)
			{
				return true;
			}
			if (this.SearchPath(obstacle, width, height, pstart, pend))
			{
				AStarPoint point = this.GetPoint(pstart.x, pstart.y);
				return this.BackTracePoint(point, steps);
			}
			return false;
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0004D94C File Offset: 0x0004BD4C
		public bool Do(byte[] obstacle, int width, int height, Point pstart, Point pend, List<int> steps)
		{
			steps.Clear();
			if (pstart.x == pend.x && pstart.y == pend.y)
			{
				return true;
			}
			if (this.SearchPath(obstacle, width, height, pstart, pend))
			{
				AStarPoint point = this.GetPoint(pstart.x, pstart.y);
				return this.BackTraceDirection(point, steps);
			}
			return false;
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0004D9BC File Offset: 0x0004BDBC
		public bool Do(byte[] obstacle, int width, int height, Point pstart, Point pend, List<Point> steps)
		{
			steps.Clear();
			if (pstart.x == pend.x && pstart.y == pend.y)
			{
				return true;
			}
			if (this.SearchPath(obstacle, width, height, pstart, pend))
			{
				AStarPoint point = this.GetPoint(pstart.x, pstart.y);
				return this.BackTracePoint(point, steps);
			}
			return false;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0004DA2C File Offset: 0x0004BE2C
		private bool SearchPath(byte[] obstacle, int width, int height, Point pstart, Point pend)
		{
			if (pstart.x < 0 || pstart.y < 0 || pend.x < 0 || pend.y < 0)
			{
				return false;
			}
			if (pstart.x >= width || pstart.y >= height || pend.x >= width || pend.y >= height)
			{
				return false;
			}
			if (this.IsCloseInObstacle(pstart, obstacle, width, height))
			{
				return false;
			}
			if (this.IsCloseInObstacle(pend, obstacle, width, height))
			{
				return false;
			}
			this.Reset(width, height);
			AStarPoint point = this.GetPoint(pend.x, pend.y);
			AStarPoint point2 = this.GetPoint(pstart.x, pstart.y);
			if (point == null || point2 == null)
			{
				return false;
			}
			this._openlist.Add(point);
			while (this._openlist.Count > 0)
			{
				AStarPoint astarPoint = this._openlist.Pop();
				astarPoint.close = true;
				for (int i = 0; i < 8; i++)
				{
					int num = astarPoint.x + PathHelper.DIR_VALUE2[i, 0];
					int num2 = astarPoint.y + PathHelper.DIR_VALUE2[i, 1];
					if (num >= 0 && num < width)
					{
						if (num2 >= 0 && num2 < height)
						{
							if (obstacle[width * num2 + num] == 0 || (num == point2.x && num2 == point2.y))
							{
								AStarPoint point3 = this.GetPoint(num, num2);
								if (point3 != null && !point3.close)
								{
									if (num == point2.x && num2 == point2.y)
									{
										point3.parent = astarPoint;
										return true;
									}
									int num3 = astarPoint.g + this._g(astarPoint, point3);
									if (!point3.open)
									{
										point3.open = true;
										point3.parent = astarPoint;
										point3.g = num3;
										point3.f = point3.g + this._f(point2, point3);
										this._openlist.Add(point3);
									}
									else if (point3.g > num3)
									{
										point3.f = point3.f - point3.g + num3;
										point3.g = num3;
										point3.parent = astarPoint;
										this._openlist.RebuildElement(point3);
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0004DCCC File Offset: 0x0004C0CC
		private bool IsCloseInObstacle(Point point, byte[] obstacle, int width, int height)
		{
			if (obstacle[width * point.y + point.x] != 0)
			{
				return true;
			}
			for (int i = 0; i < 8; i++)
			{
				int num = point.x + PathHelper.DIR_VALUE2[i, 0];
				int num2 = point.y + PathHelper.DIR_VALUE2[i, 1];
				if (num >= 0 && num < width)
				{
					if (num2 >= 0 && num2 < height)
					{
						if (obstacle[width * num2 + num] == 0)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x04000A76 RID: 2678
		private int _helperwidth = 100;

		// Token: 0x04000A77 RID: 2679
		private int _helperHeight = 100;

		// Token: 0x04000A78 RID: 2680
		private int _currentwidth;

		// Token: 0x04000A79 RID: 2681
		private int _currentheight;

		// Token: 0x04000A7A RID: 2682
		private AStarPoint[,] _helper = new AStarPoint[100, 100];

		// Token: 0x04000A7B RID: 2683
		public int _usedleft;

		// Token: 0x04000A7C RID: 2684
		public int _usedright;

		// Token: 0x04000A7D RID: 2685
		public AStarPoint[] _used = new AStarPoint[4096];

		// Token: 0x04000A7E RID: 2686
		private MaxHeap<AStarPoint> _openlist = new MaxHeap<AStarPoint>(1024);

		// Token: 0x04000A7F RID: 2687
		private Func<AStarPoint, AStarPoint, int> _g;

		// Token: 0x04000A80 RID: 2688
		private Func<AStarPoint, AStarPoint, int> _f;
	}
}

using System;
using System.Collections.Generic;
using PathFinder;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DD7 RID: 3543
	public static class PathFinding
	{
		// Token: 0x06008F14 RID: 36628 RVA: 0x001A73C0 File Offset: 0x001A57C0
		public static List<Vector3> FindPath(Vector3 current, Vector3 target, PathFinding.GridInfo gridInfo)
		{
			current.y = 0f;
			target.y = 0f;
			List<Vector3> list = new List<Vector3>();
			if ((current - target).sqrMagnitude <= 2E-06f)
			{
				list.Add(current);
				list.Add(target);
				return list;
			}
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.instance.GetTableItem<SwitchClientFunctionTable>(22, string.Empty, string.Empty);
			if (tableItem != null && !tableItem.Open)
			{
				PathFinding.m_gridInfo = gridInfo;
				PathFinding.Grid v = new PathFinding.Grid(PathFinding.m_gridInfo, current);
				PathFinding.Grid end = new PathFinding.Grid(PathFinding.m_gridInfo, target);
				int num = -1;
				PathFinding.m_openList.Add(v);
				while (PathFinding.m_openList.Count != 0)
				{
					PathFinding.Grid grid3 = PathFinding.m_openList.TakeTop();
					PathFinding.m_closeList.Add(grid3);
					int parentGrid = PathFinding.m_closeList.Count - 1;
					List<PathFinding.Grid> list2 = PathFinding._SurrroundPoints(grid3);
					for (int i = 0; i < list2.Count; i++)
					{
						PathFinding.Grid grid = list2[i];
						int num2 = PathFinding.m_openList.FindIndex((PathFinding.Grid value) => value.X == grid.X && value.Y == grid.Y);
						if (num2 >= 0 && num2 < PathFinding.m_openList.Count)
						{
							PathFinding.Grid grid2 = PathFinding.m_openList[num2];
							float num3 = PathFinding._CalcG(grid3, grid2);
							if (num3 < grid2.G)
							{
								grid2.ParentGrid = parentGrid;
								grid2.G = num3;
								PathFinding.m_openList[num2] = grid2;
							}
						}
						else
						{
							grid.ParentGrid = parentGrid;
							grid.G = PathFinding._CalcG(grid3, grid);
							grid.H = PathFinding._CalcH(end, grid);
							PathFinding.m_openList.Add(grid);
						}
					}
					int num4 = PathFinding.m_openList.FindIndex((PathFinding.Grid value) => value.X == end.X && value.Y == end.Y);
					if (num4 >= 0 && num4 < PathFinding.m_openList.Count)
					{
						PathFinding.m_closeList.Add(PathFinding.m_openList[num4]);
						num = PathFinding.m_closeList.Count - 1;
						break;
					}
				}
				if (num >= 0 && num < PathFinding.m_closeList.Count)
				{
					list.Insert(0, target);
					if (PathFinding.m_closeList[num].RealPos == target)
					{
						num = PathFinding.m_closeList[num].ParentGrid;
					}
					while (num >= 0 && num < PathFinding.m_closeList.Count)
					{
						list.Insert(0, PathFinding.m_closeList[num].RealPos);
						num = PathFinding.m_closeList[num].ParentGrid;
					}
				}
				PathFinding.m_openList.Clear();
				PathFinding.m_closeList.Clear();
				PathFinding.m_tempSurrroundGrids.Clear();
				for (int j = 0; j < list.Count; j++)
				{
				}
				return list;
			}
			byte[] gridBlockLayer = gridInfo.GridBlockLayer;
			int width = gridInfo.GridMaxX - gridInfo.GridMinX;
			int height = gridInfo.GridMaxY - gridInfo.GridMinY;
			int px = (int)Mathf.Floor(current.x / gridInfo.GridSize.x) - gridInfo.GridMinX;
			int py = (int)Mathf.Floor(current.z / gridInfo.GridSize.y) - gridInfo.GridMinY;
			int px2 = (int)Mathf.Floor(target.x / gridInfo.GridSize.x) - gridInfo.GridMinX;
			int py2 = (int)Mathf.Floor(target.z / gridInfo.GridSize.y) - gridInfo.GridMinY;
			PathHelper._start.Set(px, py);
			PathHelper._end.Set(px2, py2);
			if (PathHelper._start.x < 0 || PathHelper._start.y < 0 || PathHelper._end.x < 0 || PathHelper._end.y < 0)
			{
				Logger.LogError(string.Format("坐标 小于0了  {0}{1}{2}{3}", new object[]
				{
					PathHelper._start.x,
					PathHelper._start.y,
					PathHelper._end.x,
					PathHelper._end.y
				}));
				return list;
			}
			if (PathHelper._astar.Do(gridBlockLayer, width, height, PathHelper._start, PathHelper._end, PathHelper._list))
			{
				list.Add(current);
				float num5 = current.x;
				float y = current.y;
				float num6 = current.z;
				for (int k = 0; k < PathHelper._list.Count - 1; k++)
				{
					int num7 = PathHelper._list[k];
					num5 += (float)PathHelper.DIR_VALUE2[num7, 0] * gridInfo.GridSize.x;
					num6 += (float)PathHelper.DIR_VALUE2[num7, 1] * gridInfo.GridSize.y;
					list.Add(new Vector3(num5, y, num6));
				}
				list.Add(target);
			}
			return list;
		}

		// Token: 0x06008F15 RID: 36629 RVA: 0x001A7934 File Offset: 0x001A5D34
		private static float _CalcG(PathFinding.Grid start, PathFinding.Grid point)
		{
			float num;
			if (start.X == point.X)
			{
				num = PathFinding.m_gridInfo.GridSize.x;
			}
			else if (start.Y == point.Y)
			{
				num = PathFinding.m_gridInfo.GridSize.y;
			}
			else
			{
				num = PathFinding.m_gridInfo.GridDiagonalLength;
			}
			return num + start.G;
		}

		// Token: 0x06008F16 RID: 36630 RVA: 0x001A79AC File Offset: 0x001A5DAC
		private static float _CalcH(PathFinding.Grid end, PathFinding.Grid point)
		{
			Vector3 vector = end.RealPos - point.RealPos;
			return (float)Math.Sqrt((double)(vector.x * vector.x + vector.z * vector.z));
		}

		// Token: 0x06008F17 RID: 36631 RVA: 0x001A79F4 File Offset: 0x001A5DF4
		private static List<PathFinding.Grid> _SurrroundPoints(PathFinding.Grid point)
		{
			PathFinding.m_tempSurrroundGrids.Clear();
			for (int i = point.X - 1; i <= point.X + 1; i++)
			{
				for (int j = point.Y - 1; j <= point.Y + 1; j++)
				{
					if (i != point.X || j != point.Y)
					{
						PathFinding.Grid grid = new PathFinding.Grid(PathFinding.m_gridInfo, i, j);
						if (PathFinding._GridCanReach(grid))
						{
							PathFinding.m_tempSurrroundGrids.Add(grid);
						}
					}
				}
			}
			return PathFinding.m_tempSurrroundGrids;
		}

		// Token: 0x06008F18 RID: 36632 RVA: 0x001A7A94 File Offset: 0x001A5E94
		private static bool _GridCanReach(PathFinding.Grid grid)
		{
			if (grid.X < PathFinding.m_gridInfo.GridMinX || grid.X >= PathFinding.m_gridInfo.GridMaxX)
			{
				return false;
			}
			if (grid.Y < PathFinding.m_gridInfo.GridMinY || grid.Y >= PathFinding.m_gridInfo.GridMaxY)
			{
				return false;
			}
			int num = PathFinding.m_closeList.FindIndex((PathFinding.Grid value) => value.X == grid.X && value.Y == grid.Y);
			if (num >= 0 && num < PathFinding.m_closeList.Count)
			{
				return false;
			}
			int num2 = grid.X - PathFinding.m_gridInfo.GridMinX;
			int num3 = grid.Y - PathFinding.m_gridInfo.GridMinY;
			int num4 = (PathFinding.m_gridInfo.GridMaxX - PathFinding.m_gridInfo.GridMinX) * num3 + num2;
			if (num4 >= 0 && num4 < PathFinding.m_gridInfo.GridBlockLayer.Length)
			{
				return PathFinding.m_gridInfo.GridBlockLayer[num4] == 0;
			}
			Logger.LogErrorFormat("GridCanReach index error!!! grid.X:{0} grid.Y:{1} GridMinX:{2} GridMinY:{3} GridXSize:{4} GridYSize:{5}", new object[]
			{
				grid.X,
				grid.Y,
				PathFinding.m_gridInfo.GridMinX,
				PathFinding.m_gridInfo.GridMinY,
				PathFinding.m_gridInfo.GridMaxX - PathFinding.m_gridInfo.GridMinX,
				PathFinding.m_gridInfo.GridMaxY - PathFinding.m_gridInfo.GridMinY
			});
			return false;
		}

		// Token: 0x040046F2 RID: 18162
		public const int OBLIQUE = 14;

		// Token: 0x040046F3 RID: 18163
		public const int STEP = 10;

		// Token: 0x040046F4 RID: 18164
		private static List<PathFinding.Grid> m_closeList = new List<PathFinding.Grid>();

		// Token: 0x040046F5 RID: 18165
		private static PriorityQueue<PathFinding.Grid> m_openList = new PriorityQueue<PathFinding.Grid>(new PathFinding.GridComparer());

		// Token: 0x040046F6 RID: 18166
		private static List<PathFinding.Grid> m_tempSurrroundGrids = new List<PathFinding.Grid>();

		// Token: 0x040046F7 RID: 18167
		private static PathFinding.GridInfo m_gridInfo;

		// Token: 0x02000DD8 RID: 3544
		public class GridInfo
		{
			// Token: 0x040046F8 RID: 18168
			public Vector2 GridSize;

			// Token: 0x040046F9 RID: 18169
			public float GridDiagonalLength;

			// Token: 0x040046FA RID: 18170
			public int GridMinX;

			// Token: 0x040046FB RID: 18171
			public int GridMaxX;

			// Token: 0x040046FC RID: 18172
			public int GridMinY;

			// Token: 0x040046FD RID: 18173
			public int GridMaxY;

			// Token: 0x040046FE RID: 18174
			public byte[] GridBlockLayer;
		}

		// Token: 0x02000DD9 RID: 3545
		public struct Grid
		{
			// Token: 0x06008F1B RID: 36635 RVA: 0x001A7C84 File Offset: 0x001A6084
			public Grid(PathFinding.GridInfo gridInfo, Vector3 realPos)
			{
				this.RealPos = realPos;
				this.X = (int)Math.Floor((double)(this.RealPos.x / gridInfo.GridSize.x));
				this.Y = (int)Math.Floor((double)(this.RealPos.z / gridInfo.GridSize.y));
				this.m_h = 0f;
				this.m_g = 0f;
				this.F = 0f;
				this.ParentGrid = -1;
			}

			// Token: 0x06008F1C RID: 36636 RVA: 0x001A7D08 File Offset: 0x001A6108
			public Grid(PathFinding.GridInfo gridInfo, int x, int y)
			{
				this.X = x;
				this.Y = y;
				this.RealPos = new Vector3(((float)this.X + 0.5f) * gridInfo.GridSize.x, 0f, ((float)this.Y + 0.5f) * gridInfo.GridSize.y);
				this.m_h = 0f;
				this.m_g = 0f;
				this.F = 0f;
				this.ParentGrid = -1;
			}

			// Token: 0x170018D5 RID: 6357
			// (get) Token: 0x06008F1D RID: 36637 RVA: 0x001A7D8D File Offset: 0x001A618D
			// (set) Token: 0x06008F1E RID: 36638 RVA: 0x001A7D95 File Offset: 0x001A6195
			public float G
			{
				get
				{
					return this.m_g;
				}
				set
				{
					this.m_g = value;
					this.F = this.m_g + this.m_h;
				}
			}

			// Token: 0x170018D6 RID: 6358
			// (get) Token: 0x06008F1F RID: 36639 RVA: 0x001A7DB1 File Offset: 0x001A61B1
			// (set) Token: 0x06008F20 RID: 36640 RVA: 0x001A7DB9 File Offset: 0x001A61B9
			public float H
			{
				get
				{
					return this.m_h;
				}
				set
				{
					this.m_h = value;
					this.F = this.m_g + this.m_h;
				}
			}

			// Token: 0x040046FF RID: 18175
			public int ParentGrid;

			// Token: 0x04004700 RID: 18176
			public float F;

			// Token: 0x04004701 RID: 18177
			private float m_g;

			// Token: 0x04004702 RID: 18178
			private float m_h;

			// Token: 0x04004703 RID: 18179
			public int X;

			// Token: 0x04004704 RID: 18180
			public int Y;

			// Token: 0x04004705 RID: 18181
			public Vector3 RealPos;
		}

		// Token: 0x02000DDA RID: 3546
		public class GridComparer : IComparer<PathFinding.Grid>
		{
			// Token: 0x06008F22 RID: 36642 RVA: 0x001A7DDD File Offset: 0x001A61DD
			public int Compare(PathFinding.Grid x, PathFinding.Grid y)
			{
				if (x.F > y.F)
				{
					return -1;
				}
				if (x.F < y.F)
				{
					return 1;
				}
				return 0;
			}
		}
	}
}

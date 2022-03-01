using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020041FA RID: 16890
public static class TreasureMapGenerator
{
	// Token: 0x060175EC RID: 95724 RVA: 0x0072E2A4 File Offset: 0x0072C6A4
	private static TreasureMapGenerator.RouterInfo GenRouterInfo()
	{
		if (TreasureMapGenerator.outOfRouterBuffer)
		{
			Logger.LogErrorFormat("router buffer is out of range seed {0} {1}", new object[]
			{
				TreasureMapGenerator.randomInst.GetSeed(),
				TreasureMapGenerator.initRandomSeed
			});
			return new TreasureMapGenerator.RouterInfo();
		}
		if (TreasureMapGenerator.routerUsedCount >= TreasureMapGenerator.routerBuffer.Length)
		{
			TreasureMapGenerator.outOfRouterBuffer = true;
			Logger.LogErrorFormat("router buffer is out of range seed {0} {1}", new object[]
			{
				TreasureMapGenerator.randomInst.GetSeed(),
				TreasureMapGenerator.initRandomSeed
			});
			return new TreasureMapGenerator.RouterInfo();
		}
		int num = TreasureMapGenerator.routerUsedCount;
		if (TreasureMapGenerator.routerBuffer[num] == null)
		{
			TreasureMapGenerator.routerBuffer[num] = new TreasureMapGenerator.RouterInfo();
		}
		TreasureMapGenerator.routerUsedCount++;
		return TreasureMapGenerator.routerBuffer[num];
	}

	// Token: 0x060175ED RID: 95725 RVA: 0x0072E36F File Offset: 0x0072C76F
	private static void PushRouterInfo(TreasureMapGenerator.RouterInfo info)
	{
		if (TreasureMapGenerator.outOfRouterBuffer)
		{
			return;
		}
		if (TreasureMapGenerator.routerUsedCount <= 0)
		{
			return;
		}
		TreasureMapGenerator.routerUsedCount--;
	}

	// Token: 0x060175EE RID: 95726 RVA: 0x0072E394 File Offset: 0x0072C794
	private static void ClearRouterInfo()
	{
		TreasureMapGenerator.routerUsedCount = 0;
		TreasureMapGenerator.outOfRouterBuffer = false;
	}

	// Token: 0x060175EF RID: 95727 RVA: 0x0072E3A2 File Offset: 0x0072C7A2
	public static TreasureMapGenerator.POS_TYPE GetPosTypeInGameCoord(int x, int y)
	{
		return TreasureMapGenerator.GetPosType(y, x);
	}

	// Token: 0x060175F0 RID: 95728 RVA: 0x0072E3AC File Offset: 0x0072C7AC
	public static TreasureMapGenerator.POS_TYPE GetPosType(int x, int y)
	{
		if (x == 0 && y == 0)
		{
			return TreasureMapGenerator.POS_TYPE.LEFT_TOP_CORNER;
		}
		if (x == (int)(TreasureMapGenerator.MAX_ROW - 1) && y == 0)
		{
			return TreasureMapGenerator.POS_TYPE.LEFT_BOTTOM_CORNER;
		}
		if (x == 0 && y == (int)(TreasureMapGenerator.MAX_COL - 1))
		{
			return TreasureMapGenerator.POS_TYPE.RIGHT_TOP_CORNER;
		}
		if (x == (int)(TreasureMapGenerator.MAX_ROW - 1) && y == (int)(TreasureMapGenerator.MAX_COL - 1))
		{
			return TreasureMapGenerator.POS_TYPE.RIGHT_BOTTOM_CORNER;
		}
		if (x == 0)
		{
			return TreasureMapGenerator.POS_TYPE.TOP_CORNER;
		}
		if (x == (int)(TreasureMapGenerator.MAX_ROW - 1))
		{
			return TreasureMapGenerator.POS_TYPE.BOTTOM_CORNER;
		}
		if (y == 0)
		{
			return TreasureMapGenerator.POS_TYPE.LEFT_CORNER;
		}
		if (y == (int)(TreasureMapGenerator.MAX_COL - 1))
		{
			return TreasureMapGenerator.POS_TYPE.RIGHT_CORNER;
		}
		return TreasureMapGenerator.POS_TYPE.NORMAL;
	}

	// Token: 0x060175F1 RID: 95729 RVA: 0x0072E43C File Offset: 0x0072C83C
	public static bool GetNextLinkPosInGameCoord(int x, int y, ref int nextX, ref int nextY, int dirIndex)
	{
		TreasureMapGenerator.POS_TYPE posTypeInGameCoord = TreasureMapGenerator.GetPosTypeInGameCoord(x, y);
		int num = 0;
		bool linkPos = TreasureMapGenerator.GetLinkPos(y, x, ref nextY, ref nextX, posTypeInGameCoord, false, dirIndex, ref num);
		if (linkPos)
		{
			return TreasureMapGenerator.roomTypes[y, x] != 0;
		}
		return linkPos;
	}

	// Token: 0x060175F2 RID: 95730 RVA: 0x0072E480 File Offset: 0x0072C880
	public static bool isInBossRangeInGameCoord(int x, int y, int bossX, int bossY)
	{
		TreasureMapGenerator.POS_TYPE posTypeInGameCoord = TreasureMapGenerator.GetPosTypeInGameCoord(x, y);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			int num2 = 0;
			int num3 = 0;
			if (!TreasureMapGenerator.GetCrossLinkPos(y, x, ref num3, ref num2, posTypeInGameCoord, false, i, ref num))
			{
				break;
			}
			if (num2 == bossX && num3 == bossY)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060175F3 RID: 95731 RVA: 0x0072E4E0 File Offset: 0x0072C8E0
	public static bool GetLinkPos(int x, int y, ref int nextX, ref int nextY, TreasureMapGenerator.POS_TYPE posType, bool needRand, int tryCount, ref int linkIndex)
	{
		if (!TreasureMapGenerator.doorDir.ContainsKey((int)posType))
		{
			return false;
		}
		List<TreasureMapGenerator.Direction2> list = TreasureMapGenerator.doorDir[(int)posType];
		if (needRand)
		{
			linkIndex = TreasureMapGenerator.randomInst.InRange(0, list.Count);
		}
		else
		{
			linkIndex = tryCount;
		}
		if (linkIndex >= list.Count)
		{
			return false;
		}
		TreasureMapGenerator.Direction2 direction = list[linkIndex];
		nextX = x + (int)direction.x;
		nextY = y + (int)direction.y;
		return true;
	}

	// Token: 0x060175F4 RID: 95732 RVA: 0x0072E564 File Offset: 0x0072C964
	public static bool GetCrossLinkPos(int x, int y, ref int nextX, ref int nextY, TreasureMapGenerator.POS_TYPE posType, bool needRand, int tryCount, ref int linkIndex)
	{
		if (!TreasureMapGenerator.doorCrossDir.ContainsKey((int)posType))
		{
			return false;
		}
		List<TreasureMapGenerator.Direction2> list = TreasureMapGenerator.doorCrossDir[(int)posType];
		if (needRand)
		{
			linkIndex = TreasureMapGenerator.randomInst.InRange(0, list.Count);
		}
		else
		{
			linkIndex = tryCount;
		}
		if (linkIndex >= list.Count)
		{
			return false;
		}
		TreasureMapGenerator.Direction2 direction = list[linkIndex];
		nextX = x + (int)direction.x;
		nextY = y + (int)direction.y;
		return true;
	}

	// Token: 0x060175F5 RID: 95733 RVA: 0x0072E5E8 File Offset: 0x0072C9E8
	private static void AddRoom(int x, int y)
	{
		TreasureMapGenerator.leftRoomCount = (sbyte)((int)TreasureMapGenerator.leftRoomCount - 1);
		TreasureMapGenerator.roomTypes[x, y] = 1;
		TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount] = (byte)(x * (int)TreasureMapGenerator.MAX_COL + y);
		TreasureMapGenerator.randRoomCount = (sbyte)((int)TreasureMapGenerator.randRoomCount + 1);
	}

	// Token: 0x060175F6 RID: 95734 RVA: 0x0072E634 File Offset: 0x0072CA34
	private static void AddLink(int x, int y, int nextX, int nextY)
	{
		TreasureMapGenerator.linkInfo[nextX, nextY].AddLink(x, y);
		TreasureMapGenerator.linkInfo[x, y].AddLink(nextX, nextY);
	}

	// Token: 0x060175F7 RID: 95735 RVA: 0x0072E660 File Offset: 0x0072CA60
	private static bool GenerateLinkRoom(int x, int y)
	{
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return false;
		}
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(x, y);
		int num = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
		int num2 = 0;
		int num3 = TreasureMapGenerator.randomInst.InRange(1, num + 1);
		int num4 = 0;
		while (num4 < num && (int)TreasureMapGenerator.leftRoomCount > 0)
		{
			int num5 = x;
			int num6 = y;
			int tryCount = 0;
			int num7 = 0;
			TreasureMapGenerator.GetLinkPos(x, y, ref num5, ref num6, posType, true, tryCount, ref num7);
			if (TreasureMapGenerator.roomTypes[num5, num6] == 0)
			{
				TreasureMapGenerator.AddRoom(num5, num6);
				TreasureMapGenerator.AddLink(x, y, num5, num6);
				num2++;
				TreasureMapGenerator.GenerateLinkRoom(num5, num6);
				if (num2 >= num3)
				{
					return true;
				}
			}
			else
			{
				bool flag = false;
				int i = 0;
				while (i < 4)
				{
					num7 = i;
					tryCount = i;
					if (!TreasureMapGenerator.GetLinkPos(x, y, ref num5, ref num6, posType, false, tryCount, ref num7))
					{
						break;
					}
					if (TreasureMapGenerator.roomTypes[num5, num6] == 0)
					{
						TreasureMapGenerator.AddRoom(num5, num6);
						TreasureMapGenerator.AddLink(x, y, num5, num6);
						num2++;
						TreasureMapGenerator.GenerateLinkRoom(num5, num6);
						flag = true;
						if (num2 >= num3)
						{
							return true;
						}
						break;
					}
					else
					{
						bool flag2 = false;
						if (num3 < 3 && TreasureMapGenerator.linkInfo[num5, num6].GetCount() < 3)
						{
							flag2 = true;
						}
						else if (TreasureMapGenerator.randomInst.InRange(0, 101) >= 35)
						{
							flag2 = true;
						}
						if (flag2)
						{
							TreasureMapGenerator.AddLink(x, y, num5, num6);
						}
						i++;
					}
				}
				if (!flag)
				{
				}
			}
			num4++;
		}
		return true;
	}

	// Token: 0x060175F8 RID: 95736 RVA: 0x0072E7FC File Offset: 0x0072CBFC
	private static bool GenerateLinkRoom_2(int x, int y)
	{
		TreasureMapGenerator.travelRouter.Clear();
		TreasureMapGenerator.ClearRouterInfo();
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return false;
		}
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(x, y);
		int num = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
		int num2 = TreasureMapGenerator.randomInst.InRange(1, num + 1);
		TreasureMapGenerator.RouterInfo routerInfo = TreasureMapGenerator.GenRouterInfo();
		routerInfo.randDoorCount = (byte)num2;
		routerInfo.pos.x = (sbyte)x;
		routerInfo.pos.y = (sbyte)y;
		routerInfo.startIndex = 0;
		routerInfo.curDoorCount = 0;
		routerInfo.conflictIndex = 0;
		TreasureMapGenerator.travelRouter.Push(routerInfo);
		while (TreasureMapGenerator.travelRouter.Count > 0)
		{
			TreasureMapGenerator.RouterInfo routerInfo2 = TreasureMapGenerator.travelRouter.Peek();
			x = (int)routerInfo2.pos.x;
			y = (int)routerInfo2.pos.y;
			posType = TreasureMapGenerator.GetPosType(x, y);
			num2 = (int)routerInfo2.randDoorCount;
			num = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
			int num3 = (int)routerInfo2.curDoorCount;
			bool flag = false;
			int num4 = (int)routerInfo2.startIndex;
			while (num4 < num && (int)TreasureMapGenerator.leftRoomCount > 0 && num3 < num2)
			{
				int num5 = x;
				int num6 = y;
				int tryCount = 0;
				int num7 = 0;
				TreasureMapGenerator.GetLinkPos(x, y, ref num5, ref num6, posType, true, tryCount, ref num7);
				if (num5 < 0 || num5 >= (int)TreasureMapGenerator.MAX_ROW || num6 < 0 || num6 >= (int)TreasureMapGenerator.MAX_COL)
				{
					Logger.LogErrorFormat("wrong stack info : x {0} y {1} nextX {2} nextY {3} curPosType {4} index {5} seed {6} {7}", new object[]
					{
						x,
						y,
						num5,
						num6,
						posType,
						num4,
						TreasureMapGenerator.randomInst.GetSeed(),
						TreasureMapGenerator.initRandomSeed
					});
					return false;
				}
				int num8 = num5 * (int)TreasureMapGenerator.MAX_COL + num6;
				if (TreasureMapGenerator.roomTypes[num5, num6] == 0)
				{
					TreasureMapGenerator.AddRoom(num5, num6);
					TreasureMapGenerator.AddLink(x, y, num5, num6);
					num3++;
					if ((int)TreasureMapGenerator.leftRoomCount == 0)
					{
						return true;
					}
					TreasureMapGenerator.RouterInfo routerInfo3 = TreasureMapGenerator.GenRouterInfo();
					TreasureMapGenerator.POS_TYPE posType2 = TreasureMapGenerator.GetPosType(num5, num6);
					int num9 = (int)TreasureMapGenerator.doorCountTemplate[(int)posType2];
					routerInfo3.randDoorCount = (byte)TreasureMapGenerator.randomInst.InRange(1, num9 + 1);
					routerInfo3.pos.x = (sbyte)num5;
					routerInfo3.pos.y = (sbyte)num6;
					routerInfo3.startIndex = 0;
					routerInfo3.conflictIndex = 0;
					routerInfo3.curDoorCount = 0;
					routerInfo2.startIndex = (byte)(num4 + 1);
					routerInfo2.conflictIndex = 0;
					routerInfo2.curDoorCount = (byte)num3;
					TreasureMapGenerator.travelRouter.Push(routerInfo3);
					flag = true;
					break;
				}
				else
				{
					bool flag2 = false;
					int i = (int)routerInfo2.conflictIndex;
					while (i < 4)
					{
						num7 = i;
						tryCount = i;
						if (!TreasureMapGenerator.GetLinkPos(x, y, ref num5, ref num6, posType, false, tryCount, ref num7))
						{
							routerInfo2.startIndex = (byte)(num4 + 1);
							routerInfo2.conflictIndex = 0;
							break;
						}
						if (TreasureMapGenerator.roomTypes[num5, num6] == 0)
						{
							TreasureMapGenerator.AddRoom(num5, num6);
							TreasureMapGenerator.AddLink(x, y, num5, num6);
							num3++;
							if ((int)TreasureMapGenerator.leftRoomCount == 0)
							{
								return true;
							}
							TreasureMapGenerator.RouterInfo routerInfo4 = TreasureMapGenerator.GenRouterInfo();
							TreasureMapGenerator.POS_TYPE posType3 = TreasureMapGenerator.GetPosType(num5, num6);
							int num10 = (int)TreasureMapGenerator.doorCountTemplate[(int)posType3];
							routerInfo4.randDoorCount = (byte)TreasureMapGenerator.randomInst.InRange(1, num10 + 1);
							routerInfo4.pos.x = (sbyte)num5;
							routerInfo4.pos.y = (sbyte)num6;
							routerInfo4.conflictIndex = 0;
							routerInfo4.curDoorCount = 0;
							routerInfo4.startIndex = 0;
							TreasureMapGenerator.travelRouter.Push(routerInfo4);
							routerInfo2.startIndex = (byte)(num4 + 1);
							routerInfo2.conflictIndex = 0;
							routerInfo2.curDoorCount = (byte)num3;
							flag2 = true;
							flag = true;
							break;
						}
						else
						{
							bool flag3 = false;
							if (num2 < 3 && TreasureMapGenerator.linkInfo[num5, num6].GetCount() < 3)
							{
								flag3 = true;
							}
							else if (TreasureMapGenerator.randomInst.InRange(0, 101) >= 35)
							{
								flag3 = true;
							}
							if (flag3)
							{
								TreasureMapGenerator.AddLink(x, y, num5, num6);
							}
							i++;
						}
					}
					if (flag2)
					{
						break;
					}
					num4++;
				}
			}
			if (!flag)
			{
				TreasureMapGenerator.travelRouter.Pop();
				TreasureMapGenerator.PushRouterInfo(routerInfo2);
			}
		}
		return true;
	}

	// Token: 0x060175F9 RID: 95737 RVA: 0x0072EC5C File Offset: 0x0072D05C
	private static bool TraverseAndGenerateLinkRoom(int x, int y)
	{
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return true;
		}
		if (TreasureMapGenerator.roomTypes[x, y] == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		TreasureMapGenerator.LinkInfo linkInfo = TreasureMapGenerator.linkInfo[x, y];
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(x, y);
		int num3 = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
		int i = 0;
		while (i < 4)
		{
			int num4 = i;
			if (TreasureMapGenerator.GetLinkPos(x, y, ref num, ref num2, posType, false, i, ref num4))
			{
				int num5 = num * (int)TreasureMapGenerator.MAX_COL + num2;
				if (TreasureMapGenerator.roomTypes[num, num2] == 0)
				{
					TreasureMapGenerator.AddRoom(num, num2);
					TreasureMapGenerator.AddLink(x, y, num, num2);
					if ((int)TreasureMapGenerator.leftRoomCount == 0)
					{
						return true;
					}
					TreasureMapGenerator.visitedRoom[num5] = true;
					TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
					TreasureMapGenerator.TraverseAndGenerateLinkRoom(num, num2);
				}
				else if (!TreasureMapGenerator.visitedRoom[num5])
				{
					TreasureMapGenerator.visitedRoom[num5] = true;
					TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
					TreasureMapGenerator.TraverseAndGenerateLinkRoom(num, num2);
				}
				IL_FC:
				i++;
				continue;
				goto IL_FC;
			}
			break;
		}
		return (int)TreasureMapGenerator.leftRoomCount == 0;
	}

	// Token: 0x060175FA RID: 95738 RVA: 0x0072ED84 File Offset: 0x0072D184
	private static bool TraverseAndGenerateLinkRoom_2(int x, int y)
	{
		TreasureMapGenerator.travelRouter.Clear();
		TreasureMapGenerator.ClearRouterInfo();
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return true;
		}
		if (TreasureMapGenerator.roomTypes[x, y] == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		TreasureMapGenerator.LinkInfo linkInfo = TreasureMapGenerator.linkInfo[x, y];
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(x, y);
		int num3 = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
		TreasureMapGenerator.RouterInfo routerInfo = TreasureMapGenerator.GenRouterInfo();
		routerInfo.pos.x = (sbyte)x;
		routerInfo.pos.y = (sbyte)y;
		TreasureMapGenerator.travelRouter.Push(routerInfo);
		while (TreasureMapGenerator.travelRouter.Count > 0)
		{
			TreasureMapGenerator.RouterInfo routerInfo2 = TreasureMapGenerator.travelRouter.Pop();
			x = (int)routerInfo2.pos.x;
			y = (int)routerInfo2.pos.y;
			posType = TreasureMapGenerator.GetPosType(x, y);
			TreasureMapGenerator.PushRouterInfo(routerInfo2);
			int i = 0;
			while (i < 4)
			{
				int num4 = i;
				if (!TreasureMapGenerator.GetLinkPos(x, y, ref num, ref num2, posType, false, i, ref num4))
				{
					break;
				}
				if (num < 0 || num >= (int)TreasureMapGenerator.MAX_ROW || num2 < 0 || num2 >= (int)TreasureMapGenerator.MAX_COL)
				{
					Logger.LogErrorFormat("wrong stack info : x {0} y {1} nextX {2} nextY {3} curPosType {4} dir {5} seed {6} {7}", new object[]
					{
						x,
						y,
						num,
						num2,
						posType,
						i,
						TreasureMapGenerator.randomInst.GetSeed(),
						TreasureMapGenerator.initRandomSeed
					});
					return false;
				}
				int num5 = num * (int)TreasureMapGenerator.MAX_COL + num2;
				if (TreasureMapGenerator.roomTypes[num, num2] == 0)
				{
					TreasureMapGenerator.AddRoom(num, num2);
					TreasureMapGenerator.AddLink(x, y, num, num2);
					if ((int)TreasureMapGenerator.leftRoomCount == 0)
					{
						return true;
					}
					TreasureMapGenerator.visitedRoom[num5] = true;
					TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
					TreasureMapGenerator.RouterInfo routerInfo3 = TreasureMapGenerator.GenRouterInfo();
					routerInfo3.pos.x = (sbyte)num;
					routerInfo3.pos.y = (sbyte)num2;
					TreasureMapGenerator.travelRouter.Push(routerInfo3);
				}
				else if (!TreasureMapGenerator.visitedRoom[num5])
				{
					TreasureMapGenerator.visitedRoom[num5] = true;
					TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
					TreasureMapGenerator.RouterInfo routerInfo4 = TreasureMapGenerator.GenRouterInfo();
					routerInfo4.pos.x = (sbyte)num;
					routerInfo4.pos.y = (sbyte)num2;
					TreasureMapGenerator.travelRouter.Push(routerInfo4);
				}
				IL_252:
				i++;
				continue;
				goto IL_252;
			}
			if ((int)TreasureMapGenerator.leftRoomCount == 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060175FB RID: 95739 RVA: 0x0072F010 File Offset: 0x0072D410
	private static bool FixLeftRoom()
	{
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return true;
		}
		Array.Clear(TreasureMapGenerator.visitedRoom, 0, TreasureMapGenerator.visitedRoom.Length);
		TreasureMapGenerator.visitedRoomCount = 1;
		TreasureMapGenerator.visitedRoom[(int)TreasureMapGenerator.bornPosX * (int)TreasureMapGenerator.MAX_COL + (int)TreasureMapGenerator.bornPosY] = true;
		TreasureMapGenerator.TraverseAndGenerateLinkRoom_2((int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY);
		if ((int)TreasureMapGenerator.leftRoomCount == 0)
		{
			return true;
		}
		TreasureMapGenerator.errorInfo = string.Format("leftRoom is not zero {0} seed {1} {2}", TreasureMapGenerator.leftRoomCount, TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
		return false;
	}

	// Token: 0x060175FC RID: 95740 RVA: 0x0072F0B0 File Offset: 0x0072D4B0
	private static void FixRoomLink()
	{
		for (int i = 0; i < (int)TreasureMapGenerator.MAX_ROW; i++)
		{
			for (int j = 0; j < (int)TreasureMapGenerator.MAX_COL; j++)
			{
				if (TreasureMapGenerator.roomTypes[i, j] != 0)
				{
					TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(i, j);
					int count = TreasureMapGenerator.linkInfo[i, j].GetCount();
					int num = (int)TreasureMapGenerator.doorCountTemplate[(int)posType];
					if (num >= 3 && count < 3)
					{
						for (int k = 0; k < 4; k++)
						{
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							if (!TreasureMapGenerator.GetLinkPos(i, j, ref num2, ref num3, posType, false, k, ref num4))
							{
								break;
							}
							if (TreasureMapGenerator.roomTypes[num2, num3] != 0)
							{
								if (TreasureMapGenerator.randomInst.InRange(0, 101) >= 90)
								{
									TreasureMapGenerator.AddLink(i, j, num2, num3);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060175FD RID: 95741 RVA: 0x0072F1AC File Offset: 0x0072D5AC
	public static bool CanTraverseAllRoom(int x, int y)
	{
		if ((int)TreasureMapGenerator.visitedRoomCount == (int)TreasureMapGenerator.roomCount)
		{
			return true;
		}
		TreasureMapGenerator.LinkInfo linkInfo = TreasureMapGenerator.linkInfo[x, y];
		for (int i = 0; i < linkInfo.GetCount(); i++)
		{
			TreasureMapGenerator.Direction2 link = linkInfo.GetLink(i);
			int num = (int)link.x * (int)TreasureMapGenerator.MAX_COL + (int)link.y;
			if (!TreasureMapGenerator.visitedRoom[num])
			{
				if (TreasureMapGenerator.roomTypes[(int)link.x, (int)link.y] != 0)
				{
					TreasureMapGenerator.LinkInfo linkInfo2 = TreasureMapGenerator.linkInfo[(int)link.x, (int)link.y];
					if (!linkInfo2.HasLink(x, y))
					{
						return false;
					}
					TreasureMapGenerator.visitedRoom[num] = true;
					TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
					bool flag = TreasureMapGenerator.CanTraverseAllRoom((int)link.x, (int)link.y);
					if (!flag)
					{
						return flag;
					}
				}
				else
				{
					TreasureMapGenerator.errorInfo = string.Format("Already Linked undefine room {0} {1} {2} {3} {4} {5}", new object[]
					{
						x,
						y,
						link.x,
						link.y,
						TreasureMapGenerator.randomInst.GetSeed(),
						TreasureMapGenerator.initRandomSeed
					});
				}
				if ((int)TreasureMapGenerator.visitedRoomCount == (int)TreasureMapGenerator.roomCount)
				{
					return true;
				}
			}
		}
		return true;
	}

	// Token: 0x060175FE RID: 95742 RVA: 0x0072F318 File Offset: 0x0072D718
	public static bool CanTraverseAllRoom_2(int x, int y)
	{
		if ((int)TreasureMapGenerator.visitedRoomCount == (int)TreasureMapGenerator.roomCount)
		{
			return true;
		}
		TreasureMapGenerator.travelRouter.Clear();
		TreasureMapGenerator.ClearRouterInfo();
		TreasureMapGenerator.RouterInfo routerInfo = TreasureMapGenerator.GenRouterInfo();
		routerInfo.pos.x = (sbyte)x;
		routerInfo.pos.y = (sbyte)y;
		TreasureMapGenerator.travelRouter.Push(routerInfo);
		while (TreasureMapGenerator.travelRouter.Count > 0)
		{
			TreasureMapGenerator.RouterInfo routerInfo2 = TreasureMapGenerator.travelRouter.Pop();
			x = (int)routerInfo2.pos.x;
			y = (int)routerInfo2.pos.y;
			TreasureMapGenerator.PushRouterInfo(routerInfo2);
			TreasureMapGenerator.LinkInfo linkInfo = TreasureMapGenerator.linkInfo[x, y];
			for (int i = 0; i < linkInfo.GetCount(); i++)
			{
				TreasureMapGenerator.Direction2 link = linkInfo.GetLink(i);
				int num = (int)link.x * (int)TreasureMapGenerator.MAX_COL + (int)link.y;
				if (!TreasureMapGenerator.visitedRoom[num])
				{
					if (TreasureMapGenerator.roomTypes[(int)link.x, (int)link.y] != 0)
					{
						TreasureMapGenerator.LinkInfo linkInfo2 = TreasureMapGenerator.linkInfo[(int)link.x, (int)link.y];
						if (!linkInfo2.HasLink(x, y))
						{
							return false;
						}
						TreasureMapGenerator.visitedRoomCount = (sbyte)((int)TreasureMapGenerator.visitedRoomCount + 1);
						TreasureMapGenerator.visitedRoom[num] = true;
						TreasureMapGenerator.RouterInfo routerInfo3 = TreasureMapGenerator.GenRouterInfo();
						routerInfo3.pos.x = link.x;
						routerInfo3.pos.y = link.y;
						TreasureMapGenerator.travelRouter.Push(routerInfo3);
					}
					else
					{
						TreasureMapGenerator.errorInfo = string.Format("Already Linked undefine room {0} {1} {2} {3} {4} {5}", new object[]
						{
							x,
							y,
							link.x,
							link.y,
							TreasureMapGenerator.randomInst.GetSeed(),
							TreasureMapGenerator.initRandomSeed
						});
					}
					if ((int)TreasureMapGenerator.visitedRoomCount == (int)TreasureMapGenerator.roomCount)
					{
						return true;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x060175FF RID: 95743 RVA: 0x0072F524 File Offset: 0x0072D924
	public static bool CheckAllRoomLinked()
	{
		Array.Clear(TreasureMapGenerator.visitedRoom, 0, TreasureMapGenerator.visitedRoom.Length);
		TreasureMapGenerator.visitedRoomCount = 1;
		TreasureMapGenerator.visitedRoom[(int)TreasureMapGenerator.bornPosX * (int)TreasureMapGenerator.MAX_COL + (int)TreasureMapGenerator.bornPosY] = true;
		TreasureMapGenerator.CanTraverseAllRoom_2((int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY);
		return (int)TreasureMapGenerator.visitedRoomCount == (int)TreasureMapGenerator.roomCount;
	}

	// Token: 0x06017600 RID: 95744 RVA: 0x0072F58C File Offset: 0x0072D98C
	private static int GenerateOneRoomType(TreasureMapGenerator.ROOM_TYPE type)
	{
		int num = TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.randRoomCount);
		int num2 = (int)TreasureMapGenerator.randRoomIndexSet[num];
		int num3 = num2 / (int)TreasureMapGenerator.MAX_COL;
		int num4 = num2 % (int)TreasureMapGenerator.MAX_COL;
		TreasureMapGenerator.roomTypes[num3, num4] = (byte)type;
		TreasureMapGenerator.randRoomIndexSet[num] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1];
		TreasureMapGenerator.randRoomCount = (sbyte)((int)TreasureMapGenerator.randRoomCount - 1);
		return num2;
	}

	// Token: 0x06017601 RID: 95745 RVA: 0x0072F5F8 File Offset: 0x0072D9F8
	private static bool CanSetDropItem(int randIndex, ref int x, ref int y)
	{
		int num = (int)TreasureMapGenerator.randRoomIndexSet[randIndex];
		x = num / (int)TreasureMapGenerator.MAX_COL;
		y = num % (int)TreasureMapGenerator.MAX_COL;
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType(x, y);
		bool flag = false;
		int num2 = 0;
		for (int i = 0; i < 4; i++)
		{
			int num3 = i;
			int num4 = 0;
			int num5 = 0;
			if (!TreasureMapGenerator.GetLinkPos(x, y, ref num4, ref num5, posType, false, i, ref num3))
			{
				break;
			}
			if (TreasureMapGenerator.roomTypes[num4, num5] == 6 && TreasureMapGenerator.linkInfo[num4, num5].HasLink(x, y))
			{
				flag = true;
				break;
			}
			if (TreasureMapGenerator.roomTypes[num4, num5] == 1)
			{
				num2++;
			}
		}
		return !flag && num2 > 0;
	}

	// Token: 0x06017602 RID: 95746 RVA: 0x0072F6CC File Offset: 0x0072DACC
	private static void SetDropItemRoom(int x, int y, int index)
	{
		TreasureMapGenerator.roomTypes[x, y] = 6;
		TreasureMapGenerator.randRoomIndexSet[index] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.canPutDropItemCount - 1];
		TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.canPutDropItemCount - 1] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1];
		TreasureMapGenerator.canPutDropItemCount = (sbyte)((int)TreasureMapGenerator.canPutDropItemCount - 1);
		TreasureMapGenerator.randRoomCount = (sbyte)((int)TreasureMapGenerator.randRoomCount - 1);
		TreasureMapGenerator.realGenDropItemCount = (sbyte)((int)TreasureMapGenerator.realGenDropItemCount + 1);
	}

	// Token: 0x06017603 RID: 95747 RVA: 0x0072F744 File Offset: 0x0072DB44
	private static bool RandConflictDropItemRoom()
	{
		int num = TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.canPutDropItemCount);
		int num2 = 0;
		int num3 = 0;
		bool flag = TreasureMapGenerator.CanSetDropItem(num, ref num2, ref num3);
		if (flag)
		{
			TreasureMapGenerator.SetDropItemRoom(num2, num3, num);
		}
		else
		{
			int num4 = num2 * (int)TreasureMapGenerator.MAX_COL + num3;
			int num5 = Array.IndexOf<byte>(TreasureMapGenerator.randRoomIndexSet, (byte)num4, 0, (int)TreasureMapGenerator.canPutDropItemCount);
			if (num5 < 0)
			{
				return false;
			}
			TreasureMapGenerator.randRoomIndexSet[num5] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.canPutDropItemCount - 1];
			TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.canPutDropItemCount - 1] = (byte)num4;
			TreasureMapGenerator.canPutDropItemCount = (sbyte)((int)TreasureMapGenerator.canPutDropItemCount - 1);
		}
		return flag;
	}

	// Token: 0x06017604 RID: 95748 RVA: 0x0072F7E8 File Offset: 0x0072DBE8
	private static void GenerateDropItemRoom()
	{
		TreasureMapGenerator.canPutDropItemCount = TreasureMapGenerator.randRoomCount;
		TreasureMapGenerator.realGenDropItemCount = 0;
		for (int i = 0; i < (int)TreasureMapGenerator.dropItemCount; i++)
		{
			int num = TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.canPutDropItemCount);
			int x = 0;
			int y = 0;
			bool flag = TreasureMapGenerator.CanSetDropItem(num, ref x, ref y);
			if (flag)
			{
				TreasureMapGenerator.SetDropItemRoom(x, y, num);
			}
			else
			{
				bool flag2 = false;
				for (int j = 0; j < 4; j++)
				{
					if (TreasureMapGenerator.RandConflictDropItemRoom())
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					for (int k = 0; k < (int)TreasureMapGenerator.canPutDropItemCount; k++)
					{
						if (TreasureMapGenerator.CanSetDropItem(k, ref x, ref y))
						{
							TreasureMapGenerator.SetDropItemRoom(x, y, k);
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x06017605 RID: 95749 RVA: 0x0072F8C0 File Offset: 0x0072DCC0
	private static bool IsRandRoomIndexSetSameValue()
	{
		for (int i = 0; i < (int)TreasureMapGenerator.randRoomCount; i++)
		{
			for (int j = i + 1; j < (int)TreasureMapGenerator.randRoomCount; j++)
			{
				if (TreasureMapGenerator.randRoomIndexSet[i] == TreasureMapGenerator.randRoomIndexSet[j])
				{
					Logger.LogErrorFormat("the same value {0} {1} {2} {3}", new object[]
					{
						i,
						j,
						TreasureMapGenerator.randRoomIndexSet[j],
						TreasureMapGenerator.randRoomCount
					});
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06017606 RID: 95750 RVA: 0x0072F954 File Offset: 0x0072DD54
	private static void GenerateRoomType()
	{
		TreasureMapGenerator.POS_TYPE posType = TreasureMapGenerator.GetPosType((int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY);
		int num = (int)TreasureMapGenerator.randRoomCount;
		for (int i = 0; i < 8; i++)
		{
			int num2 = (int)TreasureMapGenerator.bornPosX;
			int num3 = (int)TreasureMapGenerator.bornPosY;
			int num4 = i;
			if (!TreasureMapGenerator.GetCrossLinkPos((int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY, ref num2, ref num3, posType, false, i, ref num4))
			{
				break;
			}
			if (TreasureMapGenerator.roomTypes[num2, num3] != 0)
			{
				int num5 = num2 * (int)TreasureMapGenerator.MAX_COL + num3;
				int num6 = Array.IndexOf<byte>(TreasureMapGenerator.randRoomIndexSet, (byte)num5, 0, num);
				if (num6 != -1)
				{
					TreasureMapGenerator.randRoomIndexSet[num6] = TreasureMapGenerator.randRoomIndexSet[num - 1];
					TreasureMapGenerator.randRoomIndexSet[num - 1] = (byte)num5;
					num--;
				}
			}
		}
		int num7 = TreasureMapGenerator.randomInst.InRange(0, num);
		int num8 = (int)TreasureMapGenerator.randRoomIndexSet[num7];
		int num9 = num8 / (int)TreasureMapGenerator.MAX_COL;
		int num10 = num8 % (int)TreasureMapGenerator.MAX_COL;
		TreasureMapGenerator.roomTypes[num9, num10] = 2;
		TreasureMapGenerator.randRoomIndexSet[num7] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1];
		TreasureMapGenerator.randRoomCount = (sbyte)((int)TreasureMapGenerator.randRoomCount - 1);
		TreasureMapGenerator.GenerateOneRoomType(TreasureMapGenerator.ROOM_TYPE.KEY_ROOM);
		TreasureMapGenerator.GenerateOneRoomType(TreasureMapGenerator.ROOM_TYPE.MAP_ROOM);
		int num11 = num8 / (int)TreasureMapGenerator.MAX_COL;
		int num12 = num8 % (int)TreasureMapGenerator.MAX_COL;
		TreasureMapGenerator.POS_TYPE posType2 = TreasureMapGenerator.GetPosType(num11, num12);
		int num13 = 0;
		int num14 = num11;
		int num15 = num12;
		int num16 = 0;
		int num17 = 0;
		int num18 = 0;
		for (int j = 0; j < 4; j++)
		{
			num14 = num11;
			num15 = num12;
			int num19 = j;
			if (!TreasureMapGenerator.GetLinkPos(num11, num12, ref num14, ref num15, posType2, false, j, ref num19))
			{
				break;
			}
			if (TreasureMapGenerator.roomTypes[num14, num15] != 0 && TreasureMapGenerator.linkInfo[num11, num12].HasLink(num14, num15))
			{
				num13++;
				if (TreasureMapGenerator.roomTypes[num14, num15] == 1)
				{
					num18++;
					num16 = num14;
					num17 = num15;
				}
			}
		}
		if (num13 == 1 && num18 == 1)
		{
			int num20 = num16 * (int)TreasureMapGenerator.MAX_COL + num17;
			int num21 = Array.IndexOf<byte>(TreasureMapGenerator.randRoomIndexSet, (byte)num20, 0, (int)TreasureMapGenerator.randRoomCount);
			if (num21 >= 0)
			{
				byte b = TreasureMapGenerator.randRoomIndexSet[num21];
				TreasureMapGenerator.randRoomIndexSet[num21] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1];
				TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1] = b;
				int num22 = TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.randRoomCount - 1);
				int num23 = (int)TreasureMapGenerator.randRoomIndexSet[num22];
				int num24 = num23 % (int)TreasureMapGenerator.MAX_COL;
				int num25 = num23 / (int)TreasureMapGenerator.MAX_COL;
				TreasureMapGenerator.roomTypes[num25, num24] = 3;
				TreasureMapGenerator.randRoomIndexSet[num22] = TreasureMapGenerator.randRoomIndexSet[(int)TreasureMapGenerator.randRoomCount - 1];
				TreasureMapGenerator.randRoomCount = (sbyte)((int)TreasureMapGenerator.randRoomCount - 1);
			}
		}
		else
		{
			TreasureMapGenerator.GenerateOneRoomType(TreasureMapGenerator.ROOM_TYPE.END_ROOM);
		}
		TreasureMapGenerator.GenerateDropItemRoom();
		for (int k = 0; k < (int)TreasureMapGenerator.trialRoomCount; k++)
		{
			TreasureMapGenerator.GenerateOneRoomType(TreasureMapGenerator.ROOM_TYPE.TRIAL_ROOM);
		}
	}

	// Token: 0x06017607 RID: 95751 RVA: 0x0072FC6C File Offset: 0x0072E06C
	private static bool CheckAllRoomType()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		for (int i = 0; i < (int)TreasureMapGenerator.MAX_ROW; i++)
		{
			for (int j = 0; j < (int)TreasureMapGenerator.MAX_COL; j++)
			{
				byte b = TreasureMapGenerator.roomTypes[i, j];
				if (b != 0)
				{
					num++;
					if (b == 1)
					{
						num2++;
					}
					else if (b == 2)
					{
						num3++;
					}
					else if (b == 3)
					{
						num4++;
					}
					else if (b == 4)
					{
						num5++;
					}
					else if (b == 5)
					{
						num6++;
					}
					else if (b == 6)
					{
						num7++;
					}
					else if (b == 7)
					{
						num8++;
					}
					else if (b == 8)
					{
						num9++;
					}
				}
			}
		}
		if (num != (int)TreasureMapGenerator.roomCount)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} room count is not same {2} {3}!", new object[]
			{
				TreasureMapGenerator.randomInst.GetSeed(),
				TreasureMapGenerator.initRandomSeed,
				num,
				TreasureMapGenerator.roomCount
			});
			return false;
		}
		if (num9 != 1)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} born room count is not single !", TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
			return false;
		}
		if (num3 != 1)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} boss room count is not single !", TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
			return false;
		}
		if (num4 != 1)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} end room count is not single !", TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
			return false;
		}
		if (num5 != 1)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} key room count is not single !", TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
			return false;
		}
		if (num6 != 1)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} map room count is not single !", TreasureMapGenerator.randomInst.GetSeed(), TreasureMapGenerator.initRandomSeed);
			return false;
		}
		if (num7 != (int)TreasureMapGenerator.dropItemCount)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} drop room count is not same {2} {3}!", new object[]
			{
				TreasureMapGenerator.randomInst.GetSeed(),
				TreasureMapGenerator.initRandomSeed,
				num7,
				TreasureMapGenerator.dropItemCount
			});
			return false;
		}
		if (num8 != (int)TreasureMapGenerator.trialRoomCount)
		{
			TreasureMapGenerator.errorInfo = string.Format("seed {0} {1} Trial room count is not same {2} {3}!", new object[]
			{
				TreasureMapGenerator.randomInst.GetSeed(),
				TreasureMapGenerator.initRandomSeed,
				num8,
				TreasureMapGenerator.trialRoomCount
			});
			return false;
		}
		return true;
	}

	// Token: 0x06017608 RID: 95752 RVA: 0x0072FF78 File Offset: 0x0072E378
	private static bool BuildRoom(FrameRandomImp rand)
	{
		TreasureMapGenerator.randomInst = rand;
		TreasureMapGenerator.initRandomSeed = 0U;
		if (TreasureMapGenerator.randomInst == null)
		{
			Logger.LogErrorFormat("random Instance is not valid", new object[0]);
			return false;
		}
		TreasureMapGenerator.initRandomSeed = TreasureMapGenerator.randomInst.GetSeed();
		for (int i = 0; i < (int)TreasureMapGenerator.MAX_ROW; i++)
		{
			for (int j = 0; j < (int)TreasureMapGenerator.MAX_COL; j++)
			{
				TreasureMapGenerator.roomTypes[i, j] = 0;
				if (TreasureMapGenerator.linkInfo[i, j] == null)
				{
					TreasureMapGenerator.linkInfo[i, j] = new TreasureMapGenerator.LinkInfo();
				}
				else
				{
					TreasureMapGenerator.linkInfo[i, j].Reset();
				}
			}
		}
		if (TreasureMapGenerator.randRoomIndexSet == null)
		{
			TreasureMapGenerator.randRoomIndexSet = new byte[(int)(TreasureMapGenerator.MAX_ROW * TreasureMapGenerator.MAX_COL)];
		}
		TreasureMapGenerator.roomCount = (sbyte)TreasureMapGenerator.randomInst.InRange(36, 49);
		TreasureMapGenerator.randRoomCount = 0;
		Array.Clear(TreasureMapGenerator.randRoomIndexSet, 0, TreasureMapGenerator.randRoomIndexSet.Length);
		TreasureMapGenerator.bornPosX = (sbyte)TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.MAX_ROW);
		TreasureMapGenerator.bornPosY = (sbyte)TreasureMapGenerator.randomInst.InRange(0, (int)TreasureMapGenerator.MAX_COL);
		TreasureMapGenerator.roomTypes[(int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY] = 8;
		sbyte b = 1;
		TreasureMapGenerator.leftRoomCount = (sbyte)((int)TreasureMapGenerator.roomCount - (int)b);
		bool flag = TreasureMapGenerator.GenerateLinkRoom_2((int)TreasureMapGenerator.bornPosX, (int)TreasureMapGenerator.bornPosY);
		if ((int)TreasureMapGenerator.leftRoomCount > 0)
		{
		}
		if (!flag)
		{
			Logger.LogError(TreasureMapGenerator.errorInfo);
		}
		flag = TreasureMapGenerator.FixLeftRoom();
		bool flag2 = flag;
		if (!flag)
		{
			Logger.LogError(TreasureMapGenerator.errorInfo);
			TreasureMapGenerator.randomInst = null;
			return flag2;
		}
		flag = TreasureMapGenerator.CheckAllRoomLinked();
		TreasureMapGenerator.FixRoomLink();
		flag2 = (flag2 && flag);
		if (!flag)
		{
			Logger.LogError(TreasureMapGenerator.errorInfo);
		}
		TreasureMapGenerator.dropItemCount = (sbyte)TreasureMapGenerator.randomInst.InRange(3, 5);
		TreasureMapGenerator.trialRoomCount = (sbyte)TreasureMapGenerator.randomInst.InRange(5, 8);
		TreasureMapGenerator.GenerateRoomType();
		flag = TreasureMapGenerator.CheckAllRoomType();
		flag2 = (flag2 && flag);
		if (!flag)
		{
			Logger.LogError(TreasureMapGenerator.errorInfo);
		}
		TreasureMapGenerator.randomInst = null;
		return flag2;
	}

	// Token: 0x06017609 RID: 95753 RVA: 0x00730190 File Offset: 0x0072E590
	public static int BuildTreasureDungeonData(FrameRandomImp rand, out IDungeonData dungeonData)
	{
		dungeonData = null;
		if (!TreasureMapGenerator.BuildRoom(rand))
		{
			return -1;
		}
		int max_ROW = (int)TreasureMapGenerator.MAX_ROW;
		int max_COL = (int)TreasureMapGenerator.MAX_COL;
		DSceneDataConnect[] array = new DSceneDataConnect[(int)TreasureMapGenerator.roomCount];
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < (int)TreasureMapGenerator.MAX_ROW; i++)
		{
			for (int j = 0; j < (int)TreasureMapGenerator.MAX_COL; j++)
			{
				byte b = TreasureMapGenerator.roomTypes[i, j];
				if (TreasureMapGenerator.roomTypes[i, j] != 0)
				{
					DSceneDataConnect dsceneDataConnect = new DSceneDataConnect();
					for (int k = 0; k < 4; k++)
					{
						dsceneDataConnect.isconnect[k] = false;
					}
					if (b == 8)
					{
						num2 = num;
						dsceneDataConnect.isstart = true;
					}
					if (b == 3)
					{
						dsceneDataConnect.isboss = true;
					}
					dsceneDataConnect.treasureType = b;
					dsceneDataConnect.positionx = j;
					dsceneDataConnect.positiony = i;
					dsceneDataConnect.id = num;
					dsceneDataConnect.areaindex = num;
					array[num++] = dsceneDataConnect;
					List<string> treasureDungeonRandomLibrary = Singleton<TableManager>.GetInstance().GetTreasureDungeonRandomLibrary((int)b);
					if (treasureDungeonRandomLibrary == null || treasureDungeonRandomLibrary.Count <= 0)
					{
						Logger.LogErrorFormat("TreasureMap At {0} {1} Type {2} seed {3} not set room path!", new object[]
						{
							i,
							j,
							b,
							TreasureMapGenerator.initRandomSeed
						});
					}
					else
					{
						int index = rand.InRange(0, treasureDungeonRandomLibrary.Count);
						dsceneDataConnect.sceneareapath = treasureDungeonRandomLibrary[index];
					}
				}
			}
		}
		for (int l = 0; l < (int)TreasureMapGenerator.MAX_ROW; l++)
		{
			for (int m = 0; m < (int)TreasureMapGenerator.MAX_COL; m++)
			{
				TreasureMapGenerator.LinkInfo linkInfo = TreasureMapGenerator.linkInfo[l, m];
				if (linkInfo.GetCount() > 0)
				{
					foreach (DSceneDataConnect dsceneDataConnect2 in array)
					{
						if (linkInfo.HasLink(dsceneDataConnect2.GetPositionY(), dsceneDataConnect2.GetPositionX()))
						{
							if (dsceneDataConnect2.GetPositionY() - l == 0)
							{
								if (dsceneDataConnect2.GetPositionX() - m == 1)
								{
									dsceneDataConnect2.isconnect[0] = true;
								}
								if (dsceneDataConnect2.GetPositionX() - m == -1)
								{
									dsceneDataConnect2.isconnect[2] = true;
								}
							}
							if (dsceneDataConnect2.GetPositionX() - m == 0)
							{
								if (dsceneDataConnect2.GetPositionY() - l == 1)
								{
									dsceneDataConnect2.isconnect[1] = true;
								}
								if (dsceneDataConnect2.GetPositionY() - l == -1)
								{
									dsceneDataConnect2.isconnect[3] = true;
								}
							}
						}
					}
				}
			}
		}
		DDungeonData ddungeonData = ScriptableObject.CreateInstance<DDungeonData>();
		dungeonData = ddungeonData;
		if (ddungeonData == null)
		{
			return -1;
		}
		ddungeonData.height = max_ROW;
		ddungeonData.weidth = max_COL;
		ddungeonData.areaconnectlist = array;
		ddungeonData.startindex = num2;
		return num2;
	}

	// Token: 0x04010C7E RID: 68734
	private static readonly byte[] doorCountTemplate = new byte[]
	{
		2,
		3,
		2,
		2,
		3,
		2,
		3,
		3,
		4
	};

	// Token: 0x04010C7F RID: 68735
	public static readonly Dictionary<int, List<TreasureMapGenerator.Direction2>> doorDir = new Dictionary<int, List<TreasureMapGenerator.Direction2>>
	{
		{
			0,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				}
			}
		},
		{
			1,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				}
			}
		},
		{
			2,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				}
			}
		},
		{
			3,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				}
			}
		},
		{
			4,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				}
			}
		},
		{
			5,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				}
			}
		},
		{
			6,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				}
			}
		},
		{
			7,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				}
			}
		},
		{
			8,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				}
			}
		}
	};

	// Token: 0x04010C80 RID: 68736
	public static readonly Dictionary<int, List<TreasureMapGenerator.Direction2>> doorCrossDir = new Dictionary<int, List<TreasureMapGenerator.Direction2>>
	{
		{
			0,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 1
				}
			}
		},
		{
			1,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 1
				}
			}
		},
		{
			2,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 1
				}
			}
		},
		{
			3,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = -1
				}
			}
		},
		{
			4,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = -1
				}
			}
		},
		{
			5,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = -1
				}
			}
		},
		{
			6,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 1
				}
			}
		},
		{
			7,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 1
				}
			}
		},
		{
			8,
			new List<TreasureMapGenerator.Direction2>
			{
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 0
				},
				new TreasureMapGenerator.Direction2
				{
					x = 0,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = -1,
					y = 1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = -1
				},
				new TreasureMapGenerator.Direction2
				{
					x = 1,
					y = 1
				}
			}
		}
	};

	// Token: 0x04010C81 RID: 68737
	private static TreasureMapGenerator.TMStack<TreasureMapGenerator.RouterInfo> travelRouter = new TreasureMapGenerator.TMStack<TreasureMapGenerator.RouterInfo>(20);

	// Token: 0x04010C82 RID: 68738
	private static TreasureMapGenerator.RouterInfo[] routerBuffer = new TreasureMapGenerator.RouterInfo[50];

	// Token: 0x04010C83 RID: 68739
	private static int routerUsedCount = 0;

	// Token: 0x04010C84 RID: 68740
	private static bool outOfRouterBuffer = false;

	// Token: 0x04010C85 RID: 68741
	public static readonly byte MAX_ROW = 6;

	// Token: 0x04010C86 RID: 68742
	public static readonly byte MAX_COL = 8;

	// Token: 0x04010C87 RID: 68743
	private static byte[,] roomTypes = new byte[(int)TreasureMapGenerator.MAX_ROW, (int)TreasureMapGenerator.MAX_COL];

	// Token: 0x04010C88 RID: 68744
	private static TreasureMapGenerator.LinkInfo[,] linkInfo = new TreasureMapGenerator.LinkInfo[(int)TreasureMapGenerator.MAX_ROW, (int)TreasureMapGenerator.MAX_COL];

	// Token: 0x04010C89 RID: 68745
	private static bool[] visitedRoom = new bool[(int)(TreasureMapGenerator.MAX_ROW * TreasureMapGenerator.MAX_COL)];

	// Token: 0x04010C8A RID: 68746
	private static sbyte visitedRoomCount = 0;

	// Token: 0x04010C8B RID: 68747
	private static sbyte roomCount = 30;

	// Token: 0x04010C8C RID: 68748
	private static sbyte leftRoomCount = 30;

	// Token: 0x04010C8D RID: 68749
	private static sbyte bornPosX = 0;

	// Token: 0x04010C8E RID: 68750
	private static sbyte bornPosY = 0;

	// Token: 0x04010C8F RID: 68751
	private static sbyte dropItemCount = 4;

	// Token: 0x04010C90 RID: 68752
	private static sbyte canPutDropItemCount = 0;

	// Token: 0x04010C91 RID: 68753
	private static sbyte realGenDropItemCount = 0;

	// Token: 0x04010C92 RID: 68754
	private static sbyte trialRoomCount = 7;

	// Token: 0x04010C93 RID: 68755
	private static byte[] randRoomIndexSet = null;

	// Token: 0x04010C94 RID: 68756
	private static sbyte randRoomCount = 0;

	// Token: 0x04010C95 RID: 68757
	private static string errorInfo = string.Empty;

	// Token: 0x04010C96 RID: 68758
	private static FrameRandomImp randomInst = null;

	// Token: 0x04010C97 RID: 68759
	private static uint initRandomSeed = 0U;

	// Token: 0x020041FB RID: 16891
	public enum POS_TYPE
	{
		// Token: 0x04010C99 RID: 68761
		LEFT_TOP_CORNER,
		// Token: 0x04010C9A RID: 68762
		LEFT_CORNER,
		// Token: 0x04010C9B RID: 68763
		LEFT_BOTTOM_CORNER,
		// Token: 0x04010C9C RID: 68764
		RIGHT_TOP_CORNER,
		// Token: 0x04010C9D RID: 68765
		RIGHT_CORNER,
		// Token: 0x04010C9E RID: 68766
		RIGHT_BOTTOM_CORNER,
		// Token: 0x04010C9F RID: 68767
		TOP_CORNER,
		// Token: 0x04010CA0 RID: 68768
		BOTTOM_CORNER,
		// Token: 0x04010CA1 RID: 68769
		NORMAL,
		// Token: 0x04010CA2 RID: 68770
		MAX_COUNT
	}

	// Token: 0x020041FC RID: 16892
	public enum ROOM_TYPE
	{
		// Token: 0x04010CA4 RID: 68772
		NONE,
		// Token: 0x04010CA5 RID: 68773
		NORMAL_ROOM,
		// Token: 0x04010CA6 RID: 68774
		BOSS_ROOM,
		// Token: 0x04010CA7 RID: 68775
		END_ROOM,
		// Token: 0x04010CA8 RID: 68776
		KEY_ROOM,
		// Token: 0x04010CA9 RID: 68777
		MAP_ROOM,
		// Token: 0x04010CAA RID: 68778
		DROPITEM_ROOM,
		// Token: 0x04010CAB RID: 68779
		TRIAL_ROOM,
		// Token: 0x04010CAC RID: 68780
		BORN_ROOM,
		// Token: 0x04010CAD RID: 68781
		MAX_COUNT
	}

	// Token: 0x020041FD RID: 16893
	public class Direction2
	{
		// Token: 0x04010CAE RID: 68782
		public sbyte x;

		// Token: 0x04010CAF RID: 68783
		public sbyte y;
	}

	// Token: 0x020041FE RID: 16894
	private class RouterInfo
	{
		// Token: 0x04010CB0 RID: 68784
		public TreasureMapGenerator.Direction2 pos = new TreasureMapGenerator.Direction2();

		// Token: 0x04010CB1 RID: 68785
		public byte randDoorCount;

		// Token: 0x04010CB2 RID: 68786
		public byte startIndex;

		// Token: 0x04010CB3 RID: 68787
		public byte conflictIndex;

		// Token: 0x04010CB4 RID: 68788
		public byte curDoorCount;
	}

	// Token: 0x020041FF RID: 16895
	public class TMStack<T> where T : class
	{
		// Token: 0x0601760D RID: 95757 RVA: 0x00730D62 File Offset: 0x0072F162
		public TMStack(int capacity)
		{
			this._array = new T[capacity];
		}

		// Token: 0x0601760E RID: 95758 RVA: 0x00730D78 File Offset: 0x0072F178
		public TMStack(T[] array)
		{
			this._array = new T[array.Length];
			foreach (T item in array)
			{
				this.Push(item);
			}
		}

		// Token: 0x0601760F RID: 95759 RVA: 0x00730DC0 File Offset: 0x0072F1C0
		public void Push(T item)
		{
			if (this._array.Length <= this._count)
			{
				Array.Resize<T>(ref this._array, this._count * 2);
			}
			this._array[this._count] = item;
			this._count++;
		}

		// Token: 0x06017610 RID: 95760 RVA: 0x00730E13 File Offset: 0x0072F213
		public void Clear()
		{
			this._count = 0;
		}

		// Token: 0x06017611 RID: 95761 RVA: 0x00730E1C File Offset: 0x0072F21C
		public bool Contains(T item)
		{
			if (this._array != null)
			{
				for (int i = 0; i < this._count; i++)
				{
					if (item == this._array[i])
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06017612 RID: 95762 RVA: 0x00730E6A File Offset: 0x0072F26A
		public T Peek()
		{
			if (this._count == 0)
			{
				return (T)((object)null);
			}
			return this._array[this._count - 1];
		}

		// Token: 0x06017613 RID: 95763 RVA: 0x00730E94 File Offset: 0x0072F294
		public T Pop()
		{
			if (this._count == 0)
			{
				return (T)((object)null);
			}
			if (this._count == 1)
			{
				this._count = 0;
				return this._array[0];
			}
			T result = this._array[this._count - 1];
			this._count--;
			return result;
		}

		// Token: 0x17001FDE RID: 8158
		// (get) Token: 0x06017614 RID: 95764 RVA: 0x00730EF6 File Offset: 0x0072F2F6
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x04010CB5 RID: 68789
		private T[] _array;

		// Token: 0x04010CB6 RID: 68790
		private int _count;
	}

	// Token: 0x02004200 RID: 16896
	public class LinkInfo
	{
		// Token: 0x06017616 RID: 95766 RVA: 0x00730F34 File Offset: 0x0072F334
		public bool AddLink(int posX, int posY)
		{
			if (this.linkCount >= 4)
			{
				return false;
			}
			if (this.HasLink(posX, posY))
			{
				return false;
			}
			this.linkPos[this.linkCount].x = (sbyte)posX;
			this.linkPos[this.linkCount].y = (sbyte)posY;
			this.linkCount++;
			return true;
		}

		// Token: 0x06017617 RID: 95767 RVA: 0x00730F98 File Offset: 0x0072F398
		public bool HasLink(int posX, int posY)
		{
			for (int i = 0; i < this.linkCount; i++)
			{
				if ((int)this.linkPos[i].x == posX && (int)this.linkPos[i].y == posY)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06017618 RID: 95768 RVA: 0x00730FE7 File Offset: 0x0072F3E7
		public void Reset()
		{
			this.linkCount = 0;
		}

		// Token: 0x06017619 RID: 95769 RVA: 0x00730FF0 File Offset: 0x0072F3F0
		public int GetCount()
		{
			return this.linkCount;
		}

		// Token: 0x0601761A RID: 95770 RVA: 0x00730FF8 File Offset: 0x0072F3F8
		public TreasureMapGenerator.Direction2 GetLink(int index)
		{
			if (index < 0 || index >= this.linkCount)
			{
				return null;
			}
			return this.linkPos[index];
		}

		// Token: 0x04010CB7 RID: 68791
		private TreasureMapGenerator.Direction2[] linkPos = new TreasureMapGenerator.Direction2[]
		{
			new TreasureMapGenerator.Direction2(),
			new TreasureMapGenerator.Direction2(),
			new TreasureMapGenerator.Direction2(),
			new TreasureMapGenerator.Direction2()
		};

		// Token: 0x04010CB8 RID: 68792
		private int linkCount;
	}
}

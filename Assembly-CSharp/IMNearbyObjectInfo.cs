using System;
using System.Collections.Generic;
using YIMEngine;

// Token: 0x02004ABE RID: 19134
public class IMNearbyObjectInfo
{
	// Token: 0x0601BC61 RID: 113761 RVA: 0x0088371A File Offset: 0x00881B1A
	public IMNearbyObjectInfo(List<RelativeLocation> neighbourList, uint startDistance, uint endDistance)
	{
		this._neighbourList = neighbourList;
		this._startDistance = startDistance;
		this._endDistance = endDistance;
	}

	// Token: 0x1700258D RID: 9613
	// (get) Token: 0x0601BC62 RID: 113762 RVA: 0x00883737 File Offset: 0x00881B37
	public List<RelativeLocation> NeighbourList
	{
		get
		{
			return this._neighbourList;
		}
	}

	// Token: 0x1700258E RID: 9614
	// (get) Token: 0x0601BC63 RID: 113763 RVA: 0x0088373F File Offset: 0x00881B3F
	public uint StartDistance
	{
		get
		{
			return this._startDistance;
		}
	}

	// Token: 0x1700258F RID: 9615
	// (get) Token: 0x0601BC64 RID: 113764 RVA: 0x00883747 File Offset: 0x00881B47
	public uint EndDistance
	{
		get
		{
			return this._endDistance;
		}
	}

	// Token: 0x040135C9 RID: 79305
	private List<RelativeLocation> _neighbourList;

	// Token: 0x040135CA RID: 79306
	private uint _startDistance;

	// Token: 0x040135CB RID: 79307
	private uint _endDistance;
}

using System;
using System.Collections.Generic;
using FBDungeonData;

// Token: 0x02004B4F RID: 19279
public class BattleDungeonData : IDungeonData
{
	// Token: 0x0601C543 RID: 116035 RVA: 0x0089BD7F File Offset: 0x0089A17F
	public BattleDungeonData(FBDungeonData.DDungeonData data)
	{
		this.mData = data;
		this.mName = this.mData.Name;
		this._initConnectData();
	}

	// Token: 0x0601C544 RID: 116036 RVA: 0x0089BDB0 File Offset: 0x0089A1B0
	private void _initConnectData()
	{
		for (int i = 0; i < this.mData.AreaconnectlistLength; i++)
		{
			this.mAreaConnect.Add(new BattleDungeonConnectData(this.mData.GetAreaconnectlist(i)));
		}
	}

	// Token: 0x0601C545 RID: 116037 RVA: 0x0089BDF5 File Offset: 0x0089A1F5
	public IDungeonConnectData GetAreaConnectList(int i)
	{
		if (this.mAreaConnect == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mAreaConnect.Count <= i)
		{
			return null;
		}
		return this.mAreaConnect[i];
	}

	// Token: 0x0601C546 RID: 116038 RVA: 0x0089BE2C File Offset: 0x0089A22C
	public int GetAreaConnectListLength()
	{
		return this.mData.AreaconnectlistLength;
	}

	// Token: 0x0601C547 RID: 116039 RVA: 0x0089BE3C File Offset: 0x0089A23C
	public int GetConnectStatus(IDungeonConnectData from, IDungeonConnectData to)
	{
		if (from == null || to == null)
		{
			return -1;
		}
		for (int i = 0; i < from.GetIsConnectLength(); i++)
		{
			if (from.GetIsConnect(i))
			{
				IDungeonConnectData sideByType = this.GetSideByType(from, (TransportDoorType)i);
				if (sideByType.GetAreaIndex() == to.GetAreaIndex() && sideByType.GetPositionX() == to.GetPositionX() && sideByType.GetPositionY() == to.GetPositionY())
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x0601C548 RID: 116040 RVA: 0x0089BEB9 File Offset: 0x0089A2B9
	public int GetHeight()
	{
		return this.mData.Height;
	}

	// Token: 0x0601C549 RID: 116041 RVA: 0x0089BEC6 File Offset: 0x0089A2C6
	public string GetName()
	{
		return this.mName;
	}

	// Token: 0x0601C54A RID: 116042 RVA: 0x0089BED0 File Offset: 0x0089A2D0
	public IDungeonConnectData GetSideByType(IDungeonConnectData condata, TransportDoorType fromtype)
	{
		int num = condata.GetPositionX();
		int num2 = condata.GetPositionY();
		switch (fromtype)
		{
		case TransportDoorType.Left:
			num--;
			break;
		case TransportDoorType.Top:
			num2--;
			break;
		case TransportDoorType.Right:
			num++;
			break;
		case TransportDoorType.Buttom:
			num2++;
			break;
		}
		for (int i = 0; i < this.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.GetAreaConnectList(i);
			if (areaConnectList.GetPositionX() == num && areaConnectList.GetPositionY() == num2)
			{
				return areaConnectList;
			}
		}
		return null;
	}

	// Token: 0x0601C54B RID: 116043 RVA: 0x0089BF64 File Offset: 0x0089A364
	public IDungeonConnectData GetSideByType(int idx, TransportDoorType fromtype)
	{
		if (idx < 0 || idx >= this.GetAreaConnectListLength())
		{
			Logger.LogError("areaidx out of range");
			return null;
		}
		return this.GetSideByType(this.GetAreaConnectList(idx), fromtype);
	}

	// Token: 0x0601C54C RID: 116044 RVA: 0x0089BF94 File Offset: 0x0089A394
	public void GetSideByType(IDungeonConnectData condata, TransportDoorType fromtype, out int index)
	{
		index = -1;
		int num = condata.GetPositionX();
		int num2 = condata.GetPositionY();
		switch (fromtype)
		{
		case TransportDoorType.Left:
			num--;
			break;
		case TransportDoorType.Top:
			num2--;
			break;
		case TransportDoorType.Right:
			num++;
			break;
		case TransportDoorType.Buttom:
			num2++;
			break;
		}
		for (int i = 0; i < this.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.GetAreaConnectList(i);
			if (areaConnectList.GetPositionX() == num && areaConnectList.GetPositionY() == num2)
			{
				index = i;
				return;
			}
		}
	}

	// Token: 0x0601C54D RID: 116045 RVA: 0x0089C02C File Offset: 0x0089A42C
	public void GetSideByType(int x, int y, TransportDoorType fromtype, out int index)
	{
		index = -1;
		switch (fromtype)
		{
		case TransportDoorType.Left:
			x--;
			break;
		case TransportDoorType.Top:
			y--;
			break;
		case TransportDoorType.Right:
			x++;
			break;
		case TransportDoorType.Buttom:
			y++;
			break;
		}
		for (int i = 0; i < this.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.GetAreaConnectList(i);
			if (areaConnectList.GetPositionX() == x && areaConnectList.GetPositionY() == y)
			{
				index = i;
				return;
			}
		}
	}

	// Token: 0x0601C54E RID: 116046 RVA: 0x0089C0BC File Offset: 0x0089A4BC
	public int GetStartIndex()
	{
		return this.mData.Startindex;
	}

	// Token: 0x0601C54F RID: 116047 RVA: 0x0089C0C9 File Offset: 0x0089A4C9
	public int GetWeidth()
	{
		return this.mData.Weidth;
	}

	// Token: 0x0601C550 RID: 116048 RVA: 0x0089C0D6 File Offset: 0x0089A4D6
	public void SetName(string name)
	{
		this.mName = name;
	}

	// Token: 0x040137E8 RID: 79848
	private FBDungeonData.DDungeonData mData;

	// Token: 0x040137E9 RID: 79849
	private string mName;

	// Token: 0x040137EA RID: 79850
	private List<IDungeonConnectData> mAreaConnect = new List<IDungeonConnectData>();
}

using System;
using UnityEngine;

// Token: 0x02004B5C RID: 19292
public class DDungeonData : ScriptableObject, IDungeonData
{
	// Token: 0x0601C5F6 RID: 116214 RVA: 0x0089D477 File Offset: 0x0089B877
	public string GetName()
	{
		return this.name;
	}

	// Token: 0x0601C5F7 RID: 116215 RVA: 0x0089D47F File Offset: 0x0089B87F
	public int GetHeight()
	{
		return this.height;
	}

	// Token: 0x0601C5F8 RID: 116216 RVA: 0x0089D487 File Offset: 0x0089B887
	public int GetWeidth()
	{
		return this.weidth;
	}

	// Token: 0x0601C5F9 RID: 116217 RVA: 0x0089D48F File Offset: 0x0089B88F
	public int GetStartIndex()
	{
		return this.startindex;
	}

	// Token: 0x0601C5FA RID: 116218 RVA: 0x0089D497 File Offset: 0x0089B897
	public int GetAreaConnectListLength()
	{
		if (this.areaconnectlist == null)
		{
			return 0;
		}
		return this.areaconnectlist.Length;
	}

	// Token: 0x0601C5FB RID: 116219 RVA: 0x0089D4AE File Offset: 0x0089B8AE
	public IDungeonConnectData GetAreaConnectList(int i)
	{
		if (this.areaconnectlist == null)
		{
			return null;
		}
		if (i < 0 || i >= this.GetAreaConnectListLength())
		{
			return null;
		}
		return this.areaconnectlist[i];
	}

	// Token: 0x0601C5FC RID: 116220 RVA: 0x0089D4DA File Offset: 0x0089B8DA
	IDungeonConnectData IDungeonData.GetSideByType(int idx, TransportDoorType fromtype)
	{
		if (idx < 0 || idx > this.areaconnectlist.Length)
		{
			Logger.LogError("areaidx out of range");
			return null;
		}
		return this.GetSideByType(this.areaconnectlist[idx], fromtype);
	}

	// Token: 0x0601C5FD RID: 116221 RVA: 0x0089D50C File Offset: 0x0089B90C
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
		for (int i = 0; i < this.areaconnectlist.Length; i++)
		{
			DSceneDataConnect dsceneDataConnect = this.areaconnectlist[i];
			if (dsceneDataConnect.positionx == num && dsceneDataConnect.positiony == num2)
			{
				index = i;
				return;
			}
		}
	}

	// Token: 0x0601C5FE RID: 116222 RVA: 0x0089D5A8 File Offset: 0x0089B9A8
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

	// Token: 0x0601C5FF RID: 116223 RVA: 0x0089D628 File Offset: 0x0089BA28
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

	// Token: 0x0601C600 RID: 116224 RVA: 0x0089D6BC File Offset: 0x0089BABC
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

	// Token: 0x0601C601 RID: 116225 RVA: 0x0089D74C File Offset: 0x0089BB4C
	public void SetName(string name)
	{
		this.name = name;
	}

	// Token: 0x04013818 RID: 79896
	[NonSerialized]
	public string name = string.Empty;

	// Token: 0x04013819 RID: 79897
	public int height = 3;

	// Token: 0x0401381A RID: 79898
	public int weidth = 3;

	// Token: 0x0401381B RID: 79899
	public int startindex;

	// Token: 0x0401381C RID: 79900
	public DSceneDataConnect[] areaconnectlist = new DSceneDataConnect[0];
}

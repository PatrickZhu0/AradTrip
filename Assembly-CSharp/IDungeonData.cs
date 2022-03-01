using System;

// Token: 0x02004B7B RID: 19323
public interface IDungeonData
{
	// Token: 0x0601C6C6 RID: 116422
	string GetName();

	// Token: 0x0601C6C7 RID: 116423
	void SetName(string name);

	// Token: 0x0601C6C8 RID: 116424
	int GetHeight();

	// Token: 0x0601C6C9 RID: 116425
	int GetWeidth();

	// Token: 0x0601C6CA RID: 116426
	int GetStartIndex();

	// Token: 0x0601C6CB RID: 116427
	int GetAreaConnectListLength();

	// Token: 0x0601C6CC RID: 116428
	IDungeonConnectData GetAreaConnectList(int i);

	// Token: 0x0601C6CD RID: 116429
	IDungeonConnectData GetSideByType(int idx, TransportDoorType fromtype);

	// Token: 0x0601C6CE RID: 116430
	void GetSideByType(IDungeonConnectData condata, TransportDoorType fromtype, out int index);

	// Token: 0x0601C6CF RID: 116431
	void GetSideByType(int x, int y, TransportDoorType fromtype, out int index);

	// Token: 0x0601C6D0 RID: 116432
	int GetConnectStatus(IDungeonConnectData from, IDungeonConnectData to);

	// Token: 0x0601C6D1 RID: 116433
	IDungeonConnectData GetSideByType(IDungeonConnectData condata, TransportDoorType fromtype);
}

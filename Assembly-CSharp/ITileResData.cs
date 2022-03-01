using System;

// Token: 0x02004BE1 RID: 19425
public interface ITileResData
{
	// Token: 0x0601C793 RID: 116627
	int GetID();

	// Token: 0x0601C794 RID: 116628
	string GetName();

	// Token: 0x0601C795 RID: 116629
	string GetPrefabPath();

	// Token: 0x0601C796 RID: 116630
	ETeamTileLayer GetTileLayer();

	// Token: 0x0601C797 RID: 116631
	ETeamTileType GetTileType();

	// Token: 0x0601C798 RID: 116632
	ETileLinkedType GetTileLinkedType();

	// Token: 0x0601C799 RID: 116633
	int GetDataLength();

	// Token: 0x0601C79A RID: 116634
	int GetDataAt(int idx);
}

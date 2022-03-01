using System;

// Token: 0x02004B83 RID: 19331
public interface ISceneMonsterInfoData
{
	// Token: 0x0601C72B RID: 116523
	ISceneEntityInfoData GetEntityInfo();

	// Token: 0x0601C72C RID: 116524
	DMonsterInfo.MonsterSwapType GetSwapType();

	// Token: 0x0601C72D RID: 116525
	DMonsterInfo.FaceType GetFaceType();

	// Token: 0x0601C72E RID: 116526
	int GetSwapNum();

	// Token: 0x0601C72F RID: 116527
	int GetSwapDelay();

	// Token: 0x0601C730 RID: 116528
	int GetFlushGroupID();

	// Token: 0x0601C731 RID: 116529
	DMonsterInfo.FlowRegionType GetFlowRegionType();

	// Token: 0x0601C732 RID: 116530
	ISceneRegionInfoData GetRegionInfo();

	// Token: 0x0601C733 RID: 116531
	ISceneDestructibleInfoData GetDestructInfo();

	// Token: 0x0601C734 RID: 116532
	void SetMonsterID(int id);

	// Token: 0x0601C735 RID: 116533
	int GetMonsterID();

	// Token: 0x0601C736 RID: 116534
	int GetMonsterLevel();

	// Token: 0x0601C737 RID: 116535
	int GetMonsterTypeID();

	// Token: 0x0601C738 RID: 116536
	int GetMonsterDiffcute();
}

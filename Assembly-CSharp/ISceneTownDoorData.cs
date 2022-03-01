using System;
using UnityEngine;

// Token: 0x02004B7E RID: 19326
public interface ISceneTownDoorData
{
	// Token: 0x0601C70D RID: 116493
	ISceneRegionInfoData GetRegionInfo();

	// Token: 0x0601C70E RID: 116494
	int GetSceneID();

	// Token: 0x0601C70F RID: 116495
	int GetDoorID();

	// Token: 0x0601C710 RID: 116496
	Vector3 GetBirthPos();

	// Token: 0x0601C711 RID: 116497
	Vector3 GetLocalBirthPos();

	// Token: 0x0601C712 RID: 116498
	int GetTargetSceneID();

	// Token: 0x0601C713 RID: 116499
	int GetTargetDoorID();

	// Token: 0x0601C714 RID: 116500
	DoorTargetType GetDoorTargetType();
}

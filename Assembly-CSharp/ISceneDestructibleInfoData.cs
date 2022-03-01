using System;
using UnityEngine;

// Token: 0x02004B81 RID: 19329
public interface ISceneDestructibleInfoData
{
	// Token: 0x0601C724 RID: 116516
	ISceneEntityInfoData GetEntityInfo();

	// Token: 0x0601C725 RID: 116517
	Quaternion GetRotation();

	// Token: 0x0601C726 RID: 116518
	int GetLevel();

	// Token: 0x0601C727 RID: 116519
	int GetFlushGroupID();
}

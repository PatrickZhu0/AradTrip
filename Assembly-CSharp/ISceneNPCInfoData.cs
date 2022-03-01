using System;
using UnityEngine;

// Token: 0x02004B84 RID: 19332
public interface ISceneNPCInfoData
{
	// Token: 0x0601C739 RID: 116537
	ISceneEntityInfoData GetEntityInfo();

	// Token: 0x0601C73A RID: 116538
	Quaternion GetRotation();

	// Token: 0x0601C73B RID: 116539
	Vector2 GetMinFindRange();

	// Token: 0x0601C73C RID: 116540
	Vector2 GetMaxFindRange();
}

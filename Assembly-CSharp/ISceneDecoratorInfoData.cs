using System;
using UnityEngine;

// Token: 0x02004B82 RID: 19330
public interface ISceneDecoratorInfoData
{
	// Token: 0x0601C728 RID: 116520
	ISceneEntityInfoData GetEntityInfo();

	// Token: 0x0601C729 RID: 116521
	Vector3 GetLocalScale();

	// Token: 0x0601C72A RID: 116522
	Quaternion GetRotation();
}

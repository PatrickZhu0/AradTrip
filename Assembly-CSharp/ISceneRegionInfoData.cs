using System;
using UnityEngine;

// Token: 0x02004B80 RID: 19328
public interface ISceneRegionInfoData
{
	// Token: 0x0601C71D RID: 116509
	ISceneEntityInfoData GetEntityInfo();

	// Token: 0x0601C71E RID: 116510
	DRegionInfo.RegionType GetRegiontype();

	// Token: 0x0601C71F RID: 116511
	void SetRegiontype(DRegionInfo.RegionType type);

	// Token: 0x0601C720 RID: 116512
	Vector2 GetRect();

	// Token: 0x0601C721 RID: 116513
	float GetRadius();

	// Token: 0x0601C722 RID: 116514
	void SetRadius(float r);

	// Token: 0x0601C723 RID: 116515
	Quaternion GetRotation();
}

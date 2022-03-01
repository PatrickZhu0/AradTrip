using System;
using UnityEngine;

// Token: 0x02004B85 RID: 19333
public interface ISceneEntityInfoData
{
	// Token: 0x0601C73D RID: 116541
	int GetGlobalid();

	// Token: 0x0601C73E RID: 116542
	int GetResid();

	// Token: 0x0601C73F RID: 116543
	string GetName();

	// Token: 0x0601C740 RID: 116544
	string GetPath();

	// Token: 0x0601C741 RID: 116545
	string GetDescription();

	// Token: 0x0601C742 RID: 116546
	DEntityType GetType();

	// Token: 0x0601C743 RID: 116547
	string GetTypename();

	// Token: 0x0601C744 RID: 116548
	Vector3 GetPosition();

	// Token: 0x0601C745 RID: 116549
	float GetScale();

	// Token: 0x0601C746 RID: 116550
	Color GetColor();

	// Token: 0x0601C747 RID: 116551
	string GetModelPathByResID();
}

using System;
using UnityEngine;

// Token: 0x02000066 RID: 102
[Serializable]
public class BangFullScreenParam
{
	// Token: 0x0400022D RID: 557
	public CameraAspectAdjust.eScreenType screenType;

	// Token: 0x0400022E RID: 558
	public Vector3 landLeftOffset;

	// Token: 0x0400022F RID: 559
	public Vector3 landRightOffset;

	// Token: 0x04000230 RID: 560
	[Header("对比iPhoneX的刘海的叠加偏移值,对iPhoneX无效")]
	public Vector3 bangOffset;
}

using System;
using System.ComponentModel;

// Token: 0x02004BBD RID: 19389
public enum DModifyXBackward
{
	// Token: 0x04013A3C RID: 80444
	[Description("继续朝着当前方向前进")]
	NONE = 1,
	// Token: 0x04013A3D RID: 80445
	[Description("停止")]
	STOP,
	// Token: 0x04013A3E RID: 80446
	[Description("朝着反方向移动 ")]
	BACKMOVE
}

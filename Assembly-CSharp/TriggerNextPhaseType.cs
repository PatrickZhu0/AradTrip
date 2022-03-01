using System;
using System.ComponentModel;

// Token: 0x02004BB1 RID: 19377
public enum TriggerNextPhaseType
{
	// Token: 0x040139B7 RID: 80311
	[Description("无")]
	NONE,
	// Token: 0x040139B8 RID: 80312
	[Description("上升到最高")]
	UPSTOP,
	// Token: 0x040139B9 RID: 80313
	[Description("接触地面")]
	TOUCHGROUND,
	// Token: 0x040139BA RID: 80314
	[Description("松开技能按钮")]
	RELEASE_BUTTON,
	// Token: 0x040139BB RID: 80315
	[Description("再次点击技能按钮")]
	PRESS_AGAIN
}

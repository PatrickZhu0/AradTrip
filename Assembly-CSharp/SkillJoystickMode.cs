using System;
using System.ComponentModel;

// Token: 0x020041BB RID: 16827
public enum SkillJoystickMode
{
	// Token: 0x04010B4A RID: 68426
	[Description("默认")]
	NONE,
	// Token: 0x04010B4B RID: 68427
	[Description("自由移动")]
	FREE,
	// Token: 0x04010B4C RID: 68428
	[Description("方向控制")]
	DIRECTION,
	// Token: 0x04010B4D RID: 68429
	[Description("用于特殊操作")]
	SPECIAL,
	// Token: 0x04010B4E RID: 68430
	[Description("选择玩家")]
	SELECTSEAT,
	// Token: 0x04010B4F RID: 68431
	[Description("前后选择")]
	FORWARDBACK
}

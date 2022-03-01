using System;
using System.ComponentModel;

// Token: 0x020041BA RID: 16826
public enum SkillWalkMode
{
	// Token: 0x04010B3D RID: 68413
	[Description("禁止移动")]
	FORBID,
	// Token: 0x04010B3E RID: 68414
	[Description("所有方向都能走")]
	FREE,
	// Token: 0x04010B3F RID: 68415
	[Description("只能往面朝的方向走")]
	FACEDIR,
	// Token: 0x04010B40 RID: 68416
	[Description("变换方向")]
	CHANGE_DIR,
	// Token: 0x04010B41 RID: 68417
	[Description("自由变换方向")]
	FREE_AND_CHANGEDIR,
	// Token: 0x04010B42 RID: 68418
	[Description("只能X轴")]
	X_ONLY,
	// Token: 0x04010B43 RID: 68419
	[Description("只能Y轴")]
	Y_ONLY,
	// Token: 0x04010B44 RID: 68420
	[Description("只能往面朝的反方向走")]
	FACEDIR_OPPOSITE,
	// Token: 0x04010B45 RID: 68421
	[Description("Y轴方向接收方向输入（不影响原技能位移）")]
	X_YControl,
	// Token: 0x04010B46 RID: 68422
	[Description("所有方向都能走2(支持多阶段技能)")]
	FREE2,
	// Token: 0x04010B47 RID: 68423
	[Description("真正的禁止移动 将技能行走速率改为0")]
	FORBID2,
	// Token: 0x04010B48 RID: 68424
	[Description("X,Y已不同速率移动")]
	XYDiffRate
}

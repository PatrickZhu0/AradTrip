using System;
using System.ComponentModel;

// Token: 0x02004BBC RID: 19388
public enum DSkillPropertyModifyType
{
	// Token: 0x04013A34 RID: 80436
	[Description("X轴速度")]
	SPEED_X = 1,
	// Token: 0x04013A35 RID: 80437
	[Description("Y轴速度")]
	SPEED_Y,
	// Token: 0x04013A36 RID: 80438
	[Description("Z轴速度")]
	SPEED_Z,
	// Token: 0x04013A37 RID: 80439
	[Description("X轴加速度")]
	SPEED_XACC,
	// Token: 0x04013A38 RID: 80440
	[Description("Y轴加速度")]
	SPEED_YACC,
	// Token: 0x04013A39 RID: 80441
	[Description("Z轴加速度")]
	SPEED_ZACC,
	// Token: 0x04013A3A RID: 80442
	[Description("Z轴加速度(新)")]
	SPEED_ZACC_NEW
}

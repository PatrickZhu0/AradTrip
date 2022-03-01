using System;
using System.ComponentModel;

// Token: 0x02004BC6 RID: 19398
public enum DSFGrapOp
{
	// Token: 0x04013A78 RID: 80504
	[Description("抓取判定")]
	GRAP_JUDGE = 1,
	// Token: 0x04013A79 RID: 80505
	[Description("抓取执行")]
	GRAP_EXECUTE,
	// Token: 0x04013A7A RID: 80506
	[Description("抓取释放")]
	GRAP_RELEASE = 4,
	// Token: 0x04013A7B RID: 80507
	[Description("抓取中断(未抓取到目标时)")]
	GRAP_INTERRUPT = 8,
	// Token: 0x04013A7C RID: 80508
	[Description("抓取并跳到下一阶段标记")]
	GRAP_JUDGE_SKIP_PHASE = 536870912,
	// Token: 0x04013A7D RID: 80509
	[Description("抓取并且马上执行")]
	GRAP_JUDGE_EXECUTE = 1073741824,
	// Token: 0x04013A7E RID: 80510
	[Description("调整被抓取者的位置")]
	GRAP_CHANGE_TARGETPOS = 16,
	// Token: 0x04013A7F RID: 80511
	[Description("停止调整抓取者的位置")]
	GRAP_STOPCHANGE_TARGETPOS = 32,
	// Token: 0x04013A80 RID: 80512
	[Description("被抓取者的目标行为")]
	GRAP_CHANGE_TARGETACTION = 64,
	// Token: 0x04013A81 RID: 80513
	[Description("抓取中断(抓取框内没有目标时)")]
	GRAP_INTERRUPT_ATTACKBOX = 128
}

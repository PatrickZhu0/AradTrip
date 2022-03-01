using System;
using System.ComponentModel;

// Token: 0x020045D7 RID: 17879
internal enum TittleComeType
{
	// Token: 0x04012026 RID: 73766
	TCT_INVALID = -1,
	// Token: 0x04012027 RID: 73767
	[Description("商城")]
	TCT_SHOP,
	// Token: 0x04012028 RID: 73768
	[Description("任务")]
	TCT_MISSION,
	// Token: 0x04012029 RID: 73769
	[Description("活动")]
	TCT_ACTIVE,
	// Token: 0x0401202A RID: 73770
	[Description("时限")]
	TCT_TIMELIMITED,
	// Token: 0x0401202B RID: 73771
	[Description("可交易")]
	TCT_TRADE,
	// Token: 0x0401202C RID: 73772
	[Description("称号合成")]
	TCT_MERGE,
	// Token: 0x0401202D RID: 73773
	TCT_COUNT
}

using System;
using System.ComponentModel;

// Token: 0x02004BA6 RID: 19366
public enum EffectTimeType
{
	// Token: 0x04013947 RID: 80199
	[Description("每次都重新创建")]
	SYNC_ANIMATION,
	// Token: 0x04013948 RID: 80200
	[Description("只会存在一个")]
	GLOBAL_ANIMATION,
	// Token: 0x04013949 RID: 80201
	[Description("全局存在")]
	BUFF
}

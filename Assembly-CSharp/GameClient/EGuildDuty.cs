using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x0200125C RID: 4700
	public enum EGuildDuty
	{
		// Token: 0x040065B8 RID: 26040
		Invalid,
		// Token: 0x040065B9 RID: 26041
		[Description("guild_duty_normal")]
		Normal,
		// Token: 0x040065BA RID: 26042
		[Description("guild_duty_elite")]
		Elite,
		// Token: 0x040065BB RID: 26043
		[Description("guild_duty_elder")]
		Elder,
		// Token: 0x040065BC RID: 26044
		[Description("guild_duty_assistant")]
		Assistant,
		// Token: 0x040065BD RID: 26045
		[Description("guild_duty_leader")]
		Leader
	}
}

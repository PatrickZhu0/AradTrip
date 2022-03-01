using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x02001181 RID: 4481
	public enum ActorActionType
	{
		// Token: 0x04006024 RID: 24612
		[Description("Anim_Idle01")]
		AT_IDLE,
		// Token: 0x04006025 RID: 24613
		[Description("Anim_Walk")]
		AT_WALK,
		// Token: 0x04006026 RID: 24614
		[Description("Anim_Run")]
		AT_RUN,
		// Token: 0x04006027 RID: 24615
		[Description("Anim_Dead")]
		AT_DEAD,
		// Token: 0x04006028 RID: 24616
		AT_COUNT
	}
}

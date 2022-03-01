using System;

namespace behaviac
{
	// Token: 0x0200327C RID: 12924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node8 : Condition
	{
		// Token: 0x06014D74 RID: 85364 RVA: 0x00647245 File Offset: 0x00645645
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node8()
		{
			this.opl_p0 = 570206;
		}

		// Token: 0x06014D75 RID: 85365 RVA: 0x00647258 File Offset: 0x00645658
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E68F RID: 59023
		private int opl_p0;
	}
}

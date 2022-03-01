using System;

namespace behaviac
{
	// Token: 0x02003387 RID: 13191
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node26 : Action
	{
		// Token: 0x06014F6B RID: 85867 RVA: 0x00650C0A File Offset: 0x0064F00A
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node26()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 1;
		}

		// Token: 0x06014F6C RID: 85868 RVA: 0x00650C2C File Offset: 0x0064F02C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E83B RID: 59451
		private int method_p0;

		// Token: 0x0400E83C RID: 59452
		private int method_p1;
	}
}

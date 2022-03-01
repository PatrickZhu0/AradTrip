using System;

namespace behaviac
{
	// Token: 0x02003454 RID: 13396
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node26 : Action
	{
		// Token: 0x060150F4 RID: 86260 RVA: 0x0065851E File Offset: 0x0065691E
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node26()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 1;
		}

		// Token: 0x060150F5 RID: 86261 RVA: 0x00658540 File Offset: 0x00656940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E9DA RID: 59866
		private int method_p0;

		// Token: 0x0400E9DB RID: 59867
		private int method_p1;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003562 RID: 13666
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node1 : Action
	{
		// Token: 0x060152FF RID: 86783 RVA: 0x00662C70 File Offset: 0x00661070
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 120000;
			this.method_p1 = 0;
		}

		// Token: 0x06015300 RID: 86784 RVA: 0x00662C94 File Offset: 0x00661094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECB3 RID: 60595
		private int method_p0;

		// Token: 0x0400ECB4 RID: 60596
		private int method_p1;
	}
}

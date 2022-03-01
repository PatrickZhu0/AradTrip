using System;

namespace behaviac
{
	// Token: 0x02003391 RID: 13201
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node31 : Action
	{
		// Token: 0x06014F7F RID: 85887 RVA: 0x00650F76 File Offset: 0x0064F376
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node31()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 2;
		}

		// Token: 0x06014F80 RID: 85888 RVA: 0x00650F98 File Offset: 0x0064F398
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E857 RID: 59479
		private int method_p0;

		// Token: 0x0400E858 RID: 59480
		private int method_p1;
	}
}

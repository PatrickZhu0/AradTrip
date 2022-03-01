using System;

namespace behaviac
{
	// Token: 0x02003446 RID: 13382
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node5 : Action
	{
		// Token: 0x060150D8 RID: 86232 RVA: 0x00658036 File Offset: 0x00656436
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 10500;
			this.method_p1 = 4;
		}

		// Token: 0x060150D9 RID: 86233 RVA: 0x00658058 File Offset: 0x00656458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E9AC RID: 59820
		private int method_p0;

		// Token: 0x0400E9AD RID: 59821
		private int method_p1;
	}
}

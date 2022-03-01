using System;

namespace behaviac
{
	// Token: 0x02003463 RID: 13411
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node37 : Action
	{
		// Token: 0x06015112 RID: 86290 RVA: 0x00658A67 File Offset: 0x00656E67
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node37()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 100;
			this.method_p1 = 5;
		}

		// Token: 0x06015113 RID: 86291 RVA: 0x00658A88 File Offset: 0x00656E88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA0F RID: 59919
		private int method_p0;

		// Token: 0x0400EA10 RID: 59920
		private int method_p1;
	}
}

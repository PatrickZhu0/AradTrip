using System;

namespace behaviac
{
	// Token: 0x020034AF RID: 13487
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node10 : Action
	{
		// Token: 0x060151A4 RID: 86436 RVA: 0x0065BF2B File Offset: 0x0065A32B
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6300;
			this.method_p1 = 2;
		}

		// Token: 0x060151A5 RID: 86437 RVA: 0x0065BF4C File Offset: 0x0065A34C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EAA5 RID: 60069
		private int method_p0;

		// Token: 0x0400EAA6 RID: 60070
		private int method_p1;
	}
}

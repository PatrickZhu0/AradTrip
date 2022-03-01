using System;

namespace behaviac
{
	// Token: 0x020034B7 RID: 13495
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node14 : Action
	{
		// Token: 0x060151B4 RID: 86452 RVA: 0x0065C1CF File Offset: 0x0065A5CF
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521715;
		}

		// Token: 0x060151B5 RID: 86453 RVA: 0x0065C1F0 File Offset: 0x0065A5F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EABD RID: 60093
		private BE_Target method_p0;

		// Token: 0x0400EABE RID: 60094
		private int method_p1;
	}
}

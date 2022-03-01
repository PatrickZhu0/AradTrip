using System;

namespace behaviac
{
	// Token: 0x020034C3 RID: 13507
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node37 : Action
	{
		// Token: 0x060151CC RID: 86476 RVA: 0x0065C592 File Offset: 0x0065A992
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521752;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151CD RID: 86477 RVA: 0x0065C5C9 File Offset: 0x0065A9C9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAD5 RID: 60117
		private BE_Target method_p0;

		// Token: 0x0400EAD6 RID: 60118
		private int method_p1;

		// Token: 0x0400EAD7 RID: 60119
		private int method_p2;

		// Token: 0x0400EAD8 RID: 60120
		private int method_p3;

		// Token: 0x0400EAD9 RID: 60121
		private int method_p4;
	}
}

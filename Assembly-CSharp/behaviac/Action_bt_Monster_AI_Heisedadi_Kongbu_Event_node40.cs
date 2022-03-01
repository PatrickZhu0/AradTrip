using System;

namespace behaviac
{
	// Token: 0x020034CE RID: 13518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node40 : Action
	{
		// Token: 0x060151E2 RID: 86498 RVA: 0x0065C93A File Offset: 0x0065AD3A
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521721;
		}

		// Token: 0x060151E3 RID: 86499 RVA: 0x0065C95B File Offset: 0x0065AD5B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAF3 RID: 60147
		private BE_Target method_p0;

		// Token: 0x0400EAF4 RID: 60148
		private int method_p1;
	}
}

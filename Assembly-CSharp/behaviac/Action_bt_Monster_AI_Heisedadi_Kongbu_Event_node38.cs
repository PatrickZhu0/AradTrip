using System;

namespace behaviac
{
	// Token: 0x020034C0 RID: 13504
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node38 : Action
	{
		// Token: 0x060151C6 RID: 86470 RVA: 0x0065C4AB File Offset: 0x0065A8AB
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node38()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521752;
		}

		// Token: 0x060151C7 RID: 86471 RVA: 0x0065C4CC File Offset: 0x0065A8CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EACF RID: 60111
		private BE_Target method_p0;

		// Token: 0x0400EAD0 RID: 60112
		private int method_p1;
	}
}

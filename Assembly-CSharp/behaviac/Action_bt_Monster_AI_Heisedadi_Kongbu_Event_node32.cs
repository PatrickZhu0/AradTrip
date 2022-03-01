using System;

namespace behaviac
{
	// Token: 0x020034C9 RID: 13513
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node32 : Action
	{
		// Token: 0x060151D8 RID: 86488 RVA: 0x0065C7A7 File Offset: 0x0065ABA7
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521715;
		}

		// Token: 0x060151D9 RID: 86489 RVA: 0x0065C7C8 File Offset: 0x0065ABC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAE7 RID: 60135
		private BE_Target method_p0;

		// Token: 0x0400EAE8 RID: 60136
		private int method_p1;
	}
}

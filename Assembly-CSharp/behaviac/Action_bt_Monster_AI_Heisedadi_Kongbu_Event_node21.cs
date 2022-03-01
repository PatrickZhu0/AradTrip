using System;

namespace behaviac
{
	// Token: 0x020034BB RID: 13499
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node21 : Action
	{
		// Token: 0x060151BC RID: 86460 RVA: 0x0065C306 File Offset: 0x0065A706
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521715;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151BD RID: 86461 RVA: 0x0065C33D File Offset: 0x0065A73D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAC4 RID: 60100
		private BE_Target method_p0;

		// Token: 0x0400EAC5 RID: 60101
		private int method_p1;

		// Token: 0x0400EAC6 RID: 60102
		private int method_p2;

		// Token: 0x0400EAC7 RID: 60103
		private int method_p3;

		// Token: 0x0400EAC8 RID: 60104
		private int method_p4;
	}
}

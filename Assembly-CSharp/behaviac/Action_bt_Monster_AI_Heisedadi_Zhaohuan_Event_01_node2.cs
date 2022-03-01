using System;

namespace behaviac
{
	// Token: 0x0200355D RID: 13661
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2 : Action
	{
		// Token: 0x060152F7 RID: 86775 RVA: 0x006629CA File Offset: 0x00660DCA
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521851;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060152F8 RID: 86776 RVA: 0x00662A04 File Offset: 0x00660E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA7 RID: 60583
		private BE_Target method_p0;

		// Token: 0x0400ECA8 RID: 60584
		private int method_p1;

		// Token: 0x0400ECA9 RID: 60585
		private int method_p2;

		// Token: 0x0400ECAA RID: 60586
		private int method_p3;

		// Token: 0x0400ECAB RID: 60587
		private int method_p4;
	}
}

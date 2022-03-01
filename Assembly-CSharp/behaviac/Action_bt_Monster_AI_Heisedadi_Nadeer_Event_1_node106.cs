using System;

namespace behaviac
{
	// Token: 0x02003540 RID: 13632
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node106 : Action
	{
		// Token: 0x060152C3 RID: 86723 RVA: 0x0066033E File Offset: 0x0065E73E
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node106()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521875;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152C4 RID: 86724 RVA: 0x00660375 File Offset: 0x0065E775
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC75 RID: 60533
		private BE_Target method_p0;

		// Token: 0x0400EC76 RID: 60534
		private int method_p1;

		// Token: 0x0400EC77 RID: 60535
		private int method_p2;

		// Token: 0x0400EC78 RID: 60536
		private int method_p3;

		// Token: 0x0400EC79 RID: 60537
		private int method_p4;
	}
}

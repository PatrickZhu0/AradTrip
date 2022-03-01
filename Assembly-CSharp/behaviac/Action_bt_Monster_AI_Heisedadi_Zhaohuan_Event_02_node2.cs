using System;

namespace behaviac
{
	// Token: 0x02003560 RID: 13664
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2 : Action
	{
		// Token: 0x060152FC RID: 86780 RVA: 0x00662B42 File Offset: 0x00660F42
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521852;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060152FD RID: 86781 RVA: 0x00662B7C File Offset: 0x00660F7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECAE RID: 60590
		private BE_Target method_p0;

		// Token: 0x0400ECAF RID: 60591
		private int method_p1;

		// Token: 0x0400ECB0 RID: 60592
		private int method_p2;

		// Token: 0x0400ECB1 RID: 60593
		private int method_p3;

		// Token: 0x0400ECB2 RID: 60594
		private int method_p4;
	}
}

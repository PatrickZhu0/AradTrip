using System;

namespace behaviac
{
	// Token: 0x0200353F RID: 13631
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node100 : Action
	{
		// Token: 0x060152C1 RID: 86721 RVA: 0x006602DB File Offset: 0x0065E6DB
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node100()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521766;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152C2 RID: 86722 RVA: 0x00660312 File Offset: 0x0065E712
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC70 RID: 60528
		private BE_Target method_p0;

		// Token: 0x0400EC71 RID: 60529
		private int method_p1;

		// Token: 0x0400EC72 RID: 60530
		private int method_p2;

		// Token: 0x0400EC73 RID: 60531
		private int method_p3;

		// Token: 0x0400EC74 RID: 60532
		private int method_p4;
	}
}

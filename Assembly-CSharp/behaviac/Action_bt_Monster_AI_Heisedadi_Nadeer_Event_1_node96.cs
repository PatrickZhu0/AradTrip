using System;

namespace behaviac
{
	// Token: 0x0200353B RID: 13627
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node96 : Action
	{
		// Token: 0x060152B9 RID: 86713 RVA: 0x0066014F File Offset: 0x0065E54F
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node96()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521783;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152BA RID: 86714 RVA: 0x00660186 File Offset: 0x0065E586
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC5C RID: 60508
		private BE_Target method_p0;

		// Token: 0x0400EC5D RID: 60509
		private int method_p1;

		// Token: 0x0400EC5E RID: 60510
		private int method_p2;

		// Token: 0x0400EC5F RID: 60511
		private int method_p3;

		// Token: 0x0400EC60 RID: 60512
		private int method_p4;
	}
}

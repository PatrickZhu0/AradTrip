using System;

namespace behaviac
{
	// Token: 0x02003530 RID: 13616
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node77 : Action
	{
		// Token: 0x060152A3 RID: 86691 RVA: 0x0065FD51 File Offset: 0x0065E151
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node77()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521773;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152A4 RID: 86692 RVA: 0x0065FD88 File Offset: 0x0065E188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC2E RID: 60462
		private BE_Target method_p0;

		// Token: 0x0400EC2F RID: 60463
		private int method_p1;

		// Token: 0x0400EC30 RID: 60464
		private int method_p2;

		// Token: 0x0400EC31 RID: 60465
		private int method_p3;

		// Token: 0x0400EC32 RID: 60466
		private int method_p4;
	}
}

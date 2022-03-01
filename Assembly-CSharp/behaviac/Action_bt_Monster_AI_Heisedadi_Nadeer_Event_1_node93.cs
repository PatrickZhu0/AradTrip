using System;

namespace behaviac
{
	// Token: 0x02003538 RID: 13624
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node93 : Action
	{
		// Token: 0x060152B3 RID: 86707 RVA: 0x00660026 File Offset: 0x0065E426
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node93()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521786;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152B4 RID: 86708 RVA: 0x0066005D File Offset: 0x0065E45D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC4D RID: 60493
		private BE_Target method_p0;

		// Token: 0x0400EC4E RID: 60494
		private int method_p1;

		// Token: 0x0400EC4F RID: 60495
		private int method_p2;

		// Token: 0x0400EC50 RID: 60496
		private int method_p3;

		// Token: 0x0400EC51 RID: 60497
		private int method_p4;
	}
}

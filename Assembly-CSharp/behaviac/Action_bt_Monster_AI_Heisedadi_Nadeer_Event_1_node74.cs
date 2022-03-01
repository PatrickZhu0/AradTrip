using System;

namespace behaviac
{
	// Token: 0x0200352D RID: 13613
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node74 : Action
	{
		// Token: 0x0601529D RID: 86685 RVA: 0x0065FC28 File Offset: 0x0065E028
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node74()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521784;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601529E RID: 86686 RVA: 0x0065FC5F File Offset: 0x0065E05F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC1F RID: 60447
		private BE_Target method_p0;

		// Token: 0x0400EC20 RID: 60448
		private int method_p1;

		// Token: 0x0400EC21 RID: 60449
		private int method_p2;

		// Token: 0x0400EC22 RID: 60450
		private int method_p3;

		// Token: 0x0400EC23 RID: 60451
		private int method_p4;
	}
}

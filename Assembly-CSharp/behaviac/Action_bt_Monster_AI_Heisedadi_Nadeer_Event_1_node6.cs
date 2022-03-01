using System;

namespace behaviac
{
	// Token: 0x020034EC RID: 13548
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node6 : Action
	{
		// Token: 0x0601521B RID: 86555 RVA: 0x0065E64B File Offset: 0x0065CA4B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521798;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601521C RID: 86556 RVA: 0x0065E682 File Offset: 0x0065CA82
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB35 RID: 60213
		private BE_Target method_p0;

		// Token: 0x0400EB36 RID: 60214
		private int method_p1;

		// Token: 0x0400EB37 RID: 60215
		private int method_p2;

		// Token: 0x0400EB38 RID: 60216
		private int method_p3;

		// Token: 0x0400EB39 RID: 60217
		private int method_p4;
	}
}

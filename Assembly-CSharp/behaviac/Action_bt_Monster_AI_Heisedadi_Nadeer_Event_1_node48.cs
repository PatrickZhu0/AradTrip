using System;

namespace behaviac
{
	// Token: 0x020034E9 RID: 13545
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node48 : Action
	{
		// Token: 0x06015215 RID: 86549 RVA: 0x0065E573 File Offset: 0x0065C973
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521798;
		}

		// Token: 0x06015216 RID: 86550 RVA: 0x0065E594 File Offset: 0x0065C994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB2E RID: 60206
		private BE_Target method_p0;

		// Token: 0x0400EB2F RID: 60207
		private int method_p1;
	}
}

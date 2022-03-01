using System;

namespace behaviac
{
	// Token: 0x02003504 RID: 13572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node43 : Action
	{
		// Token: 0x0601524B RID: 86603 RVA: 0x0065EE24 File Offset: 0x0065D224
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node43()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521749;
		}

		// Token: 0x0601524C RID: 86604 RVA: 0x0065EE45 File Offset: 0x0065D245
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB84 RID: 60292
		private BE_Target method_p0;

		// Token: 0x0400EB85 RID: 60293
		private int method_p1;
	}
}

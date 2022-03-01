using System;

namespace behaviac
{
	// Token: 0x02003518 RID: 13592
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node69 : Action
	{
		// Token: 0x06015273 RID: 86643 RVA: 0x0065F48F File Offset: 0x0065D88F
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node69()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521763;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015274 RID: 86644 RVA: 0x0065F4C6 File Offset: 0x0065D8C6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBC8 RID: 60360
		private BE_Target method_p0;

		// Token: 0x0400EBC9 RID: 60361
		private int method_p1;

		// Token: 0x0400EBCA RID: 60362
		private int method_p2;

		// Token: 0x0400EBCB RID: 60363
		private int method_p3;

		// Token: 0x0400EBCC RID: 60364
		private int method_p4;
	}
}

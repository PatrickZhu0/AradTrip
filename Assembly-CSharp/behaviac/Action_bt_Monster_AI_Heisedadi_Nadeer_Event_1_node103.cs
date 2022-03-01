using System;

namespace behaviac
{
	// Token: 0x02003519 RID: 13593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node103 : Action
	{
		// Token: 0x06015275 RID: 86645 RVA: 0x0065F4F2 File Offset: 0x0065D8F2
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521872;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015276 RID: 86646 RVA: 0x0065F529 File Offset: 0x0065D929
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBCD RID: 60365
		private BE_Target method_p0;

		// Token: 0x0400EBCE RID: 60366
		private int method_p1;

		// Token: 0x0400EBCF RID: 60367
		private int method_p2;

		// Token: 0x0400EBD0 RID: 60368
		private int method_p3;

		// Token: 0x0400EBD1 RID: 60369
		private int method_p4;
	}
}

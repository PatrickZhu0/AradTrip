using System;

namespace behaviac
{
	// Token: 0x02003522 RID: 13602
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node86 : Action
	{
		// Token: 0x06015287 RID: 86663 RVA: 0x0065F82A File Offset: 0x0065DC2A
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node86()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521790;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015288 RID: 86664 RVA: 0x0065F861 File Offset: 0x0065DC61
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBF1 RID: 60401
		private BE_Target method_p0;

		// Token: 0x0400EBF2 RID: 60402
		private int method_p1;

		// Token: 0x0400EBF3 RID: 60403
		private int method_p2;

		// Token: 0x0400EBF4 RID: 60404
		private int method_p3;

		// Token: 0x0400EBF5 RID: 60405
		private int method_p4;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200351D RID: 13597
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node81 : Action
	{
		// Token: 0x0601527D RID: 86653 RVA: 0x0065F63B File Offset: 0x0065DA3B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node81()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521783;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601527E RID: 86654 RVA: 0x0065F672 File Offset: 0x0065DA72
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBD8 RID: 60376
		private BE_Target method_p0;

		// Token: 0x0400EBD9 RID: 60377
		private int method_p1;

		// Token: 0x0400EBDA RID: 60378
		private int method_p2;

		// Token: 0x0400EBDB RID: 60379
		private int method_p3;

		// Token: 0x0400EBDC RID: 60380
		private int method_p4;
	}
}

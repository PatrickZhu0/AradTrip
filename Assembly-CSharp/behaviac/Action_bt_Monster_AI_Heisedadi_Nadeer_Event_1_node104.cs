using System;

namespace behaviac
{
	// Token: 0x02003526 RID: 13606
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node104 : Action
	{
		// Token: 0x0601528F RID: 86671 RVA: 0x0065F9B6 File Offset: 0x0065DDB6
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node104()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521873;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015290 RID: 86672 RVA: 0x0065F9ED File Offset: 0x0065DDED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC05 RID: 60421
		private BE_Target method_p0;

		// Token: 0x0400EC06 RID: 60422
		private int method_p1;

		// Token: 0x0400EC07 RID: 60423
		private int method_p2;

		// Token: 0x0400EC08 RID: 60424
		private int method_p3;

		// Token: 0x0400EC09 RID: 60425
		private int method_p4;
	}
}

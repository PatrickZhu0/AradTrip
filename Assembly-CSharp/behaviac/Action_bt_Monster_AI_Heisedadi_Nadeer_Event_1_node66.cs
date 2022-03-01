using System;

namespace behaviac
{
	// Token: 0x02003515 RID: 13589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node66 : Action
	{
		// Token: 0x0601526D RID: 86637 RVA: 0x0065F366 File Offset: 0x0065D766
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521790;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601526E RID: 86638 RVA: 0x0065F39D File Offset: 0x0065D79D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBB9 RID: 60345
		private BE_Target method_p0;

		// Token: 0x0400EBBA RID: 60346
		private int method_p1;

		// Token: 0x0400EBBB RID: 60347
		private int method_p2;

		// Token: 0x0400EBBC RID: 60348
		private int method_p3;

		// Token: 0x0400EBBD RID: 60349
		private int method_p4;
	}
}

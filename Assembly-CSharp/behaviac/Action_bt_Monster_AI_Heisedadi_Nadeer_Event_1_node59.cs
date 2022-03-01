using System;

namespace behaviac
{
	// Token: 0x02003513 RID: 13587
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node59 : Action
	{
		// Token: 0x06015269 RID: 86633 RVA: 0x0065F2A0 File Offset: 0x0065D6A0
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node59()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521788;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601526A RID: 86634 RVA: 0x0065F2D7 File Offset: 0x0065D6D7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBAF RID: 60335
		private BE_Target method_p0;

		// Token: 0x0400EBB0 RID: 60336
		private int method_p1;

		// Token: 0x0400EBB1 RID: 60337
		private int method_p2;

		// Token: 0x0400EBB2 RID: 60338
		private int method_p3;

		// Token: 0x0400EBB3 RID: 60339
		private int method_p4;
	}
}

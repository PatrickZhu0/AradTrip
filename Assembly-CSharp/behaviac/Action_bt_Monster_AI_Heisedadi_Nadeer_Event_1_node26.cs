using System;

namespace behaviac
{
	// Token: 0x020034F8 RID: 13560
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node26 : Action
	{
		// Token: 0x06015233 RID: 86579 RVA: 0x0065EA4B File Offset: 0x0065CE4B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521794;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015234 RID: 86580 RVA: 0x0065EA82 File Offset: 0x0065CE82
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB5D RID: 60253
		private BE_Target method_p0;

		// Token: 0x0400EB5E RID: 60254
		private int method_p1;

		// Token: 0x0400EB5F RID: 60255
		private int method_p2;

		// Token: 0x0400EB60 RID: 60256
		private int method_p3;

		// Token: 0x0400EB61 RID: 60257
		private int method_p4;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020034FF RID: 13567
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node37 : Action
	{
		// Token: 0x06015241 RID: 86593 RVA: 0x0065ECAE File Offset: 0x0065D0AE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521793;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015242 RID: 86594 RVA: 0x0065ECE5 File Offset: 0x0065D0E5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB76 RID: 60278
		private BE_Target method_p0;

		// Token: 0x0400EB77 RID: 60279
		private int method_p1;

		// Token: 0x0400EB78 RID: 60280
		private int method_p2;

		// Token: 0x0400EB79 RID: 60281
		private int method_p3;

		// Token: 0x0400EB7A RID: 60282
		private int method_p4;
	}
}

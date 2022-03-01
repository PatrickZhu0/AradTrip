using System;

namespace behaviac
{
	// Token: 0x020034F9 RID: 13561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node27 : Action
	{
		// Token: 0x06015235 RID: 86581 RVA: 0x0065EAAE File Offset: 0x0065CEAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521795;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015236 RID: 86582 RVA: 0x0065EAE5 File Offset: 0x0065CEE5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB62 RID: 60258
		private BE_Target method_p0;

		// Token: 0x0400EB63 RID: 60259
		private int method_p1;

		// Token: 0x0400EB64 RID: 60260
		private int method_p2;

		// Token: 0x0400EB65 RID: 60261
		private int method_p3;

		// Token: 0x0400EB66 RID: 60262
		private int method_p4;
	}
}

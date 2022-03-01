using System;

namespace behaviac
{
	// Token: 0x0200350C RID: 13580
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node65 : Action
	{
		// Token: 0x0601525B RID: 86619 RVA: 0x0065F02E File Offset: 0x0065D42E
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node65()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521774;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601525C RID: 86620 RVA: 0x0065F065 File Offset: 0x0065D465
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB95 RID: 60309
		private BE_Target method_p0;

		// Token: 0x0400EB96 RID: 60310
		private int method_p1;

		// Token: 0x0400EB97 RID: 60311
		private int method_p2;

		// Token: 0x0400EB98 RID: 60312
		private int method_p3;

		// Token: 0x0400EB99 RID: 60313
		private int method_p4;
	}
}

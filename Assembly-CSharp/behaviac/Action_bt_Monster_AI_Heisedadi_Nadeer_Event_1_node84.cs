using System;

namespace behaviac
{
	// Token: 0x02003520 RID: 13600
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node84 : Action
	{
		// Token: 0x06015283 RID: 86659 RVA: 0x0065F764 File Offset: 0x0065DB64
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node84()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521788;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015284 RID: 86660 RVA: 0x0065F79B File Offset: 0x0065DB9B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBE7 RID: 60391
		private BE_Target method_p0;

		// Token: 0x0400EBE8 RID: 60392
		private int method_p1;

		// Token: 0x0400EBE9 RID: 60393
		private int method_p2;

		// Token: 0x0400EBEA RID: 60394
		private int method_p3;

		// Token: 0x0400EBEB RID: 60395
		private int method_p4;
	}
}

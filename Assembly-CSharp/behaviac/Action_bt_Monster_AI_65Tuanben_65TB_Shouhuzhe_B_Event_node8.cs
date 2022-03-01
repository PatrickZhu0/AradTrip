using System;

namespace behaviac
{
	// Token: 0x02002C6B RID: 11371
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node8 : Action
	{
		// Token: 0x060141CF RID: 82383 RVA: 0x0060A60B File Offset: 0x00608A0B
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x060141D0 RID: 82384 RVA: 0x0060A642 File Offset: 0x00608A42
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB8D RID: 56205
		private BE_Target method_p0;

		// Token: 0x0400DB8E RID: 56206
		private int method_p1;

		// Token: 0x0400DB8F RID: 56207
		private int method_p2;

		// Token: 0x0400DB90 RID: 56208
		private int method_p3;

		// Token: 0x0400DB91 RID: 56209
		private int method_p4;
	}
}

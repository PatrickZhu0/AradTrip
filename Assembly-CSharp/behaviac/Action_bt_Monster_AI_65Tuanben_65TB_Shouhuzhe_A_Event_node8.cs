using System;

namespace behaviac
{
	// Token: 0x02002C42 RID: 11330
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node8 : Action
	{
		// Token: 0x06014180 RID: 82304 RVA: 0x00608CAF File Offset: 0x006070AF
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014181 RID: 82305 RVA: 0x00608CE6 File Offset: 0x006070E6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB43 RID: 56131
		private BE_Target method_p0;

		// Token: 0x0400DB44 RID: 56132
		private int method_p1;

		// Token: 0x0400DB45 RID: 56133
		private int method_p2;

		// Token: 0x0400DB46 RID: 56134
		private int method_p3;

		// Token: 0x0400DB47 RID: 56135
		private int method_p4;
	}
}

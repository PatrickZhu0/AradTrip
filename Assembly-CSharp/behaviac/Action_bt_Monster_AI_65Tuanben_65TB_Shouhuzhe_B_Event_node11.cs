using System;

namespace behaviac
{
	// Token: 0x02002C6D RID: 11373
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node11 : Action
	{
		// Token: 0x060141D3 RID: 82387 RVA: 0x0060A6CF File Offset: 0x00608ACF
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
		}

		// Token: 0x060141D4 RID: 82388 RVA: 0x0060A6F0 File Offset: 0x00608AF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB95 RID: 56213
		private BE_Target method_p0;

		// Token: 0x0400DB96 RID: 56214
		private int method_p1;
	}
}

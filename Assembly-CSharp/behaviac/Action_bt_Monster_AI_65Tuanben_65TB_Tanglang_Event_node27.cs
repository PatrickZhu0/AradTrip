using System;

namespace behaviac
{
	// Token: 0x02002CB3 RID: 11443
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node27 : Action
	{
		// Token: 0x0601425B RID: 82523 RVA: 0x0060CFB1 File Offset: 0x0060B3B1
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521951;
		}

		// Token: 0x0601425C RID: 82524 RVA: 0x0060CFD2 File Offset: 0x0060B3D2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC13 RID: 56339
		private BE_Target method_p0;

		// Token: 0x0400DC14 RID: 56340
		private int method_p1;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002C7B RID: 11387
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node28 : Action
	{
		// Token: 0x060141EF RID: 82415 RVA: 0x0060AC12 File Offset: 0x00609012
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 1;
		}

		// Token: 0x060141F0 RID: 82416 RVA: 0x0060AC34 File Offset: 0x00609034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DBB4 RID: 56244
		private int method_p0;

		// Token: 0x0400DBB5 RID: 56245
		private int method_p1;
	}
}

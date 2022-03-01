using System;

namespace behaviac
{
	// Token: 0x02002C52 RID: 11346
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node28 : Action
	{
		// Token: 0x060141A0 RID: 82336 RVA: 0x006092B6 File Offset: 0x006076B6
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 1;
		}

		// Token: 0x060141A1 RID: 82337 RVA: 0x006092D8 File Offset: 0x006076D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DB6A RID: 56170
		private int method_p0;

		// Token: 0x0400DB6B RID: 56171
		private int method_p1;
	}
}

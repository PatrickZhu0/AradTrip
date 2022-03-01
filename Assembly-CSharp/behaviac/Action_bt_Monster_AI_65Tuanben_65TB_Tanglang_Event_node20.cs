using System;

namespace behaviac
{
	// Token: 0x02002CB4 RID: 11444
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node20 : Action
	{
		// Token: 0x0601425D RID: 82525 RVA: 0x0060CFEC File Offset: 0x0060B3EC
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node20()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 0;
		}

		// Token: 0x0601425E RID: 82526 RVA: 0x0060D010 File Offset: 0x0060B410
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DC15 RID: 56341
		private int method_p0;

		// Token: 0x0400DC16 RID: 56342
		private int method_p1;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002B6B RID: 11115
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node69 : Action
	{
		// Token: 0x06013FE4 RID: 81892 RVA: 0x006002FE File Offset: 0x005FE6FE
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node69()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 42770021;
			this.method_p1 = false;
		}

		// Token: 0x06013FE5 RID: 81893 RVA: 0x0060031F File Offset: 0x005FE71F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F6 RID: 55798
		private int method_p0;

		// Token: 0x0400D9F7 RID: 55799
		private bool method_p1;
	}
}

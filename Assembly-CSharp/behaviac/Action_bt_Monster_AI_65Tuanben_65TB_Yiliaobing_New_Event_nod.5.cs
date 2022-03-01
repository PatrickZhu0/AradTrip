using System;

namespace behaviac
{
	// Token: 0x02002D2F RID: 11567
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node4 : Action
	{
		// Token: 0x06014347 RID: 82759 RVA: 0x00611D26 File Offset: 0x00610126
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06014348 RID: 82760 RVA: 0x00611D48 File Offset: 0x00610148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD0A RID: 56586
		private int method_p0;

		// Token: 0x0400DD0B RID: 56587
		private int method_p1;
	}
}

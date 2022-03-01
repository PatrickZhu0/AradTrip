using System;

namespace behaviac
{
	// Token: 0x02002D24 RID: 11556
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3 : Action
	{
		// Token: 0x06014333 RID: 82739 RVA: 0x00611732 File Offset: 0x0060FB32
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x06014334 RID: 82740 RVA: 0x00611754 File Offset: 0x0060FB54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DCEC RID: 56556
		private int method_p0;

		// Token: 0x0400DCED RID: 56557
		private int method_p1;
	}
}

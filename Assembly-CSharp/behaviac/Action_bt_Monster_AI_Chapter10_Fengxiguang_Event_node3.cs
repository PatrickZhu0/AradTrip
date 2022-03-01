using System;

namespace behaviac
{
	// Token: 0x020030FA RID: 12538
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node3 : Action
	{
		// Token: 0x06014AA2 RID: 84642 RVA: 0x00639131 File Offset: 0x00637531
		public Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 250;
			this.method_p1 = 0;
		}

		// Token: 0x06014AA3 RID: 84643 RVA: 0x00639154 File Offset: 0x00637554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E415 RID: 58389
		private int method_p0;

		// Token: 0x0400E416 RID: 58390
		private int method_p1;
	}
}

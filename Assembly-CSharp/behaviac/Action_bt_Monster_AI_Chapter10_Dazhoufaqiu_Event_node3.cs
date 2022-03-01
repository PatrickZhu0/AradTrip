using System;

namespace behaviac
{
	// Token: 0x020030F2 RID: 12530
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_Event_node3 : Action
	{
		// Token: 0x06014A94 RID: 84628 RVA: 0x00638D61 File Offset: 0x00637161
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x06014A95 RID: 84629 RVA: 0x00638D84 File Offset: 0x00637184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E406 RID: 58374
		private int method_p0;

		// Token: 0x0400E407 RID: 58375
		private int method_p1;
	}
}

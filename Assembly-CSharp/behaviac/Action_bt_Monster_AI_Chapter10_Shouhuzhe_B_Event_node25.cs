using System;

namespace behaviac
{
	// Token: 0x02003135 RID: 12597
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node25 : Action
	{
		// Token: 0x06014B0D RID: 84749 RVA: 0x0063B2F3 File Offset: 0x006396F3
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06014B0E RID: 84750 RVA: 0x0063B314 File Offset: 0x00639714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E47D RID: 58493
		private int method_p0;

		// Token: 0x0400E47E RID: 58494
		private int method_p1;
	}
}

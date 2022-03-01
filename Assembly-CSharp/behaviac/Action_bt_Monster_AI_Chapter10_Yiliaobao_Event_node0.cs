using System;

namespace behaviac
{
	// Token: 0x02003150 RID: 12624
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node0 : Action
	{
		// Token: 0x06014B41 RID: 84801 RVA: 0x0063C35F File Offset: 0x0063A75F
		public Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6000;
			this.method_p1 = 0;
		}

		// Token: 0x06014B42 RID: 84802 RVA: 0x0063C380 File Offset: 0x0063A780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4B6 RID: 58550
		private int method_p0;

		// Token: 0x0400E4B7 RID: 58551
		private int method_p1;
	}
}

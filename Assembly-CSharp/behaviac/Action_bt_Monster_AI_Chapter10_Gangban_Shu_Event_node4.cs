using System;

namespace behaviac
{
	// Token: 0x02003107 RID: 12551
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node4 : Action
	{
		// Token: 0x06014ABA RID: 84666 RVA: 0x006397A2 File Offset: 0x00637BA2
		public Action_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 8000;
			this.method_p1 = 0;
		}

		// Token: 0x06014ABB RID: 84667 RVA: 0x006397C4 File Offset: 0x00637BC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E42C RID: 58412
		private int method_p0;

		// Token: 0x0400E42D RID: 58413
		private int method_p1;
	}
}

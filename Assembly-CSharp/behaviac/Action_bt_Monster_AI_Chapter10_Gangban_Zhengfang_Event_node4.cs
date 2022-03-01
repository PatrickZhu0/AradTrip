using System;

namespace behaviac
{
	// Token: 0x0200310D RID: 12557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node4 : Action
	{
		// Token: 0x06014AC5 RID: 84677 RVA: 0x00639AF6 File Offset: 0x00637EF6
		public Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 8000;
			this.method_p1 = 0;
		}

		// Token: 0x06014AC6 RID: 84678 RVA: 0x00639B18 File Offset: 0x00637F18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E435 RID: 58421
		private int method_p0;

		// Token: 0x0400E436 RID: 58422
		private int method_p1;
	}
}

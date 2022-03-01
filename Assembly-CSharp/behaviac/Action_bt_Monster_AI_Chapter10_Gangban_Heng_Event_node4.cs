using System;

namespace behaviac
{
	// Token: 0x02003101 RID: 12545
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node4 : Action
	{
		// Token: 0x06014AAF RID: 84655 RVA: 0x0063944E File Offset: 0x0063784E
		public Action_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 8000;
			this.method_p1 = 0;
		}

		// Token: 0x06014AB0 RID: 84656 RVA: 0x00639470 File Offset: 0x00637870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E423 RID: 58403
		private int method_p0;

		// Token: 0x0400E424 RID: 58404
		private int method_p1;
	}
}

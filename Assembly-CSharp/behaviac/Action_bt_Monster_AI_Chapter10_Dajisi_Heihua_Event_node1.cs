using System;

namespace behaviac
{
	// Token: 0x020030D7 RID: 12503
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node1 : Action
	{
		// Token: 0x06014A65 RID: 84581 RVA: 0x00637E6F File Offset: 0x0063626F
		public Action_bt_Monster_AI_Chapter10_Dajisi_Heihua_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2950;
			this.method_p1 = 0;
		}

		// Token: 0x06014A66 RID: 84582 RVA: 0x00637E90 File Offset: 0x00636290
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E3CB RID: 58315
		private int method_p0;

		// Token: 0x0400E3CC RID: 58316
		private int method_p1;
	}
}

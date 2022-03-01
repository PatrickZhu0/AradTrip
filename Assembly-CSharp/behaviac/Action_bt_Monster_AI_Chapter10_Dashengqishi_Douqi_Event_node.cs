using System;

namespace behaviac
{
	// Token: 0x020030DF RID: 12511
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node4 : Action
	{
		// Token: 0x06014A73 RID: 84595 RVA: 0x00638286 File Offset: 0x00636686
		public Action_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 12000;
			this.method_p1 = 0;
		}

		// Token: 0x06014A74 RID: 84596 RVA: 0x006382A8 File Offset: 0x006366A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E3DF RID: 58335
		private int method_p0;

		// Token: 0x0400E3E0 RID: 58336
		private int method_p1;
	}
}

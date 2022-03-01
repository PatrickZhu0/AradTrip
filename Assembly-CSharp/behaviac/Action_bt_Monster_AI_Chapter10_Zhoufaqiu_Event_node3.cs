using System;

namespace behaviac
{
	// Token: 0x02003167 RID: 12647
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_Event_node3 : Action
	{
		// Token: 0x06014B68 RID: 84840 RVA: 0x0063CFA5 File Offset: 0x0063B3A5
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x06014B69 RID: 84841 RVA: 0x0063CFC8 File Offset: 0x0063B3C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4E2 RID: 58594
		private int method_p0;

		// Token: 0x0400E4E3 RID: 58595
		private int method_p1;
	}
}

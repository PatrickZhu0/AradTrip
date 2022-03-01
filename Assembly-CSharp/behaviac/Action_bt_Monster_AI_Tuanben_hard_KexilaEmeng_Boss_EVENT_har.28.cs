using System;

namespace behaviac
{
	// Token: 0x02003BFE RID: 15358
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node28 : Action
	{
		// Token: 0x06015FA8 RID: 90024 RVA: 0x006A356E File Offset: 0x006A196E
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
			this.method_p1 = 1;
		}

		// Token: 0x06015FA9 RID: 90025 RVA: 0x006A358B File Offset: 0x006A198B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F831 RID: 63537
		private int method_p0;

		// Token: 0x0400F832 RID: 63538
		private int method_p1;
	}
}

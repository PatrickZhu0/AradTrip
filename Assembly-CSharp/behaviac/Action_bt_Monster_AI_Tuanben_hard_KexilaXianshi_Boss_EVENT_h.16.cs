using System;

namespace behaviac
{
	// Token: 0x02003CD3 RID: 15571
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node91 : Action
	{
		// Token: 0x06016148 RID: 90440 RVA: 0x006AC8DF File Offset: 0x006AACDF
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node91()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06016149 RID: 90441 RVA: 0x006AC8F5 File Offset: 0x006AACF5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9FA RID: 63994
		private int method_p0;
	}
}

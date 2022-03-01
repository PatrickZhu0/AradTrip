using System;

namespace behaviac
{
	// Token: 0x02003CD7 RID: 15575
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node4 : Action
	{
		// Token: 0x06016150 RID: 90448 RVA: 0x006AC9E2 File Offset: 0x006AADE2
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06016151 RID: 90449 RVA: 0x006AC9F8 File Offset: 0x006AADF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA02 RID: 64002
		private int method_p0;
	}
}

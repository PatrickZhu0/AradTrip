using System;

namespace behaviac
{
	// Token: 0x02003CD9 RID: 15577
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node96 : Action
	{
		// Token: 0x06016154 RID: 90452 RVA: 0x006ACA52 File Offset: 0x006AAE52
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node96()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 0;
		}

		// Token: 0x06016155 RID: 90453 RVA: 0x006ACA6F File Offset: 0x006AAE6F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA04 RID: 64004
		private int method_p0;

		// Token: 0x0400FA05 RID: 64005
		private int method_p1;
	}
}

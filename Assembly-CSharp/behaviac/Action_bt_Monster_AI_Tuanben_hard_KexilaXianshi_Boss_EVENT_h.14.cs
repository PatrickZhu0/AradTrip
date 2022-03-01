using System;

namespace behaviac
{
	// Token: 0x02003CCF RID: 15567
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node46 : Action
	{
		// Token: 0x06016140 RID: 90432 RVA: 0x006AC7B6 File Offset: 0x006AABB6
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
		}

		// Token: 0x06016141 RID: 90433 RVA: 0x006AC7D7 File Offset: 0x006AABD7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9F1 RID: 63985
		private BE_Target method_p0;

		// Token: 0x0400F9F2 RID: 63986
		private int method_p1;
	}
}

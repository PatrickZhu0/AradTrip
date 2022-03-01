using System;

namespace behaviac
{
	// Token: 0x02002EF2 RID: 12018
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node20 : Action
	{
		// Token: 0x060146BC RID: 83644 RVA: 0x00624AC4 File Offset: 0x00622EC4
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x060146BD RID: 83645 RVA: 0x00624ADA File Offset: 0x00622EDA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E034 RID: 57396
		private int method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003084 RID: 12420
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node23 : Action
	{
		// Token: 0x060149CD RID: 84429 RVA: 0x00634A2D File Offset: 0x00632E2D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060149CE RID: 84430 RVA: 0x00634A43 File Offset: 0x00632E43
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E32B RID: 58155
		private DestinationType method_p0;
	}
}

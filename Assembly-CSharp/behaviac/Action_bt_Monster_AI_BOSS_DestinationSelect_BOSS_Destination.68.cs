using System;

namespace behaviac
{
	// Token: 0x02003078 RID: 12408
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node7 : Action
	{
		// Token: 0x060149B5 RID: 84405 RVA: 0x0063467D File Offset: 0x00632A7D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060149B6 RID: 84406 RVA: 0x00634693 File Offset: 0x00632A93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E313 RID: 58131
		private DestinationType method_p0;
	}
}

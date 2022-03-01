using System;

namespace behaviac
{
	// Token: 0x02003081 RID: 12417
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node19 : Action
	{
		// Token: 0x060149C7 RID: 84423 RVA: 0x00634941 File Offset: 0x00632D41
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060149C8 RID: 84424 RVA: 0x00634957 File Offset: 0x00632D57
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E325 RID: 58149
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002FFF RID: 12287
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node19 : Action
	{
		// Token: 0x060148C8 RID: 84168 RVA: 0x0062F791 File Offset: 0x0062DB91
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060148C9 RID: 84169 RVA: 0x0062F7A7 File Offset: 0x0062DBA7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E227 RID: 57895
		private DestinationType method_p0;
	}
}

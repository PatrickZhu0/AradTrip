using System;

namespace behaviac
{
	// Token: 0x02002FFC RID: 12284
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node15 : Action
	{
		// Token: 0x060148C2 RID: 84162 RVA: 0x0062F6A5 File Offset: 0x0062DAA5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060148C3 RID: 84163 RVA: 0x0062F6BB File Offset: 0x0062DABB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E221 RID: 57889
		private DestinationType method_p0;
	}
}

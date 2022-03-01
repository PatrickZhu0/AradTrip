using System;

namespace behaviac
{
	// Token: 0x02002FCC RID: 12236
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node15 : Action
	{
		// Token: 0x06014864 RID: 84068 RVA: 0x0062D85D File Offset: 0x0062BC5D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014865 RID: 84069 RVA: 0x0062D873 File Offset: 0x0062BC73
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1C3 RID: 57795
		private DestinationType method_p0;
	}
}

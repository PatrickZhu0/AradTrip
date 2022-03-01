using System;

namespace behaviac
{
	// Token: 0x02002FE1 RID: 12257
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node11 : Action
	{
		// Token: 0x0601488D RID: 84109 RVA: 0x0062E695 File Offset: 0x0062CA95
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601488E RID: 84110 RVA: 0x0062E6AB File Offset: 0x0062CAAB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1EC RID: 57836
		private DestinationType method_p0;
	}
}

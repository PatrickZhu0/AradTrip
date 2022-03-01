using System;

namespace behaviac
{
	// Token: 0x02002FDE RID: 12254
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node7 : Action
	{
		// Token: 0x06014887 RID: 84103 RVA: 0x0062E5A9 File Offset: 0x0062C9A9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014888 RID: 84104 RVA: 0x0062E5BF File Offset: 0x0062C9BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E6 RID: 57830
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002FC6 RID: 12230
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node7 : Action
	{
		// Token: 0x06014858 RID: 84056 RVA: 0x0062D685 File Offset: 0x0062BA85
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014859 RID: 84057 RVA: 0x0062D69B File Offset: 0x0062BA9B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B7 RID: 57783
		private DestinationType method_p0;
	}
}

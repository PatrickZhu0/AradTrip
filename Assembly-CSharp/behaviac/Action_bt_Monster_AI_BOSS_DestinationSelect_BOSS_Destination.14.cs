using System;

namespace behaviac
{
	// Token: 0x02002FD5 RID: 12245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node27 : Action
	{
		// Token: 0x06014876 RID: 84086 RVA: 0x0062DB21 File Offset: 0x0062BF21
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014877 RID: 84087 RVA: 0x0062DB37 File Offset: 0x0062BF37
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1D5 RID: 57813
		private DestinationType method_p0;
	}
}

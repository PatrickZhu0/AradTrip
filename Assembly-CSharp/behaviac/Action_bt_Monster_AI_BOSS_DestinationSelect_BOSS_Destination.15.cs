using System;

namespace behaviac
{
	// Token: 0x02002FD8 RID: 12248
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node31 : Action
	{
		// Token: 0x0601487C RID: 84092 RVA: 0x0062DC0D File Offset: 0x0062C00D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601487D RID: 84093 RVA: 0x0062DC23 File Offset: 0x0062C023
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1DB RID: 57819
		private DestinationType method_p0;
	}
}

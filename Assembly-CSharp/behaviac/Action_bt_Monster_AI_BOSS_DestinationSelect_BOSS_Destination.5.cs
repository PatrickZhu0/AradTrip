using System;

namespace behaviac
{
	// Token: 0x02002FBA RID: 12218
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node23 : Action
	{
		// Token: 0x06014841 RID: 84033 RVA: 0x0062CB11 File Offset: 0x0062AF11
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x06014842 RID: 84034 RVA: 0x0062CB27 File Offset: 0x0062AF27
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1A0 RID: 57760
		private DestinationType method_p0;
	}
}

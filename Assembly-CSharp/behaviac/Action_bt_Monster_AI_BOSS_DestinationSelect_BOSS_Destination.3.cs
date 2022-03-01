using System;

namespace behaviac
{
	// Token: 0x02002FB4 RID: 12212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node15 : Action
	{
		// Token: 0x06014835 RID: 84021 RVA: 0x0062C939 File Offset: 0x0062AD39
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014836 RID: 84022 RVA: 0x0062C94F File Offset: 0x0062AD4F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E194 RID: 57748
		private DestinationType method_p0;
	}
}

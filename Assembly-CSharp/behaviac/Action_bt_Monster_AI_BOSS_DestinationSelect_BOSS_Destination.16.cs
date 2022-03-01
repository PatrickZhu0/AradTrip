using System;

namespace behaviac
{
	// Token: 0x02002FDA RID: 12250
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node35 : Action
	{
		// Token: 0x06014880 RID: 84096 RVA: 0x0062DCB1 File Offset: 0x0062C0B1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014881 RID: 84097 RVA: 0x0062DCC7 File Offset: 0x0062C0C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E0 RID: 57824
		private DestinationType method_p0;
	}
}

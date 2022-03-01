using System;

namespace behaviac
{
	// Token: 0x02002FAE RID: 12206
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node7 : Action
	{
		// Token: 0x06014829 RID: 84009 RVA: 0x0062C761 File Offset: 0x0062AB61
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601482A RID: 84010 RVA: 0x0062C777 File Offset: 0x0062AB77
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E188 RID: 57736
		private DestinationType method_p0;
	}
}

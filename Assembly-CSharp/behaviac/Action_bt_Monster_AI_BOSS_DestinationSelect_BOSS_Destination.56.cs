using System;

namespace behaviac
{
	// Token: 0x02003053 RID: 12371
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node27 : Action
	{
		// Token: 0x0601496D RID: 84333 RVA: 0x00632A7D File Offset: 0x00630E7D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601496E RID: 84334 RVA: 0x00632A93 File Offset: 0x00630E93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2CC RID: 58060
		private DestinationType method_p0;
	}
}

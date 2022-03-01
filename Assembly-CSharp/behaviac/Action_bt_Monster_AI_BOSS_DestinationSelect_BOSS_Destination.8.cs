using System;

namespace behaviac
{
	// Token: 0x02002FC2 RID: 12226
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node35 : Action
	{
		// Token: 0x06014851 RID: 84049 RVA: 0x0062CD8D File Offset: 0x0062B18D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014852 RID: 84050 RVA: 0x0062CDA3 File Offset: 0x0062B1A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B1 RID: 57777
		private DestinationType method_p0;
	}
}

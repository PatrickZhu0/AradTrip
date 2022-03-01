using System;

namespace behaviac
{
	// Token: 0x0200309F RID: 12447
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node23 : Action
	{
		// Token: 0x06014A02 RID: 84482 RVA: 0x00635B25 File Offset: 0x00633F25
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014A03 RID: 84483 RVA: 0x00635B3B File Offset: 0x00633F3B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E360 RID: 58208
		private DestinationType method_p0;
	}
}

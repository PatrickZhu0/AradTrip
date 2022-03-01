using System;

namespace behaviac
{
	// Token: 0x020030A5 RID: 12453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node31 : Action
	{
		// Token: 0x06014A0E RID: 84494 RVA: 0x00635CFD File Offset: 0x006340FD
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014A0F RID: 84495 RVA: 0x00635D13 File Offset: 0x00634113
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E36C RID: 58220
		private DestinationType method_p0;
	}
}

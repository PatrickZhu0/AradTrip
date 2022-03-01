using System;

namespace behaviac
{
	// Token: 0x020030A8 RID: 12456
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node35 : Action
	{
		// Token: 0x06014A14 RID: 84500 RVA: 0x00635DE9 File Offset: 0x006341E9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x06014A15 RID: 84501 RVA: 0x00635DFF File Offset: 0x006341FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E372 RID: 58226
		private DestinationType method_p0;
	}
}

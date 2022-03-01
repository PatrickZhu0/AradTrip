using System;

namespace behaviac
{
	// Token: 0x020030A2 RID: 12450
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node27 : Action
	{
		// Token: 0x06014A08 RID: 84488 RVA: 0x00635C11 File Offset: 0x00634011
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014A09 RID: 84489 RVA: 0x00635C27 File Offset: 0x00634027
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E366 RID: 58214
		private DestinationType method_p0;
	}
}

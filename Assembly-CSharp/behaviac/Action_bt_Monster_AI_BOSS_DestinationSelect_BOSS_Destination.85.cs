using System;

namespace behaviac
{
	// Token: 0x020030AA RID: 12458
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node39 : Action
	{
		// Token: 0x06014A18 RID: 84504 RVA: 0x00635E8D File Offset: 0x0063428D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014A19 RID: 84505 RVA: 0x00635EA3 File Offset: 0x006342A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E377 RID: 58231
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003059 RID: 12377
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node35 : Action
	{
		// Token: 0x06014979 RID: 84345 RVA: 0x00632C55 File Offset: 0x00631055
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601497A RID: 84346 RVA: 0x00632C6B File Offset: 0x0063106B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2D8 RID: 58072
		private DestinationType method_p0;
	}
}

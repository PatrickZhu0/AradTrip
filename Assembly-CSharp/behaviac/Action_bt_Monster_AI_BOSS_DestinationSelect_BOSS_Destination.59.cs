using System;

namespace behaviac
{
	// Token: 0x0200305B RID: 12379
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node39 : Action
	{
		// Token: 0x0601497D RID: 84349 RVA: 0x00632CF9 File Offset: 0x006310F9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x0601497E RID: 84350 RVA: 0x00632D0F File Offset: 0x0063110F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2DD RID: 58077
		private DestinationType method_p0;
	}
}

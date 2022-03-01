using System;

namespace behaviac
{
	// Token: 0x0200306B RID: 12395
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node23 : Action
	{
		// Token: 0x0601499C RID: 84380 RVA: 0x00633A89 File Offset: 0x00631E89
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x0601499D RID: 84381 RVA: 0x00633A9F File Offset: 0x00631E9F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2FB RID: 58107
		private DestinationType method_p0;
	}
}

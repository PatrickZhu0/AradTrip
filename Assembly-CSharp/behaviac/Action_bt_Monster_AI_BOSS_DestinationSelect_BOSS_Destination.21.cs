using System;

namespace behaviac
{
	// Token: 0x02002FEA RID: 12266
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node23 : Action
	{
		// Token: 0x0601489F RID: 84127 RVA: 0x0062E959 File Offset: 0x0062CD59
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x060148A0 RID: 84128 RVA: 0x0062E96F File Offset: 0x0062CD6F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1FE RID: 57854
		private DestinationType method_p0;
	}
}

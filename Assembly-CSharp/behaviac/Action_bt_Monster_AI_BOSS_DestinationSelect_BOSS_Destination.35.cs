using System;

namespace behaviac
{
	// Token: 0x02003014 RID: 12308
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node15 : Action
	{
		// Token: 0x060148F1 RID: 84209 RVA: 0x006305C9 File Offset: 0x0062E9C9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060148F2 RID: 84210 RVA: 0x006305DF File Offset: 0x0062E9DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E250 RID: 57936
		private DestinationType method_p0;
	}
}

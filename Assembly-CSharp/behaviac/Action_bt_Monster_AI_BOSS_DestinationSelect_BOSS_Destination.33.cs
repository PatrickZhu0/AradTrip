using System;

namespace behaviac
{
	// Token: 0x0200300E RID: 12302
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node7 : Action
	{
		// Token: 0x060148E5 RID: 84197 RVA: 0x006303F1 File Offset: 0x0062E7F1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060148E6 RID: 84198 RVA: 0x00630407 File Offset: 0x0062E807
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E244 RID: 57924
		private DestinationType method_p0;
	}
}

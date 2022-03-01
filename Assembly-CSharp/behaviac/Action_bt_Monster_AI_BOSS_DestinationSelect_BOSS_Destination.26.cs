using System;

namespace behaviac
{
	// Token: 0x02002FF9 RID: 12281
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node11 : Action
	{
		// Token: 0x060148BC RID: 84156 RVA: 0x0062F5B9 File Offset: 0x0062D9B9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060148BD RID: 84157 RVA: 0x0062F5CF File Offset: 0x0062D9CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E21B RID: 57883
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003008 RID: 12296
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node31 : Action
	{
		// Token: 0x060148DA RID: 84186 RVA: 0x0062FA55 File Offset: 0x0062DE55
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060148DB RID: 84187 RVA: 0x0062FA6B File Offset: 0x0062DE6B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E239 RID: 57913
		private DestinationType method_p0;
	}
}

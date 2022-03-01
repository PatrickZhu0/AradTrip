using System;

namespace behaviac
{
	// Token: 0x02003005 RID: 12293
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node27 : Action
	{
		// Token: 0x060148D4 RID: 84180 RVA: 0x0062F969 File Offset: 0x0062DD69
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060148D5 RID: 84181 RVA: 0x0062F97F File Offset: 0x0062DD7F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E233 RID: 57907
		private DestinationType method_p0;
	}
}

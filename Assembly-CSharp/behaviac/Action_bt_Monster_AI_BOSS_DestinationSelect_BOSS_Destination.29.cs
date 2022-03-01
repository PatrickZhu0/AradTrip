using System;

namespace behaviac
{
	// Token: 0x02003002 RID: 12290
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node23 : Action
	{
		// Token: 0x060148CE RID: 84174 RVA: 0x0062F87D File Offset: 0x0062DC7D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x060148CF RID: 84175 RVA: 0x0062F893 File Offset: 0x0062DC93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E22D RID: 57901
		private DestinationType method_p0;
	}
}

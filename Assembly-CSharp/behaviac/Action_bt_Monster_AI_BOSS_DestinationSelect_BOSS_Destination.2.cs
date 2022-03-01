using System;

namespace behaviac
{
	// Token: 0x02002FB1 RID: 12209
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node11 : Action
	{
		// Token: 0x0601482F RID: 84015 RVA: 0x0062C84D File Offset: 0x0062AC4D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014830 RID: 84016 RVA: 0x0062C863 File Offset: 0x0062AC63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E18E RID: 57742
		private DestinationType method_p0;
	}
}

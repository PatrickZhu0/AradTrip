using System;

namespace behaviac
{
	// Token: 0x02002FB7 RID: 12215
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node19 : Action
	{
		// Token: 0x0601483B RID: 84027 RVA: 0x0062CA25 File Offset: 0x0062AE25
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601483C RID: 84028 RVA: 0x0062CA3B File Offset: 0x0062AE3B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E19A RID: 57754
		private DestinationType method_p0;
	}
}

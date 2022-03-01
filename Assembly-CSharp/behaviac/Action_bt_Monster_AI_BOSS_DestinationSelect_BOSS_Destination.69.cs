using System;

namespace behaviac
{
	// Token: 0x0200307B RID: 12411
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node11 : Action
	{
		// Token: 0x060149BB RID: 84411 RVA: 0x00634769 File Offset: 0x00632B69
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060149BC RID: 84412 RVA: 0x0063477F File Offset: 0x00632B7F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E319 RID: 58137
		private DestinationType method_p0;
	}
}

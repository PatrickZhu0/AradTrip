using System;

namespace behaviac
{
	// Token: 0x0200307E RID: 12414
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node15 : Action
	{
		// Token: 0x060149C1 RID: 84417 RVA: 0x00634855 File Offset: 0x00632C55
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060149C2 RID: 84418 RVA: 0x0063486B File Offset: 0x00632C6B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E31F RID: 58143
		private DestinationType method_p0;
	}
}

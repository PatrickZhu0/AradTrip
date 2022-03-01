using System;

namespace behaviac
{
	// Token: 0x0200308F RID: 12431
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node39 : Action
	{
		// Token: 0x060149E3 RID: 84451 RVA: 0x00634D95 File Offset: 0x00633195
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060149E4 RID: 84452 RVA: 0x00634DAB File Offset: 0x006331AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E342 RID: 58178
		private DestinationType method_p0;
	}
}

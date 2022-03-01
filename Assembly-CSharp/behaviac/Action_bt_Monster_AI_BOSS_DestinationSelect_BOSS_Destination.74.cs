using System;

namespace behaviac
{
	// Token: 0x0200308A RID: 12426
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node31 : Action
	{
		// Token: 0x060149D9 RID: 84441 RVA: 0x00634C05 File Offset: 0x00633005
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060149DA RID: 84442 RVA: 0x00634C1B File Offset: 0x0063301B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E337 RID: 58167
		private DestinationType method_p0;
	}
}

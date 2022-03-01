using System;

namespace behaviac
{
	// Token: 0x02003087 RID: 12423
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node27 : Action
	{
		// Token: 0x060149D3 RID: 84435 RVA: 0x00634B19 File Offset: 0x00632F19
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060149D4 RID: 84436 RVA: 0x00634B2F File Offset: 0x00632F2F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E331 RID: 58161
		private DestinationType method_p0;
	}
}

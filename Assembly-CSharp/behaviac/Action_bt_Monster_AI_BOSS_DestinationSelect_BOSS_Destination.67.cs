using System;

namespace behaviac
{
	// Token: 0x02003074 RID: 12404
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node35 : Action
	{
		// Token: 0x060149AE RID: 84398 RVA: 0x00633D4D File Offset: 0x0063214D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x060149AF RID: 84399 RVA: 0x00633D63 File Offset: 0x00632163
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E30D RID: 58125
		private DestinationType method_p0;
	}
}

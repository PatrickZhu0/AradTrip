using System;

namespace behaviac
{
	// Token: 0x02003099 RID: 12441
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node15 : Action
	{
		// Token: 0x060149F6 RID: 84470 RVA: 0x0063594D File Offset: 0x00633D4D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060149F7 RID: 84471 RVA: 0x00635963 File Offset: 0x00633D63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E354 RID: 58196
		private DestinationType method_p0;
	}
}

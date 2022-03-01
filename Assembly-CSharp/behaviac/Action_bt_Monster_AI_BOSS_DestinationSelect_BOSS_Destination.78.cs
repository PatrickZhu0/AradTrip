using System;

namespace behaviac
{
	// Token: 0x02003096 RID: 12438
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node11 : Action
	{
		// Token: 0x060149F0 RID: 84464 RVA: 0x00635861 File Offset: 0x00633C61
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060149F1 RID: 84465 RVA: 0x00635877 File Offset: 0x00633C77
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E34E RID: 58190
		private DestinationType method_p0;
	}
}

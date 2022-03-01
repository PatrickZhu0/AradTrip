using System;

namespace behaviac
{
	// Token: 0x02002FED RID: 12269
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node27 : Action
	{
		// Token: 0x060148A5 RID: 84133 RVA: 0x0062EA45 File Offset: 0x0062CE45
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060148A6 RID: 84134 RVA: 0x0062EA5B File Offset: 0x0062CE5B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E204 RID: 57860
		private DestinationType method_p0;
	}
}

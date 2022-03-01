using System;

namespace behaviac
{
	// Token: 0x02003363 RID: 13155
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node14 : Action
	{
		// Token: 0x06014F25 RID: 85797 RVA: 0x0064F949 File Offset: 0x0064DD49
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER_IN_CIRCLE;
		}

		// Token: 0x06014F26 RID: 85798 RVA: 0x0064F960 File Offset: 0x0064DD60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F7 RID: 59383
		private DestinationType method_p0;
	}
}

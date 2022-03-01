using System;

namespace behaviac
{
	// Token: 0x02003360 RID: 13152
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node0 : Action
	{
		// Token: 0x06014F1F RID: 85791 RVA: 0x0064F8A0 File Offset: 0x0064DCA0
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER_IN_CIRCLE;
		}

		// Token: 0x06014F20 RID: 85792 RVA: 0x0064F8B7 File Offset: 0x0064DCB7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F5 RID: 59381
		private DestinationType method_p0;
	}
}

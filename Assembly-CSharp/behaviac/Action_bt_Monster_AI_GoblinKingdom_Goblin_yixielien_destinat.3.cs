using System;

namespace behaviac
{
	// Token: 0x02003366 RID: 13158
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node6 : Action
	{
		// Token: 0x06014F2B RID: 85803 RVA: 0x0064FA07 File Offset: 0x0064DE07
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014F2C RID: 85804 RVA: 0x0064FA1D File Offset: 0x0064DE1D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FA RID: 59386
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003369 RID: 13161
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node19 : Action
	{
		// Token: 0x06014F31 RID: 85809 RVA: 0x0064FAC3 File Offset: 0x0064DEC3
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014F32 RID: 85810 RVA: 0x0064FAD9 File Offset: 0x0064DED9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FD RID: 59389
		private DestinationType method_p0;
	}
}

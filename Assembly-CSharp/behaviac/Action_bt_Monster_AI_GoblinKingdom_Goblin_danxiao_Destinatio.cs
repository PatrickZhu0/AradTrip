using System;

namespace behaviac
{
	// Token: 0x020032F9 RID: 13049
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node21 : Action
	{
		// Token: 0x06014E5C RID: 85596 RVA: 0x0064C04F File Offset: 0x0064A44F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014E5D RID: 85597 RVA: 0x0064C065 File Offset: 0x0064A465
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E749 RID: 59209
		private DestinationType method_p0;
	}
}

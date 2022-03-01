using System;

namespace behaviac
{
	// Token: 0x020032FD RID: 13053
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node4 : Action
	{
		// Token: 0x06014E64 RID: 85604 RVA: 0x0064C187 File Offset: 0x0064A587
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014E65 RID: 85605 RVA: 0x0064C19D File Offset: 0x0064A59D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E752 RID: 59218
		private DestinationType method_p0;
	}
}

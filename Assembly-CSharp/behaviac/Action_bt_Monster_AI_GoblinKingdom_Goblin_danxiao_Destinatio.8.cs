using System;

namespace behaviac
{
	// Token: 0x02003308 RID: 13064
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node1 : Action
	{
		// Token: 0x06014E7A RID: 85626 RVA: 0x0064C4C5 File Offset: 0x0064A8C5
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014E7B RID: 85627 RVA: 0x0064C4DB File Offset: 0x0064A8DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E768 RID: 59240
		private DestinationType method_p0;
	}
}

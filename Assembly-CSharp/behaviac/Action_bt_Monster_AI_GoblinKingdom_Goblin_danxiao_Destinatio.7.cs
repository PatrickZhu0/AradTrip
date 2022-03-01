using System;

namespace behaviac
{
	// Token: 0x02003307 RID: 13063
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node15 : Action
	{
		// Token: 0x06014E78 RID: 85624 RVA: 0x0064C49B File Offset: 0x0064A89B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014E79 RID: 85625 RVA: 0x0064C4B1 File Offset: 0x0064A8B1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E767 RID: 59239
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003341 RID: 13121
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node30 : Action
	{
		// Token: 0x06014EE6 RID: 85734 RVA: 0x0064E50B File Offset: 0x0064C90B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014EE7 RID: 85735 RVA: 0x0064E521 File Offset: 0x0064C921
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CB RID: 59339
		private DestinationType method_p0;
	}
}

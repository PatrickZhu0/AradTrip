using System;

namespace behaviac
{
	// Token: 0x02003320 RID: 13088
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node15 : Action
	{
		// Token: 0x06014EA7 RID: 85671 RVA: 0x0064D32B File Offset: 0x0064B72B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014EA8 RID: 85672 RVA: 0x0064D341 File Offset: 0x0064B741
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E796 RID: 59286
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200331A RID: 13082
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node9 : Action
	{
		// Token: 0x06014E9B RID: 85659 RVA: 0x0064D153 File Offset: 0x0064B553
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014E9C RID: 85660 RVA: 0x0064D169 File Offset: 0x0064B569
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E78A RID: 59274
		private DestinationType method_p0;
	}
}

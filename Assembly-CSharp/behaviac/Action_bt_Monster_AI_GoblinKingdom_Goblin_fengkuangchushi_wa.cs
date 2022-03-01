using System;

namespace behaviac
{
	// Token: 0x02003317 RID: 13079
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4 : Action
	{
		// Token: 0x06014E95 RID: 85653 RVA: 0x0064D067 File Offset: 0x0064B467
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014E96 RID: 85654 RVA: 0x0064D07D File Offset: 0x0064B47D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E784 RID: 59268
		private DestinationType method_p0;
	}
}

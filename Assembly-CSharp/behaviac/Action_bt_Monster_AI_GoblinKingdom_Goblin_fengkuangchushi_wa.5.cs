using System;

namespace behaviac
{
	// Token: 0x02003321 RID: 13089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node1 : Action
	{
		// Token: 0x06014EA9 RID: 85673 RVA: 0x0064D355 File Offset: 0x0064B755
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014EAA RID: 85674 RVA: 0x0064D36B File Offset: 0x0064B76B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E797 RID: 59287
		private DestinationType method_p0;
	}
}

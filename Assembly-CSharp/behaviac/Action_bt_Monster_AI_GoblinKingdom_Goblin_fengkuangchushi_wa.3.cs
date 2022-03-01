using System;

namespace behaviac
{
	// Token: 0x0200331D RID: 13085
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node10 : Action
	{
		// Token: 0x06014EA1 RID: 85665 RVA: 0x0064D23F File Offset: 0x0064B63F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014EA2 RID: 85666 RVA: 0x0064D255 File Offset: 0x0064B655
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E790 RID: 59280
		private DestinationType method_p0;
	}
}

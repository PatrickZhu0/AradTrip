using System;

namespace behaviac
{
	// Token: 0x0200333A RID: 13114
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node25 : Action
	{
		// Token: 0x06014ED8 RID: 85720 RVA: 0x0064E33F File Offset: 0x0064C73F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014ED9 RID: 85721 RVA: 0x0064E355 File Offset: 0x0064C755
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C1 RID: 59329
		private DestinationType method_p0;
	}
}

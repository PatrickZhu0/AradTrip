using System;

namespace behaviac
{
	// Token: 0x02003300 RID: 13056
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node9 : Action
	{
		// Token: 0x06014E6A RID: 85610 RVA: 0x0064C277 File Offset: 0x0064A677
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014E6B RID: 85611 RVA: 0x0064C28D File Offset: 0x0064A68D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E758 RID: 59224
		private DestinationType method_p0;
	}
}

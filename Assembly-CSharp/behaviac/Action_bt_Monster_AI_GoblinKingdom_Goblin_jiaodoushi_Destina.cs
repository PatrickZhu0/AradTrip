using System;

namespace behaviac
{
	// Token: 0x02003336 RID: 13110
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node6 : Action
	{
		// Token: 0x06014ED0 RID: 85712 RVA: 0x0064E1D3 File Offset: 0x0064C5D3
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014ED1 RID: 85713 RVA: 0x0064E1E9 File Offset: 0x0064C5E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7B7 RID: 59319
		private DestinationType method_p0;
	}
}

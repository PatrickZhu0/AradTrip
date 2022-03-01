using System;

namespace behaviac
{
	// Token: 0x02001E27 RID: 7719
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node3 : Action
	{
		// Token: 0x060125FE RID: 75262 RVA: 0x0055E56B File Offset: 0x0055C96B
		public Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060125FF RID: 75263 RVA: 0x0055E581 File Offset: 0x0055C981
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFE9 RID: 49129
		private DestinationType method_p0;
	}
}

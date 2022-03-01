using System;

namespace behaviac
{
	// Token: 0x02001EC4 RID: 7876
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node3 : Action
	{
		// Token: 0x0601272F RID: 75567 RVA: 0x00565A37 File Offset: 0x00563E37
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06012730 RID: 75568 RVA: 0x00565A4D File Offset: 0x00563E4D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C11E RID: 49438
		private DestinationType method_p0;
	}
}

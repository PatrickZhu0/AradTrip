using System;

namespace behaviac
{
	// Token: 0x02001E2D RID: 7725
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node15 : Action
	{
		// Token: 0x0601260A RID: 75274 RVA: 0x0055E6BB File Offset: 0x0055CABB
		public Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601260B RID: 75275 RVA: 0x0055E6D1 File Offset: 0x0055CAD1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFEF RID: 49135
		private DestinationType method_p0;
	}
}

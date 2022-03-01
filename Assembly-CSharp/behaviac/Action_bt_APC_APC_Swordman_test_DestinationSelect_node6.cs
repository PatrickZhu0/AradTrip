using System;

namespace behaviac
{
	// Token: 0x02001E10 RID: 7696
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_DestinationSelect_node6 : Action
	{
		// Token: 0x060125D2 RID: 75218 RVA: 0x0055D57F File Offset: 0x0055B97F
		public Action_bt_APC_APC_Swordman_test_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060125D3 RID: 75219 RVA: 0x0055D595 File Offset: 0x0055B995
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFBD RID: 49085
		private DestinationType method_p0;
	}
}

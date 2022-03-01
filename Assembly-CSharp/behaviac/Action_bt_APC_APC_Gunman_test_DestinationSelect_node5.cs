using System;

namespace behaviac
{
	// Token: 0x02001D48 RID: 7496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_DestinationSelect_node5 : Action
	{
		// Token: 0x06012450 RID: 74832 RVA: 0x0055473B File Offset: 0x00552B3B
		public Action_bt_APC_APC_Gunman_test_DestinationSelect_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06012451 RID: 74833 RVA: 0x00554751 File Offset: 0x00552B51
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE43 RID: 48707
		private DestinationType method_p0;
	}
}

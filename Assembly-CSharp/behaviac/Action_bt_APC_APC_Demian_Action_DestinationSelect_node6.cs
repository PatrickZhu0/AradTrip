using System;

namespace behaviac
{
	// Token: 0x02001D0E RID: 7438
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_DestinationSelect_node6 : Action
	{
		// Token: 0x060123E0 RID: 74720 RVA: 0x00551543 File Offset: 0x0054F943
		public Action_bt_APC_APC_Demian_Action_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060123E1 RID: 74721 RVA: 0x00551559 File Offset: 0x0054F959
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDD5 RID: 48597
		private DestinationType method_p0;
	}
}

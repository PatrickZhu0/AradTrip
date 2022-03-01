using System;

namespace behaviac
{
	// Token: 0x02001D4B RID: 7499
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_DestinationSelect_node3 : Action
	{
		// Token: 0x06012456 RID: 74838 RVA: 0x005547D5 File Offset: 0x00552BD5
		public Action_bt_APC_APC_Gunman_test_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06012457 RID: 74839 RVA: 0x005547EB File Offset: 0x00552BEB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE46 RID: 48710
		private DestinationType method_p0;
	}
}

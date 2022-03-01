using System;

namespace behaviac
{
	// Token: 0x02001D4A RID: 7498
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_DestinationSelect_node7 : Action
	{
		// Token: 0x06012454 RID: 74836 RVA: 0x005547AB File Offset: 0x00552BAB
		public Action_bt_APC_APC_Gunman_test_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06012455 RID: 74837 RVA: 0x005547C1 File Offset: 0x00552BC1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE45 RID: 48709
		private DestinationType method_p0;
	}
}

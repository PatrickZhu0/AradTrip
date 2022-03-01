using System;

namespace behaviac
{
	// Token: 0x02001E11 RID: 7697
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Swordman_test_DestinationSelect_node7 : Action
	{
		// Token: 0x060125D4 RID: 75220 RVA: 0x0055D5A9 File Offset: 0x0055B9A9
		public Action_bt_APC_APC_Swordman_test_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060125D5 RID: 75221 RVA: 0x0055D5BF File Offset: 0x0055B9BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFBE RID: 49086
		private DestinationType method_p0;
	}
}

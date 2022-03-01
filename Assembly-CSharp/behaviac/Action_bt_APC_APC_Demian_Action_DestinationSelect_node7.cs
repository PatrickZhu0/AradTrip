using System;

namespace behaviac
{
	// Token: 0x02001D0F RID: 7439
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x060123E2 RID: 74722 RVA: 0x0055156D File Offset: 0x0054F96D
		public Action_bt_APC_APC_Demian_Action_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060123E3 RID: 74723 RVA: 0x00551583 File Offset: 0x0054F983
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDD6 RID: 48598
		private DestinationType method_p0;
	}
}

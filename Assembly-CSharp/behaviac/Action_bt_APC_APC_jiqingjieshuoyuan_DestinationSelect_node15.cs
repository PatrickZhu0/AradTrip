using System;

namespace behaviac
{
	// Token: 0x02001D7C RID: 7548
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node15 : Action
	{
		// Token: 0x060124B4 RID: 74932 RVA: 0x00556797 File Offset: 0x00554B97
		public Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060124B5 RID: 74933 RVA: 0x005567AD File Offset: 0x00554BAD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9F RID: 48799
		private DestinationType method_p0;
	}
}

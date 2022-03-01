using System;

namespace behaviac
{
	// Token: 0x02001D78 RID: 7544
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node6 : Action
	{
		// Token: 0x060124AC RID: 74924 RVA: 0x005566B7 File Offset: 0x00554AB7
		public Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060124AD RID: 74925 RVA: 0x005566CD File Offset: 0x00554ACD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9B RID: 48795
		private DestinationType method_p0;
	}
}

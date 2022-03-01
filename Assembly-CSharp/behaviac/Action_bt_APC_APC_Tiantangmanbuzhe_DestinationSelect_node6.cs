using System;

namespace behaviac
{
	// Token: 0x02001E29 RID: 7721
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node6 : Action
	{
		// Token: 0x06012602 RID: 75266 RVA: 0x0055E5DB File Offset: 0x0055C9DB
		public Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06012603 RID: 75267 RVA: 0x0055E5F1 File Offset: 0x0055C9F1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFEB RID: 49131
		private DestinationType method_p0;
	}
}

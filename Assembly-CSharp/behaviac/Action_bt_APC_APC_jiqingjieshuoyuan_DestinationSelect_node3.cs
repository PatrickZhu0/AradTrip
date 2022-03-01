using System;

namespace behaviac
{
	// Token: 0x02001D76 RID: 7542
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node3 : Action
	{
		// Token: 0x060124A8 RID: 74920 RVA: 0x00556647 File Offset: 0x00554A47
		public Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060124A9 RID: 74921 RVA: 0x0055665D File Offset: 0x00554A5D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE99 RID: 48793
		private DestinationType method_p0;
	}
}

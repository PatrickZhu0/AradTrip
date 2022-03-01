using System;

namespace behaviac
{
	// Token: 0x02001D7A RID: 7546
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node12 : Action
	{
		// Token: 0x060124B0 RID: 74928 RVA: 0x00556727 File Offset: 0x00554B27
		public Action_bt_APC_APC_jiqingjieshuoyuan_DestinationSelect_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060124B1 RID: 74929 RVA: 0x0055673D File Offset: 0x00554B3D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE9D RID: 48797
		private DestinationType method_p0;
	}
}

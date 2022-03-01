using System;

namespace behaviac
{
	// Token: 0x02001DF5 RID: 7669
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node6 : Action
	{
		// Token: 0x0601259F RID: 75167 RVA: 0x0055C12B File Offset: 0x0055A52B
		public Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060125A0 RID: 75168 RVA: 0x0055C141 File Offset: 0x0055A541
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF93 RID: 49043
		private DestinationType method_p0;
	}
}

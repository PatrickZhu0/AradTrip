using System;

namespace behaviac
{
	// Token: 0x02001E2B RID: 7723
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node12 : Action
	{
		// Token: 0x06012606 RID: 75270 RVA: 0x0055E64B File Offset: 0x0055CA4B
		public Action_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06012607 RID: 75271 RVA: 0x0055E661 File Offset: 0x0055CA61
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFED RID: 49133
		private DestinationType method_p0;
	}
}

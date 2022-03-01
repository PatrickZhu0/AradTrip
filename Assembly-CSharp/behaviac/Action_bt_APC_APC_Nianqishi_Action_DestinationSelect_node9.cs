using System;

namespace behaviac
{
	// Token: 0x02001DF1 RID: 7665
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node9 : Action
	{
		// Token: 0x06012597 RID: 75159 RVA: 0x0055C035 File Offset: 0x0055A435
		public Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06012598 RID: 75160 RVA: 0x0055C04B File Offset: 0x0055A44B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF8D RID: 49037
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02001DF6 RID: 7670
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x060125A1 RID: 75169 RVA: 0x0055C155 File Offset: 0x0055A555
		public Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060125A2 RID: 75170 RVA: 0x0055C16B File Offset: 0x0055A56B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF94 RID: 49044
		private DestinationType method_p0;
	}
}

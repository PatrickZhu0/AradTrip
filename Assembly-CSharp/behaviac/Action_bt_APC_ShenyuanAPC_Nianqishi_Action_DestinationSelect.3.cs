using System;

namespace behaviac
{
	// Token: 0x02001EC8 RID: 7880
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x06012737 RID: 75575 RVA: 0x00565B50 File Offset: 0x00563F50
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06012738 RID: 75576 RVA: 0x00565B66 File Offset: 0x00563F66
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C125 RID: 49445
		private DestinationType method_p0;
	}
}

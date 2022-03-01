using System;

namespace behaviac
{
	// Token: 0x02001EC6 RID: 7878
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node6 : Action
	{
		// Token: 0x06012733 RID: 75571 RVA: 0x00565AA7 File Offset: 0x00563EA7
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06012734 RID: 75572 RVA: 0x00565ABD File Offset: 0x00563EBD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C120 RID: 49440
		private DestinationType method_p0;
	}
}

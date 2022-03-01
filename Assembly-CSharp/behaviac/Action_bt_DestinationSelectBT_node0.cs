using System;

namespace behaviac
{
	// Token: 0x020040D3 RID: 16595
	[GeneratedTypeMetaInfo]
	internal class Action_bt_DestinationSelectBT_node0 : Action
	{
		// Token: 0x060168FB RID: 92411 RVA: 0x006D518A File Offset: 0x006D358A
		public Action_bt_DestinationSelectBT_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060168FC RID: 92412 RVA: 0x006D51A0 File Offset: 0x006D35A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401013A RID: 65850
		private DestinationType method_p0;
	}
}

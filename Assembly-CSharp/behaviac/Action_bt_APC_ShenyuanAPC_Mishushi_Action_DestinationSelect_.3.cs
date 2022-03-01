using System;

namespace behaviac
{
	// Token: 0x02001EA7 RID: 7847
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node10 : Action
	{
		// Token: 0x060126F7 RID: 75511 RVA: 0x005644F0 File Offset: 0x005628F0
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060126F8 RID: 75512 RVA: 0x00564506 File Offset: 0x00562906
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0E5 RID: 49381
		private DestinationType method_p0;
	}
}

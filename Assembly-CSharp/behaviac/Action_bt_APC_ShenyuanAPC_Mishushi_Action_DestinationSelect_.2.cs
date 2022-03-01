using System;

namespace behaviac
{
	// Token: 0x02001EA5 RID: 7845
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node15 : Action
	{
		// Token: 0x060126F3 RID: 75507 RVA: 0x00564447 File Offset: 0x00562847
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060126F4 RID: 75508 RVA: 0x0056445D File Offset: 0x0056285D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0E0 RID: 49376
		private DestinationType method_p0;
	}
}

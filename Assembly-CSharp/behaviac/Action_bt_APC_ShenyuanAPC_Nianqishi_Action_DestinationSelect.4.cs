using System;

namespace behaviac
{
	// Token: 0x02001ECA RID: 7882
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node16 : Action
	{
		// Token: 0x0601273B RID: 75579 RVA: 0x00565BF5 File Offset: 0x00563FF5
		public Action_bt_APC_ShenyuanAPC_Nianqishi_Action_DestinationSelect_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x0601273C RID: 75580 RVA: 0x00565C0B File Offset: 0x0056400B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C12A RID: 49450
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02001D0C RID: 7436
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_DestinationSelect_node3 : Action
	{
		// Token: 0x060123DC RID: 74716 RVA: 0x005514D3 File Offset: 0x0054F8D3
		public Action_bt_APC_APC_Demian_Action_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060123DD RID: 74717 RVA: 0x005514E9 File Offset: 0x0054F8E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDD3 RID: 48595
		private DestinationType method_p0;
	}
}

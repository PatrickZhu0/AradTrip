using System;

namespace behaviac
{
	// Token: 0x02001DD6 RID: 7638
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node7 : Action
	{
		// Token: 0x06012563 RID: 75107 RVA: 0x0055AC01 File Offset: 0x00559001
		public Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06012564 RID: 75108 RVA: 0x0055AC17 File Offset: 0x00559017
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF55 RID: 48981
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02001DD5 RID: 7637
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node6 : Action
	{
		// Token: 0x06012561 RID: 75105 RVA: 0x0055ABD7 File Offset: 0x00558FD7
		public Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06012562 RID: 75106 RVA: 0x0055ABED File Offset: 0x00558FED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF54 RID: 48980
		private DestinationType method_p0;
	}
}

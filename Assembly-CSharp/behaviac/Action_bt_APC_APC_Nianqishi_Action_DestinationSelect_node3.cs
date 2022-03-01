using System;

namespace behaviac
{
	// Token: 0x02001DF3 RID: 7667
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node3 : Action
	{
		// Token: 0x0601259B RID: 75163 RVA: 0x0055C0BB File Offset: 0x0055A4BB
		public Action_bt_APC_APC_Nianqishi_Action_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x0601259C RID: 75164 RVA: 0x0055C0D1 File Offset: 0x0055A4D1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF91 RID: 49041
		private DestinationType method_p0;
	}
}

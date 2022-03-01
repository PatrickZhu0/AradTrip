using System;

namespace behaviac
{
	// Token: 0x02001DD3 RID: 7635
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node3 : Action
	{
		// Token: 0x0601255D RID: 75101 RVA: 0x0055AB67 File Offset: 0x00558F67
		public Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x0601255E RID: 75102 RVA: 0x0055AB7D File Offset: 0x00558F7D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF52 RID: 48978
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02001DD1 RID: 7633
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node9 : Action
	{
		// Token: 0x06012559 RID: 75097 RVA: 0x0055AAE1 File Offset: 0x00558EE1
		public Action_bt_APC_APC_Mishushi_Action_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x0601255A RID: 75098 RVA: 0x0055AAF7 File Offset: 0x00558EF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF4E RID: 48974
		private DestinationType method_p0;
	}
}

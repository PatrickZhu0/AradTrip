using System;

namespace behaviac
{
	// Token: 0x02001D5E RID: 7518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node3 : Action
	{
		// Token: 0x0601247A RID: 74874 RVA: 0x0055562D File Offset: 0x00553A2D
		public Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601247B RID: 74875 RVA: 0x00555643 File Offset: 0x00553A43
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE6A RID: 48746
		private DestinationType method_p0;
	}
}

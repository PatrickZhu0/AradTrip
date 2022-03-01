using System;

namespace behaviac
{
	// Token: 0x02001D5F RID: 7519
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node5 : Action
	{
		// Token: 0x0601247C RID: 74876 RVA: 0x00555657 File Offset: 0x00553A57
		public Action_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FINAL_DOOR;
		}

		// Token: 0x0601247D RID: 74877 RVA: 0x0055566D File Offset: 0x00553A6D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE6B RID: 48747
		private DestinationType method_p0;
	}
}

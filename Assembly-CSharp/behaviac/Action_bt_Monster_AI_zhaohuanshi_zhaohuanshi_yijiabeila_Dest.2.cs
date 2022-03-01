using System;

namespace behaviac
{
	// Token: 0x02004013 RID: 16403
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node10 : Action
	{
		// Token: 0x06016789 RID: 92041 RVA: 0x006CD0BD File Offset: 0x006CB4BD
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601678A RID: 92042 RVA: 0x006CD0D3 File Offset: 0x006CB4D3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFD9 RID: 65497
		private DestinationType method_p0;
	}
}

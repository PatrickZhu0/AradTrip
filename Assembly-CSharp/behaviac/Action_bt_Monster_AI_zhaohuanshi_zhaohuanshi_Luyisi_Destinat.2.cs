using System;

namespace behaviac
{
	// Token: 0x02003FE2 RID: 16354
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node10 : Action
	{
		// Token: 0x0601672B RID: 91947 RVA: 0x006CB025 File Offset: 0x006C9425
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601672C RID: 91948 RVA: 0x006CB03B File Offset: 0x006C943B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF7E RID: 65406
		private DestinationType method_p0;
	}
}

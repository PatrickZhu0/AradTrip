using System;

namespace behaviac
{
	// Token: 0x02003FDF RID: 16351
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node7 : Action
	{
		// Token: 0x06016725 RID: 91941 RVA: 0x006CAF39 File Offset: 0x006C9339
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06016726 RID: 91942 RVA: 0x006CAF4F File Offset: 0x006C934F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF78 RID: 65400
		private DestinationType method_p0;
	}
}

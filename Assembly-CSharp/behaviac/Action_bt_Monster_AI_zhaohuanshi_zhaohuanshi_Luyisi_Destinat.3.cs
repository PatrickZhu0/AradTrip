using System;

namespace behaviac
{
	// Token: 0x02003FE5 RID: 16357
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node14 : Action
	{
		// Token: 0x06016731 RID: 91953 RVA: 0x006CB111 File Offset: 0x006C9511
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016732 RID: 91954 RVA: 0x006CB127 File Offset: 0x006C9527
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF84 RID: 65412
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003FE8 RID: 16360
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node18 : Action
	{
		// Token: 0x06016737 RID: 91959 RVA: 0x006CB1FD File Offset: 0x006C95FD
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06016738 RID: 91960 RVA: 0x006CB214 File Offset: 0x006C9614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF8A RID: 65418
		private DestinationType method_p0;
	}
}

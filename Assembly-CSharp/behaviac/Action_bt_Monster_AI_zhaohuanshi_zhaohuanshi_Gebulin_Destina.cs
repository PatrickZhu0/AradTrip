using System;

namespace behaviac
{
	// Token: 0x02003FC0 RID: 16320
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node7 : Action
	{
		// Token: 0x060166E9 RID: 91881 RVA: 0x006C9A79 File Offset: 0x006C7E79
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060166EA RID: 91882 RVA: 0x006C9A8F File Offset: 0x006C7E8F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF3C RID: 65340
		private DestinationType method_p0;
	}
}

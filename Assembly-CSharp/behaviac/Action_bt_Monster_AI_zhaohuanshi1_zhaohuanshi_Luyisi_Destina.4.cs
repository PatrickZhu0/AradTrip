using System;

namespace behaviac
{
	// Token: 0x02004091 RID: 16529
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node18 : Action
	{
		// Token: 0x0601687E RID: 92286 RVA: 0x006D23D9 File Offset: 0x006D07D9
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x0601687F RID: 92287 RVA: 0x006D23F0 File Offset: 0x006D07F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100C9 RID: 65737
		private DestinationType method_p0;
	}
}

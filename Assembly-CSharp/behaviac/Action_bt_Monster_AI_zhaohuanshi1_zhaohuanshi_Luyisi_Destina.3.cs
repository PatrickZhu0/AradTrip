using System;

namespace behaviac
{
	// Token: 0x0200408E RID: 16526
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node14 : Action
	{
		// Token: 0x06016878 RID: 92280 RVA: 0x006D22ED File Offset: 0x006D06ED
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016879 RID: 92281 RVA: 0x006D2303 File Offset: 0x006D0703
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100C3 RID: 65731
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200408B RID: 16523
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node10 : Action
	{
		// Token: 0x06016872 RID: 92274 RVA: 0x006D2201 File Offset: 0x006D0601
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016873 RID: 92275 RVA: 0x006D2217 File Offset: 0x006D0617
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100BD RID: 65725
		private DestinationType method_p0;
	}
}

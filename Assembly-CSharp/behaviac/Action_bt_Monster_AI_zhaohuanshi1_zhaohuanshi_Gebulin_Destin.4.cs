using System;

namespace behaviac
{
	// Token: 0x02004072 RID: 16498
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node19 : Action
	{
		// Token: 0x06016842 RID: 92226 RVA: 0x006D0F19 File Offset: 0x006CF319
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016843 RID: 92227 RVA: 0x006D0F2F File Offset: 0x006CF32F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401008D RID: 65677
		private DestinationType method_p0;
	}
}

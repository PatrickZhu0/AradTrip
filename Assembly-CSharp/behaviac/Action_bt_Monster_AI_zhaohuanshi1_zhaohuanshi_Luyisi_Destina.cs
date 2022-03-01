using System;

namespace behaviac
{
	// Token: 0x02004088 RID: 16520
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node7 : Action
	{
		// Token: 0x0601686C RID: 92268 RVA: 0x006D2115 File Offset: 0x006D0515
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601686D RID: 92269 RVA: 0x006D212B File Offset: 0x006D052B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100B7 RID: 65719
		private DestinationType method_p0;
	}
}

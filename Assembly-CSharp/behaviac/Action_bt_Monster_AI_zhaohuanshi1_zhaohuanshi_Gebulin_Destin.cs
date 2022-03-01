using System;

namespace behaviac
{
	// Token: 0x02004069 RID: 16489
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node7 : Action
	{
		// Token: 0x06016830 RID: 92208 RVA: 0x006D0C55 File Offset: 0x006CF055
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016831 RID: 92209 RVA: 0x006D0C6B File Offset: 0x006CF06B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401007B RID: 65659
		private DestinationType method_p0;
	}
}

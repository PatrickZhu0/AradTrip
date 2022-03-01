using System;

namespace behaviac
{
	// Token: 0x020040A2 RID: 16546
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node7 : Action
	{
		// Token: 0x0601689E RID: 92318 RVA: 0x006D3261 File Offset: 0x006D1661
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601689F RID: 92319 RVA: 0x006D3277 File Offset: 0x006D1677
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E7 RID: 65767
		private DestinationType method_p0;
	}
}

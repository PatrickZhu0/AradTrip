using System;

namespace behaviac
{
	// Token: 0x020040C2 RID: 16578
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node18 : Action
	{
		// Token: 0x060168DC RID: 92380 RVA: 0x006D4471 File Offset: 0x006D2871
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060168DD RID: 92381 RVA: 0x006D4488 File Offset: 0x006D2888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010124 RID: 65828
		private DestinationType method_p0;
	}
}

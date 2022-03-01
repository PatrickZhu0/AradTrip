using System;

namespace behaviac
{
	// Token: 0x0200401D RID: 16413
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node7 : Action
	{
		// Token: 0x0601679C RID: 92060 RVA: 0x006CD7E1 File Offset: 0x006CBBE1
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601679D RID: 92061 RVA: 0x006CD7F7 File Offset: 0x006CBBF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFEB RID: 65515
		private DestinationType method_p0;
	}
}

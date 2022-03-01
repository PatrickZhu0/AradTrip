using System;

namespace behaviac
{
	// Token: 0x02004019 RID: 16409
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node18 : Action
	{
		// Token: 0x06016795 RID: 92053 RVA: 0x006CD295 File Offset: 0x006CB695
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06016796 RID: 92054 RVA: 0x006CD2AC File Offset: 0x006CB6AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFE5 RID: 65509
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003ED3 RID: 16083
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node6 : Action
	{
		// Token: 0x06016522 RID: 91426 RVA: 0x006C0A2F File Offset: 0x006BEE2F
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016523 RID: 91427 RVA: 0x006C0A45 File Offset: 0x006BEE45
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD58 RID: 64856
		private DestinationType method_p0;
	}
}

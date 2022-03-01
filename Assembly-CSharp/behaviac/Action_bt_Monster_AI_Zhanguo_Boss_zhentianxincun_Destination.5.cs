using System;

namespace behaviac
{
	// Token: 0x02003EDE RID: 16094
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node30 : Action
	{
		// Token: 0x06016538 RID: 91448 RVA: 0x006C0D67 File Offset: 0x006BF167
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06016539 RID: 91449 RVA: 0x006C0D7D File Offset: 0x006BF17D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD6C RID: 64876
		private DestinationType method_p0;
	}
}

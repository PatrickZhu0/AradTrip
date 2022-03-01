using System;

namespace behaviac
{
	// Token: 0x02003ED7 RID: 16087
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node25 : Action
	{
		// Token: 0x0601652A RID: 91434 RVA: 0x006C0B9B File Offset: 0x006BEF9B
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601652B RID: 91435 RVA: 0x006C0BB1 File Offset: 0x006BEFB1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD62 RID: 64866
		private DestinationType method_p0;
	}
}

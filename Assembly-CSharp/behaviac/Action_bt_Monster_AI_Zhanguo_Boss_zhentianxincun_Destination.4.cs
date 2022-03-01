using System;

namespace behaviac
{
	// Token: 0x02003EDB RID: 16091
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node13 : Action
	{
		// Token: 0x06016532 RID: 91442 RVA: 0x006C0C7B File Offset: 0x006BF07B
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06016533 RID: 91443 RVA: 0x006C0C91 File Offset: 0x006BF091
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD66 RID: 64870
		private DestinationType method_p0;
	}
}

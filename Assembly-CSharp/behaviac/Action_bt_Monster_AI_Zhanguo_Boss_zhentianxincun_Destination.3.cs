using System;

namespace behaviac
{
	// Token: 0x02003ED9 RID: 16089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node8 : Action
	{
		// Token: 0x0601652E RID: 91438 RVA: 0x006C0C0B File Offset: 0x006BF00B
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x0601652F RID: 91439 RVA: 0x006C0C21 File Offset: 0x006BF021
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD64 RID: 64868
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003F88 RID: 16264
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node6 : Action
	{
		// Token: 0x0601667B RID: 91771 RVA: 0x006C7331 File Offset: 0x006C5731
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601667C RID: 91772 RVA: 0x006C7347 File Offset: 0x006C5747
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED0 RID: 65232
		private DestinationType method_p0;
	}
}

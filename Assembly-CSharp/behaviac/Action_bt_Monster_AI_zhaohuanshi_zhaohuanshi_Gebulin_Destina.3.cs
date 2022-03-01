using System;

namespace behaviac
{
	// Token: 0x02003FC6 RID: 16326
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node15 : Action
	{
		// Token: 0x060166F5 RID: 91893 RVA: 0x006C9C51 File Offset: 0x006C8051
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060166F6 RID: 91894 RVA: 0x006C9C67 File Offset: 0x006C8067
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF48 RID: 65352
		private DestinationType method_p0;
	}
}

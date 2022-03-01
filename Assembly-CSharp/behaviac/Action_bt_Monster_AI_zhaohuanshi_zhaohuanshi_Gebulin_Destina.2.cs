using System;

namespace behaviac
{
	// Token: 0x02003FC3 RID: 16323
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node11 : Action
	{
		// Token: 0x060166EF RID: 91887 RVA: 0x006C9B65 File Offset: 0x006C7F65
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060166F0 RID: 91888 RVA: 0x006C9B7B File Offset: 0x006C7F7B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF42 RID: 65346
		private DestinationType method_p0;
	}
}

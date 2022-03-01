using System;

namespace behaviac
{
	// Token: 0x02003FCB RID: 16331
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node23 : Action
	{
		// Token: 0x060166FF RID: 91903 RVA: 0x006C9DE1 File Offset: 0x006C81E1
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016700 RID: 91904 RVA: 0x006C9DF7 File Offset: 0x006C81F7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF53 RID: 65363
		private DestinationType method_p0;
	}
}

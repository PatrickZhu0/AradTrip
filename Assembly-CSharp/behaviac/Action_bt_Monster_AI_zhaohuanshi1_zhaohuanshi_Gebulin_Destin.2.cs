using System;

namespace behaviac
{
	// Token: 0x0200406C RID: 16492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node11 : Action
	{
		// Token: 0x06016836 RID: 92214 RVA: 0x006D0D41 File Offset: 0x006CF141
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06016837 RID: 92215 RVA: 0x006D0D57 File Offset: 0x006CF157
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010081 RID: 65665
		private DestinationType method_p0;
	}
}

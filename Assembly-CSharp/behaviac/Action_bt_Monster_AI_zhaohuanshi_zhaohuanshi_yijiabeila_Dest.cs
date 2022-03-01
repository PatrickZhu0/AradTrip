using System;

namespace behaviac
{
	// Token: 0x02004010 RID: 16400
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7 : Action
	{
		// Token: 0x06016783 RID: 92035 RVA: 0x006CCFD1 File Offset: 0x006CB3D1
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06016784 RID: 92036 RVA: 0x006CCFE7 File Offset: 0x006CB3E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFD3 RID: 65491
		private DestinationType method_p0;
	}
}

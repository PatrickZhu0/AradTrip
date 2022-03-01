using System;

namespace behaviac
{
	// Token: 0x02004074 RID: 16500
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node23 : Action
	{
		// Token: 0x06016846 RID: 92230 RVA: 0x006D0FBD File Offset: 0x006CF3BD
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016847 RID: 92231 RVA: 0x006D0FD3 File Offset: 0x006CF3D3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010092 RID: 65682
		private DestinationType method_p0;
	}
}

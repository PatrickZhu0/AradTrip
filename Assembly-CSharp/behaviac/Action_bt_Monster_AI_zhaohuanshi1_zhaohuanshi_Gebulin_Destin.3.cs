using System;

namespace behaviac
{
	// Token: 0x0200406F RID: 16495
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node15 : Action
	{
		// Token: 0x0601683C RID: 92220 RVA: 0x006D0E2D File Offset: 0x006CF22D
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601683D RID: 92221 RVA: 0x006D0E43 File Offset: 0x006CF243
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010087 RID: 65671
		private DestinationType method_p0;
	}
}

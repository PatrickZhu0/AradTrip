using System;

namespace behaviac
{
	// Token: 0x02003F8B RID: 16267
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node9 : Action
	{
		// Token: 0x06016681 RID: 91777 RVA: 0x006C741D File Offset: 0x006C581D
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06016682 RID: 91778 RVA: 0x006C7433 File Offset: 0x006C5833
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FED6 RID: 65238
		private DestinationType method_p0;
	}
}

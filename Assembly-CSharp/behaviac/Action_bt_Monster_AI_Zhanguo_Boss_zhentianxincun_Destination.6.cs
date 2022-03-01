using System;

namespace behaviac
{
	// Token: 0x02003EE0 RID: 16096
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node27 : Action
	{
		// Token: 0x0601653C RID: 91452 RVA: 0x006C0DD7 File Offset: 0x006BF1D7
		public Action_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601653D RID: 91453 RVA: 0x006C0DED File Offset: 0x006BF1ED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD6E RID: 64878
		private DestinationType method_p0;
	}
}

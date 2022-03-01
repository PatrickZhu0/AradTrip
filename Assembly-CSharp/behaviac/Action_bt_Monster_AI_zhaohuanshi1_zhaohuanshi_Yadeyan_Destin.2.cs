using System;

namespace behaviac
{
	// Token: 0x020040A5 RID: 16549
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node9 : Action
	{
		// Token: 0x060168A4 RID: 92324 RVA: 0x006D334D File Offset: 0x006D174D
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060168A5 RID: 92325 RVA: 0x006D3363 File Offset: 0x006D1763
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100ED RID: 65773
		private DestinationType method_p0;
	}
}

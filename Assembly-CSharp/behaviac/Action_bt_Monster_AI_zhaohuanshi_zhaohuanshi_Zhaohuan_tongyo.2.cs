using System;

namespace behaviac
{
	// Token: 0x02004020 RID: 16416
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node9 : Action
	{
		// Token: 0x060167A2 RID: 92066 RVA: 0x006CD8CD File Offset: 0x006CBCCD
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060167A3 RID: 92067 RVA: 0x006CD8E3 File Offset: 0x006CBCE3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFF1 RID: 65521
		private DestinationType method_p0;
	}
}

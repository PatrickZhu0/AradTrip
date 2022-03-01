using System;

namespace behaviac
{
	// Token: 0x020040B9 RID: 16569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node7 : Action
	{
		// Token: 0x060168CA RID: 92362 RVA: 0x006D41AD File Offset: 0x006D25AD
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060168CB RID: 92363 RVA: 0x006D41C3 File Offset: 0x006D25C3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010112 RID: 65810
		private DestinationType method_p0;
	}
}

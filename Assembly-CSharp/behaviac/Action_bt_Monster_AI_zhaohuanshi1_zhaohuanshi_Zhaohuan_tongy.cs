using System;

namespace behaviac
{
	// Token: 0x020040C6 RID: 16582
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node7 : Action
	{
		// Token: 0x060168E3 RID: 92387 RVA: 0x006D49BD File Offset: 0x006D2DBD
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060168E4 RID: 92388 RVA: 0x006D49D3 File Offset: 0x006D2DD3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401012A RID: 65834
		private DestinationType method_p0;
	}
}

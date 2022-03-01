using System;

namespace behaviac
{
	// Token: 0x02003FF9 RID: 16377
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node7 : Action
	{
		// Token: 0x06016757 RID: 91991 RVA: 0x006CC085 File Offset: 0x006CA485
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016758 RID: 91992 RVA: 0x006CC09B File Offset: 0x006CA49B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA8 RID: 65448
		private DestinationType method_p0;
	}
}

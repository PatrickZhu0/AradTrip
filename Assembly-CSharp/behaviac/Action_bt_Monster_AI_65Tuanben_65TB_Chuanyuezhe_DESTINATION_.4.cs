using System;

namespace behaviac
{
	// Token: 0x02002B7A RID: 11130
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node23 : Action
	{
		// Token: 0x06014001 RID: 81921 RVA: 0x00601617 File Offset: 0x005FFA17
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014002 RID: 81922 RVA: 0x0060162D File Offset: 0x005FFA2D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA07 RID: 55815
		private DestinationType method_p0;
	}
}

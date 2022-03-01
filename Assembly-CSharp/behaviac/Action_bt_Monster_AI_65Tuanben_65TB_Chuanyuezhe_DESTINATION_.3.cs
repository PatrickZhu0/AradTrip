using System;

namespace behaviac
{
	// Token: 0x02002B76 RID: 11126
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node8 : Action
	{
		// Token: 0x06013FF9 RID: 81913 RVA: 0x00601571 File Offset: 0x005FF971
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06013FFA RID: 81914 RVA: 0x00601587 File Offset: 0x005FF987
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA05 RID: 55813
		private DestinationType method_p0;
	}
}

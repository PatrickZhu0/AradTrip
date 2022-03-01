using System;

namespace behaviac
{
	// Token: 0x020039B0 RID: 14768
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6 : Action
	{
		// Token: 0x06015B33 RID: 88883 RVA: 0x0068DFE2 File Offset: 0x0068C3E2
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015B34 RID: 88884 RVA: 0x0068DFF8 File Offset: 0x0068C3F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AD RID: 62637
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002BA7 RID: 11175
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node6 : Action
	{
		// Token: 0x06014056 RID: 82006 RVA: 0x0060361D File Offset: 0x00601A1D
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014057 RID: 82007 RVA: 0x00603633 File Offset: 0x00601A33
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA50 RID: 55888
		private DestinationType method_p0;
	}
}

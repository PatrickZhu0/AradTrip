using System;

namespace behaviac
{
	// Token: 0x020039A2 RID: 14754
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node6 : Action
	{
		// Token: 0x06015B18 RID: 88856 RVA: 0x0068D8DA File Offset: 0x0068BCDA
		public Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015B19 RID: 88857 RVA: 0x0068D8F0 File Offset: 0x0068BCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A6 RID: 62630
		private DestinationType method_p0;
	}
}

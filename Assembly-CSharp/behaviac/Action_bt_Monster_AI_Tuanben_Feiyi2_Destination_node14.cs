using System;

namespace behaviac
{
	// Token: 0x020039A6 RID: 14758
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node14 : Action
	{
		// Token: 0x06015B20 RID: 88864 RVA: 0x0068D9A4 File Offset: 0x0068BDA4
		public Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B21 RID: 88865 RVA: 0x0068D9BA File Offset: 0x0068BDBA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A7 RID: 62631
		private DestinationType method_p0;
	}
}

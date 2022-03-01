using System;

namespace behaviac
{
	// Token: 0x020039CD RID: 14797
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node23 : Action
	{
		// Token: 0x06015B6B RID: 88939 RVA: 0x0068EED8 File Offset: 0x0068D2D8
		public Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015B6C RID: 88940 RVA: 0x0068EEEE File Offset: 0x0068D2EE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BD RID: 62653
		private DestinationType method_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020039B8 RID: 14776
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node23 : Action
	{
		// Token: 0x06015B43 RID: 88899 RVA: 0x0068E18F File Offset: 0x0068C58F
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B44 RID: 88900 RVA: 0x0068E1A5 File Offset: 0x0068C5A5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B2 RID: 62642
		private DestinationType method_p0;
	}
}

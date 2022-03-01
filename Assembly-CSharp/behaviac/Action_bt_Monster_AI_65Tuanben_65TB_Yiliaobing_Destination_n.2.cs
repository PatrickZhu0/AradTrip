using System;

namespace behaviac
{
	// Token: 0x02002D19 RID: 11545
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node4 : Action
	{
		// Token: 0x0601431F RID: 82719 RVA: 0x00611265 File Offset: 0x0060F665
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014320 RID: 82720 RVA: 0x0061127B File Offset: 0x0060F67B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCD4 RID: 56532
		private DestinationType method_p0;
	}
}

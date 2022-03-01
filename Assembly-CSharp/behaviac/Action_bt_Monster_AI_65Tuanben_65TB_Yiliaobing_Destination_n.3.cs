using System;

namespace behaviac
{
	// Token: 0x02002D1B RID: 11547
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node5 : Action
	{
		// Token: 0x06014323 RID: 82723 RVA: 0x0061130C File Offset: 0x0060F70C
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014324 RID: 82724 RVA: 0x00611322 File Offset: 0x0060F722
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCD9 RID: 56537
		private DestinationType method_p0;
	}
}

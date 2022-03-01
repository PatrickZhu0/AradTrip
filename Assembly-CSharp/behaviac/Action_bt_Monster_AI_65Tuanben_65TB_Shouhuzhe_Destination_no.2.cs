using System;

namespace behaviac
{
	// Token: 0x02002C80 RID: 11392
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node5 : Action
	{
		// Token: 0x060141F8 RID: 82424 RVA: 0x0060B41D File Offset: 0x0060981D
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060141F9 RID: 82425 RVA: 0x0060B433 File Offset: 0x00609833
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBBF RID: 56255
		private DestinationType method_p0;
	}
}

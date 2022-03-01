using System;

namespace behaviac
{
	// Token: 0x02002C7E RID: 11390
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node4 : Action
	{
		// Token: 0x060141F4 RID: 82420 RVA: 0x0060B379 File Offset: 0x00609779
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060141F5 RID: 82421 RVA: 0x0060B390 File Offset: 0x00609790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBBA RID: 56250
		private DestinationType method_p0;
	}
}

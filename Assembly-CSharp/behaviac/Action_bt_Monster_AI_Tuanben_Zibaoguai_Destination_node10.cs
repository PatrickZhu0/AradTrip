using System;

namespace behaviac
{
	// Token: 0x02003B88 RID: 15240
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node10 : Action
	{
		// Token: 0x06015EC1 RID: 89793 RVA: 0x0069FEDD File Offset: 0x0069E2DD
		public Action_bt_Monster_AI_Tuanben_Zibaoguai_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.MOVETO_LEFT_SCENEEDGE;
		}

		// Token: 0x06015EC2 RID: 89794 RVA: 0x0069FEF4 File Offset: 0x0069E2F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F782 RID: 63362
		private DestinationType method_p0;
	}
}

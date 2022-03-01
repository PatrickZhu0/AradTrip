using System;

namespace behaviac
{
	// Token: 0x020039C8 RID: 14792
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node23 : Action
	{
		// Token: 0x06015B62 RID: 88930 RVA: 0x0068E9B3 File Offset: 0x0068CDB3
		public Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B63 RID: 88931 RVA: 0x0068E9C9 File Offset: 0x0068CDC9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BB RID: 62651
		private DestinationType method_p0;
	}
}

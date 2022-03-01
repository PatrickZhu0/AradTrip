using System;

namespace behaviac
{
	// Token: 0x020039AA RID: 14762
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node23 : Action
	{
		// Token: 0x06015B28 RID: 88872 RVA: 0x0068DA87 File Offset: 0x0068BE87
		public Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B29 RID: 88873 RVA: 0x0068DA9D File Offset: 0x0068BE9D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AB RID: 62635
		private DestinationType method_p0;
	}
}

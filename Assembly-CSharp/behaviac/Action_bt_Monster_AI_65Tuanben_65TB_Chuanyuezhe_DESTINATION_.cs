using System;

namespace behaviac
{
	// Token: 0x02002B6F RID: 11119
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node21 : Action
	{
		// Token: 0x06013FEB RID: 81899 RVA: 0x0060138D File Offset: 0x005FF78D
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06013FEC RID: 81900 RVA: 0x006013A3 File Offset: 0x005FF7A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9FB RID: 55803
		private DestinationType method_p0;
	}
}

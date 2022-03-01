using System;

namespace behaviac
{
	// Token: 0x02002B73 RID: 11123
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node5 : Action
	{
		// Token: 0x06013FF3 RID: 81907 RVA: 0x006014A9 File Offset: 0x005FF8A9
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06013FF4 RID: 81908 RVA: 0x006014BF File Offset: 0x005FF8BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA01 RID: 55809
		private DestinationType method_p0;
	}
}

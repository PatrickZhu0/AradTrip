using System;

namespace behaviac
{
	// Token: 0x02003B04 RID: 15108
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node6 : Action
	{
		// Token: 0x06015DC3 RID: 89539 RVA: 0x0069AFB5 File Offset: 0x006993B5
		public Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DC4 RID: 89540 RVA: 0x0069AFCC File Offset: 0x006993CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6BA RID: 63162
		private DestinationType method_p0;
	}
}

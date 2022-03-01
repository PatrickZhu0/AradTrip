using System;

namespace behaviac
{
	// Token: 0x02002202 RID: 8706
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_normal_Move_node6 : Action
	{
		// Token: 0x06012D8F RID: 77199 RVA: 0x0058C8E3 File Offset: 0x0058ACE3
		public Action_bt_AutoFight_AutoFight_Fight_normal_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06012D90 RID: 77200 RVA: 0x0058C8F9 File Offset: 0x0058ACF9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C77A RID: 51066
		private DestinationType method_p0;
	}
}

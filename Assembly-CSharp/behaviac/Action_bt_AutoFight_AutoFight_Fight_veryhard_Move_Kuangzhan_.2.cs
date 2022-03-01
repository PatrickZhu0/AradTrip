using System;

namespace behaviac
{
	// Token: 0x02002496 RID: 9366
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10 : Action
	{
		// Token: 0x06013278 RID: 78456 RVA: 0x005AF58B File Offset: 0x005AD98B
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013279 RID: 78457 RVA: 0x005AF5A1 File Offset: 0x005AD9A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC91 RID: 52369
		private DestinationType method_p0;
	}
}

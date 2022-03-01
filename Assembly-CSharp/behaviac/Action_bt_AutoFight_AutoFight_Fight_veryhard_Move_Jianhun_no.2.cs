using System;

namespace behaviac
{
	// Token: 0x02002489 RID: 9353
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node10 : Action
	{
		// Token: 0x0601325F RID: 78431 RVA: 0x005AED8F File Offset: 0x005AD18F
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013260 RID: 78432 RVA: 0x005AEDA5 File Offset: 0x005AD1A5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC7A RID: 52346
		private DestinationType method_p0;
	}
}

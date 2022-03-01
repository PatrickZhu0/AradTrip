using System;

namespace behaviac
{
	// Token: 0x0200247C RID: 9340
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node10 : Action
	{
		// Token: 0x06013246 RID: 78406 RVA: 0x005AE593 File Offset: 0x005AC993
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013247 RID: 78407 RVA: 0x005AE5A9 File Offset: 0x005AC9A9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC63 RID: 52323
		private DestinationType method_p0;
	}
}

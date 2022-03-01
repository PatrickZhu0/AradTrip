using System;

namespace behaviac
{
	// Token: 0x02002478 RID: 9336
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node22 : Action
	{
		// Token: 0x0601323E RID: 78398 RVA: 0x005AE41F File Offset: 0x005AC81F
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER_PKROBOT;
		}

		// Token: 0x0601323F RID: 78399 RVA: 0x005AE436 File Offset: 0x005AC836
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC5C RID: 52316
		private DestinationType method_p0;
	}
}

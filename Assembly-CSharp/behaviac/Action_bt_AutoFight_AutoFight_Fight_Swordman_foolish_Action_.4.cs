using System;

namespace behaviac
{
	// Token: 0x0200228F RID: 8847
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node26 : Action
	{
		// Token: 0x06012E9E RID: 77470 RVA: 0x00594295 File Offset: 0x00592695
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = BE_Equal.NotEqual;
			this.method_p2 = BE_State.DAODI;
		}

		// Token: 0x06012E9F RID: 77471 RVA: 0x005942B9 File Offset: 0x005926B9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CheckState(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8A9 RID: 51369
		private BE_Target method_p0;

		// Token: 0x0400C8AA RID: 51370
		private BE_Equal method_p1;

		// Token: 0x0400C8AB RID: 51371
		private BE_State method_p2;
	}
}

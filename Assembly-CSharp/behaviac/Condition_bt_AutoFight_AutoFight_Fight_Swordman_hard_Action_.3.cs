using System;

namespace behaviac
{
	// Token: 0x02002299 RID: 8857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node9 : Condition
	{
		// Token: 0x06012EB0 RID: 77488 RVA: 0x00594DFB File Offset: 0x005931FB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012EB1 RID: 77489 RVA: 0x00594E18 File Offset: 0x00593218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8BB RID: 51387
		private BE_Target opl_p0;

		// Token: 0x0400C8BC RID: 51388
		private BE_Equal opl_p1;

		// Token: 0x0400C8BD RID: 51389
		private BE_State opl_p2;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028CA RID: 10442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node96 : Condition
	{
		// Token: 0x06013ACE RID: 80590 RVA: 0x005DFD1D File Offset: 0x005DE11D
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node96()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013ACF RID: 80591 RVA: 0x005DFD3C File Offset: 0x005DE13C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D52E RID: 54574
		private BE_Target opl_p0;

		// Token: 0x0400D52F RID: 54575
		private BE_Equal opl_p1;

		// Token: 0x0400D530 RID: 54576
		private BE_State opl_p2;
	}
}

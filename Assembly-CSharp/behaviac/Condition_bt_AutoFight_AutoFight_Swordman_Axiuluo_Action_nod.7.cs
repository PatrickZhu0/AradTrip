using System;

namespace behaviac
{
	// Token: 0x020028A1 RID: 10401
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node12 : Condition
	{
		// Token: 0x06013A7C RID: 80508 RVA: 0x005DEA2F File Offset: 0x005DCE2F
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013A7D RID: 80509 RVA: 0x005DEA4C File Offset: 0x005DCE4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4D7 RID: 54487
		private BE_Target opl_p0;

		// Token: 0x0400D4D8 RID: 54488
		private BE_Equal opl_p1;

		// Token: 0x0400D4D9 RID: 54489
		private BE_State opl_p2;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028A6 RID: 10406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node31 : Condition
	{
		// Token: 0x06013A86 RID: 80518 RVA: 0x005DED4D File Offset: 0x005DD14D
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node31()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013A87 RID: 80519 RVA: 0x005DED6C File Offset: 0x005DD16C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4E2 RID: 54498
		private BE_Target opl_p0;

		// Token: 0x0400D4E3 RID: 54499
		private BE_Equal opl_p1;

		// Token: 0x0400D4E4 RID: 54500
		private BE_State opl_p2;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028DB RID: 10459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node83 : Condition
	{
		// Token: 0x06013AF0 RID: 80624 RVA: 0x005E0575 File Offset: 0x005DE975
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node83()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013AF1 RID: 80625 RVA: 0x005E0594 File Offset: 0x005DE994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D553 RID: 54611
		private BE_Target opl_p0;

		// Token: 0x0400D554 RID: 54612
		private BE_Equal opl_p1;

		// Token: 0x0400D555 RID: 54613
		private BE_State opl_p2;
	}
}

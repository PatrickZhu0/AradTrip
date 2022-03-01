using System;

namespace behaviac
{
	// Token: 0x020028B7 RID: 10423
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node39 : Condition
	{
		// Token: 0x06013AA8 RID: 80552 RVA: 0x005DF4D1 File Offset: 0x005DD8D1
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013AA9 RID: 80553 RVA: 0x005DF4F0 File Offset: 0x005DD8F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D505 RID: 54533
		private BE_Target opl_p0;

		// Token: 0x0400D506 RID: 54534
		private BE_Equal opl_p1;

		// Token: 0x0400D507 RID: 54535
		private BE_State opl_p2;
	}
}

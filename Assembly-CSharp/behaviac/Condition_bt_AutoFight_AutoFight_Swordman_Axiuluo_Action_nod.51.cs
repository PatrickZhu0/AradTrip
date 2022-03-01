using System;

namespace behaviac
{
	// Token: 0x020028DA RID: 10458
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node81 : Condition
	{
		// Token: 0x06013AEE RID: 80622 RVA: 0x005E04FB File Offset: 0x005DE8FB
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node81()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013AEF RID: 80623 RVA: 0x005E0530 File Offset: 0x005DE930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D54F RID: 54607
		private int opl_p0;

		// Token: 0x0400D550 RID: 54608
		private int opl_p1;

		// Token: 0x0400D551 RID: 54609
		private int opl_p2;

		// Token: 0x0400D552 RID: 54610
		private int opl_p3;
	}
}

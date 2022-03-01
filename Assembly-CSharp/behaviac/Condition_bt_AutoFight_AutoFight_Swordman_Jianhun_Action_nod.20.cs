using System;

namespace behaviac
{
	// Token: 0x0200291E RID: 10526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node62 : Condition
	{
		// Token: 0x06013B72 RID: 80754 RVA: 0x005E458A File Offset: 0x005E298A
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node62()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013B73 RID: 80755 RVA: 0x005E45C0 File Offset: 0x005E29C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5D7 RID: 54743
		private int opl_p0;

		// Token: 0x0400D5D8 RID: 54744
		private int opl_p1;

		// Token: 0x0400D5D9 RID: 54745
		private int opl_p2;

		// Token: 0x0400D5DA RID: 54746
		private int opl_p3;
	}
}

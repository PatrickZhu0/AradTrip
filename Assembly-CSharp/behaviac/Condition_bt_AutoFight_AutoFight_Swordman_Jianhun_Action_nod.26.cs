using System;

namespace behaviac
{
	// Token: 0x02002926 RID: 10534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node55 : Condition
	{
		// Token: 0x06013B82 RID: 80770 RVA: 0x005E494E File Offset: 0x005E2D4E
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013B83 RID: 80771 RVA: 0x005E4984 File Offset: 0x005E2D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5E7 RID: 54759
		private int opl_p0;

		// Token: 0x0400D5E8 RID: 54760
		private int opl_p1;

		// Token: 0x0400D5E9 RID: 54761
		private int opl_p2;

		// Token: 0x0400D5EA RID: 54762
		private int opl_p3;
	}
}

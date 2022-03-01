using System;

namespace behaviac
{
	// Token: 0x02002917 RID: 10519
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node15 : Condition
	{
		// Token: 0x06013B64 RID: 80740 RVA: 0x005E40A6 File Offset: 0x005E24A6
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node15()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013B65 RID: 80741 RVA: 0x005E40DC File Offset: 0x005E24DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5C8 RID: 54728
		private int opl_p0;

		// Token: 0x0400D5C9 RID: 54729
		private int opl_p1;

		// Token: 0x0400D5CA RID: 54730
		private int opl_p2;

		// Token: 0x0400D5CB RID: 54731
		private int opl_p3;
	}
}

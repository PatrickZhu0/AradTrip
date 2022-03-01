using System;

namespace behaviac
{
	// Token: 0x02002922 RID: 10530
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node75 : Condition
	{
		// Token: 0x06013B7A RID: 80762 RVA: 0x005E479A File Offset: 0x005E2B9A
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node75()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013B7B RID: 80763 RVA: 0x005E47D0 File Offset: 0x005E2BD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5DF RID: 54751
		private int opl_p0;

		// Token: 0x0400D5E0 RID: 54752
		private int opl_p1;

		// Token: 0x0400D5E1 RID: 54753
		private int opl_p2;

		// Token: 0x0400D5E2 RID: 54754
		private int opl_p3;
	}
}

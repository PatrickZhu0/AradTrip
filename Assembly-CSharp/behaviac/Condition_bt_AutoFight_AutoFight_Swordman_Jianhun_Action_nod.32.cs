using System;

namespace behaviac
{
	// Token: 0x0200292E RID: 10542
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node1 : Condition
	{
		// Token: 0x06013B92 RID: 80786 RVA: 0x005E4D12 File Offset: 0x005E3112
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node1()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013B93 RID: 80787 RVA: 0x005E4D48 File Offset: 0x005E3148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5F7 RID: 54775
		private int opl_p0;

		// Token: 0x0400D5F8 RID: 54776
		private int opl_p1;

		// Token: 0x0400D5F9 RID: 54777
		private int opl_p2;

		// Token: 0x0400D5FA RID: 54778
		private int opl_p3;
	}
}

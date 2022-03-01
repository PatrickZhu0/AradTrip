using System;

namespace behaviac
{
	// Token: 0x020028E9 RID: 10473
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node38 : Condition
	{
		// Token: 0x06013B09 RID: 80649 RVA: 0x005E21D2 File Offset: 0x005E05D2
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node38()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013B0A RID: 80650 RVA: 0x005E2208 File Offset: 0x005E0608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D56B RID: 54635
		private int opl_p0;

		// Token: 0x0400D56C RID: 54636
		private int opl_p1;

		// Token: 0x0400D56D RID: 54637
		private int opl_p2;

		// Token: 0x0400D56E RID: 54638
		private int opl_p3;
	}
}

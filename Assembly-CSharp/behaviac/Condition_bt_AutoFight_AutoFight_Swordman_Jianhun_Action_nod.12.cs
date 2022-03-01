using System;

namespace behaviac
{
	// Token: 0x02002913 RID: 10515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node17 : Condition
	{
		// Token: 0x06013B5C RID: 80732 RVA: 0x005E3EF2 File Offset: 0x005E22F2
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node17()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013B5D RID: 80733 RVA: 0x005E3F28 File Offset: 0x005E2328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5C0 RID: 54720
		private int opl_p0;

		// Token: 0x0400D5C1 RID: 54721
		private int opl_p1;

		// Token: 0x0400D5C2 RID: 54722
		private int opl_p2;

		// Token: 0x0400D5C3 RID: 54723
		private int opl_p3;
	}
}

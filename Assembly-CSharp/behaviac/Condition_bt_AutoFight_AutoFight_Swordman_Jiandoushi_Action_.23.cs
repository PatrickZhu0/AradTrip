using System;

namespace behaviac
{
	// Token: 0x02002901 RID: 10497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node15 : Condition
	{
		// Token: 0x06013B39 RID: 80697 RVA: 0x005E2C0A File Offset: 0x005E100A
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node15()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013B3A RID: 80698 RVA: 0x005E2C40 File Offset: 0x005E1040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D59B RID: 54683
		private int opl_p0;

		// Token: 0x0400D59C RID: 54684
		private int opl_p1;

		// Token: 0x0400D59D RID: 54685
		private int opl_p2;

		// Token: 0x0400D59E RID: 54686
		private int opl_p3;
	}
}

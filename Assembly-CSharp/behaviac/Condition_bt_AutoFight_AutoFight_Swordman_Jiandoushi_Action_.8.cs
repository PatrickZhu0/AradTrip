using System;

namespace behaviac
{
	// Token: 0x020028ED RID: 10477
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node43 : Condition
	{
		// Token: 0x06013B11 RID: 80657 RVA: 0x005E2386 File Offset: 0x005E0786
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013B12 RID: 80658 RVA: 0x005E23BC File Offset: 0x005E07BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D573 RID: 54643
		private int opl_p0;

		// Token: 0x0400D574 RID: 54644
		private int opl_p1;

		// Token: 0x0400D575 RID: 54645
		private int opl_p2;

		// Token: 0x0400D576 RID: 54646
		private int opl_p3;
	}
}

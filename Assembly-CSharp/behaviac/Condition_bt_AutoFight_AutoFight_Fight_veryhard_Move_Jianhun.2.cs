using System;

namespace behaviac
{
	// Token: 0x02002483 RID: 9347
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node21 : Condition
	{
		// Token: 0x06013253 RID: 78419 RVA: 0x005AEAFB File Offset: 0x005ACEFB
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node21()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013254 RID: 78420 RVA: 0x005AEB30 File Offset: 0x005ACF30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC6E RID: 52334
		private int opl_p0;

		// Token: 0x0400CC6F RID: 52335
		private int opl_p1;

		// Token: 0x0400CC70 RID: 52336
		private int opl_p2;

		// Token: 0x0400CC71 RID: 52337
		private int opl_p3;
	}
}

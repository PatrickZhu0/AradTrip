using System;

namespace behaviac
{
	// Token: 0x0200247E RID: 9342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node5 : Condition
	{
		// Token: 0x0601324A RID: 78410 RVA: 0x005AE603 File Offset: 0x005ACA03
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node5()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x0601324B RID: 78411 RVA: 0x005AE638 File Offset: 0x005ACA38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC65 RID: 52325
		private int opl_p0;

		// Token: 0x0400CC66 RID: 52326
		private int opl_p1;

		// Token: 0x0400CC67 RID: 52327
		private int opl_p2;

		// Token: 0x0400CC68 RID: 52328
		private int opl_p3;
	}
}

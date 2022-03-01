using System;

namespace behaviac
{
	// Token: 0x02002249 RID: 8777
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16 : Condition
	{
		// Token: 0x06012E1A RID: 77338 RVA: 0x00590B28 File Offset: 0x0058EF28
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node16()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
			this.opl_p4 = 10000;
			this.opl_p5 = 10000;
			this.opl_p6 = 10000;
			this.opl_p7 = 10000;
		}

		// Token: 0x06012E1B RID: 77339 RVA: 0x00590B94 File Offset: 0x0058EF94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C818 RID: 51224
		private int opl_p0;

		// Token: 0x0400C819 RID: 51225
		private int opl_p1;

		// Token: 0x0400C81A RID: 51226
		private int opl_p2;

		// Token: 0x0400C81B RID: 51227
		private int opl_p3;

		// Token: 0x0400C81C RID: 51228
		private int opl_p4;

		// Token: 0x0400C81D RID: 51229
		private int opl_p5;

		// Token: 0x0400C81E RID: 51230
		private int opl_p6;

		// Token: 0x0400C81F RID: 51231
		private int opl_p7;
	}
}

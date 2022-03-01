using System;

namespace behaviac
{
	// Token: 0x02002257 RID: 8791
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node60 : Condition
	{
		// Token: 0x06012E36 RID: 77366 RVA: 0x00591704 File Offset: 0x0058FB04
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node60()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
			this.opl_p4 = 10000;
			this.opl_p5 = 1000;
			this.opl_p6 = 3000;
			this.opl_p7 = 3000;
		}

		// Token: 0x06012E37 RID: 77367 RVA: 0x00591770 File Offset: 0x0058FB70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C83A RID: 51258
		private int opl_p0;

		// Token: 0x0400C83B RID: 51259
		private int opl_p1;

		// Token: 0x0400C83C RID: 51260
		private int opl_p2;

		// Token: 0x0400C83D RID: 51261
		private int opl_p3;

		// Token: 0x0400C83E RID: 51262
		private int opl_p4;

		// Token: 0x0400C83F RID: 51263
		private int opl_p5;

		// Token: 0x0400C840 RID: 51264
		private int opl_p6;

		// Token: 0x0400C841 RID: 51265
		private int opl_p7;
	}
}

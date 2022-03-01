using System;

namespace behaviac
{
	// Token: 0x02002244 RID: 8772
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4 : Condition
	{
		// Token: 0x06012E10 RID: 77328 RVA: 0x005908C4 File Offset: 0x0058ECC4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node4()
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

		// Token: 0x06012E11 RID: 77329 RVA: 0x00590930 File Offset: 0x0058ED30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C809 RID: 51209
		private int opl_p0;

		// Token: 0x0400C80A RID: 51210
		private int opl_p1;

		// Token: 0x0400C80B RID: 51211
		private int opl_p2;

		// Token: 0x0400C80C RID: 51212
		private int opl_p3;

		// Token: 0x0400C80D RID: 51213
		private int opl_p4;

		// Token: 0x0400C80E RID: 51214
		private int opl_p5;

		// Token: 0x0400C80F RID: 51215
		private int opl_p6;

		// Token: 0x0400C810 RID: 51216
		private int opl_p7;
	}
}

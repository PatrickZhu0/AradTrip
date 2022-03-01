using System;

namespace behaviac
{
	// Token: 0x020022EF RID: 8943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node27 : Condition
	{
		// Token: 0x06012F57 RID: 77655 RVA: 0x0059A4B8 File Offset: 0x005988B8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node27()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
			this.opl_p4 = 20000;
			this.opl_p5 = 20000;
			this.opl_p6 = 20000;
			this.opl_p7 = 20000;
		}

		// Token: 0x06012F58 RID: 77656 RVA: 0x0059A524 File Offset: 0x00598924
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C969 RID: 51561
		private int opl_p0;

		// Token: 0x0400C96A RID: 51562
		private int opl_p1;

		// Token: 0x0400C96B RID: 51563
		private int opl_p2;

		// Token: 0x0400C96C RID: 51564
		private int opl_p3;

		// Token: 0x0400C96D RID: 51565
		private int opl_p4;

		// Token: 0x0400C96E RID: 51566
		private int opl_p5;

		// Token: 0x0400C96F RID: 51567
		private int opl_p6;

		// Token: 0x0400C970 RID: 51568
		private int opl_p7;
	}
}

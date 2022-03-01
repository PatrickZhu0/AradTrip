using System;

namespace behaviac
{
	// Token: 0x020022D0 RID: 8912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node31 : Condition
	{
		// Token: 0x06012F1B RID: 77595 RVA: 0x00598048 File Offset: 0x00596448
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node31()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
			this.opl_p4 = 4000;
			this.opl_p5 = 4000;
			this.opl_p6 = 4000;
			this.opl_p7 = 4000;
		}

		// Token: 0x06012F1C RID: 77596 RVA: 0x005980B4 File Offset: 0x005964B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C92C RID: 51500
		private int opl_p0;

		// Token: 0x0400C92D RID: 51501
		private int opl_p1;

		// Token: 0x0400C92E RID: 51502
		private int opl_p2;

		// Token: 0x0400C92F RID: 51503
		private int opl_p3;

		// Token: 0x0400C930 RID: 51504
		private int opl_p4;

		// Token: 0x0400C931 RID: 51505
		private int opl_p5;

		// Token: 0x0400C932 RID: 51506
		private int opl_p6;

		// Token: 0x0400C933 RID: 51507
		private int opl_p7;
	}
}

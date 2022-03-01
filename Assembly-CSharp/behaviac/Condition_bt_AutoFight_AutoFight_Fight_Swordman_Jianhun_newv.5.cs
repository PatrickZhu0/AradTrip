using System;

namespace behaviac
{
	// Token: 0x020022B4 RID: 8884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node27 : Condition
	{
		// Token: 0x06012EE3 RID: 77539 RVA: 0x005961D8 File Offset: 0x005945D8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node27()
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

		// Token: 0x06012EE4 RID: 77540 RVA: 0x00596244 File Offset: 0x00594644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8F0 RID: 51440
		private int opl_p0;

		// Token: 0x0400C8F1 RID: 51441
		private int opl_p1;

		// Token: 0x0400C8F2 RID: 51442
		private int opl_p2;

		// Token: 0x0400C8F3 RID: 51443
		private int opl_p3;

		// Token: 0x0400C8F4 RID: 51444
		private int opl_p4;

		// Token: 0x0400C8F5 RID: 51445
		private int opl_p5;

		// Token: 0x0400C8F6 RID: 51446
		private int opl_p6;

		// Token: 0x0400C8F7 RID: 51447
		private int opl_p7;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020022EB RID: 8939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node51 : Condition
	{
		// Token: 0x06012F4F RID: 77647 RVA: 0x0059A2B4 File Offset: 0x005986B4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node51()
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

		// Token: 0x06012F50 RID: 77648 RVA: 0x0059A320 File Offset: 0x00598720
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C95D RID: 51549
		private int opl_p0;

		// Token: 0x0400C95E RID: 51550
		private int opl_p1;

		// Token: 0x0400C95F RID: 51551
		private int opl_p2;

		// Token: 0x0400C960 RID: 51552
		private int opl_p3;

		// Token: 0x0400C961 RID: 51553
		private int opl_p4;

		// Token: 0x0400C962 RID: 51554
		private int opl_p5;

		// Token: 0x0400C963 RID: 51555
		private int opl_p6;

		// Token: 0x0400C964 RID: 51556
		private int opl_p7;
	}
}

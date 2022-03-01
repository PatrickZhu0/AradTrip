using System;

namespace behaviac
{
	// Token: 0x020022B0 RID: 8880
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node51 : Condition
	{
		// Token: 0x06012EDB RID: 77531 RVA: 0x00595FD4 File Offset: 0x005943D4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node51()
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

		// Token: 0x06012EDC RID: 77532 RVA: 0x00596040 File Offset: 0x00594440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8E4 RID: 51428
		private int opl_p0;

		// Token: 0x0400C8E5 RID: 51429
		private int opl_p1;

		// Token: 0x0400C8E6 RID: 51430
		private int opl_p2;

		// Token: 0x0400C8E7 RID: 51431
		private int opl_p3;

		// Token: 0x0400C8E8 RID: 51432
		private int opl_p4;

		// Token: 0x0400C8E9 RID: 51433
		private int opl_p5;

		// Token: 0x0400C8EA RID: 51434
		private int opl_p6;

		// Token: 0x0400C8EB RID: 51435
		private int opl_p7;
	}
}

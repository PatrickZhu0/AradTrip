using System;

namespace behaviac
{
	// Token: 0x0200225B RID: 8795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21 : Condition
	{
		// Token: 0x06012E3E RID: 77374 RVA: 0x00591908 File Offset: 0x0058FD08
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node21()
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

		// Token: 0x06012E3F RID: 77375 RVA: 0x00591974 File Offset: 0x0058FD74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C846 RID: 51270
		private int opl_p0;

		// Token: 0x0400C847 RID: 51271
		private int opl_p1;

		// Token: 0x0400C848 RID: 51272
		private int opl_p2;

		// Token: 0x0400C849 RID: 51273
		private int opl_p3;

		// Token: 0x0400C84A RID: 51274
		private int opl_p4;

		// Token: 0x0400C84B RID: 51275
		private int opl_p5;

		// Token: 0x0400C84C RID: 51276
		private int opl_p6;

		// Token: 0x0400C84D RID: 51277
		private int opl_p7;
	}
}

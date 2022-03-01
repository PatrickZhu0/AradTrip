using System;

namespace behaviac
{
	// Token: 0x0200220B RID: 8715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node16 : Condition
	{
		// Token: 0x06012DA0 RID: 77216 RVA: 0x0058CDC4 File Offset: 0x0058B1C4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node16()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
			this.opl_p4 = 10000;
			this.opl_p5 = 10000;
			this.opl_p6 = 10000;
			this.opl_p7 = 10000;
		}

		// Token: 0x06012DA1 RID: 77217 RVA: 0x0058CE30 File Offset: 0x0058B230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C78E RID: 51086
		private int opl_p0;

		// Token: 0x0400C78F RID: 51087
		private int opl_p1;

		// Token: 0x0400C790 RID: 51088
		private int opl_p2;

		// Token: 0x0400C791 RID: 51089
		private int opl_p3;

		// Token: 0x0400C792 RID: 51090
		private int opl_p4;

		// Token: 0x0400C793 RID: 51091
		private int opl_p5;

		// Token: 0x0400C794 RID: 51092
		private int opl_p6;

		// Token: 0x0400C795 RID: 51093
		private int opl_p7;
	}
}

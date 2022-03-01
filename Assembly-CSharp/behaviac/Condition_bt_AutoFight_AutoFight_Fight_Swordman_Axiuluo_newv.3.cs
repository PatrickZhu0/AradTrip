using System;

namespace behaviac
{
	// Token: 0x02002206 RID: 8710
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node4 : Condition
	{
		// Token: 0x06012D96 RID: 77206 RVA: 0x0058CB60 File Offset: 0x0058AF60
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node4()
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

		// Token: 0x06012D97 RID: 77207 RVA: 0x0058CBCC File Offset: 0x0058AFCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C77F RID: 51071
		private int opl_p0;

		// Token: 0x0400C780 RID: 51072
		private int opl_p1;

		// Token: 0x0400C781 RID: 51073
		private int opl_p2;

		// Token: 0x0400C782 RID: 51074
		private int opl_p3;

		// Token: 0x0400C783 RID: 51075
		private int opl_p4;

		// Token: 0x0400C784 RID: 51076
		private int opl_p5;

		// Token: 0x0400C785 RID: 51077
		private int opl_p6;

		// Token: 0x0400C786 RID: 51078
		private int opl_p7;
	}
}

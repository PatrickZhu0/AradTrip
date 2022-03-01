using System;

namespace behaviac
{
	// Token: 0x02002227 RID: 8743
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node60 : Condition
	{
		// Token: 0x06012DD8 RID: 77272 RVA: 0x0058E860 File Offset: 0x0058CC60
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node60()
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

		// Token: 0x06012DD9 RID: 77273 RVA: 0x0058E8CC File Offset: 0x0058CCCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7CE RID: 51150
		private int opl_p0;

		// Token: 0x0400C7CF RID: 51151
		private int opl_p1;

		// Token: 0x0400C7D0 RID: 51152
		private int opl_p2;

		// Token: 0x0400C7D1 RID: 51153
		private int opl_p3;

		// Token: 0x0400C7D2 RID: 51154
		private int opl_p4;

		// Token: 0x0400C7D3 RID: 51155
		private int opl_p5;

		// Token: 0x0400C7D4 RID: 51156
		private int opl_p6;

		// Token: 0x0400C7D5 RID: 51157
		private int opl_p7;
	}
}

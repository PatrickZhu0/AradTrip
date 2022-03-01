using System;

namespace behaviac
{
	// Token: 0x0200239C RID: 9116
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node40 : Condition
	{
		// Token: 0x0601309E RID: 77982 RVA: 0x005A28F0 File Offset: 0x005A0CF0
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node40()
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

		// Token: 0x0601309F RID: 77983 RVA: 0x005A295C File Offset: 0x005A0D5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CABE RID: 51902
		private int opl_p0;

		// Token: 0x0400CABF RID: 51903
		private int opl_p1;

		// Token: 0x0400CAC0 RID: 51904
		private int opl_p2;

		// Token: 0x0400CAC1 RID: 51905
		private int opl_p3;

		// Token: 0x0400CAC2 RID: 51906
		private int opl_p4;

		// Token: 0x0400CAC3 RID: 51907
		private int opl_p5;

		// Token: 0x0400CAC4 RID: 51908
		private int opl_p6;

		// Token: 0x0400CAC5 RID: 51909
		private int opl_p7;
	}
}

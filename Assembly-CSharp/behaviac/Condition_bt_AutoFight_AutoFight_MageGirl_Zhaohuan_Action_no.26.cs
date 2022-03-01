using System;

namespace behaviac
{
	// Token: 0x0200276B RID: 10091
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node11 : Condition
	{
		// Token: 0x06013817 RID: 79895 RVA: 0x005D021A File Offset: 0x005CE61A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node11()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013818 RID: 79896 RVA: 0x005D0250 File Offset: 0x005CE650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D277 RID: 53879
		private int opl_p0;

		// Token: 0x0400D278 RID: 53880
		private int opl_p1;

		// Token: 0x0400D279 RID: 53881
		private int opl_p2;

		// Token: 0x0400D27A RID: 53882
		private int opl_p3;
	}
}

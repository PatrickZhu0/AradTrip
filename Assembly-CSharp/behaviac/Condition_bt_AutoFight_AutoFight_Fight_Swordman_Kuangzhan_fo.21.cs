using System;

namespace behaviac
{
	// Token: 0x02002352 RID: 9042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node43 : Condition
	{
		// Token: 0x06013011 RID: 77841 RVA: 0x0059EB7F File Offset: 0x0059CF7F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node43()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013012 RID: 77842 RVA: 0x0059EBB4 File Offset: 0x0059CFB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA26 RID: 51750
		private int opl_p0;

		// Token: 0x0400CA27 RID: 51751
		private int opl_p1;

		// Token: 0x0400CA28 RID: 51752
		private int opl_p2;

		// Token: 0x0400CA29 RID: 51753
		private int opl_p3;
	}
}

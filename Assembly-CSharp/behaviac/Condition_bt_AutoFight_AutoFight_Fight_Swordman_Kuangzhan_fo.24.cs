using System;

namespace behaviac
{
	// Token: 0x02002356 RID: 9046
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node49 : Condition
	{
		// Token: 0x06013019 RID: 77849 RVA: 0x0059ED8F File Offset: 0x0059D18F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node49()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601301A RID: 77850 RVA: 0x0059EDC4 File Offset: 0x0059D1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA2E RID: 51758
		private int opl_p0;

		// Token: 0x0400CA2F RID: 51759
		private int opl_p1;

		// Token: 0x0400CA30 RID: 51760
		private int opl_p2;

		// Token: 0x0400CA31 RID: 51761
		private int opl_p3;
	}
}

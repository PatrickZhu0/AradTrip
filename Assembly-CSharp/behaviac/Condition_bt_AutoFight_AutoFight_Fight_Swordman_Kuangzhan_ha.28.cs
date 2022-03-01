using System;

namespace behaviac
{
	// Token: 0x0200238B RID: 9099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node55 : Condition
	{
		// Token: 0x0601307D RID: 77949 RVA: 0x005A126F File Offset: 0x0059F66F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601307E RID: 77950 RVA: 0x005A12A4 File Offset: 0x0059F6A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA92 RID: 51858
		private int opl_p0;

		// Token: 0x0400CA93 RID: 51859
		private int opl_p1;

		// Token: 0x0400CA94 RID: 51860
		private int opl_p2;

		// Token: 0x0400CA95 RID: 51861
		private int opl_p3;
	}
}

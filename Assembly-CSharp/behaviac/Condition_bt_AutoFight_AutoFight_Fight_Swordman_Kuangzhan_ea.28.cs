using System;

namespace behaviac
{
	// Token: 0x0200232B RID: 9003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node55 : Condition
	{
		// Token: 0x06012FC9 RID: 77769 RVA: 0x0059CCD7 File Offset: 0x0059B0D7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012FCA RID: 77770 RVA: 0x0059CD0C File Offset: 0x0059B10C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9E0 RID: 51680
		private int opl_p0;

		// Token: 0x0400C9E1 RID: 51681
		private int opl_p1;

		// Token: 0x0400C9E2 RID: 51682
		private int opl_p2;

		// Token: 0x0400C9E3 RID: 51683
		private int opl_p3;
	}
}

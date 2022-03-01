using System;

namespace behaviac
{
	// Token: 0x02002275 RID: 8821
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node25 : Condition
	{
		// Token: 0x06012E6E RID: 77422 RVA: 0x00592FB7 File Offset: 0x005913B7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node25()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 100;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012E6F RID: 77423 RVA: 0x00592FE8 File Offset: 0x005913E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C878 RID: 51320
		private int opl_p0;

		// Token: 0x0400C879 RID: 51321
		private int opl_p1;

		// Token: 0x0400C87A RID: 51322
		private int opl_p2;

		// Token: 0x0400C87B RID: 51323
		private int opl_p3;
	}
}

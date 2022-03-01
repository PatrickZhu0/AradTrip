using System;

namespace behaviac
{
	// Token: 0x0200226A RID: 8810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node5 : Condition
	{
		// Token: 0x06012E5A RID: 77402 RVA: 0x00592B8A File Offset: 0x00590F8A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012E5B RID: 77403 RVA: 0x00592BC0 File Offset: 0x00590FC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C867 RID: 51303
		private int opl_p0;

		// Token: 0x0400C868 RID: 51304
		private int opl_p1;

		// Token: 0x0400C869 RID: 51305
		private int opl_p2;

		// Token: 0x0400C86A RID: 51306
		private int opl_p3;
	}
}

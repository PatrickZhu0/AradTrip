using System;

namespace behaviac
{
	// Token: 0x0200267A RID: 9850
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node10 : Condition
	{
		// Token: 0x06013639 RID: 79417 RVA: 0x005C4E9B File Offset: 0x005C329B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node10()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601363A RID: 79418 RVA: 0x005C4ED0 File Offset: 0x005C32D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D08A RID: 53386
		private int opl_p0;

		// Token: 0x0400D08B RID: 53387
		private int opl_p1;

		// Token: 0x0400D08C RID: 53388
		private int opl_p2;

		// Token: 0x0400D08D RID: 53389
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028A5 RID: 10405
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node30 : Condition
	{
		// Token: 0x06013A84 RID: 80516 RVA: 0x005DECD3 File Offset: 0x005DD0D3
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013A85 RID: 80517 RVA: 0x005DED08 File Offset: 0x005DD108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4DE RID: 54494
		private int opl_p0;

		// Token: 0x0400D4DF RID: 54495
		private int opl_p1;

		// Token: 0x0400D4E0 RID: 54496
		private int opl_p2;

		// Token: 0x0400D4E1 RID: 54497
		private int opl_p3;
	}
}

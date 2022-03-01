using System;

namespace behaviac
{
	// Token: 0x020028A9 RID: 10409
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node23 : Condition
	{
		// Token: 0x06013A8C RID: 80524 RVA: 0x005DEE9E File Offset: 0x005DD29E
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A8D RID: 80525 RVA: 0x005DEED4 File Offset: 0x005DD2D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4E8 RID: 54504
		private int opl_p0;

		// Token: 0x0400D4E9 RID: 54505
		private int opl_p1;

		// Token: 0x0400D4EA RID: 54506
		private int opl_p2;

		// Token: 0x0400D4EB RID: 54507
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028D2 RID: 10450
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node63 : Condition
	{
		// Token: 0x06013ADE RID: 80606 RVA: 0x005E0123 File Offset: 0x005DE523
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node63()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013ADF RID: 80607 RVA: 0x005E0158 File Offset: 0x005DE558
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D53D RID: 54589
		private int opl_p0;

		// Token: 0x0400D53E RID: 54590
		private int opl_p1;

		// Token: 0x0400D53F RID: 54591
		private int opl_p2;

		// Token: 0x0400D540 RID: 54592
		private int opl_p3;
	}
}

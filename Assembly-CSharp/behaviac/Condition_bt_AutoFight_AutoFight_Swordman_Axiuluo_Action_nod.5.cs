using System;

namespace behaviac
{
	// Token: 0x0200289F RID: 10399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node5 : Condition
	{
		// Token: 0x06013A78 RID: 80504 RVA: 0x005DE96E File Offset: 0x005DCD6E
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013A79 RID: 80505 RVA: 0x005DE9A4 File Offset: 0x005DCDA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4D2 RID: 54482
		private int opl_p0;

		// Token: 0x0400D4D3 RID: 54483
		private int opl_p1;

		// Token: 0x0400D4D4 RID: 54484
		private int opl_p2;

		// Token: 0x0400D4D5 RID: 54485
		private int opl_p3;
	}
}

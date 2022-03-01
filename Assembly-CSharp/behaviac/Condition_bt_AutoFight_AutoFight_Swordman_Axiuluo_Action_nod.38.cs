using System;

namespace behaviac
{
	// Token: 0x020028C9 RID: 10441
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node95 : Condition
	{
		// Token: 0x06013ACC RID: 80588 RVA: 0x005DFCA3 File Offset: 0x005DE0A3
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node95()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013ACD RID: 80589 RVA: 0x005DFCD8 File Offset: 0x005DE0D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D52A RID: 54570
		private int opl_p0;

		// Token: 0x0400D52B RID: 54571
		private int opl_p1;

		// Token: 0x0400D52C RID: 54572
		private int opl_p2;

		// Token: 0x0400D52D RID: 54573
		private int opl_p3;
	}
}

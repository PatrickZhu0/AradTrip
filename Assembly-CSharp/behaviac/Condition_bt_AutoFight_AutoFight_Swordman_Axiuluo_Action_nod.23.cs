using System;

namespace behaviac
{
	// Token: 0x020028B6 RID: 10422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node38 : Condition
	{
		// Token: 0x06013AA6 RID: 80550 RVA: 0x005DF457 File Offset: 0x005DD857
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node38()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013AA7 RID: 80551 RVA: 0x005DF48C File Offset: 0x005DD88C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D501 RID: 54529
		private int opl_p0;

		// Token: 0x0400D502 RID: 54530
		private int opl_p1;

		// Token: 0x0400D503 RID: 54531
		private int opl_p2;

		// Token: 0x0400D504 RID: 54532
		private int opl_p3;
	}
}

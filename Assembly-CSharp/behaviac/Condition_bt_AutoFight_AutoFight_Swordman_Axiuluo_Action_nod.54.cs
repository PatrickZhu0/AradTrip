using System;

namespace behaviac
{
	// Token: 0x020028DE RID: 10462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node86 : Condition
	{
		// Token: 0x06013AF6 RID: 80630 RVA: 0x005E076F File Offset: 0x005DEB6F
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node86()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013AF7 RID: 80631 RVA: 0x005E07A4 File Offset: 0x005DEBA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D559 RID: 54617
		private int opl_p0;

		// Token: 0x0400D55A RID: 54618
		private int opl_p1;

		// Token: 0x0400D55B RID: 54619
		private int opl_p2;

		// Token: 0x0400D55C RID: 54620
		private int opl_p3;
	}
}

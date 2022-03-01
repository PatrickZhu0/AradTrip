using System;

namespace behaviac
{
	// Token: 0x02002871 RID: 10353
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node21 : Condition
	{
		// Token: 0x06013A1F RID: 80415 RVA: 0x005DC787 File Offset: 0x005DAB87
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node21()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013A20 RID: 80416 RVA: 0x005DC7BC File Offset: 0x005DABBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D477 RID: 54391
		private int opl_p0;

		// Token: 0x0400D478 RID: 54392
		private int opl_p1;

		// Token: 0x0400D479 RID: 54393
		private int opl_p2;

		// Token: 0x0400D47A RID: 54394
		private int opl_p3;
	}
}

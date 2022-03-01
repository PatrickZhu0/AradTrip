using System;

namespace behaviac
{
	// Token: 0x020028FD RID: 10493
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node18 : Condition
	{
		// Token: 0x06013B31 RID: 80689 RVA: 0x005E2A56 File Offset: 0x005E0E56
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013B32 RID: 80690 RVA: 0x005E2A8C File Offset: 0x005E0E8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D593 RID: 54675
		private int opl_p0;

		// Token: 0x0400D594 RID: 54676
		private int opl_p1;

		// Token: 0x0400D595 RID: 54677
		private int opl_p2;

		// Token: 0x0400D596 RID: 54678
		private int opl_p3;
	}
}

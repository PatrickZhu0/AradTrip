using System;

namespace behaviac
{
	// Token: 0x020028F1 RID: 10481
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node5 : Condition
	{
		// Token: 0x06013B19 RID: 80665 RVA: 0x005E253A File Offset: 0x005E093A
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013B1A RID: 80666 RVA: 0x005E2570 File Offset: 0x005E0970
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D57B RID: 54651
		private int opl_p0;

		// Token: 0x0400D57C RID: 54652
		private int opl_p1;

		// Token: 0x0400D57D RID: 54653
		private int opl_p2;

		// Token: 0x0400D57E RID: 54654
		private int opl_p3;
	}
}

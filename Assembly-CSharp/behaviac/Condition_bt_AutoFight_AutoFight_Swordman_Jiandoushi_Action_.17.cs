using System;

namespace behaviac
{
	// Token: 0x020028F9 RID: 10489
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node55 : Condition
	{
		// Token: 0x06013B29 RID: 80681 RVA: 0x005E28A2 File Offset: 0x005E0CA2
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node55()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013B2A RID: 80682 RVA: 0x005E28D8 File Offset: 0x005E0CD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D58B RID: 54667
		private int opl_p0;

		// Token: 0x0400D58C RID: 54668
		private int opl_p1;

		// Token: 0x0400D58D RID: 54669
		private int opl_p2;

		// Token: 0x0400D58E RID: 54670
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020028F5 RID: 10485
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node25 : Condition
	{
		// Token: 0x06013B21 RID: 80673 RVA: 0x005E26EE File Offset: 0x005E0AEE
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node25()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013B22 RID: 80674 RVA: 0x005E2724 File Offset: 0x005E0B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D583 RID: 54659
		private int opl_p0;

		// Token: 0x0400D584 RID: 54660
		private int opl_p1;

		// Token: 0x0400D585 RID: 54661
		private int opl_p2;

		// Token: 0x0400D586 RID: 54662
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200292A RID: 10538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node43 : Condition
	{
		// Token: 0x06013B8A RID: 80778 RVA: 0x005E4B02 File Offset: 0x005E2F02
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node43()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013B8B RID: 80779 RVA: 0x005E4B38 File Offset: 0x005E2F38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5EF RID: 54767
		private int opl_p0;

		// Token: 0x0400D5F0 RID: 54768
		private int opl_p1;

		// Token: 0x0400D5F1 RID: 54769
		private int opl_p2;

		// Token: 0x0400D5F2 RID: 54770
		private int opl_p3;
	}
}

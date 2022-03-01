using System;

namespace behaviac
{
	// Token: 0x0200291A RID: 10522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node5 : Condition
	{
		// Token: 0x06013B6A RID: 80746 RVA: 0x005E437B File Offset: 0x005E277B
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013B6B RID: 80747 RVA: 0x005E43B0 File Offset: 0x005E27B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5CF RID: 54735
		private int opl_p0;

		// Token: 0x0400D5D0 RID: 54736
		private int opl_p1;

		// Token: 0x0400D5D1 RID: 54737
		private int opl_p2;

		// Token: 0x0400D5D2 RID: 54738
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x020027B7 RID: 10167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node7 : Condition
	{
		// Token: 0x060138AD RID: 80045 RVA: 0x005D41FA File Offset: 0x005D25FA
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node7()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060138AE RID: 80046 RVA: 0x005D4230 File Offset: 0x005D2630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D30B RID: 54027
		private int opl_p0;

		// Token: 0x0400D30C RID: 54028
		private int opl_p1;

		// Token: 0x0400D30D RID: 54029
		private int opl_p2;

		// Token: 0x0400D30E RID: 54030
		private int opl_p3;
	}
}

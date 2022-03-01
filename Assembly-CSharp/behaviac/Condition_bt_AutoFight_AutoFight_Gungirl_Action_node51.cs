using System;

namespace behaviac
{
	// Token: 0x020024C5 RID: 9413
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node51 : Condition
	{
		// Token: 0x060132D5 RID: 78549 RVA: 0x005B11A7 File Offset: 0x005AF5A7
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node51()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060132D6 RID: 78550 RVA: 0x005B11DC File Offset: 0x005AF5DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCF1 RID: 52465
		private int opl_p0;

		// Token: 0x0400CCF2 RID: 52466
		private int opl_p1;

		// Token: 0x0400CCF3 RID: 52467
		private int opl_p2;

		// Token: 0x0400CCF4 RID: 52468
		private int opl_p3;
	}
}

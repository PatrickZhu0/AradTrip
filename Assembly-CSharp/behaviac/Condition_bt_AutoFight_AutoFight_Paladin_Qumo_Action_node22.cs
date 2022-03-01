using System;

namespace behaviac
{
	// Token: 0x020027C7 RID: 10183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node22 : Condition
	{
		// Token: 0x060138CD RID: 80077 RVA: 0x005D48CA File Offset: 0x005D2CCA
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060138CE RID: 80078 RVA: 0x005D4900 File Offset: 0x005D2D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D32B RID: 54059
		private int opl_p0;

		// Token: 0x0400D32C RID: 54060
		private int opl_p1;

		// Token: 0x0400D32D RID: 54061
		private int opl_p2;

		// Token: 0x0400D32E RID: 54062
		private int opl_p3;
	}
}

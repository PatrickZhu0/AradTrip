using System;

namespace behaviac
{
	// Token: 0x02002853 RID: 10323
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node91 : Condition
	{
		// Token: 0x060139E4 RID: 80356 RVA: 0x005DA00A File Offset: 0x005D840A
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node91()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060139E5 RID: 80357 RVA: 0x005DA040 File Offset: 0x005D8440
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D43C RID: 54332
		private int opl_p0;

		// Token: 0x0400D43D RID: 54333
		private int opl_p1;

		// Token: 0x0400D43E RID: 54334
		private int opl_p2;

		// Token: 0x0400D43F RID: 54335
		private int opl_p3;
	}
}

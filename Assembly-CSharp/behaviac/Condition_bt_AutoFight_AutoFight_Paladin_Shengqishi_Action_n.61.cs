using System;

namespace behaviac
{
	// Token: 0x02002863 RID: 10339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node111 : Condition
	{
		// Token: 0x06013A04 RID: 80388 RVA: 0x005DA6DA File Offset: 0x005D8ADA
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node111()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013A05 RID: 80389 RVA: 0x005DA710 File Offset: 0x005D8B10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D45C RID: 54364
		private int opl_p0;

		// Token: 0x0400D45D RID: 54365
		private int opl_p1;

		// Token: 0x0400D45E RID: 54366
		private int opl_p2;

		// Token: 0x0400D45F RID: 54367
		private int opl_p3;
	}
}

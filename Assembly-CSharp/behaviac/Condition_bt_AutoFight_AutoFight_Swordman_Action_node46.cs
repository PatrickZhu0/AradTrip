using System;

namespace behaviac
{
	// Token: 0x02002894 RID: 10388
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node46 : Condition
	{
		// Token: 0x06013A65 RID: 80485 RVA: 0x005DD85F File Offset: 0x005DBC5F
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node46()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013A66 RID: 80486 RVA: 0x005DD894 File Offset: 0x005DBC94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4C0 RID: 54464
		private int opl_p0;

		// Token: 0x0400D4C1 RID: 54465
		private int opl_p1;

		// Token: 0x0400D4C2 RID: 54466
		private int opl_p2;

		// Token: 0x0400D4C3 RID: 54467
		private int opl_p3;
	}
}

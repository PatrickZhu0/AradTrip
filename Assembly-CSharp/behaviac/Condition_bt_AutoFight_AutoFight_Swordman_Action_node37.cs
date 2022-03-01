using System;

namespace behaviac
{
	// Token: 0x02002889 RID: 10377
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node37 : Condition
	{
		// Token: 0x06013A4F RID: 80463 RVA: 0x005DD273 File Offset: 0x005DB673
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node37()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 0;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013A50 RID: 80464 RVA: 0x005DD2A4 File Offset: 0x005DB6A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4A7 RID: 54439
		private int opl_p0;

		// Token: 0x0400D4A8 RID: 54440
		private int opl_p1;

		// Token: 0x0400D4A9 RID: 54441
		private int opl_p2;

		// Token: 0x0400D4AA RID: 54442
		private int opl_p3;
	}
}

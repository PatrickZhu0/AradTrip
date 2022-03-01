using System;

namespace behaviac
{
	// Token: 0x02002879 RID: 10361
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node27 : Condition
	{
		// Token: 0x06013A2F RID: 80431 RVA: 0x005DCB4B File Offset: 0x005DAF4B
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node27()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013A30 RID: 80432 RVA: 0x005DCB80 File Offset: 0x005DAF80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D487 RID: 54407
		private int opl_p0;

		// Token: 0x0400D488 RID: 54408
		private int opl_p1;

		// Token: 0x0400D489 RID: 54409
		private int opl_p2;

		// Token: 0x0400D48A RID: 54410
		private int opl_p3;
	}
}

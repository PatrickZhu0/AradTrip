using System;

namespace behaviac
{
	// Token: 0x02002875 RID: 10357
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node17 : Condition
	{
		// Token: 0x06013A27 RID: 80423 RVA: 0x005DC93B File Offset: 0x005DAD3B
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013A28 RID: 80424 RVA: 0x005DC970 File Offset: 0x005DAD70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D47F RID: 54399
		private int opl_p0;

		// Token: 0x0400D480 RID: 54400
		private int opl_p1;

		// Token: 0x0400D481 RID: 54401
		private int opl_p2;

		// Token: 0x0400D482 RID: 54402
		private int opl_p3;
	}
}

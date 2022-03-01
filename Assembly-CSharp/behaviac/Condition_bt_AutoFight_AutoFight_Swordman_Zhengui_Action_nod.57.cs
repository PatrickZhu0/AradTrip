using System;

namespace behaviac
{
	// Token: 0x020029C7 RID: 10695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node95 : Condition
	{
		// Token: 0x06013CC2 RID: 81090 RVA: 0x005EB733 File Offset: 0x005E9B33
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node95()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013CC3 RID: 81091 RVA: 0x005EB768 File Offset: 0x005E9B68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D72F RID: 55087
		private int opl_p0;

		// Token: 0x0400D730 RID: 55088
		private int opl_p1;

		// Token: 0x0400D731 RID: 55089
		private int opl_p2;

		// Token: 0x0400D732 RID: 55090
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002977 RID: 10615
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node86 : Condition
	{
		// Token: 0x06013C23 RID: 80931 RVA: 0x005E811F File Offset: 0x005E651F
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node86()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013C24 RID: 80932 RVA: 0x005E8154 File Offset: 0x005E6554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D688 RID: 54920
		private int opl_p0;

		// Token: 0x0400D689 RID: 54921
		private int opl_p1;

		// Token: 0x0400D68A RID: 54922
		private int opl_p2;

		// Token: 0x0400D68B RID: 54923
		private int opl_p3;
	}
}

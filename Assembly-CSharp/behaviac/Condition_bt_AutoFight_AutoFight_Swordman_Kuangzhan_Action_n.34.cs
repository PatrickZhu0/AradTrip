using System;

namespace behaviac
{
	// Token: 0x02002971 RID: 10609
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node23 : Condition
	{
		// Token: 0x06013C17 RID: 80919 RVA: 0x005E7E66 File Offset: 0x005E6266
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013C18 RID: 80920 RVA: 0x005E7E9C File Offset: 0x005E629C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D67C RID: 54908
		private int opl_p0;

		// Token: 0x0400D67D RID: 54909
		private int opl_p1;

		// Token: 0x0400D67E RID: 54910
		private int opl_p2;

		// Token: 0x0400D67F RID: 54911
		private int opl_p3;
	}
}

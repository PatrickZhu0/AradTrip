using System;

namespace behaviac
{
	// Token: 0x02002403 RID: 9219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node55 : Condition
	{
		// Token: 0x06013165 RID: 78181 RVA: 0x005A855F File Offset: 0x005A695F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node55()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013166 RID: 78182 RVA: 0x005A8594 File Offset: 0x005A6994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB8F RID: 52111
		private int opl_p0;

		// Token: 0x0400CB90 RID: 52112
		private int opl_p1;

		// Token: 0x0400CB91 RID: 52113
		private int opl_p2;

		// Token: 0x0400CB92 RID: 52114
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002946 RID: 10566
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node24 : Condition
	{
		// Token: 0x06013BC1 RID: 80833 RVA: 0x005E6BE2 File Offset: 0x005E4FE2
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node24()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06013BC2 RID: 80834 RVA: 0x005E6C18 File Offset: 0x005E5018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D625 RID: 54821
		private int opl_p0;

		// Token: 0x0400D626 RID: 54822
		private int opl_p1;

		// Token: 0x0400D627 RID: 54823
		private int opl_p2;

		// Token: 0x0400D628 RID: 54824
		private int opl_p3;
	}
}

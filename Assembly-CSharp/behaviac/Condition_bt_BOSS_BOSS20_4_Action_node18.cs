using System;

namespace behaviac
{
	// Token: 0x020029EF RID: 10735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node18 : Condition
	{
		// Token: 0x06013D11 RID: 81169 RVA: 0x005EE536 File Offset: 0x005EC936
		public Condition_bt_BOSS_BOSS20_4_Action_node18()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013D12 RID: 81170 RVA: 0x005EE56C File Offset: 0x005EC96C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D784 RID: 55172
		private int opl_p0;

		// Token: 0x0400D785 RID: 55173
		private int opl_p1;

		// Token: 0x0400D786 RID: 55174
		private int opl_p2;

		// Token: 0x0400D787 RID: 55175
		private int opl_p3;
	}
}

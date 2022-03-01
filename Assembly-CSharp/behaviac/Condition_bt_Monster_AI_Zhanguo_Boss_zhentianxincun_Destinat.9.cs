using System;

namespace behaviac
{
	// Token: 0x02003EDC RID: 16092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node18 : Condition
	{
		// Token: 0x06016534 RID: 91444 RVA: 0x006C0CA5 File Offset: 0x006BF0A5
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node18()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016535 RID: 91445 RVA: 0x006C0CDC File Offset: 0x006BF0DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD67 RID: 64871
		private int opl_p0;

		// Token: 0x0400FD68 RID: 64872
		private int opl_p1;

		// Token: 0x0400FD69 RID: 64873
		private int opl_p2;

		// Token: 0x0400FD6A RID: 64874
		private int opl_p3;
	}
}

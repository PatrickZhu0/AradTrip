using System;

namespace behaviac
{
	// Token: 0x02002FE6 RID: 12262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node18 : Condition
	{
		// Token: 0x06014897 RID: 84119 RVA: 0x0062E7F3 File Offset: 0x0062CBF3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014898 RID: 84120 RVA: 0x0062E828 File Offset: 0x0062CC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1F4 RID: 57844
		private int opl_p0;

		// Token: 0x0400E1F5 RID: 57845
		private int opl_p1;

		// Token: 0x0400E1F6 RID: 57846
		private int opl_p2;

		// Token: 0x0400E1F7 RID: 57847
		private int opl_p3;
	}
}

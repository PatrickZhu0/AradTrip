using System;

namespace behaviac
{
	// Token: 0x02002FE3 RID: 12259
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node14 : Condition
	{
		// Token: 0x06014891 RID: 84113 RVA: 0x0062E707 File Offset: 0x0062CB07
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014892 RID: 84114 RVA: 0x0062E73C File Offset: 0x0062CB3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1EE RID: 57838
		private int opl_p0;

		// Token: 0x0400E1EF RID: 57839
		private int opl_p1;

		// Token: 0x0400E1F0 RID: 57840
		private int opl_p2;

		// Token: 0x0400E1F1 RID: 57841
		private int opl_p3;
	}
}

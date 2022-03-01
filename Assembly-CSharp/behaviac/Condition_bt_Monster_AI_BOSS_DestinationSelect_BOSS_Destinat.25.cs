using System;

namespace behaviac
{
	// Token: 0x02002FD1 RID: 12241
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node22 : Condition
	{
		// Token: 0x0601486E RID: 84078 RVA: 0x0062D9BB File Offset: 0x0062BDBB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601486F RID: 84079 RVA: 0x0062D9F0 File Offset: 0x0062BDF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1CB RID: 57803
		private int opl_p0;

		// Token: 0x0400E1CC RID: 57804
		private int opl_p1;

		// Token: 0x0400E1CD RID: 57805
		private int opl_p2;

		// Token: 0x0400E1CE RID: 57806
		private int opl_p3;
	}
}

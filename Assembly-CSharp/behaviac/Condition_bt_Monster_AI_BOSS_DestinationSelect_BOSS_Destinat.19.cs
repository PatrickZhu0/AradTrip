using System;

namespace behaviac
{
	// Token: 0x02002FC8 RID: 12232
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node10 : Condition
	{
		// Token: 0x0601485C RID: 84060 RVA: 0x0062D6F7 File Offset: 0x0062BAF7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601485D RID: 84061 RVA: 0x0062D72C File Offset: 0x0062BB2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B9 RID: 57785
		private int opl_p0;

		// Token: 0x0400E1BA RID: 57786
		private int opl_p1;

		// Token: 0x0400E1BB RID: 57787
		private int opl_p2;

		// Token: 0x0400E1BC RID: 57788
		private int opl_p3;
	}
}

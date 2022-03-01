using System;

namespace behaviac
{
	// Token: 0x02002FE0 RID: 12256
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node10 : Condition
	{
		// Token: 0x0601488B RID: 84107 RVA: 0x0062E61B File Offset: 0x0062CA1B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601488C RID: 84108 RVA: 0x0062E650 File Offset: 0x0062CA50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E8 RID: 57832
		private int opl_p0;

		// Token: 0x0400E1E9 RID: 57833
		private int opl_p1;

		// Token: 0x0400E1EA RID: 57834
		private int opl_p2;

		// Token: 0x0400E1EB RID: 57835
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002FDD RID: 12253
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node6 : Condition
	{
		// Token: 0x06014885 RID: 84101 RVA: 0x0062E52F File Offset: 0x0062C92F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014886 RID: 84102 RVA: 0x0062E564 File Offset: 0x0062C964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E2 RID: 57826
		private int opl_p0;

		// Token: 0x0400E1E3 RID: 57827
		private int opl_p1;

		// Token: 0x0400E1E4 RID: 57828
		private int opl_p2;

		// Token: 0x0400E1E5 RID: 57829
		private int opl_p3;
	}
}

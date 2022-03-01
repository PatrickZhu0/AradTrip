using System;

namespace behaviac
{
	// Token: 0x02003049 RID: 12361
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node14 : Condition
	{
		// Token: 0x06014959 RID: 84313 RVA: 0x0063273F File Offset: 0x00630B3F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601495A RID: 84314 RVA: 0x00632774 File Offset: 0x00630B74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2B6 RID: 58038
		private int opl_p0;

		// Token: 0x0400E2B7 RID: 58039
		private int opl_p1;

		// Token: 0x0400E2B8 RID: 58040
		private int opl_p2;

		// Token: 0x0400E2B9 RID: 58041
		private int opl_p3;
	}
}

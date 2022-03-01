using System;

namespace behaviac
{
	// Token: 0x02002FC5 RID: 12229
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node6 : Condition
	{
		// Token: 0x06014856 RID: 84054 RVA: 0x0062D60B File Offset: 0x0062BA0B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014857 RID: 84055 RVA: 0x0062D640 File Offset: 0x0062BA40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B3 RID: 57779
		private int opl_p0;

		// Token: 0x0400E1B4 RID: 57780
		private int opl_p1;

		// Token: 0x0400E1B5 RID: 57781
		private int opl_p2;

		// Token: 0x0400E1B6 RID: 57782
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002FC1 RID: 12225
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node34 : Condition
	{
		// Token: 0x0601484F RID: 84047 RVA: 0x0062CD13 File Offset: 0x0062B113
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014850 RID: 84048 RVA: 0x0062CD48 File Offset: 0x0062B148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1AD RID: 57773
		private int opl_p0;

		// Token: 0x0400E1AE RID: 57774
		private int opl_p1;

		// Token: 0x0400E1AF RID: 57775
		private int opl_p2;

		// Token: 0x0400E1B0 RID: 57776
		private int opl_p3;
	}
}

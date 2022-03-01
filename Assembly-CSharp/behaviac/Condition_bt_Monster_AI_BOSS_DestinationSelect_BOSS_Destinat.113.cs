using System;

namespace behaviac
{
	// Token: 0x0200305E RID: 12382
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node6 : Condition
	{
		// Token: 0x06014982 RID: 84354 RVA: 0x0063365F File Offset: 0x00631A5F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014983 RID: 84355 RVA: 0x00633694 File Offset: 0x00631A94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2DF RID: 58079
		private int opl_p0;

		// Token: 0x0400E2E0 RID: 58080
		private int opl_p1;

		// Token: 0x0400E2E1 RID: 58081
		private int opl_p2;

		// Token: 0x0400E2E2 RID: 58082
		private int opl_p3;
	}
}

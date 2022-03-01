using System;

namespace behaviac
{
	// Token: 0x02003046 RID: 12358
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node10 : Condition
	{
		// Token: 0x06014953 RID: 84307 RVA: 0x00632653 File Offset: 0x00630A53
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014954 RID: 84308 RVA: 0x00632688 File Offset: 0x00630A88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2B0 RID: 58032
		private int opl_p0;

		// Token: 0x0400E2B1 RID: 58033
		private int opl_p1;

		// Token: 0x0400E2B2 RID: 58034
		private int opl_p2;

		// Token: 0x0400E2B3 RID: 58035
		private int opl_p3;
	}
}

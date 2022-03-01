using System;

namespace behaviac
{
	// Token: 0x0200307A RID: 12410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node10 : Condition
	{
		// Token: 0x060149B9 RID: 84409 RVA: 0x006346EF File Offset: 0x00632AEF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149BA RID: 84410 RVA: 0x00634724 File Offset: 0x00632B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E315 RID: 58133
		private int opl_p0;

		// Token: 0x0400E316 RID: 58134
		private int opl_p1;

		// Token: 0x0400E317 RID: 58135
		private int opl_p2;

		// Token: 0x0400E318 RID: 58136
		private int opl_p3;
	}
}

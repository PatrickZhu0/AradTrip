using System;

namespace behaviac
{
	// Token: 0x02003064 RID: 12388
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node14 : Condition
	{
		// Token: 0x0601498E RID: 84366 RVA: 0x00633837 File Offset: 0x00631C37
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601498F RID: 84367 RVA: 0x0063386C File Offset: 0x00631C6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2EB RID: 58091
		private int opl_p0;

		// Token: 0x0400E2EC RID: 58092
		private int opl_p1;

		// Token: 0x0400E2ED RID: 58093
		private int opl_p2;

		// Token: 0x0400E2EE RID: 58094
		private int opl_p3;
	}
}

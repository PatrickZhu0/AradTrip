using System;

namespace behaviac
{
	// Token: 0x0200331B RID: 13083
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node16 : Condition
	{
		// Token: 0x06014E9D RID: 85661 RVA: 0x0064D17D File Offset: 0x0064B57D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node16()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014E9E RID: 85662 RVA: 0x0064D1B4 File Offset: 0x0064B5B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E78B RID: 59275
		private int opl_p0;

		// Token: 0x0400E78C RID: 59276
		private int opl_p1;

		// Token: 0x0400E78D RID: 59277
		private int opl_p2;

		// Token: 0x0400E78E RID: 59278
		private int opl_p3;
	}
}

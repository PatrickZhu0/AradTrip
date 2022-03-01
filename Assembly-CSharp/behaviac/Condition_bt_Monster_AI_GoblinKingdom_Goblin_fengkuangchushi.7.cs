using System;

namespace behaviac
{
	// Token: 0x0200331E RID: 13086
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node17 : Condition
	{
		// Token: 0x06014EA3 RID: 85667 RVA: 0x0064D269 File Offset: 0x0064B669
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014EA4 RID: 85668 RVA: 0x0064D2A0 File Offset: 0x0064B6A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E791 RID: 59281
		private int opl_p0;

		// Token: 0x0400E792 RID: 59282
		private int opl_p1;

		// Token: 0x0400E793 RID: 59283
		private int opl_p2;

		// Token: 0x0400E794 RID: 59284
		private int opl_p3;
	}
}

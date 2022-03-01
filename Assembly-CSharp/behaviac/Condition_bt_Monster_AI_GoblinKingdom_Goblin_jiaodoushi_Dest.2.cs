using System;

namespace behaviac
{
	// Token: 0x02003334 RID: 13108
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node0 : Condition
	{
		// Token: 0x06014ECC RID: 85708 RVA: 0x0064E10D File Offset: 0x0064C50D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node0()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06014ECD RID: 85709 RVA: 0x0064E144 File Offset: 0x0064C544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7B2 RID: 59314
		private int opl_p0;

		// Token: 0x0400E7B3 RID: 59315
		private int opl_p1;

		// Token: 0x0400E7B4 RID: 59316
		private int opl_p2;

		// Token: 0x0400E7B5 RID: 59317
		private int opl_p3;
	}
}

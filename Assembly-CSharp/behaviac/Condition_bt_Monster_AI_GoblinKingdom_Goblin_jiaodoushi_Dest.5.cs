using System;

namespace behaviac
{
	// Token: 0x02003338 RID: 13112
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node14 : Condition
	{
		// Token: 0x06014ED4 RID: 85716 RVA: 0x0064E279 File Offset: 0x0064C679
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node14()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014ED5 RID: 85717 RVA: 0x0064E2B0 File Offset: 0x0064C6B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7BC RID: 59324
		private int opl_p0;

		// Token: 0x0400E7BD RID: 59325
		private int opl_p1;

		// Token: 0x0400E7BE RID: 59326
		private int opl_p2;

		// Token: 0x0400E7BF RID: 59327
		private int opl_p3;
	}
}

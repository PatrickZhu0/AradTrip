using System;

namespace behaviac
{
	// Token: 0x02003333 RID: 13107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node5 : Condition
	{
		// Token: 0x06014ECA RID: 85706 RVA: 0x0064E092 File Offset: 0x0064C492
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node5()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014ECB RID: 85707 RVA: 0x0064E0C8 File Offset: 0x0064C4C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7AE RID: 59310
		private int opl_p0;

		// Token: 0x0400E7AF RID: 59311
		private int opl_p1;

		// Token: 0x0400E7B0 RID: 59312
		private int opl_p2;

		// Token: 0x0400E7B1 RID: 59313
		private int opl_p3;
	}
}

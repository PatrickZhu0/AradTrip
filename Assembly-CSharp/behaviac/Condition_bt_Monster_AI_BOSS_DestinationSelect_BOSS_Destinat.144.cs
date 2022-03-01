using System;

namespace behaviac
{
	// Token: 0x0200308E RID: 12430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node38 : Condition
	{
		// Token: 0x060149E1 RID: 84449 RVA: 0x00634D1B File Offset: 0x0063311B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node38()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060149E2 RID: 84450 RVA: 0x00634D50 File Offset: 0x00633150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E33E RID: 58174
		private int opl_p0;

		// Token: 0x0400E33F RID: 58175
		private int opl_p1;

		// Token: 0x0400E340 RID: 58176
		private int opl_p2;

		// Token: 0x0400E341 RID: 58177
		private int opl_p3;
	}
}

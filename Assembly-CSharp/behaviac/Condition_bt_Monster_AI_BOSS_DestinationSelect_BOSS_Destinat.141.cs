using System;

namespace behaviac
{
	// Token: 0x02003089 RID: 12425
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node30 : Condition
	{
		// Token: 0x060149D7 RID: 84439 RVA: 0x00634B8B File Offset: 0x00632F8B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060149D8 RID: 84440 RVA: 0x00634BC0 File Offset: 0x00632FC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E333 RID: 58163
		private int opl_p0;

		// Token: 0x0400E334 RID: 58164
		private int opl_p1;

		// Token: 0x0400E335 RID: 58165
		private int opl_p2;

		// Token: 0x0400E336 RID: 58166
		private int opl_p3;
	}
}

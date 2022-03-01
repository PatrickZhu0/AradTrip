using System;

namespace behaviac
{
	// Token: 0x02002FF5 RID: 12277
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node6 : Condition
	{
		// Token: 0x060148B4 RID: 84148 RVA: 0x0062F453 File Offset: 0x0062D853
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060148B5 RID: 84149 RVA: 0x0062F488 File Offset: 0x0062D888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E211 RID: 57873
		private int opl_p0;

		// Token: 0x0400E212 RID: 57874
		private int opl_p1;

		// Token: 0x0400E213 RID: 57875
		private int opl_p2;

		// Token: 0x0400E214 RID: 57876
		private int opl_p3;
	}
}

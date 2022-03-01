using System;

namespace behaviac
{
	// Token: 0x02002FFE RID: 12286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node18 : Condition
	{
		// Token: 0x060148C6 RID: 84166 RVA: 0x0062F717 File Offset: 0x0062DB17
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060148C7 RID: 84167 RVA: 0x0062F74C File Offset: 0x0062DB4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E223 RID: 57891
		private int opl_p0;

		// Token: 0x0400E224 RID: 57892
		private int opl_p1;

		// Token: 0x0400E225 RID: 57893
		private int opl_p2;

		// Token: 0x0400E226 RID: 57894
		private int opl_p3;
	}
}

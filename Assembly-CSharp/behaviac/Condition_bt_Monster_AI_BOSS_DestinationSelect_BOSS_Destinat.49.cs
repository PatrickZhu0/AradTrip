using System;

namespace behaviac
{
	// Token: 0x02002FF8 RID: 12280
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node10 : Condition
	{
		// Token: 0x060148BA RID: 84154 RVA: 0x0062F53F File Offset: 0x0062D93F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060148BB RID: 84155 RVA: 0x0062F574 File Offset: 0x0062D974
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E217 RID: 57879
		private int opl_p0;

		// Token: 0x0400E218 RID: 57880
		private int opl_p1;

		// Token: 0x0400E219 RID: 57881
		private int opl_p2;

		// Token: 0x0400E21A RID: 57882
		private int opl_p3;
	}
}

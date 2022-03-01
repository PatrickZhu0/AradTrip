using System;

namespace behaviac
{
	// Token: 0x02003004 RID: 12292
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node26 : Condition
	{
		// Token: 0x060148D2 RID: 84178 RVA: 0x0062F8EF File Offset: 0x0062DCEF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node26()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148D3 RID: 84179 RVA: 0x0062F924 File Offset: 0x0062DD24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E22F RID: 57903
		private int opl_p0;

		// Token: 0x0400E230 RID: 57904
		private int opl_p1;

		// Token: 0x0400E231 RID: 57905
		private int opl_p2;

		// Token: 0x0400E232 RID: 57906
		private int opl_p3;
	}
}

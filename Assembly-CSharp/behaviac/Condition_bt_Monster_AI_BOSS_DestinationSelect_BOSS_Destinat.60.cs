using System;

namespace behaviac
{
	// Token: 0x02003009 RID: 12297
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node34 : Condition
	{
		// Token: 0x060148DC RID: 84188 RVA: 0x0062FA7F File Offset: 0x0062DE7F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148DD RID: 84189 RVA: 0x0062FAB4 File Offset: 0x0062DEB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E23A RID: 57914
		private int opl_p0;

		// Token: 0x0400E23B RID: 57915
		private int opl_p1;

		// Token: 0x0400E23C RID: 57916
		private int opl_p2;

		// Token: 0x0400E23D RID: 57917
		private int opl_p3;
	}
}

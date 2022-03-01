using System;

namespace behaviac
{
	// Token: 0x02002FFB RID: 12283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node14 : Condition
	{
		// Token: 0x060148C0 RID: 84160 RVA: 0x0062F62B File Offset: 0x0062DA2B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node14()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060148C1 RID: 84161 RVA: 0x0062F660 File Offset: 0x0062DA60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E21D RID: 57885
		private int opl_p0;

		// Token: 0x0400E21E RID: 57886
		private int opl_p1;

		// Token: 0x0400E21F RID: 57887
		private int opl_p2;

		// Token: 0x0400E220 RID: 57888
		private int opl_p3;
	}
}

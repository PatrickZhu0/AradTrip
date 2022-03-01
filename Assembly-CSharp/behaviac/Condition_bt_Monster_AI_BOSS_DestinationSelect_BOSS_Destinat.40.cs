using System;

namespace behaviac
{
	// Token: 0x02002FE9 RID: 12265
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node22 : Condition
	{
		// Token: 0x0601489D RID: 84125 RVA: 0x0062E8DF File Offset: 0x0062CCDF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601489E RID: 84126 RVA: 0x0062E914 File Offset: 0x0062CD14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1FA RID: 57850
		private int opl_p0;

		// Token: 0x0400E1FB RID: 57851
		private int opl_p1;

		// Token: 0x0400E1FC RID: 57852
		private int opl_p2;

		// Token: 0x0400E1FD RID: 57853
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002FF1 RID: 12273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node34 : Condition
	{
		// Token: 0x060148AD RID: 84141 RVA: 0x0062EB5B File Offset: 0x0062CF5B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148AE RID: 84142 RVA: 0x0062EB90 File Offset: 0x0062CF90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E20B RID: 57867
		private int opl_p0;

		// Token: 0x0400E20C RID: 57868
		private int opl_p1;

		// Token: 0x0400E20D RID: 57869
		private int opl_p2;

		// Token: 0x0400E20E RID: 57870
		private int opl_p3;
	}
}

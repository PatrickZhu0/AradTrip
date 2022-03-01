using System;

namespace behaviac
{
	// Token: 0x02002FEF RID: 12271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node30 : Condition
	{
		// Token: 0x060148A9 RID: 84137 RVA: 0x0062EAB7 File Offset: 0x0062CEB7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148AA RID: 84138 RVA: 0x0062EAEC File Offset: 0x0062CEEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E206 RID: 57862
		private int opl_p0;

		// Token: 0x0400E207 RID: 57863
		private int opl_p1;

		// Token: 0x0400E208 RID: 57864
		private int opl_p2;

		// Token: 0x0400E209 RID: 57865
		private int opl_p3;
	}
}

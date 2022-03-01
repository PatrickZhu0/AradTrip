using System;

namespace behaviac
{
	// Token: 0x02002FCE RID: 12238
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node18 : Condition
	{
		// Token: 0x06014868 RID: 84072 RVA: 0x0062D8CF File Offset: 0x0062BCCF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014869 RID: 84073 RVA: 0x0062D904 File Offset: 0x0062BD04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1C5 RID: 57797
		private int opl_p0;

		// Token: 0x0400E1C6 RID: 57798
		private int opl_p1;

		// Token: 0x0400E1C7 RID: 57799
		private int opl_p2;

		// Token: 0x0400E1C8 RID: 57800
		private int opl_p3;
	}
}

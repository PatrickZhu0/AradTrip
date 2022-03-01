using System;

namespace behaviac
{
	// Token: 0x02002FB9 RID: 12217
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node22 : Condition
	{
		// Token: 0x0601483F RID: 84031 RVA: 0x0062CA97 File Offset: 0x0062AE97
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014840 RID: 84032 RVA: 0x0062CACC File Offset: 0x0062AECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E19C RID: 57756
		private int opl_p0;

		// Token: 0x0400E19D RID: 57757
		private int opl_p1;

		// Token: 0x0400E19E RID: 57758
		private int opl_p2;

		// Token: 0x0400E19F RID: 57759
		private int opl_p3;
	}
}

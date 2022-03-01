using System;

namespace behaviac
{
	// Token: 0x02003052 RID: 12370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node26 : Condition
	{
		// Token: 0x0601496B RID: 84331 RVA: 0x00632A03 File Offset: 0x00630E03
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601496C RID: 84332 RVA: 0x00632A38 File Offset: 0x00630E38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C8 RID: 58056
		private int opl_p0;

		// Token: 0x0400E2C9 RID: 58057
		private int opl_p1;

		// Token: 0x0400E2CA RID: 58058
		private int opl_p2;

		// Token: 0x0400E2CB RID: 58059
		private int opl_p3;
	}
}

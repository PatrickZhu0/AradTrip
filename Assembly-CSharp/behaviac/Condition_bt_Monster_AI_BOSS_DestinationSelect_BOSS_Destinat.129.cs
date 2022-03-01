using System;

namespace behaviac
{
	// Token: 0x02003077 RID: 12407
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node6 : Condition
	{
		// Token: 0x060149B3 RID: 84403 RVA: 0x00634603 File Offset: 0x00632A03
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149B4 RID: 84404 RVA: 0x00634638 File Offset: 0x00632A38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E30F RID: 58127
		private int opl_p0;

		// Token: 0x0400E310 RID: 58128
		private int opl_p1;

		// Token: 0x0400E311 RID: 58129
		private int opl_p2;

		// Token: 0x0400E312 RID: 58130
		private int opl_p3;
	}
}

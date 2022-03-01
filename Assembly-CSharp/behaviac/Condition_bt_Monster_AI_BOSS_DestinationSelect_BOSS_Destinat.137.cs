using System;

namespace behaviac
{
	// Token: 0x02003083 RID: 12419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node22 : Condition
	{
		// Token: 0x060149CB RID: 84427 RVA: 0x006349B3 File Offset: 0x00632DB3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060149CC RID: 84428 RVA: 0x006349E8 File Offset: 0x00632DE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E327 RID: 58151
		private int opl_p0;

		// Token: 0x0400E328 RID: 58152
		private int opl_p1;

		// Token: 0x0400E329 RID: 58153
		private int opl_p2;

		// Token: 0x0400E32A RID: 58154
		private int opl_p3;
	}
}

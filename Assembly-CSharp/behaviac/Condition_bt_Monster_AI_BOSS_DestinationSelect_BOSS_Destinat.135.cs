using System;

namespace behaviac
{
	// Token: 0x02003080 RID: 12416
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node18 : Condition
	{
		// Token: 0x060149C5 RID: 84421 RVA: 0x006348C7 File Offset: 0x00632CC7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060149C6 RID: 84422 RVA: 0x006348FC File Offset: 0x00632CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E321 RID: 58145
		private int opl_p0;

		// Token: 0x0400E322 RID: 58146
		private int opl_p1;

		// Token: 0x0400E323 RID: 58147
		private int opl_p2;

		// Token: 0x0400E324 RID: 58148
		private int opl_p3;
	}
}

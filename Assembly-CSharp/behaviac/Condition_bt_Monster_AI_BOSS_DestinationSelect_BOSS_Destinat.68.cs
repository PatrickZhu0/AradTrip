using System;

namespace behaviac
{
	// Token: 0x02003016 RID: 12310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node18 : Condition
	{
		// Token: 0x060148F5 RID: 84213 RVA: 0x0063063B File Offset: 0x0062EA3B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060148F6 RID: 84214 RVA: 0x00630670 File Offset: 0x0062EA70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E252 RID: 57938
		private int opl_p0;

		// Token: 0x0400E253 RID: 57939
		private int opl_p1;

		// Token: 0x0400E254 RID: 57940
		private int opl_p2;

		// Token: 0x0400E255 RID: 57941
		private int opl_p3;
	}
}

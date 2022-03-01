using System;

namespace behaviac
{
	// Token: 0x0200304F RID: 12367
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node22 : Condition
	{
		// Token: 0x06014965 RID: 84325 RVA: 0x00632917 File Offset: 0x00630D17
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014966 RID: 84326 RVA: 0x0063294C File Offset: 0x00630D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C2 RID: 58050
		private int opl_p0;

		// Token: 0x0400E2C3 RID: 58051
		private int opl_p1;

		// Token: 0x0400E2C4 RID: 58052
		private int opl_p2;

		// Token: 0x0400E2C5 RID: 58053
		private int opl_p3;
	}
}

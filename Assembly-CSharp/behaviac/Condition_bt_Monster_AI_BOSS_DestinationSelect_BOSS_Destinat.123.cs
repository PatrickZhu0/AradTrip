using System;

namespace behaviac
{
	// Token: 0x0200306D RID: 12397
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node26 : Condition
	{
		// Token: 0x060149A0 RID: 84384 RVA: 0x00633AFB File Offset: 0x00631EFB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060149A1 RID: 84385 RVA: 0x00633B30 File Offset: 0x00631F30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2FD RID: 58109
		private int opl_p0;

		// Token: 0x0400E2FE RID: 58110
		private int opl_p1;

		// Token: 0x0400E2FF RID: 58111
		private int opl_p2;

		// Token: 0x0400E300 RID: 58112
		private int opl_p3;
	}
}

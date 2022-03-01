using System;

namespace behaviac
{
	// Token: 0x0200307D RID: 12413
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node14 : Condition
	{
		// Token: 0x060149BF RID: 84415 RVA: 0x006347DB File Offset: 0x00632BDB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149C0 RID: 84416 RVA: 0x00634810 File Offset: 0x00632C10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E31B RID: 58139
		private int opl_p0;

		// Token: 0x0400E31C RID: 58140
		private int opl_p1;

		// Token: 0x0400E31D RID: 58141
		private int opl_p2;

		// Token: 0x0400E31E RID: 58142
		private int opl_p3;
	}
}

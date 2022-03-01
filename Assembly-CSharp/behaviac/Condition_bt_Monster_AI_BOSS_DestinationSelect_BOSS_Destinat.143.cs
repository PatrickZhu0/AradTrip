using System;

namespace behaviac
{
	// Token: 0x0200308C RID: 12428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node34 : Condition
	{
		// Token: 0x060149DD RID: 84445 RVA: 0x00634C77 File Offset: 0x00633077
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060149DE RID: 84446 RVA: 0x00634CAC File Offset: 0x006330AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E339 RID: 58169
		private int opl_p0;

		// Token: 0x0400E33A RID: 58170
		private int opl_p1;

		// Token: 0x0400E33B RID: 58171
		private int opl_p2;

		// Token: 0x0400E33C RID: 58172
		private int opl_p3;
	}
}

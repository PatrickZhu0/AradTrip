using System;

namespace behaviac
{
	// Token: 0x02003086 RID: 12422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node26 : Condition
	{
		// Token: 0x060149D1 RID: 84433 RVA: 0x00634A9F File Offset: 0x00632E9F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060149D2 RID: 84434 RVA: 0x00634AD4 File Offset: 0x00632ED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E32D RID: 58157
		private int opl_p0;

		// Token: 0x0400E32E RID: 58158
		private int opl_p1;

		// Token: 0x0400E32F RID: 58159
		private int opl_p2;

		// Token: 0x0400E330 RID: 58160
		private int opl_p3;
	}
}

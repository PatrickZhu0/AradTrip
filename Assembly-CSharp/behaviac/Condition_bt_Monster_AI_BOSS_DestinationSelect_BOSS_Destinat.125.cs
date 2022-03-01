using System;

namespace behaviac
{
	// Token: 0x02003070 RID: 12400
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node30 : Condition
	{
		// Token: 0x060149A6 RID: 84390 RVA: 0x00633BE7 File Offset: 0x00631FE7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060149A7 RID: 84391 RVA: 0x00633C1C File Offset: 0x0063201C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E303 RID: 58115
		private int opl_p0;

		// Token: 0x0400E304 RID: 58116
		private int opl_p1;

		// Token: 0x0400E305 RID: 58117
		private int opl_p2;

		// Token: 0x0400E306 RID: 58118
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003073 RID: 12403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node34 : Condition
	{
		// Token: 0x060149AC RID: 84396 RVA: 0x00633CD3 File Offset: 0x006320D3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060149AD RID: 84397 RVA: 0x00633D08 File Offset: 0x00632108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E309 RID: 58121
		private int opl_p0;

		// Token: 0x0400E30A RID: 58122
		private int opl_p1;

		// Token: 0x0400E30B RID: 58123
		private int opl_p2;

		// Token: 0x0400E30C RID: 58124
		private int opl_p3;
	}
}

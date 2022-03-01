using System;

namespace behaviac
{
	// Token: 0x02003092 RID: 12434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node6 : Condition
	{
		// Token: 0x060149E8 RID: 84456 RVA: 0x006356FB File Offset: 0x00633AFB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149E9 RID: 84457 RVA: 0x00635730 File Offset: 0x00633B30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E344 RID: 58180
		private int opl_p0;

		// Token: 0x0400E345 RID: 58181
		private int opl_p1;

		// Token: 0x0400E346 RID: 58182
		private int opl_p2;

		// Token: 0x0400E347 RID: 58183
		private int opl_p3;
	}
}

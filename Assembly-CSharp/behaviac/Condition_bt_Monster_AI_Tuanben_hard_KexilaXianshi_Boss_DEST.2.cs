using System;

namespace behaviac
{
	// Token: 0x02003CB2 RID: 15538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node64 : Condition
	{
		// Token: 0x06016109 RID: 90377 RVA: 0x006ABD8B File Offset: 0x006AA18B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node64()
		{
			this.opl_p0 = 6600;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601610A RID: 90378 RVA: 0x006ABDC0 File Offset: 0x006AA1C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9AF RID: 63919
		private int opl_p0;

		// Token: 0x0400F9B0 RID: 63920
		private int opl_p1;

		// Token: 0x0400F9B1 RID: 63921
		private int opl_p2;

		// Token: 0x0400F9B2 RID: 63922
		private int opl_p3;
	}
}

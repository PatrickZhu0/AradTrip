using System;

namespace behaviac
{
	// Token: 0x02003095 RID: 12437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node10 : Condition
	{
		// Token: 0x060149EE RID: 84462 RVA: 0x006357E7 File Offset: 0x00633BE7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149EF RID: 84463 RVA: 0x0063581C File Offset: 0x00633C1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E34A RID: 58186
		private int opl_p0;

		// Token: 0x0400E34B RID: 58187
		private int opl_p1;

		// Token: 0x0400E34C RID: 58188
		private int opl_p2;

		// Token: 0x0400E34D RID: 58189
		private int opl_p3;
	}
}

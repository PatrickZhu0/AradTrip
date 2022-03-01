using System;

namespace behaviac
{
	// Token: 0x02003098 RID: 12440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node14 : Condition
	{
		// Token: 0x060149F4 RID: 84468 RVA: 0x006358D3 File Offset: 0x00633CD3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node14()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060149F5 RID: 84469 RVA: 0x00635908 File Offset: 0x00633D08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E350 RID: 58192
		private int opl_p0;

		// Token: 0x0400E351 RID: 58193
		private int opl_p1;

		// Token: 0x0400E352 RID: 58194
		private int opl_p2;

		// Token: 0x0400E353 RID: 58195
		private int opl_p3;
	}
}

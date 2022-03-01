using System;

namespace behaviac
{
	// Token: 0x020030A7 RID: 12455
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node34 : Condition
	{
		// Token: 0x06014A12 RID: 84498 RVA: 0x00635D6F File Offset: 0x0063416F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node34()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014A13 RID: 84499 RVA: 0x00635DA4 File Offset: 0x006341A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E36E RID: 58222
		private int opl_p0;

		// Token: 0x0400E36F RID: 58223
		private int opl_p1;

		// Token: 0x0400E370 RID: 58224
		private int opl_p2;

		// Token: 0x0400E371 RID: 58225
		private int opl_p3;
	}
}

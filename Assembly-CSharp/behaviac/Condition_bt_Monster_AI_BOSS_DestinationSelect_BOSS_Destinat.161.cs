using System;

namespace behaviac
{
	// Token: 0x020030A9 RID: 12457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node38 : Condition
	{
		// Token: 0x06014A16 RID: 84502 RVA: 0x00635E13 File Offset: 0x00634213
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node38()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014A17 RID: 84503 RVA: 0x00635E48 File Offset: 0x00634248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E373 RID: 58227
		private int opl_p0;

		// Token: 0x0400E374 RID: 58228
		private int opl_p1;

		// Token: 0x0400E375 RID: 58229
		private int opl_p2;

		// Token: 0x0400E376 RID: 58230
		private int opl_p3;
	}
}

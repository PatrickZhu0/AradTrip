using System;

namespace behaviac
{
	// Token: 0x020030A1 RID: 12449
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node26 : Condition
	{
		// Token: 0x06014A06 RID: 84486 RVA: 0x00635B97 File Offset: 0x00633F97
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014A07 RID: 84487 RVA: 0x00635BCC File Offset: 0x00633FCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E362 RID: 58210
		private int opl_p0;

		// Token: 0x0400E363 RID: 58211
		private int opl_p1;

		// Token: 0x0400E364 RID: 58212
		private int opl_p2;

		// Token: 0x0400E365 RID: 58213
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x0200309B RID: 12443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node18 : Condition
	{
		// Token: 0x060149FA RID: 84474 RVA: 0x006359BF File Offset: 0x00633DBF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060149FB RID: 84475 RVA: 0x006359F4 File Offset: 0x00633DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E356 RID: 58198
		private int opl_p0;

		// Token: 0x0400E357 RID: 58199
		private int opl_p1;

		// Token: 0x0400E358 RID: 58200
		private int opl_p2;

		// Token: 0x0400E359 RID: 58201
		private int opl_p3;
	}
}

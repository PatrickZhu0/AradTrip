using System;

namespace behaviac
{
	// Token: 0x020030A4 RID: 12452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node30 : Condition
	{
		// Token: 0x06014A0C RID: 84492 RVA: 0x00635C83 File Offset: 0x00634083
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node30()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014A0D RID: 84493 RVA: 0x00635CB8 File Offset: 0x006340B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E368 RID: 58216
		private int opl_p0;

		// Token: 0x0400E369 RID: 58217
		private int opl_p1;

		// Token: 0x0400E36A RID: 58218
		private int opl_p2;

		// Token: 0x0400E36B RID: 58219
		private int opl_p3;
	}
}

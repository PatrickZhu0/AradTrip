using System;

namespace behaviac
{
	// Token: 0x020029FC RID: 10748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node8 : Condition
	{
		// Token: 0x06013D2A RID: 81194 RVA: 0x005EF179 File Offset: 0x005ED579
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node8()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013D2B RID: 81195 RVA: 0x005EF1B0 File Offset: 0x005ED5B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D79D RID: 55197
		private int opl_p0;

		// Token: 0x0400D79E RID: 55198
		private int opl_p1;

		// Token: 0x0400D79F RID: 55199
		private int opl_p2;

		// Token: 0x0400D7A0 RID: 55200
		private int opl_p3;
	}
}

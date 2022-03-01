using System;

namespace behaviac
{
	// Token: 0x020029FB RID: 10747
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node6 : Condition
	{
		// Token: 0x06013D28 RID: 81192 RVA: 0x005EF0FD File Offset: 0x005ED4FD
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node6()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06013D29 RID: 81193 RVA: 0x005EF134 File Offset: 0x005ED534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D799 RID: 55193
		private int opl_p0;

		// Token: 0x0400D79A RID: 55194
		private int opl_p1;

		// Token: 0x0400D79B RID: 55195
		private int opl_p2;

		// Token: 0x0400D79C RID: 55196
		private int opl_p3;
	}
}

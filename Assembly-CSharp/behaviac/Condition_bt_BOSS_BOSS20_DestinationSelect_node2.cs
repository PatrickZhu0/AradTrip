using System;

namespace behaviac
{
	// Token: 0x020029F8 RID: 10744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_DestinationSelect_node2 : Condition
	{
		// Token: 0x06013D22 RID: 81186 RVA: 0x005EF02C File Offset: 0x005ED42C
		public Condition_bt_BOSS_BOSS20_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D23 RID: 81187 RVA: 0x005EF04C File Offset: 0x005ED44C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D794 RID: 55188
		private BE_Target opl_p0;

		// Token: 0x0400D795 RID: 55189
		private BE_Equal opl_p1;

		// Token: 0x0400D796 RID: 55190
		private BE_State opl_p2;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002A5F RID: 10847
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node17 : Condition
	{
		// Token: 0x06013DE8 RID: 81384 RVA: 0x005F4653 File Offset: 0x005F2A53
		public Condition_bt_Guanka_apc_guijian_jue_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013DE9 RID: 81385 RVA: 0x005F4688 File Offset: 0x005F2A88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D85B RID: 55387
		private int opl_p0;

		// Token: 0x0400D85C RID: 55388
		private int opl_p1;

		// Token: 0x0400D85D RID: 55389
		private int opl_p2;

		// Token: 0x0400D85E RID: 55390
		private int opl_p3;
	}
}

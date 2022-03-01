using System;

namespace behaviac
{
	// Token: 0x02001D21 RID: 7457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node61 : Condition
	{
		// Token: 0x06012405 RID: 74757 RVA: 0x005520DB File Offset: 0x005504DB
		public Condition_bt_APC_APC_Guiqi2_Action_node61()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012406 RID: 74758 RVA: 0x00552110 File Offset: 0x00550510
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDF3 RID: 48627
		private int opl_p0;

		// Token: 0x0400BDF4 RID: 48628
		private int opl_p1;

		// Token: 0x0400BDF5 RID: 48629
		private int opl_p2;

		// Token: 0x0400BDF6 RID: 48630
		private int opl_p3;
	}
}

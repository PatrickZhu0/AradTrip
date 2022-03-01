using System;

namespace behaviac
{
	// Token: 0x02002A0E RID: 10766
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node10 : Condition
	{
		// Token: 0x06013D4C RID: 81228 RVA: 0x005EFE6F File Offset: 0x005EE26F
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node10()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D4D RID: 81229 RVA: 0x005EFEA4 File Offset: 0x005EE2A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7B6 RID: 55222
		private int opl_p0;

		// Token: 0x0400D7B7 RID: 55223
		private int opl_p1;

		// Token: 0x0400D7B8 RID: 55224
		private int opl_p2;

		// Token: 0x0400D7B9 RID: 55225
		private int opl_p3;
	}
}

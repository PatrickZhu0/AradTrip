using System;

namespace behaviac
{
	// Token: 0x02002A09 RID: 10761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node2 : Condition
	{
		// Token: 0x06013D43 RID: 81219 RVA: 0x005EFB22 File Offset: 0x005EDF22
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node2()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D44 RID: 81220 RVA: 0x005EFB58 File Offset: 0x005EDF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7AC RID: 55212
		private int opl_p0;

		// Token: 0x0400D7AD RID: 55213
		private int opl_p1;

		// Token: 0x0400D7AE RID: 55214
		private int opl_p2;

		// Token: 0x0400D7AF RID: 55215
		private int opl_p3;
	}
}

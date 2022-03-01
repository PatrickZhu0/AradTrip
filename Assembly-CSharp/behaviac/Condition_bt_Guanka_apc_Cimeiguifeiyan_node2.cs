using System;

namespace behaviac
{
	// Token: 0x02002A20 RID: 10784
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node2 : Condition
	{
		// Token: 0x06013D6E RID: 81262 RVA: 0x005F0FEE File Offset: 0x005EF3EE
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node2()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D6F RID: 81263 RVA: 0x005F1024 File Offset: 0x005EF424
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7DA RID: 55258
		private int opl_p0;

		// Token: 0x0400D7DB RID: 55259
		private int opl_p1;

		// Token: 0x0400D7DC RID: 55260
		private int opl_p2;

		// Token: 0x0400D7DD RID: 55261
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002A44 RID: 10820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node2 : Condition
	{
		// Token: 0x06013DB3 RID: 81331 RVA: 0x005F3197 File Offset: 0x005F1597
		public Condition_bt_Guanka_apc_guijian_feng_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DB4 RID: 81332 RVA: 0x005F31CC File Offset: 0x005F15CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D823 RID: 55331
		private int opl_p0;

		// Token: 0x0400D824 RID: 55332
		private int opl_p1;

		// Token: 0x0400D825 RID: 55333
		private int opl_p2;

		// Token: 0x0400D826 RID: 55334
		private int opl_p3;
	}
}

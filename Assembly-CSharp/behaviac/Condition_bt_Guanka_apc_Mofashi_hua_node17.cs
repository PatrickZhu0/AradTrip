using System;

namespace behaviac
{
	// Token: 0x02002A8A RID: 10890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node17 : Condition
	{
		// Token: 0x06013E38 RID: 81464 RVA: 0x005F6C4A File Offset: 0x005F504A
		public Condition_bt_Guanka_apc_Mofashi_hua_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013E39 RID: 81465 RVA: 0x005F6C80 File Offset: 0x005F5080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8AC RID: 55468
		private int opl_p0;

		// Token: 0x0400D8AD RID: 55469
		private int opl_p1;

		// Token: 0x0400D8AE RID: 55470
		private int opl_p2;

		// Token: 0x0400D8AF RID: 55471
		private int opl_p3;
	}
}

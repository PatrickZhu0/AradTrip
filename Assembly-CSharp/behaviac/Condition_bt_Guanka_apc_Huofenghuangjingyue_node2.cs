using System;

namespace behaviac
{
	// Token: 0x02002A78 RID: 10872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Huofenghuangjingyue_node2 : Condition
	{
		// Token: 0x06013E16 RID: 81430 RVA: 0x005F6031 File Offset: 0x005F4431
		public Condition_bt_Guanka_apc_Huofenghuangjingyue_node2()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E17 RID: 81431 RVA: 0x005F6068 File Offset: 0x005F4468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D888 RID: 55432
		private int opl_p0;

		// Token: 0x0400D889 RID: 55433
		private int opl_p1;

		// Token: 0x0400D88A RID: 55434
		private int opl_p2;

		// Token: 0x0400D88B RID: 55435
		private int opl_p3;
	}
}

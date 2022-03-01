using System;

namespace behaviac
{
	// Token: 0x02002A7C RID: 10876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Huofenghuangjingyue_node9 : Condition
	{
		// Token: 0x06013E1E RID: 81438 RVA: 0x005F6312 File Offset: 0x005F4712
		public Condition_bt_Guanka_apc_Huofenghuangjingyue_node9()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E1F RID: 81439 RVA: 0x005F6348 File Offset: 0x005F4748
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D892 RID: 55442
		private int opl_p0;

		// Token: 0x0400D893 RID: 55443
		private int opl_p1;

		// Token: 0x0400D894 RID: 55444
		private int opl_p2;

		// Token: 0x0400D895 RID: 55445
		private int opl_p3;
	}
}

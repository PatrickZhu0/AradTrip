using System;

namespace behaviac
{
	// Token: 0x02002AAF RID: 10927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node2 : Condition
	{
		// Token: 0x06013E7D RID: 81533 RVA: 0x005F8A23 File Offset: 0x005F6E23
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013E7E RID: 81534 RVA: 0x005F8A58 File Offset: 0x005F6E58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8F0 RID: 55536
		private int opl_p0;

		// Token: 0x0400D8F1 RID: 55537
		private int opl_p1;

		// Token: 0x0400D8F2 RID: 55538
		private int opl_p2;

		// Token: 0x0400D8F3 RID: 55539
		private int opl_p3;
	}
}

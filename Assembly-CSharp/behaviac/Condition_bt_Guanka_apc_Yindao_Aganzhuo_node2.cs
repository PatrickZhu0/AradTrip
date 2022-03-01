using System;

namespace behaviac
{
	// Token: 0x02002AD3 RID: 10963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Yindao_Aganzhuo_node2 : Condition
	{
		// Token: 0x06013EC0 RID: 81600 RVA: 0x005FA89E File Offset: 0x005F8C9E
		public Condition_bt_Guanka_apc_Yindao_Aganzhuo_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013EC1 RID: 81601 RVA: 0x005FA8D4 File Offset: 0x005F8CD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D931 RID: 55601
		private int opl_p0;

		// Token: 0x0400D932 RID: 55602
		private int opl_p1;

		// Token: 0x0400D933 RID: 55603
		private int opl_p2;

		// Token: 0x0400D934 RID: 55604
		private int opl_p3;
	}
}

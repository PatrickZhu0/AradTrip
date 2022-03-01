using System;

namespace behaviac
{
	// Token: 0x02002A8F RID: 10895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node2 : Condition
	{
		// Token: 0x06013E41 RID: 81473 RVA: 0x005F72D7 File Offset: 0x005F56D7
		public Condition_bt_Guanka_apc_Mofashi_li_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013E42 RID: 81474 RVA: 0x005F730C File Offset: 0x005F570C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8B4 RID: 55476
		private int opl_p0;

		// Token: 0x0400D8B5 RID: 55477
		private int opl_p1;

		// Token: 0x0400D8B6 RID: 55478
		private int opl_p2;

		// Token: 0x0400D8B7 RID: 55479
		private int opl_p3;
	}
}

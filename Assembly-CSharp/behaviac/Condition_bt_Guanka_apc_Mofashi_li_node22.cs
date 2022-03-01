using System;

namespace behaviac
{
	// Token: 0x02002A9C RID: 10908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node22 : Condition
	{
		// Token: 0x06013E5A RID: 81498 RVA: 0x005F781B File Offset: 0x005F5C1B
		public Condition_bt_Guanka_apc_Mofashi_li_node22()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E5B RID: 81499 RVA: 0x005F7850 File Offset: 0x005F5C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8CE RID: 55502
		private int opl_p0;

		// Token: 0x0400D8CF RID: 55503
		private int opl_p1;

		// Token: 0x0400D8D0 RID: 55504
		private int opl_p2;

		// Token: 0x0400D8D1 RID: 55505
		private int opl_p3;
	}
}

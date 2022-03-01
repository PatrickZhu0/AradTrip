using System;

namespace behaviac
{
	// Token: 0x02002A28 RID: 10792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node15 : Condition
	{
		// Token: 0x06013D7E RID: 81278 RVA: 0x005F1650 File Offset: 0x005EFA50
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013D7F RID: 81279 RVA: 0x005F1684 File Offset: 0x005EFA84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7EC RID: 55276
		private int opl_p0;

		// Token: 0x0400D7ED RID: 55277
		private int opl_p1;

		// Token: 0x0400D7EE RID: 55278
		private int opl_p2;

		// Token: 0x0400D7EF RID: 55279
		private int opl_p3;
	}
}

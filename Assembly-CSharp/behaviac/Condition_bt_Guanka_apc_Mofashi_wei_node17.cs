using System;

namespace behaviac
{
	// Token: 0x02002AAA RID: 10922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node17 : Condition
	{
		// Token: 0x06013E74 RID: 81524 RVA: 0x005F8396 File Offset: 0x005F6796
		public Condition_bt_Guanka_apc_Mofashi_wei_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E75 RID: 81525 RVA: 0x005F83CC File Offset: 0x005F67CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8E8 RID: 55528
		private int opl_p0;

		// Token: 0x0400D8E9 RID: 55529
		private int opl_p1;

		// Token: 0x0400D8EA RID: 55530
		private int opl_p2;

		// Token: 0x0400D8EB RID: 55531
		private int opl_p3;
	}
}

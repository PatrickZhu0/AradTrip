using System;

namespace behaviac
{
	// Token: 0x02002AA6 RID: 10918
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node9 : Condition
	{
		// Token: 0x06013E6C RID: 81516 RVA: 0x005F81E2 File Offset: 0x005F65E2
		public Condition_bt_Guanka_apc_Mofashi_wei_node9()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E6D RID: 81517 RVA: 0x005F8218 File Offset: 0x005F6618
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8E0 RID: 55520
		private int opl_p0;

		// Token: 0x0400D8E1 RID: 55521
		private int opl_p1;

		// Token: 0x0400D8E2 RID: 55522
		private int opl_p2;

		// Token: 0x0400D8E3 RID: 55523
		private int opl_p3;
	}
}

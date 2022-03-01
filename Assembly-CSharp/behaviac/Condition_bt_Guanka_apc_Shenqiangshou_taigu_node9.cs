using System;

namespace behaviac
{
	// Token: 0x02002AC4 RID: 10948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node9 : Condition
	{
		// Token: 0x06013EA4 RID: 81572 RVA: 0x005F9A23 File Offset: 0x005F7E23
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013EA5 RID: 81573 RVA: 0x005F9A58 File Offset: 0x005F7E58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D916 RID: 55574
		private int opl_p0;

		// Token: 0x0400D917 RID: 55575
		private int opl_p1;

		// Token: 0x0400D918 RID: 55576
		private int opl_p2;

		// Token: 0x0400D919 RID: 55577
		private int opl_p3;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002A86 RID: 10886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node9 : Condition
	{
		// Token: 0x06013E30 RID: 81456 RVA: 0x005F6A96 File Offset: 0x005F4E96
		public Condition_bt_Guanka_apc_Mofashi_hua_node9()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013E31 RID: 81457 RVA: 0x005F6ACC File Offset: 0x005F4ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8A4 RID: 55460
		private int opl_p0;

		// Token: 0x0400D8A5 RID: 55461
		private int opl_p1;

		// Token: 0x0400D8A6 RID: 55462
		private int opl_p2;

		// Token: 0x0400D8A7 RID: 55463
		private int opl_p3;
	}
}

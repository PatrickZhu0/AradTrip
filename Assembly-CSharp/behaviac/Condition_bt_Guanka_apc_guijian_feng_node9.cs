using System;

namespace behaviac
{
	// Token: 0x02002A48 RID: 10824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node9 : Condition
	{
		// Token: 0x06013DBB RID: 81339 RVA: 0x005F341A File Offset: 0x005F181A
		public Condition_bt_Guanka_apc_guijian_feng_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DBC RID: 81340 RVA: 0x005F3450 File Offset: 0x005F1850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D82D RID: 55341
		private int opl_p0;

		// Token: 0x0400D82E RID: 55342
		private int opl_p1;

		// Token: 0x0400D82F RID: 55343
		private int opl_p2;

		// Token: 0x0400D830 RID: 55344
		private int opl_p3;
	}
}

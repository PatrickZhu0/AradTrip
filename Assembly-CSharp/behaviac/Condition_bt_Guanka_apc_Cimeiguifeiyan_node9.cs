using System;

namespace behaviac
{
	// Token: 0x02002A24 RID: 10788
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node9 : Condition
	{
		// Token: 0x06013D76 RID: 81270 RVA: 0x005F12CE File Offset: 0x005EF6CE
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D77 RID: 81271 RVA: 0x005F1304 File Offset: 0x005EF704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7E4 RID: 55268
		private int opl_p0;

		// Token: 0x0400D7E5 RID: 55269
		private int opl_p1;

		// Token: 0x0400D7E6 RID: 55270
		private int opl_p2;

		// Token: 0x0400D7E7 RID: 55271
		private int opl_p3;
	}
}

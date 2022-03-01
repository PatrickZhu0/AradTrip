using System;

namespace behaviac
{
	// Token: 0x02002A22 RID: 10786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node6 : Condition
	{
		// Token: 0x06013D72 RID: 81266 RVA: 0x005F10C7 File Offset: 0x005EF4C7
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013D73 RID: 81267 RVA: 0x005F10DC File Offset: 0x005EF4DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7E1 RID: 55265
		private float opl_p0;
	}
}

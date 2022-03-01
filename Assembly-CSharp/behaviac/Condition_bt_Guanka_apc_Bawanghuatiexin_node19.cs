using System;

namespace behaviac
{
	// Token: 0x02002A13 RID: 10771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node19 : Condition
	{
		// Token: 0x06013D56 RID: 81238 RVA: 0x005F01C9 File Offset: 0x005EE5C9
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node19()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013D57 RID: 81239 RVA: 0x005F01DC File Offset: 0x005EE5DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7C4 RID: 55236
		private float opl_p0;
	}
}

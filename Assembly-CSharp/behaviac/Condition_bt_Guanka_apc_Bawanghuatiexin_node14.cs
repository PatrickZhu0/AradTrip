using System;

namespace behaviac
{
	// Token: 0x02002A10 RID: 10768
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node14 : Condition
	{
		// Token: 0x06013D50 RID: 81232 RVA: 0x005EFF47 File Offset: 0x005EE347
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node14()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013D51 RID: 81233 RVA: 0x005EFF5C File Offset: 0x005EE35C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7BD RID: 55229
		private float opl_p0;
	}
}

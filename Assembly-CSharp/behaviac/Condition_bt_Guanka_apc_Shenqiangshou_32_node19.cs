using System;

namespace behaviac
{
	// Token: 0x02002ABA RID: 10938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node19 : Condition
	{
		// Token: 0x06013E92 RID: 81554 RVA: 0x005F9041 File Offset: 0x005F7441
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E93 RID: 81555 RVA: 0x005F9054 File Offset: 0x005F7454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D907 RID: 55559
		private float opl_p0;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02002AAB RID: 10923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node19 : Condition
	{
		// Token: 0x06013E76 RID: 81526 RVA: 0x005F8411 File Offset: 0x005F6811
		public Condition_bt_Guanka_apc_Mofashi_wei_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E77 RID: 81527 RVA: 0x005F8424 File Offset: 0x005F6824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8EC RID: 55532
		private float opl_p0;
	}
}

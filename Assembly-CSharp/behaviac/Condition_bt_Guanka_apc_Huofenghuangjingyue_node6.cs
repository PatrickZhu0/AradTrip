using System;

namespace behaviac
{
	// Token: 0x02002A7A RID: 10874
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Huofenghuangjingyue_node6 : Condition
	{
		// Token: 0x06013E1A RID: 81434 RVA: 0x005F610B File Offset: 0x005F450B
		public Condition_bt_Guanka_apc_Huofenghuangjingyue_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E1B RID: 81435 RVA: 0x005F6120 File Offset: 0x005F4520
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D88F RID: 55439
		private float opl_p0;
	}
}

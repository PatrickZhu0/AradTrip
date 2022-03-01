using System;

namespace behaviac
{
	// Token: 0x02002A7D RID: 10877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Huofenghuangjingyue_node11 : Condition
	{
		// Token: 0x06013E20 RID: 81440 RVA: 0x005F638D File Offset: 0x005F478D
		public Condition_bt_Guanka_apc_Huofenghuangjingyue_node11()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E21 RID: 81441 RVA: 0x005F63A0 File Offset: 0x005F47A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D896 RID: 55446
		private float opl_p0;
	}
}

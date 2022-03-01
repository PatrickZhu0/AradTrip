using System;

namespace behaviac
{
	// Token: 0x02002A29 RID: 10793
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node17 : Condition
	{
		// Token: 0x06013D80 RID: 81280 RVA: 0x005F16C9 File Offset: 0x005EFAC9
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013D81 RID: 81281 RVA: 0x005F16DC File Offset: 0x005EFADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7F0 RID: 55280
		private float opl_p0;
	}
}

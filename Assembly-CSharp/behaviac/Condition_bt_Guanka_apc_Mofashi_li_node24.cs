using System;

namespace behaviac
{
	// Token: 0x02002A9D RID: 10909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node24 : Condition
	{
		// Token: 0x06013E5C RID: 81500 RVA: 0x005F7895 File Offset: 0x005F5C95
		public Condition_bt_Guanka_apc_Mofashi_li_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013E5D RID: 81501 RVA: 0x005F78A8 File Offset: 0x005F5CA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8D2 RID: 55506
		private float opl_p0;
	}
}

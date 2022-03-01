using System;

namespace behaviac
{
	// Token: 0x02002AC1 RID: 10945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node6 : Condition
	{
		// Token: 0x06013E9E RID: 81566 RVA: 0x005F9777 File Offset: 0x005F7B77
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E9F RID: 81567 RVA: 0x005F978C File Offset: 0x005F7B8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D912 RID: 55570
		private float opl_p0;
	}
}

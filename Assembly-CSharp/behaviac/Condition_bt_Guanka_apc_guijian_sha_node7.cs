using System;

namespace behaviac
{
	// Token: 0x02002A70 RID: 10864
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node7 : Condition
	{
		// Token: 0x06013E07 RID: 81415 RVA: 0x005F567F File Offset: 0x005F3A7F
		public Condition_bt_Guanka_apc_guijian_sha_node7()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013E08 RID: 81416 RVA: 0x005F5694 File Offset: 0x005F3A94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D87C RID: 55420
		private float opl_p0;
	}
}

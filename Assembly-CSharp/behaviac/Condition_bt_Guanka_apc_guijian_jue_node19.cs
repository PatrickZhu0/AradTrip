using System;

namespace behaviac
{
	// Token: 0x02002A60 RID: 10848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node19 : Condition
	{
		// Token: 0x06013DEA RID: 81386 RVA: 0x005F46CD File Offset: 0x005F2ACD
		public Condition_bt_Guanka_apc_guijian_jue_node19()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013DEB RID: 81387 RVA: 0x005F46E0 File Offset: 0x005F2AE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D85F RID: 55391
		private float opl_p0;
	}
}

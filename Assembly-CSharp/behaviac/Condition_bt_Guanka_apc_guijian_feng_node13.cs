using System;

namespace behaviac
{
	// Token: 0x02002A4A RID: 10826
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node13 : Condition
	{
		// Token: 0x06013DBF RID: 81343 RVA: 0x005F34F3 File Offset: 0x005F18F3
		public Condition_bt_Guanka_apc_guijian_feng_node13()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013DC0 RID: 81344 RVA: 0x005F3508 File Offset: 0x005F1908
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D834 RID: 55348
		private float opl_p0;
	}
}

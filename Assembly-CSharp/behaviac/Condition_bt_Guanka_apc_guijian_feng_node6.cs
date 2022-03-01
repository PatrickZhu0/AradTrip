using System;

namespace behaviac
{
	// Token: 0x02002A46 RID: 10822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node6 : Condition
	{
		// Token: 0x06013DB7 RID: 81335 RVA: 0x005F326F File Offset: 0x005F166F
		public Condition_bt_Guanka_apc_guijian_feng_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013DB8 RID: 81336 RVA: 0x005F3284 File Offset: 0x005F1684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D82A RID: 55338
		private float opl_p0;
	}
}

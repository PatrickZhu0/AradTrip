using System;

namespace behaviac
{
	// Token: 0x02002A4E RID: 10830
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node19 : Condition
	{
		// Token: 0x06013DC7 RID: 81351 RVA: 0x005F37BD File Offset: 0x005F1BBD
		public Condition_bt_Guanka_apc_guijian_feng_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013DC8 RID: 81352 RVA: 0x005F37D0 File Offset: 0x005F1BD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D83C RID: 55356
		private float opl_p0;
	}
}

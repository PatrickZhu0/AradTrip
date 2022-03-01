using System;

namespace behaviac
{
	// Token: 0x02002A84 RID: 10884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node6 : Condition
	{
		// Token: 0x06013E2C RID: 81452 RVA: 0x005F69A3 File Offset: 0x005F4DA3
		public Condition_bt_Guanka_apc_Mofashi_hua_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013E2D RID: 81453 RVA: 0x005F69B8 File Offset: 0x005F4DB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8A1 RID: 55457
		private float opl_p0;
	}
}

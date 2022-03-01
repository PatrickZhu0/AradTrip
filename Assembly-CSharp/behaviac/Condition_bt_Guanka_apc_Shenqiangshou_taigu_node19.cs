using System;

namespace behaviac
{
	// Token: 0x02002ACB RID: 10955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node19 : Condition
	{
		// Token: 0x06013EB1 RID: 81585 RVA: 0x005F9E31 File Offset: 0x005F8231
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node19()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013EB2 RID: 81586 RVA: 0x005F9E44 File Offset: 0x005F8244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D925 RID: 55589
		private float opl_p0;
	}
}
